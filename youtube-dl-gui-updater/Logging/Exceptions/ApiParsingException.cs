namespace youtube_dl_gui;

/// <summary>
/// An exception that occurs when parsing an API fails at a critical point.
/// </summary>
[Serializable]
public sealed class ApiParsingException : Exception {
    public string ApiUrl { get; set; } = "No API URL provided.";
    public ApiParsingException(string url) : base("No message has been provided.") { ApiUrl = url; }
    public ApiParsingException(string message, string url) : base(message) { ApiUrl = url; }
    public ApiParsingException(string message, string url, string extraInfo) : base(message) { ApiUrl = url; }
    public override string ToString() => base.ToString() + "\nApi URL: " + ApiUrl;

}