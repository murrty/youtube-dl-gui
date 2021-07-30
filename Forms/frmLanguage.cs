using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmLanguage : Form {
        Language lang = Language.GetInstance();
        public string LanguageFile = null;

        public frmLanguage() {
            InitializeComponent();
            LoadLanguage();
            LoadFiles();
        }
        public void LoadLanguage() {
            this.Text = lang.frmLanguage;
            btnLanguageRefresh.Text = lang.btnLanguageRefresh;
            btnLanguageCancel.Text = lang.btnLanguageCancel;
            btnLanguageSave.Text = lang.btnLanguageSave;

            lbCurrentLanguageShort.Text = lang.CurrentLanguageShort;
            ttLanguage.SetToolTip(lbCurrentLanguageShort, lang.CurrentLanguageLong + " (" + lang.CurrentLanguageShort + ")\nLang version " + lang.CurrentLanguageVersion);
        }

        public void LoadFiles() {
            if (Directory.Exists(Environment.CurrentDirectory + "\\lang\\")) {
                List<string> Files = new List<string>();
                DirectoryInfo LangFolder = new DirectoryInfo(Environment.CurrentDirectory + "\\lang\\");
                FileInfo[] LangFiles = LangFolder.GetFiles("*.ini");
                foreach (FileInfo File in LangFiles) {
                    Files.Add(File.Name.Substring(0, File.Name.Length - 4));
                }
                cbLanguages.Items.Clear();
                cbLanguages.Items.Add("English (Internal)");
                cbLanguages.Items.AddRange(Files.ToArray());
                if (Config.ProgramConfig.Initialization.LanguageFile == "") {
                    cbLanguages.SelectedIndex = cbLanguages.SelectedIndex = 0;
                }
                else {
                    cbLanguages.SelectedIndex = cbLanguages.FindStringExact(Config.ProgramConfig.Initialization.LanguageFile);
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
            if (cbLanguages.SelectedIndex > 0) { LanguageFile = cbLanguages.GetItemText(cbLanguages.SelectedItem); }
            else { LanguageFile = null; }
            this.DialogResult = DialogResult.Yes;
        }
    }
}