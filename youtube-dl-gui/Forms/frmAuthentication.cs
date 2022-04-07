using System;
using System.Drawing;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmAuthentication : Form {

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
            this.Text = Program.lang.frmAuthentication;
            lbAuthNotice.Text = Program.lang.lbAuthNotice;
            lbAuthUsername.Text = Program.lang.lbAuthUsername;
            lbAuthPassword.Text = Program.lang.lbAuthPassword;
            lbAuth2Factor.Text = Program.lang.lbAuth2Factor;
            lbAuthVideoPassword.Text = Program.lang.lbAuthVideoPassword;
            chkAuthUseNetrc.Text = Program.lang.chkAuthUseNetrc;
            lbAuthNoSave.Text = Program.lang.lbAuthNoSave;
            btnAuthBeginDownload.Text = Program.lang.btnAuthBeginDownload;
            btnAuthGenericCancel.Text = Program.lang.GenericCancel;
        }
        private void CalculatePositions() {
            chkAuthUseNetrc.Location = new(
                //(this.Size.Width - chkAuthUseNetrc.Size.Width) / 2,
                (this.ClientSize.Width - chkAuthUseNetrc.Size.Width) / 2,
                chkAuthUseNetrc.Location.Y
            );
        }

        private void chkPasswordVisible_CheckedChanged(object sender, EventArgs e) {
            txtPassword.PasswordChar = chkPasswordVisible.Checked ? '\0' : '●';
        }

        private void chkVideoPassVisible_CheckedChanged(object sender, EventArgs e) {
            txtVideoPassword.PasswordChar = chkVideoPassVisible.Checked ? '\0' : '●';
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
