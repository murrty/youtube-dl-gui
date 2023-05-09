namespace youtube_dl_gui;
using System.Windows.Forms;
public partial class frmArchiveDownloader : Form, ILocalizedForm {
    public frmArchiveDownloader() {
        InitializeComponent();
        LoadLanguage();

        this.Load += (s, e) => {
            RegisterLocalizedForm();
            if (Config.Settings.Saved.ArchiveDownloaderLocation.Valid) {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = Config.Settings.Saved.ArchiveDownloaderLocation;
            }
        };
        this.FormClosing += (s, e) => {
            UnregisterLocalizedForm();
            Config.Settings.Saved.ArchiveDownloaderLocation = this.Location;
            Config.Settings.Saved.Save();
        };
        txtArchiveDownloaderHint.MouseEnter += (s, e) => {
            if (Config.Settings.General.HoverOverURLTextBoxToPaste)
                txtArchiveDownloaderHint.Text = Clipboard.GetText();
        };
    }
    public void LoadLanguage() {
        this.Text = Language.frmArchiveDownloader;
        lbArchiveDownloaderDescription.Text = Language.lbArchiveDownloaderDescription;
        txtArchiveDownloaderHint.TextHint = Language.txtArchiveDownloaderHint;
        btnDownload.Text = Language.sbDownload;
        btnExtendedDownload.Text = Language.mExtendedDownloadForm;
    }
    public void RegisterLocalizedForm() => Language.RegisterForm(this);
    public void UnregisterLocalizedForm() => Language.UnregisterForm(this);
    private void Download(bool Extended) {
        if (txtArchiveDownloaderHint.Text.IsNullEmptyWhitespace()) {
            txtArchiveDownloaderHint.Focus();
            System.Media.SystemSounds.Exclamation.Play();
            return;
        }
        
        string VideoKey = txtArchiveDownloaderHint.Text;
        if (DownloadHelper.IsYoutubeLink(VideoKey))
            VideoKey = DownloadHelper.GetYoutubeVideoKey(VideoKey);

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
            DownloadInfo NewInfo = new() {
                DownloadArguments = $"ytarchive:{VideoKey}",
                DownloadURL = $"https://archived.youtube.com/watch?v={VideoKey}",
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