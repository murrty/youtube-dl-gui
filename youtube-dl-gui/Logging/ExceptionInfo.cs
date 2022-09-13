namespace murrty.forms;

/// <summary>
/// The base exception detail class containing information about the exception, and modifiers about the actions.
/// </summary>
public sealed class ExceptionInfo {

    #region Fields
    /// <summary>
    /// The dynamic exception that is received.
    /// </summary>
    public dynamic ReceivedException { get; init; } = null;
    /// <summary>
    /// Extra information regarding the exception.
    /// </summary>
    public object ExtraInfo { get; init; } = null;

    /// <summary>
    /// An extra message that's printed before the main exception text.
    /// </summary>
    public string ExtraMessage { get; init; } = null;
    /// <summary>
    /// The description that is posted to the exception form instead of one that gets parsed.
    /// </summary>
    public string CustomDescription { get; init; } = null;
    /// <summary>
    /// If the exception was caused from loading the language file.
    /// </summary>
    public bool FromLanguage { get; init; } = false;
    /// <summary>
    /// If the cause of exception can be retried.
    /// </summary>
    public bool AllowRetry { get; init; } = false;
    /// <summary>
    /// If the exception is not recoverable, and the progarm must be terminated.
    /// </summary>
    public bool Unrecoverable { get; init; } = false;
    /// <summary>
    /// If the exception form should skip dwm compositing.
    /// </summary>
    public bool SkipDwmComposition { get; init; } = false;
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of <see cref="ExceptionInfo"/>.
    /// </summary>
    /// <param name="ReceivedException">The received exception.</param>
    public ExceptionInfo(dynamic ReceivedException) {
        this.ReceivedException = ReceivedException;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ExceptionInfo"/>.
    /// </summary>
    /// <param name="ReceivedException">The received exception.</param>
    /// <param name="ExtraInfo">Extra information of the exception.</param>
    public ExceptionInfo(dynamic ReceivedException, object ExtraInfo) {
        this.ReceivedException = ReceivedException;
        this.ExtraInfo = ExtraInfo;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ExceptionInfo"/>.
    /// </summary>
    /// <param name="ReceivedException">The received exception.</param>
    /// <param name="ExtraMessage">The extra message relating to the exception.</param>
    public ExceptionInfo(dynamic ReceivedException, string ExtraMessage) {
        this.ReceivedException = ReceivedException;
        this.ExtraMessage = ExtraMessage;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ExceptionInfo"/>.
    /// </summary>
    /// <param name="ReceivedException">The received exception.</param>
    /// <param name="ExtraInfo">Extra information of the exception.</param>
    /// <param name="ExtraMessage">The extra message relating to the exception.</param>
    public ExceptionInfo(dynamic ReceivedException, object ExtraInfo, string ExtraMessage) {
        this.ReceivedException = ReceivedException;
        this.ExtraInfo = ExtraInfo;
        this.ExtraMessage = ExtraMessage;
    }
    #endregion

}