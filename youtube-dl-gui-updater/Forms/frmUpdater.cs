using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui_updater {
    public partial class frmUpdater : Form {

        public static string ApplicationDownloadUrl = "https://github.com/murrty/{0}/releases/download/{1}/{0}.exe";
        private readonly UpdateInfo Info;
        private Thread DownloadThread;

        private int ThrottleCount = 0;

        public frmUpdater(UpdateInfo NewInfo) {
            InitializeComponent();
            Info = NewInfo;
            SetLanguage();
            SetDownloadThread();
        }

        private void SetLanguage() {
            this.Text = Language.frmUpdater;
            lbUpdaterHeader.Text = Language.lbUpdaterHeader;
            lbUpdaterDetails.Text = Language.lbUpdaterDetails;
            pbDownloadProgress.Text = Language.pbDownloadProgressPreparing;
        }

        private void SetDownloadThread() {
            DownloadThread = new Thread(async () => {
                // The URL that will be downloaded using the client
                string FileUrl = string.Format(ApplicationDownloadUrl, "youtube-dl-gui", Info.NewVersion);
                // The temp path of the file.
                string FileDestination = $"{Environment.CurrentDirectory}\\ytdlg.part";
                // If the download errored or not to delete the temp files or whatnot.
                bool DownloadError;
                using murrty.classcontrols.ExtendedWebClient wc = new();

                #region Download try block

RetryDownload:
                DownloadError = false;
                try {

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
                            pbDownloadProgress.Style = ProgressBarStyle.Continuous;
                            pbDownloadProgress.Text = "100%";
                        });
                    };

                    // GetRequest pre-reqs
                    wc.Headers.Add("user-agent", "youtube-dl-gui-updater/" + Program.UpdaterVersion);
                    wc.Method = murrty.classcontrols.HttpMethod.GET;

                    // Download the file to the destination
                    await wc.DownloadFileTaskAsync(new Uri(FileUrl), FileDestination);

                    if (Info.UpdateHash != null) {
                        this.Invoke((Action)delegate {
                            pbDownloadProgress.Text = Language.pbDownloadProgressCalculatingHash;
                        });

                        using SHA256 ComputeUpdateHash = SHA256Cng.Create();
                        using FileStream UpdateStream = File.OpenRead($"{Environment.CurrentDirectory}\\ytdlg.part");
                        string UpdateHash = BitConverter.ToString(ComputeUpdateHash.ComputeHash(UpdateStream)).Replace("-", "").ToLower();
                        UpdateStream.Close();

                        if (Info.UpdateHash != UpdateHash) {
                            this.Invoke((Action)delegate {
                                pbDownloadProgress.Text = Language.pbDownloadProgressHashNoMatch;
                                pbDownloadProgress.ProgressState = murrty.controls.ProgressBarState.Paused;
                            });
                            // The hash calculated by the updater does not match the known hash of the update.\r\n\r\nExpected: {Info.UpdateHash}\r\n\r\nCalculated: {UpdateHash}\r\n\r\nYou can continue without it matching, there are some instances where it may be different.
                            switch (MessageBox.Show(string.Format(Language.dlgUpdaterUpdatedVersionHashNoMatch, Info.UpdateHash, UpdateHash), "youtube-dl-gui-updater", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning)) {
                                case DialogResult.Abort: {
                                } throw new CryptographicException("The known hash of the file does not match the hash caluclated by the updater.");

                                case DialogResult.Retry: {
                                    File.Delete(Environment.CurrentDirectory + "\\ytdlg.part");
                                    this.Invoke((Action)delegate {
                                        tmrForm.Start();
                                        pbDownloadProgress.Value = 50;
                                        pbDownloadProgress.ProgressState = murrty.controls.ProgressBarState.Normal;
                                    });
                                } goto RetryDownload;

                                case DialogResult.Ignore: {
                                    this.Invoke((Action)delegate {
                                        pbDownloadProgress.ProgressState = murrty.controls.ProgressBarState.Normal;
                                    });
                                } break;
                            }
                        }
                    }
                    else {
                        this.Invoke((Action)delegate {
                            pbDownloadProgress.Text = Language.pbDownloadProgressSkippingHashCalculating;
                        });

                        MessageBox.Show(Language.dlgUpdaterHashNotGiven, "youtube-dl-gui-updater", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                #endregion

                #region Download catch blocks (retry-enabled)

                catch (ThreadAbortException) {
                    DownloadError = true;

                    this.Invoke((Action)delegate {
                        tmrForm.Stop();
                        this.Text = this.Text.Trim('.');
                        pbDownloadProgress.ProgressState = murrty.controls.ProgressBarState.Error;
                        pbDownloadProgress.Text = Language.pbDownloadProgressCancelled;
                    });

                    return;
                }
                catch (WebException webEx) {
                    DownloadError = true;

                    this.Invoke((Action)delegate {
                        tmrForm.Stop();
                        this.Text = this.Text.Trim('.');
                        pbDownloadProgress.ProgressState = murrty.controls.ProgressBarState.Error;
                        pbDownloadProgress.Text = Language.pbDownloadProgressWebException;
                    });

                    using murrty.frmException NewException = new(new(webEx) {
                        ExtraInfo = FileUrl,
                        AllowRetry = true
                    });

                    switch (NewException.ShowDialog()) {
                        case DialogResult.Retry: {
                            this.Invoke((Action)delegate {
                                tmrForm.Start();
                                pbDownloadProgress.Value = 50;
                                pbDownloadProgress.ProgressState = murrty.controls.ProgressBarState.Normal;
                            });
                        } goto RetryDownload;
                    }
                }
                catch (Exception ex) {
                    DownloadError = true;

                    this.Invoke((Action)delegate {
                        tmrForm.Stop();
                        this.Text = this.Text.Trim('.');
                        pbDownloadProgress.ProgressState = murrty.controls.ProgressBarState.Error;
                        pbDownloadProgress.Text = Language.pbDownloadProgressDownloadException;
                    });

                    using murrty.frmException NewException = new(new(ex) {
                        AllowRetry = true
                    });

                    switch (NewException.ShowDialog()) {
                        case DialogResult.Retry: {
                            this.Invoke((Action)delegate {
                                tmrForm.Start();
                                pbDownloadProgress.Value = 50;
                                pbDownloadProgress.ProgressState = murrty.controls.ProgressBarState.Normal;
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
                            pbDownloadProgress.ProgressState = murrty.controls.ProgressBarState.Error;
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
                                pbDownloadProgress.ProgressState = murrty.controls.ProgressBarState.Error;
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
                            string ExistingFileName = $"{Environment.CurrentDirectory}\\{Info.OldFileName}";
                            if (File.Exists(ExistingFileName)) {
                                if (File.Exists($"{Environment.CurrentDirectory}\\youtube-dl-gui.old.exe")) {
                                    File.Delete($"{Environment.CurrentDirectory}\\youtube-dl-gui.old.exe");
                                    //Thread.Sleep(100);
                                }
                                File.Move(ExistingFileName, $"{Environment.CurrentDirectory}\\youtube-dl-gui.old.exe");
                            }
                            // Move the new file to the old file.
                            File.Move(Environment.CurrentDirectory + "\\ytdlg.part", Environment.CurrentDirectory + "\\" + Info.OldFileName);


                            this.Invoke((Action)delegate {
                                // Set the progress bar.
                                pbDownloadProgress.Value = pbDownloadProgress.Maximum;
                                pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                                pbDownloadProgress.Text = Language.pbDownloadProgressDownloadFinishedLaunching;
                            });

                            // Run the updated program.
                            // Debug keeps the updater.
                            System.Diagnostics.Process UpdatedProgram = new() {
                                StartInfo = new() {
                                    Arguments = $"{(Program.IsDebug ? "-keepupdater" : "")}",
                                    FileName = $"{Environment.CurrentDirectory}\\{Info.OldFileName}"
                                }
                            };
                            UpdatedProgram.Start();
                            Environment.Exit(0);
                        }
                    }
                }

                #endregion

                #region Replace old version catch block

                catch (Exception ex) {
                    this.Invoke((Action)delegate {
                        tmrForm.Stop();
                        this.Text = this.Text.Trim('.');
                        pbDownloadProgress.ProgressState = murrty.controls.ProgressBarState.Error;
                        pbDownloadProgress.Text = Language.pbDownloadProgressErrorProcessingDownload;
                    });
                    using murrty.frmException NewException = new(new(ex));
                    NewException.ShowDialog();
                }

                #endregion

            }) {
                Name = "Download thread",
                IsBackground = false
            };
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
            pbDownloadProgress.Value = 50;
            DownloadThread.Start();
        }
    }
}
