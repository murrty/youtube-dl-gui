#define ALLOWUNHANDLEDCATCHING
namespace murrty.logging;

using System.Management;
using System.Windows.Forms;
using youtube_dl_gui_updater;
using WinMsg = System.Windows.Forms.MessageBox;

/// <summary>
/// The central logging system used to handle the log form, log messages, report exceptions, and display message boxes.
/// </summary>
public static class Log {

    #region Properties & Fields
    /// <summary>
    /// The default value that should appear in the message box titles.
    /// </summary>
    public const string MessageBoxTitle = "youtube-dl-gui updater";

    /// <summary>
    /// Gets the computer versioning information, such as the running operating system, language, etc.
    /// </summary>
    public static string ComputerVersionInformation {
        get; private set;
    } = $"{nameof(ComputerVersionInformation)} not initialized.";

    /// <summary>
    /// Gets or sets whether the log will write to file.
    /// </summary>
    public static bool AllowWritingToFile { get; set; } = false;
    #endregion

    static Log() {
#if RELEASE && ALLOWUNHANDLEDCATCHING
        try {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += (sender, exception) => {
                ExceptionInfo NewException = new((Exception)exception.ExceptionObject) {
                    ExceptionTime = DateTime.Now,
                    ExceptionType = exception.IsTerminating ? ExceptionType.Unhandled : ExceptionType.Caught,
                    AllowRetry = false
                };
                AddExceptionToLog(NewException);
                using frmException ExceptionDisplay = new(NewException);
                ExceptionDisplay.ShowDialog();
            };

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

        ManagementObjectSearcher MgtSearcher = new("SELECT * FROM Win32_OperatingSystem");
        ManagementObject MgtInfo = MgtSearcher?.Get().Cast<ManagementObject>().FirstOrDefault();
        ComputerVersionInformation = $$"""
            Current version: {{Program.CurrentVersion}}
            Current culture: {{Thread.CurrentThread.CurrentCulture.EnglishName}}
            """ + (MgtInfo is null ? "The ManagementObject for Win32_OperatingSystem is null and cannot be used." : $$"""
            System caption: {{MgtInfo.Properties["Caption"].Value ?? "could not query"}}
            Version: {{MgtInfo.Properties["Version"].Value ?? "could not query"}}
            Service Pack major: {{MgtInfo.Properties["ServicePackMajorVersion"].Value ?? "could not query"}}
            Service Pack minor: {{MgtInfo.Properties["ServicePackMinorVersion"].Value ?? "could not query"}}
            """);
    }

    #region Exception handling
    // Oh god, oh fuck \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    public static DialogResult ReportException(Exception ReceivedException) =>
        ReportException(ReceivedException, null, null, false, false, null);
    public static DialogResult ReportException(Exception ReceivedException, bool Retriable) =>
        ReportException(ReceivedException, null, null, Retriable, false, null);
    public static DialogResult ReportException(Exception ReceivedException, bool Retriable, bool Abortable) =>
        ReportException(ReceivedException, null, null, Retriable, Abortable, null);
    public static DialogResult ReportException(Exception ReceivedException, object ExtraInfo) =>
        ReportException(ReceivedException, ExtraInfo, null, false, false, null);
    public static DialogResult ReportException(Exception ReceivedException, object ExtraInfo, bool Retriable) =>
        ReportException(ReceivedException, ExtraInfo, null, Retriable, false, null);
    public static DialogResult ReportException(Exception ReceivedException, object ExtraInfo, bool Retriable, bool Abortable) =>
        ReportException(ReceivedException, ExtraInfo, null, Retriable, Abortable, null);
    public static DialogResult ReportException(Exception ReceivedException, string ExtraMessage) =>
        ReportException(ReceivedException, null, ExtraMessage, false, false, null);
    public static DialogResult ReportException(Exception ReceivedException, string ExtraMessage, bool Retriable) =>
        ReportException(ReceivedException, null, ExtraMessage, Retriable, false, null);
    public static DialogResult ReportException(Exception ReceivedException, string ExtraMessage, bool Retriable, bool Abortable) =>
        ReportException(ReceivedException, null, ExtraMessage, Retriable, Abortable, null);
    public static DialogResult ReportException(Exception ReceivedException, object ExtraInfo, string ExtraMessage) =>
        ReportException(ReceivedException, ExtraInfo, ExtraMessage, false, false, null);
    public static DialogResult ReportException(Exception ReceivedException, object ExtraInfo, string ExtraMessage, bool Retriable) =>
        ReportException(ReceivedException, ExtraInfo, ExtraMessage, Retriable, false, null);
    public static DialogResult ReportException(Exception ReceivedException, object ExtraInfo, string ExtraMessage, bool Retriable, bool Abortable) =>
        ReportException(ReceivedException, ExtraInfo, ExtraMessage, Retriable, Abortable, null);
    public static DialogResult ReportException(Exception ReceivedException, IWin32Window Owner) =>
        ReportException(ReceivedException, null, null, false, false, Owner);
    public static DialogResult ReportException(Exception ReceivedException, bool Retriable, IWin32Window Owner) =>
        ReportException(ReceivedException, null, null, Retriable, false, Owner);
    public static DialogResult ReportException(Exception ReceivedException, bool Retriable, bool Abortable, IWin32Window Owner) =>
        ReportException(ReceivedException, null, null, Retriable, Abortable, Owner);
    public static DialogResult ReportException(Exception ReceivedException, object ExtraInfo, IWin32Window Owner) =>
        ReportException(ReceivedException, ExtraInfo, null, false, false, Owner);
    public static DialogResult ReportException(Exception ReceivedException, object ExtraInfo, bool Retriable, IWin32Window Owner) =>
        ReportException(ReceivedException, ExtraInfo, null, Retriable, false, Owner);
    public static DialogResult ReportException(Exception ReceivedException, object ExtraInfo, bool Retriable, bool Abortable, IWin32Window Owner) =>
        ReportException(ReceivedException, ExtraInfo, null, Retriable, Abortable, Owner);
    public static DialogResult ReportException(Exception ReceivedException, string ExtraMessage, IWin32Window Owner) =>
        ReportException(ReceivedException, null, ExtraMessage, false, false, Owner);
    public static DialogResult ReportException(Exception ReceivedException, string ExtraMessage, bool Retriable, IWin32Window Owner) =>
        ReportException(ReceivedException, null, ExtraMessage, Retriable, false, Owner);
    public static DialogResult ReportException(Exception ReceivedException, string ExtraMessage, bool Retriable, bool Abortable, IWin32Window Owner) =>
        ReportException(ReceivedException, null, ExtraMessage, Retriable, Abortable, Owner);
    public static DialogResult ReportException(Exception ReceivedException, object ExtraInfo, string ExtraMessage, IWin32Window Owner) =>
        ReportException(ReceivedException, ExtraInfo, ExtraMessage, false, false, Owner);
    public static DialogResult ReportException(Exception ReceivedException, object ExtraInfo, string ExtraMessage, bool Retriable, IWin32Window Owner) =>
        ReportException(ReceivedException, ExtraInfo, ExtraMessage, Retriable, false, Owner);

    public static DialogResult ReportLanguageException(Exception ReceivedException, bool Retriable) {
        // Gets the time this gets called for reporting the exception time.
        DateTime ExceptionTime = DateTime.Now;

        // Create the exception info class with data relating to the exception and next actions.
        ExceptionInfo ExceptionData = new(ReceivedException, null, null) {
            AllowRetry = Retriable,
            AllowAbort = false,
            CustomDescription = null,
            ExceptionTime = ExceptionTime,
            FromLanguage = false,
            SkipDwmComposition = false,
            ExceptionType = ExceptionType.Caught,
            WindowOwner = null
        };

        // Returns the exception forms dialog result.
        return DisplayException(ExceptionData, AllowWritingToFile);
    }
    public static DialogResult ReportException(Exception ReceivedException, object ExtraInfo, string ExtraMessage, bool Retriable, bool Abortable, IWin32Window Owner) {
        // Gets the time this gets called for reporting the exception time.
        DateTime ExceptionTime = DateTime.Now;

        // Create the exception info class with data relating to the exception and next actions.
        ExceptionInfo ExceptionData = new(ReceivedException, ExtraInfo, ExtraMessage) {
            AllowRetry = Retriable,
            AllowAbort = Abortable,
            CustomDescription = null,
            ExceptionTime = ExceptionTime,
            FromLanguage = false,
            SkipDwmComposition = false,
            ExceptionType = ExceptionType.Caught,
            WindowOwner = Owner
        };

        // Returns the exception forms dialog result.
        return DisplayException(ExceptionData, AllowWritingToFile);
    }

    // Functionality \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    private static DialogResult DisplayException(ExceptionInfo ReceivedException, bool CanWriteToFile) {
        // Creates the exception form and displays the dialog.
        using frmException NewException = new(ReceivedException);
        DialogResult ExceptionResult = NewException.ShowDialog(ReceivedException.WindowOwner);

        // Writes the exception to a file, if enabled.
        if (CanWriteToFile)
            WriteToFile(ReceivedException);

        // Returns the dialog result.
        return ExceptionResult;
    }
    private static void WriteToFile(ExceptionInfo ReceivedException) {
        if (AllowWritingToFile) {
            bool RetrySaving = true;
            do {
                try {
                    System.IO.File.WriteAllText(
                        $"\\ex_{ReceivedException.ExceptionTime:yyyy-MM-dd_HH-mm-ss.fff}.log", ReceivedException.Exception.ToString());
                }
                catch (Exception SaveException) {
                    ExceptionInfo FileException = new(SaveException) {
                        AllowRetry = true,
                        WindowOwner = ReceivedException.WindowOwner
                    };
                    RetrySaving = DisplayException(FileException, false) == DialogResult.Retry;
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
        MessageBoxButtons Buttons = MessageBoxButtons.OK) => WinMsg.Show(Message, MessageBoxTitle, Buttons);

    /// <summary>
    /// Displays a message dialog with a pre-defined caption.
    /// </summary>
    /// <param name="Message">The message that will be displayed in the dialog.</param>
    /// <param name="Icon">The icon that will appear before the message in the dialog.</param>
    /// <returns>The dialog result of the message box.</returns>
    public static DialogResult MessageBox(
        string Message,
        MessageBoxIcon Icon) => WinMsg.Show(Message, MessageBoxTitle, MessageBoxButtons.OK, Icon);

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
        MessageBoxIcon Icon) => WinMsg.Show(Message, MessageBoxTitle, Buttons, Icon);

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
        MessageBoxDefaultButton DefaultButton) => WinMsg.Show(Message, MessageBoxTitle, Buttons, MessageBoxIcon.None, DefaultButton);

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
        MessageBoxDefaultButton DefaultButton) => WinMsg.Show(Message, MessageBoxTitle, Buttons, Icon, DefaultButton);
    #endregion

}