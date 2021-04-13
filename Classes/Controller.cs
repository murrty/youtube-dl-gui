using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;

internal class Controller {
    public static bool CreateProtocol() {
        try {
            Registry.ClassesRoot.CreateSubKey("ytdl");
            RegistryKey Identifier = Registry.ClassesRoot.OpenSubKey("ytdl", true);
            Identifier.SetValue("URL Protocol", "");
            Registry.ClassesRoot.CreateSubKey("ytdl\\shell");
            Registry.ClassesRoot.CreateSubKey("ytdl\\shell\\open");
            Registry.ClassesRoot.CreateSubKey("ytdl\\shell\\open\\command");
            RegistryKey setProtocol = Registry.ClassesRoot.OpenSubKey("ytdl\\shell\\open\\command", true);
            setProtocol.SetValue("", "\"" + Environment.CurrentDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName + "\" \" -download %1\"");
            Registry.ClassesRoot.CreateSubKey("ytdl\\DefaultIcon");
            RegistryKey setIcon = Registry.ClassesRoot.OpenSubKey("ytdl\\DefaultIcon", true);
            setIcon.SetValue("", "\"" + Environment.CurrentDirectory + "\\ytdl.exe\",1");

            return true;
        }
        catch (Exception ex) {
            youtube_dl_gui.ErrorLog.ReportException(ex);
            return false;
        }
    }
}