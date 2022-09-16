namespace youtube_dl_gui;
public enum DownloadStatus : int {
    None = -1,
    GeneratingArguments = 0,
    Downloading = 1,
    Finished = 2,
    Aborted = 3,
    YtdlError = 4,
    ProgramError = 5,
    AbortForClose = 6,
}