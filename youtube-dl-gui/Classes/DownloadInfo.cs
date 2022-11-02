namespace youtube_dl_gui;

public sealed class DownloadInfo {
    /// <summary>
    /// The URL of the video to download.
    /// </summary>
    public string DownloadURL { get; set; } = null;
    /// <summary>
    /// The arguments passed for youtube-dl
    /// </summary>
    public string DownloadArguments { get; set; } = null;
    /// <summary>
    /// The status of the current download
    /// </summary>
    public DownloadStatus Status { get; set; } = DownloadStatus.None;
    /// <summary>
    /// The file-name schema of the download.
    /// </summary>
    public string FileNameSchema { get; set; } = null;
    /// <summary>
    /// Whether the arguments are full custom, excepting for output.
    /// </summary>
    public bool MostlyCustomArguments { get; set; } = false;

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
    public bool SkipAudioForVideos { get; set; } = true;
    /// <summary>
    /// Determines if the audio should be in VBR (Variable bit rate)
    /// </summary>
    public bool UseVBR { get; set; } = false;
    /// <summary>
    /// Determines if the download is a part of a batch process.
    /// </summary>
    public bool BatchDownload { get; set; } = false;
    /// <summary>
    /// The time of the batch download start.
    /// </summary>
    public string BatchTime { get; set; } = null;
    /// <summary>
    /// The username for authentication.
    /// </summary>
    public string AuthUsername { get; set; } = null;
    /// <summary>
    /// The password for authentication.
    /// </summary>
    public string AuthPassword { get; set; } = null;
    /// <summary>
    /// The 2-factor answer for authentication.
    /// </summary>
    public string Auth2Factor { get; set; } = null;
    /// <summary>
    /// The video password for authentication.
    /// </summary>
    public string AuthVideoPassword { get; set; } = null;
    /// <summary>
    /// Determines if authentication should use NetRC.
    /// </summary>
    public bool AuthNetrc { get; set; } = false;
    /// <summary>
    /// The arguments for playlist selection.
    /// </summary>
    public string PlaylistSelectionArg { get; set; } = null;
    /// <summary>
    /// The int index of the start of the playlist.
    /// </summary>
    public int PlaylistSelectionIndexStart { get; set; } = -1;
    /// <summary>
    /// The int index of the end of the playlist.
    /// </summary>
    public int PlaylistSelectionIndexEnd { get; set; } = -1;

    public DownloadInfo() {
        FileNameSchema = Config.Settings.Downloads.fileNameSchema;
    }

    public bool GenerateArguments(murrty.controls.ExtendedRichTextBox Verbose, out string Arguments, out string CensoredArguments) {
        Status = DownloadStatus.GeneratingArguments;
        Arguments = null;
        CensoredArguments = null;

        if (DownloadURL.IsNullEmptyWhitespace()) {
            Verbose.AppendLine("The URL is null or empty. Please enter a URL to download.");
            Log.Write("Cannot continue download.");
            return false;
        }

        #region URL cleaning
        DownloadURL.Trim('\\', '"', '\n', '\r', '\t', '\0', '\b', '\'');
        if (!DownloadURL.StartsWith("https://"))
            if (DownloadURL.StartsWith("http://"))
                DownloadURL = "https" + DownloadURL[4..];
        #endregion

        StringBuilder ArgumentsBuffer = new(string.Empty);
        StringBuilder PreviewArguments;

        #region youtube-dl path
        if (Verification.YoutubeDlPath.IsNullEmptyWhitespace()) {
            Verbose.AppendLine("Youtube-DL has not been found\r\nA rescan for youtube-dl was called");
            Verification.RefreshYoutubeDlLocation();
            if (Verification.YoutubeDlPath is not null)
                Verbose.AppendLine("Rescan finished and found, continuing");
            else {
                Verbose.AppendLine("still couldnt find youtube-dl.");
                Status = DownloadStatus.ProgramError;
                Log.Write("Youtube-dl could not be found.");
                return false;
            }
        }
        Verbose.AppendLine("Youtube-DL has been found and set");
        #endregion

        #region Output
        Verbose.AppendLine("Generating output directory structure");

        StringBuilder OutputDirectory = new($"\"{(
            Config.Settings.Downloads.downloadPath.StartsWith("./") || Config.Settings.Downloads.downloadPath.StartsWith(".\\") ?
                $"{Program.ProgramPath}\\{Config.Settings.Downloads.downloadPath[2..]}" :
                Config.Settings.Downloads.downloadPath)}");

        if (BatchDownload && Config.Settings.Downloads.SeparateBatchDownloads) {
            OutputDirectory.Append("\\# Batch Downloads #");

            if (Config.Settings.Downloads.AddDateToBatchDownloadFolders)
                OutputDirectory.Append($"\\{BatchTime}");
        }

        if (Config.Settings.Downloads.separateIntoWebsiteURL)
            OutputDirectory.Append($"\\{DownloadHelper.GetUrlBase(DownloadURL, MostlyCustomArguments)}");

        if (Config.Settings.Downloads.separateDownloads && !MostlyCustomArguments) {
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
                    Verbose.AppendLine("Unable to determine what download type to use (expected 0, 1, or 2)");
                    Status = DownloadStatus.ProgramError;
                    return false;
            }
        }
        if (string.IsNullOrWhiteSpace(FileNameSchema)) {
            Verbose.AppendLine("The file name schema is not properly set, falling back to the default one. Consider setting it in the settings, or making sure the schema list has a proper schema format on the main form.");
            OutputDirectory.Append("\\%(title)s-%(id)s.%(ext)s");
        }
        else
            OutputDirectory.Append($"\\{FileNameSchema}\"");

        if (!MostlyCustomArguments)
            ArgumentsBuffer.Append($"{DownloadURL} -o {OutputDirectory}");

        Verbose.AppendLine("The output was generated and will be used");
        #endregion

        #region Quality & format
        switch (Type) {
            case DownloadType.Video: {
                if (SkipAudioForVideos)
                    ArgumentsBuffer.Append(Formats.GetVideoQualityArgsNoSound(VideoQuality));
                else
                    ArgumentsBuffer.Append(Formats.GetVideoQualityArgs(VideoQuality));

                ArgumentsBuffer.Append(Formats.GetVideoRecodeInfo(VideoFormat));
            } break;
            case DownloadType.Audio: {
                if (AudioCBRQuality == AudioCBRQualityType.best || AudioVBRQuality == AudioVBRQualityType.q0) {
                    ArgumentsBuffer.Append(" --extract-audio --audio-quality 0");
                }
                else {
                    if (UseVBR)
                        ArgumentsBuffer.Append($" --extract-audio --audio-quality {AudioVBRQuality}");
                    else
                        ArgumentsBuffer.Append($" --extract-audio --audio-quality {Formats.GetAudioQuality(AudioCBRQuality)}");
                }

                if (AudioFormat == AudioFormatType.best)
                    ArgumentsBuffer.Append(" --audio-format best");
                else
                    ArgumentsBuffer.Append($" --extract-audio --audio-format {Formats.GetAudioFormat(AudioFormat)}");
            } break;
            case DownloadType.Custom: {
                Verbose.AppendLine("Custom was requested, skipping quality + format");
                if (MostlyCustomArguments)
                    ArgumentsBuffer = new($"{DownloadArguments} -o \"{OutputDirectory}\"");
                else if (!string.IsNullOrWhiteSpace(DownloadArguments))
                    ArgumentsBuffer.Append($" {DownloadArguments}");
                else {
                    Verbose.AppendLine("No custom arguments were provided.");
                    return false;
                }
            } break;
            default: {
                Verbose.AppendLine("Expected a downloadtype (Quality + Format)");
                Status = DownloadStatus.ProgramError;
            } return false;
        }

        Verbose.AppendLine("The quality and format has been set");
        #endregion

        #region Arguments
        if (Type != DownloadType.Custom) {
            switch (PlaylistSelection) {
                case PlaylistSelectionType.PlaylistStartPlaylistEnd: // playlist-start and playlist-end
                    if (PlaylistSelectionIndexStart > 0)
                        ArgumentsBuffer.Append($" --playlist-start {PlaylistSelectionIndexStart}");

                    if (PlaylistSelectionIndexEnd > 0)
                        ArgumentsBuffer.Append($" --playlist-end {(PlaylistSelectionIndexStart + PlaylistSelectionIndexEnd)}");
                    break;
                case PlaylistSelectionType.PlaylistItems: // playlist-items
                    ArgumentsBuffer.Append($" --playlist-items {PlaylistSelectionArg}");
                    break;
                case PlaylistSelectionType.DateBefore: // datebefore
                    ArgumentsBuffer.Append($" --datebefore {PlaylistSelectionArg}");
                    break;
                case PlaylistSelectionType.DateDuring: // date
                    ArgumentsBuffer.Append($" --date {PlaylistSelectionArg}");
                    break;
                case PlaylistSelectionType.DateAfter: // dateafter
                    ArgumentsBuffer.Append($" --dateafter {PlaylistSelectionArg}");
                    break;
            }

            if ((Config.Settings.Downloads.PreferFFmpeg || DownloadHelper.IsReddit(DownloadURL)) && Config.Settings.Downloads.fixReddit) {
                Verbose.AppendLine("Looking for ffmpeg");
                if (Verification.FFmpegPath is not null) {
                    if (Config.Settings.General.UseStaticFFmpeg)
                        ArgumentsBuffer.Append($" --ffmpeg-location \"{Config.Settings.General.ffmpegPath}\" --hls-prefer-ffmpeg");
                    else
                        ArgumentsBuffer.Append($" --ffmpeg-location \"{Verification.FFmpegPath}\" --hls-prefer-ffmpeg");

                    Verbose.AppendLine("ffmpeg was found");
                }
                else
                    Verbose.AppendLine("ffmpeg path is null, downloading may be affected");
            }

            if (Config.Settings.Downloads.SaveSubtitles) {
                ArgumentsBuffer.Append(" --all-subs");

                if (!string.IsNullOrEmpty(Config.Settings.Downloads.SubtitleFormat))
                    ArgumentsBuffer.Append($" --sub-format {Config.Settings.Downloads.SubtitleFormat} ");

                if (Config.Settings.Downloads.EmbedSubtitles && Type == DownloadType.Video)
                    ArgumentsBuffer.Append(" --embed-subs");
            }
            if (Config.Settings.Downloads.SaveVideoInfo)
                ArgumentsBuffer.Append(" --write-info-json");
            if (Config.Settings.Downloads.SaveDescription)
                ArgumentsBuffer.Append(" --write-description");
            if (Config.Settings.Downloads.SaveAnnotations)
                ArgumentsBuffer.Append(" --write-annotations");
            if (Config.Settings.Downloads.SaveThumbnail) {
                // ArgumentsBuffer += "--write-all-thumbnails "; // Maybe?
                ArgumentsBuffer.Append(" --write-thumbnail");
                if (Config.Settings.Downloads.EmbedThumbnails) {
                    switch (Type) {
                        case DownloadType.Video:
                            if (VideoFormat == VideoFormatType.mp4)
                                ArgumentsBuffer.Append(" --embed-thumbnail");
                            else
                                Verbose.AppendLine("!!!!!!!! WARNING !!!!!!!!\r\nCannot embed thumbnail to non-mp4 videos files");
                            break;
                        case DownloadType.Audio:
                            if (AudioFormat == AudioFormatType.m4a || AudioFormat == AudioFormatType.mp3)
                                ArgumentsBuffer.Append(" --embed-thumbnail");
                            else
                                Verbose.AppendLine("!!!!!!!! WARNING !!!!!!!!\r\nCannot embed thumbnail to non-m4a/mp3 audio files");
                            break;
                    }
                }
            }
            if (Config.Settings.Downloads.WriteMetadata)
                ArgumentsBuffer.Append(" --add-metadata");

            if (Config.Settings.Downloads.KeepOriginalFiles)
                ArgumentsBuffer.Append(" -k");

            if (Config.Settings.Downloads.LimitDownloads && Config.Settings.Downloads.DownloadLimit > 0) {
                ArgumentsBuffer.Append($" --limit-rate {Config.Settings.Downloads.DownloadLimit}");
                switch (Config.Settings.Downloads.DownloadLimitType) {
                    case 1: { // mb
                        ArgumentsBuffer.Append("M ");
                    } break;
                    case 2: { // gb
                        ArgumentsBuffer.Append("G ");
                    } break;
                    default: { // kb default
                        ArgumentsBuffer.Append("K ");
                    } break;
                }
            }

            if (Config.Settings.Downloads.RetryAttempts != 10 && Config.Settings.Downloads.RetryAttempts > 0)
                ArgumentsBuffer.Append($" --retries {Config.Settings.Downloads.RetryAttempts}");

            if (Config.Settings.Downloads.ForceIPv4)
                ArgumentsBuffer.Append(" --force-ipv4");
            else if (Config.Settings.Downloads.ForceIPv6)
                ArgumentsBuffer.Append(" --force-ipv6");

            if (Config.Settings.Downloads.UseProxy && Config.Settings.Downloads.ProxyType > -1 && !string.IsNullOrEmpty(Config.Settings.Downloads.ProxyIP) && !string.IsNullOrEmpty(Config.Settings.Downloads.ProxyPort))
                ArgumentsBuffer.Append($" --proxy {DownloadHelper.ProxyProtocols[Config.Settings.Downloads.ProxyType]}{Config.Settings.Downloads.ProxyIP}:{Config.Settings.Downloads.ProxyPort}/");

            if (!DownloadArguments.ReplaceWhitespace(" ").IsNullEmptyWhitespace())
                ArgumentsBuffer.Append(" " + DownloadArguments.ReplaceWhitespace(" ").Trim());
        }
        #endregion

        #region Authentication
        // Set the preview arguments to what is present in the arguments buffer.
        // This is so the arguments buffer can have sensitive information and
        // the preview arguments won't include it in case anyone creates an issue.
        PreviewArguments = new(ArgumentsBuffer.ToString());

        if (!MostlyCustomArguments) {
            if (AuthUsername is not null) {
                ArgumentsBuffer.Append($" --username {AuthUsername}");
                AuthUsername = null;
                PreviewArguments.Append(" --username ***");
            }
            if (AuthPassword is not null) {
                ArgumentsBuffer.Append($" --password {AuthPassword}");
                AuthPassword = null;
                PreviewArguments.Append(" --password ***");
            }
            if (Auth2Factor is not null) {
                ArgumentsBuffer.Append($" --twofactor {Auth2Factor}");
                Auth2Factor = null;
                PreviewArguments.Append(" --twofactor ***");
            }
            if (AuthVideoPassword is not null) {
                ArgumentsBuffer.Append($" --video-password {AuthVideoPassword}");
                AuthVideoPassword = null;
                PreviewArguments.Append(" --video-password ***");
            }
            if (AuthNetrc) {
                AuthNetrc = false;
                ArgumentsBuffer.Append(" --netrc");
                PreviewArguments.Append(" --netrc ***");
            }
        }
        #endregion

        Verbose.AppendLine("Arguments have been generated");
        Arguments = ArgumentsBuffer.ToString();
        CensoredArguments = PreviewArguments.ToString();
        return true;
    }
}