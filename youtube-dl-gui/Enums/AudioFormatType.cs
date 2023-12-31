#nullable enable
namespace youtube_dl_gui;
public enum AudioFormatType : int {
    none = -1,
    best = 0,
    aac = 1,
    flac = 2,
    mp3 = 3,
    m4a = 4,
    opus = 5,
    vorbis = 6,
    wav = 7
}