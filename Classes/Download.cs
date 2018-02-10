using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace youtube_dl_gui {
    class Download {
        // Download types:
        // 0 = Video
        // 1 = Audio
        // 2 = Custom // Unsortable

        /// <summary>
        /// Argument for best Video quality downloads
        /// </summary>
        public static string bestVideo =  " -f \"bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
        /// <summary>
        /// Argument for best Audio quality downloads
        /// </summary>
        public static string bestAudio = " -x --audio-format best  --audio-quality 320K";
        public static string myAudio = " -x --audio-format mp3 --audio-quality 256K";

        /// <summary>
        /// Tooltip
        /// </summary>
        /// <param name="URL">The URL of the video (or otherwise) to download</param>
        /// <param name="downloadDir">The directory where the file will be downloaded to</param>
        /// <param name="downloadType">The type of download (0 = Video, 1 = Audio, 2 = Custom Arguments, any other will attempt a download without any arguments.</param>
        /// <param name="args">(Optional) custom arguments to pass to Youtube-DL</param>
        /// <returns></returns>
        public static bool downloadBest(string URL, string downloadDir, int downloadType, string args = "") {
            if (string.IsNullOrWhiteSpace(URL)) {
                MessageBox.Show("Please enter a URL before trying to download.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(downloadDir)) {
                MessageBox.Show("Please enter a download directory before trying to download.\nThis error is thrown from an unconfigured download directory. Check your settings and try again.");
                return false;
            }

            try {
                Process Downloader = new Process();
                Downloader.StartInfo.FileName = Settings.Default.youtubedlDir;
                //Downloader.StartInfo.UseShellExecute = false;
                //Downloader.StartInfo.RedirectStandardOutput = true;
                //Downloader.StartInfo.CreateNoWindow = true;

                string outputFolder = " -o \"" + Settings.Default.DownloadDir + "/%(title)s-%(id)s.%(ext)s\"";        // The folder where it will be downloaded
                string setArgs;             // Arguments to give.

                if (downloadType == 0 && Settings.Default.sortDownloads) {
                    // Video
                    setArgs =  URL + " -f \"bestvideo[ext=mp4]/best\" " + outputFolder;
                }
                else if (downloadType == 1 && Settings.Default.sortDownloads) {
                    // Audio
                    setArgs = URL + " -x --audio-format mp3  --audio-quality 256K " + outputFolder;
                }
                else if (downloadType == 2 && Settings.Default.sortDownloads) {
                    // Custom
                    setArgs = args;
                }
                else {
                    // Unselected.
                    setArgs = URL + outputFolder;
                }

                Downloader.StartInfo.Arguments = setArgs;
                Downloader.Start();
                Downloader.WaitForExit();
                MessageBox.Show(URL + " has finished downloading.");

                GC.Collect();
                return true;
            }
            catch (Exception ex) {
                ErrorLog.reportError(ex.ToString());
                GC.Collect();
                return false;
            }
        }

        /// <summary>
        /// Downloads with custom formatting & quality options. Must be specified.
        /// </summary>
        /// <param name="URL">The URL of the video to download.</param>
        /// <param name="downloadDir">The directory where it'll be saved to.</param>
        /// <param name="downloadType">The download type (0 = Video, 1 = Audio)</param>
        /// <param name="args">Custom arguments to pass.</param>
        /// <param name="format">The format you want the download to be.</param>
        /// <param name="quality">The quality you want the download to be.</param>
        /// <returns></returns>
        public static bool downloadCustom(string URL, string downloadDir, int downloadType, string args = null, string format = "best", string quality = "best") {
            //if (downloadType != 1) {
            //    MessageBox.Show("Custom downloads are only limited to audio formats for the time being.");
            //    return false;
            //}
            try {
                Process Downloader = new Process();
                Downloader.StartInfo.FileName = Settings.Default.youtubedlDir;
                string dl = Settings.Default.youtubedlDir;

                switch (downloadType) {
                    case 0:
                        if (format != "best") {
                            args = URL + "bestVideo,bestAudio -f " + format + " -o \"" + downloadDir + "/%(title)s-%(id)s.%(ext)s\"";
                        }
                        else {
                            args = URL + bestVideo + " -o \"" + downloadDir + "/%(title)s-%(id)s.%(ext)s\"";
                        }
                        break;
                    case 1:
                        if (quality != "best")
                            quality += "K";
                        else
                            quality = "320K";

                        args = URL + " -x --audio-format " + format + " --audio-quality " + quality + " -o \"" + downloadDir + "/%(title)s-%(id)s.%(ext)s\"";
                        break;
                    case 2:
                        break;
                }

                Downloader.StartInfo.Arguments = args;
                Downloader.Start();

                GC.Collect();
                return true;
            }
            catch (Exception ex) {
                ErrorLog.reportError(ex.ToString());
                GC.Collect();
                return false;
            }
        }

        /// <summary>
        /// Downloads the youtube-dl.exe from Github.
        /// </summary>
        /// <param name="downloadDir"></param>
        public static bool downloadYoutubeDL(string downloadDir) {
            string YtDl = "";
            try {
                string xml = Updater.getJSON("https://api.github.com/repos/rg3/youtube-dl/releases/latest");
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlNodeList xmlTag = doc.DocumentElement.SelectNodes("/root/tag_name");

                if (xmlTag[0].InnerText == Properties.Settings.Default.ytDLVersion) {
                    MessageBox.Show("youtube-dl is already at the latest version.");
                    return false;
                }

                YtDl = "https://github.com/rg3/youtube-dl/releases/download/" + xmlTag[0].InnerText + "/youtube-dl.exe";

                if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\youtube-dl.exe"))
                    File.Delete(System.Windows.Forms.Application.StartupPath + @"\youtube-dl.exe");

                using (WebClient wc = new WebClient()) {
                    wc.Headers.Add("User-Agent: " + Advanced.Default.UserAgent);
                    wc.DownloadFile(YtDl, System.Windows.Forms.Application.StartupPath + @"\youtube-dl.exe");
                }

                Settings.Default.DateLastUpdated = DateTime.Now;

                return true;

            }
            catch (WebException WebE) {
                ErrorLog.reportWebError(WebE, YtDl);
                return false;
            }
            catch (Exception ex) {
                ErrorLog.reportError(ex.ToString());
                return false;
            }
        }
    }
}
