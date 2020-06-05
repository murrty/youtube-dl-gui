using System;
using System.Diagnostics;
using System.IO;

namespace youtube_dl_gui {
    class Verification {
        private static volatile Verification Instance = new Verification();
        public static Verification GetInstance() { return Instance; }

        private static volatile string YoutubeDlPathString_ = null;
        private static volatile string FFmpegPathString_ = null;
        private static volatile string AtomicParsleyPathString_ = null;
        private static volatile int YoutubeDlPathInt_ = -1;
        private static volatile int FFmpegPathInt_ = -1;
        private static volatile int AtomicParsleyInt_ = -1;
        private static volatile string YoutubeDlVersionString = null;

        public string YoutubeDlPath { get { return YoutubeDlPathString_; } private set { YoutubeDlPathString_ = value; } }
        public string FFmpegPath { get { return FFmpegPathString_; } private set { FFmpegPathString_ = value; } }
        public string AtomicParsleyPath { get { return AtomicParsleyPathString_; } private set { AtomicParsleyPathString_ = value; } }
        public int YoutubeDlInt { get { return YoutubeDlPathInt_; } private set { YoutubeDlPathInt_ = value; } }
        public int FFmpegInt { get { return FFmpegPathInt_; } private set { FFmpegPathInt_ = value; } }
        public int AtomicParsleyInt { get { return AtomicParsleyInt_; } private set { AtomicParsleyInt_ = value; } }
        public string YoutubeDlVersion { get { return YoutubeDlVersionString; } private set { YoutubeDlVersionString = value; } }

        public void RefreshLocation() {
            RefreshYoutubeDlLocation();
            RefreshFFmpegLocation();
        }
        public void RefreshYoutubeDlLocation() {
            YoutubeDlInt = ytdlFullCheck();
            switch (YoutubeDlInt) {
                case 0:
                    YoutubeDlPath = General.Default.ytdlPath;
                    break;
                case 1:
                    YoutubeDlPath = Environment.CurrentDirectory + "\\youtube-dl.exe";
                    break;
                case 2:
                    YoutubeDlPath = ytdlPathLocation;
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
                case 0:
                    FFmpegPath = General.Default.ffmpegPath;
                    break;
                case 1:
                    FFmpegPath = Environment.CurrentDirectory;
                    break;
                case 2:
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
                case 1:
                    AtomicParsleyPath = Environment.CurrentDirectory + "\\atomicparsley.exe";
                    break;
                case 2:
                    AtomicParsleyPath = atomicParsleyPathLocation;
                    break;
                default:
                    AtomicParsleyPath = null;
                    break;
            }
        }

        public static class ApplicationLocation {
            public static int NoneFound { get { return -1; } }
            public static int StaticDirectory { get { return 0; } }
            public static int CurrentDirectory { get { return 1; } }
            public static int SystemPath { get { return 2; } }
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
                return File.Exists(Environment.CurrentDirectory + "\\youtube-dl.exe");
            }
        }

        private static string ytdlPathLocation {
            get {
                var pathValues = Environment.GetEnvironmentVariable("PATH");
                foreach (var foundPath in pathValues.Split(';')) {
                    var ytdlPath = foundPath;
                    if (File.Exists(ytdlPath + "\\youtube-dl.exe"))
                        return ytdlPath + "\\youtube-dl.exe";
                }
                return null;
            }
        }
        private static bool ytdlInSystemPath {
            get {
                string ytdlPath = ytdlPathLocation;
                if (!string.IsNullOrEmpty(ytdlPath)) {
                    return File.Exists(ytdlPath + "\\youtube-dl.exe");
                }

                return false;
            }
        }

        /// <summary>
        /// Check for youtube-dl using all possible routes
        /// </summary>
        private static int ytdlFullCheck() {
            if (General.Default.UseStaticYtdl && File.Exists(General.Default.ytdlPath))
                return 0; // Static
            else if (ytdlInExecutingDirectory)
                return 1; // Current Directory
            else if (ytdlInSystemPath)
                return 2; // System PATH
            else
                return -1; // None found
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
        private static int ffmpegFullCheck() {
            if (General.Default.UseStaticFFmpeg && File.Exists(General.Default.ffmpegPath))
                return 0; // Static
            else if (ffmpegInExecutingDirectory)
                return 1; // Current Directory
            else if (ffmpegInSystemPath)
                return 2; // System PATH
            else
                return -1; // None found
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

        private static int atomicParsleyFullCheck() {
            if (atomicParsleyInExecutingDirectory) {
                return 1;
            }
            else if (atomicParsleyInSystemPath) {
                return 2;
            }
            else {
                return -1;
            }
        }
        #endregion
    }
}
