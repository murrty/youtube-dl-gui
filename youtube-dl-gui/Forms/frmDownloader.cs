namespace youtube_dl_gui;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
public partial class frmDownloader : Form {
    public DownloadInfo CurrentDownload { get; }

    private Thread DownloadThread;              // The thread of the process for youtube-dl.
    private Process DownloadProcess;            // The process of youtube-dl which we'll redirect.
    private volatile bool AbortBatch = false;   // Determines if the rest of the batch downloads should be cancelled.
    private volatile string Msg = string.Empty; // Output message.
    private readonly bool Debug = false;

    public frmDownloader(DownloadInfo Info) {
        InitializeComponent();
        LoadLanguage();
        CurrentDownload = Info;
    }

    public frmDownloader() {
        Program.RunningActions.Add(this);
        InitializeComponent();
        LoadLanguage();
        this.Debug = true;
        System.Windows.Forms.Timer t = new() {
            Interval = 1000,
            Enabled = true
        };
        t.Tick += (s, e) => rtbVerbose.AppendLine("Hello when when when when when when when when when when when when when when when when when when");
    }

    private void LoadLanguage() {
        this.Text = Language.frmDownloader + " ";
        btnDownloaderAbortBatchDownload.Text = Language.btnDownloaderAbortBatch;
        btnClearOutput.Text = Language.GenericClear;
        btnDownloaderCancelExit.Text = Language.GenericSkip;
        btnDownloaderCancelExit.Text = Language.GenericCancel;
        chkDownloaderCloseAfterDownload.Text = Language.chkDownloaderCloseAfterDownload;
        chkDownloaderCloseAfterDownload.Checked = Config.Settings.Downloads.CloseDownloaderAfterFinish;
    }

    private void frmExtendedMassDownloader_Load(object sender, EventArgs e) {
        if (Debug) {
            btnDownloaderAbortBatchDownload.Visible = true;
            tmrTitleActivity.Start();
        }
        else {
            if (CurrentDownload.BatchDownload) {
                this.WindowState = FormWindowState.Minimized;
                btnDownloaderAbortBatchDownload.Enabled = true;
                btnDownloaderAbortBatchDownload.Visible = true;
            }
        }

        if (Config.Settings.Saved.QuickDownloaderLocation.Valid) {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Config.Settings.Saved.QuickDownloaderLocation;
        }

    }
    private void frmExtendedMassDownloader_Shown(object sender, EventArgs e) {
        pbStatus.Focus();
        if (!Debug)
            BeginDownload();
    }
    private void frmExtendedMassDownloader_FormClosing(object sender, FormClosingEventArgs e) {
        DialogResult Finish = DialogResult.None;
        switch (CurrentDownload.Status) {
            case DownloadStatus.Aborted:
                if (CurrentDownload.BatchDownload)
                    Finish = AbortBatch ? DialogResult.Abort : DialogResult.Ignore;
                break;

            case DownloadStatus.Finished:
                if (CurrentDownload.BatchDownload)
                    Finish = DownloadProcess.ExitCode == 0 ? DialogResult.Yes : DialogResult.No;
                break;

            case DownloadStatus.ProgramError:
            case DownloadStatus.YtdlError:
                if (CurrentDownload.BatchDownload)
                    Finish = DialogResult.No;
                break;

            default:
                if (DownloadThread is not null && DownloadThread.IsAlive) {
                    DownloadThread.Abort();
                    e.Cancel = true;
                }
                break;
        }
        if (!e.Cancel) {
            if (!CurrentDownload.BatchDownload)
                Config.Settings.Downloads.CloseDownloaderAfterFinish = chkDownloaderCloseAfterDownload.Checked;
            Config.Settings.Saved.QuickDownloaderLocation = this.Location;
            this.DialogResult = Finish;
            this.Dispose();
        }
    }
    private void tmrTitleActivity_Tick(object sender, EventArgs e) {
        this.Text = this.Text.EndsWith("....") ? this.Text.TrimEnd('.') : this.Text += ".";
    }
    private void btnClearOutput_Click(object sender, EventArgs e) {
        if (Debug)
            rtbVerbose.AppendLine("Hello, world world world world world world world world world world world world");
        else
            rtbVerbose.Clear();
    }
    private void btnDownloaderAbortBatchDownload_Click(object sender, EventArgs e) {
        switch (CurrentDownload.Status) {
            case DownloadStatus.YtdlError:
            case DownloadStatus.ProgramError:
            case DownloadStatus.Aborted: {
                btnDownloaderAbortBatchDownload.Visible = false;
                btnDownloaderAbortBatchDownload.Enabled = false;
                this.Text = Language.frmDownloader + " ";
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
                        btnDownloaderAbortBatchDownload.Enabled = false;
                        btnDownloaderAbortBatchDownload.Visible = false;
                        break;
                    default:
                        if (DownloadThread is not null && DownloadThread.IsAlive) {
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
                        btnDownloaderAbortBatchDownload.Enabled = false;
                        btnDownloaderAbortBatchDownload.Visible = false;
                        break;
                    default:
                        if (DownloadThread is not null && DownloadThread.IsAlive) {
                            if (DownloadProcess is not null && !DownloadProcess.HasExited) {
                                if (DownloadProcess.StartInfo.RedirectStandardOutput)
                                    DownloadProcess.CancelOutputRead();
                                if (DownloadProcess.StartInfo.RedirectStandardError)
                                    DownloadProcess.CancelErrorRead();
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
            return;
        }

        rtbVerbose.AppendText("Beginning download, this box will output progress");
        if (CurrentDownload.BatchDownload)
            chkDownloaderCloseAfterDownload.Checked = true;

        if (!CurrentDownload.GenerateArguments(rtbVerbose.AppendLine, out string Arguments, out string PreviewArguments))
            return;

        rtbVerbose.AppendLine("Arguments have been generated and are readonly in the textbox");
        if (Config.Settings.Downloads.LimitDownloads && (Config.Settings.Downloads.YtdlType == 0 || Config.Settings.Downloads.YtdlType == 3)
        && Environment.OSVersion.Version.Major <= 6 && Environment.OSVersion.Version.Minor <= 1) {
            rtbVerbose.AppendLine($"""
                WARNING: Progress MAY not be made using yt-dlp on Windows 7 with limiting downloads enabled.
                youtube-dl-gui is NOT the cause of this issue, it lies on yt-dlp to implement a fix for.
                """);
        }

        txtGeneratedArguments.Text = PreviewArguments;
        PreviewArguments = null;

        #region Download thread
        rtbVerbose.AppendLine("Creating download thread");
        Log.Write("Beginning download thread.");
        DownloadThread = new Thread(() => {
            string InterimMessage;
            try {
                DownloadProcess = new Process() {
                    StartInfo = new ProcessStartInfo(Verification.YoutubeDlPath) {
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                        Arguments = Arguments
                    },
                };
                DownloadProcess.OutputDataReceived += (s, e) => {
                    if (e.Data is not null && e.Data.Length > 0) {
                        switch (e.Data[..8].ToLower()) {
                            case "[downloa": case "[ffmpeg]":
                            case "[embedsu": case "[metadat": {
                                Msg = e.Data;
                            } break;

                            default: {
                                Msg = null;
                                InterimMessage = e.Data.ToLower();
                                if (InterimMessage.StartsWith("[merger]")) {
                                    pbStatus.Invoke(() => {
                                        pbStatus.Style = ProgressBarStyle.Marquee;
                                        pbStatus.Value = pbStatus.Maximum;
                                        pbStatus.Text = Language.pbDownloadProgressMergingFormats;
                                    });
                                }
                                else if (InterimMessage.StartsWith("[videoconvertor]")) { // Converter?
                                    pbStatus.Invoke(() => {
                                        pbStatus.Style = ProgressBarStyle.Marquee;
                                        pbStatus.Value = pbStatus.Maximum;
                                        pbStatus.Text = Language.pbDownloadProgressConverting;
                                    });
                                }
                                else {
                                    if (pbStatus.Style != ProgressBarStyle.Blocks)
                                        pbStatus.Invoke(() => pbStatus.Style = ProgressBarStyle.Blocks);

                                    if (pbStatus.Text != ".  .  .")
                                        pbStatus.Invoke(() => pbStatus.Text = ".  .  .");

                                    if (pbStatus.Value != 0)
                                        pbStatus.Invoke(() => pbStatus.Value = 0);
                                }
                                rtbVerbose?.Invoke(() => rtbVerbose.AppendLine(e.Data));
                            } break;
                        }
                    }
                };
                DownloadProcess.ErrorDataReceived += (s, e) => {
                    this.BeginInvoke(() => {
                        if (e.Data is not null && e.Data.Length > 0)
                            rtbVerbose?.AppendLine($"Error: {e.Data}");
                    });
                };
                Arguments = null;

                if (CurrentDownload.Status != DownloadStatus.Aborted) {
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

                        if (Msg.IsNotNullEmptyWhitespace()) {
                            //Console.WriteLine(Msg);
                            string Line = Msg.ReplaceWhitespace();
                            switch (Line[..5].ToLower()) {
                                case "[down": {
                                    string[] LineParts = Line.Split(' ');
                                    switch (LineParts[1][0]) {
                                        case '1': case '2': case '3':
                                        case '4': case '5': case '6':
                                        case '7': case '8': case '9':
                                        case '0': {
                                            if (pbStatus.Style != ProgressBarStyle.Blocks)
                                                pbStatus.Invoke(() => pbStatus.Style = ProgressBarStyle.Blocks);
                                            if (LineParts[1].Contains('%')) {
                                                pbStatus.Invoke(() => {
                                                    pbStatus.Text =
                                                        $"{DownloadHelper.GetTransferData(LineParts, ref Percentage, ref Eta) } ETA {Eta}";
                                                    pbStatus.Value = (int)Math.Floor(Percentage);
                                                });
                                            }
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
            }
            catch (ThreadAbortException) {
                Program.KillProcessTree((uint)DownloadProcess.Id);
                DownloadProcess?.Kill();
                this.BeginInvoke((Action)delegate {
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
                Program.RunningActions.Remove(this);
                if (this.IsHandleCreated) {
                    this.BeginInvoke(() => {
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
                    btnDownloaderAbortBatchDownload.Text = Language.GenericRetry;
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
                    pbStatus.Text = "Aborted";
                    break;
                case DownloadStatus.YtdlError:
                    rtbVerbose.AppendLine("An error occured\r\nTHIS IS A YOUTUBE-DL ERROR, NOT A ERROR WITH THIS PROGRAM!");
                    btnDownloaderAbortBatchDownload.Visible = true;
                    btnDownloaderAbortBatchDownload.Enabled = true;
                    btnDownloaderAbortBatchDownload.Text = Language.GenericRetry;
                    pbStatus.ProgressState = murrty.controls.ProgressState.Error;
                    pbStatus.Text = "Youtube-dl error";
                    this.Text = Language.frmDownloaderError;
                    this.Activate();
                    System.Media.SystemSounds.Hand.Play();
                    break;
                case DownloadStatus.ProgramError:
                    rtbVerbose.AppendLine("An error occured\r\nAn error log was presented, if enabled.");
                    pbStatus.ProgressState = murrty.controls.ProgressState.Error;
                    pbStatus.Text = "Error";
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
                        pbStatus.Text = "Finished";
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

}