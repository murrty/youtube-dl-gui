#nullable enable
namespace youtube_dl_gui;
public enum ConversionStatus {
    None,
    Preparing,
    Converting,
    Finished,
    Aborted,
    FfmpegError,
    ProgramError
}