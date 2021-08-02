using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace youtube_dl_gui {
    class UpdateChecker {
        public static bool bypassDebug = true;
        public static GitData GitData = GitData.GetInstance();
        public static Verification verif = Verification.GetInstance();
        private static bool DMCA = false; // Will bypass the youtube-dl check if it gets DMCA'd

        public static void CheckForUpdate(bool ForceCheck = false) {
            if (Program.IsDebug && !bypassDebug) {
                Debug.Print("-version " + GitData.UpdateVersion + " -name " + System.AppDomain.CurrentDomain.FriendlyName);
            }
            else {
                if (!Config.Settings.General.CheckForUpdatesOnLaunch && !ForceCheck) {
                    return;
                }

                if (GitData.UpdateAvailable) {
                    using (frmUpdateAvailable Update = new frmUpdateAvailable()) {
                        Update.BlockSkip = ForceCheck;
                        switch (Update.ShowDialog()) {
                            case DialogResult.Yes:
                                try {
                                    UpdateApplication();
                                }
                                catch (Exception ex) {
                                    ErrorLog.ReportException(ex);
                                    return;
                                }
                                break;
                        }
                    }
                }
                else {
                    if (GitData.UpdateVersion == "-1" || ForceCheck) {

                        if (Config.Settings.General.DownloadBetaVersions) {
                            string LatestReleaseVersion = GetGitLatestReleaseString(0);
                            if (IsBetaUpdateAvailable(LatestReleaseVersion)) {
                                GitData.UpdateAvailable = true;
                                if (LatestReleaseVersion != Config.Settings.Initialization.SkippedBetaVersion || ForceCheck) {
                                    using (frmUpdateAvailable Update = new frmUpdateAvailable()) {
                                        Update.BlockSkip = ForceCheck;
                                        switch (Update.ShowDialog()) {
                                            case DialogResult.Yes:
                                                try {
                                                    UpdateApplication();
                                                }
                                                catch (Exception ex) {
                                                    ErrorLog.ReportException(ex);
                                                    return;
                                                }
                                                break;
                                            case DialogResult.Ignore:
                                                Config.Settings.Initialization.SkippedBetaVersion = LatestReleaseVersion;
                                                Config.Settings.Save(ConfigType.Initialization);
                                                break;
                                        }
                                    }
                                }
                            }
                            else if (ForceCheck) {
                                MessageBox.Show("No updates available.");
                            }
                        }
                        else {
                            decimal GitVersion = GetGitVersion(0);
                            Debug.Print(GitVersion.ToString());
                            if (UpdateChecker.IsUpdateAvailable(GitVersion)) {
                                GitData.UpdateAvailable = true;
                                if (GitVersion != Config.Settings.Initialization.SkippedVersion || ForceCheck) {
                                    using (frmUpdateAvailable Update = new frmUpdateAvailable()) {
                                        Update.BlockSkip = ForceCheck;
                                        switch (Update.ShowDialog()) {
                                            case DialogResult.Yes:
                                                try {
                                                    UpdateApplication();
                                                }
                                                catch (Exception ex) {
                                                    ErrorLog.ReportException(ex);
                                                    return;
                                                }
                                                break;
                                            case DialogResult.Ignore:
                                                Config.Settings.Initialization.SkippedVersion = GitVersion;
                                                Config.Settings.Save(ConfigType.Initialization);
                                                break;
                                        }
                                    }
                                }
                            }
                            else if (ForceCheck) {
                                MessageBox.Show("No updates available.");
                            }
                        }

                    }
                }
            }
        }

        public static void UpdateApplication() {
            var UpdaterBytes = Properties.Resources.youtube_dl_gui_updater;
            File.WriteAllBytes(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe", UpdaterBytes);

            Process Updater = new Process();
            Updater.StartInfo.FileName = Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe";
            string ArgumentsBuffer = "";
            ArgumentsBuffer += "-v " + GitData.UpdateVersion + " -n " + System.AppDomain.CurrentDomain.FriendlyName;
            Updater.StartInfo.Arguments = ArgumentsBuffer;
            Updater.Start();
            Environment.Exit(0);
        }
        public static void UpdateYoutubeDl() {
            if (DMCA) {
                using (WebClient wc = new WebClient()) {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    wc.Headers.Add(HttpRequestHeader.UserAgent, "youtube-dl-gui/" + Properties.Settings.Default.CurrentVersion);

                    if (File.Exists(verif.YoutubeDlPath)) {
                        if (File.Exists(verif.YoutubeDlPath + ".old")) {
                            File.Delete(verif.YoutubeDlPath + ".old");
                        }
                        File.Move(verif.YoutubeDlPath, verif.YoutubeDlPath + ".old");
                    }

                    if (verif.YoutubeDlPath == null) {
                        verif.SetYoutubeDLPath = Environment.CurrentDirectory + "\\youtube-dl.exe";
                    }
                    wc.DownloadFile("https://yt-dl.org/downloads/latest/youtube-dl.exe", verif.YoutubeDlPath);
                }

                return;
            }

            if (Config.Settings.Downloads.useYtdlUpdater && Config.Settings.General.UseStaticYtdl && !string.IsNullOrEmpty(Config.Settings.General.ytdlPath) && File.Exists(Config.Settings.General.ytdlPath) || Config.Settings.Downloads.useYtdlUpdater && File.Exists(Program.ProgramPath + "\\youtube-dl.exe") || Config.Settings.Downloads.useYtdlUpdater && File.Exists(Program.ProgramPath + "\\youtube-dlc.exe") || Config.Settings.Downloads.useYtdlUpdater && File.Exists(Program.ProgramPath + "\\yt-dlp.exe")) {

                Process UpdateYoutubeDl = new Process();
                UpdateYoutubeDl.StartInfo.Arguments = "-U";

                if (Config.Settings.General.UseStaticYtdl && !string.IsNullOrWhiteSpace(Config.Settings.General.ytdlPath) && File.Exists(Config.Settings.General.ytdlPath)) {
                        UpdateYoutubeDl.StartInfo.FileName = Config.Settings.General.ytdlPath;
                }
                else {
                    if (File.Exists(Program.ProgramPath + "\\youtube-dl.exe")) {
                        UpdateYoutubeDl.StartInfo.FileName = Program.ProgramPath + "\\youtube-dl.exe";
                    }
                    else if (File.Exists(Program.ProgramPath + "\\youtube-dlc.exe")) {
                        UpdateYoutubeDl.StartInfo.FileName = Program.ProgramPath + "\\youtube-dlc.exe";
                    }
                    else if (File.Exists(Program.ProgramPath + "\\yt-dlp.exe")) {
                        UpdateYoutubeDl.StartInfo.FileName = Program.ProgramPath + "\\yt-dlp.exe";
                    }
                    else {
                        MessageBox.Show("Could not find a valid youtube-dl program.");
                        return;
                    }
                }

                UpdateYoutubeDl.Start();

            }
            else {
                GitData.YoutubeDlVersion = GetYoutubeDlVersion((Config.Settings.Downloads.YtdlType + 1));

                if (verif.YoutubeDlVersion != GitData.YoutubeDlVersion) {
                    string FullSavePath = null;
                    string DownloadUrl = string.Format(GitData.GitLinks.ApplicationDownloadUrl,
                                         GitData.GitLinks.Users[Config.Settings.Downloads.YtdlType + 1],
                                         GitData.GitLinks.Repos[Config.Settings.Downloads.YtdlType + 1],
                                         GitData.YoutubeDlVersion);

                    if (Config.Settings.General.UseStaticYtdl && !string.IsNullOrEmpty(Config.Settings.General.ytdlPath)) {
                        FullSavePath = Config.Settings.General.ytdlPath;
                    }
                    else {
                        switch (Config.Settings.Downloads.YtdlType) {
                            case 1:
                                FullSavePath = Program.ProgramPath + "\\youtube-dlc.exe";
                                break;

                            case 2:
                                FullSavePath = Program.ProgramPath + "\\yt-dlp.exe";
                                break;

                            default:
                                FullSavePath = Program.ProgramPath + "\\youtube-dl.exe";
                                break;
                        }
                    }

                    Thread DownloadYoutubeDl = new Thread(() => {
                        using (WebClient wc = new WebClient()) {
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                            wc.Headers.Add("User-Agent: " + Program.UserAgent);
                            try {

                                wc.DownloadFile( DownloadUrl, FullSavePath );

                                verif.RefreshYoutubeDlLocation();

                                MessageBox.Show("Youtube-dl has been updated.");
                            }
                            catch (WebException webex) {

                                ErrorLog.ReportWebException(
                                    webex,
                                    string.Format(
                                        GitData.GitLinks.ApplicationDownloadUrl,
                                        GitData.GitLinks.Users[Config.Settings.Downloads.YtdlType + 1],
                                        GitData.GitLinks.Repos[Config.Settings.Downloads.YtdlType + 1],
                                        GitData.YoutubeDlVersion
                                    )
                                );

                            }
                            catch (Exception ex) {
                                ErrorLog.ReportException(ex);
                            }
                        }
                    });
                    DownloadYoutubeDl.Name = "Downloading youtube-dl";
                    DownloadYoutubeDl.Start();

                }
                else {
                    switch (MessageBox.Show("Youtube-dl does not require an update at this moment.\r\n\r\nCurrent version: " + verif.YoutubeDlVersion + "\r\nLatest release: " + GitData.YoutubeDlVersion, "youtube-dl-gui", MessageBoxButtons.RetryCancel)) {
                        case DialogResult.Retry:
                            UpdateYoutubeDl();
                            break;
                    }
                    
                }
            }
        }

        public static string GetJSON(string url) {
            try {
                using (WebClient wc = new WebClient()) {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    wc.Headers.Add("User-Agent: " + Program.UserAgent);
                    string json = wc.DownloadString(url);
                    byte[] bytes = Encoding.ASCII.GetBytes(json);
                    using (MemoryStream stream = new MemoryStream(bytes)) {
                        XmlDictionaryReaderQuotas quotas = new XmlDictionaryReaderQuotas();
                        XmlDictionaryReader jsonReader = JsonReaderWriterFactory.CreateJsonReader(stream, quotas);
                        XDocument xml = XDocument.Load(jsonReader);
                        stream.Flush();
                        stream.Close();
                        return xml.ToString();
                    }
                }

                // maybe having a task in a new thread is wrong, but for the sake of testing; nothing is.
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //using (HttpClient ApiClient = new HttpClient()) {
                //    ApiClient.DefaultRequestHeaders.Add("User-Agent", Program.UserAgent);
                //    string ReturnedString = null;
                //    if (AcquireHeaders) {
                //        var ReturnedContent = await ApiClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
                //        ReturnedString = ReturnedContent.ToString();
                //    }
                //    else {
                //        ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //        ReturnedString = await ApiClient.GetStringAsync(url);
                //    }
                //    return Task.FromResult(ReturnedString);
                //}

            }
            catch (WebException WebE) {
                ErrorLog.ReportWebException(WebE, url);
                return null;
            }
            catch (Exception ex) {
                ErrorLog.ReportException(ex);
                return null;
            }
        }

        // These add 1 to GitID to work around this program being set as -1
        public static string GetGitLatestReleaseString(int GitID) {
            try {
                GitID++;
                string xml = GetJSON(
                    string.Format(GitData.GitLinks.GithubAllReleasesJson,
                    GitData.GitLinks.Users[((int)GitID)],
                    GitData.GitLinks.Repos[((int)GitID)]
                ));

                if (xml == null)
                    return null;

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlNodeList xmlTag = doc.DocumentElement.SelectNodes("/root/item/tag_name");

                if (((int)GitID) == 0) {
                    XmlNodeList xmlName = doc.DocumentElement.SelectNodes("/root/item/name");
                    XmlNodeList xmlBody = doc.DocumentElement.SelectNodes("/root/item/body");


                    GitData.UpdateVersion = xmlTag[0].InnerText;
                    GitData.UpdateName = xmlName[0].InnerText;
                    GitData.UpdateBody = xmlBody[0].InnerText;
                    return GitData.UpdateVersion;
                }
                else {
                    GitData.YoutubeDlVersion = xmlTag[0].InnerText;
                    return GitData.YoutubeDlVersion;
                }


            }
            catch (Exception ex) {
                ErrorLog.ReportException(ex);
                return null;
            }
        }
        public static decimal GetGitVersion(int GitID) {
            try {
                GitID++;
                string xml = GetJSON(string.Format(
                    GitData.GitLinks.GithubLatestJson,
                    GitData.GitLinks.Users[((int)GitID)],
                    GitData.GitLinks.Repos[((int)GitID)]
                ));

                if (xml == null)
                    return -1;

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlNodeList xmlTag = doc.DocumentElement.SelectNodes("/root/tag_name");

                if (((int)GitID) == 0) {
                    XmlNodeList xmlName = doc.DocumentElement.SelectNodes("/root/name");
                    XmlNodeList xmlBody = doc.DocumentElement.SelectNodes("/root/body");


                    GitData.UpdateVersion = xmlTag[0].InnerText;
                    GitData.UpdateName = xmlName[0].InnerText;
                    GitData.UpdateBody = xmlBody[0].InnerText;
                    return GitData.GitLinks.GetGitVersionDecimal(GitData.UpdateVersion);
                }
                else {
                    GitData.YoutubeDlVersion = xmlTag[0].InnerText;
                    return GitData.GitLinks.GetGitVersionDecimal(GitData.YoutubeDlVersion);
                }


            }
            catch (Exception ex) {
                ErrorLog.ReportException(ex);
                return -1;
            }
        }
        public static string GetYoutubeDlVersion(int GitID) {
            try {
                GitID++;
                string xml = GetJSON(string.Format(
                    GitData.GitLinks.GithubLatestJson,
                    GitData.GitLinks.Users[((int)GitID)],
                    GitData.GitLinks.Repos[((int)GitID)]
                ));

                if (xml == null)
                    return null;

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlNodeList xmlTag = doc.DocumentElement.SelectNodes("/root/tag_name");

                if (((int)GitID) == 0) {
                    XmlNodeList xmlName = doc.DocumentElement.SelectNodes("/root/name");
                    XmlNodeList xmlBody = doc.DocumentElement.SelectNodes("/root/body");


                    GitData.UpdateVersion = xmlTag[0].InnerText;
                    GitData.UpdateName = xmlName[0].InnerText;
                    GitData.UpdateBody = xmlBody[0].InnerText;
                    return GitData.UpdateVersion;
                }
                else {
                    GitData.YoutubeDlVersion = xmlTag[0].InnerText;
                    return GitData.YoutubeDlVersion;
                }


            }
            catch (Exception ex) {
                ErrorLog.ReportException(ex);
                return null;
            }
        }

        public static bool IsUpdateAvailable(decimal cloudVersion) {
            try {
                if (Properties.Settings.Default.CurrentVersion < cloudVersion) { return true; }
                else { return false; }
            }
            catch (Exception ex) {
                ErrorLog.ReportException(ex);
                return false;
            }
        }
        public static bool IsBetaUpdateAvailable(string cloudVersion) {
            if (Properties.Settings.Default.IsBetaVersion) {
                return cloudVersion != Properties.Settings.Default.BetaVersion;
            }
            else {
                return cloudVersion != Properties.Settings.Default.CurrentVersion.ToString();
            }
        }

        public class UpdateDebug {
            public static void UpdateAvailable() {
                bool OldGitUpdateAvailable = GitData.UpdateAvailable;
                string[] UpdateArray = { GitData.UpdateName, GitData.UpdateBody, GitData.UpdateVersion };
                GitData.UpdateAvailable = true;
                GitData.UpdateName = "An update";
                GitData.UpdateBody = "A new update is available. Not really.\nNew line escape sequence works! Use \\n\n\nhello world";
                GitData.UpdateVersion = "1.0";
                using (frmUpdateAvailable Update = new frmUpdateAvailable()) { Update.ShowDialog(); }
                GitData.UpdateAvailable = OldGitUpdateAvailable;
                GitData.UpdateName = UpdateArray[0];
                GitData.UpdateBody = UpdateArray[1];
                GitData.UpdateVersion = UpdateArray[2];
            }
        }
    }

    public class GitData {

        public enum GitID : int {
            YoutubeDlGui = -1,
            YoutubeDl = 0,
            YoutubeDlc = 1,
            YoutubeDlp = 2
        }

        public class GitLinks {
            public static readonly string GithubRawUrl = "https://raw.githubusercontent.com/{0}/{1}";
            public static readonly string GithubRepoUrl = "https://github.com/{0}/{1}";
            public static readonly string GithubIssuesUrl = "https://github.com/{0}/{1}/issues";
            public static readonly string GithubLatestJson = "https://api.github.com/repos/{0}/{1}/releases/latest";
            public static readonly string GithubAllReleasesJson = "https://api.github.com/repos/{0}/{1}/releases";
            public static readonly string ApplicationDownloadUrl = "https://github.com/{0}/{1}/releases/download/{2}/{1}.exe";

            public static readonly string[] Users = { "murrty", "ytdl-org", "blackjack4494", "yt-dlp" };
            public static readonly string[] Repos = { "youtube-dl-gui", "youtube-dl", "youtube-dlc", "yt-dlp" };

            public static decimal GetGitVersionDecimal(string InputVersion) {
                return decimal.Parse(InputVersion.Replace(".", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator), NumberStyles.Any, CultureInfo.InvariantCulture);
            }
        }

        private static GitData GitDataInstance = new GitData();
        private static volatile string UpdateVersionString = "-1";
        private static volatile string UpdateNameString = "UpdateNameString";
        private static volatile string UpdateBodyString = "UpdateBodyString";
        private static volatile bool UpdateAvailableBool = false;
        private static volatile string YoutubeDlVersionString = "0000.00.00";
        //private static volatile bool YoutubeDlUpdateAvailableBool = false;

        public static GitData GetInstance() {
            return GitDataInstance;
        }

        public string GithubIssuesLink {
            get { return string.Format(GitLinks.GithubIssuesUrl, GitLinks.Users[0], GitLinks.Repos[0]); }
        }
        public string UpdateVersion {
            get { return UpdateVersionString; }
            set { UpdateVersionString = value; }
        }
        public string UpdateName {
            get { return UpdateNameString; }
            set { UpdateNameString = value; }
        }
        public string UpdateBody {
            get { return UpdateBodyString; }
            set { UpdateBodyString = value; }
        }
        public bool UpdateAvailable {
            get { return UpdateAvailableBool; }
            set { UpdateAvailableBool = value; }
        }

        public string YoutubeDlVersion {
            get { return YoutubeDlVersionString; }
            set { YoutubeDlVersionString = value; }
        }
    }
}