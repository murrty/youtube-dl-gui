namespace youtube_dl_gui;

/// <summary>
/// An exception that occurs when converting arguments being generated only have the output extract files instead of convert.
/// </summary>
internal class ExtractOnlyException : Exception {
    public static ExtractOnlyException Default { get; } = new();
    public ExtractOnlyException() : base("The conversions source only has files to be extracted and not converted.") { }
}