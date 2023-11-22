#nullable enable
namespace murrty.logging;
using System.Windows.Forms;
/// <summary>
/// Represents basic exception information the user received.
/// </summary>
/// <param name="ReceivedException">The received exception.</param>
internal sealed class ExceptionInfo(Exception ReceivedException) {
    #region Fields
    /// <summary>
    /// Gets the <see cref="System.Exception"/> object that is received.
    /// </summary>
    public Exception Exception { get; init; } = ReceivedException;
    /// <summary>
    /// Gets the extra data object regarding the exception.
    /// </summary>
    public object? ExtraInfo { get; init; }

    /// <summary>
    /// Gets the extra message that's printed before the main exception text.
    /// </summary>
    public string? ExtraMessage { get; init; }
    /// <summary>
    /// Gets the description that is posted to the exception form instead of one that gets parsed.
    /// </summary>
    public string? CustomDescription { get; init; }
    /// <summary>
    /// Gets whether the exception was caused from loading the language file. This will load internal English values.
    /// </summary>
    public bool FromLanguage { get; init; }
    /// <summary>
    /// Gets whether the cause of exception can be retried.
    /// </summary>
    public bool AllowRetry { get; init; }
    /// <summary>
    /// Gets whether the cause of the exception can be aborted.
    /// </summary>
    public bool AllowAbort { get; init; }
    /// <summary>
    /// Gets the <see cref="forms.ExceptionType"/> of exception thrown.
    /// </summary>
    public ExceptionType ExceptionType { get; init; } = ExceptionType.Unknown;
    /// <summary>
    /// Gets whether the exception form should skip dwm compositing.
    /// </summary>
    public bool SkipDwmComposition { get; init; }
    /// <summary>
    /// Gets the <see cref="DateTime"/> of the received exception.
    /// </summary>
    public DateTime ExceptionTime { get; init; }
    /// <summary>
    /// Gets the owner window of the exception to block input.
    /// If it is null, the exception will not block any window.
    /// </summary>
    public IWin32Window? WindowOwner { get; init; }
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of <see cref="ExceptionInfo"/>.
    /// </summary>
    /// <param name="ReceivedException">The received exception.</param>
    /// <param name="ExtraInfo">Extra information of the exception.</param>
    public ExceptionInfo(Exception ReceivedException, object? ExtraInfo)
        : this(ReceivedException) => this.ExtraInfo = ExtraInfo;

    /// <summary>
    /// Initializes a new instance of <see cref="ExceptionInfo"/>.
    /// </summary>
    /// <param name="ReceivedException">The received exception.</param>
    /// <param name="ExtraMessage">The extra message relating to the exception.</param>
    public ExceptionInfo(Exception ReceivedException, string? ExtraMessage)
        : this(ReceivedException) => this.ExtraMessage = ExtraMessage;

    /// <summary>
    /// Initializes a new instance of <see cref="ExceptionInfo"/>.
    /// </summary>
    /// <param name="ReceivedException">The received exception.</param>
    /// <param name="ExtraInfo">Extra information of the exception.</param>
    /// <param name="ExtraMessage">The extra message relating to the exception.</param>
    public ExceptionInfo(Exception ReceivedException, object? ExtraInfo, string? ExtraMessage)
        : this(ReceivedException, ExtraInfo) => this.ExtraMessage = ExtraMessage;

    public ExceptionInfo(Exception ReceivedException, object? ExtraInfo, string? ExtraMessage, IWin32Window Owner)
        : this(ReceivedException, ExtraInfo, ExtraMessage) => this.WindowOwner = Owner;
    #endregion
}