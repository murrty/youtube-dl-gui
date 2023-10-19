#nullable enable
namespace youtube_dl_gui;

using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization;

/// <summary>
/// Represents the root of output json data from ffprobe
/// </summary>
[DataContract]
public sealed class FfprobeData {
    public static FfprobeData? GenerateData(string MediaFile, out string? RetrievedData) {
        RetrievedData = null;
        if (MediaFile.IsNullEmptyWhitespace() || !File.Exists(MediaFile)) {
            return null;
        }

        if (!Verification.FfprobeAvailable) {
            Verification.RefreshFFmpegLocation();
            if (!Verification.FfprobeAvailable) {
                return null;
            }
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

        if (Error.Length > 0) {
            Log.Write(Error.ToString());
        }

        if (Output.Length < 1) {
            return null;
        }

        RetrievedData = Output.ToString();
        FfprobeData? Data = null;

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
    public FfprobeSubdata.Stream[]? MediaStreams { get; set; }

    [DataMember(Name = "format")]
    public FfprobeSubdata.Format? Format { get; set; }

    [IgnoreDataMember]
    public string? FileName { get; set; }

    [IgnoreDataMember]
    public string? FilePath { get; set; }
}

/// <summary>
/// Represents sub-data for ffprobe instances.
/// </summary>
public sealed class FfprobeSubdata {
    [DataContract(Name = "format")]
    public sealed class Format {
        [DataMember(Name = "filename")]
        public string? filename { get; set; }

#if DEBUG
        [DataMember(Name = "nb_streams")]
        public int nb_streams { get; set; }

        [DataMember(Name = "nb_programs")]
        public int nb_programs { get; set; }

        [DataMember(Name = "format_name")]
        public string? format_name { get; set; }

        [DataMember(Name = "format_long_name")]
        public string? format_long_name { get; set; }

        [DataMember(Name = "start_time")]
        public string? start_time { get; set; }

        [DataMember(Name = "duration")]
        public string? duration { get; set; }

        [DataMember(Name = "size")]
        public string? size { get; set; }

        [DataMember(Name = "bit_rate")]
        public string? bit_rate { get; set; }

        [DataMember(Name = "probe_score")]
        public int probe_score { get; set; }

        [DataMember(Name = "tags")]
        public FormatTags? tags { get; set; }

        [IgnoreDataMember]
        public bool Selected { get; set; } = true;
#endif
    }

    [DataContract(Name = "streams")]
    public sealed class Stream {
        [DataMember(Name = "index")]
        public int index { get; set; }

        [DataMember(Name = "codec_name")]
        public string? codec_name { get; set; }

        [DataMember(Name = "codec_long_name")]
        public string? codec_long_name { get; set; }

        [DataMember(Name = "codec_type")]
        public string? codec_type { get; set; }

        [DataMember(Name = "width")]
        public int width { get; set; }

        [DataMember(Name = "height")]
        public int height { get; set; }

        [DataMember(Name = "coded_width")]
        public int coded_width { get; set; }

        [DataMember(Name = "coded_height")]
        public int coded_height { get; set; }

        [DataMember(Name = "display_aspect_ratio")]
        public string? display_aspect_ratio { get; set; }

        [DataMember(Name = "r_frame_rate")]
        public string? r_frame_rate { get; set; }

        [DataMember(Name = "avg_frame_rate")]
        public string? avg_frame_rate { get; set; }

        [DataMember(Name = "tags")]
        public StreamTags? tags { get; set; }

        [DataMember(Name = "sample_rate")]
        public string? sample_rate { get; set; }

        [DataMember(Name = "bit_rate")]
        public string? bit_rate { get; set; }

        [IgnoreDataMember]
        public System.Windows.Forms.TreeNode? Node { get; set; }

        [IgnoreDataMember]
        public System.Windows.Forms.TreeNode? QueuedNode { get; set; }

#if DEBUG
        [DataMember(Name = "profile")]
        public string? profile { get; set; }

        [DataMember(Name = "codec_tag_string")]
        public string? codec_tag_string { get; set; }

        [DataMember(Name = "codec_tag")]
        public string? codec_tag { get; set; }

        [DataMember(Name = "closed_captions")]
        public int closed_captions { get; set; }

        [DataMember(Name = "film_grain")]
        public int film_grain { get; set; }

        [DataMember(Name = "has_b_frames")]
        public int has_b_frames { get; set; }

        [DataMember(Name = "sample_aspect_ratio")]
        public string? sample_aspect_ratio { get; set; }

        [DataMember(Name = "pix_fmt")]
        public string? pix_fmt { get; set; }

        [DataMember(Name = "level")]
        public int level { get; set; }

        [DataMember(Name = "color_range")]
        public string? color_range { get; set; }

        [DataMember(Name = "color_space")]
        public string? color_space { get; set; }

        [DataMember(Name = "color_transfer")]
        public string? color_transfer { get; set; }

        [DataMember(Name = "color_primaries")]
        public string? color_primaries { get; set; }

        [DataMember(Name = "refs")]
        public int refs { get; set; }

        [DataMember(Name = "time_base")]
        public string? time_base { get; set; }

        [DataMember(Name = "start_pts")]
        public int start_pts { get; set; }

        [DataMember(Name = "start_time")]
        public string? start_time { get; set; }

        [DataMember(Name = "disposition")]
        public Disposition? disposition { get; set; }

        [DataMember(Name = "sample_fmt")]
        public string? sample_fmt { get; set; }

        [DataMember(Name = "channels")]
        public int channels { get; set; }

        [DataMember(Name = "channel_layout")]
        public string? channel_layout { get; set; }

        [DataMember(Name = "bits_per_sample")]
        public int bits_per_sample { get; set; }

        [DataMember(Name = "extradata_size")]
        public int extradata_size { get; set; }

        [DataMember(Name = "chroma_location")]
        public string? chroma_location { get; set; }

        [DataMember(Name = "field_order")]
        public string? field_order { get; set; }

        [DataMember(Name = "is_avc")]
        public string? is_avc { get; set; }

        [DataMember(Name = "nal_length_size")]
        public string? nal_length_size { get; set; }

        [DataMember(Name = "id")]
        public string? id { get; set; }

        [DataMember(Name = "duration_ts")]
        public long duration_ts { get; set; }

        [DataMember(Name = "duration")]
        public string? duration { get; set; }

        [DataMember(Name = "bits_per_raw_sample")]
        public string? bits_per_raw_sample { get; set; }

        [DataMember(Name = "side_data_list")]
        public Side_Data_List[]? side_data_list { get; set; }
#endif
    }

    [DataContract(Name = "tags")]
    public sealed class StreamTags {
        [DataMember(Name = "language")]
        public string? language { get; set; }

        [DataMember(Name = "title")]
        public string? title { get; set; }

        [DataMember(Name = "filename")]
        public string? filename { get; set; }

#if DEBUG
        [DataMember(Name = "DURATION")]
        public string? DURATION { get; set; }

        [DataMember(Name = "creation_time")]
        public string? creation_time { get; set; } // "creation_time": "2022-09-04T04:07:51.000000Z",

        [DataMember(Name = "handler_name")]
        public string? handler_name { get; set; }

        [DataMember(Name = "vendor_id")]
        public string? vendor_id { get; set; }

        [DataMember(Name = "comment")]
        public string? comment { get; set; }

        [DataMember(Name = "encoder")]
        public string? encoder { get; set; }

        [DataMember(Name = "BPS")]
        public string? BPS { get; set; }

        [DataMember(Name = "NUMBER_OF_FRAMES")]
        public string? NUMBER_OF_FRAMES { get; set; }

        [DataMember(Name = "NUMBER_OF_BYTES")]
        public string? NUMBER_OF_BYTES { get; set; }

        [DataMember(Name = "_STATISTICS_WRITING_APP")]
        public string? _STATISTICS_WRITING_APP { get; set; }

        [DataMember(Name = "_STATISTICS_WRITING_DATE_UTC")]
        public string? _STATISTICS_WRITING_DATE_UTC { get; set; }

        [DataMember(Name = "_STATISTICS_TAGS")]
        public string? _STATISTICS_TAGS { get; set; }

        [DataMember(Name = "BPSeng")]
        public string? BPSeng { get; set; }

        [DataMember(Name = "DURATIONeng")]
        public string? DURATIONeng { get; set; }

        [DataMember(Name = "NUMBER_OF_FRAMESeng")]
        public string? NUMBER_OF_FRAMESeng { get; set; }

        [DataMember(Name = "NUMBER_OF_BYTESeng")]
        public string? NUMBER_OF_BYTESeng { get; set; }

        [DataMember(Name = "_STATISTICS_WRITING_APPeng")]
        public string? _STATISTICS_WRITING_APPeng { get; set; }

        [DataMember(Name = "_STATISTICS_WRITING_DATE_UTCeng")]
        public string? _STATISTICS_WRITING_DATE_UTCeng { get; set; }

        [DataMember(Name = "_STATISTICS_TAGSeng")]
        public string? _STATISTICS_TAGSeng { get; set; }

        [DataMember(Name = "mimetype")]
        public string? mimetype { get; set; }
#endif
    }

#if DEBUG
    [DataContract(Name = "tags")]
    public sealed class FormatTags {
        [DataMember(Name = "ENCODER")]
        public string? ENCODER { get; set; }

        [DataMember(Name = "major_brand")]
        public string? major_brand { get; set; }

        [DataMember(Name = "minor_version")]
        public string? minor_version { get; set; }

        [DataMember(Name = "compatible_brands")]
        public string? compatible_brands { get; set; }

        [DataMember(Name = "creation_time")]
        public string? creation_time { get; set; } // "2022-09-04T04:07:51.000000Z"

        [DataMember(Name = "ALBUM")]
        public string? ALBUM { get; set; }

        [DataMember(Name = "album_artist")]
        public string? album_artist { get; set; }

        [DataMember(Name = "ARTIST")]
        public string? ARTIST { get; set; }

        [DataMember(Name = "DATE")]
        public string? DATE { get; set; }

        [DataMember(Name = "COMPOSER")]
        public string? COMPOSER { get; set; }

        [DataMember(Name = "CONDUCTOR")]
        public string? CONDUCTOR { get; set; }

        [DataMember(Name = "COPYRIGHT")]
        public string? COPYRIGHT { get; set; }

        [DataMember(Name = "CREDITS")]
        public string? CREDITS { get; set; }

        [DataMember(Name = "comment")]
        public string? comment { get; set; }

        [DataMember(Name = "ENCODEDBY")]
        public string? ENCODEDBY { get; set; }

        [DataMember(Name = "GENRE")]
        public string? GENRE { get; set; }

        [DataMember(Name = "LABEL")]
        public string? LABEL { get; set; }

        [DataMember(Name = "PMEDIA")]
        public string? PMEDIA { get; set; }

        [DataMember(Name = "PROVIDER")]
        public string? PROVIDER { get; set; }

        [DataMember(Name = "PUBLISHER")]
        public string? PUBLISHER { get; set; }

        [DataMember(Name = "RELEASECOUNTRY")]
        public string? RELEASECOUNTRY { get; set; }

        [DataMember(Name = "SOURCE")]
        public string? SOURCE { get; set; }

        [DataMember(Name = "TITLE")]
        public string? TITLE { get; set; }

        [DataMember(Name = "track")]
        public string? track { get; set; }

        [DataMember(Name = "TRACKTOTAL")]
        public string? TRACKTOTAL { get; set; }

        [DataMember(Name = "UPLOADER")]
        public string? UPLOADER { get; set; }

        [DataMember(Name = "WEBSITE")]
        public string? WEBSITE { get; set; }

        [DataMember(Name = "WORK")]
        public string? WORK { get; set; }

        [DataMember(Name = "WWWAUDIOFILE")]
        public string? WWWAUDIOFILE { get; set; }

        [DataMember(Name = "WWWAUDIOSOURCE")]
        public string? WWWAUDIOSOURCE { get; set; }

        [DataMember(Name = "title")]
        public string? title { get; set; }

        [DataMember(Name = "artist")]
        public string? artist { get; set; }

        [DataMember(Name = "album")]
        public string? album { get; set; }

        [DataMember(Name = "disc")]
        public string? disc { get; set; }

        [DataMember(Name = "genre")]
        public string? genre { get; set; }

        [DataMember(Name = "composer")]
        public string? composer { get; set; }

        [DataMember(Name = "lyricsXXX")]
        public string? lyricsXXX { get; set; }

        [DataMember(Name = "TLEN")]
        public string? TLEN { get; set; }

        [DataMember(Name = "TBPM")]
        public string? TBPM { get; set; }

        [DataMember(Name = "publisher")]
        public string? publisher { get; set; }

        [DataMember(Name = "TSRC")]
        public string? TSRC { get; set; }

        [DataMember(Name = "BARCODE")]
        public string? BARCODE { get; set; }

        [DataMember(Name = "ITUNESADVISORY")]
        public string? ITUNESADVISORY { get; set; }

        [DataMember(Name = "date")]
        public string? date { get; set; }

        [DataMember(Name = "encoder")]
        public string? encoder { get; set; }
    }

    [DataContract(Name = "disposition")]
    public sealed class Disposition {
        [DataMember(Name = "default")]
        public int _default { get; set; }

        [DataMember(Name = "dub")]
        public int dub { get; set; }

        [DataMember(Name = "original")]
        public int original { get; set; }

        [DataMember(Name = "comment")]
        public int comment { get; set; }

        [DataMember(Name = "lyrics")]
        public int lyrics { get; set; }

        [DataMember(Name = "karaoke")]
        public int karaoke { get; set; }

        [DataMember(Name = "forced")]
        public int forced { get; set; }

        [DataMember(Name = "hearing_impaired")]
        public int hearing_impaired { get; set; }

        [DataMember(Name = "visual_impaired")]
        public int visual_impaired { get; set; }

        [DataMember(Name = "clean_effects")]
        public int clean_effects { get; set; }

        [DataMember(Name = "attached_pic")]
        public int attached_pic { get; set; }

        [DataMember(Name = "timed_thumbnails")]
        public int timed_thumbnails { get; set; }

        [DataMember(Name = "captions")]
        public int captions { get; set; }

        [DataMember(Name = "descriptions")]
        public int descriptions { get; set; }

        [DataMember(Name = "metadata")]
        public int metadata { get; set; }

        [DataMember(Name = "dependent")]
        public int dependent { get; set; }

        [DataMember(Name = "still_image")]
        public int still_image { get; set; }
    }

    [DataContract(Name = "side_data_type")]
    public class Side_Data_List {
        [DataMember(Name = "side_data_type")]
        public string? side_data_type { get; set; }
    }
#endif
}

public sealed class FfprobeNodeTag(FfprobeData Parent, FfprobeSubdata.Stream stream) {
    public FfprobeData ParentFile { get; init; } = Parent;
    public FfprobeSubdata.Stream Stream { get; init; } = stream;
}