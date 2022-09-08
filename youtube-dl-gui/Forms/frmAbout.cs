using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmAbout : Form {
        Thread UpdateCheckThread;
        public frmAbout() {
            InitializeComponent();
            LoadLanguage();
            pbIcon.Image = Properties.Resources.AboutImage;
            pbIcon.Cursor = NativeMethods.SystemHandCursor;
            lbVersion.Text = $"v{Program.CurrentVersion}";
            llbCheckForUpdates.LinkVisited = Program.UpdateChecked;
            llbCheckForUpdates.Location = new(
                (this.ClientSize.Width - llbCheckForUpdates.Width) / 2,
                llbCheckForUpdates.Location.Y
            );
        }

        private void LoadLanguage() {
            lbAboutBody.Text = string.Format(Language.lbAboutBody + "\n\nlikulau best boye.", "ytdl-org", "murrty", Properties.Resources.BuildDate);
            llbCheckForUpdates.Text = Language.llbCheckForUpdates;
            this.Text = $"{Language.frmAbout} youtube-dl-gui";
        }

        private void llbCheckForUpdates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (UpdateCheckThread is null || !UpdateCheckThread.IsAlive) {
                UpdateCheckThread = new Thread(() => {
                    try {
                        bool? result;
                        if ((result = UpdateChecker.CheckForUpdate(Program.CurrentVersion, Config.Settings.General.DownloadBetaVersions, chkForceCheckUpdate.Checked)) is not null) {
                            if (result == false) {
                                this.BeginInvoke(() => {
                                    MessageBox.Show(
                                        Program.CurrentVersion.IsBeta ?
                                            string.Format(Language.dlgUpdateNoBetaUpdateAvailable, Program.CurrentVersion, updater.UpdateChecker.LastChecked.Version) :
                                            string.Format(Language.dlgUpdateNoUpdateAvailable, Program.CurrentVersion, updater.UpdateChecker.LastChecked.Version),
                                        "youtube-dl-gui",
                                        MessageBoxButtons.OK);
                                });
                            }
                        }
                        Program.UpdateChecked = true;
                        if (!Program.IsUpdating) {
                            if (this.IsHandleCreated) {
                                llbCheckForUpdates.Invoke((Action)delegate {
                                    llbCheckForUpdates.LinkVisited = true;
                                });
                            }
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
