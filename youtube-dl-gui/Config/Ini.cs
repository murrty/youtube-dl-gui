namespace youtube_dl_gui;

using System.Drawing;
using System.Text;

internal class Ini {
    public static string Path = Environment.CurrentDirectory + "\\settings.ini";
    public static string ExecutableName = "youtube-dl-gui";

    private static string Read(string Key, string Section = null) {
        var Value = new StringBuilder(65535);
        NativeMethods.GetPrivateProfileString(Section ?? ExecutableName, Key, "", Value, 65535, Path);
        return Value.ToString();
    }
    private static void WriteString(string Key, string Value, string Section = null) {
        NativeMethods.WritePrivateProfileString(Section ?? ExecutableName, Key, Value, Path);
    }

    public static string ReadString(string Key, string Section = null) {
        return Read(Key, Section);
    }
    public static bool ReadBool(string Key, string Section = null) {
        return Read(Key, Section).ToLower() switch {
            "true" => true,
            _ => false
        };
    }
    public static int ReadInt(string Key, string Section = null) {
        return int.TryParse(Read(Key, Section), out int Value) ? Value : -1;
    }
    public static decimal ReadDecimal(string Key, string Section = null) {
        return decimal.TryParse(Read(Key, Section), out decimal Value) ? Value : -1;
    }
    public static Point ReadPoint(string Key, string Section = null) {
        string[] Value = Read(Key, Section).Split(',');
        if (Value.Length == 2 && int.TryParse(Value[0], out int OutX) && int.TryParse(Value[1], out int OutY)) {
            return new(OutX, OutY);
        }
        return new(-32000, -32000);
    }
    public static Size ReadSize(string Key, string Section = null) {
        string[] Value = Read(Key, Section).Split(',');
        if (Value.Length == 2 && int.TryParse(Value[0], out int OutW) && int.TryParse(Value[1], out int OutH)) {
            return new(OutW, OutH);
        }
        return new(-32000, -32000);
    }

    public static void Write(string Key, string Value, string Section = null) {
        WriteString(Key, Value, Section);
    }
    public static void Write(string Key, bool Value, string Section = null) {
        WriteString(Key, Value ? "True" : "False", Section);
    }
    public static void Write(string Key, int Value, string Section = null) {
        WriteString(Key, Value.ToString(), Section);
    }
    public static void Write(string Key, decimal Value, string Section = null) {
        WriteString(Key, Value.ToString(), Section);
    }
    public static void Write(string Key, Point Value, string Section = null) {
        WriteString(Key, $"{Value.X},{Value.Y}", Section);
    }
    public static void Write(string Key, Size Value, string Section = null) {
        WriteString(Key, $"{Value.Width},{Value.Height}", Section);
    }

    public static void DeleteKey(string Key, string Section = null) {
        Write(Key, null, Section ?? ExecutableName);
    }
    public static void DeleteSection(string Section = null) {
        Write(null, null, Section ?? ExecutableName);
    }

    public static bool KeyExists(string Key, string Section = null) {
        return ReadString(Key, Section ?? ExecutableName).Length > 0;
    }
}