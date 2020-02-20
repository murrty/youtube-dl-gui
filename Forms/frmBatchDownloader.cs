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
    public partial class frmBatchDownloader : Form {
        Language lang = Language.GetInstance();
        public string argsText = string.Empty;

        public frmBatchDownloader() {
            InitializeComponent();
            LoadLanguage();
            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\args.txt")) {
                argsText = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\args.txt");

                if (argsText.Replace(" ", "") == "")
                    argsText = "<empty args.txt>";
            }
            else {
                argsText = "<args.txt unavailable>";
            }
        }

        void LoadLanguage() {
            this.Text = lang.frmBatchDownload;
            lbBatchDownloadLink.Text = lang.lbBatchDownloadLink;
            lbBatchDownloadType.Text = lang.lbBatchDownloadType;
            lbBatchVideoSpecificArgument.Text = lang.lbBatchDownloadVideoSpecificArgument;
            btnBatchDownloadAdd.Text = lang.btnBatchDownloadAdd;
            btnBatchDownloadRemoveSelected.Text = lang.btnBatchDownloadRemoveSelected;
            btnBatchDownloadStart.Text = lang.btnBatchDownloadStart;
        }

        private void btnBatchDownloadAdd_Click(object sender, EventArgs e) {
            if (cbBatchDownloadType.SelectedIndex < 0) {
                return;
            }

            listLink.Items.Add(txtBatchDownloadLink.Text);
            listType.Items.Add(cbBatchDownloadType.GetItemText(cbBatchDownloadType.SelectedItem));
            switch (cbBatchDownloadType.SelectedIndex) {
                case 2:
                    listArgs.Items.Add(argsText);
                    break;
                case 3:
                    if (Saved.Default.downloadArgs.Replace(" ", "") == "") {
                        listArgs.Items.Add("<saved args empty>");
                    }
                    else {
                        listArgs.Items.Add(Saved.Default.downloadArgs);
                    }
                    break;
                case 4:
                    listArgs.Items.Add(txtBatchDownloadVideoSpecificArgument.Text);
                    break;
                default:
                    listArgs.Items.Add("<n/a>");
                    break;
            }
            if (cbBatchDownloadType.SelectedIndex < 4) {
            }
            else {
            }

            txtBatchDownloadLink.Clear();
            txtBatchDownloadVideoSpecificArgument.Clear();
        }

        private void btnBatchDownloadRemoveSelected_Click(object sender, EventArgs e) {
            if (listLink.SelectedIndex == -1) {
                return;
            }

            int currentIndex = listLink.SelectedIndex;
            listLink.Items.RemoveAt(currentIndex);
            listType.Items.RemoveAt(currentIndex);
            listArgs.Items.RemoveAt(currentIndex);
            if (currentIndex + 1 > listLink.Items.Count) {
                listLink.SelectedIndex = currentIndex - 1;
            }
            else {
                listLink.SelectedIndex = currentIndex;
            }
        }

        private void btnBatchDownloadStart_Click(object sender, EventArgs e) {

        }

        private void listLink_SelectedIndexChanged(object sender, EventArgs e) {
            listType.SelectedIndex = listLink.SelectedIndex;
            listArgs.SelectedIndex = listLink.SelectedIndex;
        }
    }
}
