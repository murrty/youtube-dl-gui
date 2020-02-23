using System;
using System.Collections.Generic;
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

        private List<string> DownloadUrls = new List<string>(); // List of urls to download
        private List<int> DownloadTypes = new List<int>();      // List of types to download
        private List<string> DownloadArgs = new List<string>(); // List of args to download
        private List<bool> DownloadCompleted = new List<bool>();// List of if the download in the index completed
        private List<bool> DownloadFailed = new List<bool>();   // List of if the download in the index failed
        private bool InProgress = false;                        // Bool if the batch download is in progress
        private int CurrentItem = -1;                           // Int of the current item being downloaded
        private frmDownloader Downloader;                       // The Downloader form that will be around. Will be disposed if aborted.

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
            sbBatchDownloadLoadArgs.Text = lang.sbBatchDownloadLoadArgs;
            mBatchDownloaderLoadArgsFromSettings.Text = lang.mBatchDownloaderLoadArgsFromSettings;
            mBatchDownloaderLoadArgsFromArgsTxt.Text = lang.mBatchDownloaderLoadArgsFromArgsTxt;
            mBatchDownloaderLoadArgsFromFile.Text = lang.mBatchDownloaderLoadArgsFromFile;
            btnBatchDownloadRemoveSelected.Text = lang.btnBatchDownloadRemoveSelected;
            btnBatchDownloadStartStopExit.Text = lang.btnBatchDownloadStart;
            sbBatchDownloader.Text = lang.sbBatchDownloaderIdle;
        }
        private void frmBatchDownloader_FormClosing(object sender, FormClosingEventArgs e) {
            if (lvBatchDownloadQueue.Items.Count > 0) {
                if (MessageBox.Show("You may have a queue active. Exit?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) {
                    e.Cancel = true;
                }
            }

            if (DownloaderThread != null && DownloaderThread.IsAlive) { DownloaderThread.Abort(); }
            if (DownloaderProcess != null && DownloaderProcess.Responding) { DownloaderProcess.Kill(); }

            this.Dispose();
        }

        private void btnBatchDownloadAdd_Click(object sender, EventArgs e) {
            if (cbBatchDownloadType.SelectedIndex < 0 && string.IsNullOrEmpty(txtBatchDownloadLink.Text)) {
                return;
            }

            ListViewItem lvi = new ListViewItem();
            lvi.Checked = false;

            lvi.Name = txtBatchDownloadLink.Text;
            lvi.SubItems[0].Text = txtBatchDownloadLink.Text;
            lvi.SubItems.Add(new ListViewItem.ListViewSubItem());
            lvi.SubItems.Add(new ListViewItem.ListViewSubItem());
            switch (cbBatchDownloadType.SelectedIndex) {
                case -1:
                    MessageBox.Show("Please select a download type");
                    return;
                case 0:
                    lvi.SubItems[1].Text = "Video";
                    DownloadTypes.Add(0);
                    break;
                case 1:
                    lvi.SubItems[1].Text = "Audio";
                    DownloadTypes.Add(1);
                    break;
                case 2:
                    lvi.SubItems[1].Text = "Custom...";
                    DownloadTypes.Add(2);
                    break;
            }
            if (txtBatchDownloadVideoSpecificArgument.Text == string.Empty) {
                lvi.SubItems[2].Text = string.Empty;
            }
            else {
                lvi.SubItems[2].Text = txtBatchDownloadVideoSpecificArgument.Text;
            }
            lvi.ImageIndex = (int)BatchDownloader.ConversionIcon.Waiting;
            DownloadArgs.Add(txtBatchDownloadVideoSpecificArgument.Text);
            DownloadUrls.Add(txtBatchDownloadLink.Text);
            lvBatchDownloadQueue.Items.Add(lvi);

            txtBatchDownloadLink.Clear();
        }

        private void btnBatchDownloadRemoveSelected_Click(object sender, EventArgs e) {
            if (lvBatchDownloadQueue.SelectedIndices.Count == 0) {
                return;
            }

            for (int i = lvBatchDownloadQueue.Items.Count - 1; i >= 0; i--) {
                if (lvBatchDownloadQueue.Items[i].Selected) {
                    lvBatchDownloadQueue.Items[i].Remove();
                    DownloadUrls.RemoveAt(i);
                    DownloadTypes.RemoveAt(i);
                    DownloadArgs.RemoveAt(i);
                    DownloadCompleted.RemoveAt(i);
                    DownloadFailed.RemoveAt(i);
                }
            }
        }

        private void btnBatchDownloadStartStopExit_Click(object sender, EventArgs e) {

        }

        [System.Diagnostics.DebuggerStepThrough]
        private void lvBatchDownloadQueue_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvBatchDownloadQueue.SelectedIndices.Count > 0) {
                btnBatchDownloadRemoveSelected.Enabled = true;
            }
            else {
                btnBatchDownloadRemoveSelected.Enabled = false;
            }
        }

        private void txtBatchDownloadLink_TextChanged(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtBatchDownloadLink.Text) || cbBatchDownloadType.SelectedIndex < 0) {
                btnBatchDownloadAdd.Enabled = false;
            }
            else {
                btnBatchDownloadAdd.Enabled = true;
            }
        }

        private void cbBatchDownloadType_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbBatchDownloadType.SelectedIndex > -1 && !string.IsNullOrEmpty(txtBatchDownloadLink.Text)) { btnBatchDownloadAdd.Enabled = true; }
        }
    }

    public class BatchDownloader {
        public enum ConversionIcon:int {
            Waiting = 0,
            Downloading = 1,
            Finished = 2,
            Errored = 3
        }
    }
}
