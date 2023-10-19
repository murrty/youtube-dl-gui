#nullable enable
namespace youtube_dl_gui;
using System.Threading.Tasks;
/// <summary>
///     Base class for quick media info and settings.
/// </summary>
internal abstract class MediaInfo : MediaData {
    /// <summary>
    ///     Generates the base data for the instance of the derived class.
    /// </summary>
    /// <param name="Source">
    ///     The source URL, File, etc. of the media.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     The source is null, empty, whitespace, or only contains the <see cref="BadUrlChars"/>.
    /// </exception>
    protected MediaInfo(string Source) : base(Source) { }

    /// <summary>
    ///     Generates the arguments for this instance and sets them in the 'Arguments' property.
    /// </summary>
    /// <param name="VerboseReport">
    ///     Action that will be taken everytime verbosity will be reported.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if the arguments generated successfully; otherwise, <see langword="false"/>.
    /// </returns>
    public abstract bool GenerateArguments(Action<string> VerboseReport);

    /// <summary>
    ///     Generates the arguments for this instance asynchronously and sets them in the 'Arguments' property.
    /// </summary>
    /// <param name="VerboseReport">
    ///     Action that will be taken everytime verbosity will be reported.
    /// </param>
    /// <returns>
    ///     A task object that represents the work queued to execute in the ThreadPool.
    ///     The return will be <see langword="true"/> if the arguments have been generated successfully; otherwise, <see langword="false"/>.
    /// </returns>
    public virtual async Task<bool> GenerateArgumentsAsync(Action<string> VerboseReport) {
        return await Task.Run(() => GenerateArguments(VerboseReport));
    }
}