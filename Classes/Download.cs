using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace youtube_dl_gui {
    class Download {

        public class DownloadType {
            public static int Video { get { return 0; } }
            public static int Audio { get { return 1; } }
            public static int Custom { get { return 2; } }
            public static int Unknown { get { return 3; } }
            public static int Default { get { return 0; } }
        }
        public class ForceIpProtocol {
            public static int IPv4 { get { return 0; } }
            public static int IPv6 { get { return 1; } }
        }
        public class ProxyProtocol {
            public static int HTTPS { get { return 0; } }
            public static int HTTP { get { return 1; } }
            public static int SOCKS4 { get { return 2; } }
            public static int SOCKS5 { get { return 3; } }
        }

        #region constants
        public static string[] ProxyProtocols = { "https://", "http://", "socks4://", "socks5://" };
        /// <summary>
        /// Built-in video qualities
        /// </summary>
        public static string[] videoQualities = {
                                                    " -f \"bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",                // 0  best
                                                    " -f \"bestvideo[height<=4320][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 1  4320p60
                                                    " -f \"bestvideo[height<=4320][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 2  4320p30
                                                    " -f \"bestvideo[height<=2160][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 3  2160p60
                                                    " -f \"bestvideo[height<=2160][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 4  2160p30
                                                    " -f \"bestvideo[height<=1440][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 5  1440p60
                                                    " -f \"bestvideo[height<=1440][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 6  1440p30
                                                    " -f \"bestvideo[height<=1080][fps<=60]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 7  1080p60
                                                    " -f \"bestvideo[height<=1080][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 8  1080p30
                                                    " -f \"bestvideo[height<=720][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",   // 9  720p60
                                                    " -f \"bestvideo[height<=720][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",   // 10 720p30
                                                    " -f \"bestvideo[height<=480]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",            // 11 480p
                                                    " -f \"bestvideo[height<=360]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",            // 12 360p
                                                    " -f \"bestvideo[height<=240]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",            // 13 240p
                                                    " -f \"bestvideo[height<=144]+bestaudio[ext=m4a]/best[ext=mp4]/best\""             // 14 144p
                                                };
        public static string[] videoFormats = { "best",
                                                "mp4",
                                                "mkv",
                                                "flv",
                                                "webm"
                                              };
        /// <summary>
        /// Built-in audio qualities
        /// </summary>
        public static string[] audioQualities = { 
                                                    " -f bestaudio --extract-audio --audio-format best --audio-quality 0", // 0
                                                    " -x --audio-format mp3 --audio-quality 320K", // 1
                                                    " -x --audio-format mp3 --audio-quality 256K", // 2
                                                    " -x --audio-format mp3 --audio-quality 224K", // 3
                                                    " -x --audio-format mp3 --audio-quality 192K", // 4
                                                    " -x --audio-format mp3 --audio-quality 160K", // 5
                                                    " -x --audio-format mp3 --audio-quality 128K", // 6
                                                    " -x --audio-format mp3 --audio-quality 96K",  // 7
                                                    " -x --audio-format mp3 --audio-quality 64K",  // 8
                                                    " -x --audio-format mp3 --audio-quality 32K",  // 9
                                                    " -x --audio-format mp3 --audio-quality 16K",  // 10
                                                    " -x --audio-format mp3 --audio-quality 8K",   // 11
                                                    " -x --audio-format mp3 --audio-quality 4K"    // 12
                                                };
        /// <summary>
        /// The default file-name schema used
        /// </summary>
        public static string defaultSchema = "%(title)s-%(id)s.%(ext)s";
        #endregion

        public static bool isReddit(string url) {
            if (url.StartsWith("http://"))
                url = url.Replace("http://", "https://");
            if (url.StartsWith("https://www."))
                url = url.Replace("https://www.", "https://");

            if (url.StartsWith("https://redd.it") || url.StartsWith("https://reddit.com") || url.StartsWith("https://v.redd.it")) {
                return true;
            }
            else {
                return false;
            }
        }

        public static string getUrlBase(string url) {
            if (url.StartsWith("https://")) {
                if (url.StartsWith("https://www.")) url = url.Substring(12);
                else url = url.Substring(8);
            }
            else if (url.StartsWith("http://")){
                if (url.StartsWith("http://www.")) url = url.Substring(11);
                else url = url.Substring(7);
            }
            else {
                if (url.StartsWith("www.")) url = url.Substring(4);
            }

            return url.Split('/')[0];
        }
    }

    class DepreciatedArguments {
        private static string[] VideoFormatNamesArray = { "best",
                                                   "4320p60", "4320p",
                                                   "2160p60", "2160p",
                                                   "1440p60", "1440p",
                                                   "1080p60", "1080p",
                                                   "720p60", "720p",
                                                   "480p",
                                                   "360p",
                                                   "240p",
                                                   "144p" };
        private static string[] VideoFormatArgsArray = { "-f \"bestvideo+bestaudio\"",                                                  // 0
                                                     " -f \"bestvideo[height<=4320][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 1
                                                     " -f \"bestvideo[height<=4320][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 2
                                                     " -f \"bestvideo[height<=2160][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 3
                                                     " -f \"bestvideo[height<=2160][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 4
                                                     " -f \"bestvideo[height<=1440][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 5
                                                     " -f \"bestvideo[height<=1440][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 6
                                                     " -f \"bestvideo[height<=1080][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 7
                                                     " -f \"bestvideo[height<=1080][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",  // 8
                                                     " -f \"bestvideo[height<=720][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",   // 9
                                                     " -f \"bestvideo[height<=720][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",   // 10
                                                     " -f \"bestvideo[height<=480]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",            // 11
                                                     " -f \"bestvideo[height<=360]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",            // 12
                                                     " -f \"bestvideo[height<=240]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",            // 13
                                                     " -f \"bestvideo[height<=144]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",            // 14
                                                     " -f \"bestvideo[height<={0}]{1}+bestaudio\""
                                                   };

        #region Old Video Arrays
        private string[] VideoFormatArgsArrayOld = { " -f \"bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                     " -f \"bestvideo[height<=4320][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                     " -f \"bestvideo[height<=4320][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                     " -f \"bestvideo[height<=2160][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                     " -f \"bestvideo[height<=2160][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                     " -f \"bestvideo[height<=1440][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                     " -f \"bestvideo[height<=1440][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                     " -f \"bestvideo[height<=1080][fps<=60]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                     " -f \"bestvideo[height<=1080][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                     " -f \"bestvideo[height<=720][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                     " -f \"bestvideo[height<=720][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                     " -f \"bestvideo[height<=480]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                     " -f \"bestvideo[height<=360]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                     " -f \"bestvideo[height<=240]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                     " -f \"bestvideo[height<=144]+bestaudio[ext=m4a]/best[ext=mp4]/best\""
                                                   };
        #endregion
    }

    class DownloadFormats {
        #region Arrays

        #region Video Arrays

        public static string[] VideoArgs = { " -f \"bestvideo+bestaudio/best[ext=mp4]/best\"", " -f \"bestvideo[height<={0}]{1}+bestaudio/best[ext=mp4]/best\"" };
        public static string[] VideoArgsNoSound = { " -f \"bestvideo/best[ext=mp4]/best\"", " -f \"bestvideo[height<={0}]{1}/best[ext=mp4]/best\"" };
        public static string[] VideoResolutionsArray = { "best", "4320", "2160", "1440", "1080", "720", "480", "360", "240", "144" };
        public static string[] VideoFPSArray = { "[fps<=32]", "[fps>=48]" };
        public static string[] VideoFormatsArrayOld = { "avi", "flv", "mkv", "mp4", "ogg" };//, "webm" };
        public static string[] VideoQualityArray = { "best",
                                                     "4320p60", "4320p", // 1
                                                     "2160p60", "2160p", // 3
                                                     "1440p60", "1440p", // 5
                                                     "1080p60", "1080p", // 7
                                                     "720p60", "720p", // 9
                                                     "480p",
                                                     "360p",
                                                     "240p",
                                                     "144p" };
        public static string[] VideoFormatsNamesArray = { "best",
                                                          "avi",
                                                          "flv",
                                                          "mkv",
                                                          "mp4",
                                                          "ogg"
                                                          //"webm"
                                                        };
        public static string[] VideoFormatsArray = { " --recode-video avi",
                                                     " --recode-video flv",
                                                     " --merge-output-format mkv",//" --recode-video mkv", //" --merge-output-format mkv",
                                                     "",//" --recode-video mp4", //" --merge-output-format mp4",
                                                     " --recode-video ogg",
                                                     " --merge-output-format webm"//" --recode-video webm" //" --merge-output-format webm"
                                                   };

        public static string[] VideoFormatArgsArrayOld = { " -f \"bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]\"",
                                                            " -f \"bestvideo[ext=mp4][height<=4320][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                            " -f \"bestvideo[ext=mp4][height<=4320][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                            " -f \"bestvideo[ext=mp4][height<=2160][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                            " -f \"bestvideo[ext=mp4][height<=2160][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                            " -f \"bestvideo[ext=mp4][height<=1440][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                            " -f \"bestvideo[ext=mp4][height<=1440][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                            " -f \"bestvideo[ext=mp4][height<=1080][fps<=60]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                            " -f \"bestvideo[ext=mp4][height<=1080][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                            " -f \"bestvideo[ext=mp4][height<=720][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                            " -f \"bestvideo[ext=mp4][height<=720][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                            " -f \"bestvideo[ext=mp4][height<=480]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                            " -f \"bestvideo[ext=mp4][height<=360]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                            " -f \"bestvideo[ext=mp4][height<=240]+bestaudio[ext=m4a]/best[ext=mp4]/best\"",
                                                            " -f \"bestvideo[ext=mp4][height<=144]+bestaudio[ext=m4a]/best[ext=mp4]/best\""
                                                          };
        public static string[] VideoFormatArgsArrayNoSoundOld = { " -f \"bestvideo[ext=mp4]/best[ext=mp4]/best\"",
                                                                   " -f \"bestvideo[height<=4320][fps>=48]/best[ext=mp4]/best\"",
                                                                   " -f \"bestvideo[height<=4320][fps<=32]/best[ext=mp4]/best\"",
                                                                   " -f \"bestvideo[height<=2160][fps>=48]/best[ext=mp4]/best\"",
                                                                   " -f \"bestvideo[height<=2160][fps<=32]/best[ext=mp4]/best\"",
                                                                   " -f \"bestvideo[height<=1440][fps>=48]/best[ext=mp4]/best\"",
                                                                   " -f \"bestvideo[height<=1440][fps<=32]/best[ext=mp4]/best\"",
                                                                   " -f \"bestvideo[height<=1080][fps<=60]/best[ext=mp4]/best\"",
                                                                   " -f \"bestvideo[height<=1080][fps<=32]/best[ext=mp4]/best\"",
                                                                   " -f \"bestvideo[height<=720][fps>=48]/best[ext=mp4]/best\"",
                                                                   " -f \"bestvideo[height<=720][fps<=32]/best[ext=mp4]/best\"",
                                                                   " -f \"bestvideo[height<=480]/best[ext=mp4]/best\"",
                                                                   " -f \"bestvideo[height<=360]/best[ext=mp4]/best\"",
                                                                   " -f \"bestvideo[height<=240]/best[ext=mp4]/best\"",
                                                                   " -f \"bestvideo[height<=144]/best[ext=mp4]/best\""
                                                                 };


        private string OldBestVideo = " -f \"bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
        //mp4|flv|ogg|webm|mkv|avi

        #endregion

        #region Audio Arrays
        public static string[] AudioQualityNamesArray = { "best",
                                                          "320k",
                                                          "256k",
                                                          "224k",
                                                          "192k",
                                                          "160k",
                                                          "128k",
                                                          "96k",
                                                          "64k",
                                                          "32k",
                                                          "16k"
                                                  };
        public static string[] AudioFormatsArray = { "best",
                                                     "aac",
                                                     "flac",
                                                     "mp3",
                                                     "m4a",
                                                     "opus",
                                                     "vorbis",
                                                     "wav"
                                                 };
        private string[] AudioFormatArgsArray = { " -f  -x --audio-format best --audio-quality 0" };

        private string OldBestAudioArg = " -f bestaudio --extract-audio --audio-format best --audio-quality 0";
        #endregion

        #endregion

        public static string GetVideoFormatArgs(int Quality = 0, bool Set60FPS = false) {
            return VideoFormatArgsArrayOld[Quality];
            //if (Quality == 0) {
            //    return string.Format(VideoArgs[0]);
            //}
            //else {
            //    if (Set60FPS) {
            //        return string.Format(VideoArgs[1], VideoQualityArray[Quality].Replace("p60","").Replace("p",""), VideoFPSArray[1]);
            //    }
            //    else {
            //        return string.Format(VideoArgs[1], VideoQualityArray[Quality].Replace("p60", "").Replace("p",""), VideoFPSArray[0]);
            //    }
            //}
        }
        public static string GetVideoFormatArgsNoSound(int Quality = 0, bool Set60FPS = false) {
            return VideoFormatArgsArrayNoSoundOld[Quality];
            //if (Quality == 0) {
            //    return string.Format(VideoArgsNoSound[0]);
            //}
            //else {
            //    if (Set60FPS) {
            //        return string.Format(VideoArgsNoSound[1], VideoQualityArray[Quality].Replace("p60", "").Replace("p", ""), VideoFPSArray[1]);
            //    }
            //    else {
            //        return string.Format(VideoArgsNoSound[1], VideoQualityArray[Quality].Replace("p60", "").Replace("p", ""), VideoFPSArray[0]);
            //    }
            //}
        }
    }
}
