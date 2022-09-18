namespace youtube_dl_gui;

using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

internal static class Ini {
    private const String EmptyString = "${empty_key_value}$";
    public static string IniPath = Environment.CurrentDirectory + "\\settings.ini";

    private static bool InternalKeyExists(String Key, out String Value, String Section = null) {
        StringBuilder ReadValue = new(65535);
        NativeMethods.GetPrivateProfileString(Section ?? Language.ApplicationName, Key, EmptyString, ReadValue, ReadValue.Capacity, IniPath);
        Value = ReadValue.ToString();
        Value = Value != EmptyString && !Value.IsNullEmptyWhitespace() ? Value : null;
        return Value is not null;
    }
    private static string InternalWriteString(String Key, String Value, String Section = null) {
        NativeMethods.WritePrivateProfileString(Section ?? Language.ApplicationName, Key, Value, IniPath);
        return Value;
    }

#pragma warning disable IDE0060 // Remove unused parameter
    public static string Read(string Value, string Default, string Section = null, [CallerArgumentExpression("Value")] String Key = null) {
        if (InternalKeyExists(Key, out string Data, Section ?? Language.ApplicationName))
            return Data;
        return Default;
    }
    public static bool Read(bool Value, bool Default, string Section = null, [CallerArgumentExpression("Value")] String Key = null) {
        if (InternalKeyExists(Key, out string Data, Section ?? Language.ApplicationName))
            return Data.ToLower() switch {
                "true" or "on" or "1" => true,
                _ => false
            };
        return Default;
    }
    public static int Read(int Value, int Default, string Section = null, [CallerArgumentExpression("Value")] String Key = null) {
        if (InternalKeyExists(Key, out string Data, Section ?? Language.ApplicationName) && int.TryParse(Data, out int NewVal))
            return NewVal;
        return Default;
    }
    public static decimal Read(decimal Value, decimal Default, string Section = null, [CallerArgumentExpression("Value")] String Key = null) {
        if (InternalKeyExists(Key, out string Data, Section ?? Language.ApplicationName) && decimal.TryParse(Data, out decimal NewVal))
            return NewVal;
        return Default;
    }
    public static Point Read(Point Value, Point Default, string Section = null, [CallerArgumentExpression("Value")] String Key = null) {
        if (InternalKeyExists(Key, out string Data, Section ?? Language.ApplicationName)) {
            string[] DataSplit = Data.ReplaceWhitespace().Split(',');
            if (DataSplit.Length >= 2 && int.TryParse(DataSplit[0], out int X) && int.TryParse(DataSplit[1], out int Y))
                return new(X, Y);
        }
        return Default;
    }
    public static Size Read(Size Value, Size Default, string Section = null, [CallerArgumentExpression("Value")] String Key = null) {
        if (InternalKeyExists(Key, out string Data, Section ?? Language.ApplicationName)) {
            string[] DataSplit = Data.ReplaceWhitespace().Split(',');
            if (DataSplit.Length >= 2 && int.TryParse(DataSplit[0], out int W) && int.TryParse(DataSplit[1], out int H))
                return new(W, H);
        }
        return Default;
    }
    public static Version Read(Version Value, Version Default, string Section = null, [CallerArgumentExpression("Value")] String Key = null) {
        if (InternalKeyExists(Key, out string Data, Section ?? Language.ApplicationName) && Version.TryParse(Data, out Version NewVers))
            return NewVers;
        return Default;
    }
#pragma warning restore IDE0060 // Remove unused parameter

    public static string Write(string Value, string Section = null, [CallerArgumentExpression("Value")] String Key = null) {
        InternalWriteString(Key, Value, Section ?? Language.ApplicationName);
        return Value;
    }
    public static bool Write(bool Value, string Section = null, [CallerArgumentExpression("Value")] String Key = null) {
        InternalWriteString(Key, Value ? "True" : "False", Section ?? Language.ApplicationName);
        return Value;
    }
    public static int Write(int Value, string Section = null, [CallerArgumentExpression("Value")] String Key = null) {
        InternalWriteString(Key, Value.ToString(), Section ?? Language.ApplicationName);
        return Value;
    }
    public static decimal Write(decimal Value, string Section = null, [CallerArgumentExpression("Value")] String Key = null) {
        InternalWriteString(Key, Value.ToString(), Section ?? Language.ApplicationName);
        return Value;
    }
    public static Point Write(Point Value, string Section = null, [CallerArgumentExpression("Value")] String Key = null) {
        InternalWriteString(Key, $"{Value.X},{Value.Y}", Section ?? Language.ApplicationName);
        return Value;
    }
    public static Size Write(Size Value, string Section = null, [CallerArgumentExpression("Value")] String Key = null) {
        InternalWriteString(Key, $"{Value.Width},{Value.Height}", Section ?? Language.ApplicationName);
        return Value;
    }
    public static Version Write(Version Value, string Section = null, [CallerArgumentExpression("Value")] String Key = null) {
        InternalWriteString(Key, Value.ToString(), Section ?? Language.ApplicationName);
        return Value;
    }

    public static void DeleteKey(string Key, string Section = null) {
        InternalWriteString(Key, null, Section ?? Language.ApplicationName);
    }
    public static void DeleteSection(string Section = null) {
        InternalWriteString(null, null, Section ?? Language.ApplicationName);
    }
}