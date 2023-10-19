#nullable enable
namespace youtube_dl_gui;
using System.Windows.Forms;
public partial class frmSubtitles : LocalizedForm {
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

    public override void LoadLanguage() {
        this.Text = Language.frmSubtitles;
        lbSubtitlesHeader.Text = Language.lbSubtitlesHeader;
        lbSubtitlesUrl.Text = Language.lbSubtitlesUrl;
        lbSubtitlesLanguages.Text = Language.lbSubtitlesLanguages;
        btnSubtitlesAddLanguages.Text = Language.btnSubtitlesAddLanguage;
        btnSubtitlesClearLanguages.Text = Language.btnSubtitlesClearLanguages;
        btnSubtitlesDownload.Text = Language.btnSubtitlesDownload;
    }

    private void txtLanguage_KeyPress(object sender, KeyPressEventArgs e) {
        e.Handled = !char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != 44 && e.KeyChar != 45;
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
