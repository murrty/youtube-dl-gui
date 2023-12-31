#nullable enable
namespace youtube_dl_gui;
/// <summary>
///     Represents information relating to a media object, either quick or extended.
/// </summary>
internal abstract class MediaData : IDisposable {
    /// <summary>
    ///     Bad characters that could be caught within a URL.
    /// </summary>
    protected static readonly char[] BadUrlChars = [ '\\', '"', '\n', '\r', '\t', '\0', '\b', '\'' ];
    private string? _args;

    /// <summary>
    ///     Arguments to be used by the info provider.
    ///     These are 'one-and-done', when you get the arguments this instance will be set to <see langword="null"/>.
    /// </summary>
    public string? Arguments {
        get {
            string? args = _args;
            _args = null;
            return args;
        }
        set => _args = value;
    }

    /// <summary>
    /// Gets whether this instance has been disposed.
    /// </summary>
    public bool Disposed { get; private set; }
    /// <summary>
    ///     The source of the media details.
    /// </summary>
    protected string Source { get; init; }

    /// <summary>
    ///     Generates the base data for the instance of the derived class.
    /// </summary>
    /// <param name="Source">
    ///     The source URL, File, etc. of the media.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     The source is null, empty, whitespace, or only contains the <see cref="BadUrlChars"/>.
    /// </exception>
    protected MediaData(string Source) {
        if (Source.IsNullEmptyWhitespace() || (Source = Source.Trim(BadUrlChars)).IsNullEmptyWhitespace()) {
            throw new ArgumentNullException("The source of the media details cannot be used.");
        }
        this.Source = Source;
    }

    /// <inheritdoc/>
    public void Dispose() {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    ///     Disposes the media data.
    /// </summary>
    /// <param name="disposing">
    ///     <see langword="true"/> if the instance is being disposed.
    /// </param>
    protected virtual void Dispose(bool disposing) {
        if (Disposed) {
            return;
        }
        if (disposing) {
            Disposed = true;
        }
    }
}