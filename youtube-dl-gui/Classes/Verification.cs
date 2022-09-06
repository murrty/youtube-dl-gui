namespace youtube_dl_gui;

using System.IO;
using youtube_dl_gui.updater;

internal static class Verification {
    private static GitID YoutubeDlGitType = GitID.YoutubeDl;

    public static string YoutubeDlPath { get; private set; }
    public static string FFmpegPath { get; private set; }
    public static string FFprobePath { get; private set; }
    public static string AtomicParsleyPath { get; private set; }
    public static string YoutubeDlVersion { get; private set; }

    public static void Refresh() {
        RefreshYoutubeDlLocation();
        RefreshFFmpegLocation();
        RefreshAtomicParsleyLocation();
    }

    public static void RefreshYoutubeDlLocation() {
        YoutubeDlGitType = (GitID)Config.Settings.Downloads.YtdlType;
        string TempPath;
        string YoutubeDlName = YoutubeDlGitType switch {
            GitID.YoutubeDlc => "youtube-dlc.exe",
            GitID.YoutubeDlp => "yt-dlp.exe",
            _ => "youtube-dl.exe",
        };

        if (Config.Settings.General.UseStaticYtdl && File.Exists(Config.Settings.General.ytdlPath)) {
            TempPath = Config.Settings.General.ytdlPath;
        }
        else if (ProgramInExecutingDirectory(YoutubeDlName)) {
            TempPath = Program.ProgramPath + "\\" + YoutubeDlName;
        }
        else if (ProgramInSystemPath(YoutubeDlName, out TempPath)) { }
        else return;

        YoutubeDlPath = TempPath;
        
        if (YoutubeDlPath != null) {
            YoutubeDlVersion = GetProgramVersion(YoutubeDlPath);
            switch (YoutubeDlGitType) {
                default: //ytdl/youtube-dl {YYYY.MM.DD}
                    break;

                case GitID.YoutubeDlc: // blackjack###/youtube-dlc {YYYY.MM.DD | git.io/link}
                    YoutubeDlVersion = YoutubeDlVersion[..YoutubeDlVersion.IndexOf(" | ")];
                    //if (YoutubeDlVersion.Contains("-1 | ")) {
                    //    YoutubeDlVersion = YoutubeDlVersion[..YoutubeDlVersion.IndexOf("-1")];
                    //}
                    break;

                case GitID.YoutubeDlp: //yt-dlp/yt-dlp {YYYY.MM.DD on Python 3.8.10}
                    YoutubeDlVersion = YoutubeDlVersion[..YoutubeDlVersion.IndexOf(" on ")];
                    break;
            }
        }
    }

    public static void RefreshFFmpegLocation() {
        if (Config.Settings.General.UseStaticFFmpeg && File.Exists(Config.Settings.General.ffmpegPath)) {
            FFmpegPath = Config.Settings.General.ffmpegPath;
        }
        else if (ProgramInExecutingDirectory("ffmpeg.exe")) {
            FFmpegPath = $"{Program.ProgramPath}\\ffmpeg.exe";
        }
        else if (ProgramInSystemPath("ffmpeg.exe", out string TempPath)) {
            FFmpegPath = TempPath;
        }
        else return;

        string ffprobe = $"{Path.GetDirectoryName(FFmpegPath)}\\ffprobe.exe";
        if (File.Exists(ffprobe)) {
            FFprobePath = ffprobe;
        }
    }

    public static void RefreshAtomicParsleyLocation() {
        if (ProgramInExecutingDirectory("atomicparsley.exe")) {
            AtomicParsleyPath = $"{Program.ProgramPath}\\atomicparsley.exe";
        }
        else if (ProgramInSystemPath("atomicparsley.exe", out string TempPath)) {
            AtomicParsleyPath = TempPath;
        }
    }

    private static string GetProgramVersion(string ProgramPath) {
        try {
            return System.Diagnostics.FileVersionInfo.GetVersionInfo(ProgramPath).ProductVersion;
        }
        catch (Exception ex) {
            Log.ReportException(ex);
            return null;
        }
    }

    private static bool ProgramInExecutingDirectory(string ProgramName) {
        return File.Exists($"{Program.ProgramPath}\\{ProgramName}");
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