namespace murrty.updater;

using System.Runtime.Serialization;

/// <summary>
/// Represents a structure of the data representing the version, such as the content type (x-*) and the size of the file.
/// </summary>
[DataContract]
public struct GithubAsset {
    /// <summary>
    /// Gets the content type.
    /// </summary>
    [DataMember(Name = "content_type")]
    public string Content { get; init; }

    /// <summary>
    /// Gets the size of the file.
    /// </summary>
    [DataMember(Name = "size")]
    public long Length { get; init; }

    /// <summary>
    /// Initializes an empty asset.
    /// </summary>
    public GithubAsset() { }

    /// <summary>
    /// Initializes an asset.
    /// </summary>
    /// <param name="Content">The content type that the asset represents.</param>
    /// <param name="Size">The length (in bytes) the asset is.</param>
    public GithubAsset(string Content, long Length) {
        this.Content = Content;
        this.Length = Length;
    }
}