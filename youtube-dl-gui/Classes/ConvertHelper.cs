#nullable enable
namespace youtube_dl_gui;
internal static class ConvertHelper {
    /// <summary>
    /// Gets a preset name in the built-in presets
    /// </summary>
    /// <param name="index">Index of the preset that was requested</param>
    /// <returns>The preset string</returns>
    public static string GetVideoPreset(int index) {
        return index switch {
            0 => "ultrafast",
            1 => "superfast",
            2 => "veryfast",
            3 => "faster",
            4 => "fast",
            6 => "slow",
            7 => "slower",
            8 => "veryslow",
            _ => "medium",
        };
    }

    /// <summary>
    /// Gets a profile name in the built-in profiles
    /// </summary>
    /// <param name="index">Index of the profile that was requested</param>
    /// <returns>The profile string</returns>
    public static string GetVideoProfile(int index) {
        return index switch {
            0 => "baseline",
            2 => "high",
            3 => "high10",
            4 => "high442",
            5 => "high444",
            _ => "main",
        };
    }

    /// <summary>
    /// Detects the file-type of the file
    /// </summary>
    /// <param name="InputFile">The file to test</param>
    /// <returns>An int of the file type; video, audio, and default</returns>
    public static ConversionType GetFiletype(string InputFile) {
        string[] File = InputFile.Split('.');
        if (File.Length > 0) {
            string Format = File[^1];
            return Formats.VideoFormats.Contains(Format) ? ConversionType.Video : (Formats.AudioFormats.Contains(Format) ? ConversionType.Audio : ConversionType.FfmpegDefault);
        }
        return ConversionType.FfmpegDefault;
    }
}