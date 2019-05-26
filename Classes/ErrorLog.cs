using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace youtube_dl_gui {
    class ErrorLog {
        public static void reportWebError(WebException WebE, string YtDl) {
            System.Windows.Forms.MessageBox.Show("An exception occured while downloading " + YtDl + "\n\n" + WebE.ToString());
        }

        public static void reportError(string Exception) {
            System.Windows.Forms.MessageBox.Show("An exception occured\n\n" + Exception);
        }
    }
}
