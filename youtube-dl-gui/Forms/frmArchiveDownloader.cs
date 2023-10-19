#nullable enable
namespace youtube_dl_gui;
using System.Windows.Forms;
public partial class frmArchiveDownloader : LocalizedForm {
    public frmArchiveDownloader() {
        InitializeComponent();
        LoadLanguage();

        this.Load += (s, e) => {
            if (Saved.ArchiveDownloaderLocation.Valid) {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = Saved.ArchiveDownloaderLocation;
            }
        };
        this.FormClosing += (s, e) => Saved.ArchiveDownloaderLocation = this.Location;
        txtArchiveDownloaderHint.MouseEnter += (s, e) => {
            if (General.HoverOverURLTextBoxToPaste)
                txtArchiveDownloaderHint.Text = Clipboard.GetText();
        };
    }
    public override void LoadLanguage() {
        this.Text = Language.frmArchiveDownloader;
        lbArchiveDownloaderDescription.Text = Language.lbArchiveDownloaderDescription;
        txtArchiveDownloaderHint.TextHint = Language.txtArchiveDownloaderHint;
        btnDownload.Text = Language.sbDownload;
        btnExtendedDownload.Text = Language.mExtendedDownloadForm;
    }
    private void Download(bool Extended) {
        if (txtArchiveDownloaderHint.Text.IsNullEmptyWhitespace()) {
            txtArchiveDownloaderHint.Focus();
            System.Media.SystemSounds.Exclamation.Play();
            return;
        }

        string? VideoKey = txtArchiveDownloaderHint.Text;
        if (DownloadHelper.IsYoutubeLink(VideoKey)) {
            VideoKey = DownloadHelper.GetYoutubeVideoKey(VideoKey);
        }

        if (!DownloadHelper.IsYoutubeKey(VideoKey)) {
            txtArchiveDownloaderHint.Focus();
            System.Media.SystemSounds.Exclamation.Play();
            return;
        }

        if (Extended) {
            frmExtendedDownloader ExtendedForm = new($"ytarchive:{VideoKey}", true);
            ExtendedForm.Show();
        }
        else {
            DownloadInfo NewInfo = new($"https://archived.youtube.com/watch?v={VideoKey}") {
                Arguments = $"ytarchive:{VideoKey}",
                MostlyCustomArguments = true,
                Type = DownloadType.Custom
            };
            frmDownloader Downloader = new(NewInfo);
            Downloader.ShowDialog();
        }
    }
    private void btnDownload_Click(object sender, EventArgs e) => Download(false);
    private void btnExtendedDownload_Click(object sender, EventArgs e) => Download(true);
}