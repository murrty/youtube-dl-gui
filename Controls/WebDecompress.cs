namespace murrty.controls;

using System.IO.Compression;
using System.IO;
using System.Threading.Tasks;

internal static class WebDecompress {
    public static async Task<byte[]> GetGZip(Stream input) {
        using MemoryStream Destination = new();

        if (input.CanSeek)
            input.Position = 0;
        using GZipStream DecompressorStream = new(input, CompressionMode.Decompress);
        await DecompressorStream.CopyToAsync(Destination);

        Destination.Close();
        byte[] Bytes = Destination.ToArray();
        return Bytes;
    }
    public static async Task<byte[]> GetDeflate(Stream input) {
        using MemoryStream Destination = new();

        if (input.CanSeek)
            input.Position = 0;
        using DeflateStream DecompressorStream = new(input, CompressionMode.Decompress);
        await DecompressorStream.CopyToAsync(input);

        Destination.Close();
        byte[] Bytes = Destination.ToArray();
        return Bytes;
    }
    public static async Task<byte[]> GetRaw(Stream input) {
        using MemoryStream Destination = new();

        if (input.CanSeek)
            input.Position = 0;
        await input.CopyToAsync(Destination);

        Destination.Close();
        byte[] Bytes = Destination.ToArray();
        return Bytes;
    }
}