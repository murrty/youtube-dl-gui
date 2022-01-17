using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace youtube_dl_gui {
    class UpdateChecker {

        public static readonly GitData GitInfo = new();
        private static readonly bool bypassDebug = true;
        private const string KnownUpdaterHash = "E88DC3393363067DE7DC88885C8F81C5F9174A920B60B93D0E40099FC87EC9E8";
        private const string SHARegex = "\\b[A-Fa-f0-9]{64}\\b";
        private const string BetaRegex = "[0-9]\\.[0-9]+";

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

                if (GitInfo.UpdateAvailable && !ForceCheck) {
                    using frmUpdateAvailable Update = new();
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
                else {
                    if (Config.Settings.General.DownloadBetaVersions) {
                        string LatestReleaseVersion = GetLatestPreRelease();
                        if (IsBetaUpdateAvailable()) {
                            GitInfo.UpdateAvailable = true;
                            if (LatestReleaseVersion != Config.Settings.Initialization.SkippedBetaVersion || ForceCheck) {
                                using frmUpdateAvailable Update = new();
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
                        else if (string.IsNullOrWhiteSpace(LatestReleaseVersion)) {
                            FailedToCheck = true;
                        }
                        else if (ForceCheck) {
                            if (Properties.Settings.Default.IsBetaVersion) {
                                MessageBox.Show(string.Format(Program.lang.dlgUpdateNoBetaUpdateAvailable, Properties.Settings.Default.BetaVersion, LatestReleaseVersion));
                            }
                            else {
                                MessageBox.Show(string.Format(Program.lang.dlgUpdateNoUpdateAvailable, Properties.Settings.Default.CurrentVersion, LatestReleaseVersion));
                            }
                        }
                    }
                    else {
                        decimal GitVersion = GetLatestRelease();
                        Debug.Print(GitVersion.ToString());
                        if (IsUpdateAvailable(GitVersion)) {
                            GitInfo.UpdateAvailable = true;
                            if (GitVersion != Config.Settings.Initialization.SkippedVersion || ForceCheck) {
                                using frmUpdateAvailable Update = new();
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
                        else if (GitVersion == -1) {
                            // if the GitVersion is STILL -1 for some ungodly reason, set it as failed to check.
                            FailedToCheck = true;
                        }
                        else if (ForceCheck) {
                            if (Properties.Settings.Default.IsBetaVersion) {
                                MessageBox.Show(string.Format(Program.lang.dlgUpdateNoBetaUpdateAvailable + "\r\n\r\nThis may be a wild message to receive.", Properties.Settings.Default.BetaVersion, GitVersion));
                            }
                            else {
                                MessageBox.Show(string.Format(Program.lang.dlgUpdateNoUpdateAvailable, Properties.Settings.Default.CurrentVersion, GitVersion));
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
                    if (MessageBox.Show(Program.lang.dlgUpdateFailedToCheck, "youtube-dl-gui", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes) {
                        Process.Start(string.Format(GitData.GitLinks.GithubRepoUrl + "/releases/latest", "murrty", "youtube-dl-gui"));
                    }
                }
            }
        }

        public static void UpdateApplication() {
            // Delete the file that already exists
            if (File.Exists(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe") && Program.CalculateSha256Hash(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe") != KnownUpdaterHash.ToLower()) {
                // Delete the old one & Write the one from resource.
                File.Delete(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe");
                File.WriteAllBytes(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe", Properties.Resources.youtube_dl_gui_updater);

                // Sanity check the updater.
                if (Program.CalculateSha256Hash(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe") != KnownUpdaterHash.ToLower() && MessageBox.Show(Program.lang.dlgUpdaterHashNoMatch, "youtube-dl-gui", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) {
                    File.Delete(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe");
                    return;
                }
            }
            else {
                // Write it.
                File.WriteAllBytes(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe", Properties.Resources.youtube_dl_gui_updater);

                // Sanity check the updater.
                if (Program.CalculateSha256Hash(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe") != KnownUpdaterHash.ToLower() && MessageBox.Show(Program.lang.dlgUpdaterHashNoMatch, "youtube-dl-gui", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) {
                    File.Delete(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe");
                    return;
                }
            }

            Process Updater = new();
            Updater.StartInfo.FileName = Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe";
            Updater.StartInfo.Arguments =  $"-v {GitInfo.UpdateVersion} -n {AppDomain.CurrentDomain.FriendlyName} -l {Environment.CurrentDirectory + "\\lang\\" + Config.Settings.Initialization.LanguageFile + ".ini"}{(GitInfo.UpdateHash != null ? $" -h {GitInfo.UpdateHash}" : "")}";
            Updater.Start();
            Environment.Exit(0);
        }

        public static void UpdateYoutubeDl() {
            try {
                if (Config.Settings.Downloads.useYtdlUpdater && Config.Settings.General.UseStaticYtdl && !string.IsNullOrEmpty(Config.Settings.General.ytdlPath) && File.Exists(Config.Settings.General.ytdlPath) || Config.Settings.Downloads.useYtdlUpdater && File.Exists(Program.verif.YoutubeDlPath)) {

                    Process UpdateYoutubeDl = new();
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
                            MessageBox.Show(Program.lang.dlgUpdateNoValidYoutubeDl, "youtube-dl-gui");
                            return;
                        }
                    }

                    UpdateYoutubeDl.Start();

                }
                else {
                    int TypeIndex = Config.Settings.Downloads.YtdlType switch {
                        1 => 1,
                        2 => 2,
                        _ => 0,
                    };

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
                            FullSavePath = Program.ProgramPath + TypeIndex switch {
                                1 => "\\youtube-dlc.exe",
                                2 => "\\yt-dlp.exe",
                                _ => "\\youtube-dl.exe",
                            };
                        }

                        Thread DownloadYoutubeDl = new(() => {
                            using WebClient wc = new();
                            wc.Headers.Add("User-Agent: " + Program.UserAgent);
                            try {
                                wc.DownloadFile(DownloadUrl, FullSavePath);
                                Program.verif.RefreshYoutubeDlLocation();
                                MessageBox.Show(Program.lang.dlgUpdatedYoutubeDl, "youtube-dl-gui");
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
                        }) {
                            Name = "Downloading youtube-dl"
                        };
                        DownloadYoutubeDl.Start();

                    }
                    else {
                        switch (MessageBox.Show(string.Format(Program.lang.dlgUpateYoutubeDlNoUpdateRequired, Program.verif.YoutubeDlVersion, GitInfo.YoutubeDlVersion), "youtube-dl-gui", MessageBoxButtons.RetryCancel)) {
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
        public static string GetJSON(string Url) {
            try {
                using WebClient wc = new();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                wc.Headers.Add("User-Agent: " + Program.UserAgent);

                using MemoryStream stream = new(Encoding.ASCII.GetBytes(wc.DownloadString(Url)));
                XDocument xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(stream, new XmlDictionaryReaderQuotas()));
                stream.Flush();
                stream.Close();
                return xml.ToString();
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
                if (Xml == null) throw new ApiParsingException("The retrieved xml returned null.", Url);

                // Load the api data into an xml document
                XmlDocument doc = new();
                doc.LoadXml(Xml);

                // Check the ChildNodes count
                switch (doc.DocumentElement.ChildNodes.Count) {
                    case 0: // Critical, no information is in the xml document.
                        throw new ApiParsingException("The retrieved Xml does not contain any information.", Url, Xml);

                    case 1: // Highly suspicious, may only be the declaration.
                        throw new ApiParsingException("The retrieved Xml only contains 1 ChildNode, and will not be parsed.", Url, Xml);

                    default:
                        if (Program.IsDebug) MessageBox.Show($"{doc.DocumentElement.ChildNodes.Count} total child nodes");
                        break;
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
                else {
                    GitInfo.UpdateBody = xmlBody[0].InnerText;
                    string[] Lines = GitInfo.UpdateBody.ToLower().Replace("\r\n", "\n").Split('\n');
                    if (Lines.Length > 0) {
                        for (int i = 0; i < Lines.Length; i++) {
                            if (Lines[i].Contains("exe") && Lines[i].Contains("sha256") || Lines[i].Contains("sha 256") || Lines[i].Contains("sha-256")) {
                                Match HashMatch = Regex.Match(Lines[i], SHARegex);
                                if (HashMatch.Success) {
                                    GitInfo.UpdateHash = HashMatch.Value;
                                }
                                break;
                            }
                        }
                    }
                }

                // Tries to parse the UpdateVersion as a decimal with an invariant culture for comparison.
                // Throw a decimal parsing exception if it fails, this is a critical parse.
                if (decimal.TryParse(GitInfo.UpdateVersion,
                    System.Globalization.NumberStyles.AllowDecimalPoint,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out decimal NewVersion)) return NewVersion;
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
                XmlDocument doc = new();
                doc.LoadXml(Xml);

                // Check the ChildNodes count
                switch (doc.DocumentElement.ChildNodes.Count) {
                    case 0: // Critical, no information is in the xml document.
                        throw new ApiParsingException("The retrieved Xml does not contain any information.", Url, Xml);

                    case 1: // Highly suspicious, may only be the declaration.
                        throw new ApiParsingException("The retrieved Xml only contains 1 ChildNode, and will not be parsed.", Url, Xml);

                    default:
                        if (Program.IsDebug) MessageBox.Show($"{doc.DocumentElement.ChildNodes.Count} total child nodes");
                        break;
                }

                // Initialize the NoteLists of the 3 required pieces of info.
                XmlNodeList xmlTag = doc.DocumentElement.SelectNodes("/root/item/tag_name");
                XmlNodeList xmlName = doc.DocumentElement.SelectNodes("/root/item/name");
                XmlNodeList xmlBody = doc.DocumentElement.SelectNodes("/root/item/body");

                // If the tag does not contain any information, the API did not retrieve properly.
                // Throw an API Parsing Exception if it's empty, this is a critical variable.
                if (xmlTag.Count == 0) throw new ApiParsingException("The tag was not properly retrieved. It may be a change in API, or a temporary issue.", Url, Xml);
                else GitInfo.UpdateVersion = xmlTag[0].InnerText;

                // The update name isn't critical, so if it failed to retrieve, we can put a placeholder.
                if (xmlName.Count == 0) GitInfo.UpdateName = "Unable to retrieve the update name from the API. This may be a change in API, or a temporary issue.";
                else GitInfo.UpdateName = xmlName[0].InnerText;

                // Same thing as above, placeholder if it failed to retrieve.
                if (xmlBody.Count == 0) GitInfo.UpdateBody = "Unable to retrieve the update body from the API. This may be a change in API, or a temporary issue.";
                else {
                    GitInfo.UpdateBody = xmlBody[0].InnerText;
                    string[] Lines = GitInfo.UpdateBody.ToLower().Replace("\r\n", "\n").Split('\n');
                    if (Lines.Length > 0) {
                        for (int i = 0; i < Lines.Length; i++) {
                            if (Lines[i].Contains("exe") && Lines[i].Contains("sha256") || Lines[i].Contains("sha 256") || Lines[i].Contains("sha-256")) {
                                Match HashMatch = Regex.Match(Lines[i], SHARegex);
                                if (HashMatch.Success) {
                                    GitInfo.UpdateHash = HashMatch.Value;
                                }
                                break;
                            }
                        }
                    }
                }

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

                XmlDocument doc = new();
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
            if (Properties.Settings.Default.IsBetaVersion) {
                return true;
            }
            else {
                return Properties.Settings.Default.CurrentVersion < cloudVersion;
            }
        }

        /// <summary>
        /// Determines if an update is available from the latest releases, including pre-releases.
        /// </summary>
        /// <param name="cloudVersion">The <seealso cref="string"/> version of the latest version on Github.</param>
        /// <returns>A bool based on if the Github version is different than the current version.</returns>
        public static bool IsBetaUpdateAvailable() {
            if (Properties.Settings.Default.IsBetaVersion) {
                return GitInfo.UpdateVersion != Properties.Settings.Default.BetaVersion;
            }
            else {
                // We gotta try to parse the decimal :(
                Match FindVersion = Regex.Match(GitInfo.UpdateVersion, BetaRegex);
                if (FindVersion.Success) {
                    if (decimal.TryParse(FindVersion.Value,
                        System.Globalization.NumberStyles.AllowDecimalPoint,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out decimal NewVersion)) {
                        return NewVersion > Properties.Settings.Default.CurrentVersion;
                    }
                    else throw new DecimalParsingException("Couldn't parse the decimal from the regex match.");
                }
                else throw new DecimalParsingException("The regex couldn't find a match for the version schema.");
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
                using frmUpdateAvailable Update = new();
                Update.ShowDialog();
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

        public string UpdateBody = "UpdateBodyString";
        public string UpdateHash = null;
        public string UpdateName = "UpdateNameString";
        public string UpdateVersion = "-1";
        public bool UpdateAvailable = false;
        public string YoutubeDlVersion = "0000.00.00";
        //public bool YoutubeDlUpdateAvailableBool = false;

        public string GithubIssuesLink {
            get {
                return string.Format(GitLinks.GithubIssuesUrl, "murrty", "youtube-dl-gui");
            }
        }

        public static List<GitLanguageFile> Languages {
            get {
                string Url = "https://api.github.com/repos/murrty/youtube-dl-gui/contents/Languages";
                string Xml = UpdateChecker.GetJSON(Url);

                // if the xml is null, throw a parsing exception
                if (Xml == null) throw new ApiParsingException("The retrieved xml returned null.", Url);

                // Load the api data into an xml document
                XmlDocument doc = new();
                doc.LoadXml(Xml);

                // Check the ChildNodes count
                switch (doc.DocumentElement.ChildNodes.Count) {
                    case 0: // Critical, no information is in the xml document.
                        throw new ApiParsingException("The retrieved Xml does not contain any information.", Url, Xml);

                    case 1: // Highly suspicious, may only be the declaration.
                        throw new ApiParsingException("The retrieved Xml only contains 1 ChildNode, and will not be parsed.", Url, Xml);

                    default:
                        if (Program.IsDebug) MessageBox.Show($"{doc.DocumentElement.ChildNodes.Count} total child nodes");
                        break;
                }

                // Initialize the NoteLists of the 3 required pieces of info.
                XmlNodeList xmlName = doc.DocumentElement.SelectNodes("/root/item/name");
                XmlNodeList xmlSha = doc.DocumentElement.SelectNodes("/root/item/sha");
                XmlNodeList xmlDownloadUrl = doc.DocumentElement.SelectNodes("/root/item/download_url");

                // If the tag does not contain any information, the API did not retrieve properly.
                // Throw an API Parsing Exception if it's empty, this is a critical variable.
                if (xmlName.Count == 0) throw new ApiParsingException("The tag xmlNames was not properly retrieved. It may be a change in API, repo structure (update would be required), or a temporary issue.", Url, Xml);

                if (xmlName.Count != xmlSha.Count) throw new ApiParsingException("The tags xmlName and xmlSha do not match in count. This is a problem, if you can't tell.", Url, Xml);
                if (xmlName.Count != xmlDownloadUrl.Count) throw new ApiParsingException("The tags xmlName and xmlDownloadUrl do not match in count. This is a problem, if you can't tell.", Url, Xml);


                List<GitLanguageFile> EnumeratedLangs = new();
                for (int i = 0; i < xmlName.Count; i++) {
                    EnumeratedLangs.Add(new() {
                        Name = xmlName[i].InnerText,
                        Sha = xmlSha[i].InnerText,
                        DownloadUrl = xmlDownloadUrl[i].InnerText
                    }) ;
                }

                return EnumeratedLangs;
            }
        }
    }

    public class GitLanguageFile {
        public string Name;
        public string Sha;
        public string DownloadUrl;
    }

}
