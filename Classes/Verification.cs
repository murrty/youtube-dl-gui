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

        private static volatile string YoutubeDlPathString_ = null;
        private static volatile string FFmpegPathString_ = null;
        private static volatile string AtomicParsleyPathString_ = null;
        private static volatile ProgramLocation YoutubeDlPathInt_ = ProgramLocation.Unavailable;
        private static volatile ProgramLocation FFmpegPathInt_ = ProgramLocation.Unavailable;
        private static volatile ProgramLocation AtomicParsleyInt_ = ProgramLocation.Unavailable;
        private static volatile string YoutubeDlVersionString = null;
        private static volatile GitData.GitID YoutubeDlGitType = GitData.GitID.YoutubeDlGui;

        public string YoutubeDlPath {
            get { return YoutubeDlPathString_; }
            private set { YoutubeDlPathString_ = value; }
        }
        public string SetYoutubeDLPath {
            set { YoutubeDlPathString_ = value; }
        }
        public string FFmpegPath {
            get { return FFmpegPathString_; }
            private set { FFmpegPathString_ = value; }
        }
        public string AtomicParsleyPath {
            get { return AtomicParsleyPathString_; }
            private set { AtomicParsleyPathString_ = value; }
        }
        public ProgramLocation YoutubeDlInt {
            get { return YoutubeDlPathInt_; }
            private set { YoutubeDlPathInt_ = value; }
        }
        public ProgramLocation FFmpegInt {
            get { return FFmpegPathInt_; }
            private set { FFmpegPathInt_ = value; }
        }
        public ProgramLocation AtomicParsleyInt {
            get { return AtomicParsleyInt_; }
            private set { AtomicParsleyInt_ = value; }
        }
        public string YoutubeDlVersion {
            get { return YoutubeDlVersionString; }
            private set { YoutubeDlVersionString = value; }
        }

        public void RefreshLocation() {
            RefreshYoutubeDlLocation();
            RefreshFFmpegLocation();
            RefreshAtomicParsleyLocation();
        }
        public void RefreshYoutubeDlLocation() {
            YoutubeDlInt = ytdlFullCheck();

            switch (YoutubeDlGitType) {
                case GitData.GitID.YoutubeDl:
                    switch (YoutubeDlInt) {
                        case ProgramLocation.StaticPath:
                            YoutubeDlPath = Config.Settings.General.ytdlPath;
                            break;
                        case ProgramLocation.CurrentDirectory:
                            YoutubeDlPath = Program.ProgramPath + "\\youtube-dl.exe";
                            break;
                        case ProgramLocation.SystemPATH:
                            YoutubeDlPath = ytdlPathLocation;
                            break;
                        default:
                            YoutubeDlPath = null;
                            break;
                    }
                    break;

                case GitData.GitID.YoutubeDlc:
                    switch (YoutubeDlInt) {
                        case ProgramLocation.StaticPath:
                            YoutubeDlPath = Config.Settings.General.ytdlPath;
                            break;
                        case ProgramLocation.CurrentDirectory:
                            YoutubeDlPath = Program.ProgramPath + "\\youtube-dlc.exe";
                            break;
                        case ProgramLocation.SystemPATH:
                            YoutubeDlPath = ytdlPathLocation;
                            break;
                        default:
                            YoutubeDlPath = null;
                            break;
                    }
                    break;

                case GitData.GitID.YoutubeDlp:
                    switch (YoutubeDlInt) {
                        case ProgramLocation.StaticPath:
                            YoutubeDlPath = Config.Settings.General.ytdlPath;
                            break;
                        case ProgramLocation.CurrentDirectory:
                            YoutubeDlPath = Program.ProgramPath + "\\yt-dlp.exe";
                            break;
                        case ProgramLocation.SystemPATH:
                            YoutubeDlPath = ytdlPathLocation;
                            break;
                        default:
                            YoutubeDlPath = null;
                            break;
                    }
                    break;

                default:
                    YoutubeDlPath = null;
                    break;
            }
            
            if (YoutubeDlPath != null) {
                YoutubeDlVersion = GetYtdlVersion(YoutubeDlPath);
            }
        }
        public void RefreshFFmpegLocation() {
            FFmpegInt = ffmpegFullCheck();
            switch (FFmpegInt) {
                case ProgramLocation.StaticPath:
                    FFmpegPath = Config.Settings.General.ffmpegPath;
                    break;
                case ProgramLocation.CurrentDirectory:
                    FFmpegPath = Program.ProgramPath;
                    break;
                case ProgramLocation.SystemPATH:
                    FFmpegPath = ffmpegPathLocation;
                    break;
                default:
                    FFmpegPath = null;
                    break;
            }
        }
        public void RefreshAtomicParsleyLocation() {
            AtomicParsleyInt = atomicParsleyFullCheck();
            switch (AtomicParsleyInt) {
                case ProgramLocation.CurrentDirectory:
                    AtomicParsleyPath = Program.ProgramPath + "\\atomicparsley.exe";
                    break;
                case ProgramLocation.SystemPATH:
                    AtomicParsleyPath = atomicParsleyPathLocation;
                    break;
                default:
                    AtomicParsleyPath = null;
                    break;
            }
        }

        #region youtube-dl verification
        private static string GetYtdlVersion(string Path) {
            try {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(Path);
                return fvi.ProductVersion;
            }
            catch (Exception ex) {
                ErrorLog.ReportException(ex);
                return null;
            }
        }
        private static bool ytdlInExecutingDirectory {
            get {
                switch ((GitData.GitID)Config.Settings.Downloads.YtdlType) {
                    default:
                        return File.Exists(Environment.CurrentDirectory + "\\youtube-dl.exe");

                    case GitData.GitID.YoutubeDlc:
                        return File.Exists(Environment.CurrentDirectory + "\\youtube-dlc.exe");

                    case GitData.GitID.YoutubeDlp:
                        return File.Exists(Environment.CurrentDirectory + "\\yt-dlp.exe");
                }
            }
        }
        private static string ytdlPathLocation {
            get {
                var pathValues = Environment.GetEnvironmentVariable("PATH");
                switch ((GitData.GitID)Config.Settings.Downloads.YtdlType) {
                    default:
                        foreach (var foundPath in pathValues.Split(';')) {
                            var ytdlPath = foundPath;
                            if (File.Exists(ytdlPath + "\\youtube-dl.exe"))
                                return ytdlPath + "\\youtube-dl.exe";
                        }
                        break;

                    case GitData.GitID.YoutubeDlc:
                        foreach (var foundPath in pathValues.Split(';')) {
                            var ytdlPath = foundPath;
                            if (File.Exists(ytdlPath + "\\youtube-dlc.exe"))
                                return ytdlPath + "\\youtube-dlc.exe";
                        }
                        break;

                    case GitData.GitID.YoutubeDlp:
                        foreach (var foundPath in pathValues.Split(';')) {
                            var ytdlPath = foundPath;
                            if (File.Exists(ytdlPath + "\\yt-dlp.exe"))
                                return ytdlPath + "\\yt-dlp.exe";
                        }
                        break;
                }

                return null;
            }
        }
        private static bool ytdlInSystemPath {
            get {
                string ytdlPath = ytdlPathLocation;
                switch ((GitData.GitID)Config.Settings.Downloads.YtdlType) {
                    default:
                        if (!string.IsNullOrEmpty(ytdlPath)) {
                            return File.Exists(ytdlPath + "\\youtube-dl.exe");
                        }
                        break;

                    case GitData.GitID.YoutubeDlc:
                        if (!string.IsNullOrEmpty(ytdlPath)) {
                            return File.Exists(ytdlPath + "\\youtube-dlc.exe");
                        }
                        break;

                    case GitData.GitID.YoutubeDlp:
                        if (!string.IsNullOrEmpty(ytdlPath)) {
                            return File.Exists(ytdlPath + "\\yt-dlp.exe");
                        }
                        break;
                }
                

                return false;
            }
        }

        /// <summary>
        /// Check for youtube-dl using all possible routes
        /// </summary>
        private static ProgramLocation ytdlFullCheck() {
            if (Config.Settings.General.UseStaticYtdl && File.Exists(Config.Settings.General.ytdlPath))
                return ProgramLocation.StaticPath;
            else if (ytdlInExecutingDirectory)
                return ProgramLocation.CurrentDirectory;
            else if (ytdlInSystemPath)
                return ProgramLocation.SystemPATH;
            else
                return ProgramLocation.Unavailable;
        }
        #endregion

        #region ffmpeg verification
        private static bool ffmpegInExecutingDirectory {
            get {
                if (File.Exists(Environment.CurrentDirectory + "\\ffmpeg.exe") && File.Exists(Environment.CurrentDirectory + "\\ffprobe.exe"))
                    return true;
                else
                    return false;
            }
        }

        private static string ffmpegPathLocation {
            get {
                var pathValues = Environment.GetEnvironmentVariable("PATH");
                foreach (var foundPath in pathValues.Split(';')) {
                    var ffPath = foundPath; //Path.Combine(foundPath, "ffmpeg.exe");
                    if (File.Exists(ffPath + "\\ffmpeg.exe") && File.Exists(ffPath + "\\ffprobe.exe")) {
                        return ffPath;
                    }
                }
                return null;
            }
        }
        private static bool ffmpegInSystemPath {
            get {
                string ffPath = ffmpegPathLocation;
                if (!string.IsNullOrEmpty(ffPath)) {
                    if (File.Exists(ffPath + "\\ffmpeg.exe") && File.Exists(ffPath + "\\ffprobe.exe"))
                        return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Check for ffmpeg using all possible routes
        /// </summary>
        private static ProgramLocation ffmpegFullCheck() {
            if (Config.Settings.General.UseStaticFFmpeg && File.Exists(Config.Settings.General.ffmpegPath))
                return ProgramLocation.StaticPath;
            else if (ffmpegInExecutingDirectory)
                return ProgramLocation.CurrentDirectory;
            else if (ffmpegInSystemPath)
                return ProgramLocation.SystemPATH;
            else
                return ProgramLocation.Unavailable;
        }
        #endregion

        #region atomic parsley verification
        private static bool atomicParsleyInExecutingDirectory {
            get { return File.Exists(Environment.CurrentDirectory + "\\atomicparsley.exe"); }
        }

        private static string atomicParsleyPathLocation {
            get {
                var pathValues = Environment.GetEnvironmentVariable("PATH");
                foreach (var foundPath in pathValues.Split(';')) {
                    var apPath = Path.Combine(foundPath, "atomicparsley.exe");
                    if (File.Exists(apPath)) {
                        return apPath;
                    }
                }
                return null;
            }
        }
        private static bool atomicParsleyInSystemPath {
            get {
                string apPath = atomicParsleyPathLocation;
                if (!string.IsNullOrEmpty(apPath)) {
                    return File.Exists(apPath);
                }
                return false;
            }
        }

        private static ProgramLocation atomicParsleyFullCheck() {
            if (atomicParsleyInExecutingDirectory) {
                return ProgramLocation.CurrentDirectory;
            }
            else if (atomicParsleyInSystemPath) {
                return ProgramLocation.SystemPATH;
            }
            else {
                return ProgramLocation.Unavailable;
            }
        }
        #endregion
    }
}
