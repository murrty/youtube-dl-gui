using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmAbout : Form {
        Thread UpdateCheckThread;
        public frmAbout() {
            InitializeComponent();
            LoadLanguage();
            pbIcon.Image = Properties.Resources.youtube_dl_gui32;
            lbVersion.Text = $"v{(Program.IsBetaVersion ? Program.BetaVersion : Program.CurrentVersion)}";
            llbCheckForUpdates.LinkVisited = Program.UpdateChecked;
            llbCheckForUpdates.Location = new(
                (this.ClientSize.Width - llbCheckForUpdates.Width) / 2,
                llbCheckForUpdates.Location.Y
            );
        }

        private void LoadLanguage() {
            lbAboutBody.Text = string.Format(Program.lang.lbAboutBody + "\n\nlikulau best boye.", "ytdl-org", "murrty", Properties.Resources.BuildDate);
            llbCheckForUpdates.Text = Program.lang.llbCheckForUpdates;
            this.Text = $"{Program.lang.frmAbout} youtube-dl-gui";
        }

        private void llbCheckForUpdates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (UpdateCheckThread == null || !UpdateCheckThread.IsAlive) {
                UpdateCheckThread = new Thread(() => {
                    try {
                        UpdateChecker.CheckForUpdate(true);
                        Program.UpdateChecked = true;
                        if (!this.IsDisposed) {
                            llbCheckForUpdates.Invoke((Action)delegate {
                                llbCheckForUpdates.LinkVisited = true;
                            });
                        }
                    }
                    catch (ThreadAbortException) {
                        // do nothing
                    }
                    catch (Exception ex) {
                        Log.ReportException(ex);
                    }
                }) {
                    Name = "Checks for updates",
                    IsBackground = true
                };
                UpdateCheckThread.Start();
            }
        }

        private void pbIcon_Click(object sender, EventArgs e) =>
            Process.Start("https://github.com/murrty/youtube-dl-gui/");

        private void llbGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            Process.Start("https://github.com/murrty/youtube-dl-gui");
    }
}
