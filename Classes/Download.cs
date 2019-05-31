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
        /// Built-in best quality for video downloads
        /// </summary>
        public static string bestVideo = " -f \"bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
        /// <summary>
        /// Built-in best quality for audio downloads
        /// </summary>
        public static string bestAudio = " -f bestaudio --extract-audio --audio-format best --audio-quality 0";
        public static string goodAudio = " -x --audio-format mp3 --audio-quality 256K";
        /// <summary>
        /// The default file-name schema used
        /// </summary>
        public static string defaultSchema = "%(title)s-%(id)s.%(ext)s";

        /// <summary>
        /// Downloads files using the best preset available.
        /// </summary>
        /// <param name="URL">URL of the file</param>
        /// <param name="downloadType">Download type; (0) Video, (1) Audio, (2) Custom</param>
        /// <param name="args">Custom arguments passed to the application</param>
        /// <returns>A boolean based on the success of the download</returns>
        public static bool downloadBest(string URL, int downloadType, string args = "") {
            if (string.IsNullOrWhiteSpace(URL)) {
                MessageBox.Show("Please enter a URL before trying to download.");
                return false;
            }

            if (URL.StartsWith("http://"))
                URL = "https" + URL.Substring(4);

            try {
                Process Downloader = new Process();
                if (General.Default.useStaticYtdl && File.Exists(General.Default.ytdlPath)) {
                    Downloader.StartInfo.FileName = General.Default.ytdlPath;
                }
                else {
                    switch (Verification.ytdlFullCheck()) {
                        case 1:
                            Downloader.StartInfo.FileName = Environment.CurrentDirectory + "\\youtube-dl.exe";
                            break;
                        case 2:
                            Downloader.StartInfo.FileName = Verification.ytdlPathLocation() + "\\youtube-dl.exe";
                            break;
                        case 3:
                            Downloader.StartInfo.FileName = "youtube-dl.exe";
                            break;
                        case 0:
                            Downloader.StartInfo.FileName = General.Default.ytdlPath + "\\youtube-dl.exe";
                            break;
                        default:
                            if (MessageBox.Show("youtube-dl.exe is not present. Would you like to download it?", "youtube-dl-gui", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                                if (!downloadYoutubeDL(Environment.CurrentDirectory + "\\youtube-dl.exe"))
                                    return false;
                                else
                                    Downloader.StartInfo.FileName = Environment.CurrentDirectory + "\\youtube-dl.exe";
                            }
                            else {
                                return false;
                            }
                            break;
                    }
                }

                //Downloader.StartInfo.UseShellExecute = false;
                //Downloader.StartInfo.RedirectStandardOutput = true;
                //Downloader.StartInfo.CreateNoWindow = true;

                string outputFolder = " -o \"" + Downloads.Default.downloadPath;  // The folder where it will be downloaded
                string setArgs = string.Empty;                                    // Arguments to pass.
                string hlsFF = string.Empty;


                if (URL.StartsWith("https://v.redd.it") || URL.StartsWith("https://reddit.com/") || URL.StartsWith("https://www.reddit.com/") && downloadType != 2 && Downloads.Default.fixReddit) {
                    switch (Verification.ffmpegFullCheck()) {
                        case 0:
                            hlsFF += " --ffmpeg-location \"" + General.Default.ffmpegPath + "\\ffmpeg.exe\" --hls-prefer-ffmpeg ";
                            break;
                        case 1:
                            hlsFF += " --ffmpeg-location \"" + Environment.CurrentDirectory + "\\ffmpeg.exe\" --hls-prefer-ffmpeg ";
                            break;
                        case 2:
                            hlsFF += " --ffmpeg-location \"" + Verification.ffmpegPathLocation() + "\\ffmpeg.exe\"  --hls-prefer-ffmpeg ";
                            break;
                    }
                }

                switch (downloadType) {
                    case 0: // video
                        if (Downloads.Default.separateDownloads)
                            outputFolder += "\\Video\\" + Downloads.Default.fileNameSchema + "\"";
                        else
                            outputFolder += "\\" + Downloads.Default.fileNameSchema + "\"";

                        setArgs += URL + bestVideo + hlsFF + outputFolder;
                        break;
                    case 1: // audio
                        if (Downloads.Default.separateDownloads)
                            outputFolder += "\\Audio\\" + Downloads.Default.fileNameSchema + "\"";
                        else
                            outputFolder += "\\" + Downloads.Default.fileNameSchema + "\"";

                        setArgs = URL + bestAudio + hlsFF + outputFolder;
                        break;
                    case 2: // custom
                        if (Downloads.Default.separateDownloads)
                            outputFolder += "\\Custom\\" + Downloads.Default.fileNameSchema + "\"";
                        else
                            outputFolder += "\\\"";

                        setArgs = URL + args + outputFolder;
                        break;
                }

                Downloader.StartInfo.Arguments = setArgs;
                Downloader.Start();
                //Downloader.WaitForExit();
                //MessageBox.Show(URL + " has finished downloading.");

                GC.Collect();
                return true;
            }
            catch (Exception ex) {
                ErrorLog.reportError(ex);
                GC.Collect();
                return false;
            }
        }

        public static bool downloadCustom() {
            MessageBox.Show("wip");
            return false;
        }

        /// <summary>
        /// Downloads the latest version of youtube-dl
        /// </summary>
        /// <param name="downloadDir">The directory\File to save youtube-dl to</param>
        /// <returns>A boolean based on the success of the download</returns>
        public static bool downloadYoutubeDL(string downloadDir) {
            string YtDl = string.Empty;
            string ytSig = string.Empty;
            try {
                string xml = Updater.getJSON("https://api.github.com/repos/rg3/youtube-dl/releases/latest");
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlNodeList xmlTag = doc.DocumentElement.SelectNodes("/root/tag_name");

                if (!downloadDir.EndsWith(@"\youtube-dl.exe"))
                    downloadDir += @"\youtube-dl.exe";

                YtDl = "https://github.com/rg3/youtube-dl/releases/download/" + xmlTag[0].InnerText + "/youtube-dl.exe";
                ytSig = "https://github.com/rg3/youtube-dl/releases/download/" + xmlTag[0].InnerText + "/youtube-dl.exe.sig";

                if (File.Exists(downloadDir))
                    File.Delete(downloadDir);

                using (WebClient wc = new WebClient()) {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    wc.Headers.Add("User-Agent: " + Program.UserAgent);
                    wc.DownloadFile(YtDl, downloadDir);
                }

                MessageBox.Show("youtube-dl has been downloaded");
                return true;

            }
            catch (WebException WebE) {
                ErrorLog.reportWebError(WebE, YtDl);
                return false;
            }
            catch (Exception ex) {
                ErrorLog.reportError(ex);
                return false;
            }
        }

        /// <summary>
        /// Updates youtube-dl
        /// </summary>
        /// <returns>A boolean based on the success of the update...?</returns>
        public static bool updateYoutubeDL() {
            try {
                if (Downloads.Default.useYtdlUpdater) {
                    Process Downloader = new Process();
                    Downloader.StartInfo.Arguments = "-U";

                    if (General.Default.useStaticYtdl && !string.IsNullOrEmpty(General.Default.ytdlPath)) {
                        if (General.Default.useStaticYtdl && File.Exists(General.Default.ytdlPath)) {
                            Downloader.StartInfo.FileName = General.Default.ytdlPath;
                        }
                        else if (File.Exists(Environment.CurrentDirectory + "\\youtube-dl.exe")) {
                            Downloader.StartInfo.FileName = Environment.CurrentDirectory + "\\youtube-dl.exe";
                        }
                        else if (File.Exists(Verification.ytdlPathLocation() + "\\youtube-dl.exe")) {
                            Downloader.StartInfo.FileName = Verification.ytdlPathLocation() + "\\youtube-dl.exe";
                        }
                        else {
                            MessageBox.Show("Could not find youtube-dl.exe, manually downloading");
                            return downloadYoutubeDL(General.Default.ytdlPath);
                        }
                    }
                    else {
                        if (File.Exists(Environment.CurrentDirectory + "\\youtube-dl.exe")) {
                            Downloader.StartInfo.FileName = Environment.CurrentDirectory + "\\youtube-dl.exe";
                        }
                        else if (File.Exists(Verification.ytdlPathLocation() + "\\youtube-dl.exe")) {
                            Downloader.StartInfo.FileName = Verification.ytdlPathLocation() + "\\youtube-dl.exe";
                        }
                        else {
                            MessageBox.Show("Could not find youtube-dl.exe, manually downloading");
                            return downloadYoutubeDL(Environment.CurrentDirectory + "\\youtube-dl.exe");
                        }
                    }

                    Downloader.Start();
                    Downloader.WaitForExit();
                    return true;
                }
                else {
                    if (General.Default.useStaticYtdl && !string.IsNullOrEmpty(General.Default.ytdlPath)) {
                        if (General.Default.useStaticYtdl) {
                            return downloadYoutubeDL(General.Default.ytdlPath);
                        }
                        else {
                            return downloadYoutubeDL(Environment.CurrentDirectory + "\\youtube-dl.exe");
                        }
                    }
                    else {
                        return downloadYoutubeDL(Environment.CurrentDirectory + "\\youtube-dl.exe");
                    }
                }
            }
            catch {
                return false;
            }
        }
    }
}
