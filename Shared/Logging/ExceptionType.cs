/// ExceptionType is a part of https://github.com/murrty/aphrodite booru downloader.
/// Licensed via GPL-3.0, if you did not receieve a license with this file; idk figure it out.
/// This code, *as-is*, should not be a part of another project; it should really only be used as reference or testing.
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