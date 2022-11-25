/// Log is a part of https://github.com/murrty/aphrodite booru downloader.
/// Licensed via GPL-3.0, if you did not receieve a license with this file; idk figure it out.
/// This code, *as-is*, should not be a part of another project; it should really only be used as reference or testing.

// This definintion will allow the application to catch unhandled exceptions.
// Not useful for debugging, but useful for exception handling debugging.
#define ALLOWUNHANDLEDCATCHING
namespace murrty.logging;

using System.Diagnostics;
using System.Management;
using System.Windows.Forms;
using aphrodite;

using WinMsg = System.Windows.Forms.MessageBox;

/// <summary>
/// The central logging system used to handle the log form, log messages, report exceptions, and display message boxes.
/// </summary>
public static class Log {
    #region Properties & Fields
    /// <summary>
    /// The default value that should appear in the message box titles.
    /// </summary>
    public const string MessageBoxTitle = "aphrodite";

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
    /// Initializes the log.
    /// </summary>
    internal static void InitializeLogging() {
#if !DEBUG || ALLOWUNHANDLEDCATCHING
        try {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
#endif

            EnableLogging();

#if !DEBUG || ALLOWUNHANDLEDCATCHING
            Write("Creating unhandled exception event.");
            AppDomain.CurrentDomain.UnhandledException += (sender, exception) => {
                ExceptionInfo NewException = new((Exception)exception.ExceptionObject) {
                    ExceptionTime = DateTime.Now,
                    ExceptionType = exception.IsTerminating ? ExceptionType.Unhandled : ExceptionType.Caught,
                    AllowRetry = false
                };
                AddExceptionToLog(NewException.Exception, NewException.ExceptionTime);
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
                AddExceptionToLog(NewException.Exception, NewException.ExceptionTime);
                using frmException ExceptionDisplay = new(NewException);
                ExceptionDisplay.ShowDialog();
            };
        }
        catch (Exception ex) {
            ReportException(ex);
        }
#endif

        Write("Creating ComputerVersionInformation for exceptions.");
        ManagementObjectSearcher searcher = new("SELECT * FROM Win32_OperatingSystem");
        ManagementObject info = searcher?.Get().Cast<ManagementObject>().FirstOrDefault();
        ComputerVersionInformation = info is not null ?
            $"System Caption: {info.Properties["Caption"].Value ?? "couldn't query"}\n" +
            $"Version: {info.Properties["Version"].Value ?? "couldn't query"}\n" +
            $"Service Pack Major: {info.Properties["ServicePackMajorVersion"].Value ?? "couldn't query"}\n" +
            $"Service Pack Minor: {info.Properties["ServicePackMinorVersion"].Value ?? "couldn't query"}" :
            "The ManagementObject for Win32_OperatingSystem is null and cannot be used.";
    }

    /// <summary>
    /// Enables the logging form.
    /// </summary>
    //[DebuggerStepThrough]
    internal static void EnableLogging() {
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
    internal static void DisableLogging() {
        if (LogFormEnabled) {
            if (LogForm is not null) {
                if (!LogForm.IsDisposed && (LogForm.WindowState == FormWindowState.Minimized || LogForm.WindowState == FormWindowState.Maximized)) {
                    LogForm.Opacity = 0;
                    LogForm.WindowState = FormWindowState.Normal;

                    Config.Settings.FormSettings.frmLog_Location = LogForm.Location;
                    Config.Settings.FormSettings.frmLog_Size = LogForm.Size;
                    Config.Settings.FormSettings.Save();
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
        if (LogFormUsable) {
            if (LogForm.IsShown) {
                Write("The log form is already shown.");
                LogForm.Activate();
            }
            else {
                LogForm.Append("Showing log");
                LogForm.IsShown = true;
                LogForm.Show();
            }
        }
    }

    /// <summary>
    /// Hides the log form.
    /// </summary>
    //[DebuggerStepThrough]
    internal static void HideLog() {
        if (LogFormUsable) {
            if (LogForm.IsShown) {
                LogForm.Hide();
                LogForm.IsShown = false;
            }
        }
    }

    /// <summary>
    /// Writes a message to the log.
    /// </summary>
    /// <param name="message">The message to be sent to the log</param>
    /// <param name="initial">If the message is the initial one to be sent, does not add a new line break.</param>
    [DebuggerStepThrough]
    public static void Write(string message) {
        Debug.Print(message);
        if (LogFormUsable)
            LogForm.Append(message);
    }

    /// <summary>
    /// Writes a message to the log, not including date/time of the message.
    /// </summary>
    /// <param name="message">The message to be sent to the log</param>
    /// <param name="initial">If the message is the initial one to be sent, does not add a new line break.</param>
    [DebuggerStepThrough]
    public static void WriteNoDate(string message) {
        Debug.Print(message);
        if (LogFormUsable)
            LogForm.AppendNoDate(message);
    }
    #endregion

    #region Exception handling
    /// <summary>
    /// Reports an exception to the user and logs it to the application.
    /// </summary>
    /// <param name="ReceivedException">The receieved exception that will be reported.</param>
    /// <param name="ExtraInfo">Optional extra information regarding the error.</param>
    /// <returns>The <see cref="DialogResult"/> of the displayed exception form.</returns>
    public static DialogResult ReportException(Exception ReceivedException, object ExtraInfo = null) {
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
    /// <param name="ExtraInfo">Optional extra information regarding the error.</param>
    /// <returns>The <see cref="DialogResult"/> of the displayed exception form.</returns>
    public static DialogResult ReportRetriableException(Exception ReceivedException, object ExtraInfo = null) {
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
    /// Displays an exception dialog.
    /// </summary>
    /// <param name="ReceivedException">The <see cref="ExceptionInfo"/> instance.</param>
    /// <param name="CanWriteToFile">Whether to write the exception to a file.</param>
    /// <returns>The <see cref="DialogResult"/> of the displayed exception form.</returns>
    private static DialogResult DisplayException(ExceptionInfo ReceivedException, bool CanWriteToFile) {
        // Write it to the log, excluding the date.
        WriteNoDate($"[{ReceivedException.ExceptionTime:yyyy/MM/dd HH:mm:ss.fff}] An {ReceivedException.Exception.GetType().Name} occurred.");

        // Adds the exception to the log form.
        AddExceptionToLog(ReceivedException.Exception, ReceivedException.ExceptionTime);

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
    private static void AddExceptionToLog(Exception ReceivedException, DateTime ExceptionTime) {
        if (LogEnabled)
            LogForm?.AddException(ReceivedException.GetType().Name, $"{ReceivedException.Message}\r\n\r\n{ReceivedException.StackTrace}", ExceptionTime);
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
        string Message) => WinMsg.Show(Form.ActiveForm, Message, MessageBoxTitle);

    /// <summary>
    /// Displays a message dialog with a pre-defined caption.
    /// </summary>
    /// <param name="Message">The message that will be displayed in the dialog.</param>
    /// <param name="Buttons">The buttons that will appear within the dialog.</param>
    /// <returns>The dialog result of the message box.</returns>
    public static DialogResult MessageBox(
        string Message,
        MessageBoxButtons Buttons = MessageBoxButtons.OK) => WinMsg.Show(Form.ActiveForm, Message, MessageBoxTitle, Buttons);

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
        MessageBoxIcon Icon) => WinMsg.Show(Form.ActiveForm, Message, MessageBoxTitle, Buttons, Icon);

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
        MessageBoxDefaultButton DefaultButton) => WinMsg.Show(Form.ActiveForm, Message, MessageBoxTitle, Buttons, MessageBoxIcon.None, DefaultButton);

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
        MessageBoxDefaultButton DefaultButton) => WinMsg.Show(Form.ActiveForm, Message, MessageBoxTitle, Buttons, Icon, DefaultButton);
    #endregion
}