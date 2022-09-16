namespace youtube_dl_gui; 

internal class DownloadException : Exception {
    public string URL { get; init; }
    public DownloadException(string URL) : base("The media you are trying to access may be entered incorrectly, not be accessible at this time, or it may have been removed.") { this.URL = URL; }
    public DownloadException(string URL, string message) : base(message) { this.URL = URL; }
}