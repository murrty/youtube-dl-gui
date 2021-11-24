using System;
using System.ComponentModel;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui_updater {
    public partial class frmUpdater : Form {

        public static string ApplicationDownloadUrl = "https://github.com/murrty/{0}/releases/download/{1}/{0}.exe";
        private Thread DownloadThread;

        private int ThrottleCount = 0;

        private readonly string DownloadVersion;
        private readonly string OldName;
        private string FileUrl;

        public frmUpdater() {
            InitializeComponent();
            SetLanguage();

            string[] args = Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length; i++) {
                switch (args[i].ToLower()) {
                    case "-version": case "-v":
                        if (string.IsNullOrWhiteSpace(DownloadVersion)) {
                            DownloadVersion = args[i + 1];
                        }
                        break;

                    case "-name": case "-n":
                        if (string.IsNullOrWhiteSpace(OldName)) {
                            OldName = args[i + 1];
                        }
                        break;
                }
            }
            if (string.IsNullOrWhiteSpace(OldName)) {
                OldName = "youtube-dl-gui.exe";
            }
            else {
                if (!string.IsNullOrWhiteSpace(OldName) && !OldName.EndsWith(".exe")) {
                    OldName += ".exe";
                }
            }
        }

        private void SetLanguage() {
            this.Text = Program.lang.frmUpdater;
            lbUpdaterHeader.Text = Program.lang.lbUpdaterHeader;
            lbUpdaterDescription.Text = Program.lang.lbUpdaterDescription;
        }
        private void SetDownloadThread() {
            FileUrl = string.Format(ApplicationDownloadUrl, "youtube-dl-gui", DownloadVersion);
            DownloadThread = new Thread(() => {
RetryDownload:
                try {
                    if (DownloadWithProgress(FileUrl, Environment.CurrentDirectory + "\\ytdlg.part")) {
                        this.BeginInvoke(new MethodInvoker(() => {
                            tmrForm.Stop();
                            this.Text = this.Text.Trim('.');
                            pbDownloadProgress.Style = ProgressBarStyle.Continuous;

                            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\" + OldName)) {
                                System.IO.File.Move(Environment.CurrentDirectory + "\\" + OldName, Environment.CurrentDirectory + "\\youtube-dl-gui.old.exe");
                            }
                            System.IO.File.Move(Environment.CurrentDirectory + "\\ytdlg.part", Environment.CurrentDirectory + "\\" + OldName);
                            pbDownloadProgress.Value = 100;
                            pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                        }));

                        System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\" + OldName);
                        Environment.Exit(0);
                    }
                    else {
                        this.BeginInvoke(new MethodInvoker(() => {
                            tmrForm.Stop();
                            this.Text = this.Text.Trim('.');
                            pbDownloadProgress.Value = 0;
                            pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                        }));

                        if (System.IO.File.Exists(Environment.CurrentDirectory + "\\ytdlg.part")) { System.IO.File.Delete(Environment.CurrentDirectory + "\\ytdlg.part"); }
                        System.IO.File.Move(Environment.CurrentDirectory + "\\youtube-dl-gui.old.exe", Environment.CurrentDirectory + "\\" + OldName);
                    }
                }
                catch (ThreadAbortException) {

                }
                catch (Exception ex) {
                    tmrForm.Stop();
                    this.Text = this.Text.Trim('.');

                    if (System.IO.File.Exists(Environment.CurrentDirectory + "\\ytdlg.part")) { System.IO.File.Delete(Environment.CurrentDirectory + "\\ytdlg.part"); }

                    frmException Exception = new frmException {
                        ReportedException = ex,
                        AllowRetry = true
                    };
                    switch (Exception.ShowDialog()) {
                        case DialogResult.Retry:
                            goto RetryDownload;

                        default:
                            System.IO.File.Move(Environment.CurrentDirectory + "\\youtube-dl-gui.old.exe", Environment.CurrentDirectory + "\\" + OldName);
                            this.BeginInvoke(new MethodInvoker(() => {
                                pbDownloadProgress.Value = 0;
                                pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                            }));
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
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    wc.Headers.Add("User-Agent: youtube-dl-gui-updater/1.0");
                    wc.DownloadProgressChanged += DownloadProgress;
                    wc.DownloadFileCompleted += FinishedDownload;

                    Object SyncLock = new Object();
                    lock (SyncLock) {
                        this.BeginInvoke(new MethodInvoker(() => {
                            pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                        }));
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
        private void FinishedDownload(object sender, AsyncCompletedEventArgs e) {
            lock (e.UserState) {
                Monitor.Pulse(e.UserState);

                this.BeginInvoke(new MethodInvoker(() => {
                    pbDownloadProgress.Style = ProgressBarStyle.Continuous;
                }));
            }
        }
        private void DownloadProgress(object sender, DownloadProgressChangedEventArgs e) {
            ThrottleCount++;
            switch (ThrottleCount % 25) {
                case 0:
                    this.Invoke((Action) delegate {
                        pbDownloadProgress.Value = e.ProgressPercentage;
                    });
                    break;
            }
        }

        private void frmUpdater_Shown(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(DownloadVersion)) {
                MessageBox.Show("No version was specified. If you are running this yourself, pass \"-version {version}\" as a parameter.\r\n\r\nThis will be rectified in the future.");

                tmrForm.Stop();
                this.Text.Trim('.');
                pbDownloadProgress.Style = ProgressBarStyle.Blocks;
            }
            else {
                SetDownloadThread();
                DownloadThread.Start();
            }
        }
    }
}
