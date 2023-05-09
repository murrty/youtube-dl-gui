namespace youtube_dl_gui;
public enum DownloadStatus {
    None,
    GeneratingArguments,
    GatheringInformation,
    Downloading,
    Finished,
    Aborted,
    YtdlError,
    ProgramError,
    AbortForClose
}