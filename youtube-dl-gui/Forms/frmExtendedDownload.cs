using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmExtendedDownload : Form {

        private VideoInformation Information;
        private VideoInformation.Format VideoFormat;
        private VideoInformation.Format AudioFormat;
        private Process DownloadProcess;
        private string Msg;
        private DownloadStatus Status = DownloadStatus.None;

        private string URL { get; }

        private readonly Thread InformationThread;
        private readonly Thread ThumbnailThread;
        private Thread DownloadThread;

        public frmExtendedDownload(string URL) {
            InitializeComponent();
            LoadLanguage();
            this.URL = URL;

            if (!Program.DebugMode) {
                tcVideoData.TabPages.Remove(tpDebug);
            }

            lvVideoFormats.SelectedIndexChanged += (s, e) => {
                if (lvVideoFormats.SelectedItems.Count > 0) {
                    VideoFormat = lvVideoFormats.SelectedItems[0].Tag as VideoInformation.Format;
                }
            };
            lvAudioFormats.SelectedIndexChanged += (s, e) => {
                if (lvAudioFormats.SelectedItems.Count > 0) {
                    AudioFormat = lvAudioFormats.SelectedItems[0].Tag as VideoInformation.Format;
                }
            };

            cbVideoEncoders.Items.AddRange(
                new[] { "avi", "flv", "mkv", "mp4", "ogg", "webm" });
            cbVideoEncoders.SelectedIndex = 0;

            cbAudioEncoders.Items.AddRange(
                new[] { "aac", "flac", "mp3", "m4v", "opus", "vorbis", "wav" });
            cbAudioEncoders.SelectedIndex = 0;

            cbVbrQualities.Items.AddRange(Formats.VbrQualities);

            rbVideo.Checked = true;

            InformationThread = new(() => {
                string Retrieved = null;
                try {
                    Information = VideoInformation.GenerateInformation(URL, out Retrieved);
                    VideoInformation.Format Format;
                    for (int i = Information.AvailableFormats.Length; i > 0; i--) {
                        Format = Information.AvailableFormats[i - 1];

                        if (Format.VideoWidth > 0 && Format.VideoHeight > 0 && Format.ValidVideoFormat()) {
                            if (lvVideoFormats.Items.Count == 0)
                                VideoFormat = Format;

                            string LegibleQualityName = Format.QualityName.IsNotNullEmptyWhitespace() ? Format.QualityName : "?";
                            string Dimensions = $"{Format.VideoWidth}x{Format.VideoHeight}";
                            string Bitrate = Format.VideoBitrate is not null && Format.VideoBitrate > 0 ? $"{Format.VideoBitrate}Kbps" : "?";
                            string Container = Format.Extension ?? "Unknown";
                            string Frames = Format.VideoFps is not null && Format.VideoFps > 0 ? $"{Format.VideoFps}" : "?";
                            string Codec = Format.VideoCodec.IsNotNullEmptyWhitespace() && Format.VideoCodec != "none" ? Format.VideoCodec : "Unknown";
                            string FileSize = Format.FileSize is not null ?
                                ((long)Format.FileSize).SizeToString() : Format.ApproximateFileSize is not null ?
                                ((long)Format.ApproximateFileSize).SizeToString() : "?B";

                            ListViewItem NewFormat = new($"{(lvVideoFormats.Items.Count == 0 ? "(!) " : "")}{LegibleQualityName}");
                            NewFormat.SubItems.Add(Frames);
                            NewFormat.SubItems.Add(Container);
                            NewFormat.SubItems.Add(FileSize);
                            NewFormat.SubItems.Add(Bitrate);
                            NewFormat.SubItems.Add(Dimensions);
                            NewFormat.SubItems.Add(Codec);
                            NewFormat.Tag = Format;
                            lvVideoFormats.Invoke(() => lvVideoFormats.Items.Add(NewFormat));
                        }
                        else if (Format.AudioCodec.IsNotNullEmptyWhitespace() && Format.AudioCodec != "none") {
                            if (lvAudioFormats.Items.Count == 0)
                                AudioFormat = Format;

                            string Codec = Format.AudioCodec ?? "Unknown";
                            string Container = Format.Extension ?? "Unknown";
                            string SampleRate = $"{(Format.AudioSampleRate is not null && Format.AudioSampleRate > 0 ? $"{Format.AudioSampleRate}" : "?")}Hz";
                            string Bitrate = $"{(Format.AudioBitrate is not null && Format.AudioBitrate > 0 ? $"{Format.AudioBitrate}" : "?")}Kbps";
                            string FileSize = Format.FileSize is not null ?
                                ((long)Format.FileSize).SizeToString() : Format.ApproximateFileSize is not null ?
                                ((long)Format.ApproximateFileSize).SizeToString() : "?B";

                            ListViewItem NewFormat = new($"{(lvAudioFormats.Items.Count == 0 ? "(!) " : "")}{Bitrate}");
                            NewFormat.SubItems.Add(Container);
                            NewFormat.SubItems.Add(FileSize);
                            NewFormat.SubItems.Add(SampleRate);
                            NewFormat.SubItems.Add(Codec);
                            NewFormat.Tag = Format;
                            lvAudioFormats.Invoke(() => lvAudioFormats.Items.Add(NewFormat));
                        }
                    }

                    this.Invoke(() => {
                        this.Text = $"{Information.Title} - {Language.ApplicationName}";
                        txtMediaTitle.Text = Information.Title;
                        rtbMediaDescription.Text = Information.Description;
                        txtUploader.Text = Information.Uploader;
                        txtViews.Text = $"{(Information.Views is not null ? ((long)Information.Views).ToString("#,000") : "Unknown")}";
                        lbTimestamp.Text = Information.Duration;
                        tcVideoData.Enabled = true;

                        if (Config.Settings.Downloads.YtdlpExtendedAutoDownloadThumbnail) {
                            ThumbnailThread.Start();
                            btnExtendedDownloaderDownloadThumbnail.Enabled = btnExtendedDownloaderDownloadThumbnail.Visible = false;
                        }
                        else {
                            btnExtendedDownloaderDownloadThumbnail.Enabled = btnExtendedDownloaderDownloadThumbnail.Visible = true;
                        }

                        lbTimestamp.Location = new(
                            (pbThumbnail.Location.X + pbThumbnail.Size.Width) - lbTimestamp.Size.Width - 8,
                            (pbThumbnail.Location.Y + pbThumbnail.Size.Height) - lbTimestamp.Size.Height - 8);
                        lbTimestamp.Visible = true;

                        btnDownloadAbortClose.Enabled = true;
                        btnDownloadWithAuthentication.Enabled = true;

                        if (lvVideoFormats.Items.Count > 0)
                            lvVideoFormats.Items[0].Selected = true;

                        if (lvAudioFormats.Items.Count > 0)
                            lvAudioFormats.Items[0].Selected = true;
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

            ThumbnailThread = new(() => {
                try {
                    this.Invoke(() => {
                        lbExtendedDownloaderDownloadingThumbnail.Visible = true;
                        btnExtendedDownloaderDownloadThumbnail.Enabled = btnExtendedDownloaderDownloadThumbnail.Visible = false;
                        lbExtendedDownloaderDownloadingThumbnail.Text = Language.lbExtendedDownloaderDownloadingThumbnail;
                    });
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
                    Log.ReportException(ex);
                }
            }) {
                Name = $"ThumbThread {URL}",
                IsBackground = true,
                Priority = ThreadPriority.BelowNormal
            };

            this.Shown += (s, e) => {
                InformationThread.Start();
                lbExtendedDownloaderUploader.Focus();
            };

            this.FormClosing += (s, e) => {
                switch (Status) {
                    case DownloadStatus.Downloading: {
                        Status = DownloadStatus.Aborted;
                        e.Cancel = true;
                    } break;

                    default: {
                        if (InformationThread is not null && InformationThread.IsAlive) {
                            InformationThread.Abort();
                        }
                        if (ThumbnailThread is not null && ThumbnailThread.IsAlive) {
                            ThumbnailThread.Abort();
                        }

                        this.Dispose();
                    } break;
                }
            };
        }

        private void LoadLanguage() {
            this.Text = Language.frmExtendedDownloaderRetrieving.Format(Language.ApplicationName);
            lbExtendedDownloaderUploader.Text = Language.lbExtendedDownloaderUploader;
            lbExtendedDownloaderViews.Text = Language.lbExtendedDownloaderViews;
            btnExtendedDownloaderDownloadThumbnail.Text = Language.btnExtendedDownloaderDownloadThumbnail;
            rbVideo.Text = Language.GenericVideo;
            rbAudio.Text = Language.GenericAudio;
            rbCustom.Text = Language.GenericCustom;
            chkVideoDownloadAudio.Text = Language.GenericSound;
            tpVideoFormats.Text = Language.GenericVideo;
            tpAudioFormats.Text = Language.GenericAudio;
            tpFormats.Text = Language.lbFormat;
            lbVideoEncoder.Text = Language.GenericVideo;
            lbAudioEncoder.Text = Language.GenericAudio;
            btnDownloadAbortClose.Text = Language.sbDownload;
            btnDownloadWithAuthentication.Text = Language.mDownloadWithAuthentication;
            tpFormatOptions.Text = Language.tpExtendedDownloaderFormatOptions;
            lbSchema.Text = Language.lbSettingsDownloadsFileNameSchema;
            chkVideoSeparateAudio.Text = Language.chkExtendedDownloaderVideoSeparateAudio;
        }

        public string GenerateArguments(bool Authentication = false) {
            StringBuilder ArgumentBuffer = new($"\"{URL}\" -o \"");

            ArgumentBuffer.Append(
                Config.Settings.Downloads.downloadPath.StartsWith("./") || Config.Settings.Downloads.downloadPath.StartsWith(".\\") ?
                    $"{Program.ProgramPath}\\{Config.Settings.Downloads.downloadPath[2..]}" : Config.Settings.Downloads.downloadPath);

            if (Config.Settings.Downloads.separateIntoWebsiteURL)
                ArgumentBuffer.Append($"\\{Download.getUrlBase(URL)}");

            if (Config.Settings.Downloads.separateDownloads)
                ArgumentBuffer.Append(rbAudio.Checked ? "\\Audio" : rbCustom.Checked ? "\\Custom" : "\\Video");

            ArgumentBuffer.Append($"\\{(
                Config.Settings.Downloads.fileNameSchema.IsNotNullEmptyWhitespace() ?
                    Config.Settings.Downloads.fileNameSchema : "%(title)s-%(id)s.%(ext)s")}\"");

            VideoInformation.Format Format;

            if (rbCustom.Checked) {
                ArgumentBuffer.Append(txtCustomArguments.Text.IsNotNullEmptyWhitespace() ?
                    $" {txtCustomArguments.Text.Replace("\r\n", "\n").Split('\n').Join(" ")}" : string.Empty);
            }
            else {
                bool Break = false;
                if (rbVideo.Checked) {
                    Format = VideoFormat;
                    ArgumentBuffer.Append($" -f {VideoFormat.Identifier}");
                    if (chkVideoDownloadAudio.Checked && AudioFormat is not null) {
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

                    if (cbVideoEncoders.SelectedIndex > 0) {
                        ArgumentBuffer.Append($" --recode-video {cbVideoEncoders.GetItemText(cbVideoEncoders.SelectedItem)}");
                    }
                }
                else if (rbAudio.Checked) {
                    Format = AudioFormat;
                    ArgumentBuffer.Append($" -f {AudioFormat.Identifier}/best");

                    if (cbAudioEncoders.SelectedIndex > 0) {
                        ArgumentBuffer.Append($" --audio-format {cbAudioEncoders.GetItemText(cbAudioEncoders.SelectedItem)}");
                    }
                }
                else {
                    Format = default;
                    Break = true;
                }

                if (!Break) {
                    if (Config.Settings.Downloads.PreferFFmpeg || Download.isReddit(URL) && Config.Settings.Downloads.fixReddit) {
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
                        ArgumentBuffer.Append($"--proxy {Download.ProxyProtocols[Config.Settings.Downloads.ProxyType]}{Config.Settings.Downloads.ProxyIP}:{Config.Settings.Downloads.ProxyPort}/");
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
                pbStatus.Text = "Retrieving metadata";
                DownloadThread = new(() => {
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
                        if (e.Data is not null) {
                            if (e.Data.IndexOf("[download]") > -1 || e.Data.IndexOf("[ffmpeg]") > -1) {
                                Msg = e.Data;
                            }
                            else {
                                rtbVerbose.Invoke(() => rtbVerbose.AppendText(e.Data + "\n"));
                            }
                        }
                    };
                    DownloadProcess.ErrorDataReceived += (s, e) => {
                        if (e.Data is not null)
                            rtbVerbose.Invoke(() => rtbVerbose.AppendText(e.Data + "\n"));
                    };
                    DownloadProcess.Start();
                    DownloadProcess.BeginOutputReadLine();
                    DownloadProcess.BeginErrorReadLine();

                    while (!DownloadProcess.HasExited) {
                        if (Msg is not null) {
                            string Line = Regex.Replace(Msg, "\\s+", " ");
                            string[] LineParts = Line.Split(' ');
                            rtbVerbose.Invoke(() => rtbVerbose.AppendText(Line + "\n"));

                            if (Line.IndexOf("[download]") > -1) {
                                switch (LineParts[1][0]) {
                                    case '0':
                                    case '1': case '2': case '3':
                                    case '4': case '5': case '6':
                                    case '7': case '8': case '9': {
                                        if (LineParts[1].Contains('%')) {
                                            float Percentage = float.Parse(LineParts[1][..LineParts[1].IndexOf('%')]);
                                            pbStatus.Invoke(() => {
                                                pbStatus.Text = $"{Percentage}% @ {LineParts[5]}";
                                                pbStatus.Value = (int)Math.Round(Percentage, MidpointRounding.ToEven);
                                            });
                                        }
                                    } break;
                                }
                            }
                            else if (Line.IndexOf("[ffmpeg]") > -1) {
                                pbStatus.Invoke(() => {
                                    pbStatus.Style = ProgressBarStyle.Marquee;
                                    pbStatus.Text = "Transcoding...";
                                    pbStatus.Value = 100;
                                });
                            }
                        }

                        if ((Status == DownloadStatus.Aborted || Status == DownloadStatus.AbortForClose) && !DownloadProcess.HasExited) {
                            Program.KillProcessTree((uint)DownloadProcess.Id);
                            break;
                        }

                        Thread.Sleep(500);
                    }

                    if (Status != DownloadStatus.Aborted && Status != DownloadStatus.AbortForClose)
                        Status = DownloadProcess.ExitCode == 0 ? DownloadStatus.Finished : DownloadStatus.YtdlError;

                    this.Invoke(() => {
                        pbStatus.ShowInTaskbar = false;
                        btnDownloadAbortClose.Enabled = true;
                        btnDownloadWithAuthentication.Enabled = true;
                        switch (Status) {

                            case DownloadStatus.Aborted: {
                                pbStatus.Text = "Aborted";
                                pbStatus.Value = pbStatus.Minimum;
                                btnDownloadAbortClose.Text = Language.GenericRetry;
                            } break;

                            case DownloadStatus.Finished: {
                                pbStatus.Text = "Completed";
                                pbStatus.Value = pbStatus.Maximum;
                                btnDownloadAbortClose.Text = Language.sbDownload;
                            } break;

                            case DownloadStatus.AbortForClose: { } break;

                            default: {
                                pbStatus.Text = "Downlod error";
                                pbStatus.Value = pbStatus.Minimum;
                                btnDownloadAbortClose.Text = Language.GenericRetry;
                                tcVideoData.SelectedTab = tpVerbose;
                            } break;
                        }
                    });
                }) {
                    Name = $"Download {URL}",
                    IsBackground = true,
                    Priority = ThreadPriority.BelowNormal
                };

                DownloadThread.Start();
            }
        }

        private void btnDownloadThumbnail_Click(object sender, EventArgs e) {
            ThumbnailThread.Start();
            lbExtendedDownloaderUploader.Focus();
        }

        private void rbVideo_CheckedChanged(object sender, EventArgs e) {
            if (rbVideo.Checked) {
                pnCustom.Enabled = pnCustom.Visible = false;
                pnAudioVideo.Enabled = pnAudioVideo.Visible = true;

                cbSchema.Enabled = true;

                lvVideoFormats.Enabled = true;
                cbVideoEncoders.Enabled = true;
                chkVideoDownloadAudio.Enabled = true;

                lvAudioFormats.Enabled = cbAudioEncoders.Enabled = chkAudioVBR.Enabled = chkVideoSeparateAudio.Enabled =
                    chkVideoDownloadAudio.Checked;

                cbVbrQualities.Enabled =
                    chkAudioVBR.Checked && chkVideoDownloadAudio.Checked;
            }
        }
        private void rbAudio_CheckedChanged(object sender, EventArgs e) {
            if (rbAudio.Checked) {
                pnCustom.Enabled = pnCustom.Visible = false;
                pnAudioVideo.Enabled = pnAudioVideo.Visible = true;

                cbSchema.Enabled = true;

                lvVideoFormats.Enabled = false;
                chkVideoDownloadAudio.Enabled = false;
                cbVideoEncoders.Enabled = false;
                chkVideoSeparateAudio.Enabled = false;

                lvAudioFormats.Enabled = true;
                chkAudioVBR.Enabled = true;
                cbAudioEncoders.Enabled = true;

                cbVbrQualities.Enabled = chkAudioVBR.Checked;
            }
        }
        private void rbCustom_CheckedChanged(object sender, EventArgs e) {
            if (rbCustom.Checked) {
                pnCustom.Enabled = pnCustom.Visible = true;
                pnAudioVideo.Enabled = pnAudioVideo.Visible = false;

                lvVideoFormats.Enabled = false;
                lvAudioFormats.Enabled = false;
                chkAudioVBR.Enabled = false;
                cbVbrQualities.Enabled = false;
                chkVideoDownloadAudio.Enabled = false;
                chkVideoSeparateAudio.Enabled = false;
                cbVideoEncoders.Enabled = false;
                cbAudioEncoders.Enabled = false;
                cbSchema.Enabled = false;
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

        private void btnDownloadAbortClose_Click(object sender, EventArgs e) {
            BeginDownload(false);
            //switch (Status) {
            //    case DownloadStatus.Finished: {
            //        this.Dispose();
            //    } break;

            //    case DownloadStatus.Downloading: {
            //        Status = DownloadStatus.Aborted;
            //    } break;

            //    default: {
            //        BeginDownload(false);
            //    } break;
            //}
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

        private void btnKill_Click(object sender, EventArgs e) {
            if (DownloadProcess is not null && !DownloadProcess.HasExited) {
                Program.KillProcessTree((uint)DownloadProcess.Id);
            }
        }

        private void chkVideoDownloadAudio_CheckedChanged(object sender, EventArgs e) {
            chkAudioVBR.Enabled = cbAudioEncoders.Enabled = lvAudioFormats.Enabled = chkVideoSeparateAudio.Enabled =
                chkVideoDownloadAudio.Checked;

            cbVbrQualities.Enabled = chkVideoDownloadAudio.Checked && chkAudioVBR.Checked;
        }

        private void chkAudioVBR_CheckedChanged(object sender, EventArgs e) {
            cbVbrQualities.Enabled =
                chkAudioVBR.Checked && (rbAudio.Checked || (rbVideo.Checked && chkVideoDownloadAudio.Checked));
        }

    }
}
