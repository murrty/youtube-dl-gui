using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmBatchDownloader : Form {
        Language lang = Language.GetInstance();

        public string argsText = string.Empty;
        public bool Debugging = false;

        private List<string> DownloadUrls = new List<string>(); // List of urls to download
        private List<int> DownloadTypes = new List<int>();      // List of types to download
        private List<string> DownloadArgs = new List<string>(); // List of args to download
        private bool InProgress = false;                        // Bool if the batch download is in progress
        private int CurrentItem = -1;                           // Int of the current item being downloaded
        private Thread DownloaderThread;                                // The thread for the downloader
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
            btnBatchDownloadStartStopExit.Enabled = true;
        }
        private void sbBatchDownloadLoadArgs_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(Saved.Default.downloadArgs)) {
                txtBatchDownloadVideoSpecificArgument.Text = Saved.Default.downloadArgs;
                return;
            }

            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\args.txt")) {
                string ArgsBuffer = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\args.txt");
                if (!string.IsNullOrEmpty(ArgsBuffer)) {
                    txtBatchDownloadVideoSpecificArgument.Text = ArgsBuffer;
                    return;
                }
            }
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = "Select a file to read as arguments";
                ofd.Filter = "All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK) {
                    if (System.IO.File.Exists(ofd.FileName)) {
                        txtBatchDownloadVideoSpecificArgument.Text = System.IO.File.ReadAllText(ofd.FileName).Trim(' ').Replace('\n', ' ').Trim(' ');
                    }
                }
            }
        }
        private void mBatchDownloaderLoadArgsFromSettings_Click(object sender, EventArgs e) {
            txtBatchDownloadVideoSpecificArgument.Text = Saved.Default.downloadArgs;
        }
        private void mBatchDownloaderLoadArgsFromArgsTxt_Click(object sender, EventArgs e) {
            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\args.txt")) { txtBatchDownloadVideoSpecificArgument.Text = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\args.txt"); }
        }
        private void mBatchDownloaderLoadArgsFromFile_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = "Select a file to read as arguments";
                ofd.Filter = "All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK) {
                    if (System.IO.File.Exists(ofd.FileName)) {
                        txtBatchDownloadVideoSpecificArgument.Text = System.IO.File.ReadAllText(ofd.FileName).Trim(' ').Replace('\n', ' ').Trim(' ');
                    }
                }
            }
        }
        private void btnBatchDownloadRemoveSelected_Click(object sender, EventArgs e) {
            if (lvBatchDownloadQueue.SelectedIndices.Count == 0 || InProgress) {
                return;
            }

            for (int i = lvBatchDownloadQueue.Items.Count - 1; i >= 0; i--) {
                if (lvBatchDownloadQueue.Items[i].Selected) {
                    lvBatchDownloadQueue.Items[i].Remove();
                    DownloadUrls.RemoveAt(i);
                    DownloadTypes.RemoveAt(i);
                    DownloadArgs.RemoveAt(i);
                }
            }

            if (lvBatchDownloadQueue.Items.Count == 0) {
                btnBatchDownloadStartStopExit.Enabled = false;
            }
        }

        private void btnBatchDownloadStartStopExit_Click(object sender, EventArgs e) {
            if (DownloadUrls.Count == 0) { return; }
            if (InProgress) {
                //if (DownloaderThread != null) {
                //    DownloaderThread.Abort();
                //}
                Downloader.Dispose();
            }
            else if (lvBatchDownloadQueue.Items.Count > 0) {
                btnBatchDownloadRemoveSelected.Enabled = false;
                btnBatchDownloadStartStopExit.Text = lang.btnBatchDownloadStop;
                InProgress = true;
                string BatchTime = "\\" + BatchDownloader.CurrentTime();
                for (int i = 0; i < DownloadUrls.Count; i++) {
                    CurrentItem = i;
                    Downloader = new frmDownloader();
                    Downloader.BatchDownload = true;
                    Downloader.DownloadUrl = DownloadUrls[i];
                    Downloader.DownloadPath = Downloads.Default.downloadPath;
                    Downloader.BatchTime += BatchTime;
                    switch (DownloadTypes[i]) {
                        case 0:
                            Downloader.DownloadQuality = Saved.Default.videoQuality;
                            Downloader.DownloadType = 0;
                            break;
                        case 1:
                            Downloader.DownloadQuality = Saved.Default.audioQuality;
                            Downloader.DownloadType = 1;
                            break;
                        case 2:
                            Downloader.DownloadArguments = DownloadArgs[i];
                            Downloader.DownloadType = 2;
                            break;
                        default:
                            continue;
                    }
                    lvBatchDownloadQueue.Items[i].ImageIndex = (int)BatchDownloader.ConversionIcon.Downloading;

                    bool AbortDownload = false;
                    switch (Downloader.ShowDialog()) {
                        case System.Windows.Forms.DialogResult.Yes:
                            lvBatchDownloadQueue.Items[i].ImageIndex = (int)BatchDownloader.ConversionIcon.Finished;
                            break;
                        case System.Windows.Forms.DialogResult.No:
                            lvBatchDownloadQueue.Items[i].ImageIndex = (int)BatchDownloader.ConversionIcon.Errored;
                            break;
                        case System.Windows.Forms.DialogResult.Abort:
                            lvBatchDownloadQueue.Items[i].ImageIndex = (int)BatchDownloader.ConversionIcon.Waiting;
                            AbortDownload = true;
                            break;
                        default:
                            lvBatchDownloadQueue.Items[i].ImageIndex = (int)BatchDownloader.ConversionIcon.Finished;
                            break;
                    }
                    if (AbortDownload) { break; }
                }
                InProgress = false;
                btnBatchDownloadStartStopExit.Text = lang.btnBatchDownloadStart;
            }
        }

        [System.Diagnostics.DebuggerStepThrough]
        private void lvBatchDownloadQueue_SelectedIndexChanged(object sender, EventArgs e) {
            //cbBatchDownloadType.SelectedIndexChanged -= cbBatchDownloadType_SelectedIndexChanged;
            if (lvBatchDownloadQueue.SelectedIndices.Count > 0) {
                //btnBatchDownloadRemoveSelected.Enabled = true;
                //if (lvBatchDownloadQueue.SelectedIndices.Count > 1) {
                //    cbBatchDownloadType.SelectedIndex = -1;
                //}
                //else {
                //    for (int i = lvBatchDownloadQueue.Items.Count - 1; i >= 0; i--) {
                //        if (lvBatchDownloadQueue.Items[i].Selected) {
                //            cbBatchDownloadType.SelectedIndex = cbBatchDownloadType.Items.IndexOf(lvBatchDownloadQueue.Items[i].SubItems[1].Text);
                //        }
                //    }
                //}
                if (!InProgress) {
                    btnBatchDownloadRemoveSelected.Enabled = true;
                }
            }
            else {
                btnBatchDownloadRemoveSelected.Enabled = false;
            }
            //cbBatchDownloadType.SelectedIndexChanged += cbBatchDownloadType_SelectedIndexChanged;
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

            if (lvBatchDownloadQueue.SelectedItems.Count > 0) {
                for (int i = 0; i < lvBatchDownloadQueue.SelectedItems.Count; i++) {
                    lvBatchDownloadQueue.SelectedItems[i].SubItems[1].Text = cbBatchDownloadType.GetItemText(cbBatchDownloadType.SelectedItem);
                }
            }
        }
    }

    public class BatchDownloader {
        public enum ConversionIcon : int {
            Waiting = 0,
            Downloading = 1,
            Finished = 2,
            Errored = 3
        }

        public static string CurrentTime() {
            string DateTimeBuffer = string.Empty;
            DateTimeBuffer += DateTime.Now.Year + "_";
            if (DateTime.Now.Month < 10) { DateTimeBuffer += "0"; }
            DateTimeBuffer += DateTime.Now.Month + "_";

            if (DateTime.Now.Day < 10) { DateTimeBuffer += "0"; }
            DateTimeBuffer += DateTime.Now.Day + "-";

            if (DateTime.Now.Hour < 10) { DateTimeBuffer += "0"; }
            DateTimeBuffer += DateTime.Now.Hour + "_";

            if (DateTime.Now.Minute < 10) { DateTimeBuffer += "0"; }
            DateTimeBuffer += DateTime.Now.Minute + "_";

            if (DateTime.Now.Second < 10) { DateTimeBuffer += "0"; }
            DateTimeBuffer += DateTime.Now.Second;

            return DateTimeBuffer;
        }
    }
}