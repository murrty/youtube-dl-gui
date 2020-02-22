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
        public static GitData GitData = GitData.GetInstance();

        public static void CheckForUpdate(bool ForceCheck = false) {
            if (Program.IsDebug) {
                Debug.Print("-version " + GitData.UpdateVersion + " -name " + System.AppDomain.CurrentDomain.FriendlyName);
            }
            else {
                if (!General.Default.checkForUpdates && !ForceCheck) { return; }


                if (GitData.UpdateAvailable) {
                    frmUpdateAvailable Update = new frmUpdateAvailable();
                    Update.BlockSkip = GitData.UpdateAvailable;
                    switch (Update.ShowDialog()) {
                        case DialogResult.Yes:
                            try {
                                UpdateApplication();
                            }
                            catch (Exception ex) {
                                ErrorLog.ReportException(ex);
                            }
                            break;
                    }
                }
                else {
                    Thread checkUpdates = new Thread(() => {
                        if (GitData.UpdateVersion == "-1" || ForceCheck) {
                            decimal GitVersion = UpdateChecker.GetGitVersion(0);
                            if (UpdateChecker.IsUpdateAvailable(GitVersion)) {
                                if (GitVersion != Properties.Settings.Default.SkippedVersion || ForceCheck) {
                                    frmUpdateAvailable Update = new frmUpdateAvailable();
                                    Update.BlockSkip = ForceCheck;
                                    switch (Update.ShowDialog()) {
                                        case DialogResult.Yes:
                                            try {
                                                UpdateApplication();
                                            }
                                            catch (Exception ex) {
                                                ErrorLog.ReportException(ex);
                                            }
                                            break;
                                        case DialogResult.Ignore:
                                            Properties.Settings.Default.SkippedVersion = GitVersion;
                                            Properties.Settings.Default.Save();
                                            break;
                                    }
                                }
                            }
                            else if (ForceCheck) {
                                MessageBox.Show("No updates available.");
                            }
                        }
                    });
                    checkUpdates.Start();
                }
            }
        }
        public static bool CheckForYoutubeDlUpdate() {
            if (GitData.YoutubeDlUpdateAvailable) {
                return GitData.YoutubeDlUpdateAvailable;
            }
            else {
                if (string.IsNullOrEmpty(Properties.Settings.Default.YoutubeDlVersion)) {
                    return true;
                }
                else {
                    GetGitVersionString(1);
                    return (GitData.YoutubeDlVersion == Properties.Settings.Default.YoutubeDlVersion);
                }
            }
        }

        public static void UpdateApplication() {
            var UpdaterBytes = Properties.Resources.youtube_dl_gui_updater;
            File.WriteAllBytes(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe", UpdaterBytes);

            Process Updater = new Process();
            Updater.StartInfo.FileName = Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe";
            string ArgumentsBuffer = "";
            ArgumentsBuffer += "-version " + GitData.UpdateVersion + " -name " + System.AppDomain.CurrentDomain.FriendlyName;
            Updater.Start();
            Environment.Exit(0);
        }
        public static void UpdateYoutubeDl() {
            GetGitVersionString(1);

            if (Downloads.Default.useYtdlUpdater) {
                Process UpdateYoutubeDl = new Process();
                UpdateYoutubeDl.StartInfo.Arguments = "-U";

                if (!General.Default.useStaticYtdl || string.IsNullOrEmpty(General.Default.ytdlPath)) {
                    if (File.Exists(Environment.CurrentDirectory + "\\youtube-dl.exe")) {
                        UpdateYoutubeDl.StartInfo.FileName = Environment.CurrentDirectory + "\\youtube-dl.exe";
                    }
                    else {
                        Thread DownloadYoutubeDl = new Thread(() => {
                            using (WebClient wc = new WebClient()) {
                                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                                wc.Headers.Add("User-Agent: " + Program.UserAgent);
                                try {
                                    wc.DownloadFile(string.Format(GitData.GitLinks.ApplicationDownloadUrl, GitData.GitLinks.Users[1], GitData.GitLinks.ApplciationNames[1], GitData.YoutubeDlVersion), General.Default.ytdlPath);
                                    if (GitData.YoutubeDlVersion != Properties.Settings.Default.YoutubeDlVersion) {
                                        Properties.Settings.Default.YoutubeDlVersion = GitData.YoutubeDlVersion;
                                        Properties.Settings.Default.Save();
                                    }
                                    MessageBox.Show("Youtube-dl has been updated.");
                                }
                                catch (WebException webex) {
                                    ErrorLog.ReportWebException(webex, string.Format(GitData.GitLinks.ApplicationDownloadUrl, GitData.GitLinks.Users[1], GitData.GitLinks.ApplciationNames[1], GitData.YoutubeDlVersion));
                                }
                                catch (Exception ex) {
                                    ErrorLog.ReportException(ex);
                                }
                            }
                        });
                        DownloadYoutubeDl.Start();
                    }
                }
                else {
                    
                    UpdateYoutubeDl.StartInfo.FileName = General.Default.ytdlPath;
                }
                
                UpdateYoutubeDl.Start();
                UpdateYoutubeDl.WaitForExit();
            }
            else {
                if (!General.Default.useStaticYtdl || string.IsNullOrEmpty(General.Default.ytdlPath)) {
                    Thread DownloadYoutubeDl = new Thread(() => {
                        using (WebClient wc = new WebClient()) {
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                            wc.Headers.Add("User-Agent: " + Program.UserAgent);
                            try {
                                wc.DownloadFile(string.Format(GitData.GitLinks.ApplicationDownloadUrl, GitData.GitLinks.Users[1], GitData.GitLinks.ApplciationNames[1], GitData.YoutubeDlVersion), Environment.CurrentDirectory + "\\youtube-dl.exe");
                                if (GitData.YoutubeDlVersion != Properties.Settings.Default.YoutubeDlVersion) {
                                    Properties.Settings.Default.YoutubeDlVersion = GitData.YoutubeDlVersion;
                                    Properties.Settings.Default.Save();
                                }
                                MessageBox.Show("Youtube-dl has been updated.");
                            }
                            catch (WebException webex) {
                                ErrorLog.ReportWebException(webex, string.Format(GitData.GitLinks.ApplicationDownloadUrl, GitData.GitLinks.Users[1], GitData.GitLinks.ApplciationNames[1], GitData.YoutubeDlVersion));
                            }
                            catch (Exception ex) {
                                ErrorLog.ReportException(ex);
                            }
                        }
                    });
                    DownloadYoutubeDl.Start();
                }
                else {
                    Thread DownloadYoutubeDl = new Thread(() => {
                        using (WebClient wc = new WebClient()) {
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                            wc.Headers.Add("User-Agent: " + Program.UserAgent);
                            try {
                                wc.DownloadFile(string.Format(GitData.GitLinks.ApplicationDownloadUrl, GitData.GitLinks.Users[1], GitData.GitLinks.ApplciationNames[1], GitData.YoutubeDlVersion), General.Default.ytdlPath);
                                if (GitData.YoutubeDlVersion != Properties.Settings.Default.YoutubeDlVersion) {
                                    Properties.Settings.Default.YoutubeDlVersion = GitData.YoutubeDlVersion;
                                    Properties.Settings.Default.Save();
                                }
                                MessageBox.Show("Youtube-dl has been updated.");
                            }
                            catch (WebException webex) {
                                ErrorLog.ReportWebException(webex, string.Format(GitData.GitLinks.ApplicationDownloadUrl, GitData.GitLinks.Users[1], GitData.GitLinks.ApplciationNames[1], GitData.YoutubeDlVersion));
                            }
                            catch (Exception ex) {
                                ErrorLog.ReportException(ex);
                            }
                        }
                    });
                    DownloadYoutubeDl.Start();
                }
            }
        }

        public static string GetJSON(string url) {
            if (!Properties.Settings.Default.jsonSupport)
                return null;

            try {
                using (WebClient wc = new WebClient()) {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    wc.Headers.Add("User-Agent: " + Program.UserAgent);
                    string json = wc.DownloadString(url);
                    byte[] bytes = Encoding.ASCII.GetBytes(json);
                    using (var stream = new MemoryStream(bytes)) {
                        var quotas = new XmlDictionaryReaderQuotas();
                        var jsonReader = JsonReaderWriterFactory.CreateJsonReader(stream, quotas);
                        var xml = XDocument.Load(jsonReader);
                        stream.Flush();
                        stream.Close();
                        return xml.ToString();
                    }
                }
            }
            catch (WebException WebE) {
                ErrorLog.ReportWebException(WebE, url);
                return null;
                throw WebE;
            }
            catch (Exception ex) {
                ErrorLog.ReportException(ex);
                return null;
                throw ex;
            }
        }
        public static string GetGitVersionString(int GitID) {
            try {
                string xml = null;
                if (!Program.IsDebug) {
                    switch (GitID) {
                        case 0:
                            xml = GetJSON("http://localhost/youtube-dl-gui/latest.json");
                            break;
                        case 1:
                            xml = GetJSON("http://localhost/youtube-dl/latest.json");
                            break;
                    }
                }
                else { 
                    xml = GetJSON(string.Format(GitData.GitLinks.GithubLatestJson, GitData.GitLinks.Users[GitID], GitData.GitLinks.ApplciationNames[GitID]));
                }

                if (xml == null)
                    return null;

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlNodeList xmlTag = doc.DocumentElement.SelectNodes("/root/tag_name");

                if (GitID == 0) {
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
        public static decimal GetGitVersion(int GitID) {
            try {
                string xml = GetJSON(string.Format(GitData.GitLinks.GithubLatestJson, GitData.GitLinks.Users[GitID], GitData.GitLinks.ApplciationNames[GitID]));
                if (xml == null)
                    return -1;

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlNodeList xmlTag = doc.DocumentElement.SelectNodes("/root/tag_name");

                if (GitID == 0) {
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
        public static bool IsUpdateAvailable(decimal cloudVersion) {
            try {
                if (Properties.Settings.Default.appVersion < cloudVersion) { return true; }
                else { return false; }
            }
            catch (Exception ex) {
                ErrorLog.ReportException(ex);
                return false;
            }
        }

    }

    public class GitData {

        public class GitLinks {
            public static readonly string GithubRawUrl = "https://raw.githubusercontent.com/{0}/{1}";
            public static readonly string GithubRepoUrl = "https://github.com/{0}/{1}";
            public static readonly string GithubLatestJson = "http://api.github.com/repos/{0}/{1}/releases/latest";
            public static readonly string ApplicationDownloadUrl = "https://github.com/{0}/{1}/releases/download/{2}/{1}.exe";

            public static readonly string[] Users = { "murrty", "ytdl-org" };
            public static readonly string[] ApplciationNames = { "youtube-dl-gui", "youtube-dl" };

            public static decimal GetGitVersionDecimal(string InputVersion) {
                return decimal.Parse(InputVersion.Replace(".", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator), NumberStyles.Any, CultureInfo.InvariantCulture);
            }
        }

        private static GitData CloudDataInstance = new GitData();
        private static volatile string UpdateVersionString = "-1";
        private static volatile string UpdateNameString = "UpdateNameString";
        private static volatile string UpdateBodyString = "UpdateBodyString";
        private static volatile bool UpdateAvailableBool = false;
        private static volatile string YoutubeDlVersionString = "YoutubeDlVersion";
        private static volatile bool YoutubeDlUpdateAvailableBool = false;

        public static GitData GetInstance() {
            return CloudDataInstance;
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
        public bool YoutubeDlUpdateAvailable {
            get { return YoutubeDlUpdateAvailableBool; }
            set { YoutubeDlUpdateAvailableBool = value; }
        }
    }
}