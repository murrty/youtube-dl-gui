namespace youtube_dl_gui;

using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization;

/// <summary>
/// Represents the root of output json data from ffprobe
/// </summary>
[DataContract]
public sealed class FfprobeData {

    public static FfprobeData GenerateData(string MediaFile, out string RetrievedData) {
        RetrievedData = null;
        if (MediaFile.IsNullEmptyWhitespace() || !File.Exists(MediaFile))
            return null;

        if (!Verification.FfprobeAvailable) {
            Verification.RefreshFFmpegLocation();
            if (!Verification.FfprobeAvailable)
                return null;
        }

        Process Enumeration = new() {
            StartInfo = new() {
                Arguments = $"-v quiet -print_format json -show_format -show_streams \"{MediaFile}\"",
                FileName = Verification.FFprobePath,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                StandardErrorEncoding = Encoding.UTF8, //Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage),
                StandardOutputEncoding = Encoding.UTF8, //Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage),
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

        if (Error.Length > 0)
            Log.Write(Error.ToString());

        if (Output.Length < 1)
            return null;

        RetrievedData = Output.ToString();
        FfprobeData Data = null;

        try {
            Data = RetrievedData.JsonDeserialize<FfprobeData>();
        }
        catch (Exception ex) {
            Log.ReportException(ex, Output.ToString());
            Data = null;
        }

        return Data;
    }

    [DataMember(Name = "streams")]
    public FfprobeSubdata.Stream[] MediaStreams { get; set; }

    [DataMember(Name = "format")]
    public FfprobeSubdata.Format Format { get; set; }

    [IgnoreDataMember]
    public string FileName { get; set; }

    [IgnoreDataMember]
    public string FilePath { get; set; }
}

/// <summary>
/// Represents sub-data for ffprobe instances.
/// </summary>
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


        /// <summary>
        /// ///////////////////////////////////////////////////////////
        /// </summary>

        [DataMember(Name = "profile")]
        public string profile { get; set; }

        [DataMember(Name = "width")]
        public int width { get; set; }

        [DataMember(Name = "height")]
        public int height { get; set; }

        [DataMember(Name = "coded_width")]
        public int coded_width { get; set; }

        [DataMember(Name = "coded_height")]
        public int coded_height { get; set; }

        [DataMember(Name = "closed_captions")]
        public int closed_captions { get; set; }

        [DataMember(Name = "film_grain")]
        public int film_grain { get; set; }

        [DataMember(Name = "has_b_frames")]
        public int has_b_frames { get; set; }

        [DataMember(Name = "sample_aspect_ratio")]
        public string sample_aspect_ratio { get; set; }

        [DataMember(Name = "display_aspect_ratio")]
        public string display_aspect_ratio { get; set; }

        [DataMember(Name = "pix_fmt")]
        public string pix_fmt { get; set; }

        [DataMember(Name = "level")]
        public int level { get; set; }

        [DataMember(Name = "color_range")]
        public string color_range { get; set; }

        [DataMember(Name = "color_space")]
        public string color_space { get; set; }

        [DataMember(Name = "color_transfer")]
        public string color_transfer { get; set; }

        [DataMember(Name = "color_primaries")]
        public string color_primaries { get; set; }

        [DataMember(Name = "refs")]
        public int refs { get; set; }

        [DataMember(Name = "r_frame_rate")]
        public string r_frame_rate { get; set; }

        [DataMember(Name = "avg_frame_rate")]
        public string avg_frame_rate { get; set; }

        [DataMember(Name = "time_base")]
        public string time_base { get; set; }

        [DataMember(Name = "start_pts")]
        public int start_pts { get; set; }

        [DataMember(Name = "start_time")]
        public string start_time { get; set; }

        [DataMember(Name = "sample_fmt")]
        public string sample_fmt { get; set; }

        [DataMember(Name = "bits_per_sample")]
        public int bits_per_sample { get; set; }

        [DataMember(Name = "extradata_size")]
        public int extradata_size { get; set; }

        [DataMember(Name = "chroma_location")]
        public string chroma_location { get; set; }

        [DataMember(Name = "field_order")]
        public string field_order { get; set; }

        [DataMember(Name = "is_avc")]
        public string is_avc { get; set; }

        [DataMember(Name = "nal_length_size")]
        public string nal_length_size { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "duration_ts")]
        public long duration_ts { get; set; }

        [DataMember(Name = "duration")]
        public string duration { get; set; }

        [DataMember(Name = "bits_per_raw_sample")]
        public string bits_per_raw_sample { get; set; }

        [IgnoreDataMember]
        public System.Windows.Forms.TreeNode Node { get; set; }

        [IgnoreDataMember]
        public System.Windows.Forms.TreeNode QueuedNode { get; set; }
    }

    [DataContract(Name = "tags")]
    public sealed class Tags {
        [DataMember(Name = "language")]
        public string language { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "duration")]
        public string duration { get; set; }

        [DataMember(Name = "number_of_frames")]
        public string number_of_frames { get; set; }

        [DataMember(Name = "number_of_bytes")]
        public string number_of_bytes { get; set; }
    }
}

public sealed class FfprobeNodeTag {
    public FfprobeData ParentFile { get; init; }
    public FfprobeSubdata.Stream Stream { get; init; }
}