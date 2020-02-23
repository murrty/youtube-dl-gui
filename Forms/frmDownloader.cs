using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmDownloader : Form {
        Language lang = Language.GetInstance();

        public string DownloadUrl = null;       // The URL of the download
        public string DownloadPath = null;      // The path of the destination directory
        public string DownloadArguments = null; // The arguments passed for youtube-dl
        public int DownloadType = -1;           // The type of download
        public int DownloadQuality = 0;        // The quality of download
        public bool BatchDownload = false;

        public bool Debugging = false;

        private Process DownloadProcess = null; // The process of youtube-dl which we'll redirect
        private Thread DownloadThread = null;   // The thread of the process for youtube-dl
        private bool DownloadFinished = false;  // Determines if the download finished successfully
        private bool DownloadAborted = false;   // Determines if the download was aborted
        private bool DownloadErrored = false;   // Determines if the thread resulted in an error

        public frmDownloader() {
            InitializeComponent();
            this.Text = lang.frmDownloader + " ";
            chkDownloaderCloseAfterDownloader.Text = lang.chkDownloaderCloseAfterDownload;
            btnDownloaderCancelExit.Text = lang.btnDownloaderCancel;
            chkDownloaderCloseAfterDownloader.Checked = Downloads.Default.CloseDownloaderAfterFinish;
        }
        private void frmDownloader_Load(object sender, EventArgs e) { if (BatchDownload) { this.WindowState = FormWindowState.Minimized; } }
        private void frmDownloader_Shown(object sender, EventArgs e) { BeginDownload(); }
        private void frmDownloader_FormClosing(object sender, FormClosingEventArgs e) {
            CloseForm();
        }
        private void btnDownloaderCancelExit_Click(object sender, EventArgs e) {
            CloseForm();
        }

        private void BeginDownload() {
            if (string.IsNullOrEmpty(DownloadUrl) || string.IsNullOrEmpty(DownloadPath)) {
                MessageBox.Show("The URL or Destination is null or empty. Please enter a URL or Download path.");
                return;
            }

            if (DownloadUrl.StartsWith("http://")) { DownloadUrl = "https" + DownloadUrl.Substring(4); }

            string YoutubeDlFileName = null;
            string ArgumentsBuffer = string.Empty;
            string hlsFF = string.Empty;
            string webFolder = string.Empty;
            bool usehlsFF = Downloads.Default.fixReddit;

            #region youtube-dl path
            if (General.Default.useStaticYtdl && File.Exists(General.Default.ytdlPath)) {
                YoutubeDlFileName = General.Default.ytdlPath;
            }
            else {
                switch (Verification.ytdlFullCheck()) {
                    case 1:
                        YoutubeDlFileName = Environment.CurrentDirectory + "\\youtube-dl.exe";
                        break;
                    case 2:
                        YoutubeDlFileName = Verification.ytdlPathLocation() + "\\youtube-dl.exe";
                        break;
                    case 3:
                        YoutubeDlFileName = "youtube-dl.exe";
                        break;
                    case 0:
                        YoutubeDlFileName = General.Default.ytdlPath;
                        break;
                    default:
                        MessageBox.Show("Youtube-dl.exe is not present. Please download it from the Settings.");
                        return;
                }
            }
            if (YoutubeDlFileName == null) { return; }
            #endregion

            #region v.redd.it fix
            if (DownloadUrl.StartsWith("https://v.redd.it") || DownloadUrl.StartsWith("https://reddit.com/") || DownloadUrl.StartsWith("https://www.reddit.com/") && DownloadType != 2 && usehlsFF) {
                switch (Verification.ffmpegFullCheck()) {
                    case 0: {
                            hlsFF = " --ffmpeg-location \"" + General.Default.ffmpegPath + "\\ffmpeg.exe\" --hls-prefer-ffmpeg ";
                            break;
                        }
                    case 1: {
                            hlsFF = " --ffmpeg-location \"" + Environment.CurrentDirectory + "\\ffmpeg.exe\" --hls-prefer-ffmpeg ";
                            break;
                        }
                    case 2: {
                            hlsFF = " --ffmpeg-location \"" + Verification.ffmpegPathLocation() + "\\ffmpeg.exe\"  --hls-prefer-ffmpeg ";
                            break;
                        }
                    default: {
                            hlsFF = string.Empty;
                            break;
                        }
                }
            }
            #endregion

            #region Arguments + Output
            ArgumentsBuffer = DownloadUrl;
            if (Downloads.Default.separateIntoWebsiteURL) { webFolder = Download.getUrlBase(DownloadUrl) + "\\"; }

            switch (DownloadType) {
                case 0: // video
                    if (Downloads.Default.separateDownloads) { DownloadPath = "-o \"" + Downloads.Default.downloadPath + "\\" + webFolder + "Video\\" + Downloads.Default.fileNameSchema + "\""; }
                    else { DownloadPath = "-o \"" + Downloads.Default.downloadPath + "\\" + webFolder + "" + Downloads.Default.fileNameSchema + "\""; }

                    if (!string.IsNullOrEmpty(DownloadArguments)) {
                        string[] arguments = DownloadArguments.Split(';');
                        for (int i = 0; i < arguments.Length; i++) {
                            if (arguments[i] == "-nosound" || arguments[i] == "-ns") {
                                ArgumentsBuffer = ArgumentsBuffer.Replace("+bestaudio[ext=m4a]", "");
                            }
                        }
                    }

                    if (Download.isReddit(DownloadUrl) && usehlsFF) { ArgumentsBuffer += hlsFF; }
                    else { ArgumentsBuffer += Download.videoQualities[DownloadQuality]; }
                    break;
                case 1: // audio
                    if (Downloads.Default.separateDownloads) { DownloadPath = " -o \"" + Downloads.Default.downloadPath + "\\" + webFolder + "Audio\\" + Downloads.Default.fileNameSchema + "\""; }
                    else { DownloadPath = "-o \"" + Downloads.Default.downloadPath + "\\" + webFolder + Downloads.Default.fileNameSchema + "\""; }

                    if (usehlsFF && Download.isReddit(DownloadUrl)) { ArgumentsBuffer = hlsFF; }
                    else { ArgumentsBuffer = Download.audioQualities[DownloadQuality] + hlsFF; }

                    break;
                case 2: // custom
                    if (Downloads.Default.separateDownloads) { DownloadPath = "-o \"" + Downloads.Default.downloadPath + "\\" + webFolder + "Custom\\" + Downloads.Default.fileNameSchema + "\""; }
                    else { DownloadPath = "-o \"" + Downloads.Default.downloadPath + "\\" + webFolder + "\""; }

                    ArgumentsBuffer = DownloadArguments;
                    break;
                default:
                    rtbConsoleOutput.Text = "The download has been classified as \"default\", and cannot proceed.";
                    return;
            }

            if (Downloads.Default.SaveSubtitles) {
                ArgumentsBuffer += "--all-subs ";
                if (!string.IsNullOrEmpty(Downloads.Default.SubtitleFormat)) {
                    ArgumentsBuffer += "--sub-format " + Downloads.Default.SubtitleFormat + " ";
                }
            }
            if (Downloads.Default.SaveVideoInfo) {
                ArgumentsBuffer += "--write-info-json ";
            }
            if (Downloads.Default.SaveDescription) {
                ArgumentsBuffer += "--write-description ";
            }
            if (Downloads.Default.SaveAnnotations) {
                ArgumentsBuffer += "--write-annotations ";
            }
            if (Downloads.Default.SaveThumbnail) {
                ArgumentsBuffer += "--write-thumbnail ";
                // ArgumentsBuffer += "--write-all-thumbnails "; // Maybe?
            }

            if (Downloads.Default.LimitDownloads && Downloads.Default.DownloadLimit > 0) {
                ArgumentsBuffer += "--limit-rate " + Downloads.Default.DownloadLimit;
                switch (Downloads.Default.DownloadLimitType) {
                    case 0: { // b
                            ArgumentsBuffer += "B ";
                            break;
                        }
                    case 1: { // kb
                            ArgumentsBuffer += "KB ";
                            break;
                        }
                    case 2: { // mb
                            ArgumentsBuffer += "MB ";
                            break;
                        }
                    case 3: { // gb
                            ArgumentsBuffer += "GB ";
                            break;
                        }
                    default: { // kb default
                            ArgumentsBuffer += "KB ";
                            break;
                        }
                }
            }

            if (Downloads.Default.RetryAttempts != 10 && Downloads.Default.RetryAttempts > 0) {
                ArgumentsBuffer += "--retries " + Downloads.Default.RetryAttempts + " ";
            }

            if (Downloads.Default.ForceIPv4) {
                ArgumentsBuffer += "--force-ipv4 ";
            }
            else if (Downloads.Default.ForceIPv6) {
                ArgumentsBuffer += "--force-ipv6 ";
            }

            if (Downloads.Default.UseProxy && Downloads.Default.ProxyType > -1 && !string.IsNullOrEmpty(Downloads.Default.ProxyIP) && !string.IsNullOrEmpty(Downloads.Default.ProxyPort)) {
                ArgumentsBuffer += "--proxy " + Download.ProxyProtocols[Downloads.Default.ProxyType] + Downloads.Default.ProxyIP + ":" + Downloads.Default.ProxyPort + "/ ";
            }
            ArgumentsBuffer += DownloadPath;
            #endregion

            #region Download thread
            if (Program.IsDebug && Debugging) {
                rtbConsoleOutput.Text = ArgumentsBuffer.Replace(' ', '\n');
                return;
            }
            DownloadThread = new Thread(() => {
                try {
                    DownloadProcess = new System.Diagnostics.Process() {
                        StartInfo = new System.Diagnostics.ProcessStartInfo(YoutubeDlFileName) {
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            CreateNoWindow = true,
                            Arguments = ArgumentsBuffer
                        }
                    };

                    DownloadProcess.OutputDataReceived += (s, e) => {
                        this.BeginInvoke(new MethodInvoker(() => {
                            if (e.Data != null)
                                rtbConsoleOutput.AppendText(e.Data + "\n");
                        }));
                    };
                    DownloadProcess.ErrorDataReceived += (s, e) => {
                        this.BeginInvoke(new MethodInvoker(() => {
                            if (e.Data != null) {
                                rtbConsoleOutput.AppendText("Error:\n");
                                rtbConsoleOutput.AppendText(e.Data + "\n");
                            }
                        }));
                    };

                    DownloadProcess.Start();
                    DownloadProcess.BeginOutputReadLine();
                    DownloadProcess.BeginErrorReadLine();
                    DownloadProcess.WaitForExit();

                    DownloadFinished = true;
                }
                catch (ThreadAbortException) {
                    // Thread was aborted
                    DownloadAborted = true;
                    return;
                }
                catch (Exception ex) {
                    ErrorLog.ReportException(ex);
                    DownloadErrored = true;
                }
                finally {
                    DownloadFinishedMethod();
                }
            });
            DownloadThread.Start();
            #endregion
        }
        private void DownloadFinishedMethod() {
            this.BeginInvoke(new MethodInvoker(() => {
                if (BatchDownload) {
                    if (DownloadErrored) {
                        this.DialogResult = System.Windows.Forms.DialogResult.No;
                    }
                    else if (DownloadAborted) {
                        this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                    }
                    else if (DownloadFinished) {
                        this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                    }
                    else {
                        this.DialogResult = System.Windows.Forms.DialogResult.No;
                    }
                }
                else {
                    if (DownloadErrored) {
                        tmrTitleActivity.Stop();
                        btnDownloaderCancelExit.Text = lang.btnDownloaderExit;
                        rtbConsoleOutput.AppendText("\nAn error occured");
                    }

                    else if (chkDownloaderCloseAfterDownloader.Checked || DownloadAborted) { this.Dispose(); }

                    else if (DownloadFinished) {
                        tmrTitleActivity.Stop();
                        btnDownloaderCancelExit.Text = lang.btnDownloaderExit;
                        this.Text = lang.frmDownloaderComplete;
                        rtbConsoleOutput.AppendText("Download has finished.");
                    }
                }
            }));
        }
        private void CloseForm() {
            if (!DownloadFinished && !DownloadAborted && !DownloadErrored) {
                try {
                    DownloadProcess.Kill();
                    DownloadThread.Abort();
                }
                catch (Exception ex) {
                    ErrorLog.ReportException(ex);
                }
            }
            else {
                if (Downloads.Default.CloseDownloaderAfterFinish != chkDownloaderCloseAfterDownloader.Checked) {
                    Downloads.Default.CloseDownloaderAfterFinish = chkDownloaderCloseAfterDownloader.Checked;
                    Downloads.Default.Save();
                }
            }
            this.Dispose();
        }
        private void AbortDownload() {
            if (!DownloadFinished && !DownloadAborted && !DownloadErrored) {
                try {
                    DownloadProcess.Kill();
                    DownloadThread.Abort();
                }
                catch (Exception ex) {
                    ErrorLog.ReportException(ex);
                }
            }
            this.DialogResult = DialogResult.Abort;
        }

        private void tmrTitleActivity_Tick(object sender, EventArgs e) {
            if (this.Text.EndsWith("...."))
                this.Text = this.Text.TrimEnd('.');
            else
                this.Text += ".";
        }
    }
}