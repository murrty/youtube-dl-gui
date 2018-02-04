using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace youtube_dl_gui {
    class Converter {

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
        public static bool convert(string inputFile, string outputFile, int convType, string convFormat, int cvAudQuality = 0, int cvResolution = 0, int cvBit = 18) {
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
                if (Settings.Default.logErrorFiles)
                    ErrorLog.logError(ex.ToString(), "ydgConvert.convert");
                else
                    ErrorLog.throwError(ex.ToString());

                return false;
            }
        }
    }
}
