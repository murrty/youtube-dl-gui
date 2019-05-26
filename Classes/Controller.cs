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
}