namespace youtube_dl_gui;
using Microsoft.Win32;
internal static class SystemRegistry {
    /// <summary>
    /// Checks the registry for the protocol.
    /// </summary>
    /// <returns><see langword="true"/> if the registry for the protocol exists and points to the current application path; otherwise, <see langword="false"/>.</returns>
    public static bool CheckRegistry() {
        RegistryKey ProtocolKey = Registry.ClassesRoot.OpenSubKey("ytdlgui", false);
        
        bool Available = ProtocolKey is not null &&
            ProtocolKey.GetValue("URL Protocol") is not null &&
            ProtocolKey.OpenSubKey("shell\\open\\command").GetValue("").ToString().ToLowerInvariant() == $"\"{Program.FullProgramPath}\" \"%1\"".ToLowerInvariant();
        
        ProtocolKey.Close();
        ProtocolKey.Dispose();
        
        return Available;
    }
    /// <summary>
    /// Creates or modifies the registry to the current application path.
    /// </summary>
    /// <returns>An int value based on the success, with 0 being successful and non-zero indicating an error.</returns>
    public static int SetRegistry() {
        if (!Program.IsAdmin)
            return 2;

        try {
            RegistryKey ProtocolKey = Registry.ClassesRoot.CreateSubKey("ytdlgui", true);
            ProtocolKey.SetValue("URL Protocol", "");

            RegistryKey InUseKey = ProtocolKey.CreateSubKey("shell\\open\\command");
            InUseKey.SetValue("", $"\"{Program.FullProgramPath}\" \"%1\"");
            InUseKey.Close();

            InUseKey = ProtocolKey.CreateSubKey("DefaultIcon", true);
            InUseKey.SetValue("", $"\"{Program.FullProgramPath}\",0");
            InUseKey.Close();

            InUseKey.Dispose();

            return 0;
        }
        catch (Exception ex) {
            Log.ReportException(ex);
            return 1;
        }
    }
}