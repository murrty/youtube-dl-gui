namespace youtube_dl_gui;
public enum DownloadStatus : int {
    None = 0,
    Preparing = 1,
    Downloading = 2,
    Finished = 3,
    Aborted = 4,
    YtdlError = 5,
    ProgramError = 6,
    AbortForClose = 7,

    MergingFiles = 8,
    Converting = 9,
    ExtractingAudio = 10,
    FfmpegPostProcessing = 11,
    EmbeddingSubtitles = 12,
    EmbeddingMetadata = 13,
}