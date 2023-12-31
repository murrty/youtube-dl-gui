#nullable enable
namespace youtube_dl_gui;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Json;
[System.Diagnostics.DebuggerStepThrough]
internal static class Extensions {
    private static readonly DataContractJsonSerializerSettings Settings = new() {
        UseSimpleDictionaryFormat = true,
        SerializeReadOnlyTypes = false,
    };
    public static T JsonDeserialize<T>(this string value) {
        using System.IO.MemoryStream ms = new(Encoding.UTF8.GetBytes(value));
        DataContractJsonSerializer ser = new(typeof(T), Settings);
        T val = (T)ser.ReadObject(ms);
        ms.Close();
        return val;
    }
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
    public static bool ForIfReverse<T>(this T[] items, Func<T, bool> act) {
        for (int i = items.Length - 1; i > -1; i--)
            if (act(items[i])) return true;
        return false;
    }
    public static void ForReverse<T>(this T[] items, Action<T> act) {
        if (items.Length > 0) {
            for (int i = items.Length - 1; i > -1; i--) {
                act(items[i]);
            }
        }
    }
    public static void ForReverse<T>(this IList<T> items, Action<T> act) {
        if (items.Count > 0) {
            for (int i = items.Count - 1; i > -1; i--)
                act(items[i]);
        }
    }
}