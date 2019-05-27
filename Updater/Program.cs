using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace youtube_dl_gui_updater {
    class Program {
        static void Main(string[] args) {
            // Arguemnt gets called, it's always the name of the executable.
            string ytdlExec = "youtube-dl-gui.exe";
            bool dontUpdate = false;
            if (args.Length > 0) {
                ytdlExec = args[0];
                if (args.Length == 2 && args[1].ToLower() == "true") {
                    dontUpdate = true;
                }
            }
            Console.WriteLine("*=========================*");
            Console.WriteLine("|  youtube-dl-gui updater |");
            Console.WriteLine("|      stub version 1     |");
            Console.WriteLine("*=========================*\n");

            if (dontUpdate) {
                Console.WriteLine("Sleeping for 999999");
                Thread.Sleep(999999);
                Environment.Exit(0);
            }

            Console.WriteLine("Killing all " + ytdlExec + " processes...");
            foreach (Process processName in Process.GetProcessesByName(ytdlExec))
                processName.Kill();
            Thread.Sleep(2500);

            Console.WriteLine("Checking for updated executable...\n");
            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\ydg.exe")) {
                Console.WriteLine("ydg.exe exists, assuming it's the new version...");

                Console.WriteLine("Deleting old youtube-dl-gui...");
                System.IO.File.Delete(Environment.CurrentDirectory + "\\" + ytdlExec);
                Console.WriteLine("Renaming updated version to old version's executable name...");
                System.IO.File.Move(Environment.CurrentDirectory + "\\ydg.exe", Environment.CurrentDirectory + "\\" + ytdlExec);

                Console.WriteLine("Update completed.");
                Console.WriteLine("Would you like to launch youtube-dl-gui after closing? (Y/N)");
                switch (Console.ReadKey(true).Key) {
                    case ConsoleKey.Y:
                        Process.Start(Environment.CurrentDirectory + "\\" + ytdlExec);
                        break;
                }

                Environment.Exit(0);
            }
            else {
                Console.WriteLine("/!\\ ydg.exe does not exist. No update has been downloaded. /!\\\nyoutube-dl-gui needs to be manually updated.\n\nPress any key to exit.\nAlternatively; Press 1 to go to download page.");
                switch (Console.ReadKey(true).Key) {
                    case ConsoleKey.D1:
                        Process.Start("https://github.com/murrty/youtube-dl-gui/releases");
                        Environment.Exit(0);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
