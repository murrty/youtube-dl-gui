namespace youtube_dl_gui_updater;

using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using murrty.controls;
using murrty.logging;
using murrty.updater;

internal static class Github {
    private const int MaxRetries = 5;
    private const int RetryDelay = 1_000;
    private const string LatestRepo = "https://api.github.com/repos/murrty/youtube-dl-gui/releases/latest";
    private const string AllReleaseRepo = "https://api.github.com/repos/murrty/youtube-dl-gui/releases";

    public static async Task<UpdateData> GetUpdateData() {
        bool CanRetry;
        int Retries = 0;
        string Data = null;
        bool CheckForBetaUpdates = Program.Type == DownloadType.PreRelease;
        string URL = CheckForBetaUpdates ? AllReleaseRepo : LatestRepo;

        do {
            try {
                Data = await Program.DownloadClient.DownloadStringTaskAsync(new Uri(URL, UriKind.Absolute), Program.CancelToken.Token);
                CanRetry = false;
            }
            catch (Exception ex) {
                while (ex.InnerException is not null)
                    ex = ex.InnerException;

                if (ex is ThreadAbortException or TaskCanceledException or OperationCanceledException)
                    throw ex;

                if (Retries != MaxRetries && (ex is not HttpException hex || (int)hex.StatusCode > 499)) {
                    await Task.Delay(RetryDelay);
                    Retries++;
                    CanRetry = true;
                    continue;
                }

                switch (Log.ReportException(ex, $"URL: \"{URL}\"", true, true)) {
                    case DialogResult.Retry: {
                        CanRetry = true;
                    } break;
                    case DialogResult.Abort: throw new OperationCanceledException();
                    default: throw ex;
                }
            }
        } while (CanRetry);

        GithubData GithubData;

        if (CheckForBetaUpdates) {
            GithubData[] GithubDatas = await Data.JsonDeserializeAsync<GithubData[]>();
            GithubData = GithubData.GetNewestRelease(GithubDatas);
        }
        else {
            GithubData = await Data.JsonDeserializeAsync<GithubData>();
            if (GithubData is null) {
                throw new Exception("Could not deserialize github data properly.");
            }
        }

        return new UpdateData() {
            FileName = Environment.CurrentDirectory + Path.DirectorySeparatorChar + Language.ApplicationName + ".exe",
            UpdateHash = GithubData.ExecutableHash,
            NewVersion = GithubData.Version,
        };
    }
}