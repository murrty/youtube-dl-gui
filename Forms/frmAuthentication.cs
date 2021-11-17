using System;
using System.Drawing;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmAuthentication : Form {
        readonly Language lang = Language.GetInstance();

        public string Username = null;
        public string Password = null;
        public string TwoFactor = null;
        public string VideoPassword = null;
        public bool Netrc = false;

        public frmAuthentication() {
            InitializeComponent();
            LoadLanguage();
            CalculatePositions();
        }

        private void LoadLanguage() {
            this.Text = lang.frmAuthentication;
            lbAuthNotice.Text = lang.lbAuthNotice;
            lbAuthUsername.Text = lang.lbAuthUsername;
            lbAuthPassword.Text = lang.lbAuthPassword;
            lbAuth2Factor.Text = lang.lbAuth2Factor;
            lbAuthVideoPassword.Text = lang.lbAuthVideoPassword;
            chkAuthUseNetrc.Text = lang.chkAuthUseNetrc;
            lbAuthNoSave.Text = lang.lbAuthNoSave;
            btnAuthBeginDownload.Text = lang.btnAuthBeginDownload;
            btnAuthGenericCancel.Text = lang.GenericCancel;
        }
        private void CalculatePositions() {
            chkAuthUseNetrc.Location = new Point((this.Size.Width - chkAuthUseNetrc.Size.Width) / 2, chkAuthUseNetrc.Location.Y);
        }

        private void chkPasswordVisible_CheckedChanged(object sender, EventArgs e) {
            if (chkPasswordVisible.Checked) {
                txtPassword.PasswordChar = '\0';
            }
            else {
                txtPassword.PasswordChar = '●';
            }
        }
        private void chkVideoPassVisible_CheckedChanged(object sender, EventArgs e) {
            if (chkVideoPassVisible.Checked) {
                txtVideoPassword.PasswordChar = '\0';
            }
            else {
                txtVideoPassword.PasswordChar = '●';
            }
        }

        private void btnAuthBeginDownload_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(txtUsername.Text)) {
                Username = txtUsername.Text;
                txtUsername.Text = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtPassword.Text)) {
                Password = txtPassword.Text;
                txtPassword.Text = string.Empty;
            }
            if (!string.IsNullOrEmpty(txt2Factor.Text)) {
                TwoFactor = txt2Factor.Text;
                txt2Factor.Text = string.Empty;
            }
            if (!string.IsNullOrEmpty(txtVideoPassword.Text)) {
                VideoPassword = txtVideoPassword.Text;
                txtVideoPassword.Text = string.Empty;
            }
            Netrc = chkAuthUseNetrc.Checked;

            this.DialogResult = DialogResult.OK;
        }

        private void btnAuthGenericCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
