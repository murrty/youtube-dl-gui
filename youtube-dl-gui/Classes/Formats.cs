namespace youtube_dl_gui;

internal class Formats {
    /// <summary>
    /// The all files filter.
    /// </summary>
    public const string AllFiles = "All Files (*.*)|*.*";

    /// <summary>
    ///  All known video formats, as a filter.
    /// </summary>
    public const string VideoFormats = "Audio Video Interleave (*.avi)|*.avi"       + "|" +
                                       "Flash Video (*.flv)|*.flv"                  + "|" +
                                       "Matroska Video (*.mkv)|*.mkv"               + "|" +
                                       "Ogg Video (*.ogv, *ogx)|*.ogv;*.ogx"        + "|" +
                                       "QuickTime Movie (*.mov, *.qt)|*.mov;*.qt"   + "|" +
                                       "MPEG Video (*.mpeg, *.mpg)|*.mpeg;*.mpg"    + "|" +
                                       "MPEG-II Video Stream (*.m2v)|*.m2v"         + "|" +
                                       "MPEG-IV Part 14 (*.mp4)|*.mp4"              + "|" +
                                       "VP8/9 (*.webm)|*.webm"                      + "|" +
                                       "Windows Media Video (*.wmv)|*.wmv"          + "|" +
                                       AllKnownVideoFormats;

    /// <summary>
    /// All the known video formats, as a single filter.
    /// </summary>
    public const string AllKnownVideoFormats =
        "All known video formats|*.avi;*.flv;*.mkv;*.ogv;*.ogx;*.mov;*.qt;*.mpeg;*.mpg;*.m2v;*.mp4;*.webm;*.wmv";

    /// <summary>
    /// All known audio formats, as a filter.
    /// </summary>
    public const string AudioFormats = "Advanced Audo Codec (*.aac)|*.aac"                                          + "|" +
                                       "Audio Interchange File Format (*.aiff, *.aif, *.aifc)|*.aiff;*.aif;*.aifc"  + "|" +
                                       "Audio Interchange File Format Compressed (*.aifc)|*.aifc"                   + "|" +
                                       "Free Lossless Audio Codec (*.flac)|*.flac"                                  + "|" +
                                       "MPEG-4 Audio (*.m4a, *.mp4)|*.m4a;*.mp4"                                    + "|" +
                                       "MPEG-1 AudioLayer II (*.mp2)|*.mp2"                                         + "|" +
                                       "MPEG-1 AudioLayer III (*.mp3)|*.mp3"                                        + "|" +
                                       "OGG Vorbis (*.oga, *.ogg, *.opus)|*.oga;*.ogg;*.opus"                       + "|" +
                                       "Opus OGG Compressed (*.opus)|*.opus"                                        + "|" +
                                       "Waveform Audio (*.wav)|*.wav"                                               + "|" +
                                       AllKnownAudioFormats;

    /// <summary>
    /// All the known audio formats, as a single filter.
    /// </summary>
    public const string AllKnownAudioFormats =
        "All known audio formats|*.aac;*.aiff;*.aif;*.aifc;*.flac;*.m4a;*.mp4;*.mp2;*.mp3;*.oga;*.ogg;*.opus;*.wav";

    public static readonly string[] VbrQualities = new string[] {
        "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"
    };

    // Could this be replaced with video formats? Because they could contain video, but don't necessarily need to.
    /// <summary>
    /// All formats that can be either Audio or Video.
    /// </summary>
    public const string InterFormats = null;

    /// <summary>
    /// Custom formats inputted by the user.
    /// </summary>
    public static string CustomFormats;

    /// <summary>
    /// Loads the custom formats into memory.
    /// </summary>
    public static void LoadCustomFormats() {
        if (Config.Settings.General.extensionsName.Length > 0) {
            string[] Names = Config.Settings.General.extensionsName.Split('|');
            string[] Extensions = Config.Settings.General.extensionsShort.Split('|');
            int MinimumList = Math.Min(Names.Length, Extensions.Length);
            if (MinimumList > 0) {
                CustomFormats = string.Empty;
                for (int i = 0; i < MinimumList; i++) {
                    CustomFormats += $"{Names[i]} (*.{Extensions[i]})|*.{Extensions[i]}";
                }
            } else CustomFormats = null;
        }
    }

    // i dont remember what i was going to use this for.
    /// <summary>
    /// Get a filter-ready string of all known formats, including user-defined formats.
    /// </summary>
    /// <returns>A filter-ready string containing all known and user-defined formats.</returns>
    public static string GetAllKnownFormats() {
        return $"All known media formats|" +
            $"{AllKnownVideoFormats.Split('|')[1]};" +
            $"{AllKnownAudioFormats.Split('|')[1]}" +
            $"{(Config.Settings.General.extensionsShort.Length > 0 ? ";*." + Config.Settings.General.extensionsShort.Replace("|", "*.") : "")}";
    }

    /// <summary>
    /// Get a filter-ready string of formats from a array of formats. If the input array is null or empty, it returns all files.
    /// </summary>
    /// <param name="FormatsArray">The string-array of the formats to join into one filter.</param>
    /// <returns>A filter-ready string of formats.</returns>
    public static string JoinFormats(string[] FormatsArray) {
        var Formats = FormatsArray.Where(ArrayIndex => !string.IsNullOrWhiteSpace(ArrayIndex));
        return Formats.Count() > 0 ? string.Join("|", Formats) : AllFiles;
    }
}