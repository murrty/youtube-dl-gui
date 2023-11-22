#nullable enable
namespace murrty.controls;

/// <summary>
/// Represents the state of the progress bars' taskbar influence.
/// </summary>
[Flags]
public enum TaskbarProgressState {
    /// <summary>
    /// No progress is displayed in the taskbar.
    /// </summary>
    None = 0x0,
    /// <summary>
    /// Indicates the progress is indeterminate, or appears as a marquee.
    /// </summary>
    Indeterminate = 0x1,
    /// <summary>
    /// Indicates the progress is succeeding so far, or finished.
    /// </summary>
    Normal = 0x2,
    /// <summary>
    /// Indicates the progress has encountered an error.
    /// </summary>
    Error = 0x4,
    /// <summary>
    /// Indicates the progress has been haulted. Can also represent a warning during progress.
    /// </summary>
    Paused = 0x8
}