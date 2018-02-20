using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

internal class Controller {
    public const int HWND_BROADCAST = 0xffff;
    public static readonly int WM_SHOWFORM = RegisterWindowMessage("WM_SHOWFORM");
    [DllImport("user32")]
    public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
    [DllImport("user32")]
    public static extern int RegisterWindowMessage(string message);
}