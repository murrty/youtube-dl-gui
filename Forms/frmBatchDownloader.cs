using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmBatchDownloader : Form {
        Language lang = Language.GetInstance();

        public string argsText = string.Empty;
        public bool Debugging = false;

        private List<int> DownloadTypes = new List<int>();      // List of types to download
        private List<string> DownloadUrls = new List<string>(); // List of urls to download
        private List<string> DownloadArgs = new List<string>(); // List of args to download
        private List<int> DownloadQuality = new List<int>();    // List of the quality
        private List<int> DownloadFormat = new List<int>();     // List of the formats
        private List<bool> DownloadSoundVBR = new List<bool>(); // List of if sound/vbr should be downloaded
        private bool InProgress = false;                        // Bool if the batch download is in progress
        private int CurrentItem = -1;                           // Int of the current item being downloaded
        private frmDownloader Downloader;                       // The Downloader form that will be around. Will be disposed if aborted.

        public frmBatchDownloader() {
            InitializeComponent();
            LoadLanguage();
            if (argsText != string.Empty) {
                txtBatchDownloadVideoSpecificArgument.Text = argsText;
            }
            this.Icon = Properties.Resources.youtube_dl_gui;
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
            lvBatchDownloadQueue.Columns[1].Text = lang.lbBatchDownloadType;
            lvBatchDownloadQueue.Columns[2].Text = lang.lbBatchDownloadVideoSpecificArgument;
            cbBatchDownloadType.Items.Add(lang.GenericVideo);
            cbBatchDownloadType.Items.Add(lang.GenericAudio);
            cbBatchDownloadType.Items.Add(lang.GenericCustom);
        }
        private void frmBatchDownloader_Load(object sender, EventArgs e) {
            cbBatchDownloadType.SelectedIndex = Batch.Default.SelectedType;
            if (Batch.Default.SelectedType == 0) {
                 chkBatchDownloaderSoundVBR.Checked = Batch.Default.DownloadVideoSound;
                 cbBatchQuality.SelectedIndex = Batch.Default.SelectedVideoQuality;
                 cbBatchFormat.SelectedIndex = Batch.Default.SelectedVideoFormat;
            }
            else if (Batch.Default.SelectedType == 1) {
                if (Batch.Default.DownloadAudioVBR) {
                    chkBatchDownloaderSoundVBR.Checked = true;
                    cbBatchQuality.SelectedIndex = Batch.Default.SelectedAudioQualityVBR;
                }
                else {
                    chkBatchDownloaderSoundVBR.Checked = false;
                    cbBatchQuality.SelectedIndex = Batch.Default.SelectedAudioQuality;
                }
                cbBatchFormat.SelectedIndex = Batch.Default.SelectedAudioFormat;
            }
            else if (Batch.Default.SelectedType == 2) {
                txtBatchDownloadVideoSpecificArgument.Text = Batch.Default.CustomArguments;
            }

            if (Saved.Default.BatchFormX != -999999 && Saved.Default.BatchFormY != -999999) {
                this.Location = new System.Drawing.Point(Saved.Default.BatchFormX, Saved.Default.BatchFormY);
            }
        }
        private void frmBatchDownloader_FormClosing(object sender, FormClosingEventArgs e) {
            Saved.Default.BatchFormX = this.Location.X;
            Saved.Default.BatchFormY = this.Location.Y;
            if (!Program.IsPortable) {
                Saved.Default.Save();
            }
            this.Dispose();
        }

        private void txtBatchDownloadLink_TextChanged(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtBatchDownloadLink.Text) || cbBatchDownloadType.SelectedIndex < 0) {
                btnBatchDownloadAdd.Enabled = false;
            }
            else {
                btnBatchDownloadAdd.Enabled = true;
            }
        }
        private void txtBatchDownloadLink_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) { AddItemToList(); }
        }
        private void btnBatchDownloadAdd_Click(object sender, EventArgs e) {
            AddItemToList();
        }
        private void btnBatchDownloadRemoveSelected_Click(object sender, EventArgs e) {
            RemoveItemsFromList();
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
        private void lvBatchDownloadQueue_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control && e.KeyCode == Keys.A) {
                for (int i = 0; i < lvBatchDownloadQueue.Items.Count; i++) { lvBatchDownloadQueue.Items[i].Selected = true; }
            }
        }
        private void lvBatchDownloadQueue_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyValue == 46) {
                RemoveItemsFromList();
            }
        }
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
        private void chkBatchDownloaderSoundVBR_CheckedChanged(object sender, EventArgs e) {
            if (cbBatchDownloadType.SelectedIndex == 1) {
                cbBatchQuality.SelectedIndex = -1;
                cbBatchQuality.Items.Clear();
                if (chkBatchDownloaderSoundVBR.Checked) {
                    cbBatchQuality.Items.AddRange(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
                    cbBatchQuality.SelectedIndex = Batch.Default.SelectedAudioQualityVBR;
                }
                else {
                    cbBatchQuality.Items.AddRange(DownloadFormats.AudioQualityNamesArray);
                    cbBatchQuality.SelectedIndex = Batch.Default.SelectedAudioQualityVBR;
                }
            }
        }
        private void cbBatchDownloadType_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbBatchDownloadType.SelectedIndex == -1)
                return;

            if (!string.IsNullOrEmpty(txtBatchDownloadLink.Text)) {
                btnBatchDownloadAdd.Enabled = true;
            }

            cbBatchQuality.SelectedIndex = -1;
            cbBatchFormat.SelectedIndex = -1;
            cbBatchQuality.Items.Clear();
            cbBatchFormat.Items.Clear();

            switch (cbBatchDownloadType.SelectedIndex) {
                case 0:
                    txtBatchDownloadVideoSpecificArgument.Visible = false;
                    cbBatchQuality.Visible = true;
                    cbBatchQuality.Enabled = true;
                    cbBatchQuality.Items.AddRange(DownloadFormats.VideoQualityArray);
                    cbBatchFormat.Visible = true;
                    cbBatchFormat.Enabled = true;
                    cbBatchFormat.Items.AddRange(DownloadFormats.VideoFormatsNamesArray);
                    chkBatchDownloaderSoundVBR.Text = lang.chkDownloadSound;
                    chkBatchDownloaderSoundVBR.Enabled = true;
                    cbBatchQuality.SelectedIndex = Batch.Default.SelectedVideoQuality;
                    cbBatchFormat.SelectedIndex = Batch.Default.SelectedVideoFormat;
                    chkBatchDownloaderSoundVBR.Checked = Batch.Default.DownloadVideoSound;
                    chkBatchDownloaderSoundVBR.Visible = true;
                    break;
                case 1:
                    txtBatchDownloadVideoSpecificArgument.Visible = false;
                    cbBatchQuality.Visible = true;
                    cbBatchQuality.Enabled = true;
                    cbBatchFormat.Visible = true;
                    cbBatchFormat.Enabled = true;
                    cbBatchFormat.Items.AddRange(DownloadFormats.AudioFormatsArray);
                    chkBatchDownloaderSoundVBR.Text = "VBR";
                    chkBatchDownloaderSoundVBR.Enabled = true;
                    if (Batch.Default.DownloadAudioVBR) {
                        cbBatchQuality.Items.AddRange(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
                        cbBatchQuality.SelectedIndex = Batch.Default.SelectedAudioQuality;
                    }
                    else {
                        cbBatchQuality.Items.AddRange(DownloadFormats.AudioQualityNamesArray);
                        cbBatchQuality.SelectedIndex = Batch.Default.SelectedAudioQualityVBR;
                    }
                    cbBatchFormat.SelectedIndex = Batch.Default.SelectedAudioFormat;
                    chkBatchDownloaderSoundVBR.Checked = Batch.Default.DownloadAudioVBR;
                    chkBatchDownloaderSoundVBR.Visible = true;
                    break;
                case 2:
                    txtBatchDownloadVideoSpecificArgument.Visible = true;
                    cbBatchFormat.Visible = false;
                    cbBatchQuality.Visible = false;
                    cbBatchFormat.Enabled = false;
                    cbBatchQuality.Enabled = false;
                    chkBatchDownloaderSoundVBR.Enabled = false;
                    chkBatchDownloaderSoundVBR.Checked = false;
                    chkBatchDownloaderSoundVBR.Visible = false;
                    break;
            }

            //if (lvBatchDownloadQueue.SelectedItems.Count > 0) {
            //    for (int i = 0; i < lvBatchDownloadQueue.SelectedItems.Count; i++) {
            //        lvBatchDownloadQueue.SelectedItems[i].SubItems[1].Text = cbBatchDownloadType.GetItemText(cbBatchDownloadType.SelectedItem);
            //    }
            //}
        }
        private void btnBatchDownloadStartStopExit_Click(object sender, EventArgs e) {
            if (Program.IsDebug) {
                Batch.Default.SelectedType = cbBatchDownloadType.SelectedIndex;
                if (cbBatchDownloadType.SelectedIndex == 0) {
                    Batch.Default.DownloadVideoSound = chkBatchDownloaderSoundVBR.Checked;
                    Batch.Default.SelectedVideoQuality = cbBatchQuality.SelectedIndex;
                    Batch.Default.SelectedVideoFormat = cbBatchFormat.SelectedIndex;
                }
                else if (cbBatchDownloadType.SelectedIndex == 1) {
                    if (chkBatchDownloaderSoundVBR.Checked) {
                        Batch.Default.DownloadAudioVBR = true;
                        Batch.Default.SelectedAudioQualityVBR = cbBatchQuality.SelectedIndex;
                    }
                    else {
                        Batch.Default.DownloadAudioVBR = false;
                        Batch.Default.SelectedAudioQuality = cbBatchQuality.SelectedIndex;
                    }
                    Batch.Default.SelectedAudioFormat = cbBatchFormat.SelectedIndex;
                }
                else if (cbBatchDownloadType.SelectedIndex == 2) {
                    Batch.Default.CustomArguments = txtBatchDownloadVideoSpecificArgument.Text;
                }
                if (!Program.IsPortable) {
                    Batch.Default.Save();
                }
            }

            if (DownloadUrls.Count == 0) { return; }
            if (InProgress) {
                Downloader.Dispose();
            }
            else if (lvBatchDownloadQueue.Items.Count > 0) {
                btnBatchDownloadRemoveSelected.Enabled = false;
                btnBatchDownloadStartStopExit.Text = lang.btnBatchDownloadStop;
                InProgress = true;
                string BatchTime = "\\# Batch Downloads #" + BatchDownloader.CurrentTime();
                for (int i = 0; i < DownloadUrls.Count; i++) {
                    CurrentItem = i;
                    Downloader = new frmDownloader();
                    Downloader.BatchDownload = true;
                    Downloader.BatchTime += BatchTime;
                    Downloader.DownloadUrl = DownloadUrls[i];
                    Downloader.DownloadPath = Downloads.Default.downloadPath;
                    if (DownloadTypes[i] != 2) {
                        Downloader.DownloadQuality = DownloadQuality[i];
                        Downloader.DownloadFormat = DownloadFormat[i];
                    }
                    switch (DownloadTypes[i]) {
                        case 0:
                            Downloader.DownloadVideoAudio = DownloadSoundVBR[i];
                            Downloader.DownloadType = 0;
                            break;
                        case 1:
                            Downloader.DownloadType = 1;
                            Downloader.UseVBR = DownloadSoundVBR[i];
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
                    sbBatchDownloader.Text = lang.sbBatchDownloaderDownloading;
                    switch (Downloader.ShowDialog()) {
                        case System.Windows.Forms.DialogResult.Yes:
                            lvBatchDownloadQueue.Items[i].ImageIndex = (int)BatchDownloader.ConversionIcon.Finished;
                            break;
                        case System.Windows.Forms.DialogResult.No:
                            lvBatchDownloadQueue.Items[i].ImageIndex = (int)BatchDownloader.ConversionIcon.Errored;
                            break;
                        case System.Windows.Forms.DialogResult.Abort:
                            lvBatchDownloadQueue.Items[i].ImageIndex = (int)BatchDownloader.ConversionIcon.Waiting;
                            break;
                        case System.Windows.Forms.DialogResult.Ignore:
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
                System.Media.SystemSounds.Exclamation.Play();
                sbBatchDownloader.Text = lang.sbBatchDownloaderFinished;
                btnBatchDownloadStartStopExit.Text = lang.btnBatchDownloadStart;
            }
        }

        private void AddItemToList() {
            if (!string.IsNullOrEmpty(txtBatchDownloadLink.Text) && cbBatchDownloadType.SelectedIndex != -1) {
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
                if (cbBatchDownloadType.SelectedIndex != 2) {
                    if (cbBatchDownloadType.SelectedIndex == 0) {
                        if (chkBatchDownloaderSoundVBR.Checked) {
                            lvi.SubItems[2].Text = cbBatchQuality.GetItemText(cbBatchQuality.SelectedItem) + ", " + cbBatchFormat.GetItemText(cbBatchFormat.SelectedItem) + ", sound";
                        }
                        else {
                            lvi.SubItems[2].Text = cbBatchQuality.GetItemText(cbBatchQuality.SelectedItem) + ", " + cbBatchFormat.GetItemText(cbBatchFormat.SelectedItem) + ", no sound";
                        }
                    }
                    else if (cbBatchDownloadType.SelectedIndex == 1) {
                        if (chkBatchDownloaderSoundVBR.Checked) {
                            lvi.SubItems[2].Text = cbBatchQuality.GetItemText(cbBatchQuality.SelectedItem) + ", " + cbBatchFormat.GetItemText(cbBatchFormat.SelectedItem) + ", vbr";
                        }
                        else {
                            lvi.SubItems[2].Text = cbBatchQuality.GetItemText(cbBatchQuality.SelectedItem) + ", " + cbBatchFormat.GetItemText(cbBatchFormat.SelectedItem) + ", no vbr";
                        }
                    }
                }
                else {
                    lvi.SubItems[2].Text = txtBatchDownloadVideoSpecificArgument.Text;
                }
                lvi.ImageIndex = (int)BatchDownloader.ConversionIcon.Waiting;
                DownloadArgs.Add(txtBatchDownloadVideoSpecificArgument.Text);
                DownloadUrls.Add(txtBatchDownloadLink.Text);
                DownloadQuality.Add(cbBatchQuality.SelectedIndex);
                DownloadFormat.Add(cbBatchFormat.SelectedIndex);
                DownloadSoundVBR.Add(chkBatchDownloaderSoundVBR.Checked);
                lvBatchDownloadQueue.Items.Add(lvi);

                txtBatchDownloadLink.Clear();
                btnBatchDownloadStartStopExit.Enabled = true;
            }
        }
        private void RemoveItemsFromList() {
            if (lvBatchDownloadQueue.SelectedIndices.Count == 0 || InProgress) {
                return;
            }

            for (int i = lvBatchDownloadQueue.Items.Count - 1; i >= 0; i--) {
                if (lvBatchDownloadQueue.Items[i].Selected) {
                    lvBatchDownloadQueue.Items[i].Remove();
                    DownloadUrls.RemoveAt(i);
                    DownloadTypes.RemoveAt(i);
                    DownloadArgs.RemoveAt(i);
                    DownloadQuality.RemoveAt(i);
                    DownloadFormat.RemoveAt(i);
                    DownloadSoundVBR.RemoveAt(i);
                }
            }

            if (lvBatchDownloadQueue.Items.Count == 0) {
                btnBatchDownloadStartStopExit.Enabled = false;
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

            return "\\" + DateTimeBuffer;
        }
    }
}