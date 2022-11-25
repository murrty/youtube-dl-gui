#define ALLOWUNHANDLEDCATCHING
namespace murrty.logging;

using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using youtube_dl_gui_updater;

/// <summary>
/// This class will control the Errors that get reported in try statements.
/// </summary>
internal static class Log {
    #region Properties & Fields
    /// <summary>
    /// Gets a string that resolves information regarding the current computer.
    /// </summary>
    public static string ComputerVersionInformation {
        get; private set;
    } = "Not initialized";

    /// <summary>
    /// Gets or sets whether the log will write to file.
    /// </summary>
    public static bool AllowWritingToFile { get; set; } = false;
    #endregion

    #region Log stuff
    /// <summary>
    /// Initializes the log.
    /// </summary>
    public static void InitializeLogging() {
        // Catch any exceptions that are unhandled, so we can report it.
#if !DEBUG || ALLOWUNHANDLEDCATCHING
        try {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
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

        // Build up a string containing relevant information about the computer.
        Write("Creating ComputerVersionInformation for exceptions.");
        ManagementObjectSearcher MgtSearcher = new("SELECT * FROM Win32_OperatingSystem");
        ManagementObject MgtInfo = MgtSearcher?.Get().Cast<ManagementObject>().FirstOrDefault();
        ComputerVersionInformation = $$"""
            Current Version: {{Program.CurrentVersion}} (Updater Version)
            Current Culture: {{Thread.CurrentThread.CurrentCulture.EnglishName}}
            """ + "\n" + (MgtInfo is null ? "The ManagementObject for Win32_OperatingSystem is null and cannot be used." : $$"""
            System Caption: {{MgtInfo.Properties["Caption"].Value ?? "couldn't query"}}
            System Version: {{MgtInfo.Properties["Version"].Value ?? "couldn't query"}}
            Service Pack Major: {{MgtInfo.Properties["ServicePackMajorVersion"].Value ?? "couldn't query"}}
            Service Pack Minor: {{MgtInfo.Properties["ServicePackMinorVersion"].Value ?? "couldn't query"}}
            """);
    }

    /// <summary>
    /// Writes a message to the log.
    /// </summary>
    /// <param name="message">The message to be sent to the log.</param>
    [DebuggerStepThrough]
    public static void Write(string message) {
        Debug.Print(message);
    }

    /// <summary>
    /// Writes a message to the log, not including date/time of the message.
    /// </summary>
    /// <param name="message">The message to be sent to the log.</param>
    [DebuggerStepThrough]
    public static void WriteNoDate(string message) {
        Debug.Print(message);
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
    /// Reports an exception that occurs when language data is being changed.
    /// </summary>
    /// <param name="ReceivedException">The receieved exception that will be reported.</param>
    /// <param name="CanRetry">Whether the problematic issue can be retried.</param>
    /// <param name="ExtraInfo">Optional extra information regarding the error.</param>
    /// <returns>The <see cref="DialogResult"/> of the displayed exception form.</returns>
    public static DialogResult ReportLanguageException(Exception ReceivedException, bool CanRetry, object ExtraInfo = null) {
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
    /// Reports an exception using a user generated <see cref="ExceptionInfo"/> instance.
    /// </summary>
    /// <param name="ReceivedException">The <see cref="ExceptionInfo"/> instance to reference for the exception.</param>
    /// <returns>The <see cref="DialogResult"/> of the displayed exception form.</returns>
    public static DialogResult ReportException(ExceptionInfo ReceivedException) {
        if (ReceivedException is null) {
            ReportException(new NullReferenceException(nameof(ReceivedException)));
            return DialogResult.OK;
        }
        if (ReceivedException.Exception is null) {
            ReportException(new NullReferenceException(nameof(ReceivedException.Exception)));
            return DialogResult.OK;
        }

        return DisplayException(ReceivedException, AllowWritingToFile);
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
        //if (LogEnabled)
        //    LogForm?.AddException(ReceivedException.GetType().Name, $"{ReceivedException.Message}\r\n\r\n{ReceivedException.StackTrace}", ExceptionTime);
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
}