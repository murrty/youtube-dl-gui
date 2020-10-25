using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmAbout : Form {
        Language lang = Language.GetInstance();
        GitData GitCloud = GitData.GetInstance();

        public frmAbout() {
            InitializeComponent();
            this.Icon = Properties.Resources.youtube_dl_gui;
            pbIcon.Image = Properties.Resources.youtube_dl_gui32;
            pbIcon.Cursor = Program.SystemHandCursor;
            LoadLanguage();
        }

        private void LoadLanguage() {
            lbAboutBody.Text = string.Format("youtube-dl {0} ytdl-org\n"+
                          "youtube-dl-gui {0} murrty\n"+
                          "{1} {2}\n\n\n"+
                          "likulau best boye.", "by", "debug date", Properties.Settings.Default.debugDate);
            llbCheckForUpdates.Text = "Check for updates";
            this.Text = string.Format("{0} youtube-dl-gui", "About");
        }
        private void frmAbout_Shown(object sender, EventArgs e) {
            if (!Properties.Settings.Default.jsonSupport)
                llbCheckForUpdates.Enabled = false;

            lbVersion.Text = "v" + Properties.Settings.Default.appVersion.ToString();
            lbAboutBody.Text = lbAboutBody.Text.Replace("{DEBUG}", Properties.Settings.Default.debugDate);
        }

        private void llbCheckForUpdates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (!Properties.Settings.Default.jsonSupport)
                return;

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
