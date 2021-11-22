using System;
using System.IO;
using System.Text.RegularExpressions;

namespace youtube_dl_gui {

    public sealed class DownloadInfo : IDisposable {

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public bool IsDisposed { get; private set; }
        public void Dispose(bool disposing) {
            IsDisposed = disposing;
        }

        /// <summary>
        /// The URL of the video to download.
        /// </summary>
        private string _DownloadURL = null;
        /// <summary>
        /// The arguments passed for youtube-dl
        /// </summary>
        private string _DownloadArguments = null;
        /// <summary>
        /// The status of the current download
        /// </summary>
        private DownloadStatus _Status = DownloadStatus.None;

        /// <summary>
        /// The type of the download.
        /// </summary>
        private DownloadType _Type = DownloadType.None;
        /// <summary>
        /// The quality of the video download.
        /// </summary>
        private VideoQualityType _VideoQuality = VideoQualityType.none;
        /// <summary>
        /// The format of the video download.
        /// </summary>
        private VideoFormatType _VideoFormat = VideoFormatType.none;
        /// <summary>
        /// The CBR quality of the audio download.
        /// </summary>
        private AudioCBRQualityType _AudioCBRQuality = AudioCBRQualityType.none;
        /// <summary>
        /// The VBR quality of the audio download.
        /// </summary>
        private AudioVBRQualityType _AudioVBRQuality = AudioVBRQualityType.none;
        /// <summary>
        /// the format of the audio download.
        /// </summary>
        private AudioFormatType _AudioFormat = AudioFormatType.none;
        /// <summary>
        /// The playlist selection type.
        /// </summary>
        private PlaylistSelectionType _PlaylistSelection = PlaylistSelectionType.None;

        /// <summary>
        /// Determines of the video should skip downloading the audio
        /// </summary>
        private bool _SkipAudioForVideos = true;
        /// <summary>
        /// Determines if the audio should be in VBR (Variable bit rate)
        /// </summary>
        private bool _UseVBR = false;
        /// <summary>
        /// Determines if the download is a part of a batch process.
        /// </summary>
        private bool _BatchDownload = false;
        /// <summary>
        /// The time of the batch download start.
        /// </summary>
        private string _BatchTime = null;
        /// <summary>
        /// The username for authentication.
        /// </summary>
        private string _AuthUsername = null;
        /// <summary>
        /// The password for authentication.
        /// </summary>
        private string _AuthPassword = null;
        /// <summary>
        /// The 2-factor answer for authentication.
        /// </summary>
        private string _Auth2Factor = null;
        /// <summary>
        /// The video password for authentication.
        /// </summary>
        private string _AuthVideoPassword = null;
        /// <summary>
        /// Determines if authentication should use NetRC.
        /// </summary>
        private bool _AuthNetrc = false;
        /// <summary>
        /// The arguments for playlist selection.
        /// </summary>
        private string _PlaylistSelectionArg = null;
        /// <summary>
        /// The int index of the start of the playlist.
        /// </summary>
        private int _PlaylistSelectionIndexStart = -1;
        /// <summary>
        /// The int index of the end of the playlist.
        /// </summary>
        private int _PlaylistSelectionIndexEnd = -1;

        public string DownloadURL {
            get { return _DownloadURL; }
            set { _DownloadURL = value; }
        }
        public string DownloadArguments {
            get { return _DownloadArguments; }
            set { _DownloadArguments = value; }
        }
        public DownloadStatus Status {
            get { return _Status; }
            set { _Status = value; }
        }

        public DownloadType Type {
            get { return _Type; }
            set { _Type = value; }
        }
        public VideoQualityType VideoQuality {
            get { return _VideoQuality; }
            set { _VideoQuality = value; }
        }
        public VideoFormatType VideoFormat {
            get { return _VideoFormat; }
            set { _VideoFormat = value; }
        }
        public AudioCBRQualityType AudioCBRQuality {
            get { return _AudioCBRQuality; }
            set { _AudioCBRQuality = value; }
        }
        public AudioVBRQualityType AudioVBRQuality {
            get { return _AudioVBRQuality; }
            set { _AudioVBRQuality = value; }
        }
        public AudioFormatType AudioFormat {
            get { return _AudioFormat; }
            set { _AudioFormat = value; }
        }
        public PlaylistSelectionType PlaylistSelection {
            get { return _PlaylistSelection; }
            set { _PlaylistSelection = value; }
        }

        public bool SkipAudioForVideos {
            get { return _SkipAudioForVideos; }
            set { _SkipAudioForVideos = value; }
        }
        public bool UseVBR {
            get { return _UseVBR; }
            set { _UseVBR = value; }
        }
        public bool BatchDownload {
            get { return _BatchDownload; }
            set { _BatchDownload = value; }
        }
        public string BatchTime {
            get { return _BatchTime; }
            set { _BatchTime = value; }
        }
        public string AuthUsername {
            get { return _AuthUsername; }
            set { _AuthUsername = value; }
        }
        public string AuthPassword {
            get { return _AuthPassword; }
            set { _AuthPassword = value; }
        }
        public string Auth2Factor {
            get { return _Auth2Factor; }
            set { _Auth2Factor = value; }
        }
        public string AuthVideoPassword {
            get { return _AuthVideoPassword; }
            set { _AuthVideoPassword = value; }
        }
        public bool AuthNetrc {
            get { return _AuthNetrc; }
            set { _AuthNetrc = value; }
        }
        public string PlaylistSelectionArg {
            get { return _PlaylistSelectionArg; }
            set { _PlaylistSelectionArg = value; }
        }
        public int PlaylistSelectionIndexStart {
            get { return _PlaylistSelectionIndexStart; }
            set { _PlaylistSelectionIndexStart = value; }
        }
        public int PlaylistSelectionIndexEnd {
            get { return _PlaylistSelectionIndexEnd; }
            set { _PlaylistSelectionIndexEnd = value; }
        }

    }

    #region Public Enumerations
    public enum DownloadType : int {
        None = -1,
        Video = 0,
        Audio = 1,
        Custom = 2,
        Unknown = 3
    }

    public enum VideoQualityType : int {
        none = -1,
        best = 0,
        q4320p60 = 1,
        q4320p = 2,
        q2160p60 = 3,
        q2160p = 4,
        q1440p60 = 5,
        q1440p = 6,
        q1080p60 = 7,
        q1080p = 8,
        q720p60 = 9,
        q720p = 10,
        q480p = 11,
        q360p = 12,
        q240p = 13,
        q144p = 14
    }

    public enum VideoFormatType : int {
        none = -1,
        best = 0,
        avi = 1,
        flv = 2,
        mkv = 3,
        mp4 = 4,
        ogg = 5,
        webm = 6
    }

    public enum AudioCBRQualityType : int {
        none = -1,
        best = 0,
        q320k = 1,
        q256k = 2,
        q244k = 3,
        q192k = 4,
        q160k = 5,
        q128k = 6,
        q96k = 7,
        q64k = 8,
        q32k = 9,
        q16k = 10,
        q8k = 11,
        q4k = 12
    }

    public enum AudioVBRQualityType : int {
        none = -1,
        q0 = 0,
        q1 = 1,
        q2 = 2,
        q3 = 3,
        q4 = 4,
        q5 = 5,
        q6 = 6,
        q7 = 7,
        q8 = 8,
        q9 = 9,
        q10 = 10
    }

    public enum AudioFormatType : int {
        none = -1,
        best = 0,
        aac = 1,
        flac = 2,
        mp3 = 3,
        m4a = 4,
        opus = 5,
        vorbis = 6,
        wav = 7
    }

    public enum PlaylistSelectionType : int {
        None = -1,
        PlaylistStartPlaylistEnd = 0,
        PlaylistItems = 1,
        DateBefore = 2,
        DateDuring = 3,
        DateAfter = 4
    }

    public enum DownloadStatus : int {
        None = -1,
        GeneratingArguments = 0,
        Downloading = 1,
        Finished = 2,
        Aborted = 3,
        YtdlError = 4,
        ProgramError = 5
    }
    #endregion

    public class Download {

        public static string[] ProxyProtocols = { "https://", "http://", "socks4://", "socks5://" };

        public static bool isReddit(string url) {
            if (url.IndexOf("reddit.com") == -1 && url.IndexOf("redd.it") == -1) {
                return false;
            }

            Regex Matcher = new Regex("http(s)?://(.*?(.)?)reddit.com/r/(.*?)/(comments/)?[a-zA-Z0-9]*");
            if (Matcher.IsMatch(url)) {
                return true;
            }

            Matcher = new Regex("http(s)?://(v.)?redd.it/[a-zA-Z0-9]*");
            if (Matcher.IsMatch(url)) {
                return true;
            }

            return false;
        }

        public static string getUrlBase(string url) {
            if (url.StartsWith("https://")) {
                if (url.StartsWith("https://www."))
                    url = url.Substring(12);
                else
                    url = url.Substring(8);
            }
            else if (url.StartsWith("http://")) {
                if (url.StartsWith("http://www."))
                    url = url.Substring(11);
                else
                    url = url.Substring(7);
            }
            else {
                if (url.StartsWith("www."))
                    url = url.Substring(4);
            }

            return url.Split('/')[0];
        }

        public static bool AddToHistory(string Url) {
            try {
                if (Program.UseIni) {
                    if (!File.Exists(Program.ProgramPath + "\\history.txt")) {
                        File.Create(Program.ProgramPath + "\\history.txt").Close();
                        File.WriteAllText(Program.ProgramPath + "\\history.txt", Url);
                    }
                    else {
                        File.AppendAllText(Program.LocalAppDataPath + "\\history.txt", "\r\n" + Url);
                    }

                }
                else {
                    if (!File.Exists(Program.LocalAppDataPath + "\\history.txt")) {
                        File.Create(Program.LocalAppDataPath + "\\history.txt").Close();
                        File.WriteAllText(Program.LocalAppDataPath + "\\history.txt", Url);
                    }
                    else {
                        File.AppendAllText(Program.LocalAppDataPath + "\\history.txt", "\r\n" + Url);
                    }
                }
                return true;
            }
            catch (Exception ex) {
                ErrorLog.Report(ex);
                return false;
            }
        }

        public class Formats {
            #region Arrays

            #region Video Arrays
            public static string[] VideoQualityArray = { "best",
                                                     "4320p60", "4320p", // 1
                                                     "2160p60", "2160p", // 3
                                                     "1440p60", "1440p", // 5
                                                     "1080p60", "1080p", // 7
                                                     "720p60", "720p",   // 9
                                                     "480p",
                                                     "360p",
                                                     "240p",
                                                     "144p" };
            public static string[] VideoFormatsNamesArray = { "best",
                                                          "avi",
                                                          "flv",
                                                          "mkv",
                                                          "mp4",
                                                          "ogg",
                                                          "webm"
                                                        };
            public static string[] VideoFormatsArray = { " --recode-video avi",
                                                     " --recode-video flv",
                                                     " --merge-output-format mkv",//" --recode-video mkv", //" --merge-output-format mkv",
                                                     "",//" --recode-video mp4", //" --merge-output-format mp4",
                                                     " --recode-video ogg",
                                                     " --recode-video webm" //" --merge-output-format webm"
                                                   };

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
            #endregion

            #endregion

            public static string GetVideoQualityArgs(VideoQualityType Quality) {
                switch (Quality) {
                    case VideoQualityType.q4320p60:
                        return " -f \"bestvideo[ext=mp4][height<=4320][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
                    case VideoQualityType.q4320p:
                        return " -f \"bestvideo[ext=mp4][height<=4320][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
                    case VideoQualityType.q2160p60:
                        return " -f \"bestvideo[ext=mp4][height<=2160][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
                    case VideoQualityType.q2160p:
                        return " -f \"bestvideo[ext=mp4][height<=2160][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
                    case VideoQualityType.q1440p60:
                        return " -f \"bestvideo[ext=mp4][height<=1440][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
                    case VideoQualityType.q1440p:
                        return " -f \"bestvideo[ext=mp4][height<=1440][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
                    case VideoQualityType.q1080p60:
                        return " -f \"bestvideo[ext=mp4][height<=1080][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
                    case VideoQualityType.q1080p:
                        return " -f \"bestvideo[ext=mp4][height<=1080][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
                    case VideoQualityType.q720p60:
                        return " -f \"bestvideo[ext=mp4][height<=720][fps>=48]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
                    case VideoQualityType.q720p:
                        return " -f \"bestvideo[ext=mp4][height<=720][fps<=32]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
                    case VideoQualityType.q480p:
                        return " -f \"bestvideo[ext=mp4][height<=480]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
                    case VideoQualityType.q360p:
                        return " -f \"bestvideo[ext=mp4][height<=360]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
                    case VideoQualityType.q240p:
                        return " -f \"bestvideo[ext=mp4][height<=240]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
                    case VideoQualityType.q144p:
                        return " -f \"bestvideo[ext=mp4][height<=144]+bestaudio[ext=m4a]/best[ext=mp4]/best\"";
                    default:
                        return " -f \"bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]\"";
                }
            }
            public static string GetVideoQualityArgsNoSound(VideoQualityType Quality) {
                switch (Quality) {
                    case VideoQualityType.q4320p60:
                        return " -f \"bestvideo[height<=4320][fps>=48]/best[ext=mp4]/best\"";
                    case VideoQualityType.q4320p:
                        return " -f \"bestvideo[height<=4320][fps<=32]/best[ext=mp4]/best\"";
                    case VideoQualityType.q2160p60:
                        return " -f \"bestvideo[height<=2160][fps>=48]/best[ext=mp4]/best\"";
                    case VideoQualityType.q2160p:
                        return " -f \"bestvideo[height<=2160][fps<=32]/best[ext=mp4]/best\"";
                    case VideoQualityType.q1440p60:
                        return " -f \"bestvideo[height<=1440][fps>=48]/best[ext=mp4]/best\"";
                    case VideoQualityType.q1440p:
                        return " -f \"bestvideo[height<=1440][fps<=32]/best[ext=mp4]/best\"";
                    case VideoQualityType.q1080p60:
                        return " -f \"bestvideo[height<=1080][fps>=48]/best[ext=mp4]/best\"";
                    case VideoQualityType.q1080p:
                        return " -f \"bestvideo[height<=1080][fps<=32]/best[ext=mp4]/best\"";
                    case VideoQualityType.q720p60:
                        return " -f \"bestvideo[height<=720][fps>=48]/best[ext=mp4]/best\"";
                    case VideoQualityType.q720p:
                        return " -f \"bestvideo[height<=720][fps<=32]/best[ext=mp4]/best\"";
                    case VideoQualityType.q480p:
                        return " -f \"bestvideo[height<=480]/best[ext=mp4]/best\"";
                    case VideoQualityType.q360p:
                        return " -f \"bestvideo[height<=360]/best[ext=mp4]/best\"";
                    case VideoQualityType.q240p:
                        return " -f \"bestvideo[height<=240]/best[ext=mp4]/best\"";
                    case VideoQualityType.q144p:
                        return " -f \"bestvideo[height<=144]/best[ext=mp4]/best\"";
                    default:
                        return " -f \"bestvideo[ext=mp4]/best[ext=mp4]/best\"";
                }
            }
            public static string GetVideoRecodeInfo(VideoFormatType Format) {
                switch (Format) {
                    case VideoFormatType.avi:
                        return " --recode-video avi";
                    case VideoFormatType.flv:
                        return " --recode-video flv";
                    case VideoFormatType.mkv:
                        return " --merge-output-format mkv";
                    case VideoFormatType.ogg:
                        return " --recode-video ogg";
                    case VideoFormatType.webm:
                        return " --merge-output-format webm";
                    default:
                        return string.Empty;
                }
            }
            public static string GetAudioFormat(AudioFormatType Format) {
                switch (Format) {
                    case AudioFormatType.aac:
                        return "aac";
                    case AudioFormatType.flac:
                        return "flac";
                    case AudioFormatType.m4a:
                        return "m4a";
                    case AudioFormatType.mp3:
                        return "mp3";
                    case AudioFormatType.opus:
                        return "opus";
                    case AudioFormatType.vorbis:
                        return "vorbis";
                    case AudioFormatType.wav:
                        return "wav";
                    default:
                        return "best";
                }
            }
            public static string GetAudioQuality(AudioCBRQualityType Quality) {
                switch (Quality) {
                    case AudioCBRQualityType.q320k:
                        return "320k";
                    case AudioCBRQualityType.q256k:
                        return "256k";
                    case AudioCBRQualityType.q244k:
                        return "224k";
                    case AudioCBRQualityType.q192k:
                        return "192k";
                    case AudioCBRQualityType.q160k:
                        return "160k";
                    case AudioCBRQualityType.q128k:
                        return "128k";
                    case AudioCBRQualityType.q96k:
                        return "96k";
                    case AudioCBRQualityType.q64k:
                        return "64k";
                    case AudioCBRQualityType.q32k:
                        return "32k";
                    case AudioCBRQualityType.q16k:
                        return "16k";
                    case AudioCBRQualityType.q8k:
                        return "8k";
                    case AudioCBRQualityType.q4k:
                        return "4k";
                    default:
                        return "best";
                }
            }
        }
    }

}
