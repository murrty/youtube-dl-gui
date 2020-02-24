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
        public int DownloadQuality = 0;         // The quality of download
        public bool BatchDownload = false;      // Is the download in a batch? If so, minimize the form.
        public string BatchTime = string.Empty; // The time for the folder structure.

        public bool Debugging = false;

        private Process DownloadProcess = new Process(); // The process of youtube-dl which we'll redirect
        private Thread DownloadThread = new Thread(()=>{});   // The thread of the process for youtube-dl
        private bool DownloadFinished = false;  // Determines if the download finished successfully
        private bool DownloadAborted = false;   // Determines if the download was aborted
        private bool DownloadErrored = false;   // Determines if the thread resulted in an error
        private bool CloseFromMethod = false;   // Deterinse if CloseForm() was called

        public frmDownloader() {
            InitializeComponent();
            this.Text = lang.frmDownloader + " ";
            chkDownloaderCloseAfterDownloader.Text = lang.chkDownloaderCloseAfterDownload;
            btnDownloaderCancelExit.Text = lang.btnDownloaderCancel;
            chkDownloaderCloseAfterDownloader.Checked = Downloads.Default.CloseDownloaderAfterFinish;
            this.Icon = Properties.Resources.youtube_dl_gui;
        }
        private void frmDownloader_Load(object sender, EventArgs e) {
            if (BatchDownload) { this.WindowState = FormWindowState.Minimized; }
        }
        private void frmDownloader_Shown(object sender, EventArgs e) {
            BeginDownload();
        }
        private void frmDownloader_FormClosing(object sender, FormClosingEventArgs e) {
            if (!CloseFromMethod) {
                if (!DownloadFinished && !DownloadAborted & !DownloadErrored) {
                    CloseForm();
                }
            }
        }
        private void btnDownloaderCancelExit_Click(object sender, EventArgs e) {
            CloseForm();
        }

        private void BeginDownload() {
            Debug.Print("BeginDownload()");
            if (string.IsNullOrEmpty(DownloadUrl)) {
                MessageBox.Show("The URL is null or empty. Please enter a URL or Download path.");
                return;
            }
            rtbConsoleOutput.AppendText("Beginning download, this box will output progress\n");
            if (BatchDownload) { chkDownloaderCloseAfterDownloader.Checked = true; }

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
                        YoutubeDlFileName = null;
                        return;
                }
            }
            if (YoutubeDlFileName == null) { rtbConsoleOutput.AppendText("Youtube-DL has not been found"); return; }
            rtbConsoleOutput.AppendText("Youtube-DL has been found and set\n");
            #endregion

            #region v.redd.it fix
            if (DownloadUrl.StartsWith("https://v.redd.it") || DownloadUrl.StartsWith("https://reddit.com/") || DownloadUrl.StartsWith("https://www.reddit.com/") && DownloadType != 2 && usehlsFF) {
                rtbConsoleOutput.AppendText("Fix v.redd.it has been set; looking for ffmpeg\n");
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
                if (string.IsNullOrEmpty(hlsFF)) {
                    rtbConsoleOutput.AppendText("Fix v.redd.it was requested, but ffmpeg hasn't been found\n");
                }
                else {
                    rtbConsoleOutput.AppendText("ffmpeg has been found and set");
                }
            }
            #endregion

            #region Output
            ArgumentsBuffer = DownloadUrl;
            if (Downloads.Default.separateIntoWebsiteURL) { webFolder = Download.getUrlBase(DownloadUrl) + "\\"; }
            rtbConsoleOutput.AppendText("Generating output directory structure\n");
            switch (DownloadType) {
                case 0: // video
                    if (Downloads.Default.separateDownloads) { DownloadPath = " -o \"" + Downloads.Default.downloadPath + BatchTime + "\\" + webFolder + "Video\\" + Downloads.Default.fileNameSchema + "\""; }
                    else { DownloadPath = " -o \"" + Downloads.Default.downloadPath + BatchTime + "\\" + webFolder + "" + Downloads.Default.fileNameSchema + "\""; }

                    if (!string.IsNullOrEmpty(DownloadArguments)) {
                        string[] arguments = DownloadArguments.Split(';');
                        for (int i = 0; i < arguments.Length; i++) {
                            if (arguments[i] == "-nosound" || arguments[i] == "-ns") {
                                ArgumentsBuffer += ArgumentsBuffer.Replace("+bestaudio[ext=m4a]", "");
                            }
                        }
                    }

                    if (Download.isReddit(DownloadUrl) && usehlsFF) { ArgumentsBuffer += hlsFF; }
                    else { ArgumentsBuffer += Download.videoQualities[DownloadQuality]; }
                    break;
                case 1: // audio
                    if (Downloads.Default.separateDownloads) { DownloadPath = " -o \"" + Downloads.Default.downloadPath + BatchTime + "\\" + webFolder + "Audio\\" + Downloads.Default.fileNameSchema + "\""; }
                    else { DownloadPath = " -o \"" + Downloads.Default.downloadPath + BatchTime + "\\" + webFolder + Downloads.Default.fileNameSchema + "\""; }

                    if (usehlsFF && Download.isReddit(DownloadUrl)) { ArgumentsBuffer += hlsFF; }
                    else { ArgumentsBuffer += Download.audioQualities[DownloadQuality] + hlsFF; }

                    break;
                case 2: // custom
                    if (Downloads.Default.separateDownloads) { DownloadPath = " -o \"" + Downloads.Default.downloadPath + BatchTime + "\\" + webFolder + "Custom\\" + Downloads.Default.fileNameSchema + "\""; }
                    else { DownloadPath = " -o \"" + Downloads.Default.downloadPath + BatchTime + "\\" + webFolder + "\""; }

                    ArgumentsBuffer += " " + DownloadArguments.Trim(' ') + " ";
                    break;
                default:
                    rtbConsoleOutput.AppendText("The download has been classified as \"default\", and cannot proceed");
                    return;
            }
            rtbConsoleOutput.AppendText("The output was generated and will be used\n");
            #endregion

            #region Arguments
            if (DownloadType != 2) {
                if (Downloads.Default.SaveSubtitles) {
                    ArgumentsBuffer += " --all-subs";
                    if (!string.IsNullOrEmpty(Downloads.Default.SubtitleFormat)) {
                        ArgumentsBuffer += "--sub-format " + Downloads.Default.SubtitleFormat + " ";
                    }
                    if (Downloads.Default.EmbedSubtitles) {
                        ArgumentsBuffer += " --embed-subs";
                    }
                }
                if (Downloads.Default.SaveVideoInfo) {
                    ArgumentsBuffer += " --write-info-json";
                }
                if (Downloads.Default.SaveDescription) {
                    ArgumentsBuffer += " --write-description";
                }
                if (Downloads.Default.SaveAnnotations) {
                    ArgumentsBuffer += " --write-annotations";
                }
                if (Downloads.Default.SaveThumbnail) {
                    ArgumentsBuffer += " --write-thumbnail";
                    if (Downloads.Default.EmbedThumbnails) {
                        ArgumentsBuffer += " --embed-thumbnail";
                    }
                    // ArgumentsBuffer += "--write-all-thumbnails "; // Maybe?
                }

                if (Downloads.Default.LimitDownloads && Downloads.Default.DownloadLimit > 0) {
                    ArgumentsBuffer += " --limit-rate " + Downloads.Default.DownloadLimit;
                    switch (Downloads.Default.DownloadLimitType) {
                        case 0: { // kb
                                ArgumentsBuffer += "K ";
                                break;
                            }
                        case 1: { // mb
                                ArgumentsBuffer += "M ";
                                break;
                            }
                        case 2: { // gb
                                ArgumentsBuffer += "G ";
                                break;
                            }
                        default: { // kb default
                                ArgumentsBuffer += "K ";
                                break;
                            }
                    }
                }

                if (Downloads.Default.RetryAttempts != 10 && Downloads.Default.RetryAttempts > 0) {
                    ArgumentsBuffer += " --retries " + Downloads.Default.RetryAttempts;
                }

                if (Downloads.Default.ForceIPv4) {
                    ArgumentsBuffer += " --force-ipv4";
                }
                else if (Downloads.Default.ForceIPv6) {
                    ArgumentsBuffer += " --force-ipv6";
                }

                if (Downloads.Default.UseProxy && Downloads.Default.ProxyType > -1 && !string.IsNullOrEmpty(Downloads.Default.ProxyIP) && !string.IsNullOrEmpty(Downloads.Default.ProxyPort)) {
                    ArgumentsBuffer += " --proxy " + Download.ProxyProtocols[Downloads.Default.ProxyType] + Downloads.Default.ProxyIP + ":" + Downloads.Default.ProxyPort + "/ ";
                }
            }
            else {

            }
            ArgumentsBuffer += DownloadPath;

            rtbConsoleOutput.AppendText("Arguments have been generated and are readonly in the textbox\n");
            txtArgumentsGenerated.Text = ArgumentsBuffer;
            #endregion

            #region Download thread
            if (Program.IsDebug && Debugging && !BatchDownload) {
                rtbConsoleOutput.Text = ArgumentsBuffer.Replace(' ', '\n');
                return;
            }
            rtbConsoleOutput.AppendText("Creating download thread\n");
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
                            if (e.Data != null && rtbConsoleOutput != null)
                                rtbConsoleOutput.AppendText(e.Data + "\n");
                        }));
                    };
                    DownloadProcess.ErrorDataReceived += (s, e) => {
                        this.BeginInvoke(new MethodInvoker(() => {
                            if (e.Data != null && rtbConsoleOutput != null) {
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

                    if (DownloadProcess.ExitCode == 0) {
                        DownloadFinished = true;
                        DownloadAborted = false;
                        DownloadErrored = false;
                    }
                    else {
                        DownloadErrored = true;
                        DownloadFinished = false;
                    }
                }
                catch (ThreadAbortException) {
                    DownloadAborted = true;
                    DownloadFinished = false;
                    return;
                }
                catch (Exception ex) {
                    ErrorLog.ReportException(ex);
                    DownloadErrored = true;
                }
                finally {
                    ThreadExit();
                }
            });
            rtbConsoleOutput.AppendText("Created, starting download thread\n");
            DownloadThread.Start();
            #endregion
        }
        private void ThreadExit() {
            this.BeginInvoke(new MethodInvoker(() => {
                DownloadFinishedMethod();
            }));
        }
        private void DownloadFinishedMethod() {
            CloseFromMethod = true;
            tmrTitleActivity.Stop();
            this.Text.Trim('.');
            btnDownloaderCancelExit.Text = lang.btnBatchDownloadExit;

            if (BatchDownload) {
                if (DownloadAborted) {
                    this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                }
                else if (DownloadErrored) {
                    this.Activate();
                    System.Media.SystemSounds.Hand.Play();
                    rtbConsoleOutput.AppendText("\nAn error occured. Exit the form to resume batch download.");
                }
                else if (DownloadFinished) {
                    this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                }
                else {
                    this.DialogResult = System.Windows.Forms.DialogResult.No;
                }
            }
            else {
                if (DownloadAborted) { CloseForm(); }
                else if (DownloadErrored) {
                    btnDownloaderCancelExit.Text = lang.btnDownloaderExit;
                    rtbConsoleOutput.AppendText("\nAn error occured");
                    this.Activate();
                    System.Media.SystemSounds.Hand.Play();
                }
                else if (DownloadFinished) {
                    btnDownloaderCancelExit.Text = lang.btnDownloaderExit;
                    this.Text = lang.frmDownloaderComplete;
                    rtbConsoleOutput.AppendText("Download has finished.");
                    if (chkDownloaderCloseAfterDownloader.Checked) { CloseForm(); }
                }
            }
        }
        private void CloseForm() {
            CloseFromMethod = true;

            if (Downloads.Default.CloseDownloaderAfterFinish != chkDownloaderCloseAfterDownloader.Checked && !BatchDownload) {
                Downloads.Default.CloseDownloaderAfterFinish = chkDownloaderCloseAfterDownloader.Checked;
                Downloads.Default.Save();
            }

            if (DownloadErrored) {
                if (BatchDownload) { this.DialogResult = System.Windows.Forms.DialogResult.No; }
                else { this.Dispose(); }
            }
            if (!DownloadFinished) {
                try {
                    if (!DownloadProcess.HasExited) { DownloadProcess.Kill(); }
                    if (DownloadThread.IsAlive) { DownloadThread.Abort(); }
                }
                catch (Exception ex) {
                    ErrorLog.ReportException(ex);
                }
            }

            if (DownloadAborted) {
                if (BatchDownload) { this.DialogResult = System.Windows.Forms.DialogResult.Abort; }
                else { this.Dispose(); }
            }
            else if (DownloadFinished) {
                if (DownloadProcess.ExitCode == 0) {
                    if (BatchDownload) { this.DialogResult = System.Windows.Forms.DialogResult.Yes; }
                    else { this.Dispose(); }
                }
                else {
                    if (BatchDownload) { this.DialogResult = System.Windows.Forms.DialogResult.No; }
                }
            }
            else {
                if (BatchDownload) { this.DialogResult = System.Windows.Forms.DialogResult.No; }
            }
        }

        private void tmrTitleActivity_Tick(object sender, EventArgs e) {
            if (this.Text.EndsWith("...."))
                this.Text = this.Text.TrimEnd('.');
            else
                this.Text += ".";
        }
    }
}