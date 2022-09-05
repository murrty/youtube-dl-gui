namespace youtube_dl_gui;

using System.IO;
using System.Text.RegularExpressions;

public sealed class DownloadInfo {
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

public class Download {

    public static readonly string[] ProxyProtocols = { "https://", "http://", "socks4://", "socks5://" };

    // The prefix for the initial regex, encompasing the connection protocol.
    internal const string RegexPrefix = @"^(http(s)?:\/\/)?";

    // From most important ... least important
    public static readonly string[] LinkRegularExpression = {
        // YouTube
        RegexPrefix + @"((www|m)\.)?(youtube\.com\/watch\?(.*?)?v=|(youtu\.be\/))[a-zA-Z0-9_-]{1,}",

        // PornHub
        RegexPrefix + @"((www|m)\.)?pornhub\.com\/view_video\.php(\?viewkey=|.*?&viewkey=)ph[a-zA-Z0-9]{1,}",

        // Reddit
        RegexPrefix + @"(([a-zA-Z]{1,}.)?reddit\.com\/r\/[a-zA-Z0-9-_]{1,}\/(comments\/)?[a-zA-Z0-9]{1,}|(i\.|v\.)?redd\.it\/[a-zA-Z0-9]{1,})",

        // Twitter
        RegexPrefix + @"(t\.co\/[a-zA-Z0-9]{1,})|(((m|mobile)\.)?twitter\.com\/(i|[a-zA-Z0-9]{1,})\/status\/[0-9]{1,})",

        // Twitch
        RegexPrefix + @"(((www|m)\.)?twitch\.tv\/((videos\/[0-9]{1,})|[a-zA-Z0-9_-]{1,}\/clip\/[a-zA-Z0-9_-]{1,})|clips\.twitch\.tv\/(clips\/)?[^clip_missing][a-zA-Z0-9_-]{1,})",
        //((www\.|m\.)?twitch.tv\/((videos\/[0-9]{1,})|[a-zA-Z0-9_-]{1,}\/clip\/[a-zA-Z0-9_-]{1,})|clips.twitch.tv\/(clips\/)?[a-zA-Z0-9_-]{1,})

        // SoundCloud
        RegexPrefix + @"((www|m)\.)?soundcloud\.com\/[a-zA-Z0-9_-]{1,}\/[a-zA-Z0-9_-]{1,}",

        // Imgur
        RegexPrefix + @"((www|m|i)\.)?imgur\.com(\/(a|gallery))?\/[a-zA-Z0-9]{1,}",

    };

    public static bool isReddit(string Url) {
        Regex Matcher = new(
            LinkRegularExpression[2],
            RegexOptions.Compiled
        );

        if (Matcher.IsMatch(Url)) {
            return true;
        }

        return false;
    }

    public static string getUrlBase(string Url) {
        if (Url.StartsWith("https://")) {
            if (Url.StartsWith("https://www."))
                Url = Url[12..];
            else
                Url = Url[8..];
        }
        else if (Url.StartsWith("http://")) {
            if (Url.StartsWith("http://www."))
                Url = Url[11..];
            else
                Url = Url[7..];
        }
        else {
            if (Url.StartsWith("www."))
                Url = Url[4..];
        }

        Url = Url.Split('/')[0];

        if (!Config.Settings.Downloads.SubdomainFolderNames) {
            if (Url.IndexOf('.') != Url.LastIndexOf('.')) {
                Url = Url[(Url.IndexOf('.') + 1)..];
            }
        }

        return Url;
    }

    public static bool AddToHistory(string Url) {
        try {
            if (!File.Exists(Program.ProgramPath + "\\history.txt")) {
                File.Create(Program.ProgramPath + "\\history.txt").Close();
                File.WriteAllText(Program.ProgramPath + "\\history.txt", Url);
            }
            else {
                File.AppendAllText(Program.LocalAppDataPath + "\\history.txt", "\r\n" + Url);
            }
            return true;
        }
        catch (Exception ex) {
            Log.ReportException(ex);
            return false;
        }
    }

    public static bool SupportedDownloadLink(string Url) {
        Regex LinkMatcher;
        for (int i = 0; i < LinkRegularExpression.Length; i++) {
            LinkMatcher = new(LinkRegularExpression[i]);
            if (LinkMatcher.IsMatch(Url)) return true;
        }
        return false;
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
                                                 "144p",
                                                 "worst" };
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
                                                      "16k",
                                                      "worst"
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

