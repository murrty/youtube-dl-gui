using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmAbout : Form {
        Language lang = Language.GetInstance();
        GitData GitCloud = GitData.GetInstance();

        public frmAbout() {
            InitializeComponent();
            pbIcon.Image = Properties.Resources.youtube_dl_gui32;
            pbIcon.Cursor = Program.SystemHandCursor;
            LoadLanguage();
        }

        private void LoadLanguage() {
            lbAboutBody.Text = string.Format(lang.lbAboutBody + "\n\nlikulau best boye.", "ytdl-org", "murrty", Properties.Settings.Default.debugDate);
            llbCheckForUpdates.Text = lang.llbCheckForUpdates;
            this.Text = string.Format("{0} youtube-dl-gui", lang.frmAbout);
        }
        private void frmAbout_Shown(object sender, EventArgs e) {
            if (Properties.Settings.Default.IsBetaVersion) {
                lbVersion.Text = "v" + Properties.Settings.Default.BetaVersion;
            }
            else {
                lbVersion.Text = "v" + Properties.Settings.Default.appVersion.ToString();
            }
        }

        private void llbCheckForUpdates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            UpdateChecker.CheckForUpdate(true);
        }
        private void pbIcon_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/murrty/youtube-dl-gui/");
        }

        private void llbGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/murrty/youtube-dl-gui");
        }
    }
}
