using Microsoft.Win32;

internal class RegistryTool {
    public static bool CreateProtocol(string Protocol, string ApplicationPath, string OptionArguments) {
        try {
            Registry.ClassesRoot.CreateSubKey(Protocol);
            RegistryKey Identifier = Registry.ClassesRoot.OpenSubKey(Protocol, true);
            Identifier.SetValue("URL Protocol", "");
            Registry.ClassesRoot.CreateSubKey(Protocol + "\\shell");
            Registry.ClassesRoot.CreateSubKey(Protocol + "\\shell\\open");
            Registry.ClassesRoot.CreateSubKey(Protocol + "\\shell\\open\\command");
            RegistryKey setProtocol = Registry.ClassesRoot.OpenSubKey(Protocol + "\\shell\\open\\command", true);
            setProtocol.SetValue("", "\"" + ApplicationPath + "\" \"" + OptionArguments + " %1\"");
            Registry.ClassesRoot.CreateSubKey(Protocol + "\\DefaultIcon");
            RegistryKey setIcon = Registry.ClassesRoot.OpenSubKey(Protocol + "\\DefaultIcon", true);
            setIcon.SetValue("", "\"" + ApplicationPath + "\",1");

            return true;
        }
        catch {
            throw;
        }
    }

    public static bool ProtocolExists(string Protocol, string ExpectedValue = null) {
        try {
            RegistryKey OpenKey = Registry.ClassesRoot.OpenSubKey(Protocol);
            if (OpenKey != null && Registry.ClassesRoot.GetValue(Protocol, "URL Protocol") != null) {
                if (ExpectedValue != null) return Registry.ClassesRoot.OpenSubKey(Protocol + "\\shell\\open\\command").GetValue("").ToString().Equals(ExpectedValue);
                else return Registry.ClassesRoot.OpenSubKey(Protocol + "\\shell\\open\\command") != null;
            }
            else return false;
        }
        catch {
            throw;
        }
    }
}