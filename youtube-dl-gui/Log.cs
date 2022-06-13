using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Windows.Forms;

using murrty.forms;

namespace youtube_dl_gui {

    /// <summary>
    /// This class will control the Errors that get reported in try statements.
    /// </summary>
    class Log {

        #region Log stuff
        /// <summary>
        /// Gets a string that resolves information regarding the current computer.
        /// </summary>
        public static string DiagnosticInformation {
            get; private set;
        } = "Not initialized";

        public static void InitializeLogging() {
            //EnableLogging();

            // Build up a string containing relevant information about the computer.
            Write("Creating DiagnosticInformation for caught exceptions.");
            ManagementObjectSearcher searcher = new("SELECT * FROM Win32_OperatingSystem");
            ManagementObject info = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
            DiagnosticInformation =
                $"Current version: {(Program.IsBetaVersion ? Program.BetaVersion ?? "Unknown beta version" : Program.CurrentVersion)}\n" +
                $"Curernt culture: {System.Threading.Thread.CurrentThread.CurrentCulture.EnglishName ?? "Unknown culture"}\n" +
                $"System Caption: {info.Properties["Caption"].Value ?? "couldn't retrieve"}\n" +
                $"Version: {info.Properties["Version"].Value ?? "couldn't retrieve"}\n" +
                $"Service Pack Major: {info.Properties["ServicePackMajorVersion"].Value ?? "couldn't retrieve"}\n" +
                $"Service Pack Minor: {info.Properties["ServicePackMinorVersion"].Value ?? "couldn't retrieve"}";

            // Catch any exceptions that are unhandled, so we can report it.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Write("Creating unhandled exception event.");
            AppDomain.CurrentDomain.UnhandledException += (sender, exception) => {
                using murrty.forms.frmException UnrecoverableException = new(new(exception) {
                    Unrecoverable = true,
                    AllowRetry = false
                });
                UnrecoverableException.ShowDialog();
            };

            Write("Creating unhandled thread exception event.");
            Application.ThreadException += (sender, exception) => {
                using murrty.forms.frmException UnrecoverableException = new(new(exception) {
                    Unrecoverable = true,
                    AllowRetry = false
                });
                UnrecoverableException.ShowDialog();
            };
        }

        /// <summary>
        /// Enables the logging form.
        /// </summary>
        [DebuggerStepThrough]
        public static void EnableLogging() {
            //if (LogEnabled && LogForm != null) {
            //    Write("Logging is already enabled.");
            //}
            //else {
            //    LogForm = new frmLog();
            //    LogEnabled = true;
            //    Write("Logging has been enabled.", true);
            //}
        }

        /// <summary>
        /// Disables the logging form, but debug logging will still occur.
        /// </summary>
        [DebuggerStepThrough]
        public static void DisableLogging() {
            //if (LogEnabled) {
            //    Write("Disabling logging.");

            //    if (LogForm.WindowState == FormWindowState.Minimized || LogForm.WindowState == FormWindowState.Maximized) {
            //        LogForm.Opacity = 0;
            //        LogForm.WindowState = FormWindowState.Normal;
            //    }

            //    LogForm?.Dispose();
            //    LogEnabled = false;
            //}
        }

        /// <summary>
        /// Shows the log form.
        /// </summary>
        [DebuggerStepThrough]
        public static void ShowLog() {
            //if (LogEnabled && LogForm != null) {
            //    if (LogForm.IsShown) {
            //        Write("The log form is already shown.");
            //        LogForm.Activate();
            //    }
            //    else {
            //        LogForm.Append("Showing log");
            //        LogForm.IsShown = true;
            //        LogForm.Show();
            //    }
            //}
        }

        /// <summary>
        /// Writes a message to the log.
        /// </summary>
        /// <param name="message">The message to be sent to the log</param>
        /// <param name="initial">If the message is the initial one to be sent, does not add a new line break.</param>
        [DebuggerStepThrough]
        public static void Write(string message, bool initial = false) {
            Debug.Print(message);
            //if (LogEnabled) {
            //    LogForm?.Append(message, initial);
            //}
        }

        /// <summary>
        /// Writes a message to the log, not including date/time of the message.
        /// </summary>
        /// <param name="message">The message to be sent to the log</param>
        /// <param name="initial">If the message is the initial one to be sent, does not add a new line break.</param>
        [DebuggerStepThrough]
        public static void WriteNoDate(string message, bool initial = false) {
            Debug.Print(message);
            //if (LogEnabled) {
            //    LogForm?.AppendNoDate(message, initial);
            //}
        }
        #endregion

        #region Exception handling
        /// <summary>
        /// Reports an exception to the program, writes to an error file (if enabled) and displays an exception form.
        /// </summary>
        /// <param name="ReceivedException">A runtime-resolved object that must be a typeof Exception, or it will not display any information.</param>
        /// <param name="ExtraInfo">Any extra information regarding the exception.</param>
        /// <returns>The <see cref="DialogResult"/> of the exception form.</returns>
        public static DialogResult ReportException(dynamic ReceivedException, object ExtraInfo = null) {
            Write($"A {ReceivedException.GetType().Name} occurred.");
            WriteToFile(ReceivedException);

            using frmException NewException = new(new(ReceivedException) {
                AllowRetry = false,
                ExtraInfo = ExtraInfo
            });
            return NewException.ShowDialog();
        }

        public static DialogResult ReportRetriableException(dynamic ReceivedException, object ExtraInfo = null) {
            Write($"A {ReceivedException.GetType().Name} occurred.");
            WriteToFile(ReceivedException);

            using frmException NewException = new(new(ReceivedException) {
                AllowRetry = true,
                ExtraInfo = ExtraInfo
            });
            return NewException.ShowDialog();
        }

        /// <summary>
        /// Reports an exception from a source that can be attempted again to the program, writes to an error file (if enabled) and displays an exception form.
        /// </summary>
        /// <param name="ReceivedException">A runtime-resolved object that must be a typeof Exception, or it will not display any information.</param>
        /// <param name="ExtraInfo">Any extra information regarding the exception.</param>
        /// <returns>The <see cref="DialogResult"/> of the exception form.</returns>
        public static DialogResult ReportRetriableLanguageException(dynamic ReceivedException, object ExtraInfo = null) {
            Write($"A {ReceivedException.GetType().Name} occurred.");
            WriteToFile(ReceivedException);

            using frmException NewException = new(new(ReceivedException) {
                AllowRetry = true,
                ExtraInfo = ExtraInfo,
                FromLanguage = true
            });
            return NewException.ShowDialog();
        }

        /// <summary>
        /// Writes the exception to a error log file in the same directory as the program.
        /// </summary>
        /// <param name="ReceivedException">A runtime-resolved object that must be a typeof Exception, or it will not display any information.</param>
        private static void WriteToFile(dynamic ReceivedException) {
            if (Config.Settings.Errors.logErrors && !Program.IsDebug) {
                string LogData = ReceivedException switch {
                    UnhandledExceptionEventArgs UnhandledEvent => UnhandledEvent.ToString(),
                    System.Threading.ThreadExceptionEventArgs ThreadException => ThreadException.ToString(),
                    DecimalParsingException DecimalParsingException => DecimalParsingException.ToString(),
                    ApiParsingException ApiParsingException => ApiParsingException.ToString(),
                    System.Net.WebException WebException => WebException.ToString(),
                    Exception Exception => Exception.ToString(),
                   _ => "An uncast exception occurred, and the data cannot be retreieved."
                };
                try {
                    System.IO.File.WriteAllText(
                        $"\\error_{DateTime.Now:yyyy-MM-dd-HH-mm-ss.fff}.log",
                        LogData
                    );
                }
                catch (Exception ex) {
                    if (ReportRetriableException(ex) == DialogResult.Retry) {
                        WriteToFile(LogData);
                    }
                }
            }
        }

        /// <summary>
        /// Writes the exception to a error log file in the same directory as the program.
        /// </summary>
        /// <param name="LogData">The pre-built error data.</param>
        private static void WriteToFile(string LogData) {
            if (Config.Settings.Errors.logErrors && !Program.IsDebug) {
                try {
                    System.IO.File.WriteAllText(
                        $"\\error_{DateTime.Now:yyyy-MM-dd-HH-mm-ss.fff}.log",
                        LogData
                    );
                }
                catch (Exception ex) {
                    if (ReportRetriableException(ex) == DialogResult.Retry) {
                        WriteToFile(LogData);
                    }
                }
            }
        }
        #endregion

    }

    /// <summary>
    /// A exception that occurs when decimal.TryParse returns false.
    /// </summary>
    [Serializable]
    public class DecimalParsingException : Exception {
        public string ExtraInfo { get; set; } = "No extra info provided.";
        public DecimalParsingException() : base("No message has been provided.") { }
        public DecimalParsingException(string message) : base(message) { }
        public DecimalParsingException(string message, string extraInfo) : base(message) { ExtraInfo = extraInfo; }
        public override string ToString() =>
            base.ToString() + "\nExtra information: " + ExtraInfo;
    }

    /// <summary>
    /// An exception that occurs when parsing an API fails at a critical point.
    /// </summary>
    [Serializable]
    public class ApiParsingException : Exception {
        public string ExtraInfo { get; set; } = "No extra info provided.";
        public string ApiUrl { get; set; } = "No API URL provided.";
        public ApiParsingException(string url) : base("No message has been provided.") { ApiUrl = url; }
        public ApiParsingException(string message, string url) : base(message) { ApiUrl = url; }
        public ApiParsingException(string message, string url, string extraInfo) : base(message) { ApiUrl = url; ExtraInfo = extraInfo; }
        public override string ToString() =>
            base.ToString() + "\nApi URL: " + ApiUrl + "\nExtra information: " + ExtraInfo;
    }

}