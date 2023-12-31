#nullable enable
namespace youtube_dl_gui;
using System.Drawing;
using System.Windows.Forms;
using murrty.controls;

internal delegate void AfterExtendedMediaParse(ExtendedMediaDetails sender);

/// <summary>
/// Represents data about media when using an extended downloader.
/// </summary>
internal sealed class ExtendedMediaDetails(string URL) : MediaDetails(URL) {
    /// <summary>
    /// Gets the URL associated with this instance.
    /// </summary>
    public string URL => base.Source;

    /// <summary>
    /// Gets or sets whether the media is archived.
    /// </summary>
    public bool Archived { get; init; }
    /// <summary>
    /// Gets whether the media has the info retrieved.
    /// </summary>
    public bool InfoRetrieved { get; private set; }
    /// <summary>
    /// Gets whether the media is unknown formats only.
    /// </summary>
    public bool UnknownFormatsOnly { get; private set; }
    /// <summary>
    /// Gets or sets whether the item is a batch downloaded item.
    /// </summary>
    public bool BatchDownloadItem { get; set; }
    /// <summary>
    /// Gets or sets the batch download time associated with this media instance.
    /// </summary>
    public string? BatchDownloadTime { get; set; } = string.Empty;
    /// <summary>
    /// Gets the protected arguments that censors out the Username/Password of accounts.
    /// </summary>
    public string ArgumentsCensored { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the deserialized data associated with this instance.
    /// </summary>
    public YoutubeDlData? MediaData { get; set; }
    /// <summary>
    /// Gets or sets the queued list view item of this instance within the extended batch downloader.
    /// QueuedListViewItem.Tag is this <see cref="ExtendedMediaDetails"/> object associated with the item.
    /// </summary>
    public ListViewItem? QueueItem { get; set; }

    /// <summary>
    /// Gets or sets the name of the media associated with this instance.
    /// </summary>
    public string? MediaName { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the title progress name base of the media associated with this instance.
    /// </summary>
    public string? ProgressMediaName { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the description of the media associated with this instance.
    /// </summary>
    public string? MediaDescription { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the thumbnail image of the media associated with this instance.
    /// </summary>
    public Image? Thumbnail { get; set; }

    /// <summary>
    /// Gets the list of Video formats for the current media.
    /// </summary>
    public List<YoutubeDlSubdata.Format> VideoFormats { get; } = [];
    /// <summary>
    /// Gets the list of Video list view items for the current media.
    /// </summary>
    public List<ListViewItem> VideoItems { get; } = [];
    /// <summary>
    /// Gets or sets the last selected video format listviewitem of this instance.
    /// LastSelectedVideoFormat.Tag is the <see cref="YoutubeDlFormat"/> object that will be downloaded.
    /// </summary>
    public ListViewItem? SelectedVideoItem { get; set; }

    /// <summary>
    /// Gets the list of Audio formats for the current media.
    /// </summary>
    public List<YoutubeDlSubdata.Format> AudioFormats { get; } = [];
    /// <summary>
    /// Gets the list of Audio list view items for the current media.
    /// </summary>
    public List<ListViewItem> AudioItems { get; } = [];
    /// <summary>
    /// Gets or sets the selected audio format listviewitem of this instance.
    /// </summary>
    public ListViewItem? SelectedAudioItem { get; set; }

    /// <summary>
    /// Gets the list of Unkown formats for the current media.
    /// </summary>
    public List<YoutubeDlSubdata.Format> UnknownFormats { get; } = [];
    /// <summary>
    /// Gets the list of Unknown list view items for the current media.
    /// </summary>
    public List<ListViewItem> UnknownItems { get; } = [];
    /// <summary>
    /// Gets or sets the last selected unknown format listviewitem of this instance.
    /// </summary>
    public ListViewItem? SelectedUnknownItem { get; set; }

    /// <summary>
    /// Gets or sets the Authentication details used for this instance.
    /// </summary>
    public AuthenticationDetails? Authentication {get; set; }

    // Download settings
    /// <summary>
    /// Gets or sets the selected download type.
    /// </summary>
    public DownloadType SelectedType { get; set; } = DownloadType.None;
    /// <summary>
    /// Gets or sets the custom arguments for the current media which will be generated when it downloads.
    /// </summary>
    public string? CustomArguments { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the string-value representation of the file name schema.
    /// </summary>
    public string FileNameSchema { get; set; } = "%(title)s-%(id)s.%(ext)s";
    /// <summary>
    /// Gets or sets the index of the file name schema, if applicable.
    /// </summary>
    public int FileNameSchemaIndex { get; set; } = -1;
    /// <summary>
    /// Gets or sets the amount of fragment threads.
    /// </summary>
    public decimal FragmentThreads { get; set; } = 1;
    /// <summary>
    /// Gets or sets whether the audio with this media will use VBR.
    /// </summary>
    public bool AudioVBR { get; set; }
    /// <summary>
    /// Gets or sets the VBR index of the audio VBR setting this media will use.
    /// </summary>
    public int VBRIndex { get; set; }
    /// <summary>
    /// Gets or sets whether the audio for the video will be downloaded.
    /// </summary>
    public bool VideoDownloadAudio { get; set; } = true;
    /// <summary>
    /// Gets or sets whether the audio will be separated from the video.
    /// </summary>
    public bool VideoSeparateAudio { get; set; }
    /// <summary>
    /// Gets or sets whether the download will abort on an error.
    /// </summary>
    public bool AbortOnError { get; set; } = true;
    /// <summary>
    /// Gets or sets whether to skip unavailable fragments for a media file.
    /// </summary>
    public bool SkipUnavailableFragments { get; set; }
    /// <summary>
    /// Gets or sets the selected index of the video remux.
    /// </summary>
    public int VideoRemuxIndex { get; set; }
    /// <summary>
    /// Gets or sets the selected index of the video recoding setting.
    /// </summary>
    public int VideoEncoderIndex { get; set; }
    /// <summary>
    /// Gets or sets the selected index of the audio recoding setting.
    /// </summary>
    public int AudioEncoderIndex { get; set; }
    /// <summary>
    /// Gets or sets the start time of the selection picker.
    /// </summary>
    public Time StartTime { get; set; } = Time.Empty;
    /// <summary>
    /// Gets or sets the end time of the selection picker.
    /// </summary>
    public Time EndTime { get; set; } = Time.Empty;

    /// <summary>
    /// Downloads the media thumbnail, converting to jpg if required.
    /// If the thumbnail was already downloaded, it will return the previously acquired thumbnail.
    /// </summary>
    /// <returns>An <see cref="Image"/> of the thumbnail.</returns>
    public Image? DownloadThumbnail() => DownloadThumbnail(false);
    /// <summary>
    /// Downloads the media thumbnail, converting to jpg if required.
    /// If <paramref name="ForceRedownload"/> is <see langword="true"/>, the thumbnail will be downloaded regardless of if it already has been downloaded.
    /// </summary>
    /// <param name="ForceRedownload">Whether to redownload the thumbnail regardless of if it already exists in memory.</param>
    /// <returns>An <see cref="Image"/> of the thumbnail.</returns>
    public Image? DownloadThumbnail(bool ForceRedownload) {
        if (MediaData is not null && (Thumbnail is null || ForceRedownload)) {
            Thumbnail = MediaData.GetThumbnail();
        }

        return Thumbnail;
    }
    /// <summary>
    /// Changes the media type that this instance will download as.
    /// </summary>
    /// <param name="NewType">The new <see cref="DownloadType"/> that this instance will download as.</param>
    /// <exception cref="ArgumentException"></exception>
    public void ChangeMediaType(DownloadType NewType) {
        switch (NewType) {
            case DownloadType.Video: {
                if (VideoFormats.Count < 1) {
                    throw new ArgumentException("Cannot select video format when there are no video tracks to download.");
                }

                if (SelectedVideoItem is not null) {
                    if (SelectedVideoItem.Index != 0) {
                        VideoItems[0].ImageIndex = MediaStatusIcon.Best;
                    }
                    SelectedVideoItem.ImageIndex = MediaStatusIcon.Selected;
                }

                if (SelectedAudioItem is not null) {
                    if (VideoDownloadAudio) {
                        if (SelectedAudioItem.Index != 0) {
                            AudioItems[0].ImageIndex = MediaStatusIcon.Best;
                        }
                        SelectedAudioItem.ImageIndex = MediaStatusIcon.Selected;
                    }
                    else {
                        if (SelectedAudioItem.Index != 0) {
                            AudioItems[0].ImageIndex = MediaStatusIcon.BestDisabled;
                        }
                        SelectedAudioItem.ImageIndex = MediaStatusIcon.SelectedDisabled;
                    }
                }

                if (SelectedUnknownItem is not null) {
                    if (SelectedUnknownItem.Index != 1) {
                        UnknownItems[1].ImageIndex = MediaStatusIcon.Best;
                    }
                    SelectedUnknownItem.ImageIndex = MediaStatusIcon.Selected;
                }

                SelectedType = DownloadType.Video;
            } break;
            case DownloadType.Audio: {
                if (AudioFormats.Count < 1) {
                    throw new ArgumentException("Cannot select audio format when there are no audio tracks to download.");
                }

                if (SelectedVideoItem is not null) {
                    if (SelectedVideoItem.Index != 0) {
                        VideoItems[0].ImageIndex = MediaStatusIcon.BestDisabled;
                    }
                    SelectedVideoItem.ImageIndex = MediaStatusIcon.SelectedDisabled;
                }

                if (SelectedAudioItem is not null) {
                    if (SelectedAudioItem.Index != 0) {
                        AudioItems[0].ImageIndex = MediaStatusIcon.Best;
                    }
                    SelectedAudioItem.ImageIndex = MediaStatusIcon.Selected;
                }

                if (SelectedUnknownItem is not null) {
                    if (SelectedUnknownItem.Index != 1) {
                        UnknownItems[1].ImageIndex = MediaStatusIcon.Best;
                    }
                    SelectedUnknownItem.ImageIndex = MediaStatusIcon.Selected;
                }

                SelectedType = DownloadType.Audio;
            } break;
            case DownloadType.Unknown: {
                if (UnknownFormats.Count < 1) {
                    throw new ArgumentException("Cannot select unknown format when there are no unknown tracks to download.");
                }

                if (SelectedVideoItem is not null) {
                    if (SelectedVideoItem.Index != 0) {
                        VideoItems[0].ImageIndex = MediaStatusIcon.BestDisabled;
                    }
                    SelectedVideoItem.ImageIndex = MediaStatusIcon.SelectedDisabled;
                }

                if (SelectedAudioItem is not null) {
                    if (SelectedAudioItem.Index != 0) {
                        AudioItems[0].ImageIndex = MediaStatusIcon.BestDisabled;
                    }
                    SelectedAudioItem.ImageIndex = MediaStatusIcon.SelectedDisabled;
                }

                if (UnknownFormatsOnly) {
                    if (SelectedUnknownItem is not null) {
                        if (SelectedUnknownItem.Index != 0) {
                            UnknownItems[0].ImageIndex = MediaStatusIcon.Best;
                        }
                        SelectedUnknownItem.ImageIndex = MediaStatusIcon.Selected;
                    }
                }
                else {
                    if (SelectedUnknownItem is not null) {
                        if (SelectedUnknownItem.Index != 1) {
                            UnknownItems[1].ImageIndex = MediaStatusIcon.Best;
                        }
                        SelectedUnknownItem.ImageIndex = MediaStatusIcon.Selected;
                    }
                }

                SelectedType = DownloadType.Unknown;
            } break;
            case DownloadType.Custom: {
                if (SelectedVideoItem is not null) {
                    if (SelectedVideoItem.Index != 0) {
                        VideoItems[0].ImageIndex = MediaStatusIcon.BestDisabled;
                    }
                    SelectedVideoItem.ImageIndex = MediaStatusIcon.SelectedDisabled;
                }

                if (SelectedAudioItem is not null) {
                    if (SelectedAudioItem.Index != 0) {
                        AudioItems[0].ImageIndex = MediaStatusIcon.BestDisabled;
                    }
                    SelectedAudioItem.ImageIndex = MediaStatusIcon.SelectedDisabled;
                }

                if (SelectedUnknownItem is not null) {
                    if (SelectedUnknownItem.Index != 1) {
                        UnknownItems[1].ImageIndex = MediaStatusIcon.BestDisabled;
                    }
                    SelectedUnknownItem.ImageIndex = MediaStatusIcon.SelectedDisabled;
                }
                else if (UnknownItems.Count > 0) {
                    UnknownItems[1].ImageIndex = MediaStatusIcon.BestDisabled;
                }

                SelectedType = DownloadType.Custom;
            } break;
            default: throw new ArgumentException($"\"{NewType}\" cannot be set as a media type.");
        }
    }
    /// <summary>
    /// Gets authentication data from the user.
    /// </summary>
    /// <returns><see langword="true"/> if the authentication was confirmed; otherwise, <see langword="false"/>.</returns>
    public bool Authenticate() {
        if (Authentication is null) {
            using frmAuthentication Auth = new();
            if (Auth.ShowDialog() != DialogResult.OK) {
                return false;
            }
            Authentication = Auth.Authentication;
        }
        return true;
    }

    protected override void Parse() {
        if (URL.IsNullEmptyWhitespace()) {
            throw new DownloadException(URL, "The media you are trying to access was not entered in correctly.");
        }

        MediaData = YoutubeDlData.GenerateData(URL, Authentication, out _);
        if (MediaData is null || MediaData.AvailableFormats?.Length is not > 0) {
            throw new DownloadException(URL, "The media you are trying to access may not be accessible at this time, or it may have been removed.");
        }

        MediaData.AvailableFormats.ForReverse((Format) => {
            if (Format.ValidVideoFormat) {
                string SampleRate = "-";
                string AudioCodec = "-";
                string AudioBitrate = "-";
                string AudioChannels = "-";
                if ((Format.AudioSampleRate is not null && Format.AudioSampleRate > 0)
                || (Format.AudioBitrate is not null && Format.AudioBitrate > 0)
                || (Format.AudioCodec is not null && Format.AudioCodec != "none")
                || (Format.AudioChannels is not null && Format.AudioChannels > 0)) {
                    AudioCodec = Format.AudioCodec is not null && Format.AudioCodec != "none" ? Format.AudioCodec : "Unknown";
                    AudioBitrate = $"{(Format.AudioBitrate is not null && Format.AudioBitrate > 0 ? $"{Format.AudioBitrate}" : "?")}Kbps";
                    SampleRate = $"{(Format.AudioSampleRate is not null && Format.AudioSampleRate > 0 ? $"{Format.AudioSampleRate}" : "?")}Hz";
                    AudioChannels = Format.AudioChannels is not null ? Format.AudioChannels.ToString() : "?";
                }

                ListViewItem NewFormat = new(!Format.QualityName.IsNullEmptyWhitespace() ? Format.QualityName : "?");
                NewFormat.SubItems.Add(Format.VideoFps is not null && Format.VideoFps > 0 ? $"{Format.VideoFps}" : "?");
                NewFormat.SubItems.Add(Format.Extension ?? "Unknown");
                NewFormat.SubItems.Add(Format.Size ?? MediaData.GetApproximateVideoSize(Format));
                NewFormat.SubItems.Add(Format.VideoBitrate is not null && Format.VideoBitrate > 0 ? $"{Format.VideoBitrate}Kbps" : "?");
                NewFormat.SubItems.Add($"{Format.VideoWidth ?? -1}x{Format.VideoHeight ?? -1}");
                NewFormat.SubItems.Add(!Format.VideoCodec.IsNullEmptyWhitespace() && Format.VideoCodec != "none" ? Format.VideoCodec : "Unknown");
                NewFormat.SubItems.Add(AudioBitrate);
                NewFormat.SubItems.Add(SampleRate);
                NewFormat.SubItems.Add(AudioCodec);
                NewFormat.SubItems.Add(AudioChannels);
                NewFormat.SubItems.Add(Format.Identifier);
                NewFormat.Tag = Format;
                Format.ListViewItem = NewFormat;

                if (VideoItems.Count == 0) {
                    Format.Best = true;
                    SelectedVideoItem = NewFormat;
                    SelectedVideoItem.ImageIndex = MediaStatusIcon.Best;
                }

                VideoItems.Add(NewFormat);
                VideoFormats.Add(Format);
            }
            else if (Format.ValidAudioFormat) {
                ListViewItem NewFormat = new($"{(Format.AudioBitrate is not null && Format.AudioBitrate > 0 ? $"{Format.AudioBitrate}" : "?")}Kbps");
                NewFormat.SubItems.Add(Format.Extension ?? "Unknown");
                NewFormat.SubItems.Add(Format.Size ?? MediaData.GetApproximateAudioSize(Format));
                NewFormat.SubItems.Add($"{(Format.AudioSampleRate is not null && Format.AudioSampleRate > 0 ? $"{Format.AudioSampleRate}" : "?")}Hz");
                NewFormat.SubItems.Add(Format.AudioCodec ?? "Unknown");
                NewFormat.SubItems.Add(Format.AudioChannels is not null ? Format.AudioChannels.ToString() : "?");
                NewFormat.SubItems.Add(Format.Identifier);
                NewFormat.Tag = Format;
                Format.ListViewItem = NewFormat;

                if (AudioItems.Count == 0) {
                    Format.Best = true;
                    SelectedAudioItem = NewFormat;
                    SelectedAudioItem.ImageIndex = MediaStatusIcon.Best;
                }

                AudioItems.Add(NewFormat);
                AudioFormats.Add(Format);
            }
            else {
                string SampleRate = "-";
                string AudioCodec = "-";
                string AudioBitrate = "-";
                string AudioChannels = "-";
                if ((Format.AudioSampleRate is not null && Format.AudioSampleRate > 0)
                || (Format.AudioBitrate is not null && Format.AudioBitrate > 0)
                || (Format.AudioCodec is not null && Format.AudioCodec != "none")) {
                    AudioCodec = Format.AudioCodec is not null && Format.AudioCodec != "none" ? Format.AudioCodec : "Unknown";
                    AudioBitrate = $"{(Format.AudioBitrate is not null && Format.AudioBitrate > 0 ? $"{Format.AudioBitrate}" : "?")}Kbps";
                    SampleRate = $"{(Format.AudioSampleRate is not null && Format.AudioSampleRate > 0 ? $"{Format.AudioSampleRate}" : "?")}Hz";
                    AudioChannels = Format.AudioChannels is not null ? Format.AudioChannels.ToString() : "?";
                }

                ListViewItem NewFormat = new(!Format.QualityName.IsNullEmptyWhitespace() ? Format.QualityName : "?");
                NewFormat.SubItems.Add(Format.VideoFps is not null && Format.VideoFps > 0 ? $"{Format.VideoFps}" : "?");
                NewFormat.SubItems.Add(Format.Extension ?? "Unknown");
                NewFormat.SubItems.Add(Format.Size ?? "null");
                NewFormat.SubItems.Add(Format.VideoBitrate is not null && Format.VideoBitrate > 0 ? $"{Format.VideoBitrate}Kbps" : "?");
                NewFormat.SubItems.Add($"{Format.VideoWidth ?? -1}x{Format.VideoHeight ?? -1}");
                NewFormat.SubItems.Add(!Format.VideoCodec.IsNullEmptyWhitespace() && Format.VideoCodec != "none" ? Format.VideoCodec : "Unknown");
                NewFormat.SubItems.Add(AudioBitrate);
                NewFormat.SubItems.Add(SampleRate);
                NewFormat.SubItems.Add(AudioCodec);
                NewFormat.SubItems.Add(AudioChannels);
                NewFormat.SubItems.Add(Format.Identifier);
                NewFormat.Tag = Format;
                Format.ListViewItem = NewFormat;

                if (UnknownItems.Count == 0) {
                    Format.Best = true;
                    SelectedUnknownItem = NewFormat;
                    SelectedUnknownItem.ImageIndex = MediaStatusIcon.Best;
                }

                UnknownItems.Add(NewFormat);
                UnknownFormats.Add(Format);
            }
        });

        UnknownFormatsOnly = VideoItems.Count == 0 && AudioItems.Count == 0;
        if (!UnknownFormatsOnly && UnknownItems.Count > 0) {
            ListViewItem IgnoreUnknownFormats = new(Language.GenericDoNotDownload);
            SelectedUnknownItem = IgnoreUnknownFormats;
            UnknownItems.Insert(0, IgnoreUnknownFormats);
        }

        MediaName = MediaData.Title ?? "[media name unavailable]";
        MediaDescription = MediaData.Description ?? string.Empty;
        ProgressMediaName =
            $"{(Initialization.ScreenshotMode ? "The videos' title will appear here" : MediaName)} - {Language.ApplicationName}";

        SelectedType = VideoFormats.Count > 0 ? DownloadType.Video :
            AudioFormats.Count > 0 ? DownloadType.Audio :
            UnknownFormats.Count > 0 ? DownloadType.Unknown :
            DownloadType.Custom;

        InfoRetrieved = true;
    }
    public override bool GenerateArguments() {
        ArgumentList ArgumentBuffer = new($"\"{URL}\"");

        #region Outuput path
        StringBuilder OutputPath = new("-o \"");
        OutputPath.Append(Downloads.downloadPath.StartsWith("./") || Downloads.downloadPath.StartsWith("\\.") ?
            $"{Program.ProgramPath}\\{Downloads.downloadPath[2..]}" : Downloads.downloadPath);

        if (BatchDownloadItem && Downloads.SeparateBatchDownloads) {
            OutputPath.Append("\\# Batch Downloads #");

            if (Downloads.AddDateToBatchDownloadFolders) {
                OutputPath.Append('\\').Append(BatchDownloadTime);
            }
        }

        if (Downloads.separateIntoWebsiteURL) {
            OutputPath.Append(URL.StartsWith("ytarchive:", StringComparison.InvariantCultureIgnoreCase) ? "\\archived.youtube.com" : $"\\{DownloadHelper.GetUrlBase(URL)}");
        }

        string Schema = FileNameSchema.IsNullEmptyWhitespace() ? "%(title)s-%(id)s.%(ext)s" : FileNameSchema;

        if (!Schema.EndsWith(".%(ext)s", StringComparison.InvariantCultureIgnoreCase)) {
            Schema += ".%(ext)s";
        }

        switch (SelectedType) {
            case DownloadType.Video: {
                if (Downloads.separateDownloads) {
                    OutputPath.Append("\\Video");
                }

                if (VideoSeparateAudio) {
                    Schema = Schema[..^8] + "_%(format_id)s.%(ext)s";
                }
            } break;
            case DownloadType.Audio: {
                if (Downloads.separateDownloads) {
                    OutputPath.Append("\\Audio");
                }
            } break;
            case DownloadType.Custom: {
                if (Downloads.separateDownloads) {
                    OutputPath.Append("\\Custom");
                }
            } break;
            case DownloadType.Unknown: {
                if (Downloads.separateDownloads) {
                    OutputPath.Append("\\Unknown");
                }
            } break;
            default: throw InvalidType;
        }

        OutputPath.Append('\\').Append(Schema).Append('\"');
        ArgumentBuffer.Add(OutputPath.ToString());
        OutputPath.Clear();
        #endregion

        #region Formats
        YoutubeDlSubdata.Format? VideoFormat = null;
        YoutubeDlSubdata.Format? AudioFormat = null;
        YoutubeDlSubdata.Format? UnknownFormat;

        switch (SelectedType) {
            case DownloadType.Video when SelectedVideoItem?.Tag is YoutubeDlSubdata.Format vf: {
                VideoFormat = vf;
                string Argument = "-f " + VideoFormat.Identifier;

                if (VideoDownloadAudio && SelectedAudioItem?.Tag is YoutubeDlSubdata.Format af) {
                    AudioFormat = af;
                    Argument += VideoSeparateAudio ? "/best," : "+" + AudioFormat.Identifier + "/best";
                }
                else {
                    Argument += "/best";
                }

                if (SelectedUnknownItem?.Tag is YoutubeDlSubdata.Format uf) {
                    UnknownFormat = uf;
                    Argument += ',' + UnknownFormat.Identifier;
                }

                ArgumentBuffer.Add(Argument);

                if (VideoRemuxIndex > 0) {
                    ArgumentBuffer.Add("--remux-video " + Formats.ExtendedVideoFormats[VideoRemuxIndex - 1]);
                }
                else if (VideoEncoderIndex > 0) {
                    ArgumentBuffer.Add("--recode-video " + Formats.ExtendedVideoFormats[VideoRemuxIndex - 1]);
                }
            } break;
            case DownloadType.Audio when SelectedAudioItem?.Tag is YoutubeDlSubdata.Format af: {
                AudioFormat = af;
                string Argument = "-f " + AudioFormat.Identifier + "/best";

                if (SelectedUnknownItem?.Tag is YoutubeDlSubdata.Format uf) {
                    UnknownFormat = uf;
                    Argument += ',' + UnknownFormat.Identifier;
                }

                ArgumentBuffer.Add(Argument);

                if (AudioEncoderIndex > 0) {
                    ArgumentBuffer.Add("--recode-video " + Formats.ExtendedAudioFormats[AudioEncoderIndex - 1]);
                }
            } break;
            case DownloadType.Unknown when SelectedUnknownItem?.Tag is YoutubeDlSubdata.Format uf: {
                UnknownFormat = uf;
                ArgumentBuffer.Add("-f " + UnknownFormat.Identifier + "/best");
            } break;
            case DownloadType.Custom: {
                if (!CustomArguments.IsNullEmptyWhitespace()) {
                    ArgumentBuffer.Add(CustomArguments.Replace("\r\n", "\n").Split('\n').Join(" ")); // Join with '\n' instead of space?
                }
            } break;
            default: throw InvalidType;
        }
        #endregion

        #region Other settings (if not Custom)
        if (SelectedType != DownloadType.Custom) {
            if (Downloads.PreferFFmpeg || (DownloadHelper.IsReddit(URL) && Downloads.fixReddit)) {
                if (!Verification.FfmpegAvailable) {
                    Verification.RefreshFFmpegLocation();
                }

                if (Verification.FfmpegAvailable) {
                    ArgumentBuffer.Add("--ffmpeg-location \"" + Verification.FFmpegPath + "\" --hls-prefer-ffmpeg");
                }
            }

            if (Downloads.SaveSubtitles) {
                ArgumentBuffer.Add("--all-subs");
                if (!Downloads.SubtitleFormat.IsNullEmptyWhitespace()) {
                    ArgumentBuffer.Add("--sub-format " + Downloads.SubtitleFormat);
                }

                if (Downloads.EmbedSubtitles && SelectedType == DownloadType.Video) {
                    ArgumentBuffer.Add("--embed-subs");
                }
            }

            if (Downloads.SaveVideoInfo) {
                ArgumentBuffer.Add("--write-info-json");
            }

            if (Downloads.SaveDescription) {
                ArgumentBuffer.Add("--write-description");
            }

            if (Downloads.SaveAnnotations) {
                ArgumentBuffer.Add("--write-annotations");
            }

            if (Downloads.SaveThumbnail) {
                ArgumentBuffer.Add("--write-thumbnail");
                switch (SelectedType) {
                    case DownloadType.Video when VideoFormat?.VideoThumbnailEmbedding == true || VideoEncoderIndex == 4:
                    case DownloadType.Audio when AudioFormat?.AudioThumbnailEmbedding == true || AudioEncoderIndex == 1 || AudioEncoderIndex == 2: {
                        ArgumentBuffer.Add("--embed-thumbnail");
                    } break;
                }
            }

            if (Downloads.WriteMetadata) {
                ArgumentBuffer.Add("--add-metadata");
            }

            if (Downloads.KeepOriginalFiles) {
                ArgumentBuffer.Add("-k");
            }

            if (Downloads.LimitDownloads && Downloads.DownloadLimit > 0) {
                ArgumentBuffer.Add("--limit-rate " + Downloads.DownloadLimit + Downloads.DownloadLimitType switch {
                    1 => "M",
                    2 => "G",
                    _ => "K"
                });
            }

            if (Downloads.ForceIPv4) {
                ArgumentBuffer.Add("--force-ipv4");
            }
            else if (Downloads.ForceIPv6) {
                ArgumentBuffer.Add("--force-ipv6");
            }

            if (Downloads.UseProxy
            && Downloads.ProxyType > -1
            && !Downloads.ProxyIP.IsNullEmptyWhitespace()
            && !Downloads.ProxyPort.IsNullEmptyWhitespace()) {
                ArgumentBuffer.Add(
                    "--proxy " +
                    DownloadHelper.ProxyProtocols[Downloads.ProxyType] +
                    Downloads.ProxyIP +
                    ':' +
                    Downloads.ProxyPort +
                    '/');
            }

            if (Downloads.RetryAttempts != 10 && Downloads.RetryAttempts > 0) {
                ArgumentBuffer.Add("--retries " + Downloads.RetryAttempts);
            }

            if (!SkipUnavailableFragments) {
                ArgumentBuffer.Add("--abort-on-unavailable-fragment");
            }

            if (!AbortOnError) {
                ArgumentBuffer.Add("--no-abort-on-error");
            }

            if (FragmentThreads > 1) {
                ArgumentBuffer.Add("--concurrent-fragments " + FragmentThreads);
            }

            if (StartTime.HasValue && EndTime.HasValue) {
                ArgumentBuffer.Add("--download-sections \"*" + StartTime.ToString() + '-' + EndTime.ToString() + '\"');
            }
            else if (StartTime.HasValue) {
                ArgumentBuffer.Add("--download-sections \"*" + StartTime.ToString() + "-inf\"");
            }
            else if (EndTime.HasValue) {
                ArgumentBuffer.Add("--download-sections \"*00:00:00-" + EndTime.ToString() + '\"');
            }

            if (!BatchDownloadItem) {
                ArgumentBuffer.Add("--no-playlist");
            }

            if (!CustomArguments.IsNullEmptyWhitespace()) {
                ArgumentBuffer.Add(CustomArguments.Replace("\r\n", "\n").Split('\n').Join(" "));
            }
        }
        #endregion

        #region Authentication
        StringBuilder ProtectedArguments = new(ArgumentBuffer.ToString());
        if (Authentication is not null) {
            if (!Authentication.Username.IsNullEmptyWhitespace()) {
                ArgumentBuffer.Add("--username " + Authentication.Username);
                ProtectedArguments.Append("--username ***");
            }
            if (Authentication.Password?.Length > 0) {
                ArgumentBuffer.Add("--password " + Authentication.GetPassword());
                ProtectedArguments.Append("--password ***");
            }
            if (!Authentication.TwoFactor.IsNullEmptyWhitespace()) {
                ArgumentBuffer.Add("--twofactor " + Authentication.TwoFactor);
                ProtectedArguments.Append("--twofactor ***");
            }
            if (Authentication.MediaPassword?.Length > 0) {
                ArgumentBuffer.Add("--video-password " + Authentication.GetMediaPassword());
                ProtectedArguments.Append("--video-password ***");
            }
            if (Authentication.NetRC) {
                ArgumentBuffer.Add("--netrc");
                ProtectedArguments.Append("--netrc");
            }
            if (!Authentication.CookiesFile.IsNullEmptyWhitespace()) {
                ArgumentBuffer.Add("--cookies " + Authentication.CookiesFile);
                ProtectedArguments.Append("--cookies ***");
            }
            if (!Authentication.CookiesFromBrowser.IsNullEmptyWhitespace()) {
                ArgumentBuffer.Add("--cookies-from-browser " + Authentication.CookiesFromBrowser);
                ProtectedArguments.Append(" --cookies-from-browser ***");
            }
        }
        #endregion

        base.Arguments = ArgumentBuffer.ToString();
        this.ArgumentsCensored = ProtectedArguments.ToString();
        return true;
    }

    private DownloadException InvalidType => new(URL, $"The SelectedType {SelectedType} is not valid.");

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    /// <returns>A 32-bit signed integer hash code.</returns>
    public override int GetHashCode() => URL.GetHashCode();

    ~ExtendedMediaDetails() {
        ClearData();
    }

    private void ClearData() {
        if (Authentication is null) {
            return;
        }

        Authentication.Username = null;

        if (Authentication.Password is not null) {
            Array.Clear(Authentication.Password, 0, Authentication.Password.Length);
        }

        Authentication.Password = null;

        Authentication.TwoFactor = null;

        if (Authentication.MediaPassword is not null) {
            Array.Clear(Authentication.MediaPassword, 0, Authentication.MediaPassword.Length);
        }

        Authentication.MediaPassword = null;

        Authentication.CookiesFile = null;

        Authentication.CookiesFromBrowser = null;
    }

    protected override void Dispose(bool disposing) {
        if (Disposed) {
            return;
        }

        base.Dispose(disposing);

        if (disposing) {
            ClearData();
            Authentication = null;

            if (SelectedVideoItem is not null) {
                SelectedVideoItem.Tag = null;
                SelectedVideoItem = null;
            }
            VideoItems.Clear();

            if (SelectedAudioItem is not null) {
                SelectedAudioItem.Tag = null;
                SelectedAudioItem = null;
            }
            AudioItems.Clear();

            if (SelectedUnknownItem is not null) {
                SelectedUnknownItem.Tag = null;
                SelectedUnknownItem = null;
            }
            UnknownItems.Clear();

            CustomArguments = null;
            MediaData = null;
            ArgumentsCensored = string.Empty;
            Thumbnail = null;
        }

        GC.SuppressFinalize(this);
    }
}