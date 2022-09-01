namespace youtube_dl_gui;

/// <summary>
/// Enumeration of indexes of icons based on item status.
/// </summary>
public enum StatusIcon : int {
    /// <summary>
    /// The item is waiting to be processed.
    /// </summary>
    Waiting = 0,
    /// <summary>
    /// The item is being processed.
    /// </summary>
    Processing = 1,
    /// <summary>
    /// The item process has finished.
    /// </summary>
    Finished = 2,
    /// <summary>
    /// The item process encountered an error.
    /// </summary>
    Errored = 3
}