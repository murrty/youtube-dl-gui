namespace youtube_dl_gui;

/// <summary>
/// Enumeration of indexes of icons based on item status.
/// </summary>
public readonly struct StatusIcon {
    /// <summary>
    /// The item is waiting to be processed.
    /// </summary>
    public static int Waiting { get; } = 0;
    /// <summary>
    /// The item is being processed.
    /// </summary>
    public static int Processing { get; } = 1;
    /// <summary>
    /// The item process has finished.
    /// </summary>
    public static int Finished { get; } = 2;
    /// <summary>
    /// The item process encountered an error.
    /// </summary>
    public static int Errored { get; } = 3;
}