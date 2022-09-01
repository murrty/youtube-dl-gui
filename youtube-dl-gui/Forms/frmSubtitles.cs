using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmSubtitles : Form {

        //youtube-dl --sub-lang en --write-auto-sub --sub-format srt --skip-download
        // language - download auto generated subs - sub format - skip video
        //--write-sub                      Write subtitle file
        //--write-auto-sub                 Write automatic subtitle file (YouTube only)
        //--all-subs                       Download all the available subtitles of the video
        //--list-subs                      List all available subtitles for the video
        //--sub-format FORMAT              Subtitle format, accepts formats preference, for example: "srt" or "ass/srt/best"
        //--sub-lang LANGS                 Languages of the subtitles to download (optional) separated by commas, use IETF language tags like 'en,pt'

        // Parse the --list-subs command to get available languages.
        // If none are available, then no subtitles are available :(

        public frmSubtitles() {
            InitializeComponent();
            LoadLanguage();
        }

        void LoadLanguage() {
            this.Text = Program.lang.frmSubtitles;
            lbSubtitlesHeader.Text = Program.lang.lbSubtitlesHeader;
            lbSubtitlesUrl.Text = Program.lang.lbSubtitlesUrl;
            lbSubtitlesLanguages.Text = Program.lang.lbSubtitlesLanguages;
            btnSubtitlesAddLanguages.Text = Program.lang.btnSubtitlesAddLanguage;
            btnSubtitlesClearLanguages.Text = Program.lang.btnSubtitlesClearLanguages;
            btnSubtitlesDownload.Text = Program.lang.btnSubtitlesDownload;
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
