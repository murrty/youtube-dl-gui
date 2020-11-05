using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmMiscTools : Form {
        Language lang = Language.GetInstance();

        public frmMiscTools() {
            InitializeComponent();
            this.Text = lang.frmTools;
            btnMiscToolsRemoveAudio.Text = lang.btnMiscToolsRemoveAudio;
            btnMiscToolsExtractAudio.Text = lang.btnMiscToolsExtractAudio;
            btnMiscToolsVideoToGif.Text = lang.btnMiscToolsVideoToGif;
            this.Icon = Properties.Resources.youtube_dl_gui;
        }
        private void frmTools_FormClosing(object sender, FormClosingEventArgs e) {
            this.Dispose();
        }

        private void btnMiscToolsRemoveAudio_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = "Select a file to remove the audio from";
                ofd.Filter = Convert.videoFormatsFilter;
                ofd.FilterIndex = 0;
                if (ofd.ShowDialog() == DialogResult.OK) {
                    string newFile = Path.GetDirectoryName(ofd.FileName) + "\\" + Path.GetFileNameWithoutExtension(ofd.FileName) + "-noaudio" + Path.GetExtension(ofd.FileName);
                    if (newFile.Length > 250) {
                        newFile = Path.GetDirectoryName(ofd.FileName + "\\" + "output" + Path.GetExtension(ofd.FileName)); // Rare case, file is a lorge name
                    }
                    
                    Process ffmpeg = new Process() {
                        StartInfo = new ProcessStartInfo("cmd") {
                            UseShellExecute = false,
                            //RedirectStandardInput = true,
                            //RedirectStandardOutput = true,
                            //CreateNoWindow = true,
                            Arguments = string.Format("/c \"{0}\"", "ffmpeg -i \"" + ofd.FileName + "\" -c copy -an \"" + newFile + "\""),
                        }
                    };
                    ffmpeg.Start();
                }
            }
        }

        private void btnMiscToolsExtractAudio_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = "Select a file to extract the audio from";
                ofd.Filter = Convert.videoFormatsFilter;
                ofd.FilterIndex = 0;
                if (ofd.ShowDialog() == DialogResult.OK) {
                    using (SaveFileDialog sfd = new SaveFileDialog()) {
                        sfd.Title = "Save audio as...";
                        sfd.Filter = Convert.audioFormatsFilter;
                        sfd.FileName = Path.GetFileNameWithoutExtension(ofd.FileName);
                        sfd.FilterIndex = 5;
                        if (sfd.ShowDialog() == DialogResult.OK) {
                            string newFile = sfd.FileName;

                            Process ffmpeg = new Process() {
                                StartInfo = new ProcessStartInfo("cmd") {
                                    UseShellExecute = false,
                                    //RedirectStandardInput = true,
                                    //RedirectStandardOutput = true,
                                    //CreateNoWindow = true,
                                    Arguments = string.Format("/c \"{0}\"", "ffmpeg -i \"" + ofd.FileName + "\" \"" + newFile + "\""),
                                }
                            };
                            ffmpeg.Start();
                        }
                    }
                }
            }
        }

        private void btnMiscToolsVideoToGif_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                if (ofd.ShowDialog() == DialogResult.OK) {
                    Process ffmpeg = new Process() {
                        StartInfo = new ProcessStartInfo("cmd") {
                            UseShellExecute = false,
                            Arguments = string.Format("/c \"{0}\"", "cd " + Path.GetDirectoryName(ofd.FileName) + " | mkdir frms | ffmpeg -i \"" + ofd.FileName + "\" scale=320:-1:flags=lanczos,fps=10 frames/outframes%03d.png"),
                        }
                    };
                    ffmpeg.Start();
                    ffmpeg.WaitForExit();

                    Process imageMagick = new Process(){
                        StartInfo = new ProcessStartInfo("cmd") {
                            UseShellExecute = false,
                            Arguments = string.Format("/c \"{0}\"", "convert -loop 0 frames/outframes*.png \"" + Path.GetDirectoryName(ofd.FileName) + "\\" + Path.GetFileNameWithoutExtension(ofd.FileName) + ".gif\""),
                        }
                    };
                    imageMagick.Start();
                }
            }
        }
    }
}