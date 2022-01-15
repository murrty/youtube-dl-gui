using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmLanguage : Form {
        public string LanguageFile = null;

        public frmLanguage() {
            InitializeComponent();
            LoadLanguage();
            LoadFiles();
            cbLanguages.SelectedIndex = string.IsNullOrWhiteSpace(Config.Settings.Initialization.LanguageFile) ? 0 : cbLanguages.FindStringExact(Config.Settings.Initialization.LanguageFile);
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
                this.Text = Program.lang.frmLanguage;
                btnLanguageRefresh.Text = Program.lang.btnLanguageRefresh;
                btnLanguageCancel.Text = Program.lang.GenericCancel;
                btnLanguageSave.Text = Program.lang.GenericSave;
                btnLanguageDownload.Text = Program.lang.btnLanguageDownload;

                lbCurrentLanguageShort.Text = Program.lang.CurrentLanguageShort;
                ttLanguage.SetToolTip(lbCurrentLanguageShort, $"{Program.lang.CurrentLanguageLong} ({Program.lang.CurrentLanguageShort})\nLang version {Program.lang.CurrentLanguageVersion}");
            }
        }

        public void LoadFiles() {
            if (Directory.Exists(Environment.CurrentDirectory + "\\lang\\")) {
                List<string> Files = new();
                DirectoryInfo LangFolder = new(Environment.CurrentDirectory + "\\lang\\");
                FileInfo[] LangFiles = LangFolder.GetFiles("*.ini");
                foreach (FileInfo File in LangFiles) {
                    Files.Add(File.Name.Substring(0, File.Name.Length - 4));
                }
                cbLanguages.Items.Clear();
                cbLanguages.Items.Add("English (Internal)");
                cbLanguages.Items.AddRange(Files.ToArray());
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
                Program.lang.LoadLanguage(Program.ProgramPath + "\\lang\\" + LanguageFile + ".ini");
            }
            else {
                LanguageFile = string.Empty;
                Program.lang.LoadInternalEnglish();
            }
            this.DialogResult = DialogResult.Yes;
        }

        private void btnLanguageDownload_Click(object sender, EventArgs e) {
            using frmDownloadLanguage DownloadLanguage = new();
            DialogResult result = DownloadLanguage.ShowDialog();
            string CurrentFile = cbLanguages.GetItemText(cbLanguages.SelectedItem);
            cbLanguages.SelectedIndex = -1;
            LoadFiles();
            if (result == DialogResult.OK) {
                if (DownloadLanguage.FileName != null) {
                    cbLanguages.SelectedIndex = cbLanguages.FindStringExact(DownloadLanguage.FileName);
                }
                else {
                    cbLanguages.SelectedItem = cbLanguages.FindStringExact(CurrentFile);
                }
            }
            else {
                cbLanguages.SelectedItem = cbLanguages.FindStringExact(CurrentFile);
            }
        }
    }
}