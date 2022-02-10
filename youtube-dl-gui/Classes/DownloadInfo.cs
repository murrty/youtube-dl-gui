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
        public string DownloadURL = null;
        /// <summary>
        /// The arguments passed for youtube-dl
        /// </summary>
        public string DownloadArguments = null;
        /// <summary>
        /// The status of the current download
        /// </summary>
        public DownloadStatus Status = DownloadStatus.None;
        /// <summary>
        /// The file-name schema of the download.
        /// </summary>
        public string FileNameSchema = null;

        /// <summary>
        /// The type of the download.
        /// </summary>
        public DownloadType Type = DownloadType.None;
        /// <summary>
        /// The quality of the video download.
        /// </summary>
        public VideoQualityType VideoQuality = VideoQualityType.none;
        /// <summary>
        /// The format of the video download.
        /// </summary>
        public VideoFormatType VideoFormat = VideoFormatType.none;
        /// <summary>
        /// The CBR quality of the audio download.
        /// </summary>
        public AudioCBRQualityType AudioCBRQuality = AudioCBRQualityType.none;
        /// <summary>
        /// The VBR quality of the audio download.
        /// </summary>
        public AudioVBRQualityType AudioVBRQuality = AudioVBRQualityType.none;
        /// <summary>
        /// the format of the audio download.
        /// </summary>
        public AudioFormatType AudioFormat = AudioFormatType.none;
        /// <summary>
        /// The playlist selection type.
        /// </summary>
        public PlaylistSelectionType PlaylistSelection = PlaylistSelectionType.None;

        /// <summary>
        /// Determines of the video should skip downloading the audio
        /// </summary>
        public bool SkipAudioForVideos = true;
        /// <summary>
        /// Determines if the audio should be in VBR (Variable bit rate)
        /// </summary>
        public bool UseVBR = false;
        /// <summary>
        /// Determines if the download is a part of a batch process.
        /// </summary>
        public bool BatchDownload = false;
        /// <summary>
        /// The time of the batch download start.
        /// </summary>
        public string BatchTime = null;
        /// <summary>
        /// The username for authentication.
        /// </summary>
        public string AuthUsername = null;
        /// <summary>
        /// The password for authentication.
        /// </summary>
        public string AuthPassword = null;
        /// <summary>
        /// The 2-factor answer for authentication.
        /// </summary>
        public string Auth2Factor = null;
        /// <summary>
        /// The video password for authentication.
        /// </summary>
        public string AuthVideoPassword = null;
        /// <summary>
        /// Determines if authentication should use NetRC.
        /// </summary>
        public bool AuthNetrc = false;
        /// <summary>
        /// The arguments for playlist selection.
        /// </summary>
        public string PlaylistSelectionArg = null;
        /// <summary>
        /// The int index of the start of the playlist.
        /// </summary>
        public int PlaylistSelectionIndexStart = -1;
        /// <summary>
        /// The int index of the end of the playlist.
        /// </summary>
        public int PlaylistSelectionIndexEnd = -1;

        public DownloadInfo() {
            FileNameSchema = Config.Settings.Downloads.fileNameSchema;
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
        q144p = 14,
        worst = 15
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

            Regex Matcher = new("(http(s)?://)?(.*?(.)?)reddit.com/r/(.*?)/(comments/)?[a-zA-Z0-9]*");
            if (Matcher.IsMatch(url)) {
                return true;
            }

            Matcher = new("(http(s)?://)?(v.)?redd.it/[a-zA-Z0-9]*");
            if (Matcher.IsMatch(url)) {
                return true;
            }

            return false;
        }

        public static string getUrlBase(string url) {
            if (url.StartsWith("https://")) {
                if (url.StartsWith("https://www."))
                    url = url[12..];
                else
                    url = url[8..];
            }
            else if (url.StartsWith("http://")) {
                if (url.StartsWith("http://www."))
                    url = url[11..];
                else
                    url = url[7..];
            }
            else {
                if (url.StartsWith("www."))
                    url = url[4..];
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
                return Quality switch {
                    VideoQualityType.q4320p60 => " -f \"bestvideo[height<=4320][fps>=48]+bestaudio/best\"",
                    VideoQualityType.q4320p => " -f \"bestvideo[height<=4320][fps<=32]+bestaudio/best\"",
                    VideoQualityType.q2160p60 => " -f \"bestvideo[height<=2160][fps>=48]+bestaudio/best\"",
                    VideoQualityType.q2160p => " -f \"bestvideo[height<=2160][fps<=32]+bestaudio/best\"",
                    VideoQualityType.q1440p60 => " -f \"bestvideo[height<=1440][fps>=48]+bestaudio/best\"",
                    VideoQualityType.q1440p => " -f \"bestvideo[height<=1440][fps<=32]+bestaudio/best\"",
                    VideoQualityType.q1080p60 => " -f \"bestvideo[height<=1080][fps>=48]+bestaudio/best\"",
                    VideoQualityType.q1080p => " -f \"bestvideo[height<=1080][fps<=32]+bestaudio/best\"",
                    VideoQualityType.q720p60 => " -f \"bestvideo[height<=720][fps>=48]+bestaudio/best\"",
                    VideoQualityType.q720p => " -f \"bestvideo[height<=720][fps<=32]+bestaudio/best\"",
                    VideoQualityType.q480p => " -f \"bestvideo[height<=480]+bestaudio/best\"",
                    VideoQualityType.q360p => " -f \"bestvideo[height<=360]+bestaudio/best\"",
                    VideoQualityType.q240p => " -f \"bestvideo[height<=240]+bestaudio/best\"",
                    VideoQualityType.q144p => " -f \"bestvideo[height<=144]+bestaudio/best\"",
                    VideoQualityType.worst => " -f \"worstvideo+worstaudio/worst\"",
                    _ => "",
                };
            }
            public static string GetVideoQualityArgsNoSound(VideoQualityType Quality) {
                return Quality switch {
                    VideoQualityType.q4320p60 => " -f \"bestvideo[height<=4320][fps>=48]/best\"",
                    VideoQualityType.q4320p => " -f \"bestvideo[height<=4320][fps<=32]/best\"",
                    VideoQualityType.q2160p60 => " -f \"bestvideo[height<=2160][fps>=48]/best\"",
                    VideoQualityType.q2160p => " -f \"bestvideo[height<=2160][fps<=32]/best\"",
                    VideoQualityType.q1440p60 => " -f \"bestvideo[height<=1440][fps>=48]/best\"",
                    VideoQualityType.q1440p => " -f \"bestvideo[height<=1440][fps<=32]/best\"",
                    VideoQualityType.q1080p60 => " -f \"bestvideo[height<=1080][fps>=48]/best\"",
                    VideoQualityType.q1080p => " -f \"bestvideo[height<=1080][fps<=32]/best\"",
                    VideoQualityType.q720p60 => " -f \"bestvideo[height<=720][fps>=48]/best\"",
                    VideoQualityType.q720p => " -f \"bestvideo[height<=720][fps<=32]/best\"",
                    VideoQualityType.q480p => " -f \"bestvideo[height<=480]/best\"",
                    VideoQualityType.q360p => " -f \"bestvideo[height<=360]/best\"",
                    VideoQualityType.q240p => " -f \"bestvideo[height<=240]/best\"",
                    VideoQualityType.q144p => " -f \"bestvideo[height<=144]/best\"",
                    VideoQualityType.worst => " -f \"worstvideo\"",
                    _ => "",
                };
            }
            public static string GetVideoRecodeInfo(VideoFormatType Format) {
                return Format switch {
                    VideoFormatType.avi => " --recode-video avi",
                    VideoFormatType.flv => " --recode-video flv",
                    VideoFormatType.mkv => " --merge-output-format mkv",
                    VideoFormatType.ogg => " --recode-video ogg",
                    VideoFormatType.webm => " --merge-output-format webm",
                    _ => string.Empty,
                };
            }
            public static string GetAudioFormat(AudioFormatType Format) {
                return Format switch {
                    AudioFormatType.aac => "aac",
                    AudioFormatType.flac => "flac",
                    AudioFormatType.m4a => "m4a",
                    AudioFormatType.mp3 => "mp3",
                    AudioFormatType.opus => "opus",
                    AudioFormatType.vorbis => "vorbis",
                    AudioFormatType.wav => "wav",
                    _ => "best",
                };
            }
            public static string GetAudioQuality(AudioCBRQualityType Quality) {
                return Quality switch {
                    AudioCBRQualityType.q320k => "320k",
                    AudioCBRQualityType.q256k => "256k",
                    AudioCBRQualityType.q244k => "224k",
                    AudioCBRQualityType.q192k => "192k",
                    AudioCBRQualityType.q160k => "160k",
                    AudioCBRQualityType.q128k => "128k",
                    AudioCBRQualityType.q96k => "96k",
                    AudioCBRQualityType.q64k => "64k",
                    AudioCBRQualityType.q32k => "32k",
                    AudioCBRQualityType.q16k => "16k",
                    AudioCBRQualityType.q8k => "8k",
                    AudioCBRQualityType.q4k => "4k",
                    _ => "best",
                };
            }
        }
    }

}
