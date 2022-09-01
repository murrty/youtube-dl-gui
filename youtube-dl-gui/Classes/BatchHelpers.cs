namespace youtube_dl_gui;

/// <summary>
/// Contains batch-process helpers
/// </summary>
public partial class BatchHelpers {

    /// <summary>
    /// Gets the current date and time in "yyyy_MM_dd-HH_mm_ss" format.
    /// </summary>
    /// <returns>The current date and time formatted.</returns>
    public static string CurrentTime {
        get => $"{DateTime.Now:yyyy_MM_dd-HH_mm_ss}";
    }
}
