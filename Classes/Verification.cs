using System;
using System.Diagnostics;
using System.IO;

namespace youtube_dl_gui {
    class Verification {

        public enum ApplicationLocation : int {
            NoneFound = -1,
            StaticDirectory = 0,
            CurrentDirectory = 1,
            SystemPath = 2,
            CommandLine = 3
        }

        #region ffmpeg verification
        public static bool ffmpegInExecutingDirectory() {
            if (File.Exists(Environment.CurrentDirectory + "\\ffmpeg.exe") && File.Exists(Environment.CurrentDirectory + "\\ffprobe.exe"))
                return true;
            else
                return false;
        }
        
        public static string ffmpegPathLocation() {
            var pathValues = Environment.GetEnvironmentVariable("PATH");
            foreach (var foundPath in pathValues.Split(';')) {
                var ffPath = foundPath; //Path.Combine(foundPath, "ffmpeg.exe");
                if (File.Exists(ffPath + "\\ffmpeg.exe") && File.Exists(ffPath + "\\ffprobe.exe"))
                    return ffPath;
            }
            return null;
        }
        public static bool ffmpegInSystemPath() {
            string ffPath = ffmpegPathLocation();
            if (!string.IsNullOrEmpty(ffPath)) {
                if (File.Exists(ffPath + "\\ffmpeg.exe") && File.Exists(ffPath + "\\ffprobe.exe"))
                    return true;
            }

            return false;
        }

        public static bool ffmpegInCmd() {
            // Very hacky, don't use
            try {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.Start();
                p.StandardInput.WriteLine("ffmpeg -version");
                p.StandardInput.Flush();
                p.StandardInput.Close();
                p.WaitForExit();

                string output = p.StandardOutput.ReadToEnd().TrimEnd('\n').TrimEnd('\r');

                if (output.EndsWith("ffmpeg -version"))
                    return false;
                else
                    return true;
            }
            catch (Exception ex){
                ErrorLog.ReportException(ex);
                return false;
            }
        }

        /// <summary>
        /// Check for ffmpeg using all possible routes
        /// </summary>
        public static int ffmpegFullCheck() {
            if (General.Default.useStaticFFmpeg && File.Exists(General.Default.ffmpegPath))
                return 0; // Static
            else if (ffmpegInExecutingDirectory())
                return 1; // Current Directory
            else if (ffmpegInSystemPath())
                return 2; // System PATH
            else if (ffmpegInCmd())
                return 3; // CMD
            else
                return -1; // None found
        }
        #endregion

        #region youtube-dl verification
        public static bool ytdlInExecutingDirectory() {
            if (File.Exists(Environment.CurrentDirectory + "\\youtube-dl.exe"))
                return true;
            else
                return false;
        }

        public static string ytdlPathLocation() {
            var pathValues = Environment.GetEnvironmentVariable("PATH");
            foreach (var foundPath in pathValues.Split(';')) {
                var ytdlPath = foundPath;
                if (File.Exists(ytdlPath + "\\youtube-dl.exe"))
                    return ytdlPath;
            }
            return null;
        }
        public static bool ytdlInSystemPath() {
            string ytdlPath = ytdlPathLocation();
            if (!string.IsNullOrEmpty(ytdlPath)) {
                if (File.Exists(ytdlPath + "\\youtube-dl.exe"))
                    return true;
            }

            return false;
        }

        public static bool ytdlInCmd() {
            // Very hacky, don't use
            try {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.Start();
                p.StandardInput.WriteLine("youtube-dl");
                p.StandardInput.Flush();
                p.StandardInput.Close();
                p.WaitForExit();

                string output = p.StandardOutput.ReadToEnd().TrimEnd('\n').TrimEnd('\r');

                if (output.EndsWith("youtube-dl")) {
                    return false;
                }
                else {
                    return true;
                }
            }
            catch (Exception ex) {
                ErrorLog.ReportException(ex);
                return false;
            }
        }

        /// <summary>
        /// Check for youtube-dl using all possible routes
        /// </summary>
        public static int ytdlFullCheck() {
            if (General.Default.useStaticYtdl && File.Exists(General.Default.ytdlPath))
                return 0; // Static
            else if (ytdlInExecutingDirectory())
                return 1; // Current Directory
            else if (ytdlInSystemPath())
                return 2; // System PATH
            else if (ytdlInCmd())
                return 3; // CMD
            else
                return -1; // None found
        }
        #endregion
    }
}
