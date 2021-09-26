using System;
using System.Diagnostics;
using System.IO;

namespace youtube_dl_gui {
    class Verification {

        private static readonly Verification Instance = new Verification();

        public static Verification GetInstance() { return Instance; }

        private static volatile string YoutubeDlPath_ = null;
        private static volatile string FFmpegPath_ = null;
        private static volatile string AtomicParsleyPath_ = null;
        private static volatile string YtdlVersion_ = null;
        private static volatile GitData.GitID YoutubeDlGitType = GitData.GitID.None;

        public string YoutubeDlPath {
            get { return YoutubeDlPath_; }
            private set { YoutubeDlPath_ = value; }
        }
        public string FFmpegPath {
            get { return FFmpegPath_; }
            private set { FFmpegPath_ = value; }
        }
        public string AtomicParsleyPath {
            get { return AtomicParsleyPath_; }
            private set { AtomicParsleyPath_ = value; }
        }
        public string YoutubeDlVersion {
            get { return YtdlVersion_; }
            private set { YtdlVersion_ = value; }
        }

        public void RefreshLocation() {
            RefreshYoutubeDlLocation();
            RefreshFFmpegLocation();
            RefreshAtomicParsleyLocation();
        }

        public void RefreshYoutubeDlLocation() {
            YoutubeDlGitType = (GitData.GitID)Config.Settings.Downloads.YtdlType;
            string TempPath;
            string YoutubeDlName;

            switch (YoutubeDlGitType) {
                default:
                    YoutubeDlName = "youtube-dl.exe";
                    break;

                case GitData.GitID.YoutubeDlc:
                    YoutubeDlName = "youtube-dlc.exe";
                    break;

                case GitData.GitID.YoutubeDlp:
                    YoutubeDlName = "yt-dlp.exe";
                    break;
            }

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

                    case GitData.GitID.YoutubeDlc: // blackjack###/youtube-dlc {YYYY.MM.DD | git.io/link}
                        if (YoutubeDlVersion.Contains("-1 | ")) {
                            YoutubeDlVersion = YoutubeDlVersion.Substring(0, YoutubeDlVersion.IndexOf("-1"));
                        }
                        else {
                            YoutubeDlVersion = YoutubeDlVersion.Substring(0, YoutubeDlVersion.IndexOf(" | "));
                        }
                        break;

                    case GitData.GitID.YoutubeDlp: //yt-dlp/yt-dlp {YYYY.MM.DD on Python 3.8.10}
                        YoutubeDlVersion = YoutubeDlVersion.Substring(0, YoutubeDlVersion.IndexOf(" on "));
                        break;
                }
            }
        }
        public void RefreshFFmpegLocation() {
            string TempPath;

            if (Config.Settings.General.UseStaticFFmpeg && File.Exists(Config.Settings.General.ffmpegPath)) {
                TempPath = Config.Settings.General.ffmpegPath;
            }
            else if (ProgramInExecutingDirectory("ffmpeg.exe")) {
                TempPath = Program.ProgramPath + "\\ffmpeg.exe";
            }
            else if (ProgramInSystemPath("ffmpeg.exe", out TempPath)) { }
            else return;

            FFmpegPath = TempPath;
        }
        public void RefreshAtomicParsleyLocation() {
            string TempPath;

            if (ProgramInExecutingDirectory("atomicparsley.exe")) {
                TempPath = Program.ProgramPath + "\\atomicparsley.exe";
            }
            else if (ProgramInSystemPath("atomicparsley.exe", out TempPath)) { }
            else return;

            AtomicParsleyPath = TempPath;
        }

        #region Shared methods
        private static string GetProgramVersion(string ProgramPath) {
            try {
                return FileVersionInfo.GetVersionInfo(ProgramPath).ProductVersion;
            }
            catch (Exception ex) {
                ErrorLog.ReportException(ex);
                return null;
            }
        }

        private static bool ProgramInExecutingDirectory(string ProgramName) {
            return File.Exists(Program.ProgramPath + "\\" + ProgramName);
        }
        private static bool ProgramInSystemPath(string ProgramName, out string OutputDir) {
            string[] PathLocations = Environment.GetEnvironmentVariable("PATH").Split(';');

            for (int i = 0; i < PathLocations.Length; i++) {
                if (File.Exists(PathLocations[i] + "\\" + ProgramName)) {
                    OutputDir = PathLocations[i] + "\\" + ProgramName;
                    return true;
                }
            }

            OutputDir = null;
            return false;
        }
        #endregion
    }
}