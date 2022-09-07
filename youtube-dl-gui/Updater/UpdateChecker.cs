using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

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

        private const string KnownUpdaterHash = "08D2E8CC6B3608077DA129201572997A2A8148E0BCE04AA089900C37EFF73C6D";
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

            return PreRelease ?
                LastCheckedAllRelease is not null && LastCheckedAllRelease.IsNewerVersion :
                LastCheckedLatestRelease is not null && LastCheckedLatestRelease.IsNewerVersion;
        }

        /// <summary>
        /// Updates youtube-dl-gui with the newer version.
        /// </summary>
        public static void UpdateApplication() {
            // Delete the file that already exists
            if (File.Exists(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe") && Program.CalculateSha256Hash(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe") != KnownUpdaterHash.ToLower()) {
                // Delete the old one & Write the one from resource.
                File.Delete(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe");
            }

            // Write it.
            File.WriteAllBytes(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe", Properties.Resources.youtube_dl_gui_updater);

            // Sanity check the updater.
            if (Program.CalculateSha256Hash(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe") != KnownUpdaterHash.ToLower() && MessageBox.Show(Language.dlgUpdaterHashNoMatch, "youtube-dl-gui", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) {
                File.Delete(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe");
                return;
            }

            Program.RemoveTrayIcon();
            Process Updater = new() {
                StartInfo = new() {
                    Arguments = $"-v {LastChecked.Version} -n {AppDomain.CurrentDomain.FriendlyName} -l {Environment.CurrentDirectory + "\\lang\\" + Config.Settings.Initialization.LanguageFile + ".ini"}{(LastChecked.ExecutableHash is not null ? $" -h {LastChecked.ExecutableHash}" : "")}",
                    FileName = Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe",
                    WorkingDirectory = Environment.CurrentDirectory
                }
            };
            Updater.Start();
            Environment.Exit(0);
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
                    _ => 0,
                };

                do {
                    ShouldRetry = false;
                    try {
                        if (Config.Settings.Downloads.useYtdlUpdater && (Config.Settings.General.UseStaticYtdl && !string.IsNullOrEmpty(Config.Settings.General.ytdlPath) && File.Exists(Config.Settings.General.ytdlPath) || File.Exists(Verification.YoutubeDlPath))) {

                            Process UpdateYoutubeDl = new();
                            UpdateYoutubeDl.StartInfo.Arguments = "-U";

                            if (Config.Settings.General.UseStaticYtdl && !string.IsNullOrWhiteSpace(Config.Settings.General.ytdlPath) && File.Exists(Config.Settings.General.ytdlPath)) {
                                UpdateYoutubeDl.StartInfo.FileName = Config.Settings.General.ytdlPath;
                            }
                            else {
                                string FileName = $"{Program.ProgramPath}\\" + Config.Settings.Downloads.YtdlType switch {
                                    1 => "youtube-dlc.exe",
                                    2 => "yt-dlp.exe",
                                    _ => "youtube-dl.exe"
                                };

                                if (File.Exists(FileName)) {
                                    UpdateYoutubeDl.StartInfo.FileName = FileName;
                                    FileName = null;
                                }
                                else {
                                    MessageBox.Show(Language.dlgUpdateNoValidYoutubeDl, "youtube-dl-gui");
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
            return LatestYoutubeDl.IsNewerVersion;
        }

        /// <summary>
        /// Updates youtube-dl (or a fork) to their latest release.
        /// </summary>
        public static bool UpdateYoutubeDl() {
            if (Config.Settings.Downloads.useYtdlUpdater && (Config.Settings.General.UseStaticYtdl && !string.IsNullOrEmpty(Config.Settings.General.ytdlPath) && File.Exists(Config.Settings.General.ytdlPath) || File.Exists(Verification.YoutubeDlPath))) {

                Process UpdateYoutubeDl = new();
                UpdateYoutubeDl.StartInfo.Arguments = "-U";

                if (Config.Settings.General.UseStaticYtdl && !string.IsNullOrWhiteSpace(Config.Settings.General.ytdlPath) && File.Exists(Config.Settings.General.ytdlPath)) {
                    UpdateYoutubeDl.StartInfo.FileName = Config.Settings.General.ytdlPath;
                }
                else {
                    string FileName = $"{Program.ProgramPath}\\" + Config.Settings.Downloads.YtdlType switch {
                        1 => "youtube-dlc.exe",
                        2 => "yt-dlp.exe",
                        _ => "youtube-dl.exe"
                    };

                    if (File.Exists(FileName)) {
                        UpdateYoutubeDl.StartInfo.FileName = FileName;
                    }
                    else {
                        MessageBox.Show(Language.dlgUpdateNoValidYoutubeDl, "youtube-dl-gui");
                        return false;
                    }
                }
                UpdateYoutubeDl.Start();
                UpdateYoutubeDl.WaitForExit();
                return UpdateYoutubeDl.ExitCode == 0;
            }
            else if (LatestYoutubeDl.IsNewerVersion) {
                int TypeIndex = Config.Settings.Downloads.YtdlType switch {
                    1 => 1,
                    2 => 2,
                    _ => 0,
                };

                string DownloadUrl = string.Format(GithubLinks.ApplicationDownloadUrl,
                                     GithubLinks.Users[TypeIndex],
                                     GithubLinks.Repos[TypeIndex],
                                     LatestYoutubeDl.VersionTag);

                string FullSavePath = Config.Settings.General.UseStaticYtdl && !string.IsNullOrEmpty(Config.Settings.General.ytdlPath) ?
                    Config.Settings.General.ytdlPath :
                    Program.ProgramPath + TypeIndex switch {
                        1 => "\\youtube-dlc.exe",
                        2 => "\\yt-dlp.exe",
                        _ => "\\youtube-dl.exe",
                    };

                using WebClient wc = new();
                wc.Headers.Add("User-Agent", Program.UserAgent);

                try {
                    wc.DownloadFile(DownloadUrl, FullSavePath);
                }
                catch (WebException webex) {
                    Log.ReportException(
                        webex,
                        string.Format(
                            GithubLinks.ApplicationDownloadUrl,
                            GithubLinks.Users[TypeIndex],
                            GithubLinks.Repos[TypeIndex],
                            LatestYoutubeDl.VersionTag
                        )
                    );
                }
                catch (ThreadAbortException) { return false; }
                catch (Exception ex) {
                    Log.ReportException(ex);
                    return false;
                }
            }
            else {
                return false;
            }

            Verification.RefreshYoutubeDlLocation();
            LatestYoutubeDl.IsNewerVersion = false;
            return true;
        }

        public static GithubRepoContent[] GetAvailableLanguages() {
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
                    string.Format(PreReleases ? GithubLinks.GithubAllReleasesJson : GithubLinks.GithubLatestJson, "murrty", "youtube-dl-gui"));
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

                LatestYoutubeDl = Json.JsonDeserialize<GithubData>();
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