using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using murrty.updater;

namespace youtube_dl_gui {
    internal class UpdateChecker {
        #region Fields & Properties
        private const string KnownUpdaterHash = "B2C17EAC85AC0DF800643C602F4EAF09F93E62822CA3D1B2034D55E5C16EF1CC";
        private const string FfmpegDownloadLink = "https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-essentials.zip";
        public static GithubData LastChecked { get; private set; }
        public static GithubData LastCheckedLatestRelease { get; private set; }
        public static GithubData LastCheckedAllRelease { get; private set; }
        public static GithubData LatestYoutubeDl { get; private set; }
        #endregion

        #region Major methods
        /// <summary>
        /// Checks Github for an update to youtube-dl-gui.
        /// </summary>
        /// <param name="ForceCheck">Determines if the check was forced, so it should respond yes or no.</param>
        public static bool? CheckForUpdate(bool ForceCheck = false, bool AllowSkip = false, Form ParentHandle = null) {
            bool CanRetry = true;
            do {
                Log.Write("Checking for program update.");
                try {
                    if (ForceCheck || (Config.Settings.General.DownloadBetaVersions ? LastCheckedAllRelease is null : LastCheckedLatestRelease is null))
                        RefreshRelease(Program.CurrentVersion, Config.Settings.General.DownloadBetaVersions);
                    CanRetry = false;
                }
                catch (Exception ex) {
                    if (Log.ReportRetriableLanguageException(ex) != DialogResult.Retry)
                        return null;
                }
            } while (CanRetry);

            Log.Write($"Release found: {LastChecked.Version}");

            if (LastChecked.IsNewerVersion) {
                using frmUpdateAvailable Update = new() {
                    BlockSkip = !AllowSkip,
                    UpdateData = LastChecked
                };
                if (ParentHandle is not null && ParentHandle.IsHandleCreated) {
                    switch (ParentHandle is null ? Update.ShowDialog() : ParentHandle.InvokeRequired ? ParentHandle.Invoke(() => Update.ShowDialog(ParentHandle)) : Update.ShowDialog(ParentHandle)) {
                        case DialogResult.Yes: {
                            try {
                                Program.IsUpdating = true;
                                UpdateApplication();
                            }
                            catch (Exception ex) {
                                Log.ReportException(ex);
                                return null;
                            }
                        } break;

                        case DialogResult.Ignore: {
                            if (Config.Settings.General.DownloadBetaVersions) {
                                Config.Settings.Initialization.SkippedBetaVersion = LastCheckedAllRelease.Version;
                            }
                            else {
                                Config.Settings.Initialization.SkippedVersion = LastCheckedLatestRelease.Version;
                            }
                            Config.Settings.Save(ConfigType.Initialization);
                        } break;
                    }
                }
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Updates youtube-dl-gui with the newer version.
        /// </summary>
        public static void UpdateApplication() {
            Log.Write("Running updater.");
            // Delete the file that already exists
            if (File.Exists(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe") && Program.CalculateSha256Hash(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe") != KnownUpdaterHash.ToLowerInvariant()) {
                // Delete the old one & Write the one from resource.
                File.Delete(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe");
            }

            // Write it.
            File.WriteAllBytes(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe", Properties.Resources.youtube_dl_gui_updater);

            // Sanity check the updater.
            if (Program.CalculateSha256Hash(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe") != KnownUpdaterHash.ToLowerInvariant() && MessageBox.Show(Language.dlgUpdaterHashNoMatch, Language.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) {
                File.Delete(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe");
                return;
            }

            Process Updater = new() {
                StartInfo = new() {
                    Arguments = $"-pid {Process.GetCurrentProcess().Id} -hwnd {Program.GetMessagesHandle()}",
                    FileName = Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe",
                    WorkingDirectory = Environment.CurrentDirectory
                }
            };
            Updater.Start();
        }

        /// <summary>
        /// Checks for a update to youtube-dl, and forks.
        /// </summary>
        /// <param name="ForceCheck"></param>
        public static bool CheckForYoutubeDlUpdate(bool ForceCheck = false) {
            if (LatestYoutubeDl == null || LatestYoutubeDl.VersionTag == null || ForceCheck) {
                bool ShouldRetry;
                int TypeIndex = Config.Settings.Downloads.YtdlType switch {
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    4 => 4,
                    _ => 0,
                };

                do {
                    ShouldRetry = false;
                    try {
                        if (Config.Settings.Downloads.useYtdlUpdater && (Config.Settings.General.UseStaticYtdl && !string.IsNullOrEmpty(Config.Settings.General.ytdlPath) && File.Exists(Config.Settings.General.ytdlPath) || File.Exists(Verification.YoutubeDlPath))) {
                            Log.Write("Using youtube-dls' internal updater to update the program.");

                            Process UpdateYoutubeDl = new();
                            UpdateYoutubeDl.StartInfo.Arguments = "-U";

                            if (Config.Settings.General.UseStaticYtdl && !string.IsNullOrWhiteSpace(Config.Settings.General.ytdlPath) && File.Exists(Config.Settings.General.ytdlPath)) {
                                UpdateYoutubeDl.StartInfo.FileName = Config.Settings.General.ytdlPath;
                            }
                            else {
                                string FileName = $"{Program.ProgramPath}\\" + Config.Settings.Downloads.YtdlType switch {
                                    1 => "youtube-dl.exe",
                                    2 => "youtube-dlc.exe",
                                    3 => "youtube-dl-n.exe",
                                    4 => "yt-dlp-n.exe",
                                    _ => "yt-dlp.exe",
                                };

                                if (File.Exists(FileName)) {
                                    UpdateYoutubeDl.StartInfo.FileName = FileName;
                                    FileName = null;
                                }
                                else {
                                    MessageBox.Show(Language.dlgUpdateNoValidYoutubeDl, Language.ApplicationName);
                                    return false;
                                }
                            }
                            UpdateYoutubeDl.Start();

                        }
                        else {
                            GetLatestYoutubeDl(TypeIndex);
                            LatestYoutubeDl.IsNewerVersion = Verification.YoutubeDlVersion != LatestYoutubeDl.VersionTag;
                            return LatestYoutubeDl.IsNewerVersion;
                        }
                    }
                    catch (ApiParsingException APEx) {
                        if (Log.ReportRetriableException(APEx) == DialogResult.Retry) {
                            ShouldRetry = true;
                        }
                        else return false;
                    }
                    catch (WebException WebEx) {
                        if (Log.ReportRetriableException(WebEx,
                        string.Format(GithubLinks.ApplicationDownloadUrl,
                            GithubLinks.Users[TypeIndex],
                            GithubLinks.Repos[TypeIndex],
                            LatestYoutubeDl.VersionTag)
                        ) == DialogResult.Retry) {
                            ShouldRetry = true;
                        }
                        else return false;
                    }
                    catch (ThreadAbortException) {
                        return false;
                    }
                    catch (Exception ex) {
                        if (Log.ReportRetriableException(ex) == DialogResult.Retry) {
                            ShouldRetry = true;
                        }
                        else return false;
                    }
                } while (ShouldRetry);
            }
            Log.Write($"Found youtube-dl version: {LatestYoutubeDl.VersionTag}");
            return LatestYoutubeDl.IsNewerVersion;
        }

        /// <summary>
        /// Updates youtube-dl (or a fork) to their latest release.
        /// </summary>
        public static bool UpdateYoutubeDl(System.Drawing.Point? Location) {
            if (Config.Settings.Downloads.useYtdlUpdater && (Config.Settings.General.UseStaticYtdl && !string.IsNullOrEmpty(Config.Settings.General.ytdlPath) && File.Exists(Config.Settings.General.ytdlPath) || File.Exists(Verification.YoutubeDlPath))) {
                Log.Write("Using youtube-dls' internal updater to update the program.");

                Process UpdateYoutubeDl = new();
                UpdateYoutubeDl.StartInfo.Arguments = "-U";

                if (Config.Settings.General.UseStaticYtdl && !string.IsNullOrWhiteSpace(Config.Settings.General.ytdlPath) && File.Exists(Config.Settings.General.ytdlPath)) {
                    UpdateYoutubeDl.StartInfo.FileName = Config.Settings.General.ytdlPath;
                }
                else {
                    string FileName = $"{Program.ProgramPath}\\" + Config.Settings.Downloads.YtdlType switch {
                        1 => "youtube-dl.exe",
                        2 => "youtube-dlc.exe",
                        3 => "youtube-dl-n.exe",
                        4 => "yt-dlp-n.exe",
                        _ => "yt-dlp.exe",
                    };

                    if (File.Exists(FileName)) {
                        UpdateYoutubeDl.StartInfo.FileName = FileName;
                    }
                    else {
                        MessageBox.Show(Language.dlgUpdateNoValidYoutubeDl, Language.ApplicationName);
                        return false;
                    }
                }
                UpdateYoutubeDl.Start();
                UpdateYoutubeDl.WaitForExit();
                return UpdateYoutubeDl.ExitCode == 0;
            }
            else if (LatestYoutubeDl.IsNewerVersion) {
                Log.Write($"Downloading youtube-dl version {LatestYoutubeDl.VersionTag}.");
                int TypeIndex = Config.Settings.Downloads.YtdlType switch {
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    4 => 4,
                    _ => 0,
                };

                string DownloadUrl = string.Format(GithubLinks.ApplicationDownloadUrl,
                                     GithubLinks.Users[TypeIndex],
                                     GithubLinks.Repos[TypeIndex],
                                     LatestYoutubeDl.VersionTag);

                string FullSavePath = Config.Settings.General.UseStaticYtdl && !string.IsNullOrEmpty(Config.Settings.General.ytdlPath) ?
                    Config.Settings.General.ytdlPath :
                    $"{Program.ProgramPath}\\" + TypeIndex switch {
                        1 => "youtube-dl.exe",
                        2 => "youtube-dlc.exe",
                        3 => "youtube-dl-n.exe",
                        4 => "yt-dlp-n.exe",
                        _ => "yt-dlp.exe",
                    };

                using frmGenericDownloadProgress Downloader = Location is not null ?
                    new(DownloadUrl, FullSavePath, Location.Value) : new(DownloadUrl, FullSavePath);
                if (Downloader.ShowDialog() != DialogResult.OK)
                    return false;

            }
            else {
                return false;
            }

            Verification.RefreshYoutubeDlLocation();
            LatestYoutubeDl.IsNewerVersion = false;
            return true;
        }

        /// <summary>
        /// Updates ffmpeg.
        /// </summary>
        /// <returns><see langword="true"/> if it was updated; otherwise, <see langword="false"/>.</returns>
        public static bool UpdateFfmpeg(System.Drawing.Point? Location) {
            Log.Write("Downloading the latest ffmpeg release.");
            string FfmpegZipPath = Environment.CurrentDirectory + "\\ffmpeg.zip";

            using frmGenericDownloadProgress Downloader =
                Location is not null ? new(FfmpegDownloadLink, FfmpegZipPath, Location.Value) : new(FfmpegDownloadLink, FfmpegZipPath);
            if (Downloader.ShowDialog() != DialogResult.OK)
                return false;

            bool CanRetry = true;
            do {
                try {
                    string FfmpegPath = Verification.FFmpegPath is null ? Environment.CurrentDirectory : Path.GetDirectoryName(Verification.FFmpegPath);
                    using ZipArchive archive = ZipFile.OpenRead(FfmpegZipPath);
                    ZipArchiveEntry[] Files = archive.Entries
                        .Where(e => e.Name.ToLower() switch {
                            "ffmpeg.exe" or "ffprobe.exe" => true,
                            _ => false
                        })
                        .ToArray();

                    if (Files.Length > 0) {
                        for (int i = 0; i < Files.Length; i++)
                            Files[i].ExtractToFile($"{FfmpegPath}\\{Files[i].Name}", true);
                    }
                    else return false;

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

        public static GithubRepoContent[] GetAvailableLanguages() {
            Log.Write("Enumerating languages available.");
            string Url = "https://api.github.com/repos/murrty/youtube-dl-gui/contents/Languages";
            var AvailableLanguages = GetJSON(Url).JsonDeserialize<GithubRepoContent[]>()
                .Where(x => x.name != "English.ini")
                .ToArray();

            if (AvailableLanguages.Length > 0) {
                return AvailableLanguages;
            }
            else throw new ArgumentOutOfRangeException(nameof(AvailableLanguages));
        }
        #endregion

        #region supporting methods
        /// <summary>
        /// Gets a JSON string using an internal web-client.
        /// </summary>
        /// <param name="Url">The URL to download the string from.</param>
        /// <returns>A string from the URL.</returns>
        private static string GetJSON(string Url) {
            try {
                using WebClient wc = new();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                wc.Headers.Add("User-Agent", Program.UserAgent);
                return wc.DownloadString(Url);
            }
            catch { throw; }
        }

        /// <summary>
        /// Refreshes the release data within the application.
        /// </summary>
        /// <param name="CurrentVersion">The current version to be compared against</param>
        /// <param name="PreReleases">Whether to check for pre-releases.</param>
        private static void RefreshRelease(Version CurrentVersion, bool PreReleases) {
            try {
                string Json = GetJSON(
                    string.Format(PreReleases ? GithubLinks.GithubAllReleasesJson : GithubLinks.GithubLatestJson, "murrty", Language.ApplicationName));
                if (string.IsNullOrWhiteSpace(Json)) throw new InvalidOperationException("JSON downloaded was empty");

                GithubData CurrentCheck = null;

                if (PreReleases) {
                    var Releases = Json.JsonDeserialize<GithubData[]>();
                    if (Releases.Length == 0) throw new NullReferenceException("The found releases were empty.");
                    CurrentCheck = GetHighestVersion(Releases);

                    if (CurrentCheck is not null) {
                        LastCheckedAllRelease = CurrentCheck;
                    }
                    else return;
                }
                else {
                    CurrentCheck = Json.JsonDeserialize<GithubData>();
                    LastCheckedLatestRelease = CurrentCheck;
                }

                if (string.IsNullOrWhiteSpace(CurrentCheck.VersionTag)) throw new InvalidOperationException("tag_name was empty");

                CurrentCheck.ParseData(CurrentVersion);
                LastChecked = CurrentCheck;
            }
            catch { throw; }
        }

        /// <summary>
        /// Gets the highest release within an array of release data.
        /// </summary>
        /// <param name="DataArray">The array of GithubData to parse through.</param>
        /// <returns>The GithubData that is deemed as the highest version.</returns>
        private static GithubData GetHighestVersion(GithubData[] DataArray) {
            if (DataArray.Length > 0) {
                GithubData Newest = null;
                Version NewestVersion = Version.Empty;
                for (int i = 0; i < DataArray.Length; i++) {
                    Version Parse = DataArray[i].GetVersion();
                    if (Parse > NewestVersion) {
                        Newest = DataArray[i];
                        NewestVersion = Parse;
                    }
                }
                return Newest;
            }
            return null;
        }

        /// <summary>
        /// Gets the latest github version of the specified fork ID.
        /// </summary>
        /// <param name="GitID">The youtube-dl fork ID from <seealso cref="GithubLinks.GitLinks.Repos"/>, authored by <seealso cref="GithubLinks.GitLinks.Users"/></param>
        /// <returns>The string of the latest version of the specified fork ID.</returns>
        private static string GetLatestYoutubeDl(int GitID) {
            string Url = string.Empty;
            try {
                if (GitID < 0 || GitID + 1 > GithubLinks.Repos.Length)
                    throw new ArgumentOutOfRangeException("GitID", GitID, "The GitID is invalid, youtube-dl cannot be redownloaded.");

                Url = string.Format(GithubLinks.GithubLatestJson, GithubLinks.Users[GitID], GithubLinks.Repos[GitID]);

                string Json = GetJSON(Url);

                if (Json == null)
                    throw new ApiParsingException("The retrieved xml returned null.", Url);

                GithubData CurrentRelease = Json.JsonDeserialize<GithubData>();

                if (LatestYoutubeDl != null && LatestYoutubeDl.VersionTag == CurrentRelease.VersionTag) {
                    return LatestYoutubeDl.VersionTag;
                }

                LatestYoutubeDl = CurrentRelease;
                return LatestYoutubeDl.VersionTag;
            }
            catch (WebException WebEx) {
                Log.ReportException(WebEx, Url);
                return null;
            }
            catch {
                throw;
            }
        }
        #endregion

    }
}