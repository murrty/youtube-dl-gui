using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace youtube_dl_gui {

    public partial class frmBatchDownloader : Form {

        public bool Debugging = false;

        private readonly List<int> DownloadTypes = new();       // List of types to download
        private readonly List<string> DownloadUrls = new();     // List of urls to download
        private readonly List<string> DownloadArgs = new();     // List of args to download
        private readonly List<int> DownloadQuality = new();     // List of the quality
        private readonly List<int> DownloadFormat = new();      // List of the formats
        private readonly List<bool> DownloadSoundVBR = new();   // List of if sound/vbr should be downloaded
        private readonly ImageList StatusImages;                // The images for each individual item
        private bool InProgress = false;                        // Bool if the batch download is in progress
        private frmDownloader Downloader;                       // The Downloader form that will be around. Will be disposed if aborted.
        private DownloadInfo NewInfo;                           // The info of the download

        public frmBatchDownloader() {
            InitializeComponent();
            LoadLanguage();

            StatusImages = new() {
                ColorDepth = ColorDepth.Depth32Bit,
                TransparentColor = System.Drawing.Color.Transparent,
            };

            StatusImages.Images.Add(Properties.Resources.waiting);
            StatusImages.Images.Add(Properties.Resources.download);
            StatusImages.Images.Add(Properties.Resources.finished);
            StatusImages.Images.Add(Properties.Resources.error);
        }

        void LoadLanguage() {
            this.Text = Program.lang.frmBatchDownload;
            lbBatchDownloadLink.Text = Program.lang.lbBatchDownloadLink;
            lbBatchDownloadType.Text = Program.lang.lbBatchDownloadType;
            lbBatchVideoSpecificArgument.Text = Program.lang.lbBatchDownloadVideoSpecificArgument;
            btnBatchDownloadAdd.Text = Program.lang.btnBatchDownloadAdd;
            sbBatchDownloadLoadArgs.Text = Program.lang.sbBatchDownloadLoadArgs;
            mBatchDownloaderLoadArgsFromSettings.Text = Program.lang.mBatchDownloaderLoadArgsFromSettings;
            mBatchDownloaderLoadArgsFromArgsTxt.Text = Program.lang.mBatchDownloaderLoadArgsFromArgsTxt;
            mBatchDownloaderLoadArgsFromFile.Text = Program.lang.mBatchDownloaderLoadArgsFromFile;
            btnBatchDownloadRemoveSelected.Text = Program.lang.btnBatchDownloadRemoveSelected;
            btnBatchDownloadStartStopExit.Text = Program.lang.GenericStart;
            sbBatchDownloader.Text = Program.lang.sbBatchDownloaderIdle;
            lvBatchDownloadQueue.Columns[1].Text = Program.lang.lbBatchDownloadType;
            lvBatchDownloadQueue.Columns[2].Text = Program.lang.lbBatchDownloadVideoSpecificArgument;
            cbBatchDownloadType.Items.Add(Program.lang.GenericVideo);
            cbBatchDownloadType.Items.Add(Program.lang.GenericAudio);
            cbBatchDownloadType.Items.Add(Program.lang.GenericCustom);
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
                this.Location = new(Config.Settings.Saved.BatchFormX, Config.Settings.Saved.BatchFormY);
            }
        }

        private void frmBatchDownloader_FormClosing(object sender, FormClosingEventArgs e) {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Opacity = 0;
                this.WindowState = FormWindowState.Normal;
            }
            Config.Settings.Saved.BatchFormX = this.Location.X;
            Config.Settings.Saved.BatchFormY = this.Location.Y;
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
            using OpenFileDialog ofd = new();
            ofd.Title = "Select a file to read as arguments";
            ofd.Filter = "All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK) {
                if (System.IO.File.Exists(ofd.FileName)) {
                    cbArguments.Text = System.IO.File.ReadAllText(ofd.FileName).Trim(' ').Replace('\n', ' ').Trim(' ');
                }
            }
        }

        private void mBatchDownloaderLoadArgsFromSettings_Click(object sender, EventArgs e) {
            if (Config.Settings.Saved.DownloadCustomArguments.Length > 0) {
                cbArguments.Items.AddRange(Config.Settings.Saved.DownloadCustomArguments.Split('|'));
                cbArguments.SelectedIndex = Config.Settings.Saved.CustomArgumentsIndex;
            }
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
            using OpenFileDialog ofd = new();
            ofd.Title = "Select a file to read as arguments";
            ofd.Filter = "All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK) {
                if (System.IO.File.Exists(ofd.FileName)) {
                    cbArguments.Text = System.IO.File.ReadAllText(ofd.FileName).Trim(' ').Replace('\n', ' ').Trim(' ');
                }
            }
        }

        private void lvBatchDownloadQueue_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control && e.KeyCode == Keys.A) {
                for (int i = 0; i < lvBatchDownloadQueue.Items.Count; i++) {
                    lvBatchDownloadQueue.Items[i].Selected = true;
                }
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
                    cbBatchQuality.Items.AddRange(Download.Formats.AudioQualityNamesArray);
                    cbBatchQuality.SelectedIndex = Config.Settings.Batch.SelectedAudioQualityVBR;
                }
            }
        }

        private void cbBatchDownloadType_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbBatchDownloadType.SelectedIndex > -1) {

                if (!string.IsNullOrEmpty(txtBatchDownloadLink.Text)) {
                    btnBatchDownloadAdd.Enabled = true;
                }

                cbBatchQuality.SelectedIndex = -1;
                cbBatchFormat.SelectedIndex = -1;
                cbBatchQuality.Items.Clear();
                cbBatchFormat.Items.Clear();

                switch (cbBatchDownloadType.SelectedIndex) {
                    case 0: {
                        cbArguments.Visible = false;
                        cbBatchQuality.Visible = true;
                        cbBatchQuality.Enabled = true;
                        cbBatchQuality.Items.AddRange(Download.Formats.VideoQualityArray);
                        cbBatchFormat.Visible = true;
                        cbBatchFormat.Enabled = true;
                        cbBatchFormat.Items.AddRange(Download.Formats.VideoFormatsNamesArray);
                        chkBatchDownloaderSoundVBR.Text = Program.lang.chkDownloadSound;
                        chkBatchDownloaderSoundVBR.Enabled = true;
                        cbBatchQuality.SelectedIndex = Config.Settings.Batch.SelectedVideoQuality;
                        cbBatchFormat.SelectedIndex = Config.Settings.Batch.SelectedVideoFormat;
                        chkBatchDownloaderSoundVBR.Checked = Config.Settings.Batch.DownloadVideoSound;
                        chkBatchDownloaderSoundVBR.Visible = true;
                    } break;

                    case 1: {
                        cbArguments.Visible = false;
                        cbBatchQuality.Visible = true;
                        cbBatchQuality.Enabled = true;
                        cbBatchFormat.Visible = true;
                        cbBatchFormat.Enabled = true;
                        cbBatchFormat.Items.AddRange(Download.Formats.AudioFormatsArray);
                        chkBatchDownloaderSoundVBR.Text = "VBR";
                        chkBatchDownloaderSoundVBR.Enabled = true;
                        if (Config.Settings.Batch.DownloadAudioVBR) {
                            cbBatchQuality.Items.AddRange(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
                            cbBatchQuality.SelectedIndex = Config.Settings.Batch.SelectedAudioQuality;
                        }
                        else {
                            cbBatchQuality.Items.AddRange(Download.Formats.AudioQualityNamesArray);
                            cbBatchQuality.SelectedIndex = Config.Settings.Batch.SelectedAudioQualityVBR;
                        }
                        cbBatchFormat.SelectedIndex = Config.Settings.Batch.SelectedAudioFormat;
                        chkBatchDownloaderSoundVBR.Checked = Config.Settings.Batch.DownloadAudioVBR;
                        chkBatchDownloaderSoundVBR.Visible = true;
                    } break;

                    case 2: {
                        cbArguments.Visible = true;
                        cbBatchFormat.Visible = false;
                        cbBatchQuality.Visible = false;
                        cbBatchFormat.Enabled = false;
                        cbBatchQuality.Enabled = false;
                        chkBatchDownloaderSoundVBR.Enabled = false;
                        chkBatchDownloaderSoundVBR.Checked = false;
                        chkBatchDownloaderSoundVBR.Visible = false;
                    } break;
                }

                //if (lvBatchDownloadQueue.SelectedItems.Count > 0) {
                //    for (int i = 0; i < lvBatchDownloadQueue.SelectedItems.Count; i++) {
                //        lvBatchDownloadQueue.SelectedItems[i].SubItems[1].Text = cbBatchDownloadType.GetItemText(cbBatchDownloadType.SelectedItem);
                //    }
                //}
            }
        }

        private void btnBatchDownloadStartStopExit_Click(object sender, EventArgs e) {
            if (InProgress) {
                Downloader.Dispose();
            }
            else if (DownloadUrls.Count > 0) {
                btnBatchDownloadRemoveSelected.Enabled = false;
                btnBatchDownloadStartStopExit.Text = Program.lang.GenericStop;
                InProgress = true;
                string BatchTime = BatchHelpers.CurrentTime();
                for (int i = 0; i < DownloadUrls.Count; i++) {
                    NewInfo = new DownloadInfo {
                        BatchDownload = true,
                        BatchTime = BatchTime,
                        DownloadURL = DownloadUrls[i]
                    };
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
                    lvBatchDownloadQueue.Items[i].ImageIndex = (int)BatchHelpers.StatusIcon.Processing;

                    bool AbortDownload = false;
                    sbBatchDownloader.Text = Program.lang.sbBatchDownloaderDownloading;
                    Downloader = new frmDownloader(NewInfo);
                    switch (Downloader.ShowDialog()) {
                        case DialogResult.Yes:
                            lvBatchDownloadQueue.Items[i].ImageIndex = (int)BatchHelpers.StatusIcon.Finished;
                            break;
                        case DialogResult.No:
                            lvBatchDownloadQueue.Items[i].ImageIndex = (int)BatchHelpers.StatusIcon.Errored;
                            break;
                        case DialogResult.Abort:
                            lvBatchDownloadQueue.Items[i].ImageIndex = (int)BatchHelpers.StatusIcon.Waiting;
                            AbortDownload = true;
                            break;
                        case DialogResult.Ignore:
                            lvBatchDownloadQueue.Items[i].ImageIndex = (int)BatchHelpers.StatusIcon.Waiting;
                            break;
                        default:
                            lvBatchDownloadQueue.Items[i].ImageIndex = (int)BatchHelpers.StatusIcon.Finished;
                            break;
                    }
                    if (AbortDownload) { break; }
                }
                InProgress = false;
                System.Media.SystemSounds.Exclamation.Play();
                sbBatchDownloader.Text = Program.lang.sbBatchDownloaderFinished;
                btnBatchDownloadStartStopExit.Text = Program.lang.GenericStart;
            }
        }

        private void AddItemToList() {
            if (!string.IsNullOrEmpty(txtBatchDownloadLink.Text) && cbBatchDownloadType.SelectedIndex != -1) {
                ListViewItem lvi = new() {
                    Checked = false,
                    Name = txtBatchDownloadLink.Text
                };

                lvi.SubItems[0].Text = txtBatchDownloadLink.Text;
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem());
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem());
                switch (cbBatchDownloadType.SelectedIndex) {
                    case -1:
                        System.Media.SystemSounds.Asterisk.Play();
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
                lvi.ImageIndex = (int)BatchHelpers.StatusIcon.Waiting;
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
            if (lvBatchDownloadQueue.SelectedIndices.Count > 0 && !InProgress) {
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
    }

}