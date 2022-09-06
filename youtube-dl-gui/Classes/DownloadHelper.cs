namespace youtube_dl_gui;

using System.Text.RegularExpressions;

public class DownloadHelper {

    public static readonly string[] ProxyProtocols = {
        "https://",
        "http://",
        "socks4://",
        "socks5://"
    };

    // The prefix for the initial regex, encompasing the connection protocol.
    private const string RegexPrefix = @"^(http(s)?:\/\/)?";

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

    public static bool IsReddit(string Url) => Regex.IsMatch(Url, LinkRegularExpression[2], RegexOptions.Compiled);

    public static string GetUrlBase(string Url) {
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

    public static bool SupportedDownloadLink(string Url) {
        Regex LinkMatcher;
        for (int i = 0; i < LinkRegularExpression.Length; i++) {
            LinkMatcher = new(LinkRegularExpression[i], RegexOptions.Compiled);
            if (LinkMatcher.IsMatch(Url)) return true;
        }
        return false;
    }

    public static bool CanUseExtendedDownloader() {
        return Config.Settings.Downloads.YtdlType switch {
            0 or 2 => true,
            _ => false
        };
    }

}

