#define ALLOWUNHANDLEDCATCHING
namespace murrty.logging;
using System.Diagnostics;
using System.Management;
using System.Threading;
using System.Windows.Forms;
using youtube_dl_gui;
using WinMsg = System.Windows.Forms.MessageBox;
/// <summary>
/// This class will control the Errors that get reported in try statements.
/// </summary>
internal static class Log {

    #region Properties & Fields
    /// <summary>
    /// The log form that is used globally to log data.
    /// </summary>
    private static volatile frmLog LogForm = null;

    /// <summary>
    /// Gets the computer versioning information, such as the running operating system, language, etc.
    /// </summary>
    public static string ComputerVersionInformation {
        get; private set;
    } = $"{nameof(ComputerVersionInformation)} not initialized.";

    /// <summary>
    /// Gets whether the log is enabled.
    /// </summary>
    public static bool LogEnabled { get; private set; } = false;

    /// <summary>
    /// Gets or sets whether the log will write to file.
    /// </summary>
    public static bool AllowWritingToFile { get; set; } = false;

    /// <summary>
    /// Gets whether logging is enabled and the log form is created and not disposed.
    /// </summary>
    public static bool LogFormUsable => LogEnabled && LogForm is not null && !LogForm.IsDisposed;

    /// <summary>
    /// Gets whether whether logging is enabled, the log form is not null, or the log form is not disposed.
    /// </summary>
    public static bool LogFormEnabled => LogEnabled || LogForm is not null || !LogForm.IsDisposed;
    #endregion

    #region Log stuff
    /// <summary>
    /// Initializer
    /// </summary>
    static Log() {
        // Catch any exceptions that are unhandled, so we can report it.
#if RELEASE && ALLOWUNHANDLEDCATCHING
        try {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
#endif

            EnableLogging();

#if RELEASE && ALLOWUNHANDLEDCATCHING
            Write("Creating unhandled exception event.");
            AppDomain.CurrentDomain.UnhandledException += (sender, exception) => {
                Exception ExceptionRef = exception.ExceptionObject is Exception ex ?
                    ex : new ApplicationException("An unhandled exception occurred, but the exception object is not an exception type.");

                ExceptionInfo NewException = new(ExceptionRef) {
                    ExceptionTime = DateTime.Now,
                    ExceptionType = exception.IsTerminating ? ExceptionType.Unhandled : ExceptionType.Caught,
                    AllowRetry = false
                };
                AddExceptionToLog(NewException);
                using frmException ExceptionDisplay = new(NewException);
                ExceptionDisplay.ShowDialog();
            };

            Write("Creating unhandled thread exception event.");
            Application.ThreadException += (sender, exception) => {
                ExceptionInfo NewException = new(exception.Exception) {
                    ExceptionTime = DateTime.Now,
                    ExceptionType = ExceptionType.ThreadException,
                    AllowRetry = false
                };
                AddExceptionToLog(NewException);
                using frmException ExceptionDisplay = new(NewException);
                ExceptionDisplay.ShowDialog();
            };
        }
        catch (Exception ex) {
            ReportException(ex);
        }
#endif

        // Build up a string containing relevant information about the computer.
        Write("Creating ComputerVersionInformation for exceptions.");
        ManagementObjectSearcher MgtSearcher = new("SELECT * FROM Win32_OperatingSystem");
        ManagementObject MgtInfo = MgtSearcher?.Get().Cast<ManagementObject>().FirstOrDefault();
        ComputerVersionInformation = $$"""
            Current Version: {{Program.CurrentVersion}}
            Current Culture: {{Thread.CurrentThread.CurrentCulture.EnglishName}}
            """ + "\n" + (MgtInfo is null ? "The ManagementObject for Win32_OperatingSystem is null and cannot be used." : $$"""
            System Caption: {{MgtInfo.Properties["Caption"].Value ?? "couldn't query"}}
            System Version: {{MgtInfo.Properties["Version"].Value ?? "couldn't query"}}
            Service Pack Major: {{MgtInfo.Properties["ServicePackMajorVersion"].Value ?? "couldn't query"}}
            Service Pack Minor: {{MgtInfo.Properties["ServicePackMinorVersion"].Value ?? "couldn't query"}}
            """);

    }

    /// <summary>
    /// Enables the logging form.
    /// </summary>
    //[DebuggerStepThrough]
    public static void EnableLogging() {
        if (LogFormUsable) {
            Write("Logging is already enabled.");
        }
        else {
            LogForm = new();
            LogEnabled = true;
            Write("Logging has been enabled.");
        }
    }

    /// <summary>
    /// Disables the logging form, but debug logging will still occur.
    /// </summary>
    //[DebuggerStepThrough]
    public static void DisableLogging() {
        if (LogFormEnabled) {
            if (LogForm is not null) {
                if (!LogForm.IsDisposed && (LogForm.WindowState == FormWindowState.Minimized || LogForm.WindowState == FormWindowState.Maximized)) {
                    LogForm.Opacity = 0;
                    LogForm.WindowState = FormWindowState.Normal;

                    Saved.LogLocation = LogForm.Location;
                    Saved.LogSize = LogForm.Size;
                    LogForm.Dispose();
                }
            }

            LogForm = null;
        }
        LogEnabled = false;
    }

    /// <summary>
    /// Shows the log form.
    /// </summary>
    //[DebuggerStepThrough]
    internal static void ShowLog() {
        if (LogFormUsable)
            LogForm.ShowLog();
    }

    /// <summary>
    /// Hides the log form.
    /// </summary>
    //[DebuggerStepThrough]
    internal static void HideLog() {
        if (LogFormUsable)
            LogForm.HideLog();
    }

    /// <summary>
    /// Writes a message to the log.
    /// </summary>
    /// <param name="message">The message to be sent to the log.</param>
    [DebuggerStepThrough]
    public static void Write(string message) {
        Debug.Print(message);
        if (LogFormUsable)
            LogForm.Append(message);
    }

    /// <summary>
    /// Writes a message to the log, not including date/time of the message.
    /// </summary>
    /// <param name="message">The message to be sent to the log.</param>
    [DebuggerStepThrough]
    public static void WriteNoDate(string message) {
        Debug.Print(message);
        if (LogFormUsable)
            LogForm.AppendNoDate(message);
    }

    /// <summary>
    /// Writes a message to the console, and does not include a date/time of the message.
    /// </summary>
    /// <param name="message">The message to be sent to the console.</param>
    [DebuggerStepThrough]
    public static void WriteToConsole(string message) {
        Console.WriteLine(message);
    }
    #endregion

    #region Exception handling
    /// <summary>
    /// Reports an exception to the user and logs it to the application.
    /// </summary>
    /// <param name="ReceivedException">The receieved exception that will be reported.</param>
    /// <returns>The <see cref="DialogResult"/> of the displayed exception form.</returns>
    public static DialogResult ReportException(Exception ReceivedException) {
        // Gets the time this gets called for reporting the exception time.
        DateTime ExceptionTime = DateTime.Now;

        // Create the exception info class with data relating to the exception and next actions.
        ExceptionInfo ExceptionData = new(ReceivedException, null) {
            AllowRetry = false,
            CustomDescription = null,
            ExceptionTime = ExceptionTime,
            ExtraMessage = null,
            FromLanguage = false,
            SkipDwmComposition = false,
            ExceptionType = ExceptionType.Caught
        };

        // Returns the exception forms dialog result.
        return DisplayException(ExceptionData, AllowWritingToFile);
    }

    /// <summary>
    /// Reports an exception to the user and logs it to the application.
    /// </summary>
    /// <param name="ReceivedException">The receieved exception that will be reported.</param>
    /// <param name="ExtraInfo">Optional extra information regarding the error.</param>
    /// <returns>The <see cref="DialogResult"/> of the displayed exception form.</returns>
    public static DialogResult ReportException(Exception ReceivedException, object ExtraInfo) {
        // Gets the time this gets called for reporting the exception time.
        DateTime ExceptionTime = DateTime.Now;

        // Create the exception info class with data relating to the exception and next actions.
        ExceptionInfo ExceptionData = new(ReceivedException, ExtraInfo) {
            AllowRetry = false,
            CustomDescription = null,
            ExceptionTime = ExceptionTime,
            ExtraMessage = null,
            FromLanguage = false,
            SkipDwmComposition = false,
            ExceptionType = ExceptionType.Caught
        };

        // Returns the exception forms dialog result.
        return DisplayException(ExceptionData, AllowWritingToFile);
    }

    /// <summary>
    /// Reports an exception that can be retried to the user, and logs it to the application.
    /// </summary>
    /// <param name="ReceivedException">The receieved exception that will be reported.</param>
    /// <returns>The <see cref="DialogResult"/> of the displayed exception form.</returns>
    public static DialogResult ReportRetriableException(Exception ReceivedException) {
        // Gets the time this gets called for reporting the exception time.
        DateTime ExceptionTime = DateTime.Now;

        // Create the exception info class with data relating to the exception and next actions.
        ExceptionInfo ExceptionData = new(ReceivedException, null) {
            AllowRetry = true,
            CustomDescription = null,
            ExceptionTime = ExceptionTime,
            ExtraMessage = null,
            FromLanguage = false,
            SkipDwmComposition = false,
            ExceptionType = ExceptionType.Caught
        };

        // Returns the exception forms dialog result.
        return DisplayException(ExceptionData, AllowWritingToFile);
    }

    /// <summary>
    /// Reports an exception that can be retried to the user, and logs it to the application.
    /// </summary>
    /// <param name="ReceivedException">The receieved exception that will be reported.</param>
    /// <param name="ExtraInfo">Optional extra information regarding the error.</param>
    /// <returns>The <see cref="DialogResult"/> of the displayed exception form.</returns>
    public static DialogResult ReportRetriableException(Exception ReceivedException, object ExtraInfo) {
        // Gets the time this gets called for reporting the exception time.
        DateTime ExceptionTime = DateTime.Now;

        // Create the exception info class with data relating to the exception and next actions.
        ExceptionInfo ExceptionData = new(ReceivedException, ExtraInfo) {
            AllowRetry = true,
            CustomDescription = null,
            ExceptionTime = ExceptionTime,
            ExtraMessage = null,
            FromLanguage = false,
            SkipDwmComposition = false,
            ExceptionType = ExceptionType.Caught
        };

        // Returns the exception forms dialog result.
        return DisplayException(ExceptionData, AllowWritingToFile);
    }

    /// <summary>
    /// Reports an exception that occurs when language data is being changed.
    /// </summary>
    /// <param name="ReceivedException">The receieved exception that will be reported.</param>
    /// <param name="CanRetry">Whether the problematic issue can be retried.</param>
    /// <returns>The <see cref="DialogResult"/> of the displayed exception form.</returns>
    public static DialogResult ReportLanguageException(Exception ReceivedException, bool CanRetry) {
        // Gets the time this gets called for reporting the exception time.
        DateTime ExceptionTime = DateTime.Now;

        // Create the exception info class with data relating to the exception and next actions.
        ExceptionInfo ExceptionData = new(ReceivedException, null) {
            AllowRetry = CanRetry,
            CustomDescription = null,
            ExceptionTime = ExceptionTime,
            ExtraMessage = null,
            FromLanguage = false,
            SkipDwmComposition = false,
            ExceptionType = ExceptionType.Caught
        };

        // Returns the exception forms dialog result.
        return DisplayException(ExceptionData, AllowWritingToFile);
    }

    /// <summary>
    /// Reports an exception that occurs when language data is being changed.
    /// </summary>
    /// <param name="ReceivedException">The receieved exception that will be reported.</param>
    /// <param name="CanRetry">Whether the problematic issue can be retried.</param>
    /// <param name="ExtraInfo">Optional extra information regarding the error.</param>
    /// <returns>The <see cref="DialogResult"/> of the displayed exception form.</returns>
    public static DialogResult ReportLanguageException(Exception ReceivedException, bool CanRetry, object ExtraInfo) {
        // Gets the time this gets called for reporting the exception time.
        DateTime ExceptionTime = DateTime.Now;

        // Create the exception info class with data relating to the exception and next actions.
        ExceptionInfo ExceptionData = new(ReceivedException, ExtraInfo) {
            AllowRetry = CanRetry,
            CustomDescription = null,
            ExceptionTime = ExceptionTime,
            ExtraMessage = null,
            FromLanguage = false,
            SkipDwmComposition = false,
            ExceptionType = ExceptionType.Caught
        };

        // Returns the exception forms dialog result.
        return DisplayException(ExceptionData, AllowWritingToFile);
    }

    /// <summary>
    /// Displays an exception dialog.
    /// </summary>
    /// <param name="ReceivedException">The <see cref="ExceptionInfo"/> instance.</param>
    /// <param name="CanWriteToFile">Whether to write the exception to a file.</param>
    /// <returns>The <see cref="DialogResult"/> of the displayed exception form.</returns>
    private static DialogResult DisplayException(ExceptionInfo ReceivedException, bool CanWriteToFile) {
        // Write it to the log, excluding the date.
        WriteNoDate($"[{ReceivedException.ExceptionTime:yyyy/MM/dd HH:mm:ss.fff}] An {ReceivedException.Exception.GetType().Name} occurred.");

        // Adds the exception to the log form.
        AddExceptionToLog(ReceivedException);

        // If suppress errors is enabled, return the none result.
        if (!ReceivedException.AllowRetry && Errors.suppressErrors)
            return DialogResult.None;

        // Creates the exception form and displays the dialog.
        using frmException NewException = new(ReceivedException);
        DialogResult ExceptionResult = NewException.ShowDialog(Form.ActiveForm);

        // Writes the exception to a file, if enabled.
        if (CanWriteToFile)
            WriteToFile(ReceivedException);

        // Returns the dialog result.
        return ExceptionResult;
    }

    /// <summary>
    /// Adds an exception to the log form.
    /// </summary>
    /// <param name="ReceivedException">The <see cref="Exception"/> receieved.</param>
    /// <param name="ExceptionTime">The time of the exception.</param>
    private static void AddExceptionToLog(ExceptionInfo ReceivedException) {
        if (LogEnabled)
            LogForm?.AddException(ReceivedException);
    }

    /// <summary>
    /// Writes an exception to a file.
    /// </summary>
    /// <param name="ReceivedException">The <see cref="ExceptionInfo"/> instance.</param>
    private static void WriteToFile(ExceptionInfo ReceivedException) {
        if (AllowWritingToFile) {
            bool RetrySaving = true;
            do {
                try {
                    System.IO.File.WriteAllText(
                        $"\\ex_{ReceivedException.ExceptionTime:yyyy-MM-dd_HH-mm-ss.fff}.log", ReceivedException.Exception.ToString());
                }
                catch (Exception SaveException) {
                    if (DisplayException(new(SaveException) { AllowRetry = true }, false) != DialogResult.Retry) {
                        RetrySaving = false;
                    }
                }
            } while (RetrySaving);
        }
    }
    #endregion

    #region Message box
    /// <summary>
    /// Displays a message dialog with a pre-defined caption.
    /// </summary>
    /// <param name="Message">The message that will be displayed in the dialog.</param>
    /// <returns>The dialog result of the message box.</returns>
    public static DialogResult MessageBox(
        string Message) => WinMsg.Show(Form.ActiveForm, Message, Language.ApplicationName);

    /// <summary>
    /// Displays a message dialog with a pre-defined caption.
    /// </summary>
    /// <param name="Message">The message that will be displayed in the dialog.</param>
    /// <param name="Buttons">The buttons that will appear within the dialog.</param>
    /// <returns>The dialog result of the message box.</returns>
    public static DialogResult MessageBox(
        string Message,
        MessageBoxButtons Buttons = MessageBoxButtons.OK) => WinMsg.Show(Form.ActiveForm, Message, Language.ApplicationName, Buttons);

    /// <summary>
    /// Displays a message dialog with a pre-defined caption.
    /// </summary>
    /// <param name="Message">The message that will be displayed in the dialog.</param>
    /// <param name="Buttons">The buttons that will appear within the dialog.</param>
    /// <param name="Icon">The icon that will appear before the message in the dialog.</param>
    /// <returns>The dialog result of the message box.</returns>
    public static DialogResult MessageBox(
        string Message,
        MessageBoxButtons Buttons,
        MessageBoxIcon Icon) => WinMsg.Show(Form.ActiveForm, Message, Language.ApplicationName, Buttons, Icon);

    /// <summary>
    /// Displays a message dialog with a pre-defined caption.
    /// </summary>
    /// <param name="Message">The message that will be displayed in the dialog.</param>
    /// <param name="Buttons">The buttons that will appear within the dialog.</param>
    /// <param name="DefaultButton">The default button that will be focused when the dialog appears.</param>
    /// <returns>The dialog result of the message box.</returns>
    public static DialogResult MessageBox(
        string Message,
        MessageBoxButtons Buttons,
        MessageBoxDefaultButton DefaultButton) => WinMsg.Show(Form.ActiveForm, Message, Language.ApplicationName, Buttons, MessageBoxIcon.None, DefaultButton);

    /// <summary>
    /// Displays a message dialog with a pre-defined caption.
    /// </summary>
    /// <param name="Message">The message that will be displayed in the dialog.</param>
    /// <param name="Buttons">The buttons that will appear within the dialog.</param>
    /// <param name="DefaultButton">The default button that will be focused when the dialog appears.</param>
    /// <param name="Icon">The icon that will appear before the message in the dialog.</param>
    /// <returns>The dialog result of the message box.</returns>
    public static DialogResult MessageBox(
        string Message,
        MessageBoxButtons Buttons,
        MessageBoxIcon Icon,
        MessageBoxDefaultButton DefaultButton) => WinMsg.Show(Form.ActiveForm, Message, Language.ApplicationName, Buttons, Icon, DefaultButton);
    #endregion

}