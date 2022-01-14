using System;
using System.Net;
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
            this.Text = Program.lang.frmUpdater;
            lbUpdaterHeader.Text = Program.lang.lbUpdaterHeader;
            lbUpdaterDetails.Text = Program.lang.lbUpdaterDetails;
        }

        private void SetDownloadThread() {
            DownloadThread = new Thread(() => {
                // The URL that will be downloaded using the client
                string FileUrl = string.Format(ApplicationDownloadUrl, "youtube-dl-gui", Info.NewVersion);
                // The temp path of the file.
                string FileDestination = $"{Environment.CurrentDirectory}\\ytdlg.part";
                // If the download errored or not to delete the temp files or whatnot.
                bool DownloadError;

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
                    using murrty.classcontrols.ExtendedWebClient wc = new();
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

                        lock (e.UserState) {
                            Monitor.Pulse(e.UserState);
                        }
                    };

                    // GetRequest pre-reqs
                    wc.Headers.Add("user-agent", "youtube-dl-gui-updater/" + Properties.Settings.Default.CurrentVersion);
                    wc.Method = murrty.classcontrols.HttpMethod.GET;

                    // Download the file to the destination
                    // Lock's the object to... you know, I have no idea.
                    object SyncLock = new();
                    lock (SyncLock) {
                        // Why does it not give a WebException when it has no connection?
                        wc.DownloadFileAsync(new Uri(FileUrl), FileDestination, SyncLock);
                        Monitor.Wait(SyncLock);
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
                    });

                    return;
                }
                catch (WebException webEx) {
                    DownloadError = true;

                    this.Invoke((Action)delegate {
                        tmrForm.Stop();
                        this.Text = this.Text.Trim('.');
                        pbDownloadProgress.ProgressState = murrty.controls.ProgressBarState.Error;
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
                    if (DownloadError && System.IO.File.Exists(FileDestination)) {
                        System.IO.File.Delete(FileDestination);
                        this.Invoke((Action)delegate {
                            tmrForm.Stop();
                            this.Text = this.Text.Trim('.');
                            pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                            pbDownloadProgress.ProgressState = murrty.controls.ProgressBarState.Error;
                            pbDownloadProgress.Text = "Error downloading";
                        });
                    }
                    else {
                        // Sanity check the file, if it's less than or equal to 512 bytes.
                        // Who knows, this may be the real size :)
                        if (new System.IO.FileInfo(FileDestination).Length <= 512) {
                            System.IO.File.Delete(FileDestination);
                            this.Invoke((Action)delegate {
                                tmrForm.Stop();
                                this.Text = this.Text.Trim('.');
                                pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                                pbDownloadProgress.ProgressState = murrty.controls.ProgressBarState.Error;
                                pbDownloadProgress.Text = "Error: the download is too small";
                            });
                        }
                        else {
                            // We can assume it may be a complete program.
                            // Should we sanity check the hash?
                            // This point is the best time to do it.
                            this.Invoke((Action)delegate {
                                // We are going to assume it's properly downloaded.
                                tmrForm.Stop();
                                this.Text = this.Text.Trim('.');
                                pbDownloadProgress.Value += 25;

                                // We're saving the old version as a temp backup, at least until the program launches.
                                if (System.IO.File.Exists(Environment.CurrentDirectory + "\\" + Info.OldFileName)) {
                                    System.IO.File.Move(Environment.CurrentDirectory + "\\" + Info.OldFileName, Environment.CurrentDirectory + "\\youtube-dl-gui.old.exe");
                                }

                                // Move the new file to the old file.
                                System.IO.File.Move(Environment.CurrentDirectory + "\\ytdlg.part", Environment.CurrentDirectory + "\\" + Info.OldFileName);

                                // Set the progress bar.
                                pbDownloadProgress.Value = pbDownloadProgress.Maximum;
                                pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                                pbDownloadProgress.Text = "Download finished, launching...";
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
                        pbDownloadProgress.Text = "Error processing download";
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
