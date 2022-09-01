using System.Windows.Forms;

namespace youtube_dl_gui {

    public partial class frmUpdateAvailable : Form {

        /// <summary>
        /// Whether the "Skip" button should be enabled.
        /// </summary>
        public bool BlockSkip { get; init; } = false;

        /// <summary>
        /// The update that is available.
        /// </summary>
        internal updater.GithubData UpdateData { get; init; } = null;

        public frmUpdateAvailable() {
            InitializeComponent();
            this.Text = Program.lang.frmUpdateAvailable;
            lbUpdateAvailableHeader.Text = Program.lang.lbUpdateAvailableHeader;
            lbUpdateAvailableCurrentVersion.Text = $"{Program.lang.lbUpdateAvailableCurrentVersion.Format(Program.CurrentVersion)}";
            lbUpdateAvailableChangelog.Text = Program.lang.lbUpdateAvailableChangelog;
            btnUpdateAvailableUpdate.Text = Program.lang.btnUpdateAvailableUpdate;
            btnUpdateAvailableSkip.Text = Program.lang.btnUpdateAvailableSkipVersion;
            btnUpdateAvailableOk.Text = Program.lang.GenericOk;
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

        private void frmUpdateAvailable_Load(object sender, EventArgs e) {
            btnUpdateAvailableSkip.Enabled = !BlockSkip;
            lbUpdateAvailableUpdateVersion.Text = $"{Program.lang.lbUpdateAvailableUpdateVersion.Format(UpdateData.Version)}";
            txtUpdateAvailableName.Text = UpdateData.VersionHeader;
            rtbUpdateAvailableChangelog.Text = UpdateData.VersionDescription;
            lbUpdateSize.Text = Program.lang.lbUpdateSize.Format(Extensions.SizeToString(UpdateData.GetExecutableSize()));
        }
    }
}
