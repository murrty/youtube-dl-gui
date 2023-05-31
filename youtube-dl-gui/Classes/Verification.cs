namespace youtube_dl_gui;
using System.IO;
internal static class Verification {
    public static string YoutubeDlPath { get; private set; }
    public static string YoutubeDlVersion { get; private set; }
    public static string FFmpegPath { get; private set; }
    public static string FFprobePath { get; private set; }
    public static string MediaInfoPath { get; private set; }

    public static bool YoutubeDlAvailable => YoutubeDlPath.IsNotNullEmptyWhitespace() && File.Exists(YoutubeDlPath);
    public static bool FfmpegAvailable => FFmpegPath.IsNotNullEmptyWhitespace() && File.Exists(FFmpegPath);
    public static bool FfprobeAvailable => FFprobePath.IsNotNullEmptyWhitespace() && File.Exists(FFprobePath);
    public static bool MediaInfoAvailable => MediaInfoPath.IsNotNullEmptyWhitespace() && File.Exists(MediaInfoPath);

    public static string GetYoutubeDlProvider(bool IncludeExe) => Config.Settings.Downloads.YtdlType switch {
        (int)GitID.YoutubeDl => "youtube-dl" + (IncludeExe ? ".exe" : ""),
        (int)GitID.YoutubeDlNightly => "youtube-dl-nightly" + (IncludeExe ? ".exe" : ""),
        (int)GitID.YtDlpNightly => "yt-dlp-nightly" + (IncludeExe ? ".exe" : ""),

        _ => "yt-dlp" + (IncludeExe ? ".exe" : "")
    };
    public static int GetYoutubeDlType() => GetYoutubeDlType(null);
    /// <summary>
    /// Gets a fixed ID for a youtube-dl type. If a valid value is given, the valid type will be returned, but if an invalid id is given yt-dlp will be returned by default.
    /// </summary>
    /// <param name="CheckType">The ID of the type to verify.</param>
    /// <returns>A valid ID, if <paramref name="CheckType"/> is valid then it will be the value returned.</returns>
    public static int GetYoutubeDlType(int? CheckType) {
        int CheckId = CheckType ?? Config.Settings.Downloads.YtdlType;
        return CheckId switch {
            (int)GitID.YtDlpNightly => 1,
            (int)GitID.YoutubeDl => 2,
            (int)GitID.YoutubeDlNightly => 3,
            _ => 0,
        };
    }
    /// <summary>
    /// Returns whether downloading will most likely not produce any progress (affects Windows 7).
    /// </summary>
    public static bool YtDlpProgressProblem => Config.Settings.Downloads.LimitDownloads && (Config.Settings.Downloads.YtdlType == (int)GitID.YtDlp || Config.Settings.Downloads.YtdlType == (int)GitID.YtDlpNightly) && Environment.OSVersion.Version.Major <= 6 && Environment.OSVersion.Version.Minor <= 1;

    public static void Refresh() {
        RefreshYoutubeDlLocation();
        RefreshFFmpegLocation();
    }

    public static bool RefreshYoutubeDlLocation() {
        YoutubeDlPath = null;
        string TempPath;
        string YoutubeDlName = GetYoutubeDlProvider(true);

        if (Config.Settings.General.UseStaticYtdl && File.Exists(Config.Settings.General.ytdlPath))
            TempPath = Config.Settings.General.ytdlPath;
        else if (ProgramInExecutingDirectory(YoutubeDlName, out TempPath) || ProgramInSystemPath(YoutubeDlName, out TempPath))
            TempPath += "\\" + YoutubeDlName;
        else return false;

        if (TempPath.IsNotNullEmptyWhitespace() && File.Exists(TempPath)) {
            YoutubeDlPath = TempPath;
            YoutubeDlVersion = GetProgramVersion(YoutubeDlPath);
            return true;
        }
        
        return false;
    }
    public static bool RefreshFFmpegLocation() {
        FFmpegPath = null;
        string TempPath;
        if (Config.Settings.General.UseStaticFFmpeg && File.Exists(Config.Settings.General.ffmpegPath))
            TempPath = Config.Settings.General.ffmpegPath;
        else if (!ProgramInExecutingDirectory("ffmpeg.exe", out TempPath) && !ProgramInSystemPath("ffmpeg.exe", out TempPath))
            return false;

        if (TempPath.IsNotNullEmptyWhitespace() && Directory.Exists(TempPath) && File.Exists(TempPath + "\\ffmpeg.exe")) {
            FFmpegPath = $"{TempPath}\\ffmpeg.exe";
            string ffprobe = $"{TempPath}\\ffprobe.exe";
            if (File.Exists(ffprobe))
                FFprobePath = ffprobe;
            return true;
        }

        return false;
    }
    public static bool RefreshMediaInfoLocation() {
        MediaInfoPath = null;
        if (ProgramInExecutingDirectory("mediainfo.exe", out string TempPath) || ProgramInSystemPath("mediainfo.exe", out TempPath))
            TempPath += "\\mediainfo.exe";
        else return false;

        if (TempPath.IsNotNullEmptyWhitespace() && File.Exists(TempPath)) {
            MediaInfoPath = TempPath;
            return true;
        }

        return false;
    }

    public static string GetExpectedYoutubeDlPath() => Config.Settings.General.UseStaticYtdl ? Config.Settings.General.ytdlPath : Program.ProgramPath + "\\" + GetYoutubeDlProvider(true);
    public static string GetExpectedFfmpegPath() => Config.Settings.General.UseStaticFFmpeg ? Config.Settings.General.ffmpegPath : Program.ProgramPath + "\\ffmpeg.exe";

    private static string GetProgramVersion(string ProgramPath) {
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
    private static bool ProgramInExecutingDirectory(string ProgramName, out string OutputDir) {
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
    private static bool ProgramInSystemPath(string ProgramName, out string OutputDir) {
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