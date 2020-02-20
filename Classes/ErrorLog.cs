using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace youtube_dl_gui {
    class ErrorLog {
        /// <summary>
        /// Reports any web errors that are caught
        /// </summary>
        /// <param name="WebException">The WebException that was caught</param>
        /// <param name="url">The URL that (might-have) caused the problem</param>
        public static void reportWebError(WebException WebException, string WebsiteAddress) {
            if (Errors.Default.suppressErrors)
                return;

            frmException ExceptionDisplay = new frmException();
            ExceptionDisplay.ReportedWebException = WebException;
            ExceptionDisplay.FromLanguage = false;
            ExceptionDisplay.ShowDialog();
            ExceptionDisplay.Dispose();

            if (Errors.Default.logErrors) {
                System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\error.log", WebException.ToString());
            }
        }
        /// <summary>
        /// Reports any general exceptions that are caught
        /// </summary>
        /// <param name="Exception">The Exception that was caught</param>
        public static void reportError(Exception Exception) {
            if (Errors.Default.suppressErrors)
                return;

            frmException ExceptionDisplay = new frmException();
            ExceptionDisplay.ReportedException = Exception;
            ExceptionDisplay.ShowDialog();
            ExceptionDisplay.FromLanguage = false;
            ExceptionDisplay.Dispose();

            if (Errors.Default.logErrors) {
                System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\error.log", Exception.ToString());
            }
        }
    }
}
