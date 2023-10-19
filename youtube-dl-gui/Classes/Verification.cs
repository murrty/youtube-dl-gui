#nullable enable
namespace youtube_dl_gui;

using System.Diagnostics.CodeAnalysis;
using System.IO;
internal static class Verification {
    public static string? YoutubeDlPath { get; private set; }
    public static string? YoutubeDlVersion { get; private set; }
    public static string? FFmpegPath { get; private set; }
    public static string? FFprobePath { get; private set; }
    public static string? MediaInfoPath { get; private set; }

    [MemberNotNullWhen(true, nameof(YoutubeDlPath))]
    public static bool YoutubeDlAvailable => !YoutubeDlPath.IsNullEmptyWhitespace() && File.Exists(YoutubeDlPath);
    [MemberNotNullWhen(true, nameof(FFmpegPath))]
    public static bool FfmpegAvailable => !FFmpegPath.IsNullEmptyWhitespace() && File.Exists(FFmpegPath);
    [MemberNotNullWhen(true, nameof(FFprobePath))]
    public static bool FfprobeAvailable => !FFprobePath.IsNullEmptyWhitespace() && File.Exists(FFprobePath);
    [MemberNotNullWhen(true, nameof(MediaInfoPath))]
    public static bool MediaInfoAvailable => !MediaInfoPath.IsNullEmptyWhitespace() && File.Exists(MediaInfoPath);

    /// <summary>
    /// Returns whether downloading will most likely not produce any progress (affects Windows 7).
    /// </summary>
    public static bool YtDlpProgressProblem {
        get {
            return Downloads.LimitDownloads
                && (Downloads.YtdlType == (int) GitID.YtDlp || Downloads.YtdlType == (int) GitID.YtDlpNightly)
                && Environment.OSVersion.Version.Major <= 6
                && Environment.OSVersion.Version.Minor <= 1;
        }
    }

    static Verification() => Refresh();

    public static string GetYoutubeDlProvider(bool IncludeExe) {
        return Downloads.YtdlType switch {
            (int)GitID.YtDlpNightly => "yt-dlp-nightly" + (IncludeExe ? ".exe" : ""),
            (int)GitID.YoutubeDl => "youtube-dl" + (IncludeExe ? ".exe" : ""),
            (int)GitID.YoutubeDlNightly => "youtube-dl-nightly" + (IncludeExe ? ".exe" : ""),

            _ => "yt-dlp" + (IncludeExe ? ".exe" : "")
        };
    }
    public static int GetYoutubeDlType() {
        return GetYoutubeDlType(null);
    }
    /// <summary>
    /// Gets a fixed ID for a youtube-dl type. If a valid value is given, the valid type will be returned, but if an invalid id is given yt-dlp will be returned by default.
    /// </summary>
    /// <param name="CheckType">The ID of the type to verify.</param>
    /// <returns>A valid ID, if <paramref name="CheckType"/> is valid then it will be the value returned.</returns>
    public static int GetYoutubeDlType(int? CheckType) {
        int CheckId = CheckType ?? Downloads.YtdlType;
        return CheckId switch {
            (int)GitID.YtDlpNightly => 1,
            (int)GitID.YoutubeDl => 2,
            (int)GitID.YoutubeDlNightly => 3,
            _ => 0,
        };
    }

    public static void Refresh() {
        RefreshYoutubeDlLocation();
        RefreshFFmpegLocation();
    }

    public static bool RefreshYoutubeDlLocation() {
        YoutubeDlPath = null;
        string? TempPath;
        string YoutubeDlName = GetYoutubeDlProvider(true);

        if (General.UseStaticYtdl && File.Exists(General.ytdlPath)) {
            TempPath = General.ytdlPath;
        }
        else if (ProgramInExecutingDirectory(YoutubeDlName, out TempPath) || ProgramInSystemPath(YoutubeDlName, out TempPath)) {
            TempPath += "\\" + YoutubeDlName;
        }
        else {
            return false;
        }

        if (!TempPath.IsNullEmptyWhitespace() && File.Exists(TempPath)) {
            YoutubeDlPath = TempPath;
            YoutubeDlVersion = GetProgramVersion(YoutubeDlPath);
            return true;
        }

        return false;
    }
    public static bool RefreshFFmpegLocation() {
        FFmpegPath = null;
        string? TempPath;
        if (General.UseStaticFFmpeg && File.Exists(General.ffmpegPath)) {
            TempPath = General.ffmpegPath;
        }
        else if (!ProgramInExecutingDirectory("ffmpeg.exe", out TempPath) && !ProgramInSystemPath("ffmpeg.exe", out TempPath)) {
            return false;
        }

        if (!TempPath.IsNullEmptyWhitespace() && Directory.Exists(TempPath) && File.Exists(TempPath + "\\ffmpeg.exe")) {
            FFmpegPath = $"{TempPath}\\ffmpeg.exe";
            string ffprobe = $"{TempPath}\\ffprobe.exe";
            if (File.Exists(ffprobe)) {
                FFprobePath = ffprobe;
            }
            return true;
        }

        return false;
    }
    public static bool RefreshMediaInfoLocation() {
        MediaInfoPath = null;
        if (ProgramInExecutingDirectory("mediainfo.exe", out string? TempPath) || ProgramInSystemPath("mediainfo.exe", out TempPath)) {
            TempPath += "\\mediainfo.exe";
        }
        else {
            return false;
        }

        if (!TempPath.IsNullEmptyWhitespace() && File.Exists(TempPath)) {
            MediaInfoPath = TempPath;
            return true;
        }

        return false;
    }

    public static string GetExpectedYoutubeDlPath() {
        return General.UseStaticYtdl ? General.ytdlPath : Program.ProgramPath + "\\" + GetYoutubeDlProvider(true);
    }
    public static string GetExpectedFfmpegPath() {
        return General.UseStaticFFmpeg ? General.ffmpegPath : Program.ProgramPath + "\\ffmpeg.exe";
    }

    private static string? GetProgramVersion(string ProgramPath) {
        try {
            return File.Exists(ProgramPath) ?
                System.Diagnostics.FileVersionInfo.GetVersionInfo(ProgramPath).FileVersion : null;
            //return System.Diagnostics.FileVersionInfo.GetVersionInfo(ProgramPath).ProductVersion;
        }
        catch (Exception ex) {
            Log.ReportException(ex);
            return null;
        }
    }
    private static bool ProgramInExecutingDirectory(string ProgramName, [NotNullWhen(true)] out string? OutputDir) {
        if (File.Exists($"{Program.ProgramPath}\\{ProgramName}")) {
            OutputDir = Program.ProgramPath;
            return true;
        }

        if (File.Exists($"{Program.ProgramPath}\\bin\\{ProgramName}")) {
            OutputDir = $"{Program.ProgramPath}\\bin";
            return true;
        }

        OutputDir = null;
        return false;
    }
    private static bool ProgramInSystemPath(string ProgramName, [NotNullWhen(true)] out string? OutputDir) {
        string[] PathLocations = Environment.GetEnvironmentVariable("PATH").Split(';');

        for (int i = 0; i < PathLocations.Length; i++) {
            if (File.Exists($"{PathLocations[i]}\\{ProgramName}")) {
                OutputDir = $"{PathLocations[i]}\\{ProgramName}";
                return true;
            }
        }

        OutputDir = null;
        return false;
    }
}