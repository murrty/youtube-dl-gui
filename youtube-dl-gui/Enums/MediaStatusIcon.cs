#nullable enable
namespace youtube_dl_gui;
/// <summary>
/// Represents media states.
/// </summary>
internal readonly struct MediaStatusIcon {
    /// <summary>
    /// The media is considered 'best'.
    /// </summary>
    public static int Best { get; } = 0;
    /// <summary>
    /// The media is selected.
    /// </summary>
    public static int Selected { get; } = 1;
    /// <summary>
    /// The media is considered 'best', but it is not accessible.
    /// </summary>
    public static int BestDisabled { get; } = 2;
    /// <summary>
    /// The media is selected, but it is not accesible.
    /// </summary>
    public static int SelectedDisabled { get; } = 3;
    /// <summary>
    /// The media is not selected.
    /// </summary>
    public static int NotSelected { get; } = -1;
}