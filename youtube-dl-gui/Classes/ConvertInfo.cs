using System;
using System.Diagnostics;
using System.IO;

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

                using Process ffMerge = new();
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
        /// Gets a preset name in the built-in presets
        /// </summary>
        /// <param name="index">Index of the preset that was requested</param>
        /// <returns>The preset string</returns>
        public static string GetVideoPreset(int index) {
            return index switch {
                0 => "ultrafast",
                1 => "superfast",
                2 => "veryfast",
                3 => "faster",
                4 => "fast",
                6 => "slow",
                7 => "slower",
                8 => "veryslow",
                _ => "medium",
            };
        }

        /// <summary>
        /// Gets a profile name in the built-in profiles
        /// </summary>
        /// <param name="index">Index of the profile that was requested</param>
        /// <returns>The profile string</returns>
        public static string GetVideoProfile(int index) {
            return index switch {
                0 => "baseline",
                2 => "high",
                3 => "high10",
                4 => "high442",
                5 => "high444",
                _ => "main",
            };
        }

        /// <summary>
        /// Detects the file-type of the file
        /// </summary>
        /// <param name="file">The file to test</param>
        /// <returns>An int of the file type; video, audio, and default</returns>
        public static ConversionType GetFiletype(string InputFile) {
            string[] File = InputFile.Split('.');
            if (File.Length > 0) {
                string Format = File[^1];
                return Formats.VideoFormats.Contains(Format) ? ConversionType.Video : (Formats.AudioFormats.Contains(Format) ? ConversionType.Audio : ConversionType.FfmpegDefault);
            }
            
            return ConversionType.FfmpegDefault;
        }
    }
}
