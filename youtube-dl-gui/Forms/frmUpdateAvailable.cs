using System;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmUpdateAvailable : Form {
        public bool BlockSkip = false;

        public frmUpdateAvailable() {
            InitializeComponent();
            this.Text = Program.lang.frmUpdateAvailable;
            lbUpdateAvailableHeader.Text = Program.lang.lbUpdateAvailableHeader;
            lbUpdateAvailableUpdateVersion.Text = Program.lang.lbUpdateAvailableUpdateVersion + " " + UpdateChecker.GitInfo.UpdateVersion;
            lbUpdateAvailableCurrentVersion.Text = Program.lang.lbUpdateAvailableCurrentVersion + " " + Properties.Settings.Default.CurrentVersion.ToString();
            lbUpdateAvailableChangelog.Text = Program.lang.lbUpdateAvailableChangelog;
            txtUpdateAvailableName.Text = UpdateChecker.GitInfo.UpdateName;
            rtbUpdateAvailableChangelog.Text = UpdateChecker.GitInfo.UpdateBody;
            btnUpdateAvailableUpdate.Text = Program.lang.btnUpdateAvailableUpdate;
            btnUpdateAvailableSkip.Text = Program.lang.btnUpdateAvailableSkipVersion;
            btnUpdateAvailableOk.Text = Program.lang.GenericOk;

        }
        private void frmUpdateAvailable_Load(object sender, EventArgs e) {
            if (BlockSkip) {
                btnUpdateAvailableSkip.Enabled = false;
            }
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
