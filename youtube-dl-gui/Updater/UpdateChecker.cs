using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace youtube_dl_gui {
    internal class UpdateChecker {
        public static bool? CheckForUpdate(Version cur, bool Pre, bool Force = false) {
            bool? result;
            if ((result = updater.UpdateChecker.CheckForUpdate(cur, Pre, Force)) is not null) {
                if (result == true) {
                    using frmUpdateAvailable Update = new() {
                        BlockSkip = Force,
                        UpdateData = updater.UpdateChecker.LastChecked
                    };
                    switch (Update.ShowDialog()) {
                        case DialogResult.Yes: {
                            try {
                                Program.IsUpdating = true;
                                updater.UpdateChecker.UpdateApplication();
                            }
                            catch (Exception ex) {
                                Log.ReportException(ex);
                                return null;
                            }
                        } break;
                        case DialogResult.Ignore: {
                            if (Pre) {
                                Config.Settings.Initialization.SkippedBetaVersion = updater.UpdateChecker.LastCheckedAllRelease.Version;
                            }
                            else {
                                Config.Settings.Initialization.SkippedVersion = updater.UpdateChecker.LastCheckedLatestRelease.Version;
                            }
                            Config.Settings.Save(ConfigType.Initialization);
                        } break;
                    }
                }
                else {

                }
            }
            else {
                Log.ReportException(new Exception("The result from checking for an update was null."));
            }
            return result;
        }
    }
}

namespace youtube_dl_gui.updater {
    internal class UpdateChecker {

        private const string KnownUpdaterHash = "6C3DE407491C863019280E7FE99BEA3CC1572B31B1A0AB04421876ABBDABF527";
        private const string FfmpegDownloadLink = "https://www.gyan.dev/ffmpeg/builds/ffmpeg-release-essentials.zip";
        public static GithubData LastChecked { get; private set; }
        public static GithubData LastCheckedLatestRelease { get; private set; }
        public static GithubData LastCheckedAllRelease { get; private set; }
        public static GithubData LatestYoutubeDl { get; private set; }

        #region Major methods
        /// <summary>
        /// Checks Github for an update to youtube-dl-gui.
        /// </summary>
        /// <param name="ForceCheck">Determines if the check was forced, so it should respond yes or no.</param>
        public static bool? CheckForUpdate(Version CurrentVersion, bool PreRelease, bool ForceCheck = false) {
            bool CanRetry = true;
            do {
                Log.Write("Checking for program update.");
                try {
                    if (ForceCheck || (PreRelease ? LastCheckedAllRelease is null : LastCheckedLatestRelease is null)) {
                        RefreshRelease(CurrentVersion, PreRelease);
                    }
                    CanRetry = false;
                }
                catch (Exception ex) {
                    if (Log.ReportRetriableLanguageException(ex) != DialogResult.Retry) {
                        return null;
                    }
                }
            } while (CanRetry);


            Log.Write($"Release found: {LastChecked.Version}");

            return PreRelease ?
                LastCheckedAllRelease is not null && LastCheckedAllRelease.IsNewerVersion :
                LastCheckedLatestRelease is not null && LastCheckedLatestRelease.IsNewerVersion;
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
            var AvailableLanguages = GetJSON(Url).JsonDeserialize<GithubRepoContent[]>();

            if (AvailableLanguages.Length > 0) {
                return AvailableLanguages;
            }
            else throw new ArgumentOutOfRangeException(nameof(AvailableLanguages));
        }
        #endregion

        #region supporting methods
        public static string GetJSON(string Url) {
            try {
                using WebClient wc = new();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                wc.Headers.Add("User-Agent", Program.UserAgent);
                return wc.DownloadString(Url);
            }
            catch { throw; }
        }

        private static void RefreshRelease(Version oldVersion, bool PreReleases) {
            try {
                string Json = GetJSON(
                    string.Format(PreReleases ? GithubLinks.GithubAllReleasesJson : GithubLinks.GithubLatestJson, "murrty", Language.ApplicationName));
                if (string.IsNullOrWhiteSpace(Json)) throw new InvalidOperationException("JSON downloaded was empty");

                GithubData CurrentCheck = null;

                if (PreReleases) {
                    var Releases = Json.JsonDeserialize<GithubData[]>();
                    if (Releases.Length == 0) throw new NullReferenceException("The found releases were empty.");
                    //for (int i = 0; i < Releases.Length; i++) {
                    //    if (Releases[i].VersionPreRelease) {
                    //        CurrentCheck = Releases[i];
                    //        LastCheckedAllRelease = CurrentCheck;
                    //        break;
                    //    }
                    //}
                    CurrentCheck = Releases[0];
                    LastCheckedAllRelease = CurrentCheck;

                    if (CurrentCheck is null)
                        return;
                }
                else {
                    CurrentCheck = Json.JsonDeserialize<GithubData>();
                    LastCheckedLatestRelease = CurrentCheck;
                }

                if (string.IsNullOrWhiteSpace(CurrentCheck.VersionTag)) throw new InvalidOperationException("tag_name was empty");

                CurrentCheck.ParseData(oldVersion);
                LastChecked = CurrentCheck;
            }
            catch { throw; }
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