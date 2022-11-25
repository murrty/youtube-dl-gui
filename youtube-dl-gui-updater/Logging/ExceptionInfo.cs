namespace murrty.logging;

/// <summary>
/// The base exception detail class containing information about the exception, and modifiers about the actions.
/// </summary>
public sealed class ExceptionInfo {
    #region Fields
    /// <summary>
    /// Gets the <see cref="System.Exception"/> object that is received.
    /// </summary>
    public Exception Exception { get; init; } = null;
    /// <summary>
    /// Gets the extra data object regarding the exception.
    /// </summary>
    public object ExtraInfo { get; init; } = null;
    /// <summary>
    /// Gets the extra data array regarding the exception.
    /// </summary>
    public object[] ExtraInfoArray { get; init; } = null;

    /// <summary>
    /// Gets the extra message that's printed before the main exception text.
    /// </summary>
    public string ExtraMessage { get; init; } = null;
    /// <summary>
    /// Gets the description that is posted to the exception form instead of one that gets parsed.
    /// </summary>
    public string CustomDescription { get; init; } = null;
    /// <summary>
    /// Gets whether the exception was caused from loading the language file. This will load internal English values.
    /// </summary>
    public bool FromLanguage { get; init; } = false;
    /// <summary>
    /// Gets whether the cause of exception can be retried.
    /// </summary>
    public bool AllowRetry { get; init; } = false;
    /// <summary>
    /// Gets the <see cref="forms.ExceptionType"/> of exception thrown.
    /// </summary>
    public ExceptionType ExceptionType { get; init; } = ExceptionType.Unknown;
    /// <summary>
    /// Gets whether the exception form should skip dwm compositing.
    /// </summary>
    public bool SkipDwmComposition { get; init; } = false;
    /// <summary>
    /// Gets the <see cref="DateTime"/> of the received exception.
    /// </summary>
    public DateTime ExceptionTime { get; init; } = default;
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of <see cref="ExceptionInfo"/>.
    /// </summary>
    /// <param name="ReceivedException">The received exception.</param>
    public ExceptionInfo(Exception ReceivedException) {
        this.Exception = ReceivedException;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ExceptionInfo"/>.
    /// </summary>
    /// <param name="ReceivedException">The received exception.</param>
    /// <param name="ExtraInfo">Extra information of the exception.</param>
    public ExceptionInfo(Exception ReceivedException, object ExtraInfo) {
        this.Exception = ReceivedException;
        this.ExtraInfo = ExtraInfo;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ExceptionInfo"/>.
    /// </summary>
    /// <param name="ReceivedException">The received exception.</param>
    /// <param name="ExtraMessage">The extra message relating to the exception.</param>
    public ExceptionInfo(Exception ReceivedException, string ExtraMessage) {
        this.Exception = ReceivedException;
        this.ExtraMessage = ExtraMessage;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ExceptionInfo"/>.
    /// </summary>
    /// <param name="ReceivedException">The received exception.</param>
    /// <param name="ExtraInfo">Extra information of the exception.</param>
    /// <param name="ExtraMessage">The extra message relating to the exception.</param>
    public ExceptionInfo(Exception ReceivedException, object ExtraInfo, string ExtraMessage) {
        this.Exception = ReceivedException;
        this.ExtraInfo = ExtraInfo;
        this.ExtraMessage = ExtraMessage;
    }
    #endregion
}