using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace youtube_dl_gui {
    class Download {
        // Download types:
        // 0 = Video
        // 1 = Audio
        // 2 = Custom // Unsortable

        #region constants
        /// <summary>
        /// Built-in video qualities
        /// </summary>
        public static string[] videoQualities = {
                                                    " -f \"bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",                // 0  best
                                                    " -f \"bestvideo[height<=4320][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 1  4320p60
                                                    " -f \"bestvideo[height<=4320][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 2  4320p30
                                                    " -f \"bestvideo[height<=2160][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 3  2160p60
                                                    " -f \"bestvideo[height<=2160][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 4  2160p30
                                                    " -f \"bestvideo[height<=1440][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 5  1440p60
                                                    " -f \"bestvideo[height<=1440][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 6  1440p30
                                                    " -f \"bestvideo[height<=1080][fps<=60]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 7  1080p60
                                                    " -f \"bestvideo[height<=1080][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 8  1080p30
                                                    " -f \"bestvideo[height<=720][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",   // 9  720p60
                                                    " -f \"bestvideo[height<=720][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",   // 10 720p30
                                                    " -f \"bestvideo[height<=480]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",            // 11 480p
                                                    " -f \"bestvideo[height<=360]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",            // 12 360p
                                                    " -f \"bestvideo[height<=240]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",            // 13 240p
                                                    " -f \"bestvideo[height<=144]+bestaudio[ext=m4a]/best[ext=mp4]/best\""             // 14 144p
                                                };
        /// <summary>
        /// Built-in audio qualities
        /// </summary>
        public static string[] audioQualities = { 
                                                    " -f bestaudio --extract-audio --audio-format best --audio-quality 0", // 0
                                                    " -x --audio-format mp3 --audio-quality 320K", // 1
                                                    " -x --audio-format mp3 --audio-quality 256K", // 2
                                                    " -x --audio-format mp3 --audio-quality 224K", // 3
                                                    " -x --audio-format mp3 --audio-quality 192K", // 4
                                                    " -x --audio-format mp3 --audio-quality 160K", // 5
                                                    " -x --audio-format mp3 --audio-quality 128K", // 6
                                                    " -x --audio-format mp3 --audio-quality 96K",  // 7
                                                    " -x --audio-format mp3 --audio-quality 64K"   // 8
                                                };
        /// <summary>
        /// The default file-name schema used
        /// </summary>
        public static string defaultSchema = "%(title)s-%(id)s.%(ext)s";
        #endregion

        /// <summary>
        /// Begins the download sequence
        /// </summary>
        /// <param name="URL">The URL of the video/audio/whatever to download</param>
        /// <param name="downloadType">Int for the type, 0 = video, 1 = audio, 2 = custom</param>
        /// <param name="downloadQuality">Int for the quality</param>
        /// <param name="args">Arugments for custom downloads</param>
        /// 
        /// Custom arguments are available for downloads:
        ///     -nosound, -ns = Downloads videos without sound
        /// 
        /// <returns>A boolean based on the success of the download</returns>
        public static bool startDownload(string URL, int downloadType, int downloadQuality, string args, bool WaitForExit = false) {
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

                string outputFolder = string.Empty;             // The folder where it will be downloaded
                string setArgs = string.Empty;                  // Arguments to pass.
                string hlsFF = string.Empty;                    // an empty string, will fill up with hls on ffmpeg.
                string webFolder = string.Empty;                // The string of the website address to use as the folder
                bool usehlsFF = Downloads.Default.fixReddit;    // a boolean to set the arg to hlsFF only if it's enabled

                if (Downloads.Default.separateIntoWebsiteURL) {
                    webFolder = getUrlBase(URL) + "\\";
                }

                if (URL.StartsWith("https://v.redd.it") || URL.StartsWith("https://reddit.com/") || URL.StartsWith("https://www.reddit.com/") && downloadType != 2 && usehlsFF) {
                    switch (Verification.ffmpegFullCheck()) {
                        case 0:
                            hlsFF = " --ffmpeg-location \"" + General.Default.ffmpegPath + "\\ffmpeg.exe\" --hls-prefer-ffmpeg ";
                            break;
                        case 1:
                            hlsFF = " --ffmpeg-location \"" + Environment.CurrentDirectory + "\\ffmpeg.exe\" --hls-prefer-ffmpeg ";
                            break;
                        case 2:
                            hlsFF = " --ffmpeg-location \"" + Verification.ffmpegPathLocation() + "\\ffmpeg.exe\"  --hls-prefer-ffmpeg ";
                            break;
                    }
                }

                switch (downloadType) {
                    case 0: // video
                        if (Downloads.Default.separateDownloads)
                            outputFolder = " -o \"" + Downloads.Default.downloadPath + "\\" + webFolder + "Video\\" + Downloads.Default.fileNameSchema + "\"";
                        else
                            outputFolder = " -o \"" + Downloads.Default.downloadPath + "\\" + webFolder + Downloads.Default.fileNameSchema + "\"";

                        if (usehlsFF && isReddit(URL))
                            setArgs = URL + hlsFF + outputFolder;
                        else
                            setArgs = URL + videoQualities[downloadQuality] + hlsFF + outputFolder;

                        if (!string.IsNullOrEmpty(args)) {
                            string[] arguments = args.Split(';');
                            for (int i = 0; i < arguments.Length; i++) {
                                if (arguments[i] == "-nosound" || arguments[i] == "-ns") {
                                    setArgs = setArgs.Replace("+bestaudio[ext=m4a]", "");
                                }
                            }
                        }

                        break;
                    case 1: // audio
                        if (Downloads.Default.separateDownloads)
                            outputFolder = " -o \"" + Downloads.Default.downloadPath + "\\" + webFolder + "Audio\\" + Downloads.Default.fileNameSchema + "\"";
                        else
                            outputFolder = " -o \"" + Downloads.Default.downloadPath + "\\" + webFolder + Downloads.Default.fileNameSchema + "\"";

                        if (usehlsFF && isReddit(URL))
                            setArgs = URL + hlsFF + outputFolder;
                        else
                            setArgs = URL + audioQualities[downloadQuality] + hlsFF + outputFolder;
                        break;
                    case 2: // custom
                        if (Downloads.Default.separateDownloads)
                            outputFolder = " -o \"" + Downloads.Default.downloadPath + "\\" + webFolder + "Custom\\" + Downloads.Default.fileNameSchema + "\"";
                        else
                            outputFolder = " -o \"" + Downloads.Default.downloadPath + "\\" + webFolder + "\"";

                        setArgs = URL + args + outputFolder;
                        break;
                    default:
                        MessageBox.Show("Wow, this is weird. Your download was classified as 'default'. Let me know how this happened, please");
                        return false;
                }

                Downloader.StartInfo.Arguments = setArgs;
                Downloader.Start();
                if (WaitForExit) { Downloader.WaitForExit(); }

                GC.Collect();
                return true;
            }
            catch (Exception ex) {
                ErrorLog.ReportException(ex);
                GC.Collect();
                return false;
            }
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
                string xml = UpdateChecker.GetJSON("https://api.github.com/repos/rg3/youtube-dl/releases/latest");
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
                ErrorLog.ReportWebException(WebE, YtDl);
                return false;
            }
            catch (Exception ex) {
                ErrorLog.ReportException(ex);
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

        public static bool isReddit(string url) {
            if (url.StartsWith("http://"))
                url = url.Replace("http://", "https://");
            if (url.StartsWith("https://www."))
                url = url.Replace("https://www.", "https://");

            if (url.StartsWith("https://redd.it") || url.StartsWith("https://www.reddit.com")) {
                return true;
            }
            else {
                return false;
            }
        }

        public static string getUrlBase(string url) {
            if (url.StartsWith("https://")) {
                if (url.StartsWith("https://www.")) url = url.Substring(12);
                else url = url.Substring(8);
            }
            else if (url.StartsWith("http://")){
                if (url.StartsWith("http://www.")) url = url.Substring(11);
                else url = url.Substring(7);
            }
            else {
                if (url.StartsWith("www.")) url = url.Substring(4);
            }

            return url.Split('/')[0];
        }
    }
}
