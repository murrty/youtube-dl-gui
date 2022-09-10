namespace youtube_dl_gui;

using System.Diagnostics;
using System.IO;

internal class ConvertHelper {
    /// <summary>
    /// Merges 2 files together
    /// </summary>
    /// <param name="input1">An input to merge</param>
    /// <param name="input2">The second input to merge</param>
    /// <param name="output">The file to produce</param>
    /// <param name="mergeAudio">Should audio be merged?</param>
    /// <param name="deleteAfterMerge">Should the inputs be deleted after merge?</param>
    /// <returns></returns>
    [Obsolete("Untested as of 2022-09, needs redo and retesting.")]
    public static bool MergeFiles(string input1, string input2, string output, bool mergeAudio, bool deleteAfterMerge) {
        try {
            string[] formatsV = { ".avi", ".flv", ".mkv", ".mov", ".mp4", ".webm", ".wmv" };
            bool input1IsVideo = false; // is input1 video?

            if (Verification.FFmpegPath.IsNullEmptyWhitespace()) {
                Verification.RefreshFFmpegLocation();
                if (Verification.FFmpegPath.IsNullEmptyWhitespace()) {
                    return false;
                }
            }

            using Process ffMerge = new() {
                StartInfo = new() {
                    FileName = Verification.FFmpegPath,
                    UseShellExecute = true,
                }
            };

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
            Log.ReportException(ex);
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