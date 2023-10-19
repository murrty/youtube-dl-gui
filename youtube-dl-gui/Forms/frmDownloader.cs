#nullable enable
namespace youtube_dl_gui;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
internal partial class frmDownloader : LocalizedProcessingForm {
    public DownloadInfo CurrentDownload { get; }

    private Thread? DownloadThread;              // The thread of the process for youtube-dl.
    private Process? DownloadProcess;            // The process of youtube-dl which we'll redirect.
    private bool AbortBatch = false;   // Determines if the rest of the batch downloads should be cancelled.

    public frmDownloader(DownloadInfo Info) {
        InitializeComponent();
        LoadLanguage();
        CurrentDownload = Info;
    }

    public override void LoadLanguage() {
        this.Text = Language.frmDownloader + " ";
        btnDownloaderRetryAbortBatch.Text = Language.btnDownloaderAbortBatch;
        btnClearOutput.Text = Language.GenericClear;
        btnDownloaderCancelExit.Text = Language.GenericSkip;
        btnDownloaderCancelExit.Text = Language.GenericCancel;
        chkDownloaderCloseAfterDownload.Text = Language.chkDownloaderCloseAfterDownload;
        chkDownloaderCloseAfterDownload.Checked = Downloads.CloseDownloaderAfterFinish;

        switch (CurrentDownload?.Status) {
            case DownloadStatus.Aborted: {
                pbStatus.Text = Language.GenericAborted;
                btnDownloaderRetryAbortBatch.Text = Language.GenericRetry;
                btnDownloaderCancelExit.Text = Language.GenericExit;
            } break;
            case DownloadStatus.YtdlError: {
                pbStatus.Text = Language.GenericAltError.Format("youtube-dl");
                btnDownloaderRetryAbortBatch.Text = Language.GenericRetry;
                btnDownloaderCancelExit.Text = Language.GenericExit;
            } break;
            case DownloadStatus.ProgramError: {
                pbStatus.Text = Language.GenericError;
                btnDownloaderRetryAbortBatch.Text = Language.GenericRetry;
                btnDownloaderCancelExit.Text = Language.GenericExit;
            } break;
            case DownloadStatus.AbortForClose: {
                btnDownloaderRetryAbortBatch.Text = Language.GenericRetry;
                btnDownloaderCancelExit.Text = Language.GenericExit;
            } break;
            case DownloadStatus.Preparing: {
                pbStatus.Text = Language.dlBeginningDownload;
                btnDownloaderRetryAbortBatch.Text = Language.GenericCancel;
            } break;
            case DownloadStatus.Downloading: {
                btnDownloaderRetryAbortBatch.Text = Language.GenericCancel;
            } break;
            case DownloadStatus.MergingFiles: {
                pbStatus.Text = Language.pbDownloadProgressMergingFormats;
                btnDownloaderRetryAbortBatch.Text = Language.GenericCancel;
            } break;
            case DownloadStatus.Converting: {
                pbStatus.Text = Language.pbDownloadProgressConverting;
                btnDownloaderRetryAbortBatch.Text = Language.GenericCancel;
            } break;
            case DownloadStatus.FfmpegPostProcessing: {
                pbStatus.Text = Language.pbDownloadProgressFfmpegPostProcessing;
                btnDownloaderRetryAbortBatch.Text = Language.GenericCancel;
            } break;
            case DownloadStatus.EmbeddingSubtitles: {
                pbStatus.Text = Language.pbDownloadProgressEmbeddingSubtitles;
                btnDownloaderRetryAbortBatch.Text = Language.GenericCancel;
            } break;
            case DownloadStatus.EmbeddingMetadata: {
                btnDownloaderRetryAbortBatch.Text = Language.GenericCancel;
            } break;
            case DownloadStatus.Finished: {
                pbStatus.Text = Language.GenericCompleted;
                btnDownloaderCancelExit.Text = Language.GenericExit;
            } break;
            default: {
                pbStatus.Text = ".  .  .";
            } break;
        }
    }
    public void RetryOrAbort() {
        switch (CurrentDownload.Status) {
            case DownloadStatus.YtdlError:
            case DownloadStatus.ProgramError:
            case DownloadStatus.Aborted:
                btnDownloaderRetryAbortBatch.Visible = false;
                btnDownloaderRetryAbortBatch.Enabled = false;
                this.Text = Language.frmDownloader + " ";
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
                        rtbVerbose.AppendLine("The user requested to abort subsequent batch downloads");
                        btnDownloaderRetryAbortBatch.Enabled = false;
                        btnDownloaderRetryAbortBatch.Visible = false;
                        break;
                    default:
                        if (DownloadThread?.IsAlive == true) {
                            if (DownloadProcess?.HasExited == false) {
                                if (DownloadProcess.StartInfo.RedirectStandardOutput) {
                                    DownloadProcess.CancelOutputRead();
                                }
                                if (DownloadProcess.StartInfo.RedirectStandardError) {
                                    DownloadProcess.CancelErrorRead();
                                }
                            }
                            DownloadThread.Abort();
                        }
                        rtbVerbose.AppendLine("Additionally, the batch download has been cancelled.");
                        CurrentDownload.Status = DownloadStatus.Aborted;
                        this.Close();
                        break;
                }
                break;
        }
    }
    private void BeginDownload() {
        Log.Write($"Beginning download for {CurrentDownload.DownloadURL}.");
        if (CurrentDownload.DownloadURL.IsNullEmptyWhitespace()) {
            rtbVerbose.AppendText("The URL is null or empty. Please enter a URL to download.");
            Log.Write("Cannot continue download.");
            CurrentDownload.Status = DownloadStatus.ProgramError;
            return;
        }

        if (!Verification.YoutubeDlAvailable) {
            Verification.RefreshYoutubeDlLocation();

            if (!Verification.YoutubeDlAvailable) {
                CurrentDownload.Status = DownloadStatus.ProgramError;
                rtbVerbose.AppendLine("Youtube-dl could not be found.");
                Log.Write("Youtube-dl could not be found.");
                DownloadFinished();
                return;
            }
        }

        rtbVerbose.AppendText("Beginning download, this box will output progress");
        if (CurrentDownload.BatchDownload) {
            chkDownloaderCloseAfterDownload.Checked = true;
        }

        if (!CurrentDownload.GenerateArguments(rtbVerbose.AppendLine)) {
            CurrentDownload.Status = DownloadStatus.ProgramError;
            DownloadFinished();
            return;
        }

        rtbVerbose.AppendLine("Arguments have been generated and are readonly in the textbox");
        if (Verification.YtDlpProgressProblem) {
            rtbVerbose.AppendLine("""
                WARNING: Progress MAY not be made using yt-dlp on Windows 7 with limiting downloads enabled.
                youtube-dl-gui is NOT the cause of this issue, it lies on yt-dlp to implement a fix for.
                """);
        }

        txtGeneratedArguments.Text = CurrentDownload.ArgumentsCensored;

        #region Download thread
        rtbVerbose.AppendLine("Creating download thread");
        Log.Write("Beginning download thread.");
        DownloadThread = new Thread(() => {
            string? Msg = null;
            string InterimMsg;
            int InterimIndex;

            try {
                ProcessStartInfo StartInfo = new(Verification.YoutubeDlPath) {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    Arguments = CurrentDownload.Arguments,
                };

                DownloadProcess = new Process() { StartInfo = StartInfo };
                DownloadProcess.OutputDataReceived += (s, e) => {
                    if (e.Data?.Length > 0) {
                        switch (e.Data[..8].ToLowerInvariant()) {
                            case "[downloa": case "[ffmpeg]":
                            case "[embedsu": case "[metadat": {
                                Msg = e.Data;
                            } break;

                            default: {
                                Msg = null;
                                InterimMsg = e.Data.ToLowerInvariant();
                                if ((InterimIndex = InterimMsg.IndexOf(']')) > -1) {
                                    switch (InterimMsg[..(InterimIndex + 1)]) {
                                        case "[merger]": {
                                            pbStatus.Invoke(() => {
                                                pbStatus.Style = ProgressBarStyle.Marquee;
                                                pbStatus.Value = pbStatus.Maximum;
                                                pbStatus.Text = Language.pbDownloadProgressMergingFormats;
                                            });
                                        } break;
                                        case "[videoconvertor]": {
                                            pbStatus.Invoke(() => {
                                                pbStatus.Style = ProgressBarStyle.Marquee;
                                                pbStatus.Value = pbStatus.Maximum;
                                                pbStatus.Text = Language.pbDownloadProgressConverting;
                                            });
                                        } break;
                                        case "[extractaudio]": {
                                            pbStatus.Invoke(() => {
                                                pbStatus.Style = ProgressBarStyle.Marquee;
                                                pbStatus.Value = pbStatus.Maximum;
                                                pbStatus.Text = Language.pbDownloadProgressExtractingAudio;
                                            });
                                        } break;
                                        default: {
                                            if (pbStatus.Style != ProgressBarStyle.Blocks) {
                                                pbStatus.Invoke(() => pbStatus.Style = ProgressBarStyle.Blocks);
                                            }
                                            if (pbStatus.Text != ".  .  .") {
                                                pbStatus.Invoke(() => pbStatus.Text = ".  .  .");
                                            }
                                            if (pbStatus.Value != 0) {
                                                pbStatus.Invoke(() => pbStatus.Value = 0);
                                            }
                                        } break;
                                    }
                                }
                                else {
                                    if (pbStatus.Style != ProgressBarStyle.Blocks) {
                                        pbStatus.Invoke(() => pbStatus.Style = ProgressBarStyle.Blocks);
                                    }
                                    if (pbStatus.Text != ".  .  .") {
                                        pbStatus.Invoke(() => pbStatus.Text = ".  .  .");
                                    }
                                    if (pbStatus.Value != 0) {
                                        pbStatus.Invoke(() => pbStatus.Value = 0);
                                    }
                                }

                                rtbVerbose?.Invoke(() => rtbVerbose.AppendLine(e.Data));
                            } break;
                        }
                    }
                };
                DownloadProcess.ErrorDataReceived += (s, e) => {
                    this.BeginInvoke(() => {
                        if (e.Data?.Length > 0) {
                            rtbVerbose?.AppendLine($"Error: {e.Data}");
                        }
                    });
                };

                if (CurrentDownload.Status == DownloadStatus.Aborted) {
                    return;
                }

                this.Invoke(() => {
                    tmrTitleActivity.Start();
                    pbStatus.ShowInTaskbar = true;
                });

                DownloadProcess.Start();
                DownloadProcess.BeginOutputReadLine();
                DownloadProcess.BeginErrorReadLine();

                float Percentage = 0;
                string Eta = "Unknown";

                while (!DownloadProcess.HasExited) {
                    if (CurrentDownload.Status == DownloadStatus.Aborted || CurrentDownload.Status == DownloadStatus.AbortForClose) {
                        if (!DownloadProcess.HasExited) {
                            Program.KillProcessTree((uint)DownloadProcess.Id);
                            DownloadProcess.Kill();
                        }
                        return;
                    }

                    if (!Msg.IsNullEmptyWhitespace()) {
                        //Console.WriteLine(Msg);
                        string Line = Msg.ReplaceWhitespace();
                        switch (Line[..5].ToLowerInvariant()) {
                            case "[down": {
                                string[] LineParts = Line.Split(' ');
                                switch (LineParts[1][0]) {
                                    case '1': case '2': case '3':
                                    case '4': case '5': case '6':
                                    case '7': case '8': case '9':
                                    case '0': {
                                        if (!LineParts[1].Contains('%') || !pbStatus.IsHandleCreated) {
                                            break;
                                        }

                                        if (pbStatus.Style != ProgressBarStyle.Blocks) {
                                            pbStatus.Invoke(() => pbStatus.Style = ProgressBarStyle.Blocks);
                                        }

                                        pbStatus.Invoke(() => {
                                            pbStatus.Text =
                                                $"{DownloadHelper.GetTransferData(LineParts, ref Percentage, ref Eta) } ETA {Eta}";
                                            pbStatus.Value = (int)Math.Floor(Percentage);
                                        });
                                    } break;
                                }
                            } break;
                            case "[ffmp": {
                                rtbVerbose.Invoke(() => rtbVerbose.AppendLine(Line));
                                pbStatus.Invoke(() => {
                                    pbStatus.Style = ProgressBarStyle.Marquee;
                                    pbStatus.Text = Language.pbDownloadProgressFfmpegPostProcessing;
                                    pbStatus.Value = 100;
                                });
                                Msg = null;
                            } break;
                            case "[embe": {
                                rtbVerbose.Invoke(() => rtbVerbose.AppendLine(Line));
                                pbStatus.Invoke(() => {
                                    pbStatus.Style = ProgressBarStyle.Marquee;
                                    pbStatus.Text = Language.pbDownloadProgressEmbeddingSubtitles;
                                    pbStatus.Value = 100;
                                });
                                Msg = null;
                            } break;
                            case "[meta": {
                                rtbVerbose.Invoke(() => rtbVerbose.AppendLine(Line));
                                pbStatus.Invoke(() => {
                                    pbStatus.Style = ProgressBarStyle.Marquee;
                                    pbStatus.Text = Language.pbDownloadProgressEmbeddingMetadata;
                                    pbStatus.Value = 100;
                                });
                                Msg = null;
                            } break;
                        }
                        Msg = null;
                    }

                    Thread.Sleep(250);
                }

                CurrentDownload.Status = DownloadProcess.ExitCode switch {
                    0 => DownloadStatus.Finished,
                    _ => CurrentDownload.Status == DownloadStatus.Aborted ? DownloadStatus.Aborted : DownloadStatus.YtdlError
                };
            }
            catch (ThreadAbortException) {
                if (DownloadProcess is not null) {
                    Program.KillProcessTree((uint)DownloadProcess.Id);
                    DownloadProcess?.Kill();
                }

                this.BeginInvoke(() => {
                    if (this.IsHandleCreated) {
                        rtbVerbose.AppendLine("Downloading was aborted by the user.");
                        btnDownloaderCancelExit.Text = Language.GenericExit;
                    }
                });

                CurrentDownload.Status = DownloadStatus.Aborted;
            }
            catch (Exception ex) {
                Log.ReportException(ex);
                CurrentDownload.Status = DownloadStatus.ProgramError;
            }
            finally {
                if (this.IsHandleCreated) {
                    this.BeginInvoke(() => {
                        pbStatus.Style = ProgressBarStyle.Continuous;
                        pbStatus.ShowInTaskbar = false;
                        DownloadFinished();
                    });
                }
            }
        }) {
            IsBackground = true,
            Name = $"Download {CurrentDownload.DownloadURL}"
        };
        rtbVerbose.AppendLine("Created download thread, starting...");
        DownloadThread.Start();
        #endregion
    }
    private void DownloadFinished() {
        tmrTitleActivity.Stop();
        this.Text = this.Text.Trim('.');
        btnDownloaderCancelExit.Text = Language.GenericExit;

        if (CurrentDownload.BatchDownload) {
            switch (CurrentDownload.Status) {
                case DownloadStatus.Aborted:
                    this.DialogResult = AbortBatch ? DialogResult.Abort : DialogResult.Ignore;
                    break;
                case DownloadStatus.YtdlError:
                    this.Activate();
                    System.Media.SystemSounds.Hand.Play();
                    rtbVerbose.AppendLine("An error occured\r\nTHIS IS A YOUTUBE-DL ERROR, NOT A ERROR WITH THIS PROGRAM!\r\nExit the form to resume batch download.");
                    btnDownloaderRetryAbortBatch.Text = Language.GenericRetry;
                    pbStatus.ProgressState = murrty.controls.ProgressState.Error;
                    this.Text = Language.frmDownloaderError;
                    break;
                case DownloadStatus.ProgramError:
                    rtbVerbose.AppendLine("An error occured\r\nAn error log was presented, if enabled.\r\nExit the form to resume batch download.");
                    pbStatus.ProgressState = murrty.controls.ProgressState.Error;
                    pbStatus.Text = "Error";
                    this.Text = Language.frmDownloaderError;
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
                    pbStatus.ProgressState = murrty.controls.ProgressState.Error;
                    pbStatus.Text = Language.GenericAborted;
                    break;
                case DownloadStatus.YtdlError:
                    rtbVerbose.AppendLine("An error occured\r\nTHIS IS A YOUTUBE-DL ERROR, NOT A ERROR WITH THIS PROGRAM!");
                    btnDownloaderRetryAbortBatch.Visible = true;
                    btnDownloaderRetryAbortBatch.Enabled = true;
                    btnDownloaderRetryAbortBatch.Text = Language.GenericRetry;
                    pbStatus.ProgressState = murrty.controls.ProgressState.Error;
                    pbStatus.Text = Language.GenericAltError.Format("youtube-dl");
                    this.Text = Language.frmDownloaderError;
                    this.Activate();
                    System.Media.SystemSounds.Hand.Play();
                    break;
                case DownloadStatus.ProgramError:
                    rtbVerbose.AppendLine("An error occured\r\nAn error log was presented, if enabled.");
                    pbStatus.ProgressState = murrty.controls.ProgressState.Error;
                    pbStatus.Text = Language.GenericError;
                    this.Text = Language.frmDownloaderError;
                    this.Activate();
                    System.Media.SystemSounds.Hand.Play();
                    break;
                case DownloadStatus.Finished:
                    this.Text = Language.frmDownloaderComplete;
                    rtbVerbose.AppendLine("Download has finished.");
                    if (chkDownloaderCloseAfterDownload.Checked) { this.Close(); }
                    else {
                        pbStatus.Value = pbStatus.Maximum;
                        pbStatus.Text = Language.GenericCompleted;
                    }
                    break;
                default:
                    this.Text = Language.frmDownloaderComplete;
                    rtbVerbose.AppendLine("CurrentDownload.Status not defined (Not a batch download)\r\nAssuming success.");
                    if (chkDownloaderCloseAfterDownload.Checked) { this.Close(); }
                    break;
            }
        }
    }

    private void frmExtendedMassDownloader_Load(object sender, EventArgs e) {
        if (CurrentDownload.BatchDownload) {
            this.WindowState = FormWindowState.Minimized;
            btnDownloaderRetryAbortBatch.Enabled = true;
            btnDownloaderRetryAbortBatch.Visible = true;
        }

        if (Saved.QuickDownloaderLocation.Valid) {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Saved.QuickDownloaderLocation;
        }
    }
    private void frmExtendedMassDownloader_Shown(object sender, EventArgs e) {
        pbStatus.Focus();
    }
    private void frmExtendedMassDownloader_FormClosing(object sender, FormClosingEventArgs e) {
        DialogResult Finish = DialogResult.None;
        switch (CurrentDownload.Status) {
            case DownloadStatus.Aborted:
                if (CurrentDownload.BatchDownload) {
                    Finish = AbortBatch ? DialogResult.Abort : DialogResult.Ignore;
                }
                break;

            case DownloadStatus.Finished:
                if (CurrentDownload.BatchDownload) {
                    Finish = DownloadProcess?.ExitCode == 0 ? DialogResult.Yes : DialogResult.No;
                }
                break;

            case DownloadStatus.ProgramError:
            case DownloadStatus.YtdlError:
                if (CurrentDownload.BatchDownload) {
                    Finish = DialogResult.No;
                }
                break;

            default:
                if (DownloadThread?.IsAlive == true) {
                    DownloadThread.Abort();
                    e.Cancel = true;
                }
                break;
        }
        if (!e.Cancel) {
            if (!CurrentDownload.BatchDownload) {
                Downloads.CloseDownloaderAfterFinish = chkDownloaderCloseAfterDownload.Checked;
            }
            Saved.QuickDownloaderLocation = this.Location;
            this.DialogResult = Finish;
            this.Dispose();
        }
    }
    private void tmrTitleActivity_Tick(object sender, EventArgs e) {
        this.Text = this.Text.EndsWith("....") ? this.Text.TrimEnd('.') : this.Text += ".";
    }
    private void btnClearOutput_Click(object sender, EventArgs e) {
        rtbVerbose.Clear();
    }
    private void btnDownloaderRetryAbortBatch_Click(object sender, EventArgs e) {
        switch (CurrentDownload.Status) {
            case DownloadStatus.YtdlError:
            case DownloadStatus.ProgramError:
            case DownloadStatus.Aborted: {
                btnDownloaderRetryAbortBatch.Visible = false;
                btnDownloaderRetryAbortBatch.Enabled = false;
                this.Text = Language.frmDownloader + " ";
                pbStatus.Text = ".  .  .";
                pbStatus.Value = 0;
                pbStatus.ProgressState = murrty.controls.ProgressState.Normal;
                tmrTitleActivity.Start();
                BeginDownload();
            } break;

            default: {
                AbortBatch = true;
                switch (CurrentDownload.Status) {
                    case DownloadStatus.Finished:
                    case DownloadStatus.Aborted:
                    case DownloadStatus.YtdlError:
                    case DownloadStatus.ProgramError:
                        rtbVerbose.AppendLine("The user requested to abort subsequent batch downloads");
                        btnDownloaderRetryAbortBatch.Enabled = false;
                        btnDownloaderRetryAbortBatch.Visible = false;
                        break;
                    default:
                        if (DownloadThread?.IsAlive == true) {
                            DownloadThread.Abort();
                        }
                        rtbVerbose.AppendLine("Additionally, the batch download has been cancelled.");
                        this.Close();
                        break;
                }
            } break;
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
                Log.Write("Aborting download.");
                if (DownloadThread?.IsAlive == true) {
                    DownloadThread.Abort();
                }
                break;
        }
    }
}