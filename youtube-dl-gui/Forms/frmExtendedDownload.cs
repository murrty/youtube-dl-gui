using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmExtendedDownload : Form {

        // Download specific times: yt-dlp -i --download-sections "*00:00:00-00:00:10"

        public string URL { get; }

        private YoutubeDlData Information;
        private Thread InformationThread;
        private Thread ThumbnailThread;
        private Thread DownloadThread;
        private Process DownloadProcess;
        private ListViewItem LastSelectedVideoFormat;
        private ListViewItem LastSelectedAudioFormat;
        private ListViewItem LastSelectedUnknownFormat;

        private DownloadStatus Status = DownloadStatus.None;
        private string Msg;

        public frmExtendedDownload(string URL, bool Archived) {
            InitializeComponent();
            LoadLanguage();
            this.URL = URL;
            txtLink.Text = Archived ? URL.Split(':')[1] : URL;

            if (!Program.DebugMode) {
                tcVideoData.TabPages.Remove(tabDebug);
            }

            lvVideoFormats.SelectedIndexChanged += (s, e) => {
                if (lvVideoFormats.SelectedItems.Count > 0) {
                    if (LastSelectedVideoFormat is not null) {
                        LastSelectedVideoFormat.ImageIndex = LastSelectedVideoFormat.Index == 0 ?
                            rbVideo.Checked ? 0 : 2 : -1;
                    }
                    lvVideoFormats.SelectedItems[0].ImageIndex = rbVideo.Checked ? 1 : 3;
                    LastSelectedVideoFormat = lvVideoFormats.SelectedItems[0];
                }
            };
            lvAudioFormats.SelectedIndexChanged += (s, e) => {
                if (lvAudioFormats.SelectedItems.Count > 0) {
                    if (LastSelectedAudioFormat is not null) {
                        LastSelectedAudioFormat.ImageIndex = LastSelectedAudioFormat.Index == 0 ?
                            rbAudio.Checked || (rbVideo.Checked && chkVideoDownloadAudio.Checked) ? 0 : 2 : -1;
                    }
                    lvAudioFormats.SelectedItems[0].ImageIndex = rbAudio.Checked || (rbVideo.Checked && chkVideoDownloadAudio.Checked) ? 1 : 3;
                    LastSelectedAudioFormat = lvAudioFormats.SelectedItems[0];
                }
            };
            lvUnknownFormats.SelectedIndexChanged += (s, e) => {
                if (lvUnknownFormats.SelectedItems.Count > 0) {
                    if (rbUnknownFormat.Checked && lvUnknownFormats.SelectedItems[0].Index == 0) {
                        lvUnknownFormats.Items[1].Selected = true;
                    }
                    else {
                        if (LastSelectedUnknownFormat is not null && LastSelectedUnknownFormat.Index > -1) {
                            LastSelectedUnknownFormat.ImageIndex = LastSelectedUnknownFormat.Index == 1 ?
                                rbVideo.Checked || rbAudio.Checked || rbUnknownFormat.Checked ? 0 : 2 : -1;
                        }
                        lvUnknownFormats.SelectedItems[0].ImageIndex = rbVideo.Checked || rbAudio.Checked || rbUnknownFormat.Checked ? 1 : 3;
                        LastSelectedUnknownFormat = lvUnknownFormats.SelectedItems[0];
                    }
                }
            };

            cbVideoRemux.Items.AddRange(
                new[] { "avi", "flv", "mkv", "mov", "mp4", "webm" });
            cbVideoRemux.SelectedIndex = 0;
            cbVideoEncoders.Items.AddRange(
                new[] { "avi", "flv", "mkv", "mov", "mp4", "webm" });
            cbVideoEncoders.SelectedIndex = 0;

            cbAudioEncoders.Items.AddRange(
                new[] { "aac", "aiff", "alac", "flac", "mp3", "m4a", "ogg", "opus", "vorbis", "wav" });
            cbAudioEncoders.SelectedIndex = 0;

            cbVbrQualities.Items.AddRange(Formats.VbrQualities);
            cbVbrQualities.SelectedIndex = 0;

            cbSchema.Text = Config.Settings.Downloads.fileNameSchema;
            if (!string.IsNullOrEmpty(Config.Settings.Saved.FileNameSchemaHistory))
                cbSchema.Items.AddRange(Config.Settings.Saved.FileNameSchemaHistory.Split('|'));
            lvVideoFormats.SmallImageList = Program.ExtendedDownloaderSelectedImages;
            lvAudioFormats.SmallImageList = Program.ExtendedDownloaderSelectedImages;
            lvUnknownFormats.SmallImageList = Program.ExtendedDownloaderSelectedImages;

            this.Load += (s, e) => {
                if (Config.ValidPoint(Config.Settings.Saved.ExtendedDownloaderLocation)) {
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = Config.Settings.Saved.ExtendedDownloaderLocation;
                }
                if (Config.ValidSize(Config.Settings.Saved.ExtendedDownloaderSize))
                    this.Size = Config.Settings.Saved.ExtendedDownloaderSize;
                if (!Config.Settings.Saved.ExtendedDownloadVideoColumns.IsNullEmptyWhitespace())
                    lvVideoFormats.SetColumnWidths(Config.Settings.Saved.ExtendedDownloadVideoColumns);
                if (!Config.Settings.Saved.ExtendedDownloadAudioColumns.IsNullEmptyWhitespace())
                    lvAudioFormats.SetColumnWidths(Config.Settings.Saved.ExtendedDownloadAudioColumns);
                if (!Config.Settings.Saved.ExtendedDownloadUnknownColumns.IsNullEmptyWhitespace())
                    lvUnknownFormats.SetColumnWidths(Config.Settings.Saved.ExtendedDownloadUnknownColumns);
            };
            this.Shown += (s, e) => {
                DownloadInfo();
                lbExtendedDownloaderUploader.Focus();
            };
            this.FormClosing += (s, e) => {
                switch (Status) {
                    case DownloadStatus.Downloading: {
                        Status = DownloadStatus.Aborted;
                        e.Cancel = true;
                    } break;

                    default: {
                        if (InformationThread is not null && InformationThread.IsAlive)
                            InformationThread.Abort();
                        if (ThumbnailThread is not null && ThumbnailThread.IsAlive)
                            ThumbnailThread.Abort();
                        Config.Settings.Saved.ExtendedDownloaderLocation = this.Location;
                        Config.Settings.Saved.ExtendedDownloaderSize = this.Size;
                        Config.Settings.Saved.ExtendedDownloadVideoColumns = lvVideoFormats.GetColumnWidths();
                        Config.Settings.Saved.ExtendedDownloadAudioColumns = lvAudioFormats.GetColumnWidths();
                        Config.Settings.Saved.ExtendedDownloadUnknownColumns = lvUnknownFormats.GetColumnWidths();
                        Config.Settings.Saved.Save();
                        this.Dispose();
                    } break;
                }
            };
        }

        private void LoadLanguage() {
            this.Text = Language.frmExtendedDownloaderRetrieving.Format(Language.ApplicationName);
            lbExtendedDownloaderLink.Text = Language.lbExtendedDownloaderLink;
            lbExtendedDownloaderUploader.Text = Language.lbExtendedDownloaderUploader;
            lbExtendedDownloaderViews.Text = Language.lbExtendedDownloaderViews;
            btnExtendedDownloaderDownloadThumbnail.Text = Language.btnExtendedDownloaderDownloadThumbnail;
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
            tabFormatOptions.Text = Language.tabExtendedDownloaderFormatOptions;
            lbVideoEncoder.Text = Language.GenericVideo;
            lbAudioEncoder.Text = Language.GenericAudio;
            btnDownloadAbortClose.Text = Language.sbDownload;
            btnDownloadWithAuthentication.Text = Language.mDownloadWithAuthentication;
            lbSchema.Text = Language.lbSettingsDownloadsFileNameSchema;
            chkVideoSeparateAudio.Text = Language.chkExtendedDownloaderVideoSeparateAudio;
            chkDownloaderCloseAfterDownload.Text = Language.chkDownloaderCloseAfterDownload;
            lbVideoRemux.Text = Language.lbVideoRemux;
            txtExtendedDownloaderMediaTitle.Text = Language.txtExtendedDownloaderMediaTitle;
            tabExtendedDownloaderUnknownFormats.Text = Language.tabExtendedDownloaderUnknownFormats;
            lbExtendedDownloaderNoUnknownFormatsFound.Text = Language.lbExtendedDownloaderNoUnknownFormatsFound;

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
            chVideoFormatId.Text = Language.chFormatId;
            // lvAudioFormats
            chAudioBitrate.Text = Language.chAudioBitrate;
            chAudioContainer.Text = Language.chContainer;
            chAudioFileSize.Text = Language.chFileSize;
            chAudioSampleRate.Text = Language.chAudioSampleRate;
            chAudioCodec.Text = Language.chAudioCodec;
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
            chUnknownFormatId.Text = Language.chFormatId;


            cbVideoRemux.Items.Add(Language.GenericDoNotRemux);
            cbVideoEncoders.Items.Add(Language.GenericDoNotReEncode);
            cbAudioEncoders.Items.Add(Language.GenericDoNotReEncode);
        }
        private void DownloadInfo() {
            InformationThread = new(() => {
                string Retrieved = null;
                try {
                    if (URL.IsNullEmptyWhitespace())
                        throw new DownloadException(URL, "The media you are trying to access was not entered in correctly.");

                    Information = YoutubeDlData.GenerateData(URL, out Retrieved);
                    if (Information is null || Information.AvailableFormats.Length == 0)
                        throw new DownloadException(URL, "The media you are trying to access may not be accessible at this time, or it may have been removed.");

                    YoutubeDlFormat Format;
                    for (int i = Information.AvailableFormats.Length; i > 0; i--) {
                        Format = Information.AvailableFormats[i - 1];

                        // Some formats don't report width or height, so if either of them are greater than 0 then it's defined as a video.
                        if (Format.ValidVideoFormat) {
                            string LegibleQualityName = Format.QualityName.IsNotNullEmptyWhitespace() ? Format.QualityName : "?";
                            string Dimensions = $"{Format.VideoWidth}x{Format.VideoHeight}";
                            string Bitrate = Format.VideoBitrate is not null && Format.VideoBitrate > 0 ? $"{Format.VideoBitrate}Kbps" : "?";
                            string Container = Format.Extension ?? "Unknown";
                            string Frames = Format.VideoFps is not null && Format.VideoFps > 0 ? $"{Format.VideoFps}" : "?";
                            string Codec = Format.VideoCodec.IsNotNullEmptyWhitespace() && Format.VideoCodec != "none" ? Format.VideoCodec : "Unknown";
                            string FileSize = Format.FileSize is not null ?
                                Format.FileSize.Value.SizeToString() : Format.ApproximateFileSize is not null ?
                                Format.ApproximateFileSize.Value.SizeToString() : "?B";
                            string SampleRate = "-";
                            string AudioCodec = "-";
                            string AudioBitrate = "-";
                            if ((Format.AudioSampleRate is not null && Format.AudioSampleRate > 0)
                            || (Format.AudioBitrate is not null && Format.AudioBitrate > 0)
                            || (Format.AudioCodec is not null && Format.AudioCodec != "none")) {
                                AudioCodec = Format.AudioCodec is not null && Format.AudioCodec != "none" ? Format.AudioCodec : "Unknown";
                                AudioBitrate = $"{(Format.AudioBitrate is not null && Format.AudioBitrate > 0 ? $"{Format.AudioBitrate}" : "?")}Kbps";
                                SampleRate = $"{(Format.AudioSampleRate is not null && Format.AudioSampleRate > 0 ? $"{Format.AudioSampleRate}" : "?")}Hz";
                            }

                            ListViewItem NewFormat = new(LegibleQualityName);
                            NewFormat.SubItems.Add(Frames);
                            NewFormat.SubItems.Add(Container);
                            NewFormat.SubItems.Add(FileSize);
                            NewFormat.SubItems.Add(Bitrate);
                            NewFormat.SubItems.Add(Dimensions);
                            NewFormat.SubItems.Add(Codec);
                            NewFormat.SubItems.Add(AudioBitrate);
                            NewFormat.SubItems.Add(SampleRate);
                            NewFormat.SubItems.Add(AudioCodec);
                            NewFormat.SubItems.Add(Format.Identifier);
                            NewFormat.Tag = Format;

                            if (lvVideoFormats.Items.Count == 0)
                                LastSelectedVideoFormat = NewFormat;

                            lvVideoFormats.Invoke(() => lvVideoFormats.Items.Add(NewFormat));
                        }
                        else if (Format.ValidAudioFormat) {
                            string Codec = Format.AudioCodec ?? "Unknown";
                            string Container = Format.Extension ?? "Unknown";
                            string SampleRate = $"{(Format.AudioSampleRate is not null && Format.AudioSampleRate > 0 ? $"{Format.AudioSampleRate}" : "?")}Hz";
                            string Bitrate = $"{(Format.AudioBitrate is not null && Format.AudioBitrate > 0 ? $"{Format.AudioBitrate}" : "?")}Kbps";
                            string FileSize = Format.FileSize is not null ?
                                ((long)Format.FileSize).SizeToString() : Format.ApproximateFileSize is not null ?
                                ((long)Format.ApproximateFileSize).SizeToString() : "?B";

                            ListViewItem NewFormat = new(Bitrate);
                            NewFormat.SubItems.Add(Container);
                            NewFormat.SubItems.Add(FileSize);
                            NewFormat.SubItems.Add(SampleRate);
                            NewFormat.SubItems.Add(Codec);
                            NewFormat.SubItems.Add(Format.Identifier);
                            NewFormat.Tag = Format;

                            if (lvAudioFormats.Items.Count == 0)
                                LastSelectedAudioFormat = NewFormat;

                            lvAudioFormats.Invoke(() => lvAudioFormats.Items.Add(NewFormat));
                        }
                        else {
                            string LegibleQualityName = Format.QualityName.IsNotNullEmptyWhitespace() ? Format.QualityName : "-";
                            string Dimensions = Format.VideoWidth is not null || Format.VideoHeight is not null ?
                                $"{Format.VideoWidth ?? 0}x{Format.VideoHeight ?? 0}" : "-";
                            string Bitrate = Format.VideoBitrate is not null && Format.VideoBitrate > 0 ? $"{Format.VideoBitrate}Kbps" : "-";
                            string Container = Format.Extension ?? "Unknown";
                            string Frames = Format.VideoFps is not null && Format.VideoFps > 0 ? $"{Format.VideoFps}" : "-";
                            string Codec = Format.VideoCodec.IsNotNullEmptyWhitespace() && Format.VideoCodec != "none" ? Format.VideoCodec : "-";
                            string FileSize = Format.FileSize is not null ?
                                Format.FileSize.Value.SizeToString() : Format.ApproximateFileSize is not null ?
                                Format.ApproximateFileSize.Value.SizeToString() : "?B";
                            string SampleRate = "-";
                            string AudioCodec = "-";
                            string AudioBitrate = "-";
                            if ((Format.AudioSampleRate is not null && Format.AudioSampleRate > 0)
                            || (Format.AudioBitrate is not null && Format.AudioBitrate > 0)
                            || (Format.AudioCodec is not null && Format.AudioCodec != "none")) {
                                AudioCodec = Format.AudioCodec is not null && Format.AudioCodec != "none" ? Format.AudioCodec : "Unknown";
                                AudioBitrate = $"{(Format.AudioBitrate is not null && Format.AudioBitrate > 0 ? $"{Format.AudioBitrate}" : "?")}Kbps";
                                SampleRate = $"{(Format.AudioSampleRate is not null && Format.AudioSampleRate > 0 ? $"{Format.AudioSampleRate}" : "?")}Hz";
                            }

                            ListViewItem NewFormat = new(LegibleQualityName);
                            NewFormat.SubItems.Add(Frames);
                            NewFormat.SubItems.Add(Container);
                            NewFormat.SubItems.Add(FileSize);
                            NewFormat.SubItems.Add(Bitrate);
                            NewFormat.SubItems.Add(Dimensions);
                            NewFormat.SubItems.Add(Codec);
                            NewFormat.SubItems.Add(AudioBitrate);
                            NewFormat.SubItems.Add(SampleRate);
                            NewFormat.SubItems.Add(AudioCodec);
                            NewFormat.SubItems.Add(Format.Identifier);
                            NewFormat.Tag = Format;

                            if (lvUnknownFormats.Items.Count == 0) {
                                lvUnknownFormats.Invoke(() => lvUnknownFormats.Items.Add(Language.GenericDoNotDownload));
                                NewFormat.ImageIndex = 0;
                            }

                            lvUnknownFormats.Invoke(() => lvUnknownFormats.Items.Add(NewFormat));
                        }
                    }

                    this.Invoke(() => {
                        this.Text = $"{Information.Title} - {Language.ApplicationName}";
                        txtExtendedDownloaderMediaTitle.Text = Information.Title;
                        rtbMediaDescription.Text = Information.Description;
                        txtUploader.Text = Information.Uploader;
                        txtViews.Text = $"{(Information.Views is not null ? Information.Views.Value.ToString("#,000") : "Unknown")}";
                        lbTimestamp.Text = Information.Duration;
                        tcVideoData.Enabled = true;

                        lbTimestamp.Location = new(
                            (pbThumbnail.Location.X + pbThumbnail.Size.Width) - lbTimestamp.Size.Width - 8,
                            (pbThumbnail.Location.Y + pbThumbnail.Size.Height) - lbTimestamp.Size.Height - 8);
                        lbTimestamp.Visible = true;

                        btnDownloadAbortClose.Enabled = true;
                        btnDownloadWithAuthentication.Enabled = true;
                        rbCustom.Enabled = true;
                        cbSchema.Enabled = true;

                        if (lvVideoFormats.Items.Count > 0) {
                            rbVideo.Enabled = true;
                            lvVideoFormats.Items[0].Selected = true;
                        }
                        else {
                            rbVideo.Enabled = false;
                            lbExtendedDownloaderNoVideoFormatsAvailable.Visible = true;
                        }

                        if (lvAudioFormats.Items.Count > 0) {
                            rbAudio.Enabled = true;
                            lvAudioFormats.Items[0].Selected = true;
                        }
                        else {
                            rbAudio.Enabled = false;
                            lbExtendedDownloaderNoAudioFormatsAvailable.Visible = true;
                        }

                        if (lvUnknownFormats.Items.Count > 0) {
                            rbUnknownFormat.Enabled = true;
                        }
                        else {
                            rbUnknownFormat.Enabled = false;
                            lbExtendedDownloaderNoUnknownFormatsFound.Visible = true;
                        }

                        if (rbVideo.Enabled) {
                            rbVideo.Checked = true;
                        }
                        else if (rbAudio.Enabled) {
                            rbAudio.Checked = true;
                            tcFormats.SelectedTab = tabAudioFormats;
                        }
                        else if (rbUnknownFormat.Enabled) {
                            rbUnknownFormat.Checked = true;
                            tcFormats.SelectedTab = tabExtendedDownloaderUnknownFormats;
                        }
                        else {
                            rbCustom.Checked = true;
                            tcFormats.SelectedTab = tabCustom;
                        }

                        if (Config.Settings.Downloads.ExtendedDownloaderAutoDownloadThumbnail)
                            DownloadThumbnail();
                        else
                            btnExtendedDownloaderDownloadThumbnail.Enabled = btnExtendedDownloaderDownloadThumbnail.Visible = true;
                    });
                }
                catch (ThreadAbortException) { }
                catch (Exception ex) {
                    this.Invoke(() => Log.ReportException(ex, Retrieved));
                }
            }) {
                Name = $"InfoThread {URL}",
                IsBackground = true,
                Priority = ThreadPriority.BelowNormal
            };
            InformationThread.Start();
        }
        private void DownloadThumbnail() {
            if (ThumbnailThread is null || !ThumbnailThread.IsAlive) {
                ThumbnailThread = new(() => {
                    try {
                        Image Thumb = Information.GetThumbnail();
                        if (Thumb is not null) {
                            this.Invoke(() => {
                                pbThumbnail.Image = Thumb;
                                lbExtendedDownloaderDownloadingThumbnail.Visible = false;
                                btnExtendedDownloaderDownloadThumbnail.Enabled = btnExtendedDownloaderDownloadThumbnail.Visible = false;
                            });
                        }
                        else {
                            this.Invoke(() => {
                                btnExtendedDownloaderDownloadThumbnail.Enabled = btnExtendedDownloaderDownloadThumbnail.Visible = true;
                                lbExtendedDownloaderDownloadingThumbnail.Text = Language.lbExtendedDownloaderDownloadingThumbnailFailed;
                            });
                        }
                    }
                    catch (ThreadAbortException) { }
                    catch (Exception ex) {
                        this.Invoke(() => {
                            btnExtendedDownloaderDownloadThumbnail.Enabled = btnExtendedDownloaderDownloadThumbnail.Visible = true;
                            lbExtendedDownloaderDownloadingThumbnail.Text = Language.lbExtendedDownloaderDownloadingThumbnailFailed;
                            Log.ReportException(ex);
                        });
                    }
                }) {
                    Name = $"ThumbThread {URL}",
                    IsBackground = true,
                    Priority = ThreadPriority.BelowNormal
                };
            }
            lbExtendedDownloaderDownloadingThumbnail.Visible = true;
            btnExtendedDownloaderDownloadThumbnail.Enabled = btnExtendedDownloaderDownloadThumbnail.Visible = false;
            lbExtendedDownloaderDownloadingThumbnail.Text = Language.lbExtendedDownloaderDownloadingThumbnail;
            ThumbnailThread.Start();
        }
        public string GenerateArguments(bool Authentication = false) {
            StringBuilder ArgumentBuffer = new($"\"{URL}\" -o \"");

            ArgumentBuffer.Append(
                Config.Settings.Downloads.downloadPath.StartsWith("./") || Config.Settings.Downloads.downloadPath.StartsWith(".\\") ?
                    $"{Program.ProgramPath}\\{Config.Settings.Downloads.downloadPath[2..]}" : Config.Settings.Downloads.downloadPath);

            if (Config.Settings.Downloads.separateIntoWebsiteURL) {
                if (URL.ToLower().StartsWith("ytarchive:")) {
                    ArgumentBuffer.Append($"\\archived.youtube.com");
                }
                else {
                    ArgumentBuffer.Append($"\\{DownloadHelper.GetUrlBase(URL)}");
                }
            }

            if (Config.Settings.Downloads.separateDownloads) {
                //ArgumentBuffer.Append(rbAudio.Checked ? "\\Audio" : rbCustom.Checked ? "\\Custom" : "\\Video");
                ArgumentBuffer.Append(
                    rbCustom.Checked ? "Custom" :
                    rbVideo.Checked && LastSelectedVideoFormat.Tag is not null ? "\\Video" :
                    rbAudio.Checked || LastSelectedAudioFormat.Tag is not null ? "\\Audio" :
                    "Custom");
            }

            StringBuilder Schema = new(cbSchema.Text.IsNullEmptyWhitespace() ? "%(title)s-%(id)s.%(ext)s" : cbSchema.Text);
            if (rbVideo.Checked && chkVideoSeparateAudio.Checked) {
                if (Schema.ToString().EndsWith(".%(ext)s")) {
                    Schema.Remove(0, Schema.Length - 8);
                }
                Schema.Append(rbVideo.Checked && chkVideoSeparateAudio.Checked ? "%(format_id)s.%(ext)s" : ".%(ext)s");
            }
            else if (!Schema.ToString().EndsWith(".%(ext)s")) {
                Schema.Append(".%(ext)s");
            }
            ArgumentBuffer.Append($"\\{Schema}\"");

            YoutubeDlFormat Format;

            string GetUnknownFormats() {
                StringBuilder Formats = new(string.Empty);
                if (lvUnknownFormats.SelectedItems.Count > 0) {
                    for (int i = 0; i < lvUnknownFormats.SelectedItems.Count; i++) {
                        if (lvUnknownFormats.SelectedItems[i].Tag is not null && lvUnknownFormats.SelectedItems[i].Tag is YoutubeDlFormat UnknownFormat) {
                            Formats.Append($",{UnknownFormat.Identifier}");
                        }
                    }
                }
                return Formats.ToString();
            }

            if (rbCustom.Checked) {
                ArgumentBuffer.Append(txtCustomArguments.Text.IsNotNullEmptyWhitespace() ?
                    $" {txtCustomArguments.Text.Replace("\r\n", "\n").Split('\n').Join(" ")}" : string.Empty);
            }
            else {
                bool Break = false;
                if (rbVideo.Checked) {
                    Format = LastSelectedVideoFormat.Tag as YoutubeDlFormat;
                    ArgumentBuffer.Append($" -f {Format.Identifier}");
                    if (chkVideoDownloadAudio.Checked && LastSelectedAudioFormat.Tag is not null && LastSelectedAudioFormat.Tag is YoutubeDlFormat AudioFormat) {
                        if (chkVideoSeparateAudio.Checked) {
                            ArgumentBuffer.Append($"/best,{AudioFormat.Identifier}/best");
                        }
                        else {
                            ArgumentBuffer.Append($"+{AudioFormat.Identifier}/best");
                        }
                    }
                    else {
                        ArgumentBuffer.Append("/best");
                    }

                    ArgumentBuffer.Append(GetUnknownFormats());

                    if (cbVideoRemux.SelectedIndex > 0) {
                        ArgumentBuffer.Append($" --remux-video {cbVideoRemux.GetItemText(cbVideoRemux.SelectedItem)}");
                    }
                    else if (cbVideoEncoders.SelectedIndex > 0) {
                        ArgumentBuffer.Append($" --recode-video {cbVideoEncoders.GetItemText(cbVideoEncoders.SelectedItem)}");
                    }
                }
                else if (rbAudio.Checked) {
                    Format = LastSelectedAudioFormat.Tag as YoutubeDlFormat;
                    ArgumentBuffer.Append($" -f {Format.Identifier}/best{GetUnknownFormats()}");

                    if (cbAudioEncoders.SelectedIndex > 0) {
                        ArgumentBuffer.Append($" -x --audio-format {cbAudioEncoders.GetItemText(cbAudioEncoders.SelectedItem)}");
                    }
                }
                else {
                    Format = default;
                    Break = true;
                }

                if (!Break) {
                    if (Config.Settings.Downloads.PreferFFmpeg || DownloadHelper.IsReddit(URL) && Config.Settings.Downloads.fixReddit) {
                        if (Verification.FFmpegPath.IsNullEmptyWhitespace())
                            Verification.RefreshFFmpegLocation();

                        if (Verification.FFmpegPath.IsNotNullEmptyWhitespace())
                            ArgumentBuffer.Append($" --ffmpeg-location \"{Verification.FFmpegPath}\" --hls-prefer-ffmpeg");
                    }

                    if (Config.Settings.Downloads.SaveSubtitles) {
                        ArgumentBuffer.Append(" --all-subs");
                        if (Config.Settings.Downloads.SubtitleFormat.IsNotNullEmptyWhitespace()) {
                            ArgumentBuffer.Append($" --sub-format {Config.Settings.Downloads.SubtitleFormat}");
                        }

                        if (Config.Settings.Downloads.EmbedSubtitles && rbVideo.Checked) {
                            ArgumentBuffer.Append(" --embed-subs");
                        }
                    }

                    if (Config.Settings.Downloads.SaveVideoInfo)
                        ArgumentBuffer.Append(" --write-info-json");

                    if (Config.Settings.Downloads.SaveDescription)
                        ArgumentBuffer.Append(" --write-description");

                    if (Config.Settings.Downloads.SaveAnnotations)
                        ArgumentBuffer.Append(" --write-annotations");

                    if (Config.Settings.Downloads.SaveThumbnail) {
                        ArgumentBuffer.Append(" --write-thumbnail");
                        if (Config.Settings.Downloads.EmbedThumbnails
                        && ((rbVideo.Checked && (Format.Extension.EndsWith("mp4") || cbVideoEncoders.SelectedIndex == 4))
                        || (rbAudio.Checked && (Format.Extension.EndsWith("mp3") || Format.Extension.EndsWith("m4a") || cbAudioEncoders.SelectedIndex == 1  || cbAudioEncoders.SelectedIndex == 2)))) {
                            ArgumentBuffer.Append(" --embed-thumbnail");
                        }
                    }

                    if (Config.Settings.Downloads.WriteMetadata)
                        ArgumentBuffer.Append(" --add-metadata");

                    if (Config.Settings.Downloads.KeepOriginalFiles)
                        ArgumentBuffer.Append(" -k");

                    if (Config.Settings.Downloads.LimitDownloads && Config.Settings.Downloads.DownloadLimit > 0) {
                        ArgumentBuffer.Append($" --limit-rate {Config.Settings.Downloads.DownloadLimit}{Config.Settings.Downloads.DownloadLimitType switch {
                            1 => "M",
                            2 => "G",
                            _ => "K"
                        }}");
                    }

                    if (Config.Settings.Downloads.RetryAttempts != 10 && Config.Settings.Downloads.RetryAttempts > 0)
                        ArgumentBuffer.Append($" --retries {Config.Settings.Downloads.RetryAttempts}");

                    if (Config.Settings.Downloads.ForceIPv4)
                        ArgumentBuffer.Append(" --force-ipv4");
                    else if (Config.Settings.Downloads.ForceIPv6)
                        ArgumentBuffer.Append(" --force-ipv6");

                    if (Config.Settings.Downloads.UseProxy && Config.Settings.Downloads.ProxyType > -1 && !string.IsNullOrEmpty(Config.Settings.Downloads.ProxyIP) && !string.IsNullOrEmpty(Config.Settings.Downloads.ProxyPort)) {
                        ArgumentBuffer.Append($"--proxy {DownloadHelper.ProxyProtocols[Config.Settings.Downloads.ProxyType]}{Config.Settings.Downloads.ProxyIP}:{Config.Settings.Downloads.ProxyPort}/");
                    }
                }
            }

            if (Authentication) {
                frmAuthentication auth = new();
                if (auth.ShowDialog() == DialogResult.OK) {
                    txtGeneratedArguments.Text = ArgumentBuffer.ToString();
                    if (auth.Username != null) {
                        ArgumentBuffer.Append($" --username {auth.Username}");
                        txtGeneratedArguments.AppendText(" --username ***");
                        auth.Username = null;
                    }
                    if (auth.Password != null) {
                        ArgumentBuffer.Append($" --password {auth.Password}");
                        txtGeneratedArguments.AppendText(" --password ***");
                        auth.Password = null;
                    }
                    if (auth.TwoFactor != null) {
                        ArgumentBuffer.Append($" --twofactor {auth.TwoFactor}");
                        txtGeneratedArguments.AppendText(" --twofactor ***");
                        auth.TwoFactor = null;
                    }
                    if (auth.VideoPassword != null) {
                        ArgumentBuffer.Append($" --video-password {auth.VideoPassword}");
                        txtGeneratedArguments.AppendText(" --video-password ***");
                        auth.VideoPassword = null;
                    }
                    if (auth.Netrc) {
                        ArgumentBuffer.Append(" --netrc");
                        txtGeneratedArguments.AppendText(" --netrc");
                    }
                    auth.Dispose();
                }
                else {
                    auth.Dispose();
                    return null;
                }
            }
            else txtGeneratedArguments.Text = ArgumentBuffer.ToString();

            string Data = ArgumentBuffer.ToString();
            ArgumentBuffer.Clear();
            return Data;
        }
        public void BeginDownload(bool Auth) {
            string args = GenerateArguments(Auth);
            if (args.IsNotNullEmptyWhitespace()) {
                if (Verification.YoutubeDlPath.IsNullEmptyWhitespace())
                    Verification.RefreshYoutubeDlLocation();

                if (Verification.YoutubeDlPath.IsNullEmptyWhitespace())
                    throw new NullReferenceException("Youtube-dl path is invalid and cannot be used.");

                btnDownloadWithAuthentication.Enabled = false;
                btnDownloadAbortClose.Text = Language.GenericCancel;
                pbStatus.ShowInTaskbar = true;
                pbStatus.Value = 0;
                pbStatus.ProgressState = murrty.controls.ProgressState.Normal;
                pbStatus.Text = "Retrieving metadata";
                DownloadThread = new(() => {
                    Program.RunningActions.Add(this);
                    DownloadProcess = new() {
                        StartInfo = new() {
                            Arguments = args,
                            CreateNoWindow = true,
                            FileName = Verification.YoutubeDlPath,
                            RedirectStandardError = true,
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            WindowStyle = ProcessWindowStyle.Hidden,
                        }
                    };
                    args = null;
                    Status = DownloadStatus.Downloading;
                    DownloadProcess.OutputDataReceived += (s, e) => {
                        if (e.Data is not null && e.Data.Length > 0) {
                            switch (e.Data[..5]) {
                                case "[down": case "[ffmp": {
                                    Msg = e.Data;
                                } break;

                                default: {
                                    Msg = e.Data.ToLower();
                                    if (Msg.StartsWith("[merger]")) {
                                        pbStatus.Invoke(() => {
                                            pbStatus.Style = ProgressBarStyle.Marquee;
                                            pbStatus.Value = pbStatus.Maximum;
                                            pbStatus.Text = "Merging formats...";
                                        });
                                    }
                                    else if (Msg.StartsWith("[videoconvertor]")) { // Converter?
                                        pbStatus.Invoke(() => {
                                            pbStatus.Style = ProgressBarStyle.Marquee;
                                            pbStatus.Value = pbStatus.Maximum;
                                            pbStatus.Text = "Converting video...";
                                        });
                                    }
                                    Msg = null;
                                    rtbVerbose.Invoke(() => rtbVerbose.AppendText(e.Data + "\n"));
                                } break;
                            }
                            //if (e.Data.IndexOf("[download]") > -1 || e.Data.IndexOf("[ffmpeg]") > -1) {
                            //}
                            //else {
                            //}
                        }
                    };
                    DownloadProcess.ErrorDataReceived += (s, e) => {
                        if (e.Data is not null)
                            rtbVerbose.Invoke(() => rtbVerbose.AppendText($"Error: {e.Data}\n"));
                    };
                    DownloadProcess.Start();
                    DownloadProcess.BeginOutputReadLine();
                    DownloadProcess.BeginErrorReadLine();

                    while (!DownloadProcess.HasExited) {
                        if ((Status == DownloadStatus.Aborted || Status == DownloadStatus.AbortForClose) && !DownloadProcess.HasExited) {
                            Program.KillProcessTree((uint)DownloadProcess.Id);
                            DownloadProcess.Kill();
                            break;
                        }

                        if (Msg is not null) {
                            string Line = Msg.ReplaceWhitespace();
                            string[] LineParts = Line.Split(' ');
                            rtbVerbose.Invoke(() => rtbVerbose.AppendText(Line + "\n"));
                            switch (Line[..5]) {
                                case "[down": {
                                    switch (LineParts[1][0]) {
                                        case '1': case '2': case '3':
                                        case '4': case '5': case '6':
                                        case '7': case '8': case '9':
                                        case '0': {
                                            if (LineParts[1].Contains('%')) {
                                                float Percentage = float.Parse(LineParts[1][..LineParts[1].IndexOf('%')]);
                                                pbStatus.Invoke(() => {
                                                    pbStatus.Text = $"{Percentage}% @ {LineParts[5]}";
                                                    pbStatus.Value = (int)Math.Floor(Percentage);
                                                });
                                            }
                                        } break;
                                    }
                                } break;
                                case "[ffmp": {
                                    pbStatus.Invoke(() => {
                                        pbStatus.Style = ProgressBarStyle.Marquee;
                                        pbStatus.Text = "Post processing";
                                        pbStatus.Value = 100;
                                    });
                                } break;
                            }
                        }

                        Thread.Sleep(500);
                    }

                    if (Status != DownloadStatus.Aborted && Status != DownloadStatus.AbortForClose)
                        Status = DownloadProcess.ExitCode == 0 ? DownloadStatus.Finished : DownloadStatus.YtdlError;

                    this.Invoke(() => {
                        if (chkDownloaderCloseAfterDownload.Checked && Status == DownloadStatus.Finished) {
                            this.Dispose();
                        }
                        else {
                            pbStatus.Style = ProgressBarStyle.Continuous;
                            pbStatus.ShowInTaskbar = false;
                            btnDownloadAbortClose.Enabled = true;
                            btnDownloadWithAuthentication.Enabled = true;
                            switch (Status) {
                                case DownloadStatus.Aborted: {
                                    pbStatus.Text = "Aborted";
                                    pbStatus.Value = pbStatus.Minimum;
                                    btnDownloadAbortClose.Text = Language.GenericRetry;
                                    System.Media.SystemSounds.Exclamation.Play();
                                } break;

                                case DownloadStatus.Finished: {
                                    pbStatus.Text = "Completed";
                                    pbStatus.Value = pbStatus.Maximum;
                                    btnDownloadAbortClose.Text = Language.sbDownload;
                                    System.Media.SystemSounds.Asterisk.Play();
                                } break;

                                case DownloadStatus.AbortForClose: { } break;

                                default: {
                                    pbStatus.Text = "Downlod error";
                                    pbStatus.Value = pbStatus.Minimum;
                                    btnDownloadAbortClose.Text = Language.GenericRetry;
                                    tcVideoData.SelectedTab = tabExtendedDownloaderVerbose;
                                    System.Media.SystemSounds.Hand.Play();
                                } break;
                            }
                        }
                    });

                    Program.RunningActions.Remove(this);
                }) {
                    Name = $"Download {URL}",
                    IsBackground = true,
                    Priority = ThreadPriority.BelowNormal
                };

                DownloadThread.Start();
            }
        }

        private void chkAudioVBR_CheckedChanged(object sender, EventArgs e) {
            cbVbrQualities.Enabled =
                chkAudioVBR.Checked && (rbAudio.Checked || (rbVideo.Checked && chkVideoDownloadAudio.Checked));
        }
        private void chkVideoDownloadAudio_CheckedChanged(object sender, EventArgs e) {
            chkAudioVBR.Enabled = cbAudioEncoders.Enabled = lvAudioFormats.Enabled = chkVideoSeparateAudio.Enabled =
                chkVideoDownloadAudio.Checked;

            cbVbrQualities.Enabled = chkVideoDownloadAudio.Checked && chkAudioVBR.Checked;

            if (LastSelectedAudioFormat is not null) {
                if (chkVideoDownloadAudio.Checked) {
                    if (LastSelectedAudioFormat.Index != 0) {
                        lvAudioFormats.Items[0].ImageIndex = 0;
                    }
                    LastSelectedAudioFormat.ImageIndex = 1;
                }
                else {
                    if (LastSelectedAudioFormat.Index != 0) {
                        lvAudioFormats.Items[0].ImageIndex = 2;
                    }
                    LastSelectedAudioFormat.ImageIndex = 3;
                }
            }
        }
        private void btnDownloadThumbnail_Click(object sender, EventArgs e) {
            DownloadThumbnail();
            lbExtendedDownloaderUploader.Focus();
        }
        private void btnDownloadWithAuthentication_Click(object sender, EventArgs e) {
            switch (Status) {
                case DownloadStatus.Finished: {
                    this.Dispose();
                } break;

                default: {
                    BeginDownload(true);
                } break;
            }
        }
        private void btnDownloadAbortClose_Click(object sender, EventArgs e) {
            //BeginDownload(false);
            switch (Status) {
                //case DownloadStatus.Finished: {
                //    this.Dispose();
                //} break;

                case DownloadStatus.Downloading: {
                    Status = DownloadStatus.Aborted;
                } break;

                default: {
                    BeginDownload(false);
                } break;
            }
        }

        private void rbVideo_CheckedChanged(object sender, EventArgs e) {
            if (rbVideo.Checked) {
                lvVideoFormats.Enabled = true;
                lvUnknownFormats.Enabled = lvUnknownFormats.Items.Count > 1;
                cbVideoRemux.Enabled = true;
                cbVideoEncoders.Enabled = true;
                chkVideoDownloadAudio.Enabled = true;
                txtCustomArguments.Enabled = false;

                // Does this work with videos?
                cbAudioEncoders.Enabled = false;

                lvAudioFormats.Enabled = chkAudioVBR.Enabled = chkVideoSeparateAudio.Enabled =
                    chkVideoDownloadAudio.Checked;


                cbVbrQualities.Enabled =
                    chkAudioVBR.Checked && chkVideoDownloadAudio.Checked;

                if (LastSelectedVideoFormat is not null) {
                    if (LastSelectedVideoFormat.Index != 0)
                        lvVideoFormats.Items[0].ImageIndex = 0;
                    LastSelectedVideoFormat.ImageIndex = 1;
                }

                if (LastSelectedAudioFormat is not null) {
                    if (chkVideoDownloadAudio.Checked) {
                        if (LastSelectedAudioFormat.Index != 0)
                            lvAudioFormats.Items[0].ImageIndex = 0;
                        LastSelectedAudioFormat.ImageIndex = 1;
                    }
                    else {
                        if (LastSelectedAudioFormat.Index != 0)
                            lvAudioFormats.Items[0].ImageIndex = 2;
                        LastSelectedAudioFormat.ImageIndex = 3;
                    }
                }

                if (LastSelectedUnknownFormat is not null) {
                    if (LastSelectedUnknownFormat.Index == 0) {
                        LastSelectedUnknownFormat.ImageIndex = -1;
                        lvUnknownFormats.Items[1].Selected = true;
                    }

                    if (LastSelectedUnknownFormat.Index != 1)
                        lvUnknownFormats.Items[1].ImageIndex = 2;
                    LastSelectedUnknownFormat.ImageIndex = 1;
                }
                else if (lvUnknownFormats.Items.Count > 0) {
                    lvUnknownFormats.Items[1].ImageIndex = 0;
                }
            }
        }
        private void rbAudio_CheckedChanged(object sender, EventArgs e) {
            if (rbAudio.Checked) {
                lvVideoFormats.Enabled = false;
                lvUnknownFormats.Enabled = lvUnknownFormats.Items.Count > 1;
                chkVideoDownloadAudio.Enabled = false;
                cbVideoRemux.Enabled = false;
                cbVideoEncoders.Enabled = false;
                chkVideoSeparateAudio.Enabled = false;
                txtCustomArguments.Enabled = false;

                lvAudioFormats.Enabled = true;
                chkAudioVBR.Enabled = true;
                cbAudioEncoders.Enabled = true;

                cbVbrQualities.Enabled = chkAudioVBR.Checked;

                if (LastSelectedVideoFormat is not null) {
                    if (LastSelectedVideoFormat.Index != 0)
                        lvVideoFormats.Items[0].ImageIndex = 2;
                    LastSelectedVideoFormat.ImageIndex = 3;
                }

                if (LastSelectedAudioFormat is not null) {
                    if (LastSelectedAudioFormat.Index != 0)
                        lvAudioFormats.Items[0].ImageIndex = 0;
                    LastSelectedAudioFormat.ImageIndex = 1;
                }

                if (LastSelectedUnknownFormat is not null) {
                    if (LastSelectedUnknownFormat.Index == 0) {
                        LastSelectedUnknownFormat.ImageIndex = -1;
                        lvUnknownFormats.Items[1].Selected = true;
                    }

                    if (LastSelectedUnknownFormat.Index != 1)
                        lvUnknownFormats.Items[1].ImageIndex = 2;
                    LastSelectedUnknownFormat.ImageIndex = 1;
                }
                else if (lvUnknownFormats.Items.Count > 0) {
                    lvUnknownFormats.Items[1].ImageIndex = 0;
                }
            }
        }
        private void rbUnknownFormat_CheckedChanged(object sender, EventArgs e) {
            if (rbUnknownFormat.Checked) {
                lvVideoFormats.Enabled = false;
                lvAudioFormats.Enabled = false;
                lvUnknownFormats.Enabled = true;
                chkAudioVBR.Enabled = false;
                cbVbrQualities.Enabled = false;
                chkVideoDownloadAudio.Enabled = false;
                chkVideoSeparateAudio.Enabled = false;
                cbVideoRemux.Enabled = false;
                cbVideoEncoders.Enabled = false;
                cbAudioEncoders.Enabled = false;
                txtCustomArguments.Enabled = true;

                if (LastSelectedVideoFormat is not null) {
                    if (LastSelectedVideoFormat.Index != 0)
                        lvVideoFormats.Items[0].ImageIndex = 2;
                    LastSelectedVideoFormat.ImageIndex = 3;
                }

                if (LastSelectedAudioFormat is not null) {
                    if (LastSelectedAudioFormat.Index != 0)
                        lvAudioFormats.Items[0].ImageIndex = 2;
                    LastSelectedAudioFormat.ImageIndex = 3;
                }

                if (LastSelectedUnknownFormat is not null) {
                    if (LastSelectedUnknownFormat.Index == 0) {
                        LastSelectedUnknownFormat.ImageIndex = -1;
                        lvUnknownFormats.Items[1].Selected = true;
                    }

                    if (LastSelectedUnknownFormat.Index != 1)
                        lvUnknownFormats.Items[1].ImageIndex = 2;
                    LastSelectedUnknownFormat.ImageIndex = 1;
                }
                else if (lvUnknownFormats.Items.Count > 0) {
                    lvUnknownFormats.Items[1].Selected = true;
                }
            }
        }
        private void rbCustom_CheckedChanged(object sender, EventArgs e) {
            if (rbCustom.Checked) {
                lvVideoFormats.Enabled = false;
                lvAudioFormats.Enabled = false;
                lvUnknownFormats.Enabled = false;
                chkAudioVBR.Enabled = false;
                cbVbrQualities.Enabled = false;
                chkVideoDownloadAudio.Enabled = false;
                chkVideoSeparateAudio.Enabled = false;
                cbVideoRemux.Enabled = false;
                cbVideoEncoders.Enabled = false;
                cbAudioEncoders.Enabled = false;
                txtCustomArguments.Enabled = true;

                if (LastSelectedVideoFormat is not null) {
                    if (LastSelectedVideoFormat.Index != 0)
                        lvVideoFormats.Items[0].ImageIndex = 2;
                    LastSelectedVideoFormat.ImageIndex = 3;
                }

                if (LastSelectedAudioFormat is not null) {
                    if (LastSelectedAudioFormat.Index != 0)
                        lvAudioFormats.Items[0].ImageIndex = 2;
                    LastSelectedAudioFormat.ImageIndex = 3;
                }

                if (LastSelectedUnknownFormat is not null) {
                    if (LastSelectedUnknownFormat.Index != 1)
                        lvUnknownFormats.Items[1].ImageIndex = 2;
                    LastSelectedUnknownFormat.ImageIndex = 3;
                }
                else if (lvUnknownFormats.Items.Count > 0) {
                    lvUnknownFormats.Items[1].ImageIndex = 2;
                }
            }
        }

        private void btnCreateArgs_Click(object sender, EventArgs e) {
            MessageBox.Show(GenerateArguments(false) ?? "No args");
        }
        private void btnPbAdd_Click(object sender, EventArgs e) {
            if (pbStatus.Value < pbStatus.Maximum)
                pbStatus.Value++;
        }
        private void btnPbRemove_Click(object sender, EventArgs e) {
            if (pbStatus.Value > pbStatus.Minimum)
                pbStatus.Value--;
        }
        private void chkPbTaskbar_CheckedChanged(object sender, EventArgs e) {
            pbStatus.ShowInTaskbar = chkPbTaskbar.Checked;
        }
        private void btnKill_Click(object sender, EventArgs e) {
            if (DownloadProcess is not null && !DownloadProcess.HasExited) {
                Program.KillProcessTree((uint)DownloadProcess.Id);
                DownloadProcess.Kill();
            }
        }

    }
}