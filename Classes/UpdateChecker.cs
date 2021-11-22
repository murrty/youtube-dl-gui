using System;
using System.Diagnostics;
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

        public static readonly GitData GitInfo = new GitData();
        private static readonly bool bypassDebug = true;

        #region Major methods
        /// <summary>
        /// Checks Github for an update to youtube-dl-gui.
        /// </summary>
        /// <param name="ForceCheck">Determines if the check was forced, so it should respond yes or no.</param>
        public static void CheckForUpdate(bool ForceCheck = false) {
            bool FailedToCheck = false;

            try {
                // Debug some things from here, if the program is debug and bypass debug is false.
                if (Program.IsDebug && !bypassDebug) {
                    Debug.Print("-version " + GitInfo.UpdateVersion + " -name " + AppDomain.CurrentDomain.FriendlyName);
                    return;
                }

                if (GitInfo.UpdateAvailable) {
                    using (frmUpdateAvailable Update = new frmUpdateAvailable()) {
                        Update.BlockSkip = ForceCheck;
                        switch (Update.ShowDialog()) {
                            case DialogResult.Yes:
                                try {
                                    UpdateApplication();
                                }
                                catch (Exception ex) {
                                    ErrorLog.Report(ex);
                                    return;
                                }
                                break;
                        }
                    }
                }
                else {
                    if (GitInfo.UpdateVersion == "-1" || ForceCheck) {
                        if (Config.Settings.General.DownloadBetaVersions) {
                            string LatestReleaseVersion = GetLatestPreRelease();
                            if (IsBetaUpdateAvailable(LatestReleaseVersion)) {
                                GitInfo.UpdateAvailable = true;
                                if (LatestReleaseVersion != Config.Settings.Initialization.SkippedBetaVersion || ForceCheck) {
                                    using (frmUpdateAvailable Update = new frmUpdateAvailable()) {
                                        Update.BlockSkip = ForceCheck;
                                        switch (Update.ShowDialog()) {
                                            case DialogResult.Yes:
                                                try {
                                                    UpdateApplication();
                                                }
                                                catch (Exception ex) {
                                                    ErrorLog.Report(ex);
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
                            else if (string.IsNullOrWhiteSpace(LatestReleaseVersion)) {
                                switch (MessageBox.Show("The git version returned null/whitespace, which means it didn't properly check. Would you like to manually check?", "youtube-dl-gui", MessageBoxButtons.YesNo)) {
                                    case DialogResult.Yes:
                                        Process.Start(string.Format(GitData.GitLinks.GithubRepoUrl + "/releases/latest", "murrty", "youtube-dl-gui"));
                                        break;
                                }
                            }
                            else if (ForceCheck) {
                                MessageBox.Show("No updates available.");
                            }
                        }
                        else {
                            decimal GitVersion = GetLatestRelease();
                            Debug.Print(GitVersion.ToString());
                            if (IsUpdateAvailable(GitVersion)) {
                                GitInfo.UpdateAvailable = true;
                                if (GitVersion != Config.Settings.Initialization.SkippedVersion || ForceCheck) {
                                    using (frmUpdateAvailable Update = new frmUpdateAvailable()) {
                                        Update.BlockSkip = ForceCheck;
                                        switch (Update.ShowDialog()) {
                                            case DialogResult.Yes:
                                                try {
                                                    UpdateApplication();
                                                }
                                                catch (Exception ex) {
                                                    ErrorLog.Report(ex);
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
                            else if (GitVersion == -1) {
                                // if the GitVersion is STILL -1 for some ungodly reason, set it as failed to check.
                                FailedToCheck = true;
                            }
                            else if (ForceCheck) {
                                MessageBox.Show("No updates available.\r\n\r\nCurrent version: " + Properties.Settings.Default.CurrentVersion + "\r\nLatest version: " + GitVersion, "youtube-dl-gui");
                            }
                        }

                    }
                }
            }
            catch (ApiParsingException APEx) {
                FailedToCheck = true;
                ErrorLog.Report(APEx);
            }
            catch (DecimalParsingException DPEx) {
                FailedToCheck = true;
                ErrorLog.Report(DPEx);
            }
            catch (WebException WebEx) {
                FailedToCheck = true;
                if (Config.Settings.General.DownloadBetaVersions) {
                    ErrorLog.Report(WebEx,
                        string.Format(
                            GitData.GitLinks.GithubAllReleasesJson,
                            "murrty",
                            "youtube-dl-gui"
                        )
                    );
                }
                else {
                    ErrorLog.Report(WebEx,
                        string.Format(
                            GitData.GitLinks.GithubLatestJson,
                            "murrty",
                            "youtube-dl-gui"
                        )
                    );
                }
            }
            catch (Exception ex) {
                FailedToCheck = true;
                ErrorLog.Report(ex);
            }
            finally {
                if (FailedToCheck) {
                    if (MessageBox.Show("The update check has failed. Would you like to manually check?", "youtube-dl-gui", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                        Process.Start(string.Format(GitData.GitLinks.GithubRepoUrl + "/releases/latest", "murrty", "youtube-dl-gui"));
                    }
                }
            }
        }

        public static void UpdateApplication() {
            File.WriteAllBytes(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe", Properties.Resources.youtube_dl_gui_updater);

            Process Updater = new Process();
            Updater.StartInfo.FileName = Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe";
            string ArgumentsBuffer = "";
            ArgumentsBuffer += "-v " + GitInfo.UpdateVersion + " -n " + System.AppDomain.CurrentDomain.FriendlyName;
            Updater.StartInfo.Arguments = ArgumentsBuffer;
            Updater.Start();
            Environment.Exit(0);
        }

        public static void UpdateYoutubeDl() {
            try {
                GetLatestYoutubeDl(3);
                if (Config.Settings.Downloads.useYtdlUpdater && Config.Settings.General.UseStaticYtdl && !string.IsNullOrEmpty(Config.Settings.General.ytdlPath) && File.Exists(Config.Settings.General.ytdlPath) || Config.Settings.Downloads.useYtdlUpdater && File.Exists(Program.verif.YoutubeDlPath)) {

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
                            MessageBox.Show("Could not find a valid youtube-dl program.", "youtube-dl-gui");
                            return;
                        }
                    }

                    UpdateYoutubeDl.Start();

                }
                else {
                    int TypeIndex;
                    switch (Config.Settings.Downloads.YtdlType) {
                        case 1:
                            TypeIndex = 1;
                            break;
                        case 2:
                            TypeIndex = 2;
                            break;

                        default:
                            TypeIndex = 0;
                            break;
                    }
                    GitInfo.YoutubeDlVersion = GetLatestYoutubeDl(TypeIndex);

                    if (Program.verif.YoutubeDlVersion != GitInfo.YoutubeDlVersion) {
                        string FullSavePath = null;
                        string DownloadUrl = string.Format(GitData.GitLinks.ApplicationDownloadUrl,
                                             GitData.GitLinks.Users[TypeIndex],
                                             GitData.GitLinks.Repos[TypeIndex],
                                             GitInfo.YoutubeDlVersion);

                        if (Config.Settings.General.UseStaticYtdl && !string.IsNullOrEmpty(Config.Settings.General.ytdlPath)) {
                            FullSavePath = Config.Settings.General.ytdlPath;
                        }
                        else {
                            switch (TypeIndex) {
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

                                    wc.DownloadFile(DownloadUrl, FullSavePath);

                                    Program.verif.RefreshYoutubeDlLocation();

                                    MessageBox.Show("Youtube-dl has been updated.");
                                }
                                catch (WebException webex) {

                                    ErrorLog.Report(
                                        webex,
                                        string.Format(
                                            GitData.GitLinks.ApplicationDownloadUrl,
                                            GitData.GitLinks.Users[TypeIndex],
                                            GitData.GitLinks.Repos[TypeIndex],
                                            GitInfo.YoutubeDlVersion
                                        )
                                    );

                                }
                                catch (Exception ex) {
                                    ErrorLog.Report(ex);
                                }
                            }
                        }) {
                            Name = "Downloading youtube-dl"
                        };
                        DownloadYoutubeDl.Start();

                    }
                    else {
                        switch (MessageBox.Show("Youtube-dl does not require an update at this moment.\r\n\r\nCurrent version: " + Program.verif.YoutubeDlVersion + "\r\nLatest release: " + GitInfo.YoutubeDlVersion, "youtube-dl-gui", MessageBoxButtons.RetryCancel)) {
                            case DialogResult.Retry:
                                UpdateYoutubeDl();
                                break;
                        }

                    }
                }
            }
            catch (ApiParsingException APEx) {
                ErrorLog.Report(APEx);
            }
            catch (DecimalParsingException DPEx) {
                ErrorLog.Report(DPEx);
            }
            catch (WebException WebEx) {
                ErrorLog.Report(WebEx,
                    string.Format(
                        GitData.GitLinks.GithubLatestJson,
                        "murrty",
                        "youtube-dl-gui"
                    )
                );
            }
            catch (Exception ex) {
                ErrorLog.Report(ex);
            }
        }
        #endregion

        #region supporting methods
        /// <summary>
        /// Gets the (Json converted) Xml data of an API.
        /// </summary>
        /// <param name="Url"> The Url of the API to download and convert.</param>
        /// <returns>The string of the (Json converted) Xml data from the input Url</returns>
        private static string GetJSON(string Url) {
            try {
                using (WebClient wc = new WebClient()) {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    wc.Headers.Add("User-Agent: " + Program.UserAgent);

                    using (MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(wc.DownloadString(Url)))) {
                        XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(stream, new XmlDictionaryReaderQuotas()));
                        stream.Flush();
                        stream.Close();
                        return xml.ToString();
                    }
                }
            }
            catch {
                throw;
            }
        }
        /// <summary>
        /// Gets the latest release from Github.
        /// </summary>
        /// <returns>The <seealso cref="decimal"/> value of the latest release.</returns>
        private static decimal GetLatestRelease() {
            // Create local string for URL to be used.
            string Url = string.Format(
                GitData.GitLinks.GithubLatestJson,
                "murrty",
                "youtube-dl-gui"
            );

            try {
                // Get the api info as a local string
                string Xml = GetJSON(Url);

                // if the xml is null, throw a parsing exception
                if (Xml == null) throw new ApiParsingException("The retrieved xml returned null.",Url);
                
                // Load the api data into an xml document
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Xml);

                // Check the ChildNodes count
                switch (doc.ChildNodes.Count) {
                    case 0: // Critical, no information is in the xml document.
                        throw new ApiParsingException("The retrieved Xml does not contain any information.", Url, Xml);

                    case 1: // Highly suspicious, may only be the declaration.
                        throw new ApiParsingException("The retrieved Xml only contains 1 ChildNode, and will not be parsed.", Url, Xml);
                }

                // Initialize the NoteLists of the 3 required pieces of info.
                XmlNodeList xmlTag = doc.DocumentElement.SelectNodes("/root/tag_name");
                XmlNodeList xmlName = doc.DocumentElement.SelectNodes("/root/name");
                XmlNodeList xmlBody = doc.DocumentElement.SelectNodes("/root/body");

                // If the tag does not contain any information, the API did not retrieve properly.
                // Throw an API Parsing Exception if it's empty, this is a critical variable.
                if (xmlTag.Count == 0) throw new ApiParsingException("The tag was not properly retrieved. It may be a change in API, or a temporary issue.", Url, Xml);
                else GitInfo.UpdateVersion = xmlTag[0].InnerText;

                // The update name isn't critical, so if it failed to retrieve, we can put a placeholder.
                if (xmlName.Count == 0) GitInfo.UpdateName = "Unable to retrieve the update name from the API. This may be a change in API, or a temporary issue.";
                else GitInfo.UpdateName = xmlName[0].InnerText;

                // Same thing as above, placeholder if it failed to retrieve.
                if (xmlBody.Count == 0) GitInfo.UpdateBody = "Unable to retrieve the update body from the API. This may be a change in API, or a temporary issue.";
                else GitInfo.UpdateBody = xmlBody[0].InnerText;

                // Tries to parse the UpdateVersion as a decimal for comparison.
                // Throw a decimal parsing exception if it fails, this is a critical parse.
                if (decimal.TryParse(GitInfo.UpdateVersion, out decimal NewVersion)) return NewVersion;
                else throw new DecimalParsingException("The Github version was not able to be parsed.", Xml);

            }
            catch (WebException WebEx) {
                ErrorLog.Report(WebEx, Url);
                return -1;
            }
            catch {
                throw;
            }
        }
        /// <summary>
        /// Gets the latest release, including pre-releases, from Github.
        /// </summary>
        /// <returns>The <seealso cref="string"/> value of the latest release, either pre-release or latest.</returns>
        private static string GetLatestPreRelease() {
            // Create local string for URL to be used.
            string Url = string.Format(
                GitData.GitLinks.GithubAllReleasesJson,
                "murrty",
                "youtube-dl-gui"
            );

            try {
                // Get the api info as a local string
                string Xml = GetJSON(Url);

                // if the xml is null, throw a parsing exception
                if (Xml == null) throw new ApiParsingException("The retrieved xml returned null.", Url);
                
                // Load the api data into an xml document
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Xml);

                // Check the ChildNodes count
                switch (doc.ChildNodes.Count) {
                    case 0: // Critical, no information is in the xml document.
                        throw new ApiParsingException("The retrieved Xml does not contain any information.", Url, Xml);

                    case 1: // Highly suspicious, may only be the declaration.
                        throw new ApiParsingException("The retrieved Xml only contains 1 ChildNode, and will not be parsed.", Url, Xml);
                }

                // Initialize the NoteLists of the 3 required pieces of info.
                XmlNodeList xmlTag = doc.DocumentElement.SelectNodes("/root/tag_name");
                XmlNodeList xmlName = doc.DocumentElement.SelectNodes("/root/name");
                XmlNodeList xmlBody = doc.DocumentElement.SelectNodes("/root/body");

                // If the tag does not contain any information, the API did not retrieve properly.
                // Throw an API Parsing Exception if it's empty, this is a critical variable.
                if (xmlTag.Count == 0) throw new ApiParsingException("The tag was not properly retrieved. It may be a change in API, or a temporary issue.", Url, Xml);
                else GitInfo.UpdateVersion = xmlTag[0].InnerText;

                // The update name isn't critical, so if it failed to retrieve, we can put a placeholder.
                if (xmlName.Count == 0) GitInfo.UpdateName = "Unable to retrieve the update name from the API. This may be a change in API, or a temporary issue.";
                else GitInfo.UpdateName = xmlName[0].InnerText;

                // Same thing as above, placeholder if it failed to retrieve.
                if (xmlBody.Count == 0) GitInfo.UpdateBody = "Unable to retrieve the update body from the API. This may be a change in API, or a temporary issue.";
                else GitInfo.UpdateBody = xmlBody[0].InnerText;

                return GitInfo.UpdateVersion;
            }
            catch (WebException WebEx) {
                ErrorLog.Report(WebEx, Url);
                return null;
            }
            catch {
                throw;
            }
        }
        /// <summary>
        /// Gets the latest github version of the specified fork ID.
        /// </summary>
        /// <param name="GitID">The youtube-dl fork ID from <seealso cref="GitData.GitLinks.Repos"/>, authored by <seealso cref="GitData.GitLinks.Users"/></param>
        /// <returns>The string of the latest version of the specified fork ID.</returns>
        private static string GetLatestYoutubeDl(int GitID) {
            try {
                if (GitID > 0 || GitID + 1 < GitData.GitLinks.Repos.Length)
                    throw new ArgumentOutOfRangeException("GitID", GitID, "The GitID is invalid, youtube-dl cannot be redownloaded.");
            }
            catch {
                throw;
            }

            string Url = string.Format(
                GitData.GitLinks.GithubLatestJson,
                GitData.GitLinks.Users[GitID],
                GitData.GitLinks.Repos[GitID]);

            try {
                string Xml = GetJSON(Url);

                if (Xml == null) throw new ApiParsingException("The retrieved xml returned null.", Url);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Xml);
                switch (doc.ChildNodes.Count) {
                    case 0: // Critical, no information is in the xml document.
                        throw new ApiParsingException("The retrieved Xml does not contain any information.", Url, Xml);

                    case 1: // Highly suspicious, may only be the declaration.
                        throw new ApiParsingException("The retrieved Xml only contains 1 ChildNode, and will not be parsed.", Url, Xml);
                }

                XmlNodeList xmlTag = doc.DocumentElement.SelectNodes("/root/tag_name");
                GitInfo.YoutubeDlVersion = xmlTag[0].InnerText;
                return GitInfo.YoutubeDlVersion;
            }
            catch (WebException WebEx) {
                ErrorLog.Report(WebEx, Url);
                return null;
            }
            catch {
                throw;
            }
        }

        /// <summary>
        /// Determines if an update is available from the latest releases.
        /// </summary>
        /// <param name="cloudVersion">The <seealso cref="decimal"/> version of the latest version on Github.</param>
        /// <returns>A bool based on if the Github version is greater than the current version.</returns>
        private static bool IsUpdateAvailable(decimal cloudVersion) {
            return Properties.Settings.Default.CurrentVersion < cloudVersion;
        }
        /// <summary>
        /// Determines if an update is available from the latest releases, including pre-releases.
        /// </summary>
        /// <param name="cloudVersion">The <seealso cref="string"/> version of the latest version on Github.</param>
        /// <returns>A bool based on if the Github version is different than the current version.</returns>
        private static bool IsBetaUpdateAvailable(string cloudVersion) {
            if (Properties.Settings.Default.IsBetaVersion) {
                return cloudVersion != Properties.Settings.Default.BetaVersion;
            }
            else {
                return cloudVersion != Properties.Settings.Default.CurrentVersion.ToString();
            }
        }
        #endregion

        public class UpdateDebug {
            public static void UpdateAvailable() {
                bool OldGitUpdateAvailable = GitInfo.UpdateAvailable;
                string[] UpdateArray = { GitInfo.UpdateName, GitInfo.UpdateBody, GitInfo.UpdateVersion };
                GitInfo.UpdateAvailable = true;
                GitInfo.UpdateName = "An update";
                GitInfo.UpdateBody = "A new update is available. Not really.\nNew line escape sequence works! Use \\n\n\nhello world";
                GitInfo.UpdateVersion = "1.0";
                using (frmUpdateAvailable Update = new frmUpdateAvailable()) { Update.ShowDialog(); }
                GitInfo.UpdateAvailable = OldGitUpdateAvailable;
                GitInfo.UpdateName = UpdateArray[0];
                GitInfo.UpdateBody = UpdateArray[1];
                GitInfo.UpdateVersion = UpdateArray[2];
            }
        }
    }

    public class GitData {

        public enum GitID : int {
            None = -1,
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

            public static readonly string[] Users = { "ytdl-org", "blackjack4494", "yt-dlp" };
            public static readonly string[] Repos = { "youtube-dl", "youtube-dlc", "yt-dlp" };
        }

        public string UpdateVersion = "-1";
        public string UpdateName = "UpdateNameString";
        public string UpdateBody = "UpdateBodyString";
        public bool UpdateAvailable = false;
        public string YoutubeDlVersion = "0000.00.00";
        //public bool YoutubeDlUpdateAvailableBool = false;

        public string GithubIssuesLink {
            get { return string.Format(GitLinks.GithubIssuesUrl, "murrty", "youtube-dl-gui"); }
        }
    }


}