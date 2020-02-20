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
        public static string GithubRawUrl = "https://raw.githubusercontent.com/murrty/{0}";
        public static string GithubRepoUrl = "https://github.com/murrty/{0}";
        public static string GithubLatestJson = "http://api.github.com/repos/murrty/{0}/releases/latest";
        public static string ApplicationDownloadUrl = "https://github.com/murrty/{0}/releases/download/{1}/{0}.exe";
        public static readonly string ApplicationName = "youtube-dl-gui";
        public static CloudData GitData = CloudData.GetInstance();

        public static void CheckForUpdate(bool ForceCheck = false) {
            Thread checkUpdates = new Thread(() => {
                if (GitData.UpdateVersion == "-1" || ForceCheck) {
                    decimal GitVersion = UpdateChecker.GetGitVersion();
                    if (UpdateChecker.IsUpdateAvailable(GitVersion)) {
                        if (GitVersion != Properties.Settings.Default.SkippedVersion || ForceCheck) {
                            frmUpdateAvailable Update = new frmUpdateAvailable();
                            Update.BlockSkip = ForceCheck;
                            switch (Update.ShowDialog()) {
                                case DialogResult.Yes:
                                    try {
                                        CreateUpdateStub();
                                        Process Updater = new Process();
                                        Updater.StartInfo.FileName = Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe";
                                        string ArgumentsBuffer = "";
                                        ArgumentsBuffer += GitData.UpdateVersion + " " + System.AppDomain.CurrentDomain.FriendlyName;
                                        Updater.Start();
                                        Environment.Exit(0);
                                    }
                                    catch (Exception ex) {
                                        ErrorLog.reportError(ex);
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

        public static string GetJSON(string url) {
            if (!Properties.Settings.Default.jsonSupport)
                return null;
            url = "http://localhost/latest.json";
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
                ErrorLog.reportWebError(WebE, url);
                return null;
                throw WebE;
            }
            catch (Exception ex) {
                ErrorLog.reportError(ex);
                return null;
                throw ex;
            }
        }

        public static decimal GetGitVersion() {
            try {
                string xml = GetJSON(string.Format(GithubLatestJson, ApplicationName));
                if (xml == null)
                    return -1;

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlNodeList xmlTag = doc.DocumentElement.SelectNodes("/root/tag_name");
                XmlNodeList xmlName = doc.DocumentElement.SelectNodes("/root/name");
                XmlNodeList xmlBody = doc.DocumentElement.SelectNodes("/root/body");

                GitData.UpdateVersion = xmlTag[0].InnerText;
                GitData.UpdateName = xmlName[0].InnerText;
                GitData.UpdateBody = xmlBody[0].InnerText;

                return decimal.Parse(GitData.UpdateVersion.Replace(".", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator), NumberStyles.Any, CultureInfo.InvariantCulture);
            }
            catch (Exception ex) {
                ErrorLog.reportError(ex);
                return -1;
            }
        }
        public static bool IsUpdateAvailable(decimal cloudVersion) {
            try {
                if (Properties.Settings.Default.appVersion < cloudVersion) { return true; }
                else { return false; }
            }
            catch (Exception ex) {
                ErrorLog.reportError(ex);
                return false;
            }
        }
        public static bool CreateUpdateStub() {
            var UpdaterBytes = Properties.Resources.youtube_dl_gui_updater;
            File.WriteAllBytes(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe", UpdaterBytes);
            return true;
        }
    }

    public class CloudData {
        private static CloudData CloudDataInstance = new CloudData();
        private static volatile string UpdateVersionString = "-1";
        private static volatile string UpdateNameString = "UpdateNameString";
        private static volatile string UpdateBodyString = "UpdateBodyString";

        public static CloudData GetInstance() {
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
    }
}