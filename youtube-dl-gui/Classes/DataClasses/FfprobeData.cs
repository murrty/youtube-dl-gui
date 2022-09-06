namespace youtube_dl_gui;

using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading.Tasks;

//ffprobe -v quiet -print_format json -show_format -show_streams 

[DataContract]
public sealed class FfprobeData {

    public static FfprobeData GenerateData(string MediaFile, out string RetrievedData) {
        RetrievedData = null;
        if (!MediaFile.IsNullEmptyWhitespace() && File.Exists(MediaFile)) {
            if (Verification.FFprobePath.IsNullEmptyWhitespace())
                Verification.RefreshFFmpegLocation();

            if (Verification.FFprobePath.IsNullEmptyWhitespace())
                return null;

            Process Enumeration = new() {
                StartInfo = new() {
                    Arguments = $"-v quiet -print_format json -show_format -show_streams  \"{MediaFile}\"",
                    FileName = Verification.FFprobePath,
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                }
            };

            StringBuilder Output = new(string.Empty);
            StringBuilder Error = new(string.Empty);
            Enumeration.OutputDataReceived += (s, e) => Output.Append(e.Data);
            Enumeration.ErrorDataReceived += (s, e) => Error.Append(e.Data);
            Enumeration.Start();
            Enumeration.BeginOutputReadLine();
            Enumeration.BeginErrorReadLine();
            Enumeration.WaitForExit();

            if (!Error.ToString().IsNullEmptyWhitespace()) {
                Log.Write(Error.ToString());
            }
            if (!Output.ToString().IsNullEmptyWhitespace()) {
                RetrievedData = Output.ToString();
                try {
                    var data = RetrievedData.JsonDeserialize<FfprobeData>();
                    return data;
                }
                catch (Exception ex) {
                    Log.ReportException(ex, Output.ToString());
                }

            }
        }
        return null;
    }

    [DataMember(Name = "streams")]
    public FfprobeSubdata.Stream[] MediaStreams { get; set; }

    [DataMember(Name = "format")]
    public FfprobeSubdata.Format Format { get; set; }
}

public sealed class FfprobeSubdata {
    [DataContract(Name = "format")]
    public sealed class Format {
        [DataMember(Name = "filename")]
        public string filename { get; set; }

        [DataMember(Name = "format_name")]
        public string format_name { get; set; }

        [DataMember(Name = "format_long_name")]
        public string format_long_name { get; set; }

        [DataMember(Name = "bit_rate")]
        public string bit_rate { get; set; }
    }


    [DataContract(Name = "streams")]
    public sealed class Stream {
        [DataMember(Name = "index")]
        public int index { get; set; }

        [DataMember(Name = "codec_name")]
        public string codec_name { get; set; }

        [DataMember(Name = "codec_long_name")]
        public string codec_long_name { get; set; }

        [DataMember(Name = "codec_type")]
        public string codec_type { get; set; }

        [DataMember(Name = "codec_tag_string")]
        public string codec_tag_string { get; set; }

        [DataMember(Name = "codec_tag")]
        public string codec_tag { get; set; }

        [DataMember(Name = "sample_rate")]
        public string sample_rate { get; set; }

        [DataMember(Name = "channels")]
        public int channels { get; set; }

        [DataMember(Name = "channel_layout")]
        public string channel_layout { get; set; }

        [DataMember(Name = "bit_rate")]
        public string bit_rate { get; set; }
    }

}