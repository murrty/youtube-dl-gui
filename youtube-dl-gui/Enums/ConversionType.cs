#nullable enable
namespace youtube_dl_gui;
public enum ConversionType : int {
    Unspecified = -1,
    Video = 0,
    Audio = 1,
    Custom = 2,
    FfmpegDefault = 3
}