namespace youtube_dl_gui;
using System.IO;
internal static class Verification {
    private static GitID YoutubeDlGitType = GitID.YtDlp;

    public static string YoutubeDlPath { get; private set; }
    public static string YoutubeDlVersion { get; private set; }
    public static string FFmpegPath { get; private set; }
    public static string FFprobePath { get; private set; }
    public static string MediaInfoPath { get; private set; }

    public static bool YoutubeDlAvailable => YoutubeDlPath.IsNotNullEmptyWhitespace() && File.Exists(YoutubeDlPath);
    public static bool FfmpegAvailable => FFmpegPath.IsNotNullEmptyWhitespace() && File.Exists(FFmpegPath);
    public static bool FfprobeAvailable => FFprobePath.IsNotNullEmptyWhitespace() && File.Exists(FFprobePath);
    public static bool MediaInfoAvailable => false;

    public static string YoutubeDlProvider => Config.Settings.Downloads.YtdlType switch {
        1 => "youtube-dl",
        2 => "youtube-dl-patch",
        3 => "yt-dlp-patch",

        _ => "yt-dlp"
    };
    public static int YoutubeDlType => Config.Settings.Downloads.YtdlType switch {
        1 => 1,
        2 => 2,
        3 => 3,

        _ => 0
    };

    public static void Refresh() {
        RefreshYoutubeDlLocation();
        RefreshFFmpegLocation();
    }

    public static bool RefreshYoutubeDlLocation() {
        YoutubeDlGitType = (GitID)YoutubeDlType;
        string TempPath;
        string YoutubeDlName = YoutubeDlGitType switch {
            GitID.YoutubeDl => "youtube-dl.exe",
            GitID.YoutubeDlNightly => "youtube-dl-n.exe",
            GitID.YtDlpNightly => "yt-dlp-n.exe",
            _ => "yt-dlp.exe",
        };

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
        if (ProgramInExecutingDirectory("mediainfo.exe", out string TempPath) || ProgramInSystemPath("mediainfo.exe", out TempPath))
            TempPath += "mediainfo.exe";
        else return false;

        if (TempPath.IsNotNullEmptyWhitespace() && File.Exists(TempPath)) {
            MediaInfoPath = TempPath;
            return true;
        }

        return false;
    }

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