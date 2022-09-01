namespace youtube_dl_gui;
public enum ConversionStatus {
    None,
    GeneratingArguments,
    Converting,
    Finished,
    Aborted,
    FfmpegError,
    ProgramError
}