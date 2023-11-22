#nullable enable
namespace murrty.logging;
/// <summary>
/// An exception that occurs when parsing an API fails at a critical point.
/// </summary>
[Serializable]
#pragma warning disable RCS1194 // Implement exception constructors.
public sealed class ApiParsingException : Exception {
#pragma warning restore RCS1194 // Implement exception constructors.
    public string ApiUrl { get; set; } = "No API URL provided.";
    public ApiParsingException(string url) : base("No message has been provided.") { ApiUrl = url; }
    public ApiParsingException(string message, string url) : base(message) { ApiUrl = url; }
    public override string ToString() => base.ToString() + "\nApi URL: " + ApiUrl;
}