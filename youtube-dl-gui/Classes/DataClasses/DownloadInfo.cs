#nullable enable
namespace youtube_dl_gui;
using System.Diagnostics.CodeAnalysis;
/// <summary>
///     Represents an object that contains information about a media download, with settings for the download.
/// </summary>
/// <remarks>
///     Initializes a new instance of <see cref="DownloadInfo"/> with information for downloading a media object.
/// </remarks>
/// <param name="URL">
///     The URL to download.
/// </param>
internal sealed class DownloadInfo(string URL) : MediaInfo(URL) {
    private string? _argsCensored;

    /// <summary>
    /// The URL of the video to download.
    /// </summary>
    public string DownloadURL => base.Source;
    /// <summary>
    /// The arguments (censored) for display.
    /// These are 'one-and-done', when you get the arguments this instance will be set to <see langword="null"/>.
    /// </summary>
    public string? ArgumentsCensored {
        get {
            string? args = _argsCensored;
            _argsCensored = null;
            return args;
        }
        set => _argsCensored = value;
    }
    /// <summary>
    /// Custom arguments for youtube-dl.
    /// </summary>
    public string? CustomArguments { get; set; }
    /// <summary>
    /// The status of the current download
    /// </summary>
    public DownloadStatus Status { get; set; } = DownloadStatus.None;
    /// <summary>
    /// The file-name schema of the download.
    /// </summary>
    public string FileNameSchema { get; set; } = Downloads.fileNameSchema;
    /// <summary>
    /// Whether the only generated arguments through this application is the output folder. This should be <see langword="true"/> for ytarchive downloads or downloads that are specialized and only require the output folder to be generated for the arguments.
    /// </summary>
    [MemberNotNullWhen(true, nameof(CustomArguments))]
    public bool MostlyCustomArguments { get; set; }

    /// <summary>
    /// The type of the download.
    /// </summary>
    public DownloadType Type { get; set; } = DownloadType.None;
    /// <summary>
    /// The quality of the video download.
    /// </summary>
    public VideoQualityType VideoQuality { get; set; } = VideoQualityType.none;
    /// <summary>
    /// The format of the video download.
    /// </summary>
    public VideoFormatType VideoFormat { get; set; } = VideoFormatType.none;
    /// <summary>
    /// The CBR quality of the audio download.
    /// </summary>
    public AudioCBRQualityType AudioCBRQuality { get; set; } = AudioCBRQualityType.none;
    /// <summary>
    /// The VBR quality of the audio download.
    /// </summary>
    public AudioVBRQualityType AudioVBRQuality { get; set; } = AudioVBRQualityType.none;
    /// <summary>
    /// the format of the audio download.
    /// </summary>
    public AudioFormatType AudioFormat { get; set; } = AudioFormatType.none;
    /// <summary>
    /// The playlist selection type.
    /// </summary>
    public PlaylistSelectionType PlaylistSelection { get; set; } = PlaylistSelectionType.None;

    /// <summary>
    /// Determines of the video should skip downloading the audio
    /// </summary>
    public bool SkipAudioForVideos { get; set; }
    /// <summary>
    /// Determines if the audio should be in VBR (Variable bit rate)
    /// </summary>
    public bool UseVBR { get; set; }
    /// <summary>
    /// Determines if the download is a part of a batch process.
    /// </summary>
    public bool BatchDownload { get; set; }
    /// <summary>
    /// The time of the batch download start.
    /// </summary>
    public string? BatchTime { get; set; }
    /// <summary>
    /// The authentication for this instance.
    /// </summary>
    public AuthenticationDetails? Authentication { get; set; }
    /// <summary>
    /// The arguments for playlist selection.
    /// </summary>
    public string? PlaylistSelectionArg { get; set; }
    /// <summary>
    /// The int index of the start of the playlist.
    /// </summary>
    public int PlaylistSelectionIndexStart { get; set; } = -1;
    /// <summary>
    /// The int index of the end of the playlist.
    /// </summary>
    public int PlaylistSelectionIndexEnd { get; set; } = -1;

    /// <summary>
    /// Generates the arguments for the download instance.
    /// </summary>
    /// <param name="Verbose">The ExtendedRichTextBox object to export verbose information to.</param>
    /// <returns><see langword="true"/> if the arguments generated successfully; otherwise, <see langword="false"/>.</returns>
    public override bool GenerateArguments(Action<string> Verbose) {
        Status = DownloadStatus.Preparing;

        if (DownloadURL.IsNullEmptyWhitespace()) {
            Verbose("The URL is null or empty. Please enter a URL to download.");
            Log.Write("Cannot continue download.");
            return false;
        }

        ArgumentList ArgumentsBuffer = new();
        ArgumentList PreviewArguments;

        #region youtube-dl path
        string DownloadProvider = Verification.GetYoutubeDlProvider(false);

        Verbose($"Using {DownloadProvider} as the download provider.");
        if (!Verification.YoutubeDlAvailable) {
            Verbose($"The download provider has not been found\r\nA rescan for {DownloadProvider} was called");
            Verification.RefreshYoutubeDlLocation();
            if (!Verification.YoutubeDlAvailable) {
                Verbose($"still couldnt find {DownloadProvider}.");
                Status = DownloadStatus.ProgramError;
                Log.Write($"{DownloadProvider} could not be found.");
                return false;
            }
        }
        Verbose($"{DownloadProvider} has been found and set");
        #endregion

        #region Output
        Verbose("Generating output directory structure");

        StringBuilder OutputDirectory = new($"\"{(
            Downloads.downloadPath.StartsWith("./") || Downloads.downloadPath.StartsWith(".\\") ?
                $"{Program.ProgramPath}\\{Downloads.downloadPath[2..]}" :
                Downloads.downloadPath)}");

        if (BatchDownload && Downloads.SeparateBatchDownloads) {
            OutputDirectory.Append("\\# Batch Downloads #");

            if (Downloads.AddDateToBatchDownloadFolders)
                OutputDirectory.Append('\\').Append(BatchTime);
        }

        if (Downloads.separateIntoWebsiteURL)
            OutputDirectory.Append('\\').Append(DownloadHelper.GetUrlBase(DownloadURL, MostlyCustomArguments));

        if (Downloads.separateDownloads && !MostlyCustomArguments) {
            switch (Type) {
                case DownloadType.Video:
                    OutputDirectory.Append("\\Video");
                    break;
                case DownloadType.Audio:
                    OutputDirectory.Append("\\Audio");
                    break;
                case DownloadType.Custom:
                    OutputDirectory.Append("\\Custom");
                    break;
                default:
                    Verbose("Unable to determine what download type to use.");
                    Status = DownloadStatus.ProgramError;
                    return false;
            }
        }
        if (FileNameSchema.IsNullEmptyWhitespace()) {
            Verbose("The file name schema is not properly set, falling back to the default one. Consider setting it in the settings, or making sure the schema list has a proper schema format on the main form.");
            OutputDirectory.Append("\\%(title)s-%(id)s.%(ext)s\"");
        }
        else {
            OutputDirectory.Append('\\').Append(FileNameSchema).Append('\"');
        }

        if (!MostlyCustomArguments) {
            ArgumentsBuffer.Add($"{DownloadURL} -o {OutputDirectory}");
        }

        Verbose("The output was generated and will be used");
        #endregion

        #region Quality & format
        switch (Type) {
            case DownloadType.Video: {
                if (SkipAudioForVideos) {
                    ArgumentsBuffer.Add(Formats.GetVideoQualityArgsNoSound(VideoQuality));
                }
                else {
                    ArgumentsBuffer.Add(Formats.GetVideoQualityArgs(VideoQuality));
                }

                ArgumentsBuffer.Add(Formats.GetVideoRecodeInfo(VideoFormat));
            } break;
            case DownloadType.Audio: {
                if (AudioCBRQuality == AudioCBRQualityType.best || AudioVBRQuality == AudioVBRQualityType.q0) {
                    ArgumentsBuffer.Add("--extract-audio --audio-quality 0");
                }
                else {
                    if (UseVBR) {
                        ArgumentsBuffer.Add($"--extract-audio --audio-quality {AudioVBRQuality}");
                    }
                    else {
                        ArgumentsBuffer.Add($"--extract-audio --audio-quality {Formats.GetAudioQuality(AudioCBRQuality)}");
                    }
                }

                if (AudioFormat == AudioFormatType.best) {
                    ArgumentsBuffer.Add("--audio-format best");
                }
                else {
                    ArgumentsBuffer.Add($"--extract-audio --audio-format {Formats.GetAudioFormat(AudioFormat)}");
                }
            } break;
            case DownloadType.Custom: {
                Verbose("Custom was requested, skipping quality + format");
                if (MostlyCustomArguments) {
                    ArgumentsBuffer = new($"{CustomArguments} -o \"{OutputDirectory}\"");
                    break;
                }

                if (CustomArguments.IsNullEmptyWhitespace()) {
                    Verbose("No custom arguments were provided.");
                    return false;
                }

                ArgumentsBuffer.Add(CustomArguments);
            } break;
            default: {
                Verbose("Expected a downloadtype (Quality + Format)");
                Status = DownloadStatus.ProgramError;
            } return false;
        }

        Verbose("The quality and format has been set");
        #endregion

        #region Arguments
        if (Type != DownloadType.Custom) {
            switch (PlaylistSelection) {
                case PlaylistSelectionType.PlaylistStartPlaylistEnd: // playlist-start and playlist-end
                    if (PlaylistSelectionIndexStart > 0) {
                        ArgumentsBuffer.Add($"--playlist-start {PlaylistSelectionIndexStart}");
                    }

                    if (PlaylistSelectionIndexEnd > 0) {
                        ArgumentsBuffer.Add($"--playlist-end {PlaylistSelectionIndexStart + PlaylistSelectionIndexEnd}");
                    }
                    break;
                case PlaylistSelectionType.PlaylistItems: // playlist-items
                    ArgumentsBuffer.Add($"--playlist-items {PlaylistSelectionArg}");
                    break;
                case PlaylistSelectionType.DateBefore: // datebefore
                    ArgumentsBuffer.Add($"--datebefore {PlaylistSelectionArg}");
                    break;
                case PlaylistSelectionType.DateDuring: // date
                    ArgumentsBuffer.Add($"--date {PlaylistSelectionArg}");
                    break;
                case PlaylistSelectionType.DateAfter: // dateafter
                    ArgumentsBuffer.Add($"--dateafter {PlaylistSelectionArg}");
                    break;
            }

            if (Downloads.PreferFFmpeg || (DownloadHelper.IsReddit(DownloadURL) && Downloads.fixReddit)) {
                Verbose("Looking for ffmpeg");
                bool AddArg = true;
                if (!Verification.FfmpegAvailable) {
                    Verbose("WARNING: ffmpeg could not be found; refreshing location");
                    Verification.RefreshFFmpegLocation();
                    if (!Verification.FfmpegAvailable) {
                        Verbose("WARNING: Could not find ffmpeg, it will not be used, downloading may be affected");
                        AddArg = false;
                    }
                }

                if (AddArg) {
                    Verbose("ffmpeg will be used for HLS");
                    ArgumentsBuffer.Add($"--ffmpeg-location \"{Verification.FFmpegPath}\" --hls-prefer-ffmpeg");
                }
            }

            if (Downloads.SaveSubtitles) {
                ArgumentsBuffer.Add("--all-subs");

                if (!Downloads.SubtitleFormat.IsNullEmptyWhitespace()) {
                    ArgumentsBuffer.Add($"--sub-format {Downloads.SubtitleFormat} ");
                }

                if (Downloads.EmbedSubtitles && Type == DownloadType.Video) {
                    ArgumentsBuffer.Add("--embed-subs");
                }
            }
            if (Downloads.SaveVideoInfo) {
                ArgumentsBuffer.Add("--write-info-json");
            }
            if (Downloads.SaveDescription) {
                ArgumentsBuffer.Add("--write-description");
            }
            if (Downloads.SaveAnnotations) {
                ArgumentsBuffer.Add("--write-annotations");
            }
            if (Downloads.SaveThumbnail) {
                // ArgumentsBuffer += "--write-all-thumbnails "; // Maybe?
                ArgumentsBuffer.Add("--write-thumbnail");
                if (Downloads.EmbedThumbnails) {
                    switch (Type) {
                        case DownloadType.Video:
                            if (VideoFormat == VideoFormatType.mp4) {
                                ArgumentsBuffer.Add("--embed-thumbnail");
                            }
                            else {
                                Verbose("!!!!!!!! WARNING !!!!!!!!\r\nCannot embed thumbnail to non-mp4 videos files");
                            }
                            break;
                        case DownloadType.Audio:
                            if (AudioFormat == AudioFormatType.m4a || AudioFormat == AudioFormatType.mp3) {
                                ArgumentsBuffer.Add("--embed-thumbnail");
                            }
                            else {
                                Verbose("!!!!!!!! WARNING !!!!!!!!\r\nCannot embed thumbnail to non-m4a/mp3 audio files");
                            }
                            break;
                    }
                }
            }
            if (Downloads.WriteMetadata) {
                ArgumentsBuffer.Add("--add-metadata");
            }

            if (Downloads.KeepOriginalFiles) {
                ArgumentsBuffer.Add("-k");
            }

            if (Downloads.LimitDownloads && Downloads.DownloadLimit > 0) {
                ArgumentsBuffer.Add($"--limit-rate {Downloads.DownloadLimit}");
                switch (Downloads.DownloadLimitType) {
                    case 1: { // mb
                        ArgumentsBuffer.Add("M");
                    } break;
                    case 2: { // gb
                        ArgumentsBuffer.Add("G");
                    } break;
                    default: { // kb default
                        ArgumentsBuffer.Add("K");
                    } break;
                }
            }

            if (Downloads.RetryAttempts != 10 && Downloads.RetryAttempts > 0) {
                ArgumentsBuffer.Add($"--retries {Downloads.RetryAttempts}");
            }

            if (Downloads.ForceIPv4) {
                ArgumentsBuffer.Add("--force-ipv4");
            }
            else if (Downloads.ForceIPv6) {
                ArgumentsBuffer.Add("--force-ipv6");
            }

            if (Downloads.UseProxy && Downloads.ProxyType > -1 && !string.IsNullOrEmpty(Downloads.ProxyIP) && !string.IsNullOrEmpty(Downloads.ProxyPort)) {
                ArgumentsBuffer.Add($"--proxy {DownloadHelper.ProxyProtocols[Downloads.ProxyType]}{Downloads.ProxyIP}:{Downloads.ProxyPort}/");
            }

            if (Downloads.SkipUnavailableFragments) {
                ArgumentsBuffer.Add("--abort-on-unavailable-fragment");
            }

            if (!Downloads.AbortOnError) {
                ArgumentsBuffer.Add("--no-abort-on-error");
            }

            if (Downloads.FragmentThreads > 1) {
                ArgumentsBuffer.Add("--concurrent-fragments " + Downloads.FragmentThreads);
            }

            if (!BatchDownload) {
                ArgumentsBuffer.Add("--no-playlist");
            }

            if (!CustomArguments.IsNullEmptyWhitespace()) {
                CustomArguments = CustomArguments.ReplaceWhitespace().Trim();
                if (!CustomArguments.IsNullEmptyWhitespace()) {
                    ArgumentsBuffer.Add(CustomArguments);
                }
            }
        }
        #endregion

        #region Authentication
        // Set the preview arguments to what is present in the arguments buffer.
        // This is so the arguments buffer can have sensitive information and
        // the preview arguments won't include it in case anyone creates an issue.
        PreviewArguments = new(ArgumentsBuffer.ToString());

        if (!MostlyCustomArguments) {
            if (Authentication is not null) {
                if (!Authentication.Username.IsNullEmptyWhitespace()) {
                    ArgumentsBuffer.Add($"--username {Authentication.Username}");
                    Authentication.Username = null;
                    PreviewArguments.Add("--username ***");
                }
                if (Authentication.Password?.Length > 0) {
                    ArgumentsBuffer.Add($"--password {Authentication.GetPassword()}");
                    Array.Clear(Authentication.Password, 0, Authentication.Password.Length);
                    PreviewArguments.Add("--password ***");
                }
                if (!Authentication.TwoFactor.IsNullEmptyWhitespace()) {
                    ArgumentsBuffer.Add($"--twofactor {Authentication.TwoFactor}");
                    Authentication.TwoFactor = null;
                    PreviewArguments.Add("--twofactor ***");
                }
                if (Authentication.MediaPassword?.Length > 0) {
                    ArgumentsBuffer.Add($"--video-password {Authentication.GetMediaPassword()}");
                    Array.Clear(Authentication.MediaPassword, 0, Authentication.MediaPassword.Length);
                    PreviewArguments.Add("--video-password ***");
                }
                if (Authentication.NetRC) {
                    ArgumentsBuffer.Add("--netrc");
                    PreviewArguments.Add("--netrc ***");
                    Authentication.NetRC = false;
                }
                if (!Authentication.CookiesFile.IsNullEmptyWhitespace()) {
                    ArgumentsBuffer.Add($"--cookies {Authentication.CookiesFile}");
                    PreviewArguments.Add("--cookies ***");
                    Authentication.CookiesFile = null;
                }
                if (!Authentication.CookiesFromBrowser.IsNullEmptyWhitespace()) {
                    ArgumentsBuffer.Add($"--cookies-from-browser {Authentication.CookiesFromBrowser}");
                    PreviewArguments.Add("--cookies-from-browser ***");
                    Authentication.CookiesFromBrowser = null;
                }
            }
        }
        #endregion

        Verbose("Arguments have been generated");
        base.Arguments = ArgumentsBuffer.ToString();
        ArgumentsCensored = PreviewArguments.ToString();

        ArgumentsBuffer.Clear();
        PreviewArguments.Clear();
        return true;
    }
}