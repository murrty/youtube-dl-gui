namespace youtube_dl_gui;

public sealed class DownloadInfo {
    /// <summary>
    /// The URL of the video to download.
    /// </summary>
    public string DownloadURL = null;
    /// <summary>
    /// The arguments passed for youtube-dl
    /// </summary>
    public string DownloadArguments = null;
    /// <summary>
    /// The status of the current download
    /// </summary>
    public DownloadStatus Status = DownloadStatus.None;
    /// <summary>
    /// The file-name schema of the download.
    /// </summary>
    public string FileNameSchema = null;

    /// <summary>
    /// The type of the download.
    /// </summary>
    public DownloadType Type = DownloadType.None;
    /// <summary>
    /// The quality of the video download.
    /// </summary>
    public VideoQualityType VideoQuality = VideoQualityType.none;
    /// <summary>
    /// The format of the video download.
    /// </summary>
    public VideoFormatType VideoFormat = VideoFormatType.none;
    /// <summary>
    /// The CBR quality of the audio download.
    /// </summary>
    public AudioCBRQualityType AudioCBRQuality = AudioCBRQualityType.none;
    /// <summary>
    /// The VBR quality of the audio download.
    /// </summary>
    public AudioVBRQualityType AudioVBRQuality = AudioVBRQualityType.none;
    /// <summary>
    /// the format of the audio download.
    /// </summary>
    public AudioFormatType AudioFormat = AudioFormatType.none;
    /// <summary>
    /// The playlist selection type.
    /// </summary>
    public PlaylistSelectionType PlaylistSelection = PlaylistSelectionType.None;

    /// <summary>
    /// Determines of the video should skip downloading the audio
    /// </summary>
    public bool SkipAudioForVideos = true;
    /// <summary>
    /// Determines if the audio should be in VBR (Variable bit rate)
    /// </summary>
    public bool UseVBR = false;
    /// <summary>
    /// Determines if the download is a part of a batch process.
    /// </summary>
    public bool BatchDownload = false;
    /// <summary>
    /// The time of the batch download start.
    /// </summary>
    public string BatchTime = null;
    /// <summary>
    /// The username for authentication.
    /// </summary>
    public string AuthUsername = null;
    /// <summary>
    /// The password for authentication.
    /// </summary>
    public string AuthPassword = null;
    /// <summary>
    /// The 2-factor answer for authentication.
    /// </summary>
    public string Auth2Factor = null;
    /// <summary>
    /// The video password for authentication.
    /// </summary>
    public string AuthVideoPassword = null;
    /// <summary>
    /// Determines if authentication should use NetRC.
    /// </summary>
    public bool AuthNetrc = false;
    /// <summary>
    /// The arguments for playlist selection.
    /// </summary>
    public string PlaylistSelectionArg = null;
    /// <summary>
    /// The int index of the start of the playlist.
    /// </summary>
    public int PlaylistSelectionIndexStart = -1;
    /// <summary>
    /// The int index of the end of the playlist.
    /// </summary>
    public int PlaylistSelectionIndexEnd = -1;

    public DownloadInfo() {
        FileNameSchema = Config.Settings.Downloads.fileNameSchema;
    }
}