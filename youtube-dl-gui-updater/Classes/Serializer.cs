namespace youtube_dl_gui_updater;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
internal static class Serializer {
    private static readonly DataContractJsonSerializerSettings Settings = new() {
        UseSimpleDictionaryFormat = true,
        SerializeReadOnlyTypes = false,
    };
    public static async Task<T> JsonDeserializeAsync<T>(this string JSON) {
        T ReturnData = default;

        await Task.Run(() => {
            using MemoryStream Stream = new(Encoding.UTF8.GetBytes(JSON));
            DataContractJsonSerializer Serializer = new(typeof(T), Settings);
            ReturnData = (T)Serializer.ReadObject(Stream);
            Stream.Close();
        });

        return ReturnData;
    }
}