using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmAbout : Form {
        Thread UpdateCheckThread;

        public frmAbout() {
            InitializeComponent();
            pbIcon.Image = Properties.Resources.youtube_dl_gui32;
            LoadLanguage();
            if (Properties.Settings.Default.IsBetaVersion) {
                lbVersion.Text = "v" + Properties.Settings.Default.BetaVersion;
            }
            else {
                lbVersion.Text = "v" + Properties.Settings.Default.CurrentVersion.ToString();
            }
        }

        private void LoadLanguage() {
            lbAboutBody.Text = string.Format(Program.lang.lbAboutBody + "\n\nlikulau best boye.", "ytdl-org", "murrty", Properties.Settings.Default.LastDebugDate);
            llbCheckForUpdates.Text = Program.lang.llbCheckForUpdates;
            this.Text = string.Format("{0} youtube-dl-gui", Program.lang.frmAbout);
        }

        private void llbCheckForUpdates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (UpdateCheckThread == null || !UpdateCheckThread.IsAlive) {
                UpdateCheckThread = new Thread(() => {
                    try {
                        UpdateChecker.CheckForUpdate(true);
                    }
                    catch (ThreadAbortException) {
                        // do nothing
                    }
                    catch (Exception ex) {
                        ErrorLog.Report(ex);
                    }
                }) {
                    Name = "Checks for updates",
                    IsBackground = true
                };
                UpdateCheckThread.Start();
            }
        }
        private void pbIcon_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/murrty/youtube-dl-gui/");
        }

        private void llbGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/murrty/youtube-dl-gui");
        }
    }
}
