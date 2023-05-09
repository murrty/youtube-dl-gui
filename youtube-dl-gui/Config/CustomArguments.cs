namespace youtube_dl_gui;
using System.IO;

// TODO: ugh

/// <summary>
/// Manages the custom arguments the user provides.
/// </summary>
internal static class CustomArguments {

    /// <summary>
    /// Represends a list of all used youtube-dl arguments.
    /// </summary>
    public static List<string> YtdlArguments { get; } = new();

    /// <summary>
    /// Represends a list of all used ffmpeg arguments.
    /// </summary>
    public static List<string> FfmpegArguments { get; } = new();

    /// <summary>
    /// Represents the last used youtube-dl argument by the user.
    /// </summary>
    public static string LastUsedYtdlArgument { get; set; } = string.Empty;

    /// <summary>
    /// Represents the last used ffmpeg argument by the user.
    /// </summary>
    public static string LastUsedFfmpegArgument { get; set; } = string.Empty;

    public static void Load() {

    }

    public static void Save() {

    }

}