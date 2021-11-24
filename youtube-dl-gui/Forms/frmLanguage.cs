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
        }
        public void LoadLanguage() {
            this.Text = Program.lang.frmLanguage;
            btnLanguageRefresh.Text = Program.lang.btnLanguageRefresh;
            btnLanguageCancel.Text = Program.lang.GenericCancel;
            btnLanguageSave.Text = Program.lang.GenericSave;

            lbCurrentLanguageShort.Text = Program.lang.CurrentLanguageShort;
            ttLanguage.SetToolTip(lbCurrentLanguageShort, Program.lang.CurrentLanguageLong + " (" + Program.lang.CurrentLanguageShort + ")\nLang version " + Program.lang.CurrentLanguageVersion);
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
                if (string.IsNullOrWhiteSpace(Config.Settings.Initialization.LanguageFile)) {
                    cbLanguages.SelectedIndex = cbLanguages.SelectedIndex = 0;
                }
                else {
                    cbLanguages.SelectedIndex = cbLanguages.FindStringExact(Config.Settings.Initialization.LanguageFile);
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
                Program.lang.LoadLanguage(Program.ProgramPath + "\\lang\\" + LanguageFile + ".ini");
            }
            else {
                LanguageFile = null;
                Program.lang.LoadInternalEnglish();
            }
            this.DialogResult = DialogResult.Yes;
        }
    }
}