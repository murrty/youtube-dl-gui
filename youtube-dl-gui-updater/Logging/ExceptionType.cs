namespace murrty.logging;
/// <summary>
/// Enum of exception types that may occur during runtime.
/// </summary>
public enum ExceptionType {
    /// <summary>
    /// An unknown exception type.
    /// </summary>
    Unknown,
    /// <summary>
    /// A successfully caught exception.
    /// </summary>
    Caught,
    /// <summary>
    /// An unhandled exception type, which will cause the application to exit.
    /// </summary>
    Unhandled,
    /// <summary>
    /// An unhandled thread exception that will allow the application to continue.
    /// </summary>
    ThreadException
}