namespace youtube_dl_gui;

using System.Text.RegularExpressions;
using System.Windows.Forms;

public partial class frmArchiveDownloader : Form {
    public frmArchiveDownloader() {
        InitializeComponent();
        LoadLanguage();

        this.Load += (s, e) => {
            if (Config.Settings.Saved.ArchiveDownloaderLocation.Valid) {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = Config.Settings.Saved.ArchiveDownloaderLocation;
            }
        };
        this.FormClosing += (s, e) => {
            Config.Settings.Saved.ArchiveDownloaderLocation = this.Location;
            Config.Settings.Saved.Save();
        };
        txtArchiveDownloaderHint.MouseEnter += (s, e) => {
            if (Config.Settings.General.HoverOverURLTextBoxToPaste) {
                txtArchiveDownloaderHint.Text = Clipboard.GetText();
            }
        };
    }
    private void LoadLanguage() {
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
        string URL;
        if (!new Regex(@"^[a-zA-Z0-9-_]{11}").IsMatch(txtArchiveDownloaderHint.Text)) {
            if (!new Regex(@"(((http|https):\/\/)?(.){0,5}(youtube\.com|youtu\.be)\/(watch\?v=)?)?[a-zA-Z0-9-_]{11}").IsMatch(txtArchiveDownloaderHint.Text)) {
                txtArchiveDownloaderHint.Focus();
                System.Media.SystemSounds.Exclamation.Play();
                return;
            }
            else {
                URL = txtArchiveDownloaderHint.Text.Split('&')[0];
                string URLLower = URL.ToLower();
                if (URLLower.StartsWith("http://")) {
                    URL = URL[7..];
                    URLLower = URLLower[7..];
                }
                else if (URLLower.StartsWith("https://")) {
                    URL = URL[8..];
                    URLLower = URLLower[8..];
                }
                if (URLLower.StartsWith("www.")) {
                    URL = URL[4..];
                    URLLower = URLLower[4..];
                }
                if (URLLower.StartsWith("youtube.com/watch?v=")) {
                    URL = URL[20..];
                    URLLower = URLLower[20..];
                }
                else if (URLLower.StartsWith("youtu.be/")) {
                    URL = URL[9..];
                    URLLower = URLLower[9..];
                }

                if (URL.Length > 11) {
                    URL = URL[..11];
                }

                if (!new Regex(@"^[a-zA-Z0-9-_]{11}$").IsMatch(URL)) {
                    txtArchiveDownloaderHint.Focus();
                    System.Media.SystemSounds.Exclamation.Play();
                    return;
                }
            }
        }
        else {
            URL = txtArchiveDownloaderHint.Text.Length > 11 ? txtArchiveDownloaderHint.Text[..11] : txtArchiveDownloaderHint.Text;
        }

        if (Extended) {
            frmExtendedDownloader ExtendedForm = new($"ytarchive:{URL}", true);
            ExtendedForm.Show();
        }
        else {
            DownloadInfo NewInfo = new() {
                DownloadArguments = $"ytarchive:{URL}",
                DownloadURL = $"https://archived.youtube.com/watch?v={URL}",
                MostlyCustomArguments = true,
                Type = DownloadType.Custom
            };
            frmDownloader Downloader = new(NewInfo);
            Downloader.ShowDialog();
        }
    }
    private void btnDownload_Click(object sender, EventArgs e) {
        Download(false);
    }
    private void btnExtendedDownload_Click(object sender, EventArgs e) {
        Download(true);
    }
}