using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmDownloader : Form {
        Language lang = Language.GetInstance();
        Verification verif = Verification.GetInstance();

        public string DownloadUrl = null;       // The URL of the download.
        public string DownloadPath = null;      // The path of the destination directory.
        public string DownloadArguments = null; // The arguments passed for youtube-dl.
        public int DownloadType = -1;           // The type of download.
        public int DownloadQuality = 0;         // The quality of download.
        public int DownloadFormat = 0;          // The format of the download.
        public bool DownloadVideoAudio = true;  // Downloads videos with audio.
        public bool Set60FPS = false;           // The download will download 60fps (if available).
        public bool UseVBR = false;             // Uses variable bitrate for audio.
        public bool BatchDownload = false;      // Is the download in a batch? If so, minimize the form.
        public string BatchTime = string.Empty; // The time for the folder structure.
        public string AuthUsername = null;      // The username for authenticating.
        public string AuthPassword = null;      // The password for authenticating.
        public string Auth2Factor = null;       // The 2-factor code for authenticating.
        public string AuthVideoPassword = null; // The video password for authenticating.
        public bool AuthNetrc = false;          // Determine to use .netrc for authenticating.
        public int SelectionType = -1;          // Used for selecting videos to download
        public string SelectionArg = null;      // Used as the argument for selecting videos with one specific argument
        public int SelectionIndexStart = 0;     // Used as the argument for selecting videos to download in a playlist
        public int SelectionIndexEnd = 0;       // Used as the argument for selecting videos to download in a playlist

        public bool Debugging = false;

        private Process DownloadProcess;        // The process of youtube-dl which we'll redirect.
        private Thread DownloadThread;          // The thread of the process for youtube-dl.
        private bool DownloadFinished = false;  // Determines if the download finished successfully.
        private bool DownloadAborted = false;   // Determines if the download was aborted.
        private bool DownloadErrored = false;   // Determines if the thread resulted in an error.
        private bool CloseFromMethod = false;   // Determines if CloseForm() was called.
        private bool AbortBatch = false;        // Determines if the rest of the batch downloads should be canceled.

        public frmDownloader() {
            InitializeComponent();
            this.Icon = Properties.Resources.youtube_dl_gui;
        }
        private void frmDownloader_Load(object sender, EventArgs e) {
            if (BatchDownload) {
                if (!Program.IsDebug) {
                    this.WindowState = FormWindowState.Minimized;
                }
                btnDownloaderAbortBatchDownload.Enabled = true;
                btnDownloaderAbortBatchDownload.Visible = true;
            }

            this.Text = lang.frmDownloader + " ";
            chkDownloaderCloseAfterDownload.Text = lang.chkDownloaderCloseAfterDownload;
            if (BatchDownload) {
                btnDownloaderAbortBatchDownload.Text = lang.btnDownloaderAbortBatch;
                btnDownloaderCancelExit.Text = lang.GenericSkip;
            }
            else {
                btnDownloaderCancelExit.Text = lang.GenericCancel;
            }
            chkDownloaderCloseAfterDownload.Checked = Downloads.Default.CloseDownloaderAfterFinish;
        }
        private void frmDownloader_Shown(object sender, EventArgs e) {
            BeginDownload();
        }
        private void frmDownloader_FormClosing(object sender, FormClosingEventArgs e) {
            if (!CloseFromMethod) {
                if (!DownloadFinished && !DownloadAborted && !DownloadErrored) {
                    CloseForm();
                }
            }
        }
        private void btnDownloaderAbortBatchDownload_Click(object sender, EventArgs e) {
            if (BatchDownload) {
                btnDownloaderAbortBatchDownload.Enabled = false;
                AbortBatch = true;
                if (!DownloadFinished && !DownloadErrored && !DownloadAborted) {
                    DownloadAborted = true;
                    if (!DownloadProcess.HasExited) {
                        DownloadProcess.Kill();
                    }
                    if (DownloadThread.IsAlive) {
                        DownloadThread.Abort();
                    }
                    System.Media.SystemSounds.Hand.Play();
                    rtbConsoleOutput.AppendText("Downloading was aborted by the user.\n");
                    rtbConsoleOutput.AppendText("Additionally, the batch download has been canceled.");
                }

                this.DialogResult = DialogResult.Abort;
            }
        }
        private void btnDownloaderCancelExit_Click(object sender, EventArgs e) {
            if (!DownloadFinished && !DownloadErrored && !DownloadAborted) {
                DownloadAborted = true;
                if (!DownloadProcess.HasExited) {
                    DownloadProcess.Kill();
                }
                if (DownloadThread.IsAlive) {
                    DownloadThread.Abort();
                }
                System.Media.SystemSounds.Hand.Play();
                rtbConsoleOutput.AppendText("Downloading was aborted by the user.");
            }
            else {
                CloseForm();
            }
        }

        private void BeginDownload() {
            Debug.Print("BeginDownload()");
            if (string.IsNullOrEmpty(DownloadUrl)) {
                MessageBox.Show("The URL is null or empty. Please enter a URL or Download path.");
                return;
            }
            rtbConsoleOutput.AppendText("Beginning download, this box will output progress\n");
            if (BatchDownload) { chkDownloaderCloseAfterDownload.Checked = true; }

            if (DownloadUrl.StartsWith("http://")) { DownloadUrl = "https" + DownloadUrl.Substring(4); }

            string YoutubeDlFileName = null;
            string ArgumentsBuffer = string.Empty;
            string PreviewArguments = string.Empty;
            string QualityFormatBuffer = string.Empty;
            string hlsFF = string.Empty;
            string webFolder = string.Empty;

            #region youtube-dl path
            if (General.Default.UseStaticYtdl && File.Exists(General.Default.ytdlPath)) {
                YoutubeDlFileName = General.Default.ytdlPath;
            }
            else {
                YoutubeDlFileName = verif.YoutubeDlPath;
            }
            if (YoutubeDlFileName == null) {
                rtbConsoleOutput.AppendText("Youtube-DL has not been found\nA rescan for youtube-dl was called");
                verif.RefreshYoutubeDlLocation();
                if (verif.YoutubeDlPath != null) {
                    rtbConsoleOutput.AppendText("try redownloading the video, it seems to be detected now.");
                }
                else {
                    rtbConsoleOutput.AppendText("still couldnt find youtube-dl.");
                }
                return;
            }
            rtbConsoleOutput.AppendText("Youtube-DL has been found and set\n");
            #endregion

            #region Output
            rtbConsoleOutput.AppendText("Generating output directory structure\n");
            if (Downloads.Default.separateIntoWebsiteURL) {
                webFolder = Download.getUrlBase(DownloadUrl) + "\\";
            }
            ArgumentsBuffer = DownloadUrl + " -o \"" + Downloads.Default.downloadPath + BatchTime + "\\" + webFolder + "{0}" + Downloads.Default.fileNameSchema + "\"";

            if (Downloads.Default.separateDownloads) {
                switch (DownloadType) {
                    case 0:
                        ArgumentsBuffer = ArgumentsBuffer.Replace("{0}", "Video\\");
                        break;
                    case 1:
                        ArgumentsBuffer = ArgumentsBuffer.Replace("{0}", "Audio\\");
                        break;
                    case 2:
                        ArgumentsBuffer = ArgumentsBuffer.Replace("{0}", "Custom\\");
                        break;
                    default:
                        rtbConsoleOutput.AppendText("Unable to determine what download type to use (expected 0, 1, or 2)");
                        return;
                }
            }
            else {
                ArgumentsBuffer = ArgumentsBuffer.Replace("{0}", "");
            }
            rtbConsoleOutput.AppendText("The output was generated and will be used\n");
            #endregion

            #region Quality + format
            switch (DownloadType) {
                case 0: {
                        if (DownloadQuality == 0) {
                            if (DownloadVideoAudio) {
                                if (DownloadFormat == 4) {
                                    ArgumentsBuffer += DownloadFormats.VideoFormatArgsArrayOld[0];
                                }
                                else {
                                    ArgumentsBuffer += DownloadFormats.VideoArgs[0];
                                }
                            }
                            else {
                                if (DownloadFormat == 4) {
                                    ArgumentsBuffer += DownloadFormats.VideoFormatArgsArrayNoSoundOld[0];
                                }
                                else {
                                    ArgumentsBuffer += DownloadFormats.VideoArgsNoSound[0];
                                }
                            }
                        }
                        else {
                            if (DownloadVideoAudio) {
                                ArgumentsBuffer += DownloadFormats.GetVideoFormatArgs(DownloadQuality, Set60FPS);
                            }
                            else {
                                ArgumentsBuffer += DownloadFormats.GetVideoFormatArgsNoSound(DownloadQuality, Set60FPS);
                            }
                        }
                        break;
                    }
                case 1: {
                        if (UseVBR) {
                            if (DownloadQuality == 0) {
                                ArgumentsBuffer += " -f bestaudio --extract-audio --audio-quality 0";
                            }
                            else {
                                ArgumentsBuffer += " --extract-audio --audio-quality " + DownloadQuality;
                            }
                        }
                        else {
                            if (DownloadQuality == 0) {
                                ArgumentsBuffer += " -f bestaudio --extract-audio --audio-quality 0";
                            }
                            else {
                                ArgumentsBuffer += " --extract-audio --audio-quality " + DownloadFormats.AudioQualityNamesArray[DownloadQuality];
                            }
                        }
                        break;
                    }
                case 2: {
                        rtbConsoleOutput.AppendText("Custom was requested, skipping quality + format");
                        ArgumentsBuffer += " " + DownloadArguments;
                        break;
                    }
                default: {
                        rtbConsoleOutput.AppendText("Expected a downloadtype (Quality + Format)");
                        return;
                    }
            }

            if (DownloadFormat > 0 && DownloadType == 0 && DownloadFormat != 4) {
                ArgumentsBuffer += DownloadFormats.VideoFormatsArray[DownloadFormat - 1];
            }
            else if (DownloadType == 1) {
                ArgumentsBuffer += " --audio-format " + DownloadFormats.AudioFormatsArray[DownloadFormat];
            }

            rtbConsoleOutput.AppendText("The quality and format has been set\n");
            #endregion

            #region Arguments
            if (DownloadType != 2) {
                switch (SelectionType) {
                    case 0: // playlist-start and playlist-end
                        if (SelectionIndexStart > 0) {
                            ArgumentsBuffer += " --playlist-start " + SelectionIndexStart;
                        }

                        if (SelectionIndexEnd > 0) {
                            ArgumentsBuffer += " --playlist-end " + (SelectionIndexStart + SelectionIndexEnd);
                        }
                        break;
                    case 1: // playlist-items
                        ArgumentsBuffer += " --platlist-items " + SelectionArg;
                        break;
                    case 2: // datebefore
                        ArgumentsBuffer += " --datebefore " + SelectionArg;
                        break;
                    case 3: // date
                        ArgumentsBuffer += " --date " + SelectionArg;
                        break;
                    case 4: // dateafter
                        ArgumentsBuffer += " --dateafter " + SelectionArg;
                        break;
                }

                if (Downloads.Default.PreferFFmpeg || Download.isReddit(DownloadUrl) && Downloads.Default.fixReddit) {
                    rtbConsoleOutput.AppendText("Looking for ffmpeg\n");
                    if (verif.FFmpegPath != null) {
                        if (General.Default.UseStaticFFmpeg) {
                            ArgumentsBuffer += " --ffmpeg-location \"" + General.Default.ffmpegPath + "\\ffmpeg.exe\"";
                        }
                        else {
                            ArgumentsBuffer += " --ffmpeg-location \"" + verif.FFmpegPath + "\\ffmpeg.exe\" --hls-prefer-ffmpeg";
                        }
                        rtbConsoleOutput.AppendText("ffmpeg was found\n");
                    }
                    else {
                        rtbConsoleOutput.AppendText("ffmpeg path is null, downloading may be affected\n");
                    }
                }
                
                if (Downloads.Default.SaveSubtitles) {
                    ArgumentsBuffer += " --all-subs";
                    if (!string.IsNullOrEmpty(Downloads.Default.SubtitleFormat)) {
                        ArgumentsBuffer += " --sub-format " + Downloads.Default.SubtitleFormat + " ";
                    }
                    if (Downloads.Default.EmbedSubtitles && DownloadType == 0 && DownloadFormat == 3 || DownloadFormat == 4 || DownloadFormat == 6) {
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
                    // ArgumentsBuffer += "--write-all-thumbnails "; // Maybe?
                    //ArgumentsBuffer += " --write-thumbnail";
                    if (Downloads.Default.EmbedThumbnails) {
                        switch (DownloadType) {
                            case 0:
                                if (DownloadFormat == 4) {
                                    ArgumentsBuffer += " --embed-thumbnail";
                                }
                                else {
                                    rtbConsoleOutput.AppendText("!!!!!!!! WARNING !!!!!!!!\nCannot embed thumbnail to non-mp4 videos files\n");
                                }
                                break;
                            case 1:
                                if (DownloadFormat == 3 || DownloadFormat == 4) {
                                    ArgumentsBuffer += " --embed-thumbnail";
                                }
                                else {
                                    rtbConsoleOutput.AppendText("!!!!!!!! WARNING !!!!!!!!\nCannot embed thumbnail to non-m4a/mp3 audio files\n");
                                }
                                break;
                        }
                    }
                    //if (Downloads.Default.EmbedThumbnails) {
                    //    switch (DownloadType) {
                    //        case 0:
                    //            if (DownloadFormat != 4) {
                    //                rtbConsoleOutput.AppendText("!!!!!!!! WARNING !!!!!!!!\nCannot embed thumbnail to non-mp4 videos files\nWill try anyway.\n");
                    //            }
                    //            break;
                    //        case 1:
                    //            if (DownloadFormat != 3 && DownloadFormat != 4) {
                    //                rtbConsoleOutput.AppendText("!!!!!!!! WARNING !!!!!!!!\nCannot embed thumbnail to non-m4a/mp3 audio files\nWill try anyway.\n");
                    //            }
                    //            break;
                    //    }
                    //    ArgumentsBuffer += " --embed-thumbnail";
                    //}
                }
                if (Downloads.Default.WriteMetadata) {
                    ArgumentsBuffer += " --add-metadata";
                }

                if (Downloads.Default.KeepOriginalFiles) {
                    ArgumentsBuffer += " -k";
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
            #endregion

            #region Authentication
            // Set the preview arguments to what is present in the arguments buffer.
            // This is so the arguments buffer can have sensitive information and
            // the preview arguments won't include it in case anyone creates an issue.
            PreviewArguments = ArgumentsBuffer;

            if (AuthUsername != null) {
                ArgumentsBuffer += " --username " + AuthUsername;
                PreviewArguments += " --username ***";
                AuthUsername = null;
            }
            if (AuthPassword != null) {
                ArgumentsBuffer += " --password " + AuthPassword;
                PreviewArguments += " --password ***";
                AuthPassword = null;
            }
            if (Auth2Factor != null) {
                ArgumentsBuffer += " --twofactor " + Auth2Factor;
                PreviewArguments += " --twofactor ***";
                Auth2Factor = null;
            }
            if (AuthVideoPassword != null) {
                ArgumentsBuffer += " --video-password " + AuthVideoPassword;
                PreviewArguments += " --video-password ***";
                AuthVideoPassword = null;
            }
            if (AuthNetrc) {
                ArgumentsBuffer += " --netrc";
                PreviewArguments += " --netrc";
                AuthNetrc = false;
            }
            #endregion

            rtbConsoleOutput.AppendText("Arguments have been generated and are readonly in the textbox\n");
            txtArgumentsGenerated.Text = PreviewArguments;

            #region Download thread
            if (Program.IsDebug && !BatchDownload) {
                rtbConsoleOutput.Text = ArgumentsBuffer.Replace(' ', '\n') + "\n\n" + PreviewArguments.Replace(' ', '\n');
                return;
            }
            rtbConsoleOutput.AppendText("Creating download thread\n");
            DownloadThread = new Thread(() => {
                try {
                    DownloadProcess = new Process() {
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

                    ArgumentsBuffer = null;
                    PreviewArguments = null;

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
            DownloadThread.Name = "Downloading video";
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
                    if (AbortBatch) {
                        this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                    }
                    else {
                        this.DialogResult = System.Windows.Forms.DialogResult.Ignore;
                    }
                }
                else if (DownloadErrored) {
                    this.Activate();
                    System.Media.SystemSounds.Hand.Play();
                    rtbConsoleOutput.AppendText("\nAn error occured. Exit the form to resume batch download.");
                    this.Text = lang.frmDownloaderError;
                }
                else if (DownloadFinished) {
                    this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                }
                else {
                    this.DialogResult = System.Windows.Forms.DialogResult.No;
                }
            }
            else {
                if (DownloadAborted) { if (chkDownloaderCloseAfterDownload.Checked) { CloseForm(); } }
                else if (DownloadErrored) {
                    btnDownloaderCancelExit.Text = lang.btnDownloaderExit;
                    rtbConsoleOutput.AppendText("\nAn error occured");
                    this.Text = lang.frmDownloaderError;
                    this.Activate();
                    System.Media.SystemSounds.Hand.Play();
                }
                else if (DownloadFinished) {
                    btnDownloaderCancelExit.Text = lang.btnDownloaderExit;
                    this.Text = lang.frmDownloaderComplete;
                    rtbConsoleOutput.AppendText("Download has finished.");
                    if (chkDownloaderCloseAfterDownload.Checked) { CloseForm(); }
                }
            }
        }
        private void CloseForm() {
            CloseFromMethod = true;

            if (AbortBatch) {
                this.DialogResult = DialogResult.Abort;
            }

            if (Downloads.Default.CloseDownloaderAfterFinish != chkDownloaderCloseAfterDownload.Checked && !BatchDownload) {
                Downloads.Default.CloseDownloaderAfterFinish = chkDownloaderCloseAfterDownload.Checked;
                if (!Program.IsPortable) {
                    Downloads.Default.Save();
                }
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
                if (BatchDownload) { this.DialogResult = System.Windows.Forms.DialogResult.Ignore; }
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

        private void btnClearOutput_Click(object sender, EventArgs e) {
            rtbConsoleOutput.Clear();
        }

    }
}