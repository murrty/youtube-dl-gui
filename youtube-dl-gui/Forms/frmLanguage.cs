using System.IO;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmLanguage : Form {
        public string LanguageFile { get; private set; } = null;

        public frmLanguage() {
            InitializeComponent();
            LoadLanguage();
            LoadFiles();
            cbLanguages.SelectedIndex = string.IsNullOrWhiteSpace(Config.Settings.Initialization.LanguageFile) ? 
                0 : cbLanguages.FindStringExact(Config.Settings.Initialization.LanguageFile);
            lbCurrentVersion.Text = Program.CurrentVersion.ToString();
        }

        public void LoadLanguage() {
            if (Config.Settings.Initialization.firstTime) {
                this.Text = Language.InternalEnglish.frmLanguage;
                btnLanguageRefresh.Text = Language.InternalEnglish.btnLanguageRefresh;
                btnLanguageCancel.Text = Language.InternalEnglish.GenericCancel;
                btnLanguageSave.Text = Language.InternalEnglish.GenericSave;
                btnLanguageDownload.Text = Language.InternalEnglish.btnLanguageDownload;

                lbCurrentLanguageShort.Text = Language.InternalEnglish.CurrentLanguageShort;
                ttLanguage.SetToolTip(lbCurrentLanguageShort, Language.InternalEnglish.CurrentLanguageLong + " (while first time)");
            }
            else {
                this.Text = Language.frmLanguage;
                btnLanguageRefresh.Text = Language.btnLanguageRefresh;
                btnLanguageCancel.Text = Language.GenericCancel;
                btnLanguageSave.Text = Language.GenericSave;
                btnLanguageDownload.Text = Language.btnLanguageDownload;

                lbCurrentLanguageShort.Text = Language.CurrentLanguageShort;
                ttLanguage.SetToolTip(lbCurrentLanguageShort, $"{Language.CurrentLanguageLong} ({Language.CurrentLanguageShort})\nv{Language.CurrentLanguageVersion}");
            }
        }

        public void LoadFiles() {
            if (Directory.Exists(Environment.CurrentDirectory + "\\lang\\")) {
                DirectoryInfo LangFolder = new(Environment.CurrentDirectory + "\\lang\\");
                FileInfo[] LangFiles = LangFolder.GetFiles("*.ini");
                cbLanguages.Items.Clear();
                cbLanguages.Items.Add("English (Internal)");
                foreach (FileInfo File in LangFiles) {
                    cbLanguages.Items.Add(File.Name[..^4]);
                }
            }
        }

        private void btnLanguageRefresh_Click(object sender, EventArgs e) {
            LoadFiles();
        }

        private void btnLanguageCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnLanguageSave_Click(object sender, EventArgs e) {
            if (cbLanguages.SelectedIndex > 0) {
                LanguageFile = cbLanguages.GetItemText(cbLanguages.SelectedItem);
                Language.LoadLanguage($"{Program.ProgramPath}\\lang\\{LanguageFile}.ini");
            }
            else {
                LanguageFile = string.Empty;
                Language.LoadInternalEnglish();
            }
            this.DialogResult = DialogResult.Yes;
        }

        private void btnLanguageDownload_Click(object sender, EventArgs e) {
            using frmDownloadLanguage DownloadLanguage = new();
            DialogResult result = DownloadLanguage.ShowDialog();
            string CurrentFile = cbLanguages.GetItemText(cbLanguages.SelectedItem);
            cbLanguages.SelectedIndex = -1;
            LoadFiles();
            if (result == DialogResult.OK)
                cbLanguages.SelectedIndex = cbLanguages.FindStringExact(DownloadLanguage.FileName is null ? CurrentFile : DownloadLanguage.FileName);
        }
    }
}