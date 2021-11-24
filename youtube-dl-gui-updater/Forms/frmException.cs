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
            btnExceptionRetry.Enabled = AllowRetry;
        }

        void loadLanguage() {
            if (FromLanguage) {
                this.Text = Language.InternalEnglish.frmException;
                lbExceptionHeader.Text = Language.InternalEnglish.lbExceptionHeader;
                lbExceptionDescription.Text = Language.InternalEnglish.lbExceptionDescription;
                rtbExceptionDetails.Text = Language.InternalEnglish.rtbUpdaterExceptionDetails;
                btnExceptionGithub.Text = Language.InternalEnglish.btnExceptionGithub;
                btnExceptionOk.Text = Language.InternalEnglish.GenericOk;
                btnExceptionRetry.Text = Language.InternalEnglish.GenericRetry;
            }
            else {
                this.Text = Program.lang.frmException;
                lbExceptionHeader.Text = Program.lang.lbExceptionHeader;
                lbExceptionDescription.Text = Program.lang.lbExceptionDescription;
                lbExceptionDescription.Text = Program.lang.lbExceptionDescription;
                btnExceptionGithub.Text = Program.lang.btnExceptionGithub;
                btnExceptionOk.Text = Program.lang.GenericOk;
                btnExceptionRetry.Text = Program.lang.GenericRetry;
            }
        }

        private void frmError_Load(object sender, EventArgs e) {
            if (ReportedException == null) {
                rtbExceptionDetails.Text = Program.lang.rtbUpdaterExceptionDetails + "\n\nUpdater version: " + Properties.Settings.Default.CurrentVersion + "\nReported Exception: No exception has occured, but this form still appeared. Something is wrong.";
            }
            else {
                rtbExceptionDetails.Text = Program.lang.rtbUpdaterExceptionDetails + "\n\nUpdater version: " + Properties.Settings.Default.CurrentVersion + "\nReported Exception: " + ReportedException.ToString();
            }
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
