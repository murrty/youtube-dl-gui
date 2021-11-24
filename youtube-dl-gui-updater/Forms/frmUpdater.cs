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
RetryDownload:
                try {
                    string FileUrl = string.Format(ApplicationDownloadUrl, "youtube-dl-gui", Info.NewVersion);
                    if (DownloadWithProgress(FileUrl, Environment.CurrentDirectory + "\\ytdlg.part")) {
                        this.Invoke((Action)delegate {
                            tmrForm.Stop();
                            this.Text = this.Text.Trim('.');
                            pbDownloadProgress.Style = ProgressBarStyle.Continuous;

                            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\" + Info.OldFileName)) {
                                System.IO.File.Move(Environment.CurrentDirectory + "\\" + Info.OldFileName, Environment.CurrentDirectory + "\\youtube-dl-gui.old.exe");
                            }
                            System.IO.File.Move(Environment.CurrentDirectory + "\\ytdlg.part", Environment.CurrentDirectory + "\\" + Info.OldFileName);
                            pbDownloadProgress.Value = 100;
                            pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                        });

                        System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\" + Info.OldFileName);
                        Environment.Exit(0);
                    }
                    else {
                        this.Invoke((Action)delegate {
                            tmrForm.Stop();
                            this.Text = this.Text.Trim('.');
                            pbDownloadProgress.Value = 0;
                            pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                        });

                        if (System.IO.File.Exists(Environment.CurrentDirectory + "\\ytdlg.part")) { System.IO.File.Delete(Environment.CurrentDirectory + "\\ytdlg.part"); }
                    }
                }
                catch (ThreadAbortException) {
                    this.Invoke((Action)delegate {
                        tmrForm.Stop();
                        this.Text = this.Text.Trim('.');
                    });
                }
                catch (Exception ex) {
                    this.Invoke((Action)delegate {
                        tmrForm.Stop();
                        this.Text = this.Text.Trim('.');
                    });

                    if (System.IO.File.Exists(Environment.CurrentDirectory + "\\ytdlg.part")) { System.IO.File.Delete(Environment.CurrentDirectory + "\\ytdlg.part"); }

                    frmException Exception = new frmException {
                        ReportedException = ex,
                        AllowRetry = true
                    };
                    switch (Exception.ShowDialog()) {
                        case DialogResult.Retry:
                            this.Invoke((Action)delegate {
                                tmrForm.Start();
                            });
                            goto RetryDownload;

                        default:
                            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\youtube-dl-gui.old.exe")) {
                                System.IO.File.Move(Environment.CurrentDirectory + "\\youtube-dl-gui.old.exe", Environment.CurrentDirectory + "\\" + Info.OldFileName);
                            }
                            this.Invoke((Action)delegate {
                                pbDownloadProgress.Value = 0;
                                pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                            });
                            break;
                    }
                }
            }) {
                Name = "Download thread",
                IsBackground = false
            };
        }

        private void tmrForm_Tick(object sender, EventArgs e) {
            if(this.Text.EndsWith("....")) {
                this.Text = this.Text.Trim('.');
            }
            else {
                this.Text += ".";
            }
        }

        private bool DownloadWithProgress(string url, string destination) {
            try {
                using (WebClient wc = new WebClient()) {
                    wc.Headers.Add("User-Agent: youtube-dl-gui-updater/" + Properties.Settings.Default.CurrentVersion);
                    wc.DownloadProgressChanged += (s, e) => {
                        ThrottleCount++;
                        switch (ThrottleCount % 25) {
                            case 0:
                                this.Invoke((Action)delegate {
                                    pbDownloadProgress.Value = e.ProgressPercentage;
                                });
                                ThrottleCount = 0;
                                break;
                        }
                    };
                    wc.DownloadFileCompleted += (s, e) => {
                        lock (e.UserState) {
                            Monitor.Pulse(e.UserState);

                            this.Invoke((Action)delegate {
                                pbDownloadProgress.Style = ProgressBarStyle.Continuous;
                            });
                        }
                    };

                    this.Invoke((Action)delegate {
                        pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                    });

                    Object SyncLock = new Object();
                    lock (SyncLock) {
                        wc.DownloadFileAsync(new Uri(url), destination, SyncLock);
                        Monitor.Wait(SyncLock);
                    }
                }

                return true;
            }
            catch (Exception ex) {
                throw new Exception("Attempted URL: " + url + "\nAttempted destination: " + destination + "\n" + ex.ToString());
            }
        }

        private void frmUpdater_Shown(object sender, EventArgs e) {
            DownloadThread.Start();
        }
    }
}
