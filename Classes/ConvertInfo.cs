using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace youtube_dl_gui {

    public enum ConversionType : int {
        Unspecified = -1,
        Video = 0,
        Audio = 1,
        Custom = 2,
        FfmpegDefault = 3
    }

    public enum ConversionStatus {
        None,
        GeneratingArguments,
        Converting,
        Finished,
        Aborted,
        FfmpegError,
        ProgramError
    }

    public sealed class ConvertInfo : IDisposable {

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public bool IsDisposed { get; private set; }
        public void Dispose(bool disposing) {
            IsDisposed = disposing;
        }

        /// <summary>
        /// The input of the file to be converted.
        /// </summary>
        public string InputFile = null;
        /// <summary>
        /// The output of the converted file.
        /// </summary>
        public string OutputFile = null;
        /// <summary>
        /// Determines if the current conversion is in a batch conversion.
        /// </summary>
        public bool BatchConversion = false;
        /// <summary>
        /// The conversion type, used for user-specified settings.
        /// </summary>
        public ConversionType Type = ConversionType.Unspecified;
        /// <summary>
        /// The status of the current conversion.
        /// </summary>
        public ConversionStatus Status = ConversionStatus.None;

        /// <summary>
        /// Hides the compile information from ffmpeg.
        /// </summary>
        public bool HideFFmpegCompile = Config.Settings.Converts.hideFFmpegCompile;
        
        /// <summary>
        /// Determines if the video conversions should use bitrate.
        /// </summary>
        public bool VideoUseBitrate = Config.Settings.Converts.videoUseBitrate;
        /// <summary>
        /// The conversion bitrate of the video.
        /// </summary>
        public int VideoBitrate = Config.Settings.Converts.videoBitrate;
        /// <summary>
        /// Determines if video conversions should use a preset.
        /// </summary>
        public bool VideoUsePreset = Config.Settings.Converts.videoUsePreset;
        /// <summary>
        /// The conversion preset of the video.
        /// </summary>
        public int VideoPreset = Config.Settings.Converts.videoPreset;
        /// <summary>
        /// Determines if video conversions should use a profile.
        /// </summary>
        public bool VideoUseProfile = Config.Settings.Converts.videoUseProfile;
        /// <summary>
        /// The conversion profile of the video.
        /// </summary>
        public int VideoProfile = Config.Settings.Converts.videoProfile;
        /// <summary>
        /// Determines if video conversions should use CRF.
        /// </summary>
        public bool VideoUseCRF = Config.Settings.Converts.videoUseCRF;
        /// <summary>
        /// The conversion CRF of the video.
        /// </summary>
        public int VideoCRF = Config.Settings.Converts.videoCRF;
        /// <summary>
        /// Determines if video conversions should have the faststart flag.
        /// </summary>
        public bool VideoFastStart = Config.Settings.Converts.videoFastStart;

        /// <summary>
        /// Determines if audio conversions should use bitrate.
        /// </summary>
        public bool AudioUseBitrate = Config.Settings.Converts.audioUseBitrate;
        /// <summary>
        /// The conversion bitrate of the audio.
        /// </summary>
        public int AudioBitrate = Config.Settings.Converts.audioBitrate;

        public string CustomArguments = Config.Settings.Saved.convertCustom;

        public ConvertInfo() {
            
        }
    }
    
    class Convert {
        #region Constants
        /// <summary>
        /// All built-in video formats
        /// </summary>
        public static readonly string videoFormatsFilter = "All File Formats (*.*)|*.*|" +
                                                           "Audio Video Interleave (*.AVI)|*.avi|" +
                                                           "Flash Video (*.FLV)|*.flv|" +
                                                           "Matroska Video (*.MKV)|*.mkv|" +
                                                           "Ogg Vorbis (*.OGV, *.OGX)|*.ogv;*.ogx|" +
                                                           "QuickTime Movie (*.MOV)|*.mov|" +
                                                           "MPEG-4 Part 14 (*.M4A, *.MP4)|*.m4v;*.mp4|" +
                                                           "WebM (*.WEBM)|*.webm|" +
                                                           "Windows Media Video (*.WMV)|*.wmv";

        /// <summary>
        /// All built-in audio formats
        /// </summary>
        public static readonly string audioFormatsFilter = "All File Formats (*.*)|*.*|" +
                                                           "Advanced Audio Codec (*.AAC)|*.aac|" +
                                                           "Free Lossless Audio Codec (*.FLAC)|*.flac|" +
                                                           "MPEG-4 Audio (*.M4A, *.MP4)|*.m4a;*.mp4|" +
                                                           "MPEG-1 AudioLayer III (*.MP3)|*.mp3|" +
                                                           "Ogg Vorbis (*.OGA, *.OGG)|*.oga;*.ogg|" +
                                                           "Opus (*.OPUS)|*.opus|" +
                                                           "Waveform Audio (*.WAV)|*.wav";

        /// <summary>
        /// All built-in audio and video formats
        /// </summary>
        public static readonly string allFormatsFilter = "All File Formats (*.*)|*.*|" +
                                                         "Advanced Audio Codec (*.AAC)|*.aac|" +
                                                         "Audio Video Interleave (*.AVI)|*.avi|" +
                                                         "Free Lossless Audio Codec (*.FLAC)|*.flac|" +
                                                         "Flash Video (*.FLV)|*.flv|" +
                                                         "MPEG-4 Audio (*.M4A)|*.m4a|" +
                                                         "Matroska Video (*.MKV)|*.mkv|" +
                                                         "QuickTime Movie (*.MOV)|*.mov|" +
                                                         "MPEG-1 AudioLayer III (*.MP3)|*.mp3|" +
                                                         "MPEG-4 Part 14 (*.MP4)|*.mp4|" +
                                                         "Ogg Vorbis Audio (*.OGA, *.OGG)|*.oga;*.ogg|" +
                                                         "Ogg Vorbis Video (*.OGV, *.OGX)|*.ogv;*.ogx|" +
                                                         "Opus (*.OPUS)|*.opus|" +
                                                         "Waveform Audio (*.WAV)|*.wav|" +
                                                         "WebM (*.WEBM)|*.webm|" +
                                                         "Windows Media Video (*.WMV)|*.wmv";

        /// <summary>
        /// All built-in video formats in a single filter
        /// </summary>
        public static readonly string allVideoFormats = "All Video Formats|" + "*.avi;*.flv;*.mkv;*.mov;*.ogv;*.ogx;*.m4a;*.mp4;*.webm;*.wmv";
        /// <summary>
        /// All built-in audio formats in a single filter
        /// </summary>
        public static readonly string allAudioFormats = "All Audio Formats|" +
            "*.aac;*.flac;*.m4a;*.mp4;*.mp3;*.opus;*.oga;*.ogg;*.wav";
        /// <summary>
        /// All built-in audio and video formats in a single filter
        /// </summary>
        public static readonly string allMediaFormats = "All Media Formats|" +
            "*.aac;*.avi;*.flac;*.flv;*.m4a;*.mkv;*.mov;*.mp3;*.mp4;*.ogg;*.opus;*.wav;*.webm;*.wmv";

        /// <summary>
        /// Temporary array of video qualities. Not used, just for reference.
        /// </summary>
        public static readonly string[] videoQuality = {
                                                           "1920x1080",
                                                           "1600x900",
                                                           "1280x720",
                                                           "960x540",
                                                           "640x360"
                                                       };

        /// <summary>
        /// Temporary array of audio qualities. Not used, just for reference.
        /// </summary>
        public static readonly string[] audioQuality = {
                                                           "best",
                                                           "8K",
                                                           "16K",
                                                           "24K",
                                                           "32K",
                                                           "40K",
                                                           "48K",
                                                           "56K",
                                                           "64K",
                                                           "80K",
                                                           "96K",
                                                           "112K",
                                                           "128K",
                                                           "160K",
                                                           "192K",
                                                           "224K",
                                                           "256K",
                                                           "320K"
                                                       };

        #endregion

        /// <summary>
        /// Converts a file using ffmpeg
        /// </summary>
        /// <param name="input">The full-path input file</param>
        /// <param name="output">The full-path output</param>
        /// <param name="convType">Determines what conversion it'll attempt to do; To-Video, To-Audio, To-Custom, To-Automatic</param>
        /// <returns>A boolean based on the success of the conversion</returns>
        public static bool convertFile(string input, string output, int convType = -1) {
            return true;
            /// -1 = Automatic
            /// 0 = Video
            /// 1 = Audio
            /// 2 = Custom
            /// 6 = No params at all, just an option to look back to. aka ffmpeg auto

            //try {
            //    Process startConvert = new Process();
            //    if (Program.verif.FFmpegPath == null) {
            //        throw new Exception("FFmpegPath is null. Cannot convert. If you do not have ffmpeg, consider downloading it.");
            //    }
            //    startConvert.StartInfo.FileName = Program.verif.FFmpegPath;

            //    string convertArguments = "-i \"" + input + "\"";
            //    switch (convType) {
            //        case 0:
            //            if (Config.Settings.Converts.videoUseBitrate)
            //                convertArguments += " -b:v " + Config.Settings.Converts.videoBitrate.ToString() + "k";

            //            if (Config.Settings.Converts.videoUsePreset)
            //                convertArguments += " -preset " + GetVideoPreset(Config.Settings.Converts.videoPreset);

            //            if (Config.Settings.Converts.videoUseCRF)
            //                convertArguments += " -crf " + Config.Settings.Converts.videoCRF.ToString();

            //            if (!output.EndsWith(".wmv") && Config.Settings.Converts.videoUseProfile)
            //                convertArguments += " -profile:v " + GetVideoProfile(Config.Settings.Converts.videoProfile);

            //            if (Config.Settings.Converts.videoFastStart)
            //                convertArguments += " -faststart";

            //            break;
            //        case 1:
            //            if (Config.Settings.Converts.audioUseBitrate)
            //                convertArguments += " -ab " + (Config.Settings.Converts.audioBitrate * 1000);

            //            break;
            //        case 2:
            //            convertArguments += " " + Config.Settings.Saved.convertCustom;
            //            break;
            //        case 6:
            //            // FFmpeg default
            //            break;
            //        default:
            //            if (Config.Settings.Converts.detectFiletype) {
            //                switch (GetFiletype(output)) {
            //                    case 0:
            //                        if (Config.Settings.Converts.videoUseBitrate)
            //                            convertArguments += " -b:v " + Config.Settings.Converts.videoBitrate.ToString() + "k";

            //                        if (Config.Settings.Converts.videoUsePreset)
            //                            convertArguments += " -preset " + GetVideoPreset(Config.Settings.Converts.videoPreset);

            //                        if (Config.Settings.Converts.videoUseCRF)
            //                            convertArguments += " -crf " + Config.Settings.Converts.videoCRF.ToString();

            //                        if (!output.EndsWith(".wmv") && Config.Settings.Converts.videoUseProfile)
            //                            convertArguments += " -profile:v " + GetVideoProfile(Config.Settings.Converts.videoProfile);

            //                        if (Config.Settings.Converts.videoFastStart)
            //                            convertArguments += " -faststart";
            //                        break;
            //                    case 1:
            //                        if (Config.Settings.Converts.audioUseBitrate)
            //                            convertArguments += " -ab " + (Config.Settings.Converts.audioBitrate * 1000);

            //                        break;
            //                    default:
            //                        convertArguments += " -preset fast -b 3000k";
            //                        break;
            //                }
            //            }
            //            else {
            //                convertArguments += " -preset fast -b 3000k";
            //            }
            //            break;
            //    }

            //    if (Config.Settings.Converts.hideFFmpegCompile && convType != 2) {
            //        convertArguments += " -hide_banner";
            //    }

            //    convertArguments += " \"" + output + "\"";

            //    startConvert.StartInfo.Arguments = convertArguments;
            //    startConvert.Start();
            //    //startConvert.WaitForExit();

            //    return true;
            //}
            //catch (Exception ex) {
            //    ErrorLog.Report(ex);
            //    return false;
            //}
        }

        /// <summary>
        /// Merges 2 files together
        /// </summary>
        /// <param name="input1">An input to merge</param>
        /// <param name="input2">The second input to merge</param>
        /// <param name="output">The file to produce</param>
        /// <param name="mergeAudio">Should audio be merged?</param>
        /// <param name="deleteAfterMerge">Should the inputs be deleted after merge?</param>
        /// <returns></returns>
        public static bool mergeFiles(string input1, string input2, string output, bool mergeAudio, bool deleteAfterMerge) {
            try {
                string[] formatsV = { ".avi", ".flv", ".mkv", ".mov", ".mp4", ".webm", ".wmv" };
                bool input1IsVideo = false; // is input1 video?

                Process ffMerge = new Process();
                ffMerge.StartInfo.UseShellExecute = true;
                ffMerge.StartInfo.FileName = "ffmpeg.exe";
                for (int i = 0; i < formatsV.Length; i++) {
                    if (input1.EndsWith(formatsV[i])) {
                        input1IsVideo = true;
                        break;
                    }
                }

                if (mergeAudio) {
                    if (input1IsVideo) {
                        ffMerge.StartInfo.Arguments = " -i \"" + input1 + "\" \"" + Path.GetDirectoryName(input1) + "\\tempaudio.mp3\"";
                    }
                    else {
                        ffMerge.StartInfo.Arguments = " -i \"" + input2 + "\" \"" + Path.GetDirectoryName(input2) + "\\tempaudio.mp3\"";
                    }

                    ffMerge.Start();
                    ffMerge.WaitForExit();


                    if (input1IsVideo) {
                        ffMerge.StartInfo.Arguments = " -i \"" + input2 + "\" -i \"" + Path.GetDirectoryName(input1) + "\\tempaudio.mp3\" -filter_complex amix=inputs=2:duration=longest \"" + Path.GetDirectoryName(input1) + "\\final.mp3\"";
                    }
                    else {
                        ffMerge.StartInfo.Arguments = " -i \"" + input1 + "\" -i \"" + Path.GetDirectoryName(input2) + "\\tempaudio.mp3\" -filter_complex amix=inputs=2:duration=longest \"" + Path.GetDirectoryName(input2) + "\\final.mp3\"";
                    }
                    ffMerge.Start();
                    ffMerge.WaitForExit();

                    if (input1IsVideo) {
                        ffMerge.StartInfo.Arguments = " -i \"" + input1 + "\" -i \"" + Path.GetDirectoryName(input1) + "\\final.mp3\" -map 0:v -map 1:a -longest -c copy -y \"" + output + "\"";
                    }
                    else {
                        ffMerge.StartInfo.Arguments = " -i \"" + input2 + "\" -i \"" + Path.GetDirectoryName(input2) + "\\final.mp3\" -map 0:v -map 1:a -longest -c copy -y \"" + output + "\"";
                    }

                    ffMerge.Start();
                    ffMerge.WaitForExit();
                }
                else {
                    if (input1IsVideo) {
                        ffMerge.StartInfo.Arguments = " -i \"" + input1 + "\" -i \"" + input2 + "\" -map 0:v -map 1:a -c copy -y \"" + output + "\"";
                    }
                    else {
                        ffMerge.StartInfo.Arguments = " -i \"" + input1 + "\" -i \"" + input2 + "\" -map 1:v -map 0:a -c copy -y \"" + output + "\"";
                    }

                    ffMerge.Start();
                    ffMerge.WaitForExit();
                }

                if (deleteAfterMerge) {
                    File.Delete(input1);
                    File.Delete(input2);
                }

                return true;
            }
            catch (Exception ex) {
                ErrorLog.Report(ex);
                return false;
            }
        }

        /// <summary>
        /// Get the custom extensions provided by the user.
        /// </summary>
        /// <param name="returnSeparator">Determines if it'll return the filter list with the '|' char at the end.</param>
        /// <returns>The filter list of the user.</returns>
        public static string GetCustomExtensions(bool returnSeparator = true) {
            if (Config.Settings.General.extensionsName.Length > 0) {
                string extensionList = string.Empty;

                List<string> Names = new List<string>(Config.Settings.General.extensionsName.Split('|').ToList());
                List<string> Exts = new List<string>(Config.Settings.General.extensionsShort.Split('|').ToList());

                for (int i = 0; i < Names.Count; i++) {
                    extensionList += Names[i] + " (*." + Exts[i] + ")|*." + Exts[i] + "|";
                }

                if (returnSeparator)
                    return extensionList;
                else
                    return extensionList.TrimEnd('|');
            }
            else {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets a preset name in the built-in presets
        /// </summary>
        /// <param name="index">Index of the preset that was requested</param>
        /// <returns>The preset string</returns>
        public static string GetVideoPreset(int index) {
            switch (index) {
                case 0:
                    return "ultrafast";
                case 1:
                    return "superfast";
                case 2:
                    return "veryfast";
                case 3:
                    return "faster";
                case 4:
                    return "fast";
                case 6:
                    return "slow";
                case 7:
                    return "slower";
                case 8:
                    return "veryslow";
                default:
                    return "medium";
            }
        }
        /// <summary>
        /// Gets a profile name in the built-in profiles
        /// </summary>
        /// <param name="index">Index of the profile that was requested</param>
        /// <returns>The profile string</returns>
        public static string GetVideoProfile(int index) {
            switch (index) {
                case 0:
                    return "baseline";
                case 2:
                    return "high";
                case 3:
                    return "high10";
                case 4:
                    return "high442";
                case 5:
                    return "high444";
                default:
                    return "main";
            }
        }

        /// <summary>
        /// Detects the file-type of the file
        /// </summary>
        /// <param name="file">The file to test</param>
        /// <returns>An int of the file type; video, audio, and default</returns>
        public static ConversionType GetFiletype(string file) {
            if (file.EndsWith(".avi")
             || file.EndsWith(".flv")
             || file.EndsWith(".mp4")
             || file.EndsWith(".mkv")
             || file.EndsWith(".mov")
             || file.EndsWith(".webm")
             || file.EndsWith(".wmv")) { return ConversionType.Video; }

            else if (file.EndsWith(".aac")
                  || file.EndsWith(".flac")
                  || file.EndsWith(".m4a")
                  || file.EndsWith(".mp3")
                  || file.EndsWith(".opus")
                  || file.EndsWith(".ogg")
                  || file.EndsWith(".wav")) { return ConversionType.Audio; }

            else { return ConversionType.FfmpegDefault; }

            //if (file.EndsWith(".avi")
            // || file.EndsWith(".flv")
            // || file.EndsWith(".mp4")
            // || file.EndsWith(".mkv")
            // || file.EndsWith(".mov")
            // || file.EndsWith(".webm")
            // || file.EndsWith(".wmv")) { return 0; }

            //else if (file.EndsWith(".aac")
            //      || file.EndsWith(".flac")
            //      || file.EndsWith(".m4a")
            //      || file.EndsWith(".mp3")
            //      || file.EndsWith(".opus")
            //      || file.EndsWith(".ogg")
            //      || file.EndsWith(".wav")) { return 1; }

            //else { return 3; }
        }
    }
}
