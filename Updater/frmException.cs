using System;
using System.Windows.Forms;

namespace youtube_dl_gui_updater {
    public partial class frmException : Form {
        Language lang = Language.GetLangInstance();
        public Exception reportedException;
        public bool FromLanguage = false;

        public frmException() {
            InitializeComponent();
            loadLanguage();
        }

        void loadLanguage() {
            if (FromLanguage) {
                this.Text = Language.InternalEnglish.frmException;
                lbExceptionHeader.Text = Language.InternalEnglish.lbExceptionHeader;
                lbExceptionDescription.Text = Language.InternalEnglish.lbExceptionDescription;
                rtbExceptionDetails.Text = Language.InternalEnglish.rtbExceptionDetails;
                btnExceptionGithub.Text = Language.InternalEnglish.btnExceptionGithub;
                btnExceptionOk.Text = Language.InternalEnglish.btnExceptionOk;
            }
            else {
                this.Text = lang.frmException;
                lbExceptionHeader.Text = lang.lbExceptionHeader;
                lbExceptionDescription.Text = lang.lbExceptionDescription;
                lbExceptionDescription.Text = lang.lbExceptionDescription;
                btnExceptionGithub.Text = lang.btnExceptionGithub;
                btnExceptionOk.Text = lang.btnExceptionOk;
            }
        }

        private void frmError_Load(object sender, EventArgs e) {
            string outputBuffer = lang.rtbExceptionDetails + "\n\nUpdater version: " + "1.0" + "\nReported Exception: " + reportedException.ToString();
            rtbExceptionDetails.Text = outputBuffer;
            lbVersion.Text = "v" + "?";
            System.Media.SystemSounds.Hand.Play();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void btnGithub_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/murrty/SoloMatchmaking/issues");
        }

    }
}
