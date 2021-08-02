using System;
using System.Diagnostics;
using System.IO;

namespace youtube_dl_gui {
    class Verification {

        private static volatile Verification Instance = new Verification();

        public static Verification GetInstance() { return Instance; }

        private enum ProgramLocation {
            StaticPath,
            CurrentDirectory,
            SystemPATH,
            Unavailable
        }

        private static volatile string YoutubeDlPath_ = null;
        private static volatile string FFmpegPath_ = null;
        private static volatile string AtomicParsleyPath_ = null;
        //private static volatile ProgramLocation YtdlLocation = ProgramLocation.Unavailable;
        //private static volatile ProgramLocation FFmpegLocation = ProgramLocation.Unavailable;
        //private static volatile ProgramLocation AtomicParsleyLocation = ProgramLocation.Unavailable;
        private static volatile string YtdlVersion_ = null;
        private static volatile GitData.GitID YoutubeDlGitType = GitData.GitID.YoutubeDlGui;

        public string YoutubeDlPath {
            get { return YoutubeDlPath_; }
            private set { YoutubeDlPath_ = value; }
        }
        public string SetYoutubeDLPath {
            set { YoutubeDlPath_ = value; }
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
            string TempPath = null;
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
                //YtdlLocation = ProgramLocation.StaticPath;
                TempPath = Config.Settings.General.ytdlPath;
            }
            else if (ProgramInExecutingDirectory(YoutubeDlName)) {
                //YtdlLocation = ProgramLocation.CurrentDirectory;
                TempPath = Program.ProgramPath + "\\" + YoutubeDlName;
            }
            else if (ProgramInSystemPath(YoutubeDlName, out TempPath)) {
                //YtdlLocation = ProgramLocation.SystemPATH;
            }
            else {
                //YtdlLocation = ProgramLocation.Unavailable;
            }

            YoutubeDlPath = TempPath;
            
            if (YoutubeDlPath != null) {
                YoutubeDlVersion = GetProgramVersion(YoutubeDlPath);
            }
        }
        public void RefreshFFmpegLocation() {
            string TempPath = null;

            if (Config.Settings.General.UseStaticFFmpeg && File.Exists(Config.Settings.General.ffmpegPath)) {
                //FFmpegLocation = ProgramLocation.StaticPath;
                TempPath = Config.Settings.General.ffmpegPath;
            }
            else if (ProgramInExecutingDirectory("ffmpeg.exe")) {
                //FFmpegLocation = ProgramLocation.CurrentDirectory;
                TempPath = Program.ProgramPath + "\\" + "\\ffmpeg.exe";
            }
            else if (ProgramInSystemPath("ffmpeg.exe", out TempPath)) {
                //FFmpegLocation = ProgramLocation.SystemPATH;
            }
            else {
                //FFmpegLocation = ProgramLocation.Unavailable;
            }

            FFmpegPath = TempPath;
        }
        public void RefreshAtomicParsleyLocation() {
            string TempPath = null;

            if (ProgramInExecutingDirectory("atomicparsley.exe")) {
                //AtomicParsleyLocation = ProgramLocation.CurrentDirectory;
                TempPath = Program.ProgramPath + "\\atomicparsley.exe";
            }
            else if (ProgramInSystemPath("atomicparsley.exe", out TempPath)) {
                //AtomicParsleyLocation = ProgramLocation.SystemPATH;
            }
            else {
                //AtomicParsleyLocation = ProgramLocation.Unavailable;
            }

            AtomicParsleyPath = TempPath;
        }

        #region Shared methods
        private static string GetProgramVersion(string ProgramPath) {
            try {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(ProgramPath);
                return fvi.ProductVersion;
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