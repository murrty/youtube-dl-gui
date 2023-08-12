using System.Text.RegularExpressions;
internal static class Extensions {
    private static readonly Regex WhitespaceCleaner = new(@"\s+", RegexOptions.Compiled);
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
    public static bool IsNotNullEmptyWhitespace(this string value) {
        if (value is null || value.Length == 0)
            return false;

        for (int i = 0; i < value.Length; i++) {
            if (!char.IsWhiteSpace(value[i]))
                return true;
        }

        return false;
    }
    public static string ReplaceWhitespace(this string str) => WhitespaceCleaner.Replace(str, " ");
    public static string ReplaceWhitespace(this string str, string replacement) => WhitespaceCleaner.Replace(str, replacement);
}