using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtube_dl_gui {
    class ErrorLog {
        public static bool throwError(string errMessage) {
            if (Advanced.Default.disableErrors)
                return false;

            try {
                MessageBox.Show("An error has occured.\n\n" + errMessage);
                return true;
            } catch (Exception ex) {
                // How ironic.
                MessageBox.Show("An error occured while trying to retrieve the error.\nThe next two dialogs will be the error when writing the log and the error that occured before.\nBe sure to write down the gist of the error(s) or screenshot them.");
                MessageBox.Show(ex.ToString());
                MessageBox.Show(errMessage);
                return false;
            }
        }

        public static bool logError(string errMessage, string filename) {
            if (Advanced.Default.disableErrors)
                return false;

            try {
                if (filename.EndsWith(".log")) { filename = filename.Replace(".log", ""); }
                if (Settings.Default.logErrorFiles) { 
                    if (File.Exists(Application.StartupPath + @"\YChanEx Errors\" + filename + ".log"))
                        File.Delete(Application.StartupPath + @"\YChanEx Errors\" + filename + ".log");

                    File.Create(Application.StartupPath + @"\YChanEx Errors\" + filename + ".log").Dispose();
                    File.WriteAllText(Application.StartupPath + @"\YChanEx Errors\" + filename + ".log", errMessage);

                    MessageBox.Show("An error has occured and has been logged. Check \"\\YChanEx Errors\\\"" + filename + ".log for information.");
                }
                else { MessageBox.Show("An error has occured.\n\n" + errMessage.ToString(), filename); }
                return true;

            } catch (Exception ex) {
                MessageBox.Show("An error occured when writing the error to a log.\nThe next two dialogs will be the error when writing the log and the error that occured before.\nBe sure to write down the gist of the error(s) or screenshot them.");
                MessageBox.Show("Error writing the log:\n\n" + ex.ToString());
                MessageBox.Show("The original error that occured:\n\n" + errMessage);
                return false;
            }

        }
    }
}
