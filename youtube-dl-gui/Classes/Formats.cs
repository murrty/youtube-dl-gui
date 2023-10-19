#nullable enable
namespace youtube_dl_gui;

internal static class Formats {
    /// <summary>
    /// The all files filter.
    /// </summary>
    public static string AllFiles { get; } = "All Files (*.*)|*.*";

    /// <summary>
    ///  All known video formats used by ffmpeg, as a filter.
    /// </summary>
    public static string VideoFormats { get; } =
        "3rd Generation Partnership (*.3gp, *3g2)|*.3gp;*.3g2"                  + "|" +
        //"Actions Media Video (*.amv)|*.amv"                        + "|" +
        "Audio Video Interleave (*.avi)|*.avi"                                  + "|" +
        //"Bink Video (*.bink, *.bik, *.bk2, *.bik2)|*.bink;*.bik;*.bk2;*.bik2"   + "|" +
        "Flash Video (*.flv)|*.flv"                                             + "|" +
        "Matroska Video (*.mkv)|*.mkv"                                          + "|" +
        "Theora Video (*.ogv)|*.ogv"                                            + "|" +
        "QuickTime Movie (*.mov)|*.mov"                                         + "|" +
        "MPEG Video (*.mpeg, *.mpg)|*.mpeg;*.mpg"                               + "|" +
        "MPEG-2 Video Stream (*.m2v)|*.m2v"                                     + "|" +
        "MPEG-4 Part 14 (*.mp4)|*.mp4"                                          + "|" +
        "NUT Video File (*.nut)|*.nut"                                          + "|" +
        //"Smacker video (*.smk)|*.smk"                                           + "|" +
        "Shockwave Flash (*.swf)|*.swf"                                         + "|" +
        "VP8/9 (*.webm)|*.webm"                                                 + "|" +
        "Windows Media Video (*.wmv)|*.wmv"                                     //+ "|" +
        //"Xbox Media Video (*.xmv)|*.xmv"                                        + "|" +
        //AllKnownVideoFormats + "|" + AllFiles;
        ;

    /// <summary>
    /// All the known video formats used by ffmpeg, as a single filter.
    /// </summary>
    public static string AllKnownVideoFormats { get; } =
        "*3gp;*3g2;*.avi;*.flv;*.mkv;*.ogv;*.mov;*.mpeg;*.mpg;*.m2v;*.mp4;*.nut;*.swf;*.webm;*.wmv";

    /// <summary>
    /// All known audio formats used by ffmpeg, as a filter.
    /// </summary>
    public static string AudioFormats  { get; } =
        "Advanced Audo Codec (*.aac)|*.aac"                                             + "|" +
        //"Audible Audio / Audible Enhanced Audio (*.aa, *.aax)|*.aa;*.aax"               + "|" +
        "Audio Codec 3 (*.ac3)|*.ac3"                                                   + "|" +
        "Audio Interchange File Format (*.aiff, *.aif, *.aifc)|*.aiff;*.aif;*.aifc"     + "|" +
        "Audio Interchange File Format Compressed (*.aifc)|*.aifc"                      + "|" +
        //"Bink Audio (*.binka)|*.binka"                                                  + "|" +
        //"Binary Revolution Stream (*.brstm)|*.brstm"                                    + "|" +
        //"FMOD Sample Bank (*.fsb)|*.fsb"                                                + "|" +
        "Free Lossless Audio Codec (*.flac)|*.flac"                                     + "|" +
        "Matroska Audio (*.mka)|*.mka"                                                  + "|" +
        //"Monkey's Audio (*.ape)|*.ape"                                                  + "|" +
        "MPEG-4 Audio (*.m4a)|*.m4a"                                                    + "|" +
        "MPEG-1 AudioLayer II (*.mp2)|*.mp2"                                            + "|" +
        "MPEG-1 AudioLayer III (*.mp3)|*.mp3"                                           + "|" +
        "OGG Vorbis (*.oga, *.ogg)|*.oga;*.ogg"                                         + "|" +
        "Opus OGG Compressed (*.opus)|*.opus"                                           + "|" +
        "True Audio (*.tta)|*.tta"                                                      + "|" +
        "Waveform Audio (*.wav)|*.wav"                                                  + "|" +
        "Windows Media Audio (*.wma)|*.wma"                                             //+ "|" +
        //"Xbox Windows Media Audio (*.xwma)|*.xwma"                                      + "|" +
        //AllKnownAudioFormats + "|" + AllFiles;
        ;

    /// <summary>
    /// All the known audio formats used by ffmpeg, as a single filter.
    /// </summary>
    public static string AllKnownAudioFormats { get; } =
        "*.aac;*.ac3;*.aiff;*.aif;*.aifc;*.flac;*.m4a;*.mka;*.mp2;*.mp3;*.oga;*.ogg;*.opus;*.tta;*.wav;*.wma";

    /// <summary>
    /// An aggregated string of all known video and audio formates with the all files filter as well.
    /// </summary>
    public static string AllFormats { get; } =
        $"All known formats|{AllKnownVideoFormats};{AllKnownAudioFormats}|{AllFiles}|{ VideoFormats}|{AudioFormats}";

    /// <summary>
    /// String array of known yt-dlp supported video formats.
    /// </summary>
    public static string[] ExtendedVideoFormats { get; } = {
        "avi",
        "flv",
        "mkv",
        "mov",
        "mp4",
        "webm"
    };

    /// <summary>
    /// String array of known yt-dlp supported audio formats.
    /// </summary>
    public static string[] ExtendedAudioFormats { get; } = {
        "aac",
        "aiff",
        "alac",
        "flac",
        "mp3",
        "m4a",
        "ogg",
        "opus",
        "vorbis",
        "wav"
    };

    #region Video Arrays
    public static string[] VideoQualityArray { get; } = {
        "best",
        "4320p60", "4320p", // 1
        "2160p60", "2160p", // 3
        "1440p60", "1440p", // 5
        "1080p60", "1080p", // 7
        "720p60", "720p",   // 9
        "480p",
        "360p",
        "240p",
        "144p",
        "worst"
    };

    public static string[] VideoFormatsNamesArray { get; } = {
        "best",
        "avi",
        "flv",
        "mkv",
        "mp4",
        "ogg",
        "webm"
    };
    #endregion

    #region Audio Arrays
    public static string[] AudioQualityNamesArray { get; } = {
        "best",
        "320k",
        "256k",
        "224k",
        "192k",
        "160k",
        "128k",
        "96k",
        "64k",
        "32k",
        "16k",
        "worst"
    };
    public static string[] AudioFormatsArray { get; } = {
        "best",
        "aac",
        "flac",
        "mp3",
        "m4a",
        "opus",
        "vorbis",
        "wav"
    };

    public static string[] VbrQualities { get; } = new string[] {
        "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"
    };
    #endregion

    // Could this be replaced with video formats? Because they could contain video, but don't necessarily need to.
    /// <summary>
    /// All formats that can be either Audio or Video.
    /// </summary>
    public const string InterFormats = null;

    /// <summary>
    /// Custom formats inputted by the user.
    /// </summary>
    public static string? CustomFormats;

    /// <summary>
    /// Loads the custom formats into memory.
    /// </summary>
    public static void LoadCustomFormats() {
        if (General.extensionsName.Length > 0) {
            string[] Names = General.extensionsName.Split('|');
            string[] Extensions = General.extensionsShort.Split('|');
            int MinimumList = Math.Min(Names.Length, Extensions.Length);
            if (MinimumList > 0) {
                CustomFormats = string.Empty;
                for (int i = 0; i < MinimumList; i++) {
                    CustomFormats += $"{Names[i]} (*.{Extensions[i]})|*.{Extensions[i]}";
                }
            }
            else {
                CustomFormats = null;
            }
        }
    }

    /// <summary>
    /// Get a filter-ready string of formats from a array of formats. If the input array is null or empty, it returns all files.
    /// </summary>
    /// <param name="FormatsArray">The string-array of the formats to join into one filter.</param>
    /// <returns>A filter-ready string of formats.</returns>
    public static string JoinFormats(string[] FormatsArray) {
        var Formats = FormatsArray.Where(ArrayIndex => !string.IsNullOrWhiteSpace(ArrayIndex));
        return Formats.Any() ? string.Join("|", Formats) : AllFiles;
    }

    public static string GetVideoQualityArgs(VideoQualityType Quality) {
        return Quality switch {
            VideoQualityType.q4320p60 => "-f \"bestvideo[height<=4320][fps>=48]+bestaudio/best\"",
            VideoQualityType.q4320p => "-f \"bestvideo[height<=4320][fps<=32]+bestaudio/best\"",
            VideoQualityType.q2160p60 => "-f \"bestvideo[height<=2160][fps>=48]+bestaudio/best\"",
            VideoQualityType.q2160p => "-f \"bestvideo[height<=2160][fps<=32]+bestaudio/best\"",
            VideoQualityType.q1440p60 => "-f \"bestvideo[height<=1440][fps>=48]+bestaudio/best\"",
            VideoQualityType.q1440p => "-f \"bestvideo[height<=1440][fps<=32]+bestaudio/best\"",
            VideoQualityType.q1080p60 => "-f \"bestvideo[height<=1080][fps>=48]+bestaudio/best\"",
            VideoQualityType.q1080p => "-f \"bestvideo[height<=1080][fps<=32]+bestaudio/best\"",
            VideoQualityType.q720p60 => "-f \"bestvideo[height<=720][fps>=48]+bestaudio/best\"",
            VideoQualityType.q720p => "-f \"bestvideo[height<=720][fps<=32]+bestaudio/best\"",
            VideoQualityType.q480p => "-f \"bestvideo[height<=480]+bestaudio/best\"",
            VideoQualityType.q360p => "-f \"bestvideo[height<=360]+bestaudio/best\"",
            VideoQualityType.q240p => "-f \"bestvideo[height<=240]+bestaudio/best\"",
            VideoQualityType.q144p => "-f \"bestvideo[height<=144]+bestaudio/best\"",
            VideoQualityType.worst => "-f \"worstvideo+worstaudio/worst\"",
            _ => "-f \"bestvideo+bestaudio/best\"",
        };
    }
    public static string GetVideoQualityArgsNoSound(VideoQualityType Quality) {
        return Quality switch {
            VideoQualityType.q4320p60 => "-f \"bestvideo[height<=4320][fps>=48]/best\"",
            VideoQualityType.q4320p => "-f \"bestvideo[height<=4320][fps<=32]/best\"",
            VideoQualityType.q2160p60 => "-f \"bestvideo[height<=2160][fps>=48]/best\"",
            VideoQualityType.q2160p => "-f \"bestvideo[height<=2160][fps<=32]/best\"",
            VideoQualityType.q1440p60 => "-f \"bestvideo[height<=1440][fps>=48]/best\"",
            VideoQualityType.q1440p => "-f \"bestvideo[height<=1440][fps<=32]/best\"",
            VideoQualityType.q1080p60 => "-f \"bestvideo[height<=1080][fps>=48]/best\"",
            VideoQualityType.q1080p => "-f \"bestvideo[height<=1080][fps<=32]/best\"",
            VideoQualityType.q720p60 => "-f \"bestvideo[height<=720][fps>=48]/best\"",
            VideoQualityType.q720p => "-f \"bestvideo[height<=720][fps<=32]/best\"",
            VideoQualityType.q480p => "-f \"bestvideo[height<=480]/best\"",
            VideoQualityType.q360p => "-f \"bestvideo[height<=360]/best\"",
            VideoQualityType.q240p => "-f \"bestvideo[height<=240]/best\"",
            VideoQualityType.q144p => "-f \"bestvideo[height<=144]/best\"",
            VideoQualityType.worst => "-f \"worstvideo\"",
            _ => "-f \"bestvideo\"",
        };
    }
    public static string GetVideoRecodeInfo(VideoFormatType Format) {
        return Format switch {
            VideoFormatType.avi => "--recode-video avi",
            VideoFormatType.flv => "--recode-video flv",
            VideoFormatType.mkv => "--merge-output-format mkv",
            VideoFormatType.mp4 => "--recode-video mp4",
            VideoFormatType.ogg => "--recode-video ogg",
            VideoFormatType.webm => "--merge-output-format webm",
            _ => string.Empty,
        };
    }
    public static string GetAudioFormat(AudioFormatType Format) {
        return Format switch {
            AudioFormatType.aac => "aac",
            AudioFormatType.flac => "flac",
            AudioFormatType.m4a => "m4a",
            AudioFormatType.mp3 => "mp3",
            AudioFormatType.opus => "opus",
            AudioFormatType.vorbis => "vorbis",
            AudioFormatType.wav => "wav",
            _ => "best",
        };
    }
    public static string GetAudioQuality(AudioCBRQualityType Quality) {
        return Quality switch {
            AudioCBRQualityType.q320k => "320k",
            AudioCBRQualityType.q256k => "256k",
            AudioCBRQualityType.q244k => "224k",
            AudioCBRQualityType.q192k => "192k",
            AudioCBRQualityType.q160k => "160k",
            AudioCBRQualityType.q128k => "128k",
            AudioCBRQualityType.q96k => "96k",
            AudioCBRQualityType.q64k => "64k",
            AudioCBRQualityType.q32k => "32k",
            AudioCBRQualityType.q16k => "16k",
            AudioCBRQualityType.q8k => "8k",
            AudioCBRQualityType.q4k => "4k",
            _ => "best",
        };
    }
}