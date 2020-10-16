using System;
using System.ComponentModel;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui_updater {
    public partial class frmUpdater : Form {
        Language lang = Language.GetLangInstance();
        public static string ApplicationDownloadUrl = "https://github.com/murrty/{0}/releases/download/{1}/{0}.exe";
        public frmUpdater() {
            InitializeComponent();
            string DownloadVersion = null;
            string OldName = null;
            string FileUrl = null;
            lang.LoadLanguage();
            SetLanguage();
            string[] args = Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length; i++) {
                if (args[i].ToLower().StartsWith("-version") || args[i].ToLower().StartsWith("-v")) {
                    DownloadVersion = args[i+1];
                }
                else if (args[i].ToLower().StartsWith("-name") || args[i].ToLower().StartsWith("-n")) {
                    OldName = args[i+1];
                }
            }
            if (!OldName.EndsWith(".exe")) {
                OldName += ".exe";
            }

            FileUrl = string.Format(ApplicationDownloadUrl, "youtube-dl-gui", DownloadVersion);
        #if DEBUG
            return;
        #else
            Thread DownloadUpdateThread = new Thread(() => {
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
                catch (Exception ex) {
                    tmrForm.Stop();
                    this.Text = this.Text.Trim('.');
                    frmException Exception = new frmException();
                    Exception.reportedException = ex;
                    Exception.ShowDialog();
                    if (System.IO.File.Exists(Environment.CurrentDirectory + "\\ytdlg.part")) { System.IO.File.Delete(Environment.CurrentDirectory + "\\ytdlg.part"); }
                    System.IO.File.Move(Environment.CurrentDirectory + "\\youtube-dl-gui.old.exe", Environment.CurrentDirectory + "\\" + OldName);
                    this.BeginInvoke(new MethodInvoker(() => {
                        pbDownloadProgress.Value = 0;
                        pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                    }));
                }
            });
            DownloadUpdateThread.IsBackground = false;
            DownloadUpdateThread.Start();
        #endif
        }

        private void SetLanguage() {
            this.Text = lang.frmUpdater + Properties.Settings.Default.CurrentVersion + " ";
            lbUpdaterHeader.Text = lang.lbUpdaterHeader;
            lbUpdaterDescription.Text = lang.lbUpdaterDescription;
        }

        private void tmrForm_Tick(object sender, EventArgs e) {
            if(this.Text.EndsWith("....")) {
                this.Text = this.Text.Trim('.');
            }
            else {
                this.Text += ".";
            }
        }

        public bool DownloadWithProgress(string url, string destination) {
            try {
                using (WebClient wc = new WebClient()) {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    wc.Headers.Add("User-Agent: youtube-dl-gui-updater/1.0");
                    wc.DownloadProgressChanged += DownloadProgress;
                    wc.DownloadFileCompleted += FinishedDownload;

                    var sync = new Object();
                    lock (sync) {
                        this.BeginInvoke(new MethodInvoker(() => {
                            pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                        }));
                        wc.DownloadFileAsync(new Uri(url), destination, sync);
                        Monitor.Wait(sync);
                    }
                }

                return true;
            }
            catch (Exception ex) {
                throw new Exception("Attempted URL: " + url + "\nAttempted destination: " + destination + "\n" + ex.ToString());
            }
        }
        public void FinishedDownload(object sender, AsyncCompletedEventArgs e) {
            lock (e.UserState) {
                Monitor.Pulse(e.UserState);

                this.BeginInvoke(new MethodInvoker(() => {
                    pbDownloadProgress.Style = ProgressBarStyle.Continuous;
                }));
            }
        }
        public void DownloadProgress(object sender, DownloadProgressChangedEventArgs e) {
            this.BeginInvoke(new MethodInvoker(() => {
                pbDownloadProgress.Value = e.ProgressPercentage;
            }));
        }
    }
}
