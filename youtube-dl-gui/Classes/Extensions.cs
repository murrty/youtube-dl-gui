namespace youtube_dl_gui;
using System.Text;
internal static class Extensions {
    private static readonly System.Runtime.Serialization.Json.DataContractJsonSerializerSettings Settings = new() {
        UseSimpleDictionaryFormat = true,
        SerializeReadOnlyTypes = false,
    };
    private static readonly System.Text.RegularExpressions.Regex WhitespaceCleaner = new(@"\s+", System.Text.RegularExpressions.RegexOptions.Compiled);
    public static T JsonDeserialize<T>(this string value) {
        using System.IO.MemoryStream ms = new(Encoding.UTF8.GetBytes(value));
        System.Runtime.Serialization.Json.DataContractJsonSerializer ser = new(typeof(T), Settings);
        T val = (T)ser.ReadObject(ms);
        ms.Close();
        return val;
    }
    private static readonly string[] SizeSuffix =
        { "B", "KiB", "MiB", "GiB", "TiB", "PiB", "EiB", "ZiB", "YiB" };
    public static string SizeToString(this long Size, int DecimalPlaces = 2) {
        int DivisionCount = 0;
        decimal Division = Size;
        while (Math.Round(Division, DecimalPlaces) >= 1024) {
            Division /= 1024;
            DivisionCount++;
        }
        return $"{decimal.Round(Division, DecimalPlaces)}{SizeSuffix[DivisionCount]}";
    }
    public static string Format(this string str, params object[] objs) {
        return String.Format(str, objs);
    }
    public static bool IsNullEmptyWhitespace(this string value) {
        if (value is null || value.Length == 0)
            return true;

        while (value[^1] == ' ')
            value = value[..^1];

        while (value[0] == ' ')
            value = value[1..];

        return value.Length == 0;
    }
    public static bool IsNotNullEmptyWhitespace(this string value) => !IsNullEmptyWhitespace(value);
    public static string Join(this IEnumerable<string> str, string joiner) => string.Join(joiner, str);
    public static string ReplaceWhitespace(this string str) => WhitespaceCleaner.Replace(str, " ");
    public static string ReplaceWhitespace(this string str, string replacement) => WhitespaceCleaner.Replace(str, replacement);
    public static void ShowIfCondition(this System.Windows.Forms.Form frm, bool AsDialog) {
        if (AsDialog) frm.ShowDialog();
        else frm.Show();
    }
    public static bool ForIf<T>(this T[] items, Func<T, bool> act) {
        for (int i = 0; i < items.Length; i++)
            if (act(items[i])) return true;
        return false;
    }
}