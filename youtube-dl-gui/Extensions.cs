namespace youtube_dl_gui;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Json;
internal static class Extensions {
    private static readonly DataContractJsonSerializerSettings Settings = new() {
        UseSimpleDictionaryFormat = true,
        SerializeReadOnlyTypes = false,
    };
    private static readonly Regex WhitespaceCleaner = new(@"\s+", RegexOptions.Compiled);
    public static T JsonDeserialize<T>(this string value) {
        using System.IO.MemoryStream ms = new(Encoding.UTF8.GetBytes(value));
        DataContractJsonSerializer ser = new(typeof(T), Settings);
        T val = (T)ser.ReadObject(ms);
        ms.Close();
        return val;
    }
    public static string SizeToString(this long Size, int DecimalPlaces = 2) {
        int DivisionCount = 0;
        decimal Division = Size;
        while (Math.Round(Division, DecimalPlaces) >= 1024m) {
            Division /= 1024m;
            DivisionCount++;
        }

        return $"{decimal.Round(Division, DecimalPlaces)}{DivisionCount switch {
            0 => "B",
            1 => "KiB",
            2 => "MiB",
            3 => "GiB",
            4 => "TiB",
            5 => "PiB",
            6 => "EiB",
            7 => "ZiB",
            8 => "YiB",
            _ => "?iB"
        }}";
    }
    public static string Format(this string str, params object[] objs) => string.Format(str, objs);
    public static bool IsNullEmptyWhitespace(this string value) {
        if (value is null || value.Length == 0)
            return true;

        for (int i = 0; i < value.Length; i++) {
            if (!char.IsWhiteSpace(value[i]))
                return false;
        }

        return true;
    }
    public static bool IsNotNullEmptyWhitespace(this string value) => !IsNullEmptyWhitespace(value);
    public static string Join(this IEnumerable<string> str, string joiner) => string.Join(joiner, str);
    public static string JoinUntilLimit(this string[] str, string joiner, int limit) {
        if (limit < 0)
            throw new ArgumentOutOfRangeException(nameof(limit));
        if (str is null)
            throw new NullReferenceException(nameof(str));
        if (joiner.IsNullEmptyWhitespace())
            throw new NullReferenceException($"{nameof(joiner)} is null, empty, or whitespace.");

        StringBuilder Builder = new(limit);
        for (int i = 0; i < str.Length; i++) {
            if (Builder.Length + str[i].Length <= limit)
                Builder.Append(str[i]);
            else break;
        }

        return Builder.ToString();
    }
    public static string ReplaceWhitespace(this string str) => WhitespaceCleaner.Replace(str, " ");
    public static string ReplaceWhitespace(this string str, string replacement) => WhitespaceCleaner.Replace(str, replacement);
    public static bool ForIf<T>(this T[] items, Func<T, bool> act) {
        for (int i = 0; i < items.Length; i++)
            if (act(items[i])) return true;
        return false;
    }
    public static void For<T>(this T[] items, Action<T> act) {
        if (items.Length > 0) {
            for (int i = 0; i < items.Length; i++) {
                act(items[i]);
            }
        }
    }
    public static void For<T>(this IList<T> items, Action<T> act) {
        if (items.Count > 0) {
            for (int i = 0; i < items.Count; i++)
                act(items[i]);
        }
    }
}