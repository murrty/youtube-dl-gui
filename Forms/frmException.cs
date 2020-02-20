using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmException : Form {
        public Exception reportedException;
        Language lang = Language.GetLanguageInstance();
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
            string outputBuffer = lang.rtbExceptionDetails + "\n\nVersion: " + Properties.Settings.Default.appVersion + "\nReported Exception: " + reportedException.ToString();
            rtbExceptionDetails.Text = outputBuffer;
            lbVersion.Text = "v" + Properties.Settings.Default.appVersion.ToString();
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
