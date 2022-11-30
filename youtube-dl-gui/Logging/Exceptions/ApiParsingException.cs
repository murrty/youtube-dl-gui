namespace youtube_dl_gui;

/// <summary>
/// An exception that occurs when parsing an API fails at a critical point.
/// </summary>
[Serializable]
public sealed class ApiParsingException : Exception {
    public string ApiUrl { get; } = null;
    public ApiParsingException(string url) : base("No message has been provided.") { ApiUrl = url; }
    public ApiParsingException(string message, string url) : base(message) { ApiUrl = url; }
    public override string ToString() => base.ToString() + (ApiUrl is not null ? ($"\nApi URL: {ApiUrl}") : "");

}