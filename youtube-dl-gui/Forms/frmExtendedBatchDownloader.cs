#define ENABLETRY2
namespace youtube_dl_gui;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
public partial class frmExtendedBatchDownloader : Form {

    private List<string> QueuedParsingList = new(); // A list of URLs that will be queried.

    private Thread InformationThread;   // The information processing thread.
    private Thread ThumbnailThread;     // The thumbnail downloader thread (n/a on batch downloader atm)
    private Thread DownloadThread;      // The downloading thread.
    private Process DownloadProcess;    // The process for yt-dlp.
    private ExtendedMediaDetails SelectedMedia; // The selected media in the batch queue.

    private ExtendedBatchStatus Status = ExtendedBatchStatus.Waiting; // The overall status.
    private bool ChangingQueuedItem = false;    // Whether the selected queued item is being changed.

    public frmExtendedBatchDownloader() {
        InitializeComponent();
        LoadLanguage();

        cbVideoRemux.Items.AddRange(Formats.ExtendedVideoFormats);
        cbVideoRemux.SelectedIndex = 0;
        cbVideoEncoders.Items.AddRange(Formats.ExtendedVideoFormats);
        cbVideoEncoders.SelectedIndex = 0;

        cbAudioEncoders.Items.AddRange(Formats.ExtendedAudioFormats);
        cbAudioEncoders.SelectedIndex = 0;

        cbVbrQualities.Items.AddRange(Formats.VbrQualities);
        cbVbrQualities.SelectedIndex = 0;

        cbSchema.Text = Config.Settings.Downloads.fileNameSchema;
        if (!string.IsNullOrEmpty(Config.Settings.Saved.FileNameSchemaHistory))
            cbSchema.Items.AddRange(Config.Settings.Saved.FileNameSchemaHistory.Split('|'));

        lvQueuedMedia.SmallImageList = Program.BatchStatusImages;
        lvVideoFormats.SmallImageList = Program.ExtendedDownloaderSelectedImages;
        lvAudioFormats.SmallImageList = Program.ExtendedDownloaderSelectedImages;
        lvUnknownFormats.SmallImageList = Program.ExtendedDownloaderSelectedImages;

        lvQueuedMedia.ContextMenu = cmQueuedMedia;
    }
    public frmExtendedBatchDownloader(string URL) : this() => QueuedParsingList.Add(URL);
    public frmExtendedBatchDownloader(string[] URLs) : this() => QueuedParsingList.AddRange(URLs);
    private void frmExtendedBatchDownloader_Load(object sender, EventArgs e) {
        if (Config.Settings.Saved.ExtendedBatchDownloaderLocation.Valid) {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Config.Settings.Saved.ExtendedBatchDownloaderLocation;
        }
        if (Config.Settings.Saved.ExtendedDownloaderSize.Valid)
            this.Size = Config.Settings.Saved.ExtendedDownloaderSize;
        if (!Config.Settings.Saved.ExtendedBatchDownloaderQueuedColumns.IsNullEmptyWhitespace())
            lvVideoFormats.SetColumnWidths(Config.Settings.Saved.ExtendedBatchDownloaderQueuedColumns);
        if (!Config.Settings.Saved.ExtendedDownloaderVideoColumns.IsNullEmptyWhitespace())
            lvVideoFormats.SetColumnWidths(Config.Settings.Saved.ExtendedDownloaderVideoColumns);
        if (!Config.Settings.Saved.ExtendedDownloaderAudioColumns.IsNullEmptyWhitespace())
            lvAudioFormats.SetColumnWidths(Config.Settings.Saved.ExtendedDownloaderAudioColumns);
        if (!Config.Settings.Saved.ExtendedDownloaderUnknownColumns.IsNullEmptyWhitespace())
            lvUnknownFormats.SetColumnWidths(Config.Settings.Saved.ExtendedDownloaderUnknownColumns);
    }
    private void frmExtendedBatchDownloader_Shown(object sender, EventArgs e) {
        if (QueuedParsingList.Count > 0)
            DownloadQueueInfo();
        txtQueueLink.Focus();
    }
    private void frmExtendedBatchDownloader_FormClosing(object sender, FormClosingEventArgs e) {
        switch (Status) {
            case ExtendedBatchStatus.GatheringInformation: {

            } break;
        }
    }

    private void LoadLanguage() {
        this.Text = Language.frmExtendedDownloaderRetrieving.Format(Language.ApplicationName);

        chBatchURL.Text = Language.lbExtendedDownloaderLink;
        chBatchTitle.Text = Language.GenericTitle;
        chBatchLength.Text = Language.GenericLength;
        chBatchUploader.Text = Language.lbExtendedDownloaderUploader;
        chBatchViews.Text = Language.lbExtendedDownloaderViews;

        rbVideo.Text = Language.GenericVideo;
        rbAudio.Text = Language.GenericAudio;
        rbUnknownFormat.Text = Language.GenericUnknownFormat;
        rbCustom.Text = Language.GenericCustom;
        chkVideoDownloadAudio.Text = Language.GenericSound;
        tabExtendedDownloaderFormats.Text = Language.lbFormat;
        tabExtendedDownloaderDescription.Text = Language.tabExtendedDownloaderDescription;
        tabExtendedDownloaderVerbose.Text = Language.tabExtendedDownloaderVerbose;
        tabVideoFormats.Text = Language.GenericVideo;
        lbExtendedDownloaderNoVideoFormatsAvailable.Text = Language.lbExtendedDownloaderNoVideoFormatsAvailable;
        tabAudioFormats.Text = Language.GenericAudio;
        lbExtendedDownloaderNoAudioFormatsAvailable.Text = Language.lbExtendedDownloaderNoAudioFormatsAvailable;
        tabCustom.Text = Language.GenericCustom;
        tabExtendedDownloaderFormatOptions.Text = Language.tabExtendedDownloaderFormatOptions;
        lbVideoEncoder.Text = Language.GenericVideo;
        lbAudioEncoder.Text = Language.GenericAudio;
        btnDownloadAbortClose.Text = Language.sbDownload;
        btnDownloadWithAuthentication.Text = Language.mDownloadWithAuthentication;
        lbSchema.Text = Language.lbSettingsDownloadsFileNameSchema;
        chkVideoSeparateAudio.Text = Language.chkExtendedDownloaderVideoSeparateAudio;
        lbVideoRemux.Text = Language.lbVideoRemux;
        txtExtendedDownloaderMediaTitle.Text = Language.txtExtendedDownloaderMediaTitle;
        tabExtendedDownloaderUnknownFormats.Text = Language.tabExtendedDownloaderUnknownFormats;
        lbExtendedDownloaderNoUnknownFormatsFound.Text = Language.lbExtendedDownloaderNoUnknownFormatsFound;
        btnClearOutput.Text = Language.GenericClear;

        // lvVideoFormats
        chVideoQuality.Text = Language.chVideoQuality;
        chVideoFPS.Text = Language.chVideoFPS;
        chVideoContainer.Text = Language.chContainer;
        chVideoFileSize.Text = Language.chFileSize;
        chVideoBitrate.Text = Language.chVideoBitrate;
        chVideoDimension.Text = Language.chVideoDimension;
        chVideoCodec.Text = Language.chVideoCodec;
        chVideoAudioBitrate.Text = Language.chAudioBitrate;
        chVideoAudioSampleRate.Text = Language.chAudioSampleRate;
        chVideoAudioCodec.Text = Language.chAudioCodec;
        chVideoAudioChannels.Text = Language.chAudioChannels;
        chVideoFormatId.Text = Language.chFormatId;
        // lvAudioFormats
        chAudioBitrate.Text = Language.chAudioBitrate;
        chAudioContainer.Text = Language.chContainer;
        chAudioFileSize.Text = Language.chFileSize;
        chAudioSampleRate.Text = Language.chAudioSampleRate;
        chAudioCodec.Text = Language.chAudioCodec;
        chAudioChannels.Text = Language.chAudioChannels;
        chAudioFormatId.Text = Language.chFormatId;
        // lvUnknownFormats
        chUnknownQuality.Text = Language.chVideoQuality;
        chUnknownFPS.Text = Language.chVideoFPS;
        chUnknownContainer.Text = Language.chContainer;
        chUnknownFileSize.Text = Language.chFileSize;
        chUnknownVideoBitrate.Text = Language.chVideoBitrate;
        chUnknownDimensions.Text = Language.chVideoDimension;
        chUnknownVideoCodec.Text = Language.chVideoCodec;
        chUnknownAudioBitrate.Text = Language.chAudioBitrate;
        chUnknownAudioSampleRate.Text = Language.chAudioSampleRate;
        chUnknownAudioCodec.Text = Language.chAudioCodec;
        chUnknownAudioChannels.Text = Language.chAudioChannels;
        chUnknownFormatId.Text = Language.chFormatId;


        cbVideoRemux.Items.Add(Language.GenericDoNotRemux);
        cbVideoEncoders.Items.Add(Language.GenericDoNotReEncode);
        cbAudioEncoders.Items.Add(Language.GenericDoNotReEncode);
    }
    private void DownloadQueueInfo() {
        if (InformationThread is not null && InformationThread.IsAlive)
            return;

        InformationThread = new(() => {
            string Link = null;
#if ENABLETRY
            try {
#endif
                Status = ExtendedBatchStatus.GatheringInformation;
                while (QueuedParsingList.Count > 0) {
                    Link = QueuedParsingList[0];
                    QueuedParsingList.RemoveAt(0);
                    try {
                        ListViewItem NewLink = new(Link) {
                            ImageIndex = StatusIcon.Waiting
                        };
                        NewLink.SubItems.Add("-"); // Title
                        NewLink.SubItems.Add("-"); // Length
                        NewLink.SubItems.Add("-"); // Uploader
                        NewLink.SubItems.Add("-"); // Views

                        lvQueuedMedia.Invoke(() => lvQueuedMedia.Items.Add(NewLink));
                        ExtendedMediaDetails NewMedia = new() {
                            URL = Link,
                            QueueItem = NewLink
                        };
                        NewLink.Tag = NewMedia;

                        NewMedia.GetMediaInfo((x) => {
                            lvQueuedMedia.Invoke(() => {
                                if (lvQueuedMedia.Items.Contains(x.QueueItem)) {
                                    x.QueueItem.SubItems[1].Text = NewMedia.MediaName;
                                    x.QueueItem.SubItems[2].Text = NewMedia.MediaData.Duration;
                                    x.QueueItem.SubItems[3].Text = NewMedia.MediaData.Uploader;
                                    x.QueueItem.SubItems[4].Text = NewMedia.MediaData.Views.HasValue ? NewMedia.MediaData.Views.Value.ToString("#,000") : "?";

                                    if (lvQueuedMedia.SelectedItems.Count > 0 && lvQueuedMedia.Items[0] == x.QueueItem) {
                                        ChangingQueuedItem = true;
                                        if (x.VideoItems.Count > 0) {
                                            lvVideoFormats.Enabled = rbVideo.Enabled = true;
                                            lbExtendedDownloaderNoVideoFormatsAvailable.Visible = false;
                                            lvVideoFormats.Items.Clear();
                                            x.VideoItems.For((Format) => lvVideoFormats.Items.Add(Format));
                                            x.SelectedVideoItem.Selected = true;
                                        }
                                        else {
                                            rbVideo.Enabled = false;
                                            lbExtendedDownloaderNoVideoFormatsAvailable.Visible = true;
                                        }

                                        if (x.AudioItems.Count > 0) {
                                            lvAudioFormats.Enabled = rbAudio.Enabled = true;
                                            lbExtendedDownloaderNoAudioFormatsAvailable.Visible = false;
                                            lvAudioFormats.Items.Clear();
                                            x.AudioItems.For((Format) => lvAudioFormats.Items.Add(Format));
                                            x.SelectedAudioItem.Selected = true;
                                        }
                                        else {
                                            rbAudio.Enabled = false;
                                            lbExtendedDownloaderNoAudioFormatsAvailable.Visible = true;
                                        }

                                        if (x.UnknownItems.Count > 0) {
                                            lvUnknownFormats.Enabled = rbUnknownFormat.Enabled = true;
                                            lbExtendedDownloaderNoUnknownFormatsFound.Visible = false;
                                            lvUnknownFormats.Items.Clear();
                                            x.UnknownItems.For((Format) => lvUnknownFormats.Items.Add(Format));
                                        }
                                        else {
                                            rbUnknownFormat.Enabled = false;
                                            lbExtendedDownloaderNoUnknownFormatsFound.Visible = true;
                                        }

                                        txtCustomArguments.Enabled = true;
                                        ChangingQueuedItem = false;
                                    }
                                }
                            });
                        });
                    }
                    catch (Exception ex) {
                        Log.ReportException(ex, $"Exception received at URL \"{Link}\".");
                    }
                }
#if ENABLETRY
            }
            catch (ThreadAbortException) { }
            catch (Exception ex) {
                Log.ReportException(ex, $"Exception received at URL \"{Link ?? "No URL"}\".");
            }
#endif

            Status = ExtendedBatchStatus.Waiting;
        }) {
            Name = "Retrieving batch download queue info",
            IsBackground = true,
        };
        InformationThread.Start();
    }
    /// <summary>
    /// Applies settings to the selected media. Should only occur when the queued item is changing or the download starts.
    /// </summary>
    private void ApplyMediaSettings() {
        if (SelectedMedia is null)
            return;

        SelectedMedia.SelectedType = true switch {
            _ when rbVideo.Checked => DownloadType.Video,
            _ when rbAudio.Checked => DownloadType.Audio,
            _ when rbUnknownFormat.Checked => DownloadType.Unknown,
            _ => DownloadType.Custom,
        };

        SelectedMedia.CustomArguments = txtCustomArguments.Text;

        SelectedMedia.FileNameSchema = cbSchema.Text;
        SelectedMedia.FileNameSchemaIndex = cbSchema.Items.IndexOf(cbSchema.Text);

        SelectedMedia.AudioVBR = chkAudioVBR.Checked;
        SelectedMedia.VBRIndex = cbVbrQualities.SelectedIndex;

        SelectedMedia.VideoDownloadAudio = chkVideoDownloadAudio.Checked;
        SelectedMedia.VideoSeparateAudio = chkVideoSeparateAudio.Checked;

        SelectedMedia.VideoRemuxIndex = cbVideoRemux.SelectedIndex;
        SelectedMedia.VideoEncoderIndex = cbVideoEncoders.SelectedIndex;

        SelectedMedia.AudioEncoderIndex = cbAudioEncoders.SelectedIndex;

        if (lvVideoFormats.SelectedItems.Count > 0) {
            SelectedMedia.SelectedVideoItem = lvVideoFormats.SelectedItems[0];
            SelectedMedia.SelectedVideoFormat = SelectedMedia.SelectedVideoItem.Tag as YoutubeDlFormat;
        }
        if (lvAudioFormats.SelectedItems.Count > 0) {
            SelectedMedia.SelectedAudioItem = lvAudioFormats.SelectedItems[0];
            SelectedMedia.SelectedAudioFormat = SelectedMedia.SelectedAudioItem.Tag as YoutubeDlFormat;
        }
        if (lvUnknownFormats.SelectedItems.Count > 0) {
            SelectedMedia.SelectedUnknownItem = lvUnknownFormats.SelectedItems[0];
            SelectedMedia.SelectedUnknownFormat = SelectedMedia.SelectedUnknownItem.Tag as YoutubeDlFormat;
        }
    }
    /// <summary>
    /// Loads the saved media settings.
    /// </summary>
    private void LoadMediaSettings() {
        if (SelectedMedia is null)
            return;

        switch (SelectedMedia.SelectedType) {
            case DownloadType.Video: {
                rbVideo.Checked = true;
            } break;
            case DownloadType.Audio: {
                rbAudio.Checked = true;
            } break;
            case DownloadType.Unknown: {
                rbUnknownFormat.Checked = true;
            } break;
            default: {
                rbCustom.Checked = true;
            } break;
        }

        txtCustomArguments.Text = SelectedMedia.CustomArguments ?? string.Empty;

        if (SelectedMedia.FileNameSchemaIndex > -1) cbSchema.SelectedIndex = SelectedMedia.FileNameSchemaIndex;
        else cbSchema.Text = SelectedMedia.FileNameSchema;

        chkAudioVBR.Checked = SelectedMedia.AudioVBR;
        cbVbrQualities.SelectedIndex = SelectedMedia.VBRIndex;

        chkVideoDownloadAudio.Checked = SelectedMedia.VideoDownloadAudio;
        chkVideoSeparateAudio.Checked = SelectedMedia.VideoSeparateAudio;

        cbVideoRemux.SelectedIndex = SelectedMedia.VideoRemuxIndex;
        cbVideoEncoders.SelectedIndex = SelectedMedia.VideoEncoderIndex;

        cbAudioEncoders.SelectedIndex = SelectedMedia.AudioEncoderIndex;

        lvVideoFormats.Items.Clear();
        if (SelectedMedia.VideoItems.Count > 0) {
            SelectedMedia.VideoItems.For((Item) => lvVideoFormats.Items.Add(Item));
            if (SelectedMedia.SelectedVideoItem is not null && lvVideoFormats.Items.Contains(SelectedMedia.SelectedVideoItem)) {
                SelectedMedia.SelectedVideoItem.Selected = true;
            }
            else {
                lvVideoFormats.Items[0].Selected = true;
            }

            lbExtendedDownloaderNoVideoFormatsAvailable.Visible = false;
            lvVideoFormats.Enabled= true;
        }
        else {
            lbExtendedDownloaderNoVideoFormatsAvailable.Visible = true;
            lvVideoFormats.Enabled = false;
        }

        lvAudioFormats.Items.Clear();
        if (SelectedMedia.AudioItems.Count > 0) {
            SelectedMedia.AudioItems.For((Item) => lvAudioFormats.Items.Add(Item));
            if (SelectedMedia.SelectedAudioItem is not null && lvAudioFormats.Items.Contains(SelectedMedia.SelectedAudioItem)) {
                SelectedMedia.SelectedAudioItem.Selected = true;
            }
            else {
                lvAudioFormats.Items[0].Selected = true;
            }

            lbExtendedDownloaderNoAudioFormatsAvailable.Visible = false;
        }
        else {

            lbExtendedDownloaderNoAudioFormatsAvailable.Visible = true;
            lvAudioFormats.Enabled = false;
        }

        lvUnknownFormats.Items.Clear();
        if (SelectedMedia.UnknownItems.Count > 0) {
            SelectedMedia.UnknownItems.For((Item) => lvUnknownFormats.Items.Add(Item));
            if (SelectedMedia.SelectedUnknownItem is not null && lvUnknownFormats.Items.Contains(SelectedMedia.SelectedUnknownItem)) {
                SelectedMedia.SelectedUnknownItem.Selected = true;
            }
            else {
                lvUnknownFormats.Items[0].Selected = true;
            }

            lbExtendedDownloaderNoUnknownFormatsFound.Visible = false;
        }
        else {

            lbExtendedDownloaderNoUnknownFormatsFound.Visible = true;
            lvUnknownFormats.Enabled = false;
        }

    }
    public void BeginDownload() {
        if (lvQueuedMedia.Items.Count < 1)
            return;

        rtbVerbose.AppendLine(Config.Settings.Downloads.YtdlType switch {
            0 => "Using yt-dlp as the",
            1 => "Using youtube-dl as the",
            3 => "Using youtube-dl-patch as the",
            2 => "Using yt-dlp-patch as the",
            _ => "Unknown"
        } + " download provider.");

        ApplyMediaSettings();
    }

    private void btnEnqeue_Click(object sender, EventArgs e) {
        if (txtQueueLink.Text.IsNullEmptyWhitespace()) {
            txtQueueLink.Focus();
            System.Media.SystemSounds.Exclamation.Play();
            return;
        }

        QueuedParsingList.Add(txtQueueLink.Text);
        DownloadQueueInfo();
        txtQueueLink.Clear();
    }
    private void lvQueuedMedia_SelectedIndexChanged(object sender, EventArgs e) {
        ChangingQueuedItem = true;
        ApplyMediaSettings();

        SelectedMedia = lvQueuedMedia.SelectedItems.Count > 0 ?
            lvQueuedMedia.SelectedItems[0].Tag as ExtendedMediaDetails : null;

        if (SelectedMedia is not null) {
            LoadMediaSettings();
        }
        else {

        }
        // TODO: Select all the options for the selected media entry.
        ChangingQueuedItem = false;
    }
    private void mRemoveSelected_Click(object sender, EventArgs e) {
        if (lvQueuedMedia.SelectedItems.Count > 0) {

        }
    }
    private void mViewInBrowser_Click(object sender, EventArgs e) {
        if (lvQueuedMedia.SelectedItems.Count > 0)
            Process.Start(SelectedMedia.URL);
    }

    private void rbVideo_CheckedChanged(object sender, EventArgs e) {
    }
    private void rbAudio_CheckedChanged(object sender, EventArgs e) {
    }
    private void rbUnknownFormat_CheckedChanged(object sender, EventArgs e) {
    }
    private void rbCustom_CheckedChanged(object sender, EventArgs e) {
    }

    private void lvVideoFormats_SelectedIndexChanged(object sender, EventArgs e) {
        if (SelectedMedia is not null && lvVideoFormats.SelectedItems.Count > 0) {
            if (SelectedMedia.SelectedVideoItem is not null) {
                SelectedMedia.SelectedVideoItem.ImageIndex = SelectedMedia.SelectedVideoItem.Index == 0 ?
                    rbVideo.Checked ? 0 : 2 : -1;
            }
            lvVideoFormats.SelectedItems[0].ImageIndex = rbVideo.Checked ? 1 : 3;
            SelectedMedia.SelectedVideoItem = lvVideoFormats.SelectedItems[0];
        }
    }
    private void lvAudioFormats_SelectedIndexChanged(object sender, EventArgs e) {
        if (SelectedMedia is not null && lvAudioFormats.SelectedItems.Count > 0) {
            if (SelectedMedia.SelectedAudioItem is not null) {
                SelectedMedia.SelectedAudioItem.ImageIndex = SelectedMedia.SelectedAudioItem.Index == 0 ?
                    rbAudio.Checked || (rbVideo.Checked && chkVideoDownloadAudio.Checked) ? 0 : 2 : -1;
            }
            lvAudioFormats.SelectedItems[0].ImageIndex = rbAudio.Checked || (rbVideo.Checked && chkVideoDownloadAudio.Checked) ? 1 : 3;
            SelectedMedia.SelectedAudioItem = lvAudioFormats.SelectedItems[0];
        }
    }
    private void lvUnknownFormats_SelectedIndexChanged(object sender, EventArgs e) {
        if (SelectedMedia is not null && lvUnknownFormats.SelectedItems.Count > 0) {
            if (rbUnknownFormat.Checked && lvUnknownFormats.SelectedItems[0].Index == 0) {
                lvUnknownFormats.Items[1].Selected = true;
            }
            else {
                if (SelectedMedia.SelectedUnknownItem is not null && SelectedMedia.SelectedUnknownItem.Index > -1) {
                    SelectedMedia.SelectedUnknownItem.ImageIndex = SelectedMedia.SelectedUnknownItem.Index == 1 ?
                        rbVideo.Checked || rbAudio.Checked || rbUnknownFormat.Checked ? 0 : 2 : -1;
                }
                lvUnknownFormats.SelectedItems[0].ImageIndex = rbVideo.Checked || rbAudio.Checked || rbUnknownFormat.Checked ? 1 : 3;
                SelectedMedia.SelectedUnknownItem = lvUnknownFormats.SelectedItems[0];
            }
        }
    }

    private void chkAudioVBR_CheckedChanged(object sender, EventArgs e) {

    }
    private void chkVideoDownloadAudio_CheckedChanged(object sender, EventArgs e) {

    }
    private void btnClearOutput_Click(object sender, EventArgs e) {
        rtbVerbose.Clear();
    }
    private void btnDownloadWithAuthentication_Click(object sender, EventArgs e) {

    }
    private void btnDownloadAbortClose_Click(object sender, EventArgs e) {

    }

    private void btnCreateArgs_Click(object sender, EventArgs e) {

    }
}