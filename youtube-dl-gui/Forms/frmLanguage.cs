namespace youtube_dl_gui;
using System.IO;
using System.Windows.Forms;
public partial class frmLanguage : Form, ILocalizedForm {
    public frmLanguage() {
        InitializeComponent();
        LoadLanguage();
        LoadFiles();
        cbLanguages.SelectedIndex = string.IsNullOrWhiteSpace(Language.LoadedFile) ? 
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
    // Ignore Registration because it is not used.
    public void RegisterLocalizedForm() { }
    public void UnregisterLocalizedForm() { }
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
    private void btnLanguageDownload_Click(object sender, EventArgs e) {
        using frmDownloadLanguage DownloadLanguage = new();
        DialogResult result = DownloadLanguage.ShowDialog();
        string CurrentFile = cbLanguages.GetItemText(cbLanguages.SelectedItem);
        cbLanguages.SelectedIndex = -1;
        LoadFiles();
        if (result == DialogResult.OK)
            cbLanguages.SelectedIndex = cbLanguages.FindStringExact(DownloadLanguage.FileName is null ? CurrentFile : DownloadLanguage.FileName);
    }
    private void btnLanguageSave_Click(object sender, EventArgs e) {
        Config.Settings.Initialization.LanguageFile = cbLanguages.SelectedIndex > 0 ?
            cbLanguages.GetItemText(cbLanguages.SelectedItem) : null;
        Config.Settings.Initialization.Save();
        Language.LoadLanguage($"{Environment.CurrentDirectory}\\lang\\{Config.Settings.Initialization.LanguageFile}.ini");
        this.DialogResult = DialogResult.OK;
    }
    private void btnLanguageCancel_Click(object sender, EventArgs e) {
        this.DialogResult = DialogResult.Cancel;
    }

}