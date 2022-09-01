namespace youtube_dl_gui.updater;

internal static class GithubLinks {
    public const string GithubRawUrl            = "https://raw.githubusercontent.com/{0}/{1}";
    public const string GithubRepoUrl           = "https://github.com/{0}/{1}";
    public const string GithubIssuesUrl         = "https://github.com/{0}/{1}/issues";
    public const string GithubLatestJson        = "https://api.github.com/repos/{0}/{1}/releases/latest";
    public const string GithubAllReleasesJson   = "https://api.github.com/repos/{0}/{1}/releases";
    public const string ApplicationDownloadUrl  = "https://github.com/{0}/{1}/releases/download/{2}/{1}.exe";

    public static readonly string[] Users = { "ytdl-org", "blackjack4494", "yt-dlp" };
    public static readonly string[] Repos = { "youtube-dl", "youtube-dlc", "yt-dlp" };
}