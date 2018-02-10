using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtube_dl_gui {
    class ErrorLog {
        /// <summary>
        /// Reports the error recieved into a MessageBox.
        /// </summary>
        /// <param name="Error">The error string</param>
        public static void reportError(string Error) {
            if (Advanced.Default.disableErrors)
                return;

            if (MessageBox.Show("An error occured:\n" + Error + "\n\nCopy error to clipboard?", "YChanEx", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Clipboard.SetText(Error);
        }

        /// <summary>
        /// Reports the web error with a specific code.
        /// </summary>
        /// <param name="webEx">The caught web exception.</param>
        /// <param name="url">(Optional) The URL attempting to be downloaded.</param>
        public static void reportWebError(WebException webEx, string url = "Not defined") {
            if (Advanced.Default.disableErrors)
                return;

            var resp = webEx.Response as HttpWebResponse;
            int respID = (int)resp.StatusCode;
            if (resp != null) {
                if (respID == 404) {
                    MessageBox.Show("404 at URL " + url + "\nThe item was not found.");
                }
                else if (respID == 403) {
                    MessageBox.Show("403 at URL " + url + "\nYou do not have access to this.");
                }
                else if (respID == 500) {
                    MessageBox.Show("500 at URL " + url + "\nAn error occured on the server. Try again later.");
                }
                else if (respID == 502) {
                    MessageBox.Show("502 at URL " + url + "\nBad gateway. Try again later.");
                }
                else if (respID == 503) {
                    MessageBox.Show("503 at URL " + url + "\nThe server is temporarily unavailable.\nTry again later, or decrease your downloads");
                }
                else {
                    MessageBox.Show(respID + " at URL " + url + "\nThe error is not documented in the source. It's either unrelated or not relevant.\nTry again, either now or later.");
                }
            }
        }
    }
}
