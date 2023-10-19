namespace murrty.updater;

using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using youtube_dl_gui;

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

    [IgnoreDataMember]
    public long ExecutableSize { get; private set; }

    /// <summary>
    /// Tries to parse the executable hash from the version description.
    /// </summary>
    /// <param name="body">The</param>
    /// <returns></returns>
    private string FindHash() {
        if (!VersionDescription.IsNullEmptyWhitespace()) {
            MatchCollection Matches = Regex.Matches(VersionDescription, "(?<=exe sha([- ])256: )(`)?[0-9a-fA-F]{64}(`)?(?=)");
            if (Matches.Count > 0) {
                return Matches[0].Value;
            }
            Matches = Regex.Matches(VersionDescription, "(?<=exe sha256: )(`)?[0-9a-fA-F]{64}(`)?(?=)");
            if (Matches.Count > 0) {
                return Matches[0].Value;
            }
        }
        return null;
    }

    [OnDeserialized]
    void Deserialized(StreamingContext ctx) {
        // Skip any that cannot be parsed by the version string.
        if (!Version.TryParse(VersionTag, out Version vers))
            return;

        Version = vers;
        IsNewerVersion = Version > Program.CurrentVersion;
        ExecutableHash = FindHash();
        ExecutableSize = 0;
        if (Files.Length > 0) {
            for (int i = 0; i < Files.Length; i++) {
                if (Files[i].Content == "application/x-msdownload") {
                    ExecutableSize = Files[i].Length;
                }
            }
        }
    }

    public static GithubData GetNewestRelease(GithubData[] Releases) {
        if (Releases.Length == 0)
            throw new NullReferenceException("The found releases were empty.");
        GithubData CurrentCheck = Releases[0];
        Version NewestVersion = Version.Empty;
        for (int i = 0; i < Releases.Length; i++) {
            Version Parse = Releases[i].Version;
            if (Parse > NewestVersion) {
                CurrentCheck = Releases[i];
                NewestVersion = Parse;
            }
        }
        return CurrentCheck;
    }

}