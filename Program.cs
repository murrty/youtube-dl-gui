using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtube_dl_gui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>


        [STAThread]
        static void Main()
        {
            if (PriorProcess() != null)
            {
                MessageBox.Show("Another instance of youtube-dl-gui is already running.");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
        public static Process PriorProcess()
        {
            Process currentProc = Process.GetCurrentProcess();
            Process[] listProcess = Process.GetProcessesByName(currentProc.ProcessName);
            foreach (Process retProcess in listProcess)
            {
                if ((retProcess.Id != currentProc.Id) &&
                    (retProcess.MainModule.FileName == currentProc.MainModule.FileName))
                    return retProcess;
            }
            return null;
        }
    }
}
