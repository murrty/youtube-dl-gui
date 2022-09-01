namespace youtube_dl_gui.updater;

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
    /// The files associated with the update.
    /// </summary>
    [DataMember(Name = "assets")]
    public GithubAsset[] Files { get; init; }

    /// <summary>
    /// Gets whether this is a newer version of the program.
    /// </summary>
    [IgnoreDataMember]
    public bool IsNewerVersion { get; internal set; }

    /// <summary>
    /// Gets the string hash of the version (if available).
    /// </summary>
    [IgnoreDataMember]
    public string ExecutableHash { get; internal set; }

    /// <summary>
    /// Gets the <see cref="updater.Version"/> struct representation of the version.
    /// </summary>
    [IgnoreDataMember]
    public Version Version { get; internal set; }

    /// <summary>
    /// Gets whether the version is a beta version (or pre-release).
    /// </summary>
    [IgnoreDataMember]
    public bool IsBetaVersion => Version.IsBeta;

    public long GetExecutableSize() {
        if (Files.Length > 0) {
            for (int i = 0; i < Files.Length; i++) {
                if (Files[i].Content == "application/x-msdownload") {
                    return Files[i].Length;
                }
            }
        }
        return 0;
    }

    /// <summary>
    /// Parses the update for data that may be relevant.
    /// </summary>
    internal void ParseData(Version oldVersion) {
        if (!VersionTag.IsNullEmptyWhitespace() && Version.TryParse(VersionTag, out Version vers)) {
            Version = vers;
            ExecutableHash = FindHash();
            IsNewerVersion = vers > oldVersion;
        }
    }

    /// <summary>
    /// Tries to parse the executable hash from the version description.
    /// </summary>
    /// <param name="body">The</param>
    /// <returns></returns>
    private string FindHash() {
        if (!VersionDescription.IsNullEmptyWhitespace()) {
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