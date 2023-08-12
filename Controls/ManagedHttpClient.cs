namespace murrty.controls;

using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

internal sealed class ManagedHttpClient : IDisposable {
    internal const long DefaultBuffer = 2048L; //81920L;
    internal const int ProgressReportTime = 25;
    internal const int EstimateReportTime = 1000 / ProgressReportTime;
    private static readonly TimeSpan ProgressThrottle = TimeSpan.FromMilliseconds(ProgressReportTime);
    private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(60);

    private delegate void ProgressFinishedCallback();

    private readonly Timer ProgressReportTimer;
    private readonly ProgressFinishedCallback FinishedCallback;
    private static SynchronizationContext SyncThread;

    public event EventHandler<DownloadProgressChangedEventArgs> ProgressChanged;
    public event EventHandler<DownloadFinishedEventArgs> DownloadComplete;

    private long CurrentProgress;
    private long CurrentTotalSize;
    private long ByteEstimate;
    private long ByteEstimateBuffer;
    private int EstimateTime;

    public bool IsBusy { get; private set; } = false;
    public bool Disposed { get; private set; } = false;
    public static HttpClient DownloadClientStatic { get; private set; }
    public static bool UseProxy { get; private set; }
    public HttpClient DownloadClient { get; private set; }

    static ManagedHttpClient() {
        SyncThread = SynchronizationContext.Current;
    }
    public ManagedHttpClient() {
        this.ProgressReportTimer = new(
            SyncThread is null ? OnProgressThrottleTicked_NoSyncContext : OnProgressThrottleTicked,
            null, Timeout.Infinite, Timeout.Infinite);

        FinishedCallback = SyncThread is null ? OnProgressFinished_NoSyncContext : OnProgressFinished;
        DownloadClient = DownloadClientStatic;
    }

    public void UpdateInstancedDownloadClient() {
        DownloadClient = DownloadClientStatic;
    }

    public static bool UpdateDownloadClient(string UserAgent) {
        HttpClientHandler handler = new() {
            UseCookies = true,
        };
        DownloadClientStatic = new(handler) {
            Timeout = DefaultTimeout,
        };

        DownloadClientStatic.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
        DownloadClientStatic.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
        //DownloadClientStatic.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("br"));

        DownloadClientStatic.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("*"));
        DownloadClientStatic.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
        DownloadClientStatic.DefaultRequestHeaders.ConnectionClose = false;
        DownloadClientStatic.DefaultRequestHeaders.Add("Keep-Alive", "600");

        DownloadClientStatic.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
        return true;
    }
    public static bool UpdateSyncContext(SynchronizationContext Context) {
        if (SyncThread is null || SyncThread != Context) {
            SyncThread = Context;
            return true;
        }
        return false;
    }
    private static async Task<HttpException> GetException(HttpResponseMessage Response) {
        using Stream ResponseStream = await Response.Content.ReadAsStreamAsync();
        byte[] ResponseContent = Response.Content.Headers.ContentEncoding.FirstOrDefault() switch {
            "gzip" => await WebDecompress.GetGZip(ResponseStream),
            "deflate" => await WebDecompress.GetDeflate(ResponseStream),
            _ => await WebDecompress.GetRaw(ResponseStream)
        };
        return new HttpException(Response.StatusCode, ResponseContent);
    }

    private void OnProgressThrottleTicked(object state) {
        if (EstimateTime == EstimateReportTime) {
            EstimateTime = 0;
            ByteEstimate = ByteEstimateBuffer;
            ByteEstimateBuffer = 0;
        }
        else {
            EstimateTime++;
        }

        if (ProgressChanged is not null)
            SyncThread.Post(st => ProgressChanged.Invoke(this, new(CurrentProgress, CurrentTotalSize, ByteEstimate)), null);
    }
    private void OnProgressThrottleTicked_NoSyncContext(object state) {
        if (EstimateTime == EstimateReportTime) {
            EstimateTime = 0;
            ByteEstimate = ByteEstimateBuffer;
            ByteEstimateBuffer = 0;
        }
        else {
            EstimateTime++;
        }
        ProgressChanged?.Invoke(this, new(CurrentProgress, CurrentTotalSize, ByteEstimate));
    }

    private void OnProgressFinished() {
        if (DownloadComplete is not null)
            SyncThread.Post(st => DownloadComplete.Invoke(this, new(CurrentProgress)), null);
    }
    private void OnProgressFinished_NoSyncContext() {
        DownloadComplete?.Invoke(this, new(CurrentProgress));
    }

    public async Task DownloadFileTaskAsync(Uri uri, string destination, CancellationToken Token) {
        try {
            using HttpResponseMessage Response = await DownloadClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead, Token);

            if (!Response.IsSuccessStatusCode)
                throw await GetException(Response);

            CurrentTotalSize = Response.Content.Headers.ContentLength ?? 0;

            using FileStream Destination = new(
                path: destination,
                mode: FileMode.Create,
                access: FileAccess.ReadWrite,
                share: FileShare.Read);
            using Stream ContentStream = await Response.Content.ReadAsStreamAsync();

            await WriteStream(ContentStream, Destination, Token);
            await Destination.FlushAsync();
            Destination.Close();
            FinishedCallback();
        }
        finally {
            ProgressReportTimer.Change(Timeout.Infinite, Timeout.Infinite);
            CurrentProgress = 0L;
            CurrentTotalSize = 0L;
            EstimateTime = 0;
            ByteEstimate = 0;
            ByteEstimateBuffer = 0;
        }
    }
    public async Task<string> DownloadStringTaskAsync(Uri uri, CancellationToken Token) {
        try {
            using HttpResponseMessage Response = await DownloadClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead, Token);

            if (!Response.IsSuccessStatusCode)
                throw await GetException(Response);

            CurrentTotalSize = Response.Content.Headers.ContentLength ?? 0;

            using MemoryStream Destination = new();
            using Stream ContentStream = await Response.Content.ReadAsStreamAsync();

            await WriteStream(ContentStream, Destination, Token);
            await Destination.FlushAsync();
            FinishedCallback();

            byte[] Bytes = Response.Content.Headers.ContentEncoding.FirstOrDefault() switch {
                "gzip" => await WebDecompress.GetGZip(Destination),
                "deflate" => await WebDecompress.GetDeflate(Destination),
                _ => await WebDecompress.GetRaw(Destination),
            };

            return (Response.Content.Headers.ContentType.CharSet ?? "utf-8").ToLowerInvariant() switch {
                "ascii" => Encoding.ASCII.GetString(Bytes),
                "utf-7" => Encoding.UTF7.GetString(Bytes),
                "utf-32" => Encoding.UTF32.GetString(Bytes),
                "utf-16" or "unicode" => Encoding.Unicode.GetString(Bytes),
                "utf-16-be" or "utf-16be" or "unicode-be" or "unicodebe" => Encoding.BigEndianUnicode.GetString(Bytes),
                _ => Encoding.UTF8.GetString(Bytes),
            };
        }
        finally {
            ProgressReportTimer.Change(Timeout.Infinite, Timeout.Infinite);
            CurrentProgress = 0L;
            CurrentTotalSize = 0L;
            EstimateTime = 0;
            ByteEstimate = 0;
            ByteEstimateBuffer = 0;
        }
    }

    private async Task WriteStream(Stream Source, Stream Writer, CancellationToken Token) {
        byte[] buffer = new byte[DefaultBuffer];
        int bytesRead;
        EstimateTime = 35;

        ProgressReportTimer.Change(ProgressThrottle, ProgressThrottle);
        while ((bytesRead = await Source.ReadAsync(buffer, 0, buffer.Length, Token).ConfigureAwait(false)) > 0) {
            await Writer.WriteAsync(buffer, 0, bytesRead, Token).ConfigureAwait(false);
            CurrentProgress += bytesRead;
            ByteEstimateBuffer += bytesRead;
        }
        ProgressReportTimer.Change(Timeout.Infinite, Timeout.Infinite);
    }

    public void Dispose() {
        Dispose(true);
    }
    private void Dispose(bool disposing) {
        if (disposing && !Disposed) {
            ProgressReportTimer.Dispose();
            Disposed = true;
        }
    }
}