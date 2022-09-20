namespace youtube_dl_gui_updater;
internal static class Serializer {
    private static readonly System.Runtime.Serialization.Json.DataContractJsonSerializerSettings Settings = new() {
        UseSimpleDictionaryFormat = true,
        SerializeReadOnlyTypes = false,
    };
    public static T JsonDeserialize<T>(this string value) {
        using System.IO.MemoryStream ms = new(Encoding.UTF8.GetBytes(value));
        System.Runtime.Serialization.Json.DataContractJsonSerializer ser = new(typeof(T), Settings);
        T val = (T)ser.ReadObject(ms);
        ms.Close();
        return val;
    }
}