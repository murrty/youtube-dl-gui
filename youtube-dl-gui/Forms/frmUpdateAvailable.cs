using System;
using System.Windows.Forms;

namespace youtube_dl_gui {

    public partial class frmUpdateAvailable : Form {

        /// <summary>
        /// Whether the "Skip" button should be enabled.
        /// </summary>
        public bool BlockSkip = false;

        public frmUpdateAvailable() {
            InitializeComponent();

            this.Text = Program.lang.frmUpdateAvailable;
            lbUpdateAvailableHeader.Text = Program.lang.lbUpdateAvailableHeader;
            lbUpdateAvailableUpdateVersion.Text = $"{Program.lang.lbUpdateAvailableUpdateVersion} {UpdateChecker.GitInfo.UpdateVersion}";
            lbUpdateAvailableCurrentVersion.Text = $"{Program.lang.lbUpdateAvailableCurrentVersion} {(Properties.Settings.Default.IsBetaVersion ? Properties.Settings.Default.BetaVersion : Properties.Settings.Default.CurrentVersion)}";
            lbUpdateAvailableChangelog.Text = Program.lang.lbUpdateAvailableChangelog;
            txtUpdateAvailableName.Text = UpdateChecker.GitInfo.UpdateName;
            rtbUpdateAvailableChangelog.Text = UpdateChecker.GitInfo.UpdateBody;
            btnUpdateAvailableUpdate.Text = Program.lang.btnUpdateAvailableUpdate;
            btnUpdateAvailableSkip.Text = Program.lang.btnUpdateAvailableSkipVersion;
            btnUpdateAvailableOk.Text = Program.lang.GenericOk;

            btnUpdateAvailableSkip.Enabled = !BlockSkip;

        }

        private void btnUpdateAvailableSkip_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Ignore;
        }

        private void btnUpdateAvailableUpdate_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Yes;
        }

        private void btnUpdateAvailableOk_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

    }
}
