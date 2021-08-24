using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmBatchDownloader : Form {

        Language lang = Language.GetInstance();

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
        private DownloadInfo NewInfo;                           // The info of the download

        public frmBatchDownloader() {
            InitializeComponent();
            LoadLanguage();
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
            cbBatchDownloadType.SelectedIndex = Config.Settings.Batch.SelectedType;
            if (Config.Settings.Batch.SelectedType == 0) {
                chkBatchDownloaderSoundVBR.Checked = Config.Settings.Batch.DownloadVideoSound;
                cbBatchQuality.SelectedIndex = Config.Settings.Batch.SelectedVideoQuality;
                cbBatchFormat.SelectedIndex = Config.Settings.Batch.SelectedVideoFormat;
            }
            else if (Config.Settings.Batch.SelectedType == 1) {
                if (Config.Settings.Batch.DownloadAudioVBR) {
                    chkBatchDownloaderSoundVBR.Checked = true;
                    cbBatchQuality.SelectedIndex = Config.Settings.Batch.SelectedAudioQualityVBR;
                }
                else {
                    chkBatchDownloaderSoundVBR.Checked = false;
                    cbBatchQuality.SelectedIndex = Config.Settings.Batch.SelectedAudioQuality;
                }
                cbBatchFormat.SelectedIndex = Config.Settings.Batch.SelectedAudioFormat;
            }


            if (Config.Settings.Saved.BatchFormX != -32000 && Config.Settings.Saved.BatchFormY != -32000) {
                this.Location = new System.Drawing.Point(Config.Settings.Saved.BatchFormX, Config.Settings.Saved.BatchFormY);
            }
        }
        private void frmBatchDownloader_FormClosing(object sender, FormClosingEventArgs e) {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Opacity = 0;
                this.WindowState = FormWindowState.Normal;
            }
            Config.Settings.Saved.BatchFormX = this.Location.X;
            Config.Settings.Saved.BatchFormY = this.Location.Y;
            if (!Program.UseIni) {
                Config.Settings.Saved.Save();
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
            if (!string.IsNullOrEmpty(Config.Settings.Saved.DownloadCustomArguments)) {
                cbArguments.Items.AddRange(Config.Settings.Saved.DownloadCustomArguments.Split('|'));
                cbArguments.SelectedIndex = Config.Settings.Saved.CustomArgumentsIndex;
            }

            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\args.txt")) {
                cbArguments.Items.AddRange(System.IO.File.ReadAllLines(Environment.CurrentDirectory + "\\args.txt"));
                if (Config.Settings.Saved.CustomArgumentsIndex > -1 && Config.Settings.Saved.CustomArgumentsIndex <= cbArguments.Items.Count) {
                    cbArguments.SelectedIndex = Config.Settings.Saved.CustomArgumentsIndex;
                }
            }
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = "Select a file to read as arguments";
                ofd.Filter = "All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK) {
                    if (System.IO.File.Exists(ofd.FileName)) {
                        cbArguments.Text = System.IO.File.ReadAllText(ofd.FileName).Trim(' ').Replace('\n', ' ').Trim(' ');
                    }
                }
            }
        }
        private void mBatchDownloaderLoadArgsFromSettings_Click(object sender, EventArgs e) {
            cbArguments.Items.AddRange(Config.Settings.Saved.DownloadCustomArguments.Split('|'));
            cbArguments.SelectedIndex = Config.Settings.Saved.CustomArgumentsIndex;
        }
        private void mBatchDownloaderLoadArgsFromArgsTxt_Click(object sender, EventArgs e) {
            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\args.txt")) {
                cbArguments.Items.AddRange(System.IO.File.ReadAllLines(Environment.CurrentDirectory + "\\args.txt"));
                if (Config.Settings.Saved.CustomArgumentsIndex > -1 && Config.Settings.Saved.CustomArgumentsIndex <= cbArguments.Items.Count) {
                    cbArguments.SelectedIndex = Config.Settings.Saved.CustomArgumentsIndex;
                }
            }
        }
        private void mBatchDownloaderLoadArgsFromFile_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = "Select a file to read as arguments";
                ofd.Filter = "All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK) {
                    if (System.IO.File.Exists(ofd.FileName)) {
                        cbArguments.Text = System.IO.File.ReadAllText(ofd.FileName).Trim(' ').Replace('\n', ' ').Trim(' ');
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
                    cbBatchQuality.SelectedIndex = Config.Settings.Batch.SelectedAudioQualityVBR;
                }
                else {
                    cbBatchQuality.Items.AddRange(DownloadFormats.AudioQualityNamesArray);
                    cbBatchQuality.SelectedIndex = Config.Settings.Batch.SelectedAudioQualityVBR;
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
                    cbArguments.Visible = false;
                    cbBatchQuality.Visible = true;
                    cbBatchQuality.Enabled = true;
                    cbBatchQuality.Items.AddRange(DownloadFormats.VideoQualityArray);
                    cbBatchFormat.Visible = true;
                    cbBatchFormat.Enabled = true;
                    cbBatchFormat.Items.AddRange(DownloadFormats.VideoFormatsNamesArray);
                    chkBatchDownloaderSoundVBR.Text = lang.chkDownloadSound;
                    chkBatchDownloaderSoundVBR.Enabled = true;
                    cbBatchQuality.SelectedIndex = Config.Settings.Batch.SelectedVideoQuality;
                    cbBatchFormat.SelectedIndex = Config.Settings.Batch.SelectedVideoFormat;
                    chkBatchDownloaderSoundVBR.Checked = Config.Settings.Batch.DownloadVideoSound;
                    chkBatchDownloaderSoundVBR.Visible = true;
                    break;
                case 1:
                    cbArguments.Visible = false;
                    cbBatchQuality.Visible = true;
                    cbBatchQuality.Enabled = true;
                    cbBatchFormat.Visible = true;
                    cbBatchFormat.Enabled = true;
                    cbBatchFormat.Items.AddRange(DownloadFormats.AudioFormatsArray);
                    chkBatchDownloaderSoundVBR.Text = "VBR";
                    chkBatchDownloaderSoundVBR.Enabled = true;
                    if (Config.Settings.Batch.DownloadAudioVBR) {
                        cbBatchQuality.Items.AddRange(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
                        cbBatchQuality.SelectedIndex = Config.Settings.Batch.SelectedAudioQuality;
                    }
                    else {
                        cbBatchQuality.Items.AddRange(DownloadFormats.AudioQualityNamesArray);
                        cbBatchQuality.SelectedIndex = Config.Settings.Batch.SelectedAudioQualityVBR;
                    }
                    cbBatchFormat.SelectedIndex = Config.Settings.Batch.SelectedAudioFormat;
                    chkBatchDownloaderSoundVBR.Checked = Config.Settings.Batch.DownloadAudioVBR;
                    chkBatchDownloaderSoundVBR.Visible = true;
                    break;
                case 2:
                    cbArguments.Visible = true;
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
            if (DownloadUrls.Count == 0) { return; }
            if (InProgress) {
                Downloader.Dispose();
            }
            else if (lvBatchDownloadQueue.Items.Count > 0) {
                btnBatchDownloadRemoveSelected.Enabled = false;
                btnBatchDownloadStartStopExit.Text = lang.btnBatchDownloadStop;
                InProgress = true;
                string BatchTime = BatchDownloader.CurrentTime();
                for (int i = 0; i < DownloadUrls.Count; i++) {
                    CurrentItem = i;
                    Downloader = new frmDownloader();
                    NewInfo = new DownloadInfo();
                    NewInfo.BatchDownload = true;
                    NewInfo.BatchTime = BatchTime;
                    NewInfo.DownloadURL = DownloadUrls[i];
                    switch (DownloadTypes[i]) {
                        case 0:
                            NewInfo.Type = DownloadType.Video;
                            NewInfo.VideoQuality = (VideoQualityType)DownloadQuality[i];
                            NewInfo.VideoFormat = (VideoFormatType)DownloadFormat[i];
                            NewInfo.SkipAudioForVideos = !DownloadSoundVBR[i];
                            break;
                        case 1:
                            NewInfo.Type = DownloadType.Audio;
                            if (DownloadSoundVBR[i]) {
                                NewInfo.UseVBR = true;
                                NewInfo.AudioVBRQuality = (AudioVBRQualityType)DownloadQuality[i];
                            }
                            else {
                                NewInfo.UseVBR = false;
                                NewInfo.AudioCBRQuality = (AudioCBRQualityType)DownloadQuality[i];
                            }
                            NewInfo.AudioFormat = (AudioFormatType)DownloadFormat[i];
                            break;
                        case 2:
                            NewInfo.Type = DownloadType.Custom;
                            NewInfo.DownloadArguments = DownloadArgs[i];
                            break;
                        default:
                            continue;
                    }
                    lvBatchDownloadQueue.Items[i].ImageIndex = (int)BatchDownloader.ConversionIcon.Downloading;

                    bool AbortDownload = false;
                    sbBatchDownloader.Text = lang.sbBatchDownloaderDownloading;
                    Downloader.CurrentDownload = NewInfo;
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
                        case System.Windows.Forms.DialogResult.Ignore:
                            lvBatchDownloadQueue.Items[i].ImageIndex = (int)BatchDownloader.ConversionIcon.Waiting;
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
                    lvi.SubItems[2].Text = cbArguments.Text;
                }
                lvi.ImageIndex = (int)BatchDownloader.ConversionIcon.Waiting;
                DownloadArgs.Add(cbArguments.Text);
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
            DateTimeBuffer += DateTime.Now.Year.ToString("0.####") + "_";
            DateTimeBuffer += DateTime.Now.Month.ToString("00.##") + "_";
            DateTimeBuffer += DateTime.Now.Day.ToString("00.##") + " - ";
            DateTimeBuffer += DateTime.Now.Hour.ToString("00.##") + "_";
            DateTimeBuffer += DateTime.Now.Minute.ToString("00.##") + "_";
            DateTimeBuffer += DateTime.Now.Second.ToString("00.##");
            return DateTimeBuffer;
        }
    }
}