namespace youtube_dl_gui_updater;

using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;

public partial class frmUpdater : Form, IUpdateForm {
    private const string ApplicationDownloadUrl = "https://github.com/murrty/{0}/releases/download/{1}/{0}.exe";
    private readonly MessageHandler Messages;

    private Thread DownloadThread;
    private System.Diagnostics.Process ProgramProcess;
    private int ThrottleCount = 0;

    public frmUpdater() {
        InitializeComponent();
        lbUpdaterVersion.Text = Program.CurrentVersion;
        pbDownloadProgress.Style = ProgressBarStyle.Marquee;
        LoadLanguage();
        SetDownloadThread();
        if (!Program.UpdateData.FileName.ToLower().EndsWith(".exe"))
            Program.UpdateData.FileName += ".exe";
        Messages = new();
    }

    private void LoadLanguage() {
        this.Text = Language.frmUpdater;
        lbUpdaterHeader.Text = Language.lbUpdaterHeader;
        lbUpdaterDetails.Text = Language.lbUpdaterDetails;
        pbDownloadProgress.Text = Language.pbDownloadProgressPreparing;
    }

    private void SetDownloadThread() {
        DownloadThread = new Thread(async () => {

            if (ProgramProcess is not null) {
                pbDownloadProgress.Invoke(() => pbDownloadProgress.Text = Language.pbDownloadProgressWaitingForClose);
                CopyData.SendMessage((nint)Program.ProgramData.hWnd, CopyData.WM_UPDATERREADY, 0, 0);
                while (!ProgramProcess.HasExited) {
                    Thread.Sleep(150);
                }
            }

            pbDownloadProgress.Invoke(() => {
                pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                pbDownloadProgress.Value = 50;
            });

            // The URL that will be downloaded using the client
            string FileUrl = string.Format(ApplicationDownloadUrl, Program.RepositoryName, Program.UpdateData.NewVersion);
            // The temp path of the file.
            string FileDestination = $"{Environment.CurrentDirectory}\\update.part";
            // If the download errored or not to delete the temp files or whatnot.
            bool DownloadError;
            using murrty.classcontrols.ExtendedWebClient wc = new();

            #region Download try block

RetryDownload:
            DownloadError = false;
            try {

                if (File.Exists(FileDestination)) {
                    File.Delete(FileDestination);
                }

                // Set the style to blocks so progress can be reported.
                this.Invoke((Action)delegate {
                    pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                    pbDownloadProgress.Text = "0%";
                });

                // WebClient declaration
                wc.DownloadProgressChanged += (s, e) => {
                    // We throttle the progress changed event to prevent overloading.
                    // Maybe 25 is too low, but.
                    ThrottleCount++;
                    switch (ThrottleCount % 25) {
                        case 0: {
                            this.Invoke((Action)delegate {
                                pbDownloadProgress.Value = e.ProgressPercentage + 50;
                                pbDownloadProgress.Text = $"{e.ProgressPercentage}%";
                            });
                            ThrottleCount = 0;
                        } break;
                    }
                };

                wc.DownloadFileCompleted += (s, e) => {
                    this.Invoke((Action)delegate {
                        pbDownloadProgress.Text = "100%";
                    });
                };

                // GetRequest pre-reqs
                wc.UserAgent = Program.UserAgent;
                wc.Method = murrty.classcontrols.HttpMethod.GET;

                // Download the file to the destination
                await wc.DownloadFileTaskAsync(new Uri(FileUrl), FileDestination);

                if (Program.UpdateData.UpdateHash != null) {
                    this.Invoke((Action)delegate {
                        pbDownloadProgress.Text = Language.pbDownloadProgressCalculatingHash;
                    });

                    using SHA256 ComputeUpdateHash = SHA256.Create();
                    using FileStream UpdateStream = File.OpenRead(FileDestination);
                    string UpdateHash = BitConverter.ToString(ComputeUpdateHash.ComputeHash(UpdateStream)).Replace("-", "").ToLowerInvariant();
                    UpdateStream.Close();

                    if (Program.UpdateData.UpdateHash != UpdateHash) {
                        this.Invoke((Action)delegate {
                            pbDownloadProgress.Text = Language.pbDownloadProgressHashNoMatch;
                            pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Paused;
                        });
                        switch ((DialogResult)this.Invoke(() => MessageBox.Show(this, string.Format(Language.dlgUpdaterUpdatedVersionHashNoMatch, Program.UpdateData.UpdateHash, UpdateHash), $"{Program.RepositoryName}-updater", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning))) {
                            case DialogResult.Abort: {
                            } throw new CryptographicException("The known hash of the file does not match the hash caluclated by the updater.");

                            case DialogResult.Retry: {
                                File.Delete(FileDestination);
                                this.Invoke((Action)delegate {
                                    tmrForm.Start();
                                    pbDownloadProgress.Value = 50;
                                    pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Normal;
                                });
                            } goto RetryDownload;

                            case DialogResult.Ignore: {
                                this.Invoke((Action)delegate {
                                    pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Normal;
                                });
                            } break;
                        }
                    }
                }
                else {
                    this.Invoke((Action)delegate {
                        pbDownloadProgress.Text = Language.pbDownloadProgressSkippingHashCalculating;
                    });

                    this.Invoke(() => MessageBox.Show(this,
                        Language.dlgUpdaterHashNotGiven,
                        $"{Program.RepositoryName}-updater",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning));
                }
            }

            #endregion

            #region Download catch blocks (retry-enabled)

            catch (ThreadAbortException) {
                DownloadError = true;

                this.Invoke((Action)delegate {
                    tmrForm.Stop();
                    this.Text = this.Text.Trim('.');
                    pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Error;
                    pbDownloadProgress.Text = Language.pbDownloadProgressCancelled;
                });

                return;
            }
            catch (WebException webEx) {
                DownloadError = true;

                this.Invoke((Action)delegate {
                    tmrForm.Stop();
                    this.Text = this.Text.Trim('.');
                    pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Error;
                    pbDownloadProgress.Text = Language.pbDownloadProgressWebException;
                });

                switch (Log.ReportRetriableException(webEx, FileUrl)) {
                    case DialogResult.Retry: {
                        this.Invoke((Action)delegate {
                            tmrForm.Start();
                            pbDownloadProgress.Value = 50;
                            pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Normal;
                        });
                    } goto RetryDownload;
                }
            }
            catch (Exception ex) {
                DownloadError = true;

                this.Invoke((Action)delegate {
                    tmrForm.Stop();
                    this.Text = this.Text.Trim('.');
                    pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Error;
                    pbDownloadProgress.Text = Language.pbDownloadProgressDownloadException;
                });

                switch (Log.ReportRetriableException(ex)) {
                    case DialogResult.Retry: {
                        this.Invoke((Action)delegate {
                            tmrForm.Start();
                            pbDownloadProgress.Value = 50;
                            pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Normal;
                        });
                    } goto RetryDownload;
                }
            }

            #endregion

            #region Replace old version try block

            try {
                // If a download error occurred, we need to delete the temp file.
                if (DownloadError && File.Exists(FileDestination)) {
                    File.Delete(FileDestination);
                    this.Invoke((Action)delegate {
                        tmrForm.Stop();
                        this.Text = this.Text.Trim('.');
                        pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                        pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Error;
                        pbDownloadProgress.Text = Language.pbDownloadProgressErrorDownloading;
                    });
                }
                else {
                    // Sanity check the file, if it's less than or equal to 512 bytes.
                    // Who knows, this may be the real size :)
                    if (new FileInfo(FileDestination).Length <= 512) {
                        File.Delete(FileDestination);
                        this.Invoke((Action)delegate {
                            tmrForm.Stop();
                            this.Text = this.Text.Trim('.');
                            pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                            pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Error;
                            pbDownloadProgress.Text = Language.pbDownloadProgressDownloadTooSmall;
                        });
                    }
                    else {
                        this.Invoke((Action)delegate {
                            // We are going to assume it's properly downloaded.
                            tmrForm.Stop();
                            this.Text = this.Text.Trim('.');
                            pbDownloadProgress.Value += 25;
                        });


                        // We're saving the old version as a temp backup, at least until the program launches.
                        string ExistingFileName = $"{Environment.CurrentDirectory}\\{Program.UpdateData.FileName}";
                        string ExistingNewFileName = $"{Environment.CurrentDirectory}\\{Path.GetFileNameWithoutExtension(Program.UpdateData.FileName)}.old.exe";
                        if (File.Exists(ExistingFileName)) {
                            if (File.Exists(ExistingNewFileName)) {
                                File.Delete(ExistingNewFileName);
                                //Thread.Sleep(100);
                            }
                            File.Move(ExistingFileName, ExistingNewFileName);
                        }
                        // Move the new file to the old file.
                        File.Move(FileDestination, ExistingFileName);


                        this.Invoke((Action)delegate {
                            // Set the progress bar.
                            pbDownloadProgress.Value = pbDownloadProgress.Maximum;
                            pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                            pbDownloadProgress.Text = Language.pbDownloadProgressDownloadFinishedLaunching;
                        });

                        // Run the updated program.
                        // Debug keeps the updater.
                        if (!Program.DebugMode) {
                            System.Diagnostics.Process UpdatedProgram = new() {
                                StartInfo = new() {
                                    FileName = ExistingFileName,
                                    WorkingDirectory = Environment.CurrentDirectory
                                }
                            };

                            UpdatedProgram.Start();
                            Environment.Exit(0);
                        }
                    }
                }
            }

            #endregion

            #region Replace old version catch block

            catch (Exception ex) {
                this.Invoke((Action)delegate {
                    tmrForm.Stop();
                    this.Text = this.Text.Trim('.');
                    pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Error;
                    pbDownloadProgress.Text = Language.pbDownloadProgressErrorProcessingDownload;
                });
                Log.ReportRetriableLanguageException(ex);
            }

            #endregion

        }) {
            Name = "Download thread",
            IsBackground = false
        };
    }

    public void StartUpdate() {
        DownloadThread.Start();
    }

    private void tmrForm_Tick(object sender, EventArgs e) {
        // This really is just for appearance.
        if (this.Text.EndsWith("....")) {
            this.Text = this.Text.Trim('.');
        }
        else {
            this.Text += ".";
        }
    }

    private void frmUpdater_Shown(object sender, EventArgs e) {
        if (Program.ProgramData.ProgramSet) {
            pbDownloadProgress.Text = Language.pbDownloadProgressWaitingForData;
            ProgramProcess = System.Diagnostics.Process.GetProcessById((int)Program.ProgramData.pid);
            CopyData.SendMessage((nint)Program.ProgramData.hWnd, CopyData.WM_UPDATEDATAREQUEST, Messages.Handle, 0);
        }
        else if (Program.GotLatestUpdate) {
            StartUpdate();
        }
    }
}