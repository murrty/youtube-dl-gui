#nullable enable
namespace youtube_dl_gui;
using System.Threading.Tasks;
/// <summary>
///     Delegate for when the media is parsed.
/// </summary>
/// <param name="sender">
///     The <see cref="MediaDetails"/> instance that has been parsed.
/// </param>
internal delegate void AfterMediaParse(MediaDetails sender);
/// <summary>
///     Base class for extended media details.
/// </summary>
internal abstract class MediaDetails : MediaData {
    /// <summary>
    ///     Whether the media info was parsed already.
    /// </summary>
    protected bool InfoParsed { get; set; }

    /// <summary>
    ///     Generates the base data for the instance of the derived class.
    /// </summary>
    /// <param name="Source">
    ///     The source URL, File, etc. of the media details.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     The source is null, empty, whitespace, or only contains the <see cref="BadUrlChars"/>.
    /// </exception>
    protected MediaDetails(string Source) : base(Source) { }

    /// <summary>
    ///     Parses the instance of the media details.
    /// </summary>
    protected abstract void Parse();

    /// <summary>
    ///     Retrieves the media details.
    /// </summary>
    public virtual void GetMediaDetails() {
        if (InfoParsed) {
            return;
        }

        Parse();
    }

    /// <summary>
    ///     Retrieves the media details.
    /// </summary>
    /// <param name="AfterParse">
    ///     Delegate that runs after the parse finishes.
    /// </param>
    public virtual void GetMediaDetails(AfterMediaParse? AfterParse) {
        if (InfoParsed) {
            return;
        }

        Parse();
        AfterParse?.Invoke(this);
    }

    /// <summary>
    ///     Retrieves the media details asynchronously.
    /// </summary>
    /// <returns>
    ///     A task object that represents the work queued to execute in the ThreadPool.
    /// </returns>
    public virtual async Task GetMediaDetailsAsync() {
        if (InfoParsed) {
            return;
        }

        await Task.Run(Parse);
    }

    /// <summary>
    ///     Retrieves the media details asynchronously.
    /// </summary>
    /// <param name="AfterParse">
    ///     Delegate that runs after the parse finishes.
    /// </param>
    /// <returns>
    ///     A task object that represents the work queued to execute in the ThreadPool.
    /// </returns>
    public virtual async Task GetMediaDetailsAsync(AfterMediaParse? AfterParse) {
        if (InfoParsed) {
            return;
        }

        await Task.Run(Parse);
        AfterParse?.Invoke(this);
    }

    /// <summary>
    ///     Generates the arguments for this instance and sets them in the 'Arguments' property.
    /// </summary>
    /// <returns>
    ///     <see langword="true"/> if the arguments generated successfully; otherwise, <see langword="false"/>.
    /// </returns>
    public abstract bool GenerateArguments();

    /// <summary>
    ///     Generates the arguments for this instance asynchronously and sets them in the 'Arguments' property.
    /// </summary>
    /// <returns>
    ///     A task object that represents the work queued to execute in the ThreadPool.
    ///     The return will be <see langword="true"/> if the arguments have been generated successfully; otherwise, <see langword="false"/>.
    /// </returns>
    public virtual async Task<bool> GenerateArgumentsAsync() {
        return await Task.Run(GenerateArguments);
    }
}