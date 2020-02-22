using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

internal class Controller {
    public const int HWND_YTDLGUIBROADCAST = 0xffff;
    public static readonly int WM_SHOWYTDLGUIFORM = RegisterWindowMessage("WM_SHOWYTDLGUIFORM");
    [DllImport("user32")]
    public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
    [DllImport("user32")]
    public static extern int RegisterWindowMessage(string message);

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
            throw ex;
        }
    }
}