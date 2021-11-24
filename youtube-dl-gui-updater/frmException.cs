using System;
using System.Windows.Forms;

namespace youtube_dl_gui_updater {
    public partial class frmException : Form {
        Language lang = Language.GetLangInstance();
        public Exception reportedException;
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
                this.Text = lang.frmException;
                lbExceptionHeader.Text = lang.lbExceptionHeader;
                lbExceptionDescription.Text = lang.lbExceptionDescription;
                lbExceptionDescription.Text = lang.lbExceptionDescription;
                btnExceptionGithub.Text = lang.btnExceptionGithub;
                btnExceptionOk.Text = lang.btnExceptionOk;
                btnExceptionOk.Text = lang.btnExceptionRetry;
            }
        }

        private void frmError_Load(object sender, EventArgs e) {
            string outputBuffer = lang.rtbExceptionDetails + "\n\nUpdater version: " + Properties.Settings.Default.CurrentVersion + "\nReported Exception: " + reportedException.ToString();
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
