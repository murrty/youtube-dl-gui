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
        /// <param name="WebE">The WebException that was caught</param>
        /// <param name="url">The URL that (might-have) caused the problem</param>
        public static void reportWebError(WebException WebE, string url) {
            if (Errors.Default.suppressErrors)
                return;

            string outputMessage = "A WebException occured while downloading " + url + "\n\n" +
                                   "Inner Exception: " + WebE.InnerException +
                                   "\nStacktrace:" + WebE.StackTrace +
                                   "\n" + WebE.Message +
                                   "\n\n" + WebE.HResult;

            if (Errors.Default.detailedErrors) {
                System.Windows.Forms.MessageBox.Show(outputMessage, "youtube-dl-gui");
            }
            else {
                System.Windows.Forms.MessageBox.Show("An exception occured while downloading " + url + "\n\n" + WebE.ToString(), "youtube-dl-gui");
            }

            if (Errors.Default.logErrors) {
                System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\error.log", outputMessage);
            }
        }
        /// <summary>
        /// Reports any general exceptions that are caught
        /// </summary>
        /// <param name="Exception">The Exception that was caught</param>
        public static void reportError(Exception Exception) {
            if (Errors.Default.suppressErrors)
                return;

            string outputMessage = "A general exception has occured.\n\n" +
                                   "Inner Exception: " + Exception.InnerException +
                                   "\nStacktrace:" + Exception.StackTrace +
                                   "\n" + Exception.Message;

            if (Errors.Default.detailedErrors) {
                System.Windows.Forms.MessageBox.Show(outputMessage, "youtube-dl-gui");
            }
            else {
                System.Windows.Forms.MessageBox.Show("An exception occured\n\n" + Exception.ToString(), "youtube-dl-gui");
            }

            if (Errors.Default.logErrors) {
                System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\error.log", outputMessage);
            }
        }
    }
}
