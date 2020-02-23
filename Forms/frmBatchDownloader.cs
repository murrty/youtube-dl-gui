using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmBatchDownloader : Form {
        Language lang = Language.GetInstance();
        Thread DownloaderThread = null;
        Process DownloaderProcess = null;

        public string argsText = string.Empty;
        public bool Debugging = false;

        public frmBatchDownloader() {
            InitializeComponent();
            LoadLanguage();
            if (argsText != string.Empty) {
                txtBatchDownloadVideoSpecificArgument.Text = argsText;
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
        private void frmBatchDownloader_FormClosing(object sender, FormClosingEventArgs e) {
            if (vistaListView1.Items.Count > 0) {
                if (MessageBox.Show("You may have a queue active. Exit?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) {
                    e.Cancel = true;
                }
            }

            if (DownloaderThread != null && DownloaderThread.IsAlive) { DownloaderThread.Abort(); }
            if (DownloaderProcess != null && DownloaderProcess.Responding) { DownloaderProcess.Kill(); }

            this.Dispose();
        }

        private void btnBatchDownloadAdd_Click(object sender, EventArgs e) {
            if (cbBatchDownloadType.SelectedIndex < 0) {
                return;
            }

            ListViewItem lvi = new ListViewItem();
            lvi.Checked = false;

            lvi.Name = "";
            lvi.SubItems[0].Text = txtBatchDownloadLink.Text;
            lvi.SubItems.Add(new ListViewItem.ListViewSubItem());
            lvi.SubItems.Add(new ListViewItem.ListViewSubItem());
            switch (cbBatchDownloadType.SelectedIndex) {
                case -1:
                    MessageBox.Show("Please select a download type");
                    return;
                case 0:
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem());
                    lvi.SubItems[1].Text = "Video";
                    break;
                case 1:
                    lvi.SubItems[1].Text = "Audio";
                    break;
                case 2:
                    lvi.SubItems[1].Text = "Custom...";
                    break;
            }
            if (txtBatchDownloadVideoSpecificArgument.Text == string.Empty) {
                lvi.SubItems[2].Text = string.Empty;
            }
            else {
                lvi.SubItems[2].Text = txtBatchDownloadVideoSpecificArgument.Text;
            }

            vistaListView1.Items.Add(lvi);

            txtBatchDownloadLink.Clear();
            txtBatchDownloadVideoSpecificArgument.Clear();
        }

        private void btnBatchDownloadRemoveSelected_Click(object sender, EventArgs e) {
            //if (vistaListView1.SelectedIndex == -1) {
            //    return;
            //}

            //int currentIndex = vistaListView1.SelectedIndices;
            //vistaListView1.Items.RemoveAt(currentIndex);
            //vistaListView1.Items.RemoveAt(currentIndex);
            //vistaListView1.Items.RemoveAt(currentIndex);
            //if (currentIndex + 1 > vistaListView1.Items.Count) {
            //    vistaListView1.SelectedIndex = currentIndex - 1;
            //}
            //else {
            //    vistaListView1.SelectedIndex = currentIndex;
            //}
        }

        private void btnBatchDownloadStart_Click(object sender, EventArgs e) {

        }

        private void listLink_SelectedIndexChanged(object sender, EventArgs e) {
            
        }

    }
}
