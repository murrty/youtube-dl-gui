using System;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmSubtitles : Form {
        Language lang = Language.GetInstance();
        public frmSubtitles() {
            InitializeComponent();
            LoadLanguage();
        }

        void LoadLanguage() {
            this.Text = lang.frmSubtitles;
            lbSubtitlesHeader.Text = lang.lbSubtitlesHeader;
            lbSubtitlesUrl.Text = lang.lbSubtitlesUrl;
            lbSubtitlesLanguages.Text = lang.lbSubtitlesLanguages;
            btnSubtitlesAddLanguages.Text = lang.btnSubtitlesAddLanguage;
            btnSubtitlesClearLanguages.Text = lang.btnSubtitlesClearLanguages;
            btnSubtitlesDownload.Text = lang.btnSubtitlesDownload;
        }

        private void txtLanguage_KeyPress(object sender, KeyPressEventArgs e) {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == 44 || e.KeyChar == 45)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnSubtitlesAddLanguages_Click(object sender, EventArgs e) {
            if (cbLanguage.SelectedIndex == 0) {
                txtLanguage.Clear();
                txtLanguage.Text = "all";
                return;
            }
            else if (txtLanguage.Text == "all") {
                txtLanguage.Clear();
            }
            if (txtLanguage.Text != string.Empty) {
                txtLanguage.AppendText(",");
            }
            txtLanguage.AppendText(cbLanguage.GetItemText(cbLanguage.SelectedItem));
        }

        private void btnSubtitlesClearLanguages_Click(object sender, EventArgs e) {
            txtLanguage.Clear();
        }

        private void btnSubtitlesDownload_Click(object sender, EventArgs e) {

        }
    }
}
