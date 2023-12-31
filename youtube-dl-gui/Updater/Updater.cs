#nullable enable
namespace youtube_dl_gui;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using murrty.controls;
using murrty.logging;
using murrty.updater;
internal static class Updater {
    private const int MaxRetries = 5;
    private const int RetryDelay = 1_000; // Time between retries.

    /// <summary>
    /// This is the known SHA-256 hash of the updater.
    /// </summary>
    private const string KnownUpdaterHash = "53AF690186506C675B1907F5FE4A31D3C7B1CD10F4A62F57297DC4F944D3638B";

    /// <summary>
    /// This is the direct ffmpeg download link.
    /// </summary>
    private const string FfmpegDownloadLink = "https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-essentials.zip";

    private static bool UpdateCheckerRunning;
    private static CancellationTokenSource UpdateToken = new();

    #region Properties
    /// <summary>
    /// Represents the very last checked repository release.
    /// </summary>
    public static GithubData? LastChecked { get; private set; }
    /// <summary>
    /// Represents the last checked latest release from a repository.
    /// </summary>
    public static GithubData? LastCheckedLatestRelease { get; private set; }
    /// <summary>
    /// Represents the last checked any release from a repository (this can include pre-releases).
    /// </summary>
    public static GithubData? LastCheckedAllRelease { get; private set; }

    /// <summary>
    /// Represents the latest youtube-dl provider release.
    /// </summary>
    public static GithubData? LatestYoutubeDl { get; private set; }
    #endregion

    #region Major methods
    [MemberNotNullWhen(true, nameof(LastChecked)), MemberNotNullWhen(false, nameof(LastChecked))]
    public static async Task<bool?> CheckForUpdate(bool ForceCheck) {
        if (!Program.UpdaterEnabled) {
            Log.Write("Cannot check for updates: TLS 1.2+ is not in use.");
            Process.Start("https://github.com/murrty/youtube-dl-gui/releases");
            return null;
        }

        try {
            if (UpdateCheckerRunning) {
                return null;
            }

            if (ForceCheck || (General.DownloadBetaVersions ? LastCheckedAllRelease is null : LastCheckedLatestRelease is null)) {
                UpdateCheckerRunning = true;
                await RefreshRelease();
                UpdateCheckerRunning = false;
            }

            return General.DownloadBetaVersions ?
                LastCheckedAllRelease?.IsNewerVersion == true :
                LastCheckedLatestRelease?.IsNewerVersion == true;
        }
        finally {
            UpdateCheckerRunning = false;
        }
    }
    public static bool IsSkipped() {
        if (LastChecked?.IsBetaVersion == true) {
            return LastChecked.Version == Initialization.SkippedBetaVersion;
        }
        else {
            return LastChecked?.Version == Initialization.SkippedVersion;
        }
    }
    public static void AbortUpdateCheck() {
        UpdateToken.Cancel();
        UpdateToken = new();
    }
    public async static void ShowUpdateForm(bool AllowSkip) {
        if (General.DownloadBetaVersions ? LastCheckedAllRelease is null : LastCheckedLatestRelease is null) {
            await RefreshRelease();
            if (LastChecked?.IsNewerVersion != true) {
                return;
            }
        }

        if (LastChecked is null) {
            return;
        }

        using frmUpdateAvailable UpdateDialog = new(LastChecked) {
            BlockSkip = !AllowSkip,
        };
        switch (UpdateDialog.ShowDialog()) {
            case DialogResult.Yes: {
                BeginUpdate();
            } break;

            case DialogResult.Ignore when AllowSkip: {
                Log.Write($"Ignoring update v{LastChecked.Version}");

                if (General.DownloadBetaVersions) {
                    if (LastCheckedAllRelease is not null) {
                        Initialization.SkippedBetaVersion = LastCheckedAllRelease.Version;
                    }
                }
                else if (LastCheckedLatestRelease is not null) {
                    Initialization.SkippedVersion = LastCheckedLatestRelease.Version;
                }
            } break;
        }
    }
    private static void BeginUpdate() {
        string UpdaterPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "youtube-dl-gui-updater.exe";

        // Delete the file that already exists
        if (File.Exists(UpdaterPath)) {
            if (Program.CalculateSha256Hash(UpdaterPath) != KnownUpdaterHash.ToLowerInvariant()) {
                // Delete the old one & Write the one from resource.
                File.Delete(UpdaterPath);

                // Write it.
                File.WriteAllBytes(UpdaterPath, Properties.Resources.youtube_dl_gui_updater);
            }
        }
        else {
            // Write it.
            File.WriteAllBytes(UpdaterPath, Properties.Resources.youtube_dl_gui_updater);
        }

        // Sanity check the updater.
        if (Program.CalculateSha256Hash(UpdaterPath) != KnownUpdaterHash.ToLowerInvariant() &&
        Log.MessageBox(Language.dlgUpdaterHashNoMatch, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) {
            File.Delete(UpdaterPath);
            return;
        }

        Process Updater = new() {
            StartInfo = new() {
                Arguments = $"-pid {Process.GetCurrentProcess().Id} -hwnd {Program.GetMessagesHandle()}",
                FileName = UpdaterPath,
                WorkingDirectory = Environment.CurrentDirectory
            }
        };
        Log.Write($"Using the pid {Process.GetCurrentProcess().Id} with hwnd {Program.GetMessagesHandle()}");
        Updater.Start();
    }

    /// <summary>
    /// Checks for a update to youtube-dl, and forks.
    /// </summary>
    /// <param name="ForceCheck"></param>
    public static async Task<bool> CheckForYoutubeDlUpdate(bool ForceCheck = false) {
        if (LatestYoutubeDl is null || LatestYoutubeDl.VersionTag is null || ForceCheck) {
            int TypeIndex = Verification.GetYoutubeDlType();
            bool CanRetry;

            do {
                try {
                    Log.Write("Manually checking for youtube-dl update...");
                    // Always get the latest ytdl version regardless of if the application exists.
                    await GetLatestYoutubeDl(TypeIndex);

                    // If the file does not exist, it needs to be re-downloaded.
                    if (!Verification.YoutubeDlAvailable || LatestYoutubeDl is null) {
                        return true;
                    }

                    // Set the is-latest flag in the git data for the ytdl tag.
                    LatestYoutubeDl.IsNewerVersion = Verification.YoutubeDlVersion != LatestYoutubeDl.VersionTag;

                    // Return the flag.
                    return LatestYoutubeDl.IsNewerVersion;
                }
                catch (ApiParsingException APEx) {
                    if (Log.ReportRetriableException(APEx) != DialogResult.Retry)
                        return false;

                    CanRetry = true;
                }
                catch (WebException WebEx) {
                    if (Log.ReportRetriableException(WebEx, GithubLinks.ApplicationDownloadUrl.Format(
                        GithubLinks.ProviderRepos[TypeIndex].User,
                        GithubLinks.ProviderRepos[TypeIndex].Repo,
                        GithubLinks.ProviderRepos[TypeIndex].FriendlyName,
                        LatestYoutubeDl?.VersionTag ?? "0")) != DialogResult.Retry) {
                        return false;
                    }

                    CanRetry = true;
                }
                catch (ThreadAbortException) {
                    return false;
                }
                catch (Exception ex) {
                    if (Log.ReportRetriableException(ex) != DialogResult.Retry) {
                        return false;
                    }

                    CanRetry = true;
                }
            } while (CanRetry);
        }

        Log.Write("Assuming the update check finished.");

        if (LatestYoutubeDl is null) {
            Log.ReportException(new InvalidOperationException("LatestYoutubeDl is still null!"));
            return false;
        }

        Log.Write($"Found youtube-dl version: {LatestYoutubeDl.VersionTag}");
        return LatestYoutubeDl.IsNewerVersion;
    }

    /// <summary>
    /// Updates the current youtube-dl provider to the latest version.
    /// </summary>
    /// <param name="Internal">Whether to use the youtube-dl providers' internal updater as opposed to youtube-dl-guis' updater.</param>
    /// <param name="Location">The location where the generic downloader should appear.</param>
    /// <returns><see langword="true"/> if the youtube-dl provider update has went through regardless of success; otherwise, <see langword="false"/>.</returns>
    public static bool UpdateYoutubeDl(bool Internal, System.Drawing.Point? Location = null) {
        if (LatestYoutubeDl is null) {
            return false;
        }

        if (Internal) {
            if (!Verification.YoutubeDlAvailable) {
                return false;
            }

            Log.Write("Using youtube-dls' internal updater to update the program.");

            Process UpdateYoutubeDl = new() {
                StartInfo = new(Verification.YoutubeDlPath) {
                    Arguments = "-U",
                }
            };
            UpdateYoutubeDl.Start();
            return true;
        }
        else {
            if (Verification.YoutubeDlAvailable && !LatestYoutubeDl.IsNewerVersion) {
                return false;
            }

            Log.Write($"Downloading youtube-dl version {LatestYoutubeDl.VersionTag}.");
            int TypeIndex = Verification.GetYoutubeDlType();

            string DownloadUrl =
                GithubLinks.ApplicationDownloadUrl.Format(
                    GithubLinks.ProviderRepos[TypeIndex].User,
                    GithubLinks.ProviderRepos[TypeIndex].Repo,
                    GithubLinks.ProviderRepos[TypeIndex].FriendlyName,
                    LatestYoutubeDl.VersionTag ?? "0");

            using frmGenericDownloadProgress Downloader = new(DownloadUrl, Verification.YoutubeDlPath ?? Verification.GetExpectedYoutubeDlPath(), Location);
            if (Downloader.ShowDialog() != DialogResult.OK) {
                return false;
            }

            Verification.RefreshYoutubeDlLocation();
            LatestYoutubeDl.IsNewerVersion = false;
            return true;
        }
    }

    /// <summary>
    /// Updates ffmpeg.
    /// </summary>
    /// <returns><see langword="true"/> if it was updated; otherwise, <see langword="false"/>.</returns>
    public static async Task<bool> UpdateFfmpeg(System.Drawing.Point? Location) {
        Log.Write("Downloading the latest ffmpeg release.");
        string FfmpegZipPath = Environment.CurrentDirectory + "\\ffmpeg.zip";

        using frmGenericDownloadProgress Downloader = new(FfmpegDownloadLink, FfmpegZipPath, Location);
        if (Downloader.ShowDialog() != DialogResult.OK) {
            return false;
        }

        bool CanRetry = true;
        do {
            try {
                string FfmpegPath = Verification.FFmpegPath is null ?
                    Environment.CurrentDirectory : Path.GetDirectoryName(Verification.FFmpegPath ?? Verification.GetExpectedFfmpegPath());

                using ZipArchive archive = ZipFile.OpenRead(FfmpegZipPath);
                ZipArchiveEntry[] Files = archive.Entries
                    .Where(e => e.Name.ToLower() switch {
                        "ffmpeg.exe" or "ffprobe.exe" => true,
                        _ => false
                    })
                    .ToArray();

                if (Files.Length > 0) {
                    for (int i = 0; i < Files.Length; i++)
                        await Task.Run(() => Files[i].ExtractToFile($"{FfmpegPath}\\{Files[i].Name}", true));
                }
                else {
                    return false;
                }

                CanRetry = false;
            }
            catch (Exception ex) {
                if (Log.ReportRetriableException(ex) != DialogResult.Retry) {
                    CanRetry = false;
                    return false;
                }
            }
        } while (CanRetry);

        // Delete the zip file.
        File.Delete(FfmpegZipPath);
        Verification.RefreshFFmpegLocation();
        return true;
    }

    /// <summary>
    /// Retrieves the available youtube-dl-gui languages.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static GithubRepoContent[] GetAvailableLanguages() {
        Log.Write("Enumerating languages available.");
        const string Url = "https://api.github.com/repos/murrty/youtube-dl-gui/contents/Languages";

        Task<string?> JsonTask = GetJSON(Url);
        JsonTask.Wait();

        string? JSON = JsonTask.Result;

        if (JSON.IsNullEmptyWhitespace()) {
            throw new NullReferenceException("Github api is null empty or whitespace.");
        }

        var AvailableLanguages = JSON.JsonDeserialize<GithubRepoContent[]>()
            .Where(x => x.name != "English.ini")
            .ToArray();

        return AvailableLanguages.Length > 0 ? AvailableLanguages : throw new ArgumentOutOfRangeException(nameof(AvailableLanguages));
    }
    #endregion

    #region Supporting methods
    /// <summary>
    /// Gets a JSON string using an internal web-client.
    /// </summary>
    /// <param name="Url">The URL to download the string from.</param>
    /// <returns>A string from the URL.</returns>
    private static async Task<string?> GetJSON(string Url) {
        string? Json = null;
        bool CanRetry;
        int Retries = 0;
        do {
            try {
                Json = await Program.HttpClient.DownloadStringTaskAsync(new Uri(Url), CancellationToken.None);
                CanRetry = false;
            }
            catch (Exception ex) {
                while (ex.InnerException is not null) {
                    ex = ex.InnerException;
                }

                if (ex is ThreadAbortException or TaskCanceledException or OperationCanceledException) {
                    throw;
                }

                if (Retries != MaxRetries && (ex is not HttpException hex || (int)hex.StatusCode > 499)) {
                    Log.Write("An exception occurred, retrying...");
                    await Task.Delay(RetryDelay);
                    Retries++;
                    CanRetry = true;
                    continue;
                }

                switch (Log.ReportRetriableException(ex, $"URL: \"{Url}\"")) {
                    case DialogResult.Retry: {
                        CanRetry = true;
                    } break;
                    default: return null;
                }
            }
        } while (CanRetry);

        return Json;
    }

    /// <summary>
    /// Refreshes the release data within the application.
    /// </summary>
    private static async Task RefreshRelease() {
        string? Json = await GetJSON((General.DownloadBetaVersions ? GithubLinks.GithubAllReleasesJson : GithubLinks.GithubLatestJson)
            .Format("murrty", Language.ApplicationName));

        if (Json.IsNullEmptyWhitespace()) {
            throw new InvalidOperationException("JSON downloaded was empty");
        }

        GithubData CurrentCheck;

        if (General.DownloadBetaVersions) {
            GithubData[] Releases = Json.JsonDeserialize<GithubData[]>();
            CurrentCheck = LastCheckedAllRelease = GithubData.GetNewestRelease(Releases);
        }
        else {
            CurrentCheck = Json.JsonDeserialize<GithubData>();
            LastCheckedLatestRelease = CurrentCheck;
        }

        LastChecked = CurrentCheck;
    }

    /// <summary>
    /// Gets the latest github version of the specified fork ID.
    /// </summary>
    /// <param name="GitID">The youtube-dl fork ID from <seealso cref="GithubLinks.GitLinks.Repos"/>, authored by <seealso cref="GithubLinks.GitLinks.Users"/></param>
    /// <returns>The string of the latest version of the specified fork ID.</returns>
    private static async Task GetLatestYoutubeDl(int GitID) {
        if (GitID < 0 || GitID + 1 > GithubLinks.ProviderRepos.Length) {
            throw new ArgumentOutOfRangeException(nameof(GitID), GitID, "The GitID is invalid, youtube-dl cannot be redownloaded.");
        }

        Log.Write("Retrieving Github release data for youtube-dl");

        string Url = GithubLinks.GithubLatestJson.Format(GithubLinks.ProviderRepos[GitID].User, GithubLinks.ProviderRepos[GitID].Repo);
        string Json = await GetJSON(Url)
            .ConfigureAwait(true) ?? throw new ApiParsingException("The retrieved xml returned null.", Url);

        GithubData CurrentRelease = Json.JsonDeserialize<GithubData>();

        if (LatestYoutubeDl is not null && LatestYoutubeDl.VersionTag == CurrentRelease.VersionTag) {
            return;
        }

        LatestYoutubeDl = CurrentRelease;
    }
    #endregion
}