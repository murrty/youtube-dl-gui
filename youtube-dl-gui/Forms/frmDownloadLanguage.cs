using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmDownloadLanguage : Form {

        private readonly Font SubItemFont;
        private readonly List<GitLanguageFile> EnumeratedLanguages;
        private readonly List<bool> Downloaded = new();

        public string FileName { get; private set; }

        public frmDownloadLanguage() {
            InitializeComponent();
            NativeMethods.SetWindowTheme(listView1.Handle, "explorer", null);
            SubItemFont = new("Segoi UI", this.Font.Size, FontStyle.Italic);
            try {
                EnumeratedLanguages = GitData.Languages;
                if (EnumeratedLanguages.Count > 0) {
                    // Uncomment these out when the SHA calcuation gets fixed.
                    for (int i = 0; i < EnumeratedLanguages.Count; i++) {
                        ListViewItem NewItem = new($"Item {EnumeratedLanguages[i]}");
                        NewItem.SubItems[0].Text = $"{i + 1}: {EnumeratedLanguages[i].Name}";
                        NewItem.UseItemStyleForSubItems = false;
                        NewItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                        NewItem.SubItems[1].Text = $"{EnumeratedLanguages[i].DownloadUrl}";
                        //NewItem.SubItems[1].Text = $"{EnumeratedLanguages[i].Sha}";
                        NewItem.SubItems[1].ForeColor = Color.FromKnownColor(KnownColor.ScrollBar);
                        NewItem.SubItems[1].Font = SubItemFont;
                        //NewItem.ToolTipText = EnumeratedLanguages[i].DownloadUrl;
                        listView1.Items.Add(NewItem);
                        Downloaded.Add(System.IO.File.Exists(Environment.CurrentDirectory + "\\" + EnumeratedLanguages[i].Name));
                    }
                }
            }
            catch (Exception ex) {
                ErrorLog.Report(ex);
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
RetryDownload:
            try {
                if (!System.IO.Directory.Exists(Environment.CurrentDirectory + "\\lang")) {
                    System.IO.Directory.CreateDirectory(Environment.CurrentDirectory + "\\lang");
                }

                wc.DownloadFile(EnumeratedLanguages[listView1.SelectedIndices[0]].DownloadUrl, Environment.CurrentDirectory + "\\lang\\" + EnumeratedLanguages[listView1.SelectedIndices[0]].Name);

                // The SHA on github doesn't match what I can calculate here.
                //if (Program.CalculateSha1Hash(Environment.CurrentDirectory + "\\lang\\" + EnumeratedLanguages[listView1.SelectedIndices[0]].Name).ToLower() != EnumeratedLanguages[listView1.SelectedIndices[0]].Sha.ToLower()) {
                    //MessageBox.Show(Program.lang.dlgLanguageHashNoMatch, "youtube-dl-gui", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                Downloaded[listView1.SelectedIndices[0]] = true;
            }
            catch (System.Net.WebException wex) {
                using murrty.frmException ShowEx = new(new(wex) {
                    AllowRetry = true
                });

                if (ShowEx.ShowDialog() == DialogResult.Retry) {
                    goto RetryDownload;
                }
            }
            catch (Exception ex) {
                using murrty.frmException ShowEx = new(new(ex) {
                    AllowRetry = true
                });

                if (ShowEx.ShowDialog() == DialogResult.Retry) {
                    goto RetryDownload;
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
            if (listView1.SelectedIndices.Count > 0) {
                if (!Downloaded[listView1.SelectedIndices[0]]) {
                    DownloadSelectedLanguageFile();
                }
                FileName = EnumeratedLanguages[listView1.SelectedIndices[0]].Name;
            }
            else {
                FileName = null;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
            btnOk.Enabled = listView1.SelectedIndices.Count > 0;
            btnDownloadSelected.Enabled = listView1.SelectedIndices.Count > 0;
        }
    }
}