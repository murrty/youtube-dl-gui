namespace youtube_dl_gui;

internal static class GithubLinks {
    public const string GithubRepoUrl           = "https://github.com/{0}/{1}";
    public const string GithubLatestJson        = "https://api.github.com/repos/{0}/{1}/releases/latest";
    public const string GithubAllReleasesJson   = "https://api.github.com/repos/{0}/{1}/releases";
    public const string ApplicationDownloadUrl  = "https://github.com/{0}/{1}/releases/download/{2}/{1}.exe";

    public static readonly string[] Users = { "yt-dlp", "ytdl-org",   "ytdl-patched", "ytdl-patched" };
    public static readonly string[] Repos = { "yt-dlp", "youtube-dl", "youtube-dl",   "yt-dlp" };
}