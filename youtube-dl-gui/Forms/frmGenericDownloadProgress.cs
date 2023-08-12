namespace youtube_dl_gui;

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using murrty.controls;

public partial class frmGenericDownloadProgress : LocalizedForm {
    public string URL { get; private set; }
    public string Output { get; private set; }
    public string TempFile { get; private set; }
    public string BackupFile { get; private set; }

    private readonly ManagedHttpClient DownloadClient;
    private readonly CancellationTokenSource CancelToken;
    private bool Cancelled = false;
    private bool Finished = false;
    private bool Downloaded = false;

    public frmGenericDownloadProgress(string URL, string Output) : this(URL, Output, null) { }
    public frmGenericDownloadProgress(string URL, string Output, Point? Location) {
        InitializeComponent();
        this.URL = URL;
        this.Output = Output;
        this.TempFile = Output + ".tmp";
        this.BackupFile = Output + ".bck";
        CancelToken = new();
        Log.Write($"Using generic downloader to display progress for '{URL}'.");

        DownloadClient = new();
        this.Load += (s, e) => {
            DownloadClient.ProgressChanged += OnProgressChanged;
            DownloadClient.DownloadComplete += OnDownloadFinished;
            if (Location is not null && Location.HasValue && Location.Value.Valid) {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = Location.Value;
            }
        };

        this.Shown += (s, e) => {
            _ = RunDownload();
        };

        this.FormClosing += (s, e) => {
            if (!Finished) {
                CancelToken.Cancel();
                return;
            }
            DownloadClient.Dispose();
            this.DialogResult = Downloaded ? DialogResult.OK :
                Cancelled ? DialogResult.Cancel : DialogResult.No;
        };
    }

    public override void LoadLanguage() {
        this.Text = Language.frmGenericDownloadProgress;
    }
    private async Task RunDownload() {
        bool CanRetry = true;

        while (CanRetry) {
            try {
                if (File.Exists(TempFile))
                    File.Delete(TempFile);

                await DownloadClient.DownloadFileTaskAsync(new Uri(URL, UriKind.Absolute), TempFile, CancelToken.Token);

                if (File.Exists(BackupFile))
                    File.Delete(BackupFile);

                if (File.Exists(Output))
                    File.Move(Output, BackupFile);

                File.Move(TempFile, Output);

                CanRetry = false;
                Downloaded = true;
            }
            catch (Exception ex) {
                while (ex.InnerException is not null)
                    ex = ex.InnerException;

                if (ex is ThreadAbortException or OperationCanceledException or TaskCanceledException) {
                    Cancelled = true;
                    Finished = true;
                    CanRetry = false;
                }

                if ((DialogResult)this.Invoke(() => Log.ReportRetriableException(ex, URL)) != DialogResult.Retry) {
                    Cancelled = true;
                    Finished = true;
                    CanRetry = false;
                }
            }
        }

        this.Invoke(this.Close);
    }

    private void OnProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
        this.Invoke(() => {
            pbProgress.Value = (int)Math.Floor(e.Percentage);
            pbProgress.Text = $"{e.Percentage}% ({e.BytesReceived.SizeToString()} / {e.TotalBytesToReceive.SizeToString()})";
        });
    }
    private void OnDownloadFinished(object sender, DownloadFinishedEventArgs e) {
        Finished = true;
    }
}