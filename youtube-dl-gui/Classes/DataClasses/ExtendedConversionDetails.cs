namespace youtube_dl_gui;

using System.Windows.Forms;
using murrty.controls;

internal sealed class ExtendedConversionDetails {
    /// <summary>
    /// The input file that will be the source.
    /// </summary>
    public required string InputFilePath { get; init; }
    /// <summary>
    /// The output file that will be converted to.
    /// </summary>
    public string OutputFilePath { get; set; } = null;
    
    /// <summary>
    /// Gets whether the info for this conversion instance was retrieved.
    /// </summary>
    public bool InfoRetrieved { get; private set; } = false;
    /// <summary>
    /// Gets the arguments that have been generated when <see cref="GenerateArguments"/> is called.
    /// </summary>
    public string Arguments { get; private set; } = null;
    /// <summary>
    /// Gets whether the substreams (subtitles, attachments, data) for this instance have to be extracted instead of included.
    /// <para/>
    /// Only MKV and WebM allow substreams to be embedded.
    /// </summary>
    public bool ExtractSubstreams { get; private set; } = false;

    /// <summary>
    /// The custom arguments that the conversion will use instead of auto-generation.
    /// <para/>
    /// If this is not <see langword="NULL"/>, empty, or whitespace, it will override generated arguments.
    /// </summary>
    public string CustomArguments { get; set; } = null;
    /// <summary>
    /// The partial-custom arguments that will be included with the generated arguments.
    /// <para/>
    /// This will not be concated with <see cref="CustomArguments"/> if they are used.
    /// </summary>
    public string PartialCustomArguments { get; set; } = null;

    /// <summary>
    /// Gets the ffprobe data instance that contains ffprobe data for this instance.
    /// </summary>
    public FfprobeData ProbeData { get; set; } = null;
    /// <summary>
    /// Gets the QueueItem for a batch conversion relating to this instance.
    /// </summary>
    public ListViewItem QueueItem { get; set; } = null;

    /// <summary>
    /// Gets a list of known video <see cref="FfprobeSubdata.Stream"/> objects.
    /// </summary>
    public List<FfprobeSubdata.Stream> VideoStreams { get; set; } = new();
    /// <summary>
    /// Gets a list of list view items for known video streams.
    /// </summary>
    public List<ListViewItem> VideoItems { get; set; } = new();

    /// <summary>
    /// Gets a list of known audio <see cref="FfprobeSubdata.Stream"/> objects.
    /// </summary>
    public List<FfprobeSubdata.Stream> AudioStreams { get; set; } = new();
    /// <summary>
    /// Gets a list of list view items for known audio streams.
    /// </summary>
    public List<ListViewItem> AudioItems { get; set; } = new();

    /// <summary>
    /// Gets a list of known subtitle <see cref="FfprobeSubdata.Stream"/> objects.
    /// </summary>
    public List<FfprobeSubdata.Stream> Subtitles { get; set; } = new();
    /// <summary>
    /// Gets a list of list view items for known subtitles.
    /// </summary>
    public List<ListViewItem> SubtitleItems { get; set; } = new();

    /// <summary>
    /// Gets a list of known attachment <see cref="FfprobeSubdata.Stream"/> objects.
    /// </summary>
    public List<FfprobeSubdata.Stream> Attachments { get; set; } = new();
    /// <summary>
    /// Gets a list of list view items for known attachments.
    /// </summary>
    public List<ListViewItem> AttachmentItems { get; set; } = new();

    /// <summary>
    /// Gets a list of known data file <see cref="FfprobeSubdata.Stream"/> objects.
    /// </summary>
    public List<FfprobeSubdata.Stream> DataFiles { get; set; } = new();
    /// <summary>
    /// Gets a list of list view items for known data files.
    /// </summary>
    public List<ListViewItem> DataFileItems { get; set; } = new();

    /// <summary>
    /// Gets a list of enabled video streams for this conversion instance.
    /// </summary>
    public List<int> EnabledVideoStreams { get; } = new();
    /// <summary>
    /// Gets a list of enabled audio streams for this conversion instance.
    /// </summary>
    public List<int> EnabledAudioStreams { get; } = new();
    /// <summary>
    /// Gets a list of enabled subtitles for this conversion instance.
    /// </summary>
    public List<int> EnabledSubtitles { get; } = new();
    /// <summary>
    /// Gets a list of enabled attachments for this conversion instance.
    /// </summary>
    public List<int> EnabledAttachments { get; } = new();
    /// <summary>
    /// Gets a list of enabled data files for this conversion instance.
    /// </summary>
    public List<int> EnabledDataFiles { get; } = new();
    /// <summary>
    /// Gets a list of all enabled streams for this conversion instance.
    /// </summary>
    public List<int> TotalEnabledStreams { get; } = new();

    /// <summary>
    /// Removes any non-critical metadata information from the output.
    /// </summary>
    public bool RemoveMetadata { get; set; } = false;
    /// <summary>
    /// Does not embed ffmpeg-related metadata to the output.
    /// </summary>
    public bool HideFfmpegMetadata { get; set; } = false;
    /// <summary>
    /// Copies the codec from the input to the output.
    /// <para/>
    /// May not allow conversion if the codec cannot be stored in the container.
    /// </summary>
    public bool CopyCodecs { get; set; } = false;
    /// <summary>
    /// Specifies a starting time to start the conversion from. Anything before this time will not be included in the output.
    /// <para/>
    /// If <see cref="EndTime"/> is not specified it will only skip the parts of the media before <see cref="StartTime"/>.
    /// </summary>
    public Time StartTime { get; set; } = Time.Empty;
    /// <summary>
    /// Specifies a ending time to end the conversion at. Anything after this time will not be included in the output.
    /// <para/>
    /// If <see cref="StartTime"/> is not specified, it will only skip the parts of the media after <see cref="EndTime"/>.
    /// </summary>
    public Time EndTime { get; set; } = Time.Empty;
    /// <summary>
    /// Determines whether to add Video or Audio arguments.
    /// </summary>
    public ConversionType Type { get; set; } = ConversionType.Unspecified;

    /// <summary>
    /// The bitrate (in KBs) that the video streams will be encoded to.
    /// <para/>
    /// If <see cref="CopyCodecs"/> is true, it will re-encode to the new bitrate.
    /// </summary>
    public decimal VideoBitrate { get; set; } = 0;
    /// <summary>
    /// "The preset that will be used during video encoding.
    /// </summary>
    public VideoPresets VideoPreset { get; set; } = VideoPresets.none;
    /// <summary>
    /// The profile that will be used during video encoding.
    /// </summary>
    public VideoProfiles VideoProfile { get; set; } = VideoProfiles.none;
    /// <summary>
    /// Whether to use Constant Rate Factor, which is used for higher qualities with less regard for file size.
    /// <para/>
    /// If <see cref="CopyCodecs"/> is true, it will re-encode for the new CRF value.
    /// </summary>
    public bool VideoUseCRF { get; set; } = false;
    /// <summary>
    /// The Constant Rate Factor to use for encoding.
    /// </summary>
    public int VideoCRF { get; set; } = 0;
    /// <summary>
    /// Moves the MOOV atom to the start of the video.
    /// </summary>
    public bool VideoFastStart { get; set; } = false;

    /// <summary>
    /// The bitrate (in KBs) that the audio streams will be encoded to.
    /// <para/>
    /// If <see cref="CopyCodecs"/> is true, it will re-encode to the new bitrate.
    /// </summary>
    public decimal AudioBitrate { get; set; } = 0;
    /// <summary>
    /// Whether to use Variable Bitrate (as apposed to Constant Bitrate), which is a more storage-saving encoding method that adjusts the bitrate over time.
    /// </summary>
    public bool AudioUseVBR { get; set; } = false;
    /// <summary>
    /// The Variable Bitrate value to use during encoding, with a valid range between 0-10.
    /// <para/>
    /// 0 is conisdered the best quality, while 10 is considered the worst.
    /// </summary>
    public int AudioVBR { get; set; } = 0;
    /// <summary>
    /// The sample rate that will be encoded into audio streams.
    /// <para/>
    /// If <see cref="CopyCodecs"/> is true, it will re-encode for the new sample rate.
    /// </summary>
    public AudioSampleRates AudioSampleRate { get; set; } = AudioSampleRates.none;

    private bool ShouldExtractSubstreams() {
        return OutputFilePath.ToLowerInvariant()[OutputFilePath.LastIndexOf('.')..] switch {
            ".webm" => false,
            ".mkv" => false,
            _ => true,
        };
    }

    /// <summary>
    /// Aggregates information for the input media file.
    /// </summary>
    public void GetMediaInfo() {
        if (InfoRetrieved)
            return;

        RetrieveInfo_Ffprobe();
    }

    private void RetrieveInfo_Ffprobe() {
        if (InputFilePath.IsNullEmptyWhitespace())
            throw new ArgumentNullException(nameof(InputFilePath));

        ProbeData = FfprobeData.GenerateData(InputFilePath, out _);
        if (ProbeData is null || ProbeData.MediaStreams is null || ProbeData.MediaStreams.Length < 1)
            throw new ArgumentException(nameof(InputFilePath));

        FfprobeSubdata.Stream Stream;
        StringBuilder Display = new();
        string[] Framerate;
        for (int i = 0; i < ProbeData.MediaStreams.Length; i++) {
            Stream = ProbeData.MediaStreams[i];
            switch (Stream.codec_type.ToLowerInvariant()) {
                case "video": {
                    VideoStreams.Add(Stream);
                    ListViewItem NewStream = new((i + 1).ToString()) {
                        Tag = Stream,
                        Checked = true,
                    };
                    NewStream.SubItems.Add(Stream.tags is null ? Stream.codec_name : Stream.tags.title ?? Stream.codec_name ?? "-");
                    NewStream.SubItems.Add(Stream.codec_long_name ?? "-");
                    Display.Clear();

                    if (Stream.width > 0)
                        Display.Append(Stream.width);
                    else if (Stream.coded_width > 0)
                        Display.Append(Stream.coded_width);
                    else Display.Append("?");

                    Display.Append("x");

                    if (Stream.height > 0)
                        Display.Append(Stream.height);
                    else if (Stream.coded_height > 0)
                        Display.Append(Stream.coded_height);
                    else Display.Append("?");

                    if (Stream.display_aspect_ratio.IsNotNullEmptyWhitespace()) {
                        if (Display.Length > 0)
                            Display.Append(" / ");
                        Display.Append(Stream.display_aspect_ratio);
                    }

                    if (Stream.avg_frame_rate.IsNotNullEmptyWhitespace() &&
                    (Framerate = Stream.avg_frame_rate.Split('/')).Length >= 2 &&
                    int.TryParse(Framerate[0], out int A) && int.TryParse(Framerate[1], out int B)) {
                        if (Display.Length > 0)
                            Display.Append(" / ");
                        Display.Append($"{(decimal)A / B} fps");
                    }
                    else if (Stream.r_frame_rate.IsNotNullEmptyWhitespace() &&
                    (Framerate = Stream.r_frame_rate.Split('/')).Length >= 2 &&
                    int.TryParse(Framerate[0], out A) && int.TryParse(Framerate[1], out B)) {
                        if (Display.Length > 0)
                            Display.Append(" / ");
                        Display.Append($"{(decimal)A / B} fps");
                    }

                    NewStream.SubItems.Add(Display.Length > 0 ? Display.ToString() : "-");
                    VideoItems.Add(NewStream);
                }
                break;

                case "audio": {
                    AudioStreams.Add(Stream);
                    ListViewItem NewStream = new((i + 1).ToString()) {
                        Tag = Stream,
                        Checked = true,
                    };
                    NewStream.SubItems.Add(Stream.tags is null ? Stream.codec_name : Stream.tags.title ?? Stream.codec_name ?? "-");
                    NewStream.SubItems.Add(Stream.codec_long_name ?? "-");
                    NewStream.SubItems.Add(Stream.bit_rate);
                    NewStream.SubItems.Add(Stream.sample_rate);
                    AudioItems.Add(NewStream);
                }
                break;

                case "subtitle":
                case "subtitles":
                case "text": {
                    Subtitles.Add(Stream);
                    ListViewItem NewStream = new((i + 1).ToString()) {
                        Tag = Stream,
                        Checked = true,
                    };
                    NewStream.SubItems.Add(Stream.tags is null ? Stream.codec_name : Stream.tags.title ?? Stream.codec_name ?? "-");
                    NewStream.SubItems.Add(Stream.tags.language ?? "-");
                    NewStream.SubItems.Add(Stream.codec_long_name);
                    SubtitleItems.Add(NewStream);
                }
                break;

                case "attachments":
                case "attachment": {
                    Attachments.Add(Stream);
                    ListViewItem NewStream = new((i + 1).ToString()) {
                        Tag = Stream,
                        Checked = true,
                    };
                    NewStream.SubItems.Add(Stream.tags is null ? Stream.codec_name : Stream.tags.filename ?? Stream.codec_name ?? "-");
                    NewStream.SubItems.Add(Stream.codec_long_name ?? "-");
                    AttachmentItems.Add(NewStream);
                }
                break;

                case "data": {
                    DataFiles.Add(Stream);
                    ListViewItem NewStream = new((i + 1).ToString()) {
                        Tag = Stream,
                        Checked = true,
                    };
                    NewStream.SubItems.Add(Stream.tags is null ? Stream.codec_name : Stream.tags.title ?? Stream.codec_name ?? "-");
                    DataFileItems.Add(NewStream);
                }
                break;
            }
        }
    }

    /// <summary>
    /// Generates arguments for this instance
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidProgramException"></exception>
    public string GenerateArguments() {
        if (!InfoRetrieved)
            throw new ArgumentException(nameof(FfprobeData));

        if (!Arguments.IsNullEmptyWhitespace())
            return Arguments;

        StringBuilder Args = new();
        Args.AppendArg($"-i \"{InputFilePath}\"");

        bool VideoStreams = false;
        bool AudioStreams = false;

        // TODO: Implement subtitle extraction instead of mapping into output if output is MP4.

        #region Stream removal
        EnabledVideoStreams.Clear();
        EnabledAudioStreams.Clear();
        EnabledSubtitles.Clear();
        EnabledSubtitles.Clear();
        EnabledDataFiles.Clear();
        TotalEnabledStreams.Clear();

        if (VideoItems.Count > 0) {
            for (int i = 0; i < VideoItems.Count; i++) {
                if (VideoItems[i].Checked) {
                    int Index = (VideoItems[i].Tag as FfprobeSubdata.Stream).index;
                    EnabledVideoStreams.Add(Index);
                    TotalEnabledStreams.Add(Index);
                }
            }
            VideoStreams = EnabledVideoStreams.Count > 0;
        }
        if (AudioItems.Count > 0) {
            for (int i = 0; i < AudioItems.Count; i++) {
                if (AudioItems[i].Checked) {
                    int Index = (AudioItems[i].Tag as FfprobeSubdata.Stream).index;
                    EnabledAudioStreams.Add(Index);
                    TotalEnabledStreams.Add(Index);
                }
            }
            AudioStreams = EnabledAudioStreams.Count > 0;
        }

        if (SubtitleItems.Count > 0) {
            for (int i = 0; i < SubtitleItems.Count; i++) {
                if (SubtitleItems[i].Checked) {
                    int Index = (SubtitleItems[i].Tag as FfprobeSubdata.Stream).index;
                    EnabledSubtitles.Add(Index);
                    TotalEnabledStreams.Add(Index);
                }
            }
        }
        if (AttachmentItems.Count > 0) {
            for (int i = 0; i < AttachmentItems.Count; i++) {
                if (AttachmentItems[i].Checked) {
                    int Index = (AttachmentItems[i].Tag as FfprobeSubdata.Stream).index;
                    EnabledAttachments.Add(Index);
                    TotalEnabledStreams.Add(Index);
                }
            }
        }
        if (DataFileItems.Count > 0) {
            for (int i = 0; i < DataFileItems.Count; i++) {
                if (DataFileItems[i].Checked) {
                    int Index = (DataFileItems[i].Tag as FfprobeSubdata.Stream).index;
                    EnabledDataFiles.Add(Index);
                    TotalEnabledStreams.Add(Index);
                }
            }
        }

        ExtractSubstreams = ShouldExtractSubstreams() && EnabledSubtitles.Count > 0 && EnabledAttachments.Count > 0 && EnabledDataFiles.Count > 0;

        if (EnabledVideoStreams.Count < this.VideoStreams.Count ||
        EnabledAudioStreams.Count < this.AudioStreams.Count ||
        EnabledSubtitles.Count < this.Subtitles.Count ||
        EnabledAttachments.Count < this.Attachments.Count ||
        EnabledDataFiles.Count < this.DataFiles.Count) {
            if (TotalEnabledStreams.Count < 1)
                throw new InvalidProgramException($"Not enough streams enabled in {nameof(TotalEnabledStreams)}.");

            if (EnabledVideoStreams.Count > 0)
                EnabledVideoStreams.For((Stream) => Args.AppendArg($"-map 0:{Stream}"));
            if (EnabledAudioStreams.Count > 0)
                EnabledAudioStreams.For((Stream) => Args.AppendArg($"-map 0:{Stream}"));

            if (!ExtractSubstreams) {
                if (EnabledVideoStreams.Count < 1 && EnabledAudioStreams.Count < 1)
                    throw ExtractOnlyException.Default;

                if (EnabledSubtitles.Count > 0)
                    EnabledSubtitles.For((Stream) => Args.AppendArg($"-map 0:{Stream}"));
                if (EnabledAttachments.Count > 0)
                    EnabledAttachments.For((Stream) => Args.AppendArg($"-map 0:{Stream}"));
                if (EnabledDataFiles.Count > 0)
                    EnabledDataFiles.For((Stream) => Args.AppendArg($"-map 0:{Stream}"));
            }
        }
        #endregion

        #region Video options
        if (VideoStreams) {
            if (VideoUseCRF)
                Args.Append("-crf" + VideoCRF);
            else if (VideoBitrate > 0)
                Args.AppendArg($"-b:v {VideoBitrate}k");

            if (VideoPreset != VideoPresets.none)
                Args.AppendArg("-preset " + VideoPreset.ToString());

            if (VideoProfile != VideoProfiles.none && !OutputFilePath.ToLowerInvariant().EndsWith(".wmv"))
                Args.AppendArg("-profile:v " + VideoProfile.ToString());

            // TODO: MP4 + MOV?
            if (VideoFastStart)
                Args.AppendArg("-movflags +faststart"); // or `-faststart` ?
        }
        #endregion

        #region Audio options
        if (AudioStreams) {
            if (AudioUseVBR)
                Args.AppendArg($"-q:a {AudioVBR}");
            else if (AudioBitrate > 0)
                Args.AppendArg($"-b:a {AudioBitrate * 1000}");

            if (AudioSampleRate != AudioSampleRates.none)
                Args.AppendArg(AudioSampleRate switch {
                    AudioSampleRates.hz8000 =>  "-ar 8000",
                    AudioSampleRates.hz11025 => "-ar 11025",
                    AudioSampleRates.hz22050 => "-ar 22050",
                    AudioSampleRates.hz32000 => "-ar 32000",
                    AudioSampleRates.hz44100 => "-ar 44100",
                    AudioSampleRates.hz48000 => "-ar 48000",
                    _ => ""
                });
        }
        #endregion

        #region Misc options
        if (StartTime.HasValue) {
            Args.AppendArg($"-ss {StartTime}");

            if (EndTime.HasValue)
                Args.AppendArg($"-to {EndTime}");
        }
        else if (EndTime.HasValue) {
            Args.AppendArg($"-ss 0:00 -to {EndTime}");
        }

        if (CopyCodecs)
            Args.AppendArg("-c copy");

        if (RemoveMetadata)
            Args.AppendArg("-map_metadata -1");

        if (HideFfmpegMetadata)
            Args.AppendArg("-hide_banner -fflags +bitexact -flags:v +bitexact -flags:a +bitexact");
        #endregion

        if (!PartialCustomArguments.IsNullEmptyWhitespace())
            Args.AppendArg(PartialCustomArguments.TrimEnd().Replace("\n", " "));

        Args.Append($"\"{OutputFilePath}\"");
        return Args.ToString();
    }

    /// <summary>
    /// Generates an array of strings that will be ran to extract files from the input file.
    /// </summary>
    /// <returns></returns>
    public string[] GeenerateExtractionArguments() {
        if (!ExtractSubstreams)
            return null;

        List<string> Arguments = new();

        string OutputDir = OutputFilePath[..OutputFilePath.LastIndexOf('.')];

        EnabledSubtitles.For((Stream) => {
            Arguments.Add($"-i \"{InputFilePath}\" -map 0:{Stream} \"{OutputDir}\\subs\\\"");
        });

        if (Arguments.Count < 1)
            throw new ArgumentException($"No arguments available to run.");

        return Arguments.ToArray();
    }
}