namespace youtube_dl_gui;

using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Delegate for when the media is parsed.
/// </summary>
/// <param name="sender">The sending <see cref="ExtendedMediaDetails"/> object.</param>
internal delegate void AfterMediaParse(ExtendedMediaDetails sender);

/// <summary>
/// Represents data about media when using an extended downloader.
/// </summary>
internal sealed class ExtendedMediaDetails : IDisposable {
    /// <summary>
    /// Gets the URL associated with this instance.
    /// </summary>
    public required string URL {
        get => fURL;
        init {
            if (value.IsNullEmptyWhitespace())
                throw new ArgumentException($"URL is null/empty/whitespace.");
            fURL = value.Trim('\\', '"', '\n', '\r', '\t', '\0', '\b', '\'');
        }
    }
    private readonly string fURL;

    /// <summary>
    /// Gets whether the media has the info retrieved.
    /// </summary>
    public bool InfoRetrieved { get; private set; } = false;
    /// <summary>
    /// Gets the arguments associated with this media instance. It will be generated on the fly.
    /// </summary>
    public string Arguments {
        get {
            StringBuilder ArgumentBuffer = new($"\"{URL}\" -o \"");

            #region Outuput path
            ArgumentBuffer.Append(Config.Settings.Downloads.downloadPath.StartsWith("./") || Config.Settings.Downloads.downloadPath.StartsWith("\\.") ?
                $"{Program.ProgramPath}\\{Config.Settings.Downloads.downloadPath[2..]}" : Config.Settings.Downloads.downloadPath);

            if (Config.Settings.Downloads.separateIntoWebsiteURL)
                ArgumentBuffer.Append(URL.ToLowerInvariant().StartsWith("ytarchive:") ? "\\archived.youtube.com" : $"\\{DownloadHelper.GetUrlBase(URL)}");

            string Schema = FileNameSchema.IsNullEmptyWhitespace() ? "%(title)s-%(id)s.%(ext)s" : FileNameSchema;

            if (!Schema.ToLowerInvariant().EndsWith(".%(ext)s"))
                Schema += ".%(ext)s";

            switch (SelectedType) {
                case DownloadType.Video: {
                    if (Config.Settings.Downloads.separateDownloads)
                        ArgumentBuffer.Append("\\Video");

                    if (VideoSeparateAudio)
                        Schema = Schema[..8] + "_%(format_id)s.%(ext)s";
                }
                break;
                case DownloadType.Audio: {
                    if (Config.Settings.Downloads.separateDownloads)
                        ArgumentBuffer.Append("\\Audio");
                }
                break;
                case DownloadType.Custom: {
                    if (Config.Settings.Downloads.separateDownloads)
                        ArgumentBuffer.Append("\\Custom");
                }
                break;
                case DownloadType.Unknown: {
                    if (Config.Settings.Downloads.separateDownloads)
                        ArgumentBuffer.Append("\\Unknown");
                }
                break;
                default: throw InvalidType;
            }

            ArgumentBuffer.Append($"\\{Schema}");
            #endregion

            #region Formats
            YoutubeDlFormat VideoFormat = null;
            YoutubeDlFormat AudioFormat = null;
            YoutubeDlFormat UnknownFormat = null;

            switch (SelectedType) {
                case DownloadType.Custom: {
                    ArgumentBuffer.Append(CustomArguments.IsNullEmptyWhitespace() ? $" {CustomArguments.Replace("\r\n", "\n").Split('\n').Join("\n")}" : string.Empty);
                }
                break;
                case DownloadType.Video: {
                    VideoFormat = SelectedVideoItem.Tag as YoutubeDlFormat;
                    ArgumentBuffer.Append($" -f {VideoFormat.Identifier}");
                    if (VideoDownloadAudio && SelectedAudioItem is not null) {
                        AudioFormat = SelectedAudioItem.Tag as YoutubeDlFormat;
                        ArgumentBuffer.Append($"{(VideoSeparateAudio ? "/best," : "+") + AudioFormat.Identifier}/best");
                    }
                    else ArgumentBuffer.Append("/best");

                    if (SelectedUnknownItem is not null) {
                        UnknownFormat = SelectedUnknownItem.Tag as YoutubeDlFormat;
                        ArgumentBuffer.Append($",{UnknownFormat.Identifier}");
                    }

                    if (VideoRemuxIndex > 0)
                        ArgumentBuffer.Append($" --remux-video {Formats.ExtendedVideoFormats[VideoRemuxIndex - 1]}");
                    else if (VideoEncoderIndex > 0)
                        ArgumentBuffer.Append($" --recode-video {Formats.ExtendedVideoFormats[VideoRemuxIndex - 1]}");
                }
                break;
                case DownloadType.Audio: {
                    AudioFormat = SelectedAudioItem.Tag as YoutubeDlFormat;

                    ArgumentBuffer.Append($" -f {AudioFormat.Identifier}/best");

                    if (SelectedUnknownItem is not null) {
                        UnknownFormat = SelectedUnknownItem.Tag as YoutubeDlFormat;
                        ArgumentBuffer.Append($",{UnknownFormat.Identifier}");
                    }

                    if (AudioEncoderIndex > 0)
                        ArgumentBuffer.Append($" --recode-video {Formats.ExtendedAudioFormats[AudioEncoderIndex - 1]}");
                }
                break;
                case DownloadType.Unknown: {
                    UnknownFormat = SelectedUnknownItem.Tag as YoutubeDlFormat;
                    ArgumentBuffer.Append($" -f {UnknownFormat.Identifier}/best");
                }
                break;
                default: throw InvalidType;
            }
            #endregion

            #region Other settings (if not Custom)
            if (SelectedType != DownloadType.Custom) {
                if (Config.Settings.Downloads.PreferFFmpeg || (DownloadHelper.IsReddit(URL) && Config.Settings.Downloads.fixReddit)) {
                    if (Verification.FFmpegPath.IsNullEmptyWhitespace())
                        Verification.RefreshFFmpegLocation();

                    if (!Verification.FFmpegPath.IsNullEmptyWhitespace())
                        ArgumentBuffer.Append($" --ffmpeg-location \"{Verification.FFmpegPath}\" --hls-prefer-ffmpeg");
                }

                if (Config.Settings.Downloads.SaveSubtitles) {
                    ArgumentBuffer.Append(" --all-subs");
                    if (Config.Settings.Downloads.SubtitleFormat.IsNotNullEmptyWhitespace())
                        ArgumentBuffer.Append($" --sub-format {Config.Settings.Downloads.SubtitleFormat}");

                    if (Config.Settings.Downloads.EmbedSubtitles && SelectedType == DownloadType.Video)
                        ArgumentBuffer.Append(" --embed-subs");
                }

                if (Config.Settings.Downloads.SaveVideoInfo)
                    ArgumentBuffer.Append(" --write-info-json");

                if (Config.Settings.Downloads.SaveDescription)
                    ArgumentBuffer.Append(" --write-description");

                if (Config.Settings.Downloads.SaveAnnotations)
                    ArgumentBuffer.Append(" --write-annotations");

                if (Config.Settings.Downloads.SaveThumbnail) {
                    ArgumentBuffer.Append(" --write-thumbnail");
                    switch (SelectedType) {
                        case DownloadType.Video when VideoFormat.VideoThumbnailEmbedding || VideoEncoderIndex == 4:
                        case DownloadType.Audio when AudioFormat.AudioThumbnailEmbedding || AudioEncoderIndex == 1 || AudioEncoderIndex == 2: {
                            ArgumentBuffer.Append(" --embed-thumbnail");
                        }
                        break;
                    }
                }

                if (Config.Settings.Downloads.WriteMetadata)
                    ArgumentBuffer.Append(" --add-metadata");

                if (Config.Settings.Downloads.KeepOriginalFiles)
                    ArgumentBuffer.Append(" -k");

                if (Config.Settings.Downloads.LimitDownloads && Config.Settings.Downloads.DownloadLimit > 0)
                    ArgumentBuffer.Append($" --limit-rate {Config.Settings.Downloads.DownloadLimit}{Config.Settings.Downloads.DownloadLimitType switch {
                        1 => "M",
                        2 => "G",
                        _ => "K"
                    }}");

                if (Config.Settings.Downloads.ForceIPv4)
                    ArgumentBuffer.Append(" --force-ipv4");
                else if (Config.Settings.Downloads.ForceIPv6)
                    ArgumentBuffer.Append(" --force-ipv6");

                if (Config.Settings.Downloads.UseProxy
                && Config.Settings.Downloads.ProxyType > -1
                && !Config.Settings.Downloads.ProxyIP.IsNullEmptyWhitespace()
                && !Config.Settings.Downloads.ProxyPort.IsNullEmptyWhitespace()) {
                    ArgumentBuffer.Append($" --proxy {DownloadHelper.ProxyProtocols[Config.Settings.Downloads.ProxyType]}{Config.Settings.Downloads.ProxyIP}:{Config.Settings.Downloads.ProxyPort}/");
                }

                if (Config.Settings.Downloads.RetryAttempts != 10 && Config.Settings.Downloads.RetryAttempts > 0)
                    ArgumentBuffer.Append($" --retries {Config.Settings.Downloads.RetryAttempts}");

                if (!CustomArguments.IsNullEmptyWhitespace())
                    ArgumentBuffer.Append($" {CustomArguments.Replace("\r\n", "\n").Split('\n').Join(" ")}");
            }
            #endregion

            #region Authentication
            StringBuilder ProtectedArguments = new(ArgumentBuffer.ToString());
            if (!Authentication.Username.IsNullEmptyWhitespace()) {
                ArgumentBuffer.Append($" --username {Authentication.Username}");
                ProtectedArguments.Append(" --username ***");
            }
            if (Authentication.Password?.Length > 0) {
                ArgumentBuffer.Append($" --password {Authentication.GetPassword()}");
                ProtectedArguments.Append(" --password ***");
            }
            if (!Authentication.TwoFactor.IsNullEmptyWhitespace()) {
                ArgumentBuffer.Append($" --twofactor {Authentication.TwoFactor}");
                ProtectedArguments.Append(" --twofactor ***");
            }
            if (Authentication.MediaPassword?.Length > 0) {
                ArgumentBuffer.Append($" --video-password {Authentication.GetMediaPassword()}");
                ProtectedArguments.Append(" --video-password ***");
            }
            if (Authentication.NetRC) {
                ArgumentBuffer.Append(" --netrc");
                ProtectedArguments.Append(" --netrc");
            }
            if (!Authentication.CookiesFile.IsNullEmptyWhitespace()) {
                ArgumentBuffer.Append($" --cookies {Authentication.CookiesFile}");
                ProtectedArguments.Append(" --cookies ***");
            }
            if (!Authentication.CookiesFromBrowser.IsNullEmptyWhitespace()) {
                ArgumentBuffer.Append($" --cookies-from-browser {Authentication.CookiesFromBrowser}");
                ProtectedArguments.Append(" --cookies-from-browser ***");
            }
            #endregion

            return ArgumentBuffer.ToString();
        }
    }
    /// <summary>
    /// Gets the protected arguments that censors out the Username/Password of accounts.
    /// </summary>
    public string ProtectedArguments { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the deserialized data associated with this instance.
    /// </summary>
    public YoutubeDlData MediaData { get; set; } = null;
    /// <summary>
    /// Gets or sets the queued list view item of this instance within the extended batch downloader.
    /// QueuedListViewItem.Tag is this <see cref="ExtendedMediaDetails"/> object associated with the item.
    /// </summary>
    public ListViewItem QueueItem { get; set; } = null;

    /// <summary>
    /// Gets or sets the name of the media associated with this instance.
    /// </summary>
    public string MediaName { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the title progress name base of the media associated with this instance.
    /// </summary>
    public string ProgressMediaName { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the thumbnail image of the media associated with this instance.
    /// </summary>
    public Image Thumbnail { get; set; } = null;

    /// <summary>
    /// Gets or sets the selected video format.
    /// </summary>
    public YoutubeDlFormat SelectedVideoFormat { get; set; } = null;
    /// <summary>
    /// Gets or sets the last selected video format listviewitem of this instance.
    /// LastSelectedVideoFormat.Tag is the <see cref="YoutubeDlFormat"/> object that will be downloaded.
    /// </summary>
    public ListViewItem SelectedVideoItem { get; set; } = null;
    /// <summary>
    /// Gets the list of Video formats for the current media.
    /// </summary>
    public List<YoutubeDlFormat> VideoFormats { get; private set; } = new();
    /// <summary>
    /// Gets the list of Video list view items for the current media.
    /// </summary>
    public List<ListViewItem> VideoItems { get; private set; } = new();

    /// <summary>
    /// Gets or sets the selected audio format.
    /// </summary>
    public YoutubeDlFormat SelectedAudioFormat { get; set; } = null;
    /// <summary>
    /// Gets or sets the selected audio format listviewitem of this instance.
    /// </summary>
    public ListViewItem SelectedAudioItem { get; set; } = null;
    /// <summary>
    /// Gets the list of Audio formats for the current media.
    /// </summary>
    public List<YoutubeDlFormat> AudioFormats { get; private set; } = new();
    /// <summary>
    /// Gets the list of Audio list view items for the current media.
    /// </summary>
    public List<ListViewItem> AudioItems { get; private set; } = new();

    /// <summary>
    /// Gets or sets the selected unknown format.
    /// </summary>
    public YoutubeDlFormat SelectedUnknownFormat { get; set; } = null;
    /// <summary>
    /// Gets or sets the last selected unknown format listviewitem of this instance.
    /// </summary>
    public ListViewItem SelectedUnknownItem { get; set; } = null;
    /// <summary>
    /// Gets the list of Unkown formats for the current media.
    /// </summary>
    public List<YoutubeDlFormat> UnknownFormats { get; private set; } = new();
    /// <summary>
    /// Gets the list of Unknown list view items for the current media.
    /// </summary>
    public List<ListViewItem> UnknownItems { get; private set; } = new();

    /// <summary>
    /// Gets the status of this instance.
    /// </summary>
    public DownloadStatus Status { get; set; } = DownloadStatus.None;

    /// <summary>
    /// Gets or sets the Authentication details used for this instance.
    /// </summary>
    public AuthenticationDetails Authentication {get; set; } = null;

    // Download settings
    /// <summary>
    /// Gets or sets the selected download type.
    /// </summary>
    public DownloadType SelectedType { get; set; } = DownloadType.None;
    /// <summary>
    /// Gets or sets the custom arguments for the current media which will be generated when it downloads.
    /// </summary>
    public string CustomArguments { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the string-value representation of the file name schema.
    /// </summary>
    public string FileNameSchema { get; set; } = "%(title)s-%(id)s.%(ext)s";
    /// <summary>
    /// Gets or sets the index of the file name schema, if applicable.
    /// </summary>
    public int FileNameSchemaIndex { get; set; } = 0;
    /// <summary>
    /// Gets or sets whether the audio with this media will use VBR.
    /// </summary>
    public bool AudioVBR { get; set; } = false;
    /// <summary>
    /// Gets or sets the VBR index of the audio VBR setting this media will use.
    /// </summary>
    public int VBRIndex { get; set; } = 0;
    /// <summary>
    /// Gets or sets whether the audio for the video will be downloaded.
    /// </summary>
    public bool VideoDownloadAudio { get; set; } = true;
    /// <summary>
    /// Gets or sets whether the audio will be separated from the video.
    /// </summary>
    public bool VideoSeparateAudio { get; set; } = false;
    /// <summary>
    /// Gets or sets the selected index of the video remux.
    /// </summary>
    public int VideoRemuxIndex { get; set; } = 0;
    /// <summary>
    /// Gets or sets the selected index of the video recoding setting.
    /// </summary>
    public int VideoEncoderIndex { get; set; } = 0;
    /// <summary>
    /// Gets or sets the selected index of the audio recoding setting.
    /// </summary>
    public int AudioEncoderIndex { get; set; } = 0;

    /// <summary>
    /// Downloads and parses the information for this media.
    /// </summary>
    /// <param name="ParsingFinished">Delegate for when the media is finished being parsed.</param>
    /// <param name="NewVideoFormat">Delegate for when a new video format is detected.</param>
    /// <param name="NewAudioFormat">Delegate for when a new audio format is detected.</param>
    /// <param name="NewUnknownFormat">Delegate for when a new unknown format is detected.</param>
    public void GetMediaInfo(AfterMediaParse ParsingFinished) {
        if (!InfoRetrieved) {
            if (URL.IsNullEmptyWhitespace())
                throw new DownloadException(URL, "The media you are trying to access was not entered in correctly.");

            MediaData = YoutubeDlData.GenerateData(URL, out _);
            if (MediaData is null || MediaData.AvailableFormats.Length == 0)
                throw new DownloadException(URL, "The media you are trying to access may not be accessible at this time, or it may have been removed.");

            MediaData.AvailableFormats.For((Format) => {
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

                    ListViewItem NewFormat = new(Format.QualityName.IsNotNullEmptyWhitespace() ? Format.QualityName : "?");
                    NewFormat.SubItems.Add(Format.VideoFps is not null && Format.VideoFps > 0 ? $"{Format.VideoFps}" : "?");
                    NewFormat.SubItems.Add(Format.Extension ?? "Unknown");
                    NewFormat.SubItems.Add(Format.Size);
                    NewFormat.SubItems.Add(Format.VideoBitrate is not null && Format.VideoBitrate > 0 ? $"{Format.VideoBitrate}Kbps" : "?");
                    NewFormat.SubItems.Add($"{Format.VideoWidth ?? -1}x{Format.VideoHeight ?? -1}");
                    NewFormat.SubItems.Add(Format.VideoCodec.IsNotNullEmptyWhitespace() && Format.VideoCodec != "none" ? Format.VideoCodec : "Unknown");
                    NewFormat.SubItems.Add(AudioBitrate);
                    NewFormat.SubItems.Add(SampleRate);
                    NewFormat.SubItems.Add(AudioCodec);
                    NewFormat.SubItems.Add(AudioChannels);
                    NewFormat.SubItems.Add(Format.Identifier);
                    NewFormat.Tag = Format;
                    Format.ListViewItem = NewFormat;

                    if (VideoItems.Count == 0)
                        SelectedVideoItem = NewFormat;

                    VideoItems.Add(NewFormat);
                }
                else if (Format.ValidAudioFormat) {
                    ListViewItem NewFormat = new($"{(Format.AudioBitrate is not null && Format.AudioBitrate > 0 ? $"{Format.AudioBitrate}" : "?")}Kbps");
                    NewFormat.SubItems.Add(Format.Extension ?? "Unknown");
                    NewFormat.SubItems.Add(Format.Size);
                    NewFormat.SubItems.Add($"{(Format.AudioSampleRate is not null && Format.AudioSampleRate > 0 ? $"{Format.AudioSampleRate}" : "?")}Hz");
                    NewFormat.SubItems.Add(Format.AudioCodec ?? "Unknown");
                    NewFormat.SubItems.Add(Format.AudioChannels is not null ? Format.AudioChannels.ToString() : "?");
                    NewFormat.SubItems.Add(Format.Identifier);
                    NewFormat.Tag = Format;
                    Format.ListViewItem = NewFormat;

                    if (AudioItems.Count == 0)
                        SelectedAudioItem = NewFormat;

                    AudioItems.Add(NewFormat);
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

                    ListViewItem NewFormat = new(Format.QualityName.IsNotNullEmptyWhitespace() ? Format.QualityName : "?");
                    NewFormat.SubItems.Add(Format.VideoFps is not null && Format.VideoFps > 0 ? $"{Format.VideoFps}" : "?");
                    NewFormat.SubItems.Add(Format.Extension ?? "Unknown");
                    NewFormat.SubItems.Add(Format.Size);
                    NewFormat.SubItems.Add(Format.VideoBitrate is not null && Format.VideoBitrate > 0 ? $"{Format.VideoBitrate}Kbps" : "?");
                    NewFormat.SubItems.Add($"{Format.VideoWidth ?? -1}x{Format.VideoHeight ?? -1}");
                    NewFormat.SubItems.Add(Format.VideoCodec.IsNotNullEmptyWhitespace() && Format.VideoCodec != "none" ? Format.VideoCodec : "Unknown");
                    NewFormat.SubItems.Add(AudioBitrate);
                    NewFormat.SubItems.Add(SampleRate);
                    NewFormat.SubItems.Add(AudioCodec);
                    NewFormat.SubItems.Add(AudioChannels);
                    NewFormat.SubItems.Add(Format.Identifier);
                    NewFormat.Tag = Format;
                    Format.ListViewItem = NewFormat;

                    if (UnknownItems.Count == 0)
                        NewFormat.ImageIndex = 0;

                    UnknownItems.Add(NewFormat);
                }

                MediaName = MediaData.Title;
                ProgressMediaName =
                    $"{(Config.Settings.Initialization.ScreenshotMode ? "The videos' title will appear here" : MediaName)} - {Language.ApplicationName}";
            });

            InfoRetrieved = true;

            if (System.Threading.SynchronizationContext.Current is not null)
                System.Threading.SynchronizationContext.Current.Send((callback) => ParsingFinished(this), null);
            else ParsingFinished(this);
        }
    }
    /// <summary>
    /// Downloads the media thumbnail, converting to jpg if required.
    /// If the thumbnail was already downloaded, it will return the previously acquired thumbnail.
    /// </summary>
    /// <returns>An <see cref="Image"/> of the thumbnail.</returns>
    public Image DownloadThumbnail() => DownloadThumbnail(false);
    /// <summary>
    /// Downloads the media thumbnail, converting to jpg if required.
    /// If <paramref name="ForceRedownload"/> is <see langword="true"/>, the thumbnail will be downloaded regardless of if it already has been downloaded.
    /// </summary>
    /// <param name="ForceRedownload">Whether to redownload the thumbnail regardless of if it already exists in memory.</param>
    /// <returns>An <see cref="Image"/> of the thumbnail.</returns>
    public Image DownloadThumbnail(bool ForceRedownload) {
        if (Thumbnail is null || ForceRedownload)
            Thumbnail = MediaData.GetThumbnail();

        return Thumbnail;
    }
    /// <summary>
    /// Generates <see cref="DownloadException"/> for an invalid <see cref="SelectedType"/> value.
    /// </summary>
    private DownloadException InvalidType => new(URL, $"The SelectedType {SelectedType} is not valid.");

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    /// <returns>A 32-bit signed integer hash code.</returns>
    public override int GetHashCode() => URL.GetHashCode();

    ~ExtendedMediaDetails() {
        Authentication.Username = null;
        Authentication.Password?.Clear();
        Authentication.Password = null;
        Authentication.TwoFactor = null;
        Authentication.MediaPassword?.Clear();
        Authentication.MediaPassword = null;
        Authentication.CookiesFile = null;
        Authentication.CookiesFromBrowser = null;
    }

    /// <summary>
    /// Gets whether this instance has been disposed.
    /// </summary>
    public bool Disposed { get; private set; }
    public void Dispose() {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
    private void Dispose(bool disposing) {
        if (!Disposed) {
            if (disposing) {
                Authentication.Username = null;
                Authentication.Password?.Clear();
                Authentication.Password = null;
                Authentication.TwoFactor = null;
                Authentication.MediaPassword?.Clear();
                Authentication.MediaPassword = null;
                Authentication.CookiesFile = null;
                Authentication.CookiesFromBrowser = null;

                SelectedVideoItem.Tag = null;
                SelectedVideoItem = null;
                VideoItems.Clear();
                SelectedAudioItem.Tag = null;
                SelectedAudioItem = null;
                AudioItems.Clear();
                SelectedUnknownItem.Tag = null;
                SelectedUnknownItem = null;
                UnknownItems.Clear();

                CustomArguments = null;
                MediaData = null;
                ProtectedArguments = null;
                Thumbnail = null;
            }
            Disposed = true;
        }
    }
}