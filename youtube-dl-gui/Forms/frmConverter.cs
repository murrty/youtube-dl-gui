using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmConverter : Form {
        public bool Debugging = false;
        public volatile ConvertInfo CurrentConversion;

        private Thread ConverterThread;             // The thread of the process for youtube-dl.
        private volatile Process ConverterProcess;  // The process of youtube-dl which we'll redirect.
        private volatile bool AbortBatch = false;   // Determines if the rest of the batch downloads should be cancelled.

        public frmConverter(ConvertInfo Info) {
            InitializeComponent();
            this.CurrentConversion = Info;
        }
        private void frmConverter_Load(object sender, EventArgs e) {
            this.Text = Language.frmConverter + " ";
            if (CurrentConversion.BatchConversion) {
                this.WindowState = FormWindowState.Minimized;
                btnConverterAbortBatchConversions.Enabled = true;
                btnConverterAbortBatchConversions.Visible = true;
                btnConverterAbortBatchConversions.Text = Language.btnConverterAbortBatchConversions;
                btnConverterCancelExit.Text = Language.GenericSkip;
            }
            else {
                btnConverterCancelExit.Text = Language.GenericCancel;
            }
            chkConverterCloseAfterConversion.Text = Language.chkConverterCloseAfterConversion;
            chkConverterCloseAfterConversion.Checked = Config.Settings.Converts.CloseAfterFinish;
        }
        private void frmConverter_Shown(object sender, EventArgs e) {
            BeginConversion();
        }
        private void frmConverter_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult Finish = DialogResult.None;
            switch (CurrentConversion.Status) {
                case ConversionStatus.Aborted:
                    if (CurrentConversion.BatchConversion) {
                        if (AbortBatch) {
                            Finish = DialogResult.Abort;
                        }
                        else {
                            Finish = DialogResult.Ignore;
                        }
                    }
                    break;
                case ConversionStatus.Finished:
                    if (ConverterProcess.ExitCode == 0) {
                        if (CurrentConversion.BatchConversion) {
                            this.DialogResult = DialogResult.Yes;
                        }
                    }
                    else {
                        if (CurrentConversion.BatchConversion) {
                            this.DialogResult = DialogResult.No;
                        }
                    }
                    break;
                case ConversionStatus.ProgramError:
                case ConversionStatus.FfmpegError:
                    if (CurrentConversion.BatchConversion) {
                        Finish = DialogResult.No;
                    }
                    break;
                default:
                    if (ConverterThread != null && ConverterThread.IsAlive) {
                        ConverterThread.Abort();
                        e.Cancel = true;
                    }
                    break;
            }
            if (!e.Cancel) {
                Config.Settings.Converts.CloseAfterFinish = chkConverterCloseAfterConversion.Checked;
                Config.Settings.Converts.Save();

                this.DialogResult = Finish;
                this.Dispose();
            }
        }

        public void Abort() {
            switch (CurrentConversion.Status) {
                case ConversionStatus.FfmpegError:
                case ConversionStatus.ProgramError:
                case ConversionStatus.Aborted:
                    btnConverterAbortBatchConversions.Visible = false;
                    btnConverterAbortBatchConversions.Enabled = false;
                    this.Text = Language.frmDownloader + " ";
                    tmrTitleActivity.Start();
                    BeginConversion();
                    break;
                default:
                    AbortBatch = true;
                    switch (CurrentConversion.Status) {
                        case ConversionStatus.Finished:
                        case ConversionStatus.Aborted:
                        case ConversionStatus.FfmpegError:
                        case ConversionStatus.ProgramError:
                            rtbConsoleOutput.AppendText("The user requested to abort subsequent batch conversions");
                            btnConverterAbortBatchConversions.Enabled = false;
                            btnConverterAbortBatchConversions.Visible = false;
                            break;
                        default:
                            if (ConverterThread != null && ConverterThread.IsAlive) {
                                ConverterThread.Abort();
                            }
                            rtbConsoleOutput.AppendText("Additionally, the batch conversion has been cancelled.");
                            CurrentConversion.Status = ConversionStatus.Aborted;
                            this.Close();
                            break;
                    }
                    break;
            }
        }

        private void tmrTitleActivity_Tick(object sender, EventArgs e) {
            if (this.Text.EndsWith("....")) this.Text = this.Text.TrimEnd('.');
            else this.Text += ".";
        }

        private void BeginConversion() {
            Debug.Print("BeginConversion()");
            if (string.IsNullOrWhiteSpace(CurrentConversion.InputFile)) {
                rtbConsoleOutput.AppendText("The input file is null or empty. Cannot convert no file.");
                CurrentConversion.Status = ConversionStatus.ProgramError;
                return;
            }
            if (string.IsNullOrWhiteSpace(CurrentConversion.OutputFile)) {
                rtbConsoleOutput.AppendText("The output file is null or empty. Cannot convert to no file.");
                CurrentConversion.Status = ConversionStatus.ProgramError;
                return;
            }

            rtbConsoleOutput.AppendText("Beginning conversion, this box will output progress\n");
            if (CurrentConversion.BatchConversion) {
                chkConverterCloseAfterConversion.Checked = true;
            }

            CurrentConversion.Status = ConversionStatus.GeneratingArguments;

            StringBuilder ArgumentsBuffer = new("-i \"" + CurrentConversion.InputFile + "\"");
            // string PreviewArguments = null; ???

            #region ffmpeg path
            if (string.IsNullOrWhiteSpace(Verification.FFmpegPath)) {
                rtbConsoleOutput.AppendText("ffmpeg has not been found.\nA rescan for ffmpeg was called\n");
                Verification.RefreshFFmpegLocation();
                if (Verification.FFmpegPath != null) {
                    rtbConsoleOutput.AppendText("Rescan finished and found, continuing\n");
                }
                else {
                    rtbConsoleOutput.AppendText("still couldn't find ffmpeg.");
                    CurrentConversion.Status = ConversionStatus.ProgramError;
                    return;
                }
            }
            rtbConsoleOutput.AppendText("ffmpeg has been found and set\n");
            #endregion

            #region Arguments
            switch (CurrentConversion.Type) {
                case ConversionType.Video:
                    if (CurrentConversion.VideoUseBitrate)
                        ArgumentsBuffer.Append($" -b:v {CurrentConversion.VideoBitrate}k");

                    if (CurrentConversion.VideoUsePreset)
                        ArgumentsBuffer.Append($" -preset {Convert.GetVideoPreset(CurrentConversion.VideoPreset)}");

                    if (CurrentConversion.VideoUseCRF)
                        ArgumentsBuffer.Append($" -crf {CurrentConversion.VideoCRF}");

                    if (!CurrentConversion.OutputFile.EndsWith(".wmv") && CurrentConversion.VideoUseProfile)
                        ArgumentsBuffer.Append($" -profile:v {Convert.GetVideoProfile(CurrentConversion.VideoProfile)}");

                    if (CurrentConversion.VideoFastStart)
                        ArgumentsBuffer.Append(" -faststart");
                    break;

                case ConversionType.Audio:
                    if (CurrentConversion.AudioUseBitrate)
                        ArgumentsBuffer.Append($" -ab {CurrentConversion.AudioBitrate * 1000}");

                    break;

                case ConversionType.Custom:
                    rtbConsoleOutput.AppendText("Custom conversion was specified, skipping generating arguments\n");
                    ArgumentsBuffer.Append(CurrentConversion.CustomArguments);
                    break;

                default:
                    rtbConsoleOutput.AppendText("Using ffmpeg to automatically choose best settings\n");
                    break;
            }

            // Extra arguments not supported by the custom conversion type
            if (CurrentConversion.Type != ConversionType.Custom) {
                if (CurrentConversion.HideFFmpegCompile)
                    ArgumentsBuffer.Append(" -hide_banner");
            }

            ArgumentsBuffer.Append($" \"{CurrentConversion.OutputFile}\"");
            #endregion

            rtbConsoleOutput.AppendText("Arguments have been generated and are readonly in the textbox.\n");
            txtArgumentsGenerated.Text = ArgumentsBuffer.ToString();
            CurrentConversion.Status = ConversionStatus.Converting;

            #region Conversion thread
            ConverterThread = new Thread(() => {
                Program.RunningActions.Add(this);
                try {
                    ConverterProcess = new Process() {
                        StartInfo = new(Verification.FFmpegPath) {
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            CreateNoWindow = true,
                            Arguments = ArgumentsBuffer.ToString()
                        },
                        EnableRaisingEvents = true
                    };
                    ConverterProcess.OutputDataReceived += (s, e) => {
                        this.BeginInvoke(new MethodInvoker(() => {
                            if (e.Data != null && rtbConsoleOutput != null)
                                rtbConsoleOutput.AppendText(e.Data + "\n");
                        }));
                    };
                    ConverterProcess.ErrorDataReceived += (s, e) => {
                        this.BeginInvoke(new MethodInvoker(() => {
                            if (e.Data != null && rtbConsoleOutput != null) {
                                rtbConsoleOutput.AppendText("Error:\n");
                                rtbConsoleOutput.AppendText(e.Data + "\n");
                            }
                        }));
                    };
                    ConverterProcess.Exited += (s, e) => {
                        if (ConverterProcess.ExitCode == 0) {
                            CurrentConversion.Status = ConversionStatus.Finished;
                        }
                        else if (CurrentConversion.Status != ConversionStatus.Aborted) {
                            CurrentConversion.Status = ConversionStatus.FfmpegError;
                        }
                    };

                    if (CurrentConversion.Status != ConversionStatus.Aborted) {
                        ConverterProcess.Start();

                        ArgumentsBuffer = null;

                        ConverterProcess.BeginOutputReadLine();
                        ConverterProcess.BeginErrorReadLine();

                        while (!ConverterProcess.HasExited) {
                            Thread.Sleep(1000);
                        }
                    }
                }
                catch (ThreadAbortException) {
                    ConverterProcess.CancelErrorRead();
                    ConverterProcess.CancelOutputRead();
                    Program.KillProcessTree((uint)ConverterProcess.Id);
                    ConverterProcess.Kill();
                    this.Invoke((Action)delegate {
                        rtbConsoleOutput.AppendText("Conversion was aborted by the user.");
                    });
                }
                catch (Exception ex) {
                    Log.ReportException(ex);
                    CurrentConversion.Status = ConversionStatus.ProgramError;
                }
                finally {
                    Program.RunningActions.Remove(this);
                    if (CurrentConversion.Status != ConversionStatus.Aborted || CurrentConversion.BatchConversion) {
                        this.BeginInvoke((Action)delegate {
                            ConversionFinished();
                        });
                    }
                }
            });
            rtbConsoleOutput.AppendText("Created conversion thread, starting...\n");
            ConverterThread.Name = "Converting file";
            ConverterThread.Start();
            #endregion
        }

        private void ConversionFinished() {
            tmrTitleActivity.Stop();
            this.Text = this.Text.Trim('.');
            btnConverterCancelExit.Text = Language.GenericExit;

            if (CurrentConversion.BatchConversion) {
                switch (CurrentConversion.Status) {
                    case ConversionStatus.Aborted:
                        if (AbortBatch) {
                            this.DialogResult = DialogResult.Abort;
                        }
                        else {
                            this.DialogResult = DialogResult.Ignore;
                        }
                        break;
                    case ConversionStatus.FfmpegError:
                        this.Activate();
                        System.Media.SystemSounds.Hand.Play();
                        rtbConsoleOutput.AppendText("\nAn error occured\nTHIS IS A FFMPEG ERROR, NOT A ERROR WITH THIS PROGRAM!\nExit the form to resume batch download.");
                        this.Text = Language.frmConverterError;
                        break;
                    case ConversionStatus.ProgramError:
                        rtbConsoleOutput.AppendText("\nAn error occured\nAn error log was presented, if enabled.\nExit the form to resume batch download.");
                        this.Text = Language.frmConverterError;
                        this.Activate();
                        System.Media.SystemSounds.Hand.Play();
                        break;
                    case ConversionStatus.Finished:
                        this.DialogResult = DialogResult.Yes;
                        break;
                    default:
                        this.DialogResult = DialogResult.No;
                        break;
                }
            }
            else {
                switch (CurrentConversion.Status) {
                    case ConversionStatus.Aborted:
                        break;
                    case ConversionStatus.FfmpegError:
                        rtbConsoleOutput.AppendText("\nAn error occured\nTHIS IS A FFMPEG ERROR, NOT A ERROR WITH THIS PROGRAM!");
                        btnConverterAbortBatchConversions.Visible = true;
                        btnConverterAbortBatchConversions.Enabled = true;
                        btnConverterAbortBatchConversions.Text = Language.GenericRetry;
                        this.Text = Language.frmConverterError;
                        this.Activate();
                        System.Media.SystemSounds.Hand.Play();
                        break;
                    case ConversionStatus.ProgramError:
                        rtbConsoleOutput.AppendText("\nAn error occured\nAn error log was presented, if enabled.");
                        this.Text = Language.frmConverterError;
                        this.Activate();
                        System.Media.SystemSounds.Hand.Play();
                        break;
                    case ConversionStatus.Finished:
                        this.Text = Language.frmConverterComplete;
                        rtbConsoleOutput.AppendText("Conversion has finished.");
                        if (chkConverterCloseAfterConversion.Checked) { this.Close(); }
                        break;
                    default:
                        this.Text = Language.frmConverterComplete;
                        rtbConsoleOutput.AppendText("CurrentConversion.Status not defined (Not a batch download)\nAssuming success.");
                        if (chkConverterCloseAfterConversion.Checked) { this.Close(); }
                        break;
                }
            }
        }

        private void btnConverterCancelExit_Click(object sender, EventArgs e) {
            switch (CurrentConversion.Status) {
                case ConversionStatus.Finished:
                case ConversionStatus.FfmpegError:
                case ConversionStatus.Aborted:
                    this.Close();
                    break;
                default:
                    if (ConverterThread != null && ConverterThread.IsAlive) {
                        ConverterThread.Abort();
                    }
                    break;
            }
        }

        private void btnConverterAbortBatchConversions_Click(object sender, EventArgs e) {
            Abort();
        }

        private void btnClearOutput_Click(object sender, EventArgs e) {
            rtbConsoleOutput.Clear();
        }
    }
}
