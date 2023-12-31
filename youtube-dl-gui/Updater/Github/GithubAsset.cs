#nullable enable
namespace murrty.updater;

using System.Runtime.Serialization;

/// <summary>
/// Represents a structure of the data representing the version, such as the content type (x-*) and the size of the file.
/// </summary>
[DataContract]
public readonly struct GithubAsset(string Content, long Length) {
    /// <summary>
    /// Gets the content type.
    /// </summary>
    [DataMember(Name = "content_type")]
    public string Content { get; init; } = Content;

    /// <summary>
    /// Gets the size of the file.
    /// </summary>
    [DataMember(Name = "size")]
    public long Length { get; init; } = Length;

    /// <summary>
    /// Initializes an empty asset.
    /// </summary>
    public GithubAsset() : this(string.Empty, 0) { }
}