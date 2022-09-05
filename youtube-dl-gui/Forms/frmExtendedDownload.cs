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
        private readonly List<string> OutputMsg = new(128);
        private string Msg;
        private DownloadStatus Status = DownloadStatus.None;

        private string URL { get; }

        private readonly Thread InformationThread;
        private readonly Thread ThumbnailThread;
        private Thread Output;
        private Thread DownloadThread;

        public frmExtendedDownload(string URL) {
            InitializeComponent();
            this.URL = URL;

            rbVideo.CheckedChanged += (s, e) => {
                pnCustom.Enabled = pnCustom.Visible = false;
                pnAudioVideo.Enabled = pnAudioVideo.Visible = true;

                chkVideoDownloadAudio.Enabled = true;
                lvVideoFormats.Enabled = true;
            };
            rbAudio.CheckedChanged += (s, e) => {
                pnCustom.Enabled = pnCustom.Visible = false;
                pnAudioVideo.Enabled = pnAudioVideo.Visible = true;

                chkVideoDownloadAudio.Enabled = false;
                lvVideoFormats.Enabled = false;
            };
            rbCustom.CheckedChanged += (s, e) => {
                pnAudioVideo.Enabled = pnAudioVideo.Visible = false;
                pnCustom.Enabled = pnCustom.Visible = true;

                chkVideoDownloadAudio.Enabled = false;
            };

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

            cbVideoEncoders.SelectedIndex = 0;
            cbVideoEncoders.Items.AddRange(
                new[] { "avi", "flv", "mkv", "mp4", "ogg", "webm" });
            cbAudioEncoders.SelectedIndex = 0;
            cbAudioEncoders.Items.AddRange(
                new[] { "aac", "flac", "mp3", "m4v", "opus", "vorbis", "wav" });

            rbVideo.Checked = true;

            LoadLanguage();
            InformationThread = new(() => {
                try {
                    Information = VideoInformation.GenerateInformation(URL);
                    VideoInformation.Format Format;
                    for (int i = Information.formats.Length; i > 0; i--) {
                        Format = Information.formats[i - 1];

                        if (Format.width > 0 && Format.height > 0) {
                            if (lvVideoFormats.Items.Count == 0)
                                VideoFormat = Format;

                            string LegibleQualityName = Format.format_note.IsNotNullEmptyWhitespace() ? Format.format_note : "?";
                            string Dimensions = $"{Format.width}x{Format.height}";
                            string Bitrate = Format.tbr is not null && Format.tbr > 0 ? $"{Format.tbr}k" : "?";
                            string Container = Format.ext ?? "Unknown";
                            string Frames = Format.fps is not null && Format.fps > 0 ? $"{Format.fps}" : "FPS?";
                            string Codec = Format.vcodec.IsNotNullEmptyWhitespace() && Format.vcodec != "none" ? Format.vcodec : "Unknown";
                            string FileSize = Format.filesize is not null ? 
                                ((long)Format.filesize).SizeToString() : Format.filesize_approx is not null ?
                                ((long)Format.filesize_approx).SizeToString() : "?B";

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
                        else if (Format.acodec.IsNotNullEmptyWhitespace() && Format.acodec != "none") {
                            if (lvAudioFormats.Items.Count == 0)
                                AudioFormat = Format;

                            string Codec = Format.acodec ?? "Unknown";
                            string Container = Format.ext ?? "Unknown";
                            string SampleRate = $"{(Format.asr is not null && Format.asr > 0 ? $"{Format.asr}" : "-")}Hz";
                            string Bitrate = $"{(Format.abr is not null && Format.abr > 0 ? $"{Format.abr}" : "?")}kbps";
                            string FileSize = Format.filesize is not null ?
                                ((long)Format.filesize).SizeToString() : Format.filesize_approx is not null ?
                                ((long)Format.filesize_approx).SizeToString() : "?B";

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
                        this.Text = $"{Information.title} - {Language.ApplicationName}";
                        txtMediaTitle.Text = Information.title;
                        rtbMediaDescription.Text = Information.description;
                        txtUploader.Text = Information.uploader;
                        txtViews.Text = $"{(Information.view_count is not null ? ((long)Information.view_count).ToString("#,000") : "Unknown")}";
                        lbTimestamp.Text = Information.duration_string;
                        btnExtendedDownloaderDownloadThumbnail.Enabled =
                            tcVideoData.Enabled = btnExtendedDownloaderDownloadThumbnail.Visible = true;

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
                catch (Exception ex) {
                    Log.ReportException(ex);
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
                        lbExtendedDownloaderDownloadingThumbnail.Text = Program.lang.lbExtendedDownloaderDownloadingThumbnail;
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
                            lbExtendedDownloaderDownloadingThumbnail.Text = Program.lang.lbExtendedDownloaderDownloadingThumbnailFailed;
                        });
                    }
                }
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
                if (InformationThread is not null && InformationThread.IsAlive) {
                    InformationThread.Abort();
                }
                if (ThumbnailThread is not null && ThumbnailThread.IsAlive) {
                    ThumbnailThread.Abort();
                }
            };
        }

        private void LoadLanguage() {
            this.Text = Program.lang.frmExtendedDownloaderRetrieving.Format(Language.ApplicationName);
            lbExtendedDownloaderUploader.Text = Program.lang.lbExtendedDownloaderUploader;
            lbExtendedDownloaderViews.Text = Program.lang.lbExtendedDownloaderViews;
            btnExtendedDownloaderDownloadThumbnail.Text = Program.lang.btnExtendedDownloaderDownloadThumbnail;
            rbVideo.Text = Program.lang.GenericVideo;
            rbAudio.Text = Program.lang.GenericAudio;
            rbCustom.Text = Program.lang.GenericCustom;
            chkVideoDownloadAudio.Text = Program.lang.chkDownloadSound;
            tpVideoFormats.Text = Program.lang.GenericVideo;
            tpAudioFormats.Text = Program.lang.GenericAudio;
            tpFormats.Text = Program.lang.lbFormat;
            lbVideoEncoder.Text = Program.lang.GenericVideo;
            lbAudioEncoder.Text = Program.lang.GenericAudio;
            btnDownloadAbortClose.Text = Program.lang.sbDownload;
            btnDownloadWithAuthentication.Text = Program.lang.mDownloadWithAuthentication;
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
                    ArgumentBuffer.Append($" -f {VideoFormat.format_id}");
                    if (chkVideoDownloadAudio.Checked) {
                        ArgumentBuffer.Append($"+{AudioFormat.format_id}");
                    }
                    ArgumentBuffer.Append("/best");

                }
                else if (rbAudio.Checked) {
                    Format = AudioFormat;
                }
                else {
                    Format = default;
                    Break = true;
                }

                if (!Break) {
                    if (Config.Settings.Downloads.PreferFFmpeg || Download.isReddit(URL) && Config.Settings.Downloads.fixReddit) {
                        if (Program.verif.FFmpegPath.IsNullEmptyWhitespace())
                            Program.verif.RefreshFFmpegLocation();

                        if (Program.verif.FFmpegPath.IsNotNullEmptyWhitespace())
                            ArgumentBuffer.Append($" --ffmpeg-location \"{Program.verif.FFmpegPath}\" --hls-prefer-ffmpeg");
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
                        && ((rbVideo.Checked && (Format.ext.EndsWith("mp4") || cbVideoEncoders.SelectedIndex == 4))
                        || (rbAudio.Checked && (Format.ext.EndsWith("mp3") || Format.ext.EndsWith("m4a") || cbAudioEncoders.SelectedIndex == 1  || cbAudioEncoders.SelectedIndex == 2)))) {
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
                    txtCustomArguments.Text = ArgumentBuffer.ToString();
                    if (auth.Username != null) {
                        ArgumentBuffer.Append($" --username {auth.Username}");
                        txtCustomArguments.AppendText(" --username ***");
                        auth.Username = null;
                    }
                    if (auth.Password != null) {
                        ArgumentBuffer.Append($" --password {auth.Password}");
                        txtCustomArguments.AppendText(" --password ***");
                        auth.Password = null;
                    }
                    if (auth.TwoFactor != null) {
                        ArgumentBuffer.Append($" --twofactor {auth.TwoFactor}");
                        txtCustomArguments.AppendText(" --twofactor ***");
                        auth.TwoFactor = null;
                    }
                    if (auth.VideoPassword != null) {
                        ArgumentBuffer.Append($" --video-password {auth.VideoPassword}");
                        txtCustomArguments.AppendText(" --video-password ***");
                        auth.VideoPassword = null;
                    }
                    if (auth.Netrc) {
                        ArgumentBuffer.Append(" --netrc");
                        txtCustomArguments.AppendText(" --netrc");
                    }
                    auth.Dispose();
                }
                else {
                    auth.Dispose();
                    return null;
                }
            }
            else txtCustomArguments.Text = ArgumentBuffer.ToString();

            string Data = ArgumentBuffer.ToString();
            ArgumentBuffer.Clear();
            return Data;
        }

        public void BeginDownload(bool Auth) {
            string args = GenerateArguments(Auth);
            if (args.IsNotNullEmptyWhitespace()) {
                if (Program.verif.YoutubeDlPath.IsNullEmptyWhitespace())
                    Program.verif.RefreshYoutubeDlLocation();

                if (Program.verif.YoutubeDlPath.IsNullEmptyWhitespace())
                    throw new NullReferenceException("Youtube-dl path is invalid and cannot be used.");

                btnDownloadWithAuthentication.Enabled = false;
                btnDownloadAbortClose.Text = Program.lang.GenericCancel;
                pbStatus.ShowInTaskbar = true;
                pbStatus.Text = "Retrieving metadata";
                // Download
                Output = new(() => {
                    try {
                        while (Status == DownloadStatus.Downloading) {
                            // Parse the output
                            // We want to invoke without waiting for the thread to finish.
                            if (DownloadProcess is not null) {
                                if (!DownloadProcess.HasExited) {
                                    if (OutputMsg.Count > 0) {
                                        string Line = Regex.Replace(OutputMsg[^1], "\\s+", " ");
                                        rtbVerbose.AppendText(Line);
                                        string[] LineParts = Line.Split(' ');

                                        if (Line.IndexOf("[download]") > -1) {
                                            switch (Line[12]) {
                                                case '0':
                                                case '1': case '2': case '3':
                                                case '4': case '5': case '6':
                                                case '7': case '8': case '9': {
                                                    pbStatus.Invoke(() => {
                                                        float Percentage = float.Parse(LineParts[1][..LineParts[1].IndexOf('%')]);
                                                        pbStatus.Text = $"{LineParts[5]} @ {Percentage}%";
                                                        pbStatus.Value = (int)Math.Round(Percentage, MidpointRounding.ToEven);
                                                    });
                                                    OutputMsg.Clear();
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
                                }
                            }
                            Thread.Sleep(500);
                        }

                        pbStatus.Invoke(() => {
                            pbStatus.ShowInTaskbar = false;
                            if (Status == DownloadStatus.Aborted) {
                                pbStatus.Text = "Aborted";
                                pbStatus.Value = pbStatus.Minimum;
                            }
                            else {
                                if (Status == DownloadStatus.Finished) {
                                    pbStatus.Text = "Completed";
                                    pbStatus.Value = pbStatus.Maximum;
                                }
                                else {
                                    pbStatus.Text = "Downlod process error";
                                    pbStatus.Value = pbStatus.Minimum;
                                }
                            }
                        });
                    }
                    catch (ThreadAbortException) { }
                    catch (Exception ex) {
                        Log.Write(ex.ToString());
                    }
                }) {
                    Name = $"Output {URL}",
                    IsBackground = true,
                    Priority = ThreadPriority.Normal
                };
                DownloadThread = new(() => {
                    DownloadProcess = new() {
                        StartInfo = new() {
                            Arguments = args,
                            CreateNoWindow = true,
                            FileName = Program.verif.YoutubeDlPath,
                            RedirectStandardError = true,
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            WindowStyle = ProcessWindowStyle.Hidden,
                        }
                    };
                    args = null;
                    Status = DownloadStatus.Downloading;
                    DownloadProcess.OutputDataReceived += (s, e) => {
                        if (e.Data is not null && (e.Data.IndexOf("[download]") > -1 || e.Data.IndexOf("[ffmpeg]") > -1)) {
                            Msg = e.Data;
                            OutputMsg.Add(e.Data);
                        }
                        else {
                            rtbVerbose.AppendText(e.Data + "\n");
                        }
                    };
                    DownloadProcess.ErrorDataReceived += (s, e) => {
                        if (e.Data is not null) {
                            rtbVerbose.AppendText(e.Data + "\n");
                        }
                    };
                    DownloadProcess.Start();
                    DownloadProcess.BeginOutputReadLine();
                    DownloadProcess.BeginErrorReadLine();
                    //Output.Start();

                    while (!DownloadProcess.HasExited) {
                        if (Msg is not null) {
                            string Line = Regex.Replace(Msg, "\\s+", " ");
                            rtbVerbose.AppendText(Line + "\n");
                            string[] LineParts = Line.Split(' ');

                            if (Line.IndexOf("[download]") > -1) {
                                switch (Line[12]) {
                                    case '0':
                                    case '1': case '2': case '3':
                                    case '4': case '5': case '6':
                                    case '7': case '8': case '9': {
                                        if (LineParts[1].Contains('%')) {
                                            pbStatus.Invoke(() => {
                                                float Percentage = float.Parse(LineParts[1][..LineParts[1].IndexOf('%')]);
                                                pbStatus.Text = $"{LineParts[5]} @ {Percentage}%";
                                                pbStatus.Value = (int)Math.Round(Percentage, MidpointRounding.ToEven);
                                            });
                                        }
                                        //OutputMsg.Clear();
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

                        if (Status == DownloadStatus.Aborted && !DownloadProcess.HasExited) {
                            Program.KillProcessTree((uint)DownloadProcess.Id);
                            break;
                        }

                        Thread.Sleep(500);
                    }

                    if (Status != DownloadStatus.Aborted)
                        Status = DownloadProcess.ExitCode == 0 ? DownloadStatus.Finished : DownloadStatus.YtdlError;

                    this.Invoke(() => {
                        pbStatus.ShowInTaskbar = false;
                        btnDownloadAbortClose.Enabled = true;
                        switch (Status) {
                            case DownloadStatus.Aborted: {
                                pbStatus.Text = "Aborted";
                                pbStatus.Value = pbStatus.Minimum;
                                btnDownloadWithAuthentication.Enabled = true;
                                btnDownloadAbortClose.Text = Program.lang.GenericRetry;
                            } break;

                            case DownloadStatus.Finished: {
                                pbStatus.Text = "Completed";
                                pbStatus.Value = pbStatus.Maximum;
                                btnDownloadAbortClose.Text = Program.lang.GenericExit;
                            } break;

                            default: {
                                pbStatus.Text = "Downlod error";
                                pbStatus.Value = pbStatus.Minimum;
                                btnDownloadWithAuthentication.Enabled = true;
                                btnDownloadAbortClose.Text = Program.lang.GenericRetry;
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
            lvVideoFormats.Visible = true;
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
            switch (Status) {
                case DownloadStatus.Finished: {
                    this.Dispose();
                } break;

                case DownloadStatus.Downloading: {
                    Status = DownloadStatus.Aborted;
                } break;

                default: {
                    BeginDownload(false);
                } break;
            }
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
    }
}
