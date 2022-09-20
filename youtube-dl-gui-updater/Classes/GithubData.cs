namespace youtube_dl_gui_updater;

using System.Runtime.Serialization;
using System.Text.RegularExpressions;

[DataContract]
public sealed class GithubData {
    /// <summary>
    /// The string header of the update.
    /// </summary>
    [DataMember(Name = "name")]
    public string VersionHeader { get; init; }

    /// <summary>
    /// The full description of the update.
    /// </summary>
    [DataMember(Name = "body")]
    public string VersionDescription { get; init; }

    /// <summary>
    /// The tag of the update, which is usually the version.
    /// </summary>
    [DataMember(Name = "tag_name")]
    public string VersionTag { get; init; }

    /// <summary>
    /// Whether the version posted on Github is a pre-release.
    /// </summary>
    [DataMember(Name = "prerelease")]
    public bool VersionPreRelease { get; init; }

    /// <summary>
    /// Gets the string hash of the version (if available).
    /// </summary>
    [IgnoreDataMember]
    public string ExecutableHash { get; internal set; }

    /// <summary>
    /// Parses the update for data that may be relevant.
    /// </summary>
    internal void ParseData() {
        if (!string.IsNullOrWhiteSpace(VersionTag)) {
            ExecutableHash = FindHash();
        }
    }

    /// <summary>
    /// Tries to parse the executable hash from the version description.
    /// </summary>
    /// <param name="body">The</param>
    /// <returns></returns>
    private string FindHash() {
        if (!string.IsNullOrWhiteSpace(VersionDescription)) {
            MatchCollection Matches = Regex.Matches(VersionDescription, "(?<=exe sha-256: )[0-9a-fA-F]{64}(?=)");
            if (Matches.Count > 0) {
                return Matches[0].Value;
            }
            Matches = Regex.Matches(VersionDescription, "(?<=exe sha256: )[0-9a-fA-F]{64}(?=)");
            if (Matches.Count > 0) {
                return Matches[0].Value;
            }
            Matches = Regex.Matches(VersionDescription, "(?<=exe sha 256: )[0-9a-fA-F]{64}(?=)");
            if (Matches.Count > 0) {
                return Matches[0].Value;
            }
        }
        return null;
    }
}