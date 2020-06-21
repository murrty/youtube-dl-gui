using System;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmUpdateAvailable : Form {
        Language lang = Language.GetInstance();
        GitData Cloud = GitData.GetInstance();
        public bool BlockSkip = false;

        public frmUpdateAvailable() {
            InitializeComponent();
            this.Text = lang.frmUpdateAvailable;
            lbUpdateAvailableHeader.Text = lang.lbUpdateAvailableHeader;
            lbUpdateAvailableUpdateVersion.Text = lang.lbUpdateAvailableUpdateVersion + " " + Cloud.UpdateVersion;
            lbUpdateAvailableCurrentVersion.Text = lang.lbUpdateAvailableCurrentVersion + " " + Properties.Settings.Default.appVersion.ToString();
            lbUpdateAvailableChangelog.Text = lang.lbUpdateAvailableChangelog;
            txtUpdateAvailableName.Text = Cloud.UpdateName;
            rtbUpdateAvailableChangelog.Text = Cloud.UpdateBody;
            btnUpdateAvailableUpdate.Text = lang.btnUpdateAvailableUpdate;
            btnUpdateAvailableSkip.Text = lang.btnUpdateAvailableSkipVersion;
            btnUpdateAvailableOk.Text = lang.btnUpdateAvailableOk;
            this.Icon = Properties.Resources.youtube_dl_gui;

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
