using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtube_dl_gui {
    class Convert {
        public static readonly string videoFormatsFilter = "Audio Video Interleave (*.AVI)|*.avi|" +
                                                           "Flash Video (*.FLV)|*.flv|" +
                                                           "MPEG-4 Part 14 (*.MP4)|*.mp4|" +
                                                           "Matroska (*.MKV)|*.mkv|" +
                                                           "QuickTime Movie (*.MOV)|*.mov|" +
                                                           "WebM (*.WEBM)|*.webm|" +
                                                           "Windows Media Video (*.WMV)|*.wmv|" +
                                                           "All File Formats (*.*)|*.*";

        public static readonly string audioFormatsFilter = "Advanced Audio Coded (*.AAC)|*.aac|" +
                                                           "Free Lossless Audio Codec (*.FLAC)|*.flac|" +
                                                           "MPEG 4 Audio (*.M4A)|*.m4a|" +
                                                           "MPEG-2 Aduio Layer III (*.MP3)|*.mp3|" +
                                                           "Opus (*.OPUS)|*.opus|" +
                                                           "Ogg Vorbis (*.OGG)|*.ogg|" +
                                                           "Waveform Audio File (*.WAV)|*.wav|" +
                                                           "All File Formats (*.*)|*.*";

        public static bool convertFile(string input, string output, int convType = -1) {
            /// -1 = Automatic
            /// 0 = Video
            /// 1 = Audio
            /// 2 = Custom
            /// 6 = No params at all, just an option to look back to. aka ffmpeg auto
            /// 
            try {
                Process startConvert = new Process();
                if (General.Default.useStaticFFmpeg && File.Exists(General.Default.ffmpegPath)) {
                    startConvert.StartInfo.FileName = General.Default.ffmpegPath;
                }
                else {
                    switch (Verification.ytdlFullCheck()) {
                        case 1:
                            startConvert.StartInfo.FileName = Environment.CurrentDirectory + "\\ffmpeg.exe";
                            break;
                        case 2:
                            startConvert.StartInfo.FileName = Verification.ffmpegPathLocation() + "\\ffmpeg.exe";
                            break;
                        case 3:
                            startConvert.StartInfo.FileName = "ffmpeg.exe";
                            break;
                        case 0:
                            startConvert.StartInfo.FileName = General.Default.ffmpegPath + "\\ffmpeg.exe";
                            break;
                        default:
                            if (MessageBox.Show("ffmpeg is not present. Would you like to download it?", "youtube-dl-gui", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                                Process.Start("https://ffmpeg.org/download.html#build-windows");
                                return false;
                            }
                            else {
                                return false;
                            }
                    }
                }
                string convertArguments = string.Empty;
                switch (convType) {
                    case 0:
                        if (!output.EndsWith(".wmv"))
                                    convertArguments += " -profile:v " + getVideoProfile(Converts.Default.videoProfile);

                        convertArguments = "-i \"" + input + "\"" +
                                           " -preset " + getVideoPreset(Converts.Default.videoPreset) +
                                           " -crf " + Converts.Default.videoCRF.ToString() +
                                           " -b:v " + Converts.Default.videoBitrate.ToString() + "k";
                        if (Converts.Default.videoFastStart) {
                            convertArguments += " -faststart";
                        }

                        break;
                    case 1:
                        convertArguments = "-i \"" + input + "\" -preset slow -b 5000k";
                        break;
                    case 2:
                        convertArguments = "-i \"" + input + "\"";
                        break;
                    case 6:
                        convertArguments = "-i \"" + input + "\"";
                        break;
                    default:
                        if (Converts.Default.detectFiletype) {
                            if (output.EndsWith(".avi") || output.EndsWith(".flv") || output.EndsWith(".mp4") || output.EndsWith(".mkv") || output.EndsWith(".mov") || output.EndsWith(".webm") || output.EndsWith(".wmv")) {
                                if (!output.EndsWith(".wmv"))
                                    convertArguments += " -profile:v " + getVideoProfile(Converts.Default.videoProfile);

                                convertArguments = "-i \"" + input + "\"" +
                                           " -preset " + getVideoPreset(Converts.Default.videoPreset) +
                                           " -crf " + Converts.Default.videoCRF.ToString() +
                                           " -b:v " + Converts.Default.videoBitrate.ToString() + "k";
                                if (Converts.Default.videoFastStart) {
                                    convertArguments += " -faststart";
                                }
                            }
                            else if (output.EndsWith(".aac") || output.EndsWith(".flac") || output.EndsWith(".m4a") || output.EndsWith(".mp3") || output.EndsWith(".opus") || output.EndsWith(".ogg") || output.EndsWith(".wav")) {
                                convertArguments = "-i \"" + input + "\" -preset slow -b:a 5000k"; // Good quality for audio
                            }
                            else {
                                convertArguments = "-i \"" + input + "\" -preset slow -b 3000k"; // Ambiguous file type
                            }
                        }
                        else {
                            convertArguments = "-i \"" + input + "\" -preset slow -b 3000k"; 
                        }
                        break;
                }

                if (Converts.Default.hideFFmpegCompile) {
                    convertArguments += " -hide_banner";
                }

                convertArguments += " \"" + output + "\"";

                startConvert.StartInfo.Arguments = convertArguments;
                startConvert.Start();
                startConvert.WaitForExit();

                return true;
            }
            catch (Exception ex) {
                ErrorLog.reportError(ex.ToString());
                return false;
            }
        }




        /// <summary>
        /// Converts a file.
        /// </summary>
        /// <param name="inputFile">The file that will be used as the input.</param>
        /// <param name="outputFile">The file that will be outputed as the converted file.</param>
        /// <param name="convType">The Conversion type. (0 = Video, 1 = Audio)</param>
        /// <param name="convFormat">The format it will be converted to.</param>
        /// <param name="cvAudQuality">The quality of the new audio.</param>
        /// <param name="cvResolution">The resolution that the video will be converted to.</param>
        /// <returns></returns>
        public static bool convertOld(string inputFile, string outputFile, int convType, string convFormat, int cvAudQuality = 0, int cvResolution = 0, int cvBit = 18) {
            try {
                Process Converter = new Process();
                Converter.StartInfo.FileName = "ffmpeg.exe";
                string args = "-i ";

                if (convType == 0) {
                    // Video
                    if (cvResolution == 0)
                        return false;

                    args += "\"" + inputFile + "\" -vf scale=-1:" + cvResolution + " -c:v libx264 -crf " + cvBit + " -preset veryslow -c:a copy \"" + outputFile + "\"";
                    System.Windows.Forms.MessageBox.Show(args);
                }
                else if (convType == 1) {
                    // Audio
                    if (cvAudQuality == 0)
                        return false;

                    args += "\"" + inputFile + "\" -ab " + cvAudQuality + "K" + " \"" + outputFile + "\"";
                }
                else {
                    return false;
                }

                Converter.StartInfo.Arguments = args;
                Converter.Start();
                return true;
            }
            catch (Exception ex) {
                ErrorLog.reportError(ex.ToString());
                return false;
            }
        }

        public static bool mergeFiles(string videoFile, string audioFile, bool delete) {
            try {
                Process merger = new Process();
                merger.StartInfo.FileName = "ffmpeg.exe";
                //merger.StartInfo.Arguments = " -i \"" + videoFile + "\" -i \"" + audioFile + "\" -codec copy \"" + Settings.Default.DownloadDir + "\\Merged\\" + Path.GetFileName(videoFile) + "\"";
                merger.Start();
                return true;
            }
            catch (Exception ex) {
                ErrorLog.reportError(ex.ToString());
                return false;
            }
        }

        public static string getVideoPreset(int index) {
            switch (index) {
                case 0: return "ultrafast";
                case 1: return "superfast";
                case 2: return "veryfast";
                case 3: return "faster";
                case 4: return "fast";
                case 5: return "medium";
                case 6: return "slow";
                case 7: return "slower";
                case 8: return "veryslow";
                default: return "medium";
            }
        }
        public static string getVideoProfile(int index) {
            switch (index) {
                case 0: return "baseline";
                case 1: return "main";
                case 2: return "high";
                case 3: return "high10";
                case 4: return "high442";
                case 5: return "high444";
                default: return "main";
            }
        }
    }
}
