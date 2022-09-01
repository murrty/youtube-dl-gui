using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmDownloader : Form {
        public bool Debugging = false;
        public volatile DownloadInfo CurrentDownload;

        private Thread DownloadThread;              // The thread of the process for youtube-dl.
        private volatile Process DownloadProcess;   // The process of youtube-dl which we'll redirect.
        private volatile bool AbortBatch = false;   // Determines if the rest of the batch downloads should be cancelled.

        public frmDownloader(DownloadInfo Info) {
            InitializeComponent();
            CurrentDownload = Info;
        }

        private void frmDownloader_Load(object sender, EventArgs e) {
            //CurrentDownload.BatchDownload = true;
            this.Text = Program.lang.frmDownloader + " ";
            if (CurrentDownload.BatchDownload) {
                this.WindowState = FormWindowState.Minimized;
                btnDownloaderAbortBatchDownload.Enabled = true;
                btnDownloaderAbortBatchDownload.Visible = true;
                btnDownloaderAbortBatchDownload.Text = Program.lang.btnDownloaderAbortBatch;
                btnDownloaderCancelExit.Text = Program.lang.GenericSkip;
            }
            else {
                btnDownloaderCancelExit.Text = Program.lang.GenericCancel;
            }
            chkDownloaderCloseAfterDownload.Text = Program.lang.chkDownloaderCloseAfterDownload;
            chkDownloaderCloseAfterDownload.Checked = Config.Settings.Downloads.CloseDownloaderAfterFinish;
        }
        private void frmDownloader_Shown(object sender, EventArgs e) {
            BeginDownload();
        }
        private void frmDownloader_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult Finish = DialogResult.None;
            switch (CurrentDownload.Status) {
                case DownloadStatus.Aborted:
                    if (CurrentDownload.BatchDownload) {
                        if (AbortBatch) {
                            Finish = DialogResult.Abort;
                        }
                        else {
                            Finish = DialogResult.Ignore;
                        }
                    }
                    break;
                case DownloadStatus.Finished:
                    if (DownloadProcess.ExitCode == 0) {
                        if (CurrentDownload.BatchDownload) {
                            this.DialogResult = DialogResult.Yes;
                        }
                    }
                    else {
                        if (CurrentDownload.BatchDownload) {
                            this.DialogResult = DialogResult.No;
                        }
                    }
                    break;
                case DownloadStatus.ProgramError:
                case DownloadStatus.YtdlError:
                    if (CurrentDownload.BatchDownload) {
                        Finish = DialogResult.No;
                    }
                    break;
                default:
                    if (DownloadThread is not null && DownloadThread.IsAlive) {
                        DownloadThread.Abort();
                        e.Cancel = true;
                    }
                    break;
            }
            if (!e.Cancel) {
                if (Config.Settings.Downloads.CloseDownloaderAfterFinish != chkDownloaderCloseAfterDownload.Checked && !CurrentDownload.BatchDownload) {
                    Config.Settings.Downloads.CloseDownloaderAfterFinish = chkDownloaderCloseAfterDownload.Checked;
                }

                this.DialogResult = Finish;
                this.Dispose();
            }
        }
        private void btnDownloaderAbortBatchDownload_Click(object sender, EventArgs e) {
            switch (CurrentDownload.Status) {
                case DownloadStatus.YtdlError: case DownloadStatus.ProgramError: case DownloadStatus.Aborted:
                    btnDownloaderAbortBatchDownload.Visible = false;
                    btnDownloaderAbortBatchDownload.Enabled = false;
                    this.Text = Program.lang.frmDownloader + " ";
                    tmrTitleActivity.Start();
                    BeginDownload();
                    break;
                default:
                    AbortBatch = true;
                    switch (CurrentDownload.Status) {
                        case DownloadStatus.Finished: case DownloadStatus.Aborted:
                        case DownloadStatus.YtdlError: case DownloadStatus.ProgramError:
                            rtbConsoleOutput.AppendText("The user requested to abort subsequent batch downloads");
                            btnDownloaderAbortBatchDownload.Enabled = false;
                            btnDownloaderAbortBatchDownload.Visible = false;
                            break;
                        default:
                            if (DownloadThread is not null && DownloadThread.IsAlive) {
                                DownloadThread.Abort();
                            }
                            rtbConsoleOutput.AppendText("Additionally, the batch download has been cancelled.");
                            this.Close();
                            break;
                    }
                    break;
            }
        }
        private void btnDownloaderCancelExit_Click(object sender, EventArgs e) {
            switch (CurrentDownload.Status) {
                case DownloadStatus.Finished:
                case DownloadStatus.YtdlError:
                case DownloadStatus.Aborted:
                    this.Close();
                    break;
                default:
                    if (DownloadThread is not null && DownloadThread.IsAlive) {
                        DownloadThread.Abort();
                    }
                    break;
            }
        }

        public void Abort() {
            switch (CurrentDownload.Status) {
                case DownloadStatus.YtdlError:
                case DownloadStatus.ProgramError:
                case DownloadStatus.Aborted:
                    btnDownloaderAbortBatchDownload.Visible = false;
                    btnDownloaderAbortBatchDownload.Enabled = false;
                    this.Text = Program.lang.frmDownloader + " ";
                    tmrTitleActivity.Start();
                    BeginDownload();
                    break;
                default:
                    AbortBatch = true;
                    switch (CurrentDownload.Status) {
                        case DownloadStatus.Finished:
                        case DownloadStatus.Aborted:
                        case DownloadStatus.YtdlError:
                        case DownloadStatus.ProgramError:
                            rtbConsoleOutput.AppendText("The user requested to abort subsequent batch downloads");
                            btnDownloaderAbortBatchDownload.Enabled = false;
                            btnDownloaderAbortBatchDownload.Visible = false;
                            break;
                        default:
                            if (DownloadThread is not null && DownloadThread.IsAlive) {
                                DownloadThread.Abort();
                            }
                            rtbConsoleOutput.AppendText("Additionally, the batch download has been cancelled.");
                            CurrentDownload.Status = DownloadStatus.Aborted;
                            this.Close();
                            break;
                    }
                    break;
            }
        }
        private void BeginDownload() {
            Debug.Print("BeginDownload()");
            if (string.IsNullOrEmpty(CurrentDownload.DownloadURL)) {
                rtbConsoleOutput.AppendText("The URL is null or empty. Please enter a URL to download.");
                return;
            }
            CurrentDownload.Status = DownloadStatus.GeneratingArguments;
            rtbConsoleOutput.AppendText("Beginning download, this box will output progress\n");
            if (CurrentDownload.BatchDownload) {
                chkDownloaderCloseAfterDownload.Checked = true;
            }

            #region URL cleaning
            if (!CurrentDownload.DownloadURL.StartsWith("https://")) {
                CurrentDownload.DownloadURL.Trim('\\', '"', '\n', '\r', '\t', '\0', '\b', '\'');

                if (CurrentDownload.DownloadURL.StartsWith("http://")) {
                    CurrentDownload.DownloadURL = "https" + CurrentDownload.DownloadURL[4..];
                }
            }
            #endregion

            StringBuilder ArgumentsBuffer = new(string.Empty);
            StringBuilder PreviewArguments;
            string QualityFormatBuffer = string.Empty;
            string hlsFF = string.Empty;
            string webFolder = string.Empty;

            #region youtube-dl path
            if (Program.verif.YoutubeDlPath.IsNullEmptyWhitespace()) {
                rtbConsoleOutput.AppendText("Youtube-DL has not been found\nA rescan for youtube-dl was called\n");
                Program.verif.RefreshYoutubeDlLocation();
                if (Program.verif.YoutubeDlPath is not null) {
                    rtbConsoleOutput.AppendText("Rescan finished and found, continuing\n");
                }
                else {
                    rtbConsoleOutput.AppendText("still couldnt find youtube-dl.");
                    CurrentDownload.Status = DownloadStatus.ProgramError;
                    return;
                }
            }
            rtbConsoleOutput.AppendText("Youtube-DL has been found and set\n");
            #endregion

            #region Output
            rtbConsoleOutput.AppendText("Generating output directory structure\n");

            if (Config.Settings.Downloads.separateIntoWebsiteURL) {
                webFolder = $"{Download.getUrlBase(CurrentDownload.DownloadURL)}\\";
            }

            StringBuilder OutputDirectory = new($"\"{(
                Config.Settings.Downloads.downloadPath.StartsWith("./") || Config.Settings.Downloads.downloadPath.StartsWith(".\\") ?
                    $"{Program.ProgramPath}\\{Config.Settings.Downloads.downloadPath[2..]}" :
                    Config.Settings.Downloads.downloadPath)}");

            if (CurrentDownload.BatchDownload && Config.Settings.Downloads.SeparateBatchDownloads) {
                OutputDirectory.Append("\\# Batch Downloads #");
                if (Config.Settings.Downloads.AddDateToBatchDownloadFolders) {
                    OutputDirectory.Append($"\\{CurrentDownload.BatchTime}");
                }
            }

            OutputDirectory.Append($"\\{webFolder}");

            if (Config.Settings.Downloads.separateDownloads) {
                switch (CurrentDownload.Type) {
                    case DownloadType.Video:
                        OutputDirectory.Append("\\Video");
                        break;
                    case DownloadType.Audio:
                        OutputDirectory.Append("\\Audio");
                        break;
                    case DownloadType.Custom:
                        OutputDirectory.Append("\\Custom");
                        break;
                    default:
                        rtbConsoleOutput.AppendText("Unable to determine what download type to use (expected 0, 1, or 2)");
                        CurrentDownload.Status = DownloadStatus.ProgramError;
                        return;
                }
            }
            if (string.IsNullOrWhiteSpace(CurrentDownload.FileNameSchema)) {
                rtbConsoleOutput.AppendText("The file name schema is not properly set, falling back to the default one. Consider setting it in the settings, or making sure the schema list has a proper schema format on the main form.");
                OutputDirectory.Append("\\%(title)s-%(id)s.%(ext)s");
            }
            else {
                OutputDirectory.Append($"\\{CurrentDownload.FileNameSchema}\"");
            }

            ArgumentsBuffer.Append($"{CurrentDownload.DownloadURL} -o {OutputDirectory}");
            rtbConsoleOutput.AppendText("The output was generated and will be used\n");
            #endregion

            #region Quality & format
            switch (CurrentDownload.Type) {
                case DownloadType.Video: {
                        if (CurrentDownload.SkipAudioForVideos) {
                            ArgumentsBuffer.Append(Download.Formats.GetVideoQualityArgsNoSound(CurrentDownload.VideoQuality));
                        }
                        else {
                            ArgumentsBuffer.Append(Download.Formats.GetVideoQualityArgs(CurrentDownload.VideoQuality));
                        }

                        ArgumentsBuffer.Append(Download.Formats.GetVideoRecodeInfo(CurrentDownload.VideoFormat));
                        break;
                    }
                case DownloadType.Audio: {
                        if (CurrentDownload.AudioCBRQuality == AudioCBRQualityType.best || CurrentDownload.AudioVBRQuality == AudioVBRQualityType.q0) {
                            ArgumentsBuffer.Append(" --extract-audio --audio-quality 0");
                        }
                        else {
                            if (CurrentDownload.UseVBR) {
                                ArgumentsBuffer.Append($" --extract-audio --audio-quality {CurrentDownload.AudioVBRQuality}");
                            }
                            else {
                                ArgumentsBuffer.Append($" --extract-audio --audio-quality {Download.Formats.GetAudioQuality(CurrentDownload.AudioCBRQuality)}");
                            }
                        }
                        if (CurrentDownload.AudioFormat == AudioFormatType.best) {
                            ArgumentsBuffer.Append(" --audio-format best");
                        }
                        else {
                            ArgumentsBuffer.Append($" --extract-audio --audio-format {Download.Formats.GetAudioFormat(CurrentDownload.AudioFormat)}");
                        }
                        break;
                    }
                case DownloadType.Custom: {
                        rtbConsoleOutput.AppendText("Custom was requested, skipping quality + format");
                        if (!string.IsNullOrWhiteSpace(CurrentDownload.DownloadArguments)) {
                            ArgumentsBuffer.Append($" {CurrentDownload.DownloadArguments}");
                        }
                        break;
                    }
                default: {
                        rtbConsoleOutput.AppendText("Expected a downloadtype (Quality + Format)");
                        CurrentDownload.Status = DownloadStatus.ProgramError;
                        return;
                    }
            }

            rtbConsoleOutput.AppendText("The quality and format has been set\n");
            #endregion

            #region Arguments
            if (CurrentDownload.Type != DownloadType.Custom) {
                switch (CurrentDownload.PlaylistSelection) {
                    case PlaylistSelectionType.PlaylistStartPlaylistEnd: // playlist-start and playlist-end
                        if (CurrentDownload.PlaylistSelectionIndexStart > 0) {
                            ArgumentsBuffer.Append($" --playlist-start {CurrentDownload.PlaylistSelectionIndexStart}");
                        }

                        if (CurrentDownload.PlaylistSelectionIndexEnd > 0) {
                            ArgumentsBuffer.Append($" --playlist-end {(CurrentDownload.PlaylistSelectionIndexStart + CurrentDownload.PlaylistSelectionIndexEnd)}");
                        }
                        break;
                    case PlaylistSelectionType.PlaylistItems: // playlist-items
                        ArgumentsBuffer.Append($" --playlist-items {CurrentDownload.PlaylistSelectionArg}");
                        break;
                    case PlaylistSelectionType.DateBefore: // datebefore
                        ArgumentsBuffer.Append($" --datebefore {CurrentDownload.PlaylistSelectionArg}");
                        break;
                    case PlaylistSelectionType.DateDuring: // date
                        ArgumentsBuffer.Append($" --date {CurrentDownload.PlaylistSelectionArg}");
                        break;
                    case PlaylistSelectionType.DateAfter: // dateafter
                        ArgumentsBuffer.Append($" --dateafter {CurrentDownload.PlaylistSelectionArg}");
                        break;
                }

                if (Config.Settings.Downloads.PreferFFmpeg || Download.isReddit(CurrentDownload.DownloadURL) && Config.Settings.Downloads.fixReddit) {
                    rtbConsoleOutput.AppendText("Looking for ffmpeg\n");
                    if (Program.verif.FFmpegPath is not null) {
                        if (Config.Settings.General.UseStaticFFmpeg) {
                            ArgumentsBuffer.Append($" --ffmpeg-location \"{Config.Settings.General.ffmpegPath}\" --hls-prefer-ffmpeg");
                        }
                        else {
                            ArgumentsBuffer.Append($" --ffmpeg-location \"{Program.verif.FFmpegPath}\" --hls-prefer-ffmpeg");
                        }
                        rtbConsoleOutput.AppendText("ffmpeg was found\n");
                    }
                    else {
                        rtbConsoleOutput.AppendText("ffmpeg path is null, downloading may be affected\n");
                    }
                }

                if (Config.Settings.Downloads.SaveSubtitles) {
                    ArgumentsBuffer.Append(" --all-subs");
                    if (!string.IsNullOrEmpty(Config.Settings.Downloads.SubtitleFormat)) {
                        ArgumentsBuffer.Append($" --sub-format {Config.Settings.Downloads.SubtitleFormat} ");
                    }
                    if (Config.Settings.Downloads.EmbedSubtitles && CurrentDownload.Type == DownloadType.Video) {
                        switch (CurrentDownload.VideoFormat) {
                            case VideoFormatType.flv: case VideoFormatType.mkv:
                                break;
                        }
                        ArgumentsBuffer.Append(" --embed-subs");
                    }
                }
                if (Config.Settings.Downloads.SaveVideoInfo) {
                    ArgumentsBuffer.Append(" --write-info-json");
                }
                if (Config.Settings.Downloads.SaveDescription) {
                    ArgumentsBuffer.Append(" --write-description");
                }
                if (Config.Settings.Downloads.SaveAnnotations) {
                    ArgumentsBuffer.Append(" --write-annotations");
                }
                if (Config.Settings.Downloads.SaveThumbnail) {
                    // ArgumentsBuffer += "--write-all-thumbnails "; // Maybe?
                    ArgumentsBuffer.Append(" --write-thumbnail");
                    if (Config.Settings.Downloads.EmbedThumbnails) {
                        switch (CurrentDownload.Type) {
                            case DownloadType.Video:
                                if (CurrentDownload.VideoFormat == VideoFormatType.mp4) {
                                    ArgumentsBuffer.Append(" --embed-thumbnail");
                                }
                                else {
                                    rtbConsoleOutput.AppendText("!!!!!!!! WARNING !!!!!!!!\nCannot embed thumbnail to non-mp4 videos files\n");
                                }
                                break;
                            case DownloadType.Audio:
                                if (CurrentDownload.AudioFormat == AudioFormatType.m4a || CurrentDownload.AudioFormat == AudioFormatType.mp3) {
                                    ArgumentsBuffer.Append(" --embed-thumbnail");
                                }
                                else {
                                    rtbConsoleOutput.AppendText("!!!!!!!! WARNING !!!!!!!!\nCannot embed thumbnail to non-m4a/mp3 audio files\n");
                                }
                                break;
                        }
                    }
                }
                if (Config.Settings.Downloads.WriteMetadata) {
                    ArgumentsBuffer.Append(" --add-metadata");
                }

                if (Config.Settings.Downloads.KeepOriginalFiles) {
                    ArgumentsBuffer.Append(" -k");
                }

                if (Config.Settings.Downloads.LimitDownloads && Config.Settings.Downloads.DownloadLimit > 0) {
                    ArgumentsBuffer.Append($" --limit-rate {Config.Settings.Downloads.DownloadLimit}");
                    switch (Config.Settings.Downloads.DownloadLimitType) {
                        case 1: { // mb
                            ArgumentsBuffer.Append("M ");
                        } break;
                        case 2: { // gb
                            ArgumentsBuffer.Append("G ");
                        } break;
                        default: { // kb default
                            ArgumentsBuffer.Append("K ");
                        } break;
                    }
                }

                if (Config.Settings.Downloads.RetryAttempts != 10 && Config.Settings.Downloads.RetryAttempts > 0) {
                    ArgumentsBuffer.Append($" --retries {Config.Settings.Downloads.RetryAttempts}");
                }

                if (Config.Settings.Downloads.ForceIPv4) {
                    ArgumentsBuffer.Append(" --force-ipv4");
                }
                else if (Config.Settings.Downloads.ForceIPv6) {
                    ArgumentsBuffer.Append(" --force-ipv6");
                }

                if (Config.Settings.Downloads.UseProxy && Config.Settings.Downloads.ProxyType > -1 && !string.IsNullOrEmpty(Config.Settings.Downloads.ProxyIP) && !string.IsNullOrEmpty(Config.Settings.Downloads.ProxyPort)) {
                    ArgumentsBuffer.Append($" --proxy {Download.ProxyProtocols[Config.Settings.Downloads.ProxyType]}{Config.Settings.Downloads.ProxyIP}:{Config.Settings.Downloads.ProxyPort}/ ");
                }
            }
            #endregion

            #region Authentication
            // Set the preview arguments to what is present in the arguments buffer.
            // This is so the arguments buffer can have sensitive information and
            // the preview arguments won't include it in case anyone creates an issue.
            PreviewArguments = new(ArgumentsBuffer.ToString());

            if (CurrentDownload.AuthUsername is not null) {
                ArgumentsBuffer.Append($" --username {CurrentDownload.AuthUsername}");
                CurrentDownload.AuthUsername = null;
                PreviewArguments.Append(" --username ***");
            }
            if (CurrentDownload.AuthPassword is not null) {
                ArgumentsBuffer.Append($" --password {CurrentDownload.AuthPassword}");
                CurrentDownload.AuthPassword = null;
                PreviewArguments.Append(" --password ***");
            }
            if (CurrentDownload.Auth2Factor is not null) {
                ArgumentsBuffer.Append($" --twofactor {CurrentDownload.Auth2Factor}");
                CurrentDownload.Auth2Factor = null;
                PreviewArguments.Append(" --twofactor ***");
            }
            if (CurrentDownload.AuthVideoPassword is not null) {
                ArgumentsBuffer.Append($" --video-password {CurrentDownload.AuthVideoPassword}");
                CurrentDownload.AuthVideoPassword = null;
                PreviewArguments.Append(" --video-password ***");
            }
            if (CurrentDownload.AuthNetrc) {
                CurrentDownload.AuthNetrc = false;
                ArgumentsBuffer.Append(" --netrc");
                PreviewArguments.Append(" --netrc ***");
            }
            #endregion

            rtbConsoleOutput.AppendText("Arguments have been generated and are readonly in the textbox\n");
            txtArgumentsGenerated.Text = PreviewArguments.ToString();

            #region Download thread
            rtbConsoleOutput.AppendText("Creating download thread\n");
            bool IsYtdlp = Config.Settings.Downloads.YtdlType == 2;
            if (IsYtdlp) {
                rtbConsoleOutput.AppendText("Due to youtube-dlp changing how download progress is updated, a console with download progress will appear.\n");
            }
            DownloadThread = new Thread(() => {
                try {
                    DownloadProcess = new Process() {
                        StartInfo = new ProcessStartInfo(Program.verif.YoutubeDlPath) {
                            UseShellExecute = false,
                            RedirectStandardOutput = !IsYtdlp,
                            RedirectStandardError = !IsYtdlp,
                            CreateNoWindow = !IsYtdlp,
                            Arguments = ArgumentsBuffer.ToString()
                        },
                        EnableRaisingEvents = true
                    };
                    DownloadProcess.OutputDataReceived += (s, e) => {
                        this.BeginInvoke(new MethodInvoker(() => {
                            if (e.Data is not null)
                                rtbConsoleOutput?.AppendText($"{e.Data}\n");
                        }));
                    };
                    DownloadProcess.ErrorDataReceived += (s, e) => {
                        this.BeginInvoke(new MethodInvoker(() => {
                            if (e.Data is not null)
                                rtbConsoleOutput?.AppendText($"Error: {e.Data}\n");
                        }));
                    };
                    DownloadProcess.Exited += (s, e) => {
                        CurrentDownload.Status = DownloadProcess.ExitCode switch {
                            0 => DownloadStatus.Finished,
                            _ => CurrentDownload.Status == DownloadStatus.Aborted ? DownloadStatus.Aborted : DownloadStatus.YtdlError
                        };
                    };

                    if (CurrentDownload.Status != DownloadStatus.Aborted) {
                        DownloadProcess.Start();

                        ArgumentsBuffer = null;
                        PreviewArguments = null;

                        if (!IsYtdlp) {
                            DownloadProcess.BeginOutputReadLine();
                            DownloadProcess.BeginErrorReadLine();
                        }

                        while (!DownloadProcess.HasExited) {
                            Thread.Sleep(1000);
                        }
                    }

                }
                catch (ThreadAbortException) {
                    if (!IsYtdlp) {
                        DownloadProcess.CancelErrorRead();
                        DownloadProcess.CancelOutputRead();
                    }
                    Program.KillProcessTree((uint)DownloadProcess.Id);
                    DownloadProcess.Kill();
                    this.BeginInvoke((Action)delegate {
                        if (this.IsHandleCreated) {
                            rtbConsoleOutput.AppendText("Downloading was aborted by the user.");
                        }
                    });
                    CurrentDownload.Status = DownloadStatus.Aborted;
                }
                catch (Exception ex) {
                    Log.ReportException(ex);
                    CurrentDownload.Status = DownloadStatus.ProgramError;
                }
                finally {
                    if (CurrentDownload.Status != DownloadStatus.Aborted || CurrentDownload.BatchDownload && this.IsHandleCreated) {
                        this.BeginInvoke(() => DownloadFinished());
                    }
                }
            });
            rtbConsoleOutput.AppendText("Created download thread, starting...\n");
            DownloadThread.Name = "Downloading video";
            DownloadThread.Start();
            #endregion
        }
        private void DownloadFinished() {
            tmrTitleActivity.Stop();
            this.Text = this.Text.Trim('.');
            btnDownloaderCancelExit.Text = Program.lang.GenericExit;

            if (CurrentDownload.BatchDownload) {
                switch (CurrentDownload.Status) {
                    case DownloadStatus.Aborted:
                        if (AbortBatch) {
                            this.DialogResult = DialogResult.Abort;
                        }
                        else {
                            this.DialogResult = DialogResult.Ignore;
                        }
                        break;
                    case DownloadStatus.YtdlError:
                        this.Activate();
                        System.Media.SystemSounds.Hand.Play();
                        rtbConsoleOutput.AppendText("\nAn error occured\nTHIS IS A YOUTUBE-DL ERROR, NOT A ERROR WITH THIS PROGRAM!\nExit the form to resume batch download.");
                        this.Text = Program.lang.frmDownloaderError;
                        break;
                    case DownloadStatus.ProgramError:
                        rtbConsoleOutput.AppendText("\nAn error occured\nAn error log was presented, if enabled.\nExit the form to resume batch download.");
                        this.Text = Program.lang.frmDownloaderError;
                        this.Activate();
                        System.Media.SystemSounds.Hand.Play();
                        break;
                    case DownloadStatus.Finished:
                        this.DialogResult = DialogResult.Yes;
                        break;
                    default:
                        this.DialogResult = DialogResult.No;
                        break;
                }
            }
            else {
                switch (CurrentDownload.Status) {
                    case DownloadStatus.Aborted:
                        break;
                    case DownloadStatus.YtdlError:
                        rtbConsoleOutput.AppendText("\nAn error occured\nTHIS IS A YOUTUBE-DL ERROR, NOT A ERROR WITH THIS PROGRAM!");
                        btnDownloaderAbortBatchDownload.Visible = true;
                        btnDownloaderAbortBatchDownload.Enabled = true;
                        btnDownloaderAbortBatchDownload.Text = Program.lang.GenericRetry;
                        this.Text = Program.lang.frmDownloaderError;
                        this.Activate();
                        System.Media.SystemSounds.Hand.Play();
                        break;
                    case DownloadStatus.ProgramError:
                        rtbConsoleOutput.AppendText("\nAn error occured\nAn error log was presented, if enabled.");
                        this.Text = Program.lang.frmDownloaderError;
                        this.Activate();
                        System.Media.SystemSounds.Hand.Play();
                        break;
                    case DownloadStatus.Finished:
                        this.Text = Program.lang.frmDownloaderComplete;
                        rtbConsoleOutput.AppendText("Download has finished.");
                        if (chkDownloaderCloseAfterDownload.Checked) { this.Close(); }
                        break;
                    default:
                        this.Text = Program.lang.frmDownloaderComplete;
                        rtbConsoleOutput.AppendText("CurrentDownload.Status not defined (Not a batch download)\nAssuming success.");
                        if (chkDownloaderCloseAfterDownload.Checked) { this.Close(); }
                        break;
                }
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