using System;
using System.Windows.Forms;

namespace youtube_dl_gui_updater {
    public partial class frmException : Form {
        public Exception ReportedException;
        public bool FromLanguage = false;
        public bool AllowRetry = false;

        public frmException() {
            InitializeComponent();
            loadLanguage();
            DateTime TimeNow = DateTime.Now;
            lbDate.Text = string.Format("{0}/{1}/{2} {3}:{4}:{5}", TimeNow.Year, TimeNow.Month, TimeNow.Day, TimeNow.Hour, TimeNow.Minute, TimeNow.Second);
        }

        void loadLanguage() {
            if (FromLanguage) {
                this.Text = Language.InternalEnglish.frmException;
                lbExceptionHeader.Text = Language.InternalEnglish.lbExceptionHeader;
                lbExceptionDescription.Text = Language.InternalEnglish.lbExceptionDescription;
                rtbExceptionDetails.Text = Language.InternalEnglish.rtbExceptionDetails;
                btnExceptionGithub.Text = Language.InternalEnglish.btnExceptionGithub;
                btnExceptionOk.Text = Language.InternalEnglish.btnExceptionOk;
                btnExceptionRetry.Text = Language.InternalEnglish.btnExceptionRetry;
            }
            else {
                this.Text = Program.lang.frmException;
                lbExceptionHeader.Text = Program.lang.lbExceptionHeader;
                lbExceptionDescription.Text = Program.lang.lbExceptionDescription;
                lbExceptionDescription.Text = Program.lang.lbExceptionDescription;
                btnExceptionGithub.Text = Program.lang.btnExceptionGithub;
                btnExceptionOk.Text = Program.lang.btnExceptionOk;
                btnExceptionOk.Text = Program.lang.btnExceptionRetry;
            }
        }

        private void frmError_Load(object sender, EventArgs e) {
            string outputBuffer = Program.lang.rtbExceptionDetails + "\n\nUpdater version: " + Properties.Settings.Default.CurrentVersion + "\nReported Exception: " + ReportedException.ToString();
            rtbExceptionDetails.Text = outputBuffer;
            lbVersion.Text = "v" + Properties.Settings.Default.CurrentVersion;
            System.Media.SystemSounds.Hand.Play();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void btnGithub_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/murrty/SoloMatchmaking/issues");
        }

        private void btnExceptionRetry_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Retry;
            this.Dispose();
        }

    }
}
