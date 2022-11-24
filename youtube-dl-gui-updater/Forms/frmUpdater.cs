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
            // We are gonna gather the update data from the running process.
            if (ProgramProcess is not null) {
                pbDownloadProgress.Invoke(() => pbDownloadProgress.Text = Language.pbDownloadProgressWaitingForClose);
                // WM_UPDATEREADY is a non-standard message that tells youtube-dl-gui to send the updater is ready and that it should close.
                // The updater is going to wait for the main program to exit, allowing the user to finish any in-progress downloads.
                CopyData.SendMessage((nint)Program.ProgramData.hWnd, CopyData.WM_UPDATERREADY, 0, 0);
                while (!ProgramProcess.HasExited) {
                    Thread.Sleep(150);
                }
            }

            // The progress bar has a max of 200. Half of it is used for the download progress.
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
                // Delete the previous download part file, if it exists.
                if (File.Exists(FileDestination))
                    File.Delete(FileDestination);

                // Set the style to blocks so progress can be reported.
                pbDownloadProgress.Invoke(() => {
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
                            pbDownloadProgress.Invoke(() => {
                                pbDownloadProgress.Value = e.ProgressPercentage + 50;
                                pbDownloadProgress.Text = $"{e.ProgressPercentage}%";
                            });
                            ThrottleCount = 0;
                        } break;
                    }
                };

                wc.DownloadFileCompleted += (s, e) => {
                    pbDownloadProgress.Invoke(() => pbDownloadProgress.Text = "100%");
                };

                // GetRequest pre-reqs
                wc.UserAgent = Program.UserAgent;
                wc.Method = murrty.classcontrols.HttpMethod.GET;

                // Download the file to the destination
                await wc.DownloadFileTaskAsync(new Uri(FileUrl), FileDestination);

                // The new versions hash has been given, so we should check it.
                if (Program.UpdateData.UpdateHash != null) {
                    pbDownloadProgress.Invoke(() => pbDownloadProgress.Text = Language.pbDownloadProgressCalculatingHash);

                    using SHA256 ComputeUpdateHash = SHA256.Create();
                    using FileStream UpdateStream = File.OpenRead(FileDestination);
                    string UpdateHash = BitConverter.ToString(ComputeUpdateHash.ComputeHash(UpdateStream)).Replace("-", "").ToLowerInvariant();
                    UpdateStream.Close();

                    if (Program.UpdateData.UpdateHash != UpdateHash) {
                        pbDownloadProgress.Invoke(() => {
                            pbDownloadProgress.Text = Language.pbDownloadProgressHashNoMatch;
                            pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Paused;
                        });

                        switch ((DialogResult)this.Invoke(() => MessageBox.Show(this, string.Format(Language.dlgUpdaterUpdatedVersionHashNoMatch, Program.UpdateData.UpdateHash, UpdateHash), $"{Program.RepositoryName}-updater", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning))) {
                            case DialogResult.Abort: {
                            } throw new CryptographicException("The known hash of the file does not match the hash caluclated by the updater.");

                            case DialogResult.Retry: {
                                File.Delete(FileDestination);
                                this.Invoke(() => {
                                    tmrForm.Start();
                                    pbDownloadProgress.Value = 50;
                                    pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Normal;
                                });
                            } goto RetryDownload;

                            case DialogResult.Ignore: {
                                pbDownloadProgress.Invoke(() => pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Normal);
                            } break;
                        }
                    }
                }

                // No hash was given, so give a warning about it.
                else {
                    pbDownloadProgress.Invoke(() => pbDownloadProgress.Text = Language.pbDownloadProgressSkippingHashCalculating);

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

                this.Invoke(() => {
                    tmrForm.Stop();
                    this.Text = this.Text.Trim('.');
                    pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Error;
                    pbDownloadProgress.Text = Language.pbDownloadProgressCancelled;
                });

                return;
            }
            catch (WebException webEx) {
                DownloadError = true;

                this.Invoke(() => {
                    tmrForm.Stop();
                    this.Text = this.Text.Trim('.');
                    pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Error;
                    pbDownloadProgress.Text = Language.pbDownloadProgressWebException;
                });

                switch (Log.ReportRetriableException(webEx, FileUrl)) {
                    case DialogResult.Retry: {
                        this.Invoke(() => {
                            tmrForm.Start();
                            pbDownloadProgress.Value = 50;
                            pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Normal;
                        });
                    } goto RetryDownload;
                }
            }
            catch (Exception ex) {
                DownloadError = true;

                this.Invoke(() => {
                    tmrForm.Stop();
                    this.Text = this.Text.Trim('.');
                    pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Error;
                    pbDownloadProgress.Text = Language.pbDownloadProgressDownloadException;
                });

                switch (Log.ReportRetriableException(ex)) {
                    case DialogResult.Retry: {
                        this.Invoke(() => {
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
                    this.Invoke(() => {
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
                        this.Invoke(() => {
                            tmrForm.Stop();
                            this.Text = this.Text.Trim('.');
                            pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                            pbDownloadProgress.ProgressState = murrty.controls.ProgressState.Error;
                            pbDownloadProgress.Text = Language.pbDownloadProgressDownloadTooSmall;
                        });
                    }
                    else {
                        this.Invoke(() => {
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
                this.Invoke(() => {
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
        this.Text = this.Text.EndsWith("...") ? this.Text.Trim('.') : this.Text + ".";
    }

    private void frmUpdater_Shown(object sender, EventArgs e) {
        // Checks if the host program (youtube-dl-gui) gave data for updating.
        if (Program.ProgramData.ProgramSet) {
            pbDownloadProgress.Text = Language.pbDownloadProgressWaitingForData;
            // Gets the parent process, because we got the required process info sent through the arguments.
            ProgramProcess = System.Diagnostics.Process.GetProcessById((int)Program.ProgramData.pid);
            // WM_UPDATEDATAREQUEST is a non-standard window message that tells youtube-dl-gui to build information for the update,
            // which is the update tag, the file name to save the update as, and the hash of the new version.
            CopyData.SendMessage((nint)Program.ProgramData.hWnd, CopyData.WM_UPDATEDATAREQUEST, Messages.Handle, 0);
        }

        // Otherwise, we need to check if the program has a version to download through the user.
        else if (Program.GotLatestUpdate) {
            StartUpdate();
        }

        else {
            // In theory: the user shouldn't ever reach a state where either of those don't happen.
            // But, just in case...
            throw new ApplicationException("The updater does not have a known update method.");
        }
    }
}