using System.Drawing;
using System.Windows.Forms;

using youtube_dl_gui.updater;

namespace youtube_dl_gui {
    public partial class frmDownloadLanguage : Form {

        private readonly Font SubItemFont;
        private readonly GithubRepoContent[] EnumeratedLanguages;

        public string FileName { get; private set; }

        public frmDownloadLanguage() {
            InitializeComponent();
            NativeMethods.SetWindowTheme(lvAvailableLanguages.Handle, "explorer", null);
            SubItemFont = new("Segoi UI", this.Font.Size, FontStyle.Italic);
            try {
                EnumeratedLanguages = updater.UpdateChecker.GetAvailableLanguages();
                if (EnumeratedLanguages.Length > 0) {
                    // Uncomment these out when the SHA calcuation gets fixed.
                    for (int i = 0; i < EnumeratedLanguages.Length; i++) {
                        ListViewItem NewItem = new($"Item {EnumeratedLanguages[i].name}");
                        NewItem.SubItems[0].Text = $"{i + 1}: {EnumeratedLanguages[i].name} ({EnumeratedLanguages[i].size.SizeToString()})";
                        NewItem.UseItemStyleForSubItems = false;
                        NewItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                        NewItem.SubItems[1].Text = $"{EnumeratedLanguages[i].download_url}";
                        //NewItem.SubItems[1].Text = $"{EnumeratedLanguages[i].Sha}";
                        NewItem.SubItems[1].ForeColor = Color.FromKnownColor(KnownColor.ScrollBar);
                        NewItem.SubItems[1].Font = SubItemFont;
                        //NewItem.ToolTipText = EnumeratedLanguages[i].DownloadUrl;
                        lvAvailableLanguages.Items.Add(NewItem);
                    }
                }
            }
            catch (Exception ex) {
                Log.ReportException(ex);
            }
            if (Config.Settings.Initialization.firstTime) {
                btnCancel.Text = Language.InternalEnglish.GenericCancel;
                btnOk.Text = Language.InternalEnglish.GenericOk;
                btnDownloadSelected.Text = Language.InternalEnglish.sbDownload;
                this.Text = Language.InternalEnglish.frmDownloadLanguage;
            }
            else {
                btnCancel.Text = Program.lang.GenericCancel;
                btnOk.Text = Program.lang.GenericOk;
                btnDownloadSelected.Text = Program.lang.sbDownload;
                this.Text = Program.lang.frmDownloadLanguage;
            }
        }

        private void DownloadSelectedLanguageFile() {
            using System.Net.WebClient wc = new();
            string URL = EnumeratedLanguages[lvAvailableLanguages.SelectedIndices[0]].download_url;

            try {
                if (!System.IO.Directory.Exists(Environment.CurrentDirectory + "\\lang")) {
                    System.IO.Directory.CreateDirectory(Environment.CurrentDirectory + "\\lang");
                }

                wc.DownloadFile(URL, Environment.CurrentDirectory + "\\lang\\" + EnumeratedLanguages[lvAvailableLanguages.SelectedIndices[0]].name);

                // The SHA on github doesn't match what I can calculate here.
                //if (Program.CalculateSha1Hash(Environment.CurrentDirectory + "\\lang\\" + EnumeratedLanguages[listView1.SelectedIndices[0]].Name).ToLower() != EnumeratedLanguages[listView1.SelectedIndices[0]].Sha.ToLower()) {
                    //MessageBox.Show(Program.lang.dlgLanguageHashNoMatch, "youtube-dl-gui", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
            catch (System.Net.WebException wex) {
                if (Log.ReportRetriableException(wex, URL) == DialogResult.Retry) {
                    DownloadSelectedLanguageFile();
                }
            }
            catch (Exception ex) {
                if (Log.ReportRetriableException(ex) == DialogResult.Retry) {
                    DownloadSelectedLanguageFile();
                }
            }
        }

        private void btnDownloadSelected_Click(object sender, EventArgs e) {
            DownloadSelectedLanguageFile();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e) {
            if (lvAvailableLanguages.SelectedIndices.Count > 0) {
                DownloadSelectedLanguageFile();
                FileName = EnumeratedLanguages[lvAvailableLanguages.SelectedIndices[0]].name;
            }
            else {
                FileName = null;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
            btnOk.Enabled = lvAvailableLanguages.SelectedIndices.Count > 0;
            btnDownloadSelected.Enabled = lvAvailableLanguages.SelectedIndices.Count > 0;
        }
    }
}