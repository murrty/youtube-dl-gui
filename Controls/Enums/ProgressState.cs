namespace murrty.controls;

/// <summary>
/// Represents the state of the progress bar control.
/// </summary>
[Flags]
public enum ProgressState {
    /// <summary>
    /// Indicates the progress is succeeding so far, or finished.
    /// </summary>
    Normal = 0x1,
    /// <summary>
    /// Indicates the progress has encountered an error.
    /// </summary>
    Error = 0x2,
    /// <summary>
    /// Indicates the progress has been haulted. Can also represent a warning during progress.
    /// </summary>
    Paused = 0x3
}