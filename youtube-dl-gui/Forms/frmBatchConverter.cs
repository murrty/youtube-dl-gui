using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmBatchConverter : Form {

        private readonly List<string> InputFiles = new();
        private readonly List<string> OutputFiles = new();
        private readonly List<string> Arguments = new();
        private readonly ImageList StatusImages;                // The images for each individual item
        private Thread ConversionThread;
        private bool InProgress = false;
        private frmConverter Converter;
        private ConvertInfo NewInfo;

        public frmBatchConverter() {
            InitializeComponent();
            LoadLanguage();

            StatusImages = new() {
                ColorDepth = ColorDepth.Depth32Bit,
                TransparentColor = System.Drawing.Color.Transparent,
            };

            StatusImages.Images.Add(Properties.Resources.waiting);
            StatusImages.Images.Add(Properties.Resources.download);
            StatusImages.Images.Add(Properties.Resources.finished);
            StatusImages.Images.Add(Properties.Resources.error);
            lvBatchConvertQueue.SmallImageList = StatusImages;
        }

        private void LoadLanguage() {
            btnBatchConverterAdd.Text = Program.lang.GenericAdd;
            btnBatchConverterRemoveSelected.Text = Program.lang.GenericRemoveSelected;
            btnBatchConverterStartStopExit.Text = Program.lang.GenericStart;
            this.Text = Program.lang.frmBatchConverter;
            lbBatchConverterInput.Text = Program.lang.lbBatchConverterInput;
            txtBatchConverterInputFile.TextHint = Program.lang.txtBatchConverterInputFile;
            lbBatchConverterOutput.Text = Program.lang.lbBatchConverterOutput;
            txtBatchConverterOutputFile.TextHint = Program.lang.txtBatchConverterOutputFile;
            txtBatchConverterCustomConversionArguments.TextHint = Program.lang.txtBatchConverterCustomConversionArguments;
            sbBatchConverter.Text = Program.lang.sbBatchConverterIdle;
        }

        private void SelectInput() {
            using OpenFileDialog ofd = new();
            ofd.Title = Program.lang.dlgConvertSelectFileToConvert;
            ofd.AutoUpgradeEnabled = true;
            ofd.Multiselect = false;
            ofd.Filter = Formats.JoinFormats(new[] {
                Formats.AllFiles,
                Formats.VideoFormats,
                Formats.AudioFormats,
                !string.IsNullOrWhiteSpace(Formats.CustomFormats) ? Formats.CustomFormats : ""
            });

            if (ofd.ShowDialog() == DialogResult.OK) {
                txtBatchConverterInputFile.Text = ofd.FileName;
                if (string.IsNullOrWhiteSpace(txtBatchConverterOutputFile.Text)) {
                    SelectOutput();
                }
                else {
                    btnBatchConverterAdd.Enabled = true;
                }
            }
        }

        private void SelectOutput() {
            using SaveFileDialog sfd = new();
            sfd.AutoUpgradeEnabled = true;
            sfd.Title = Program.lang.dlgSaveOutputFileAs;
            sfd.Filter = Formats.JoinFormats(new[] {
                Formats.AllFiles,
                Formats.VideoFormats,
                Formats.AudioFormats,
                !string.IsNullOrWhiteSpace(Formats.CustomFormats) ? Formats.CustomFormats : ""
            });

            if (!string.IsNullOrWhiteSpace(txtBatchConverterInputFile.Text)) {
                sfd.FileName = System.IO.Path.GetFileNameWithoutExtension(txtBatchConverterOutputFile.Text);
            }

            if (sfd.ShowDialog() == DialogResult.OK) {
                txtBatchConverterOutputFile.Text = sfd.FileName;
                if (string.IsNullOrWhiteSpace(txtBatchConverterInputFile.Text)) {
                    SelectInput();
                }
                else {
                    btnBatchConverterAdd.Enabled = true;
                }
            }
        }

        private void AddItem() {
            if (!string.IsNullOrWhiteSpace(txtBatchConverterInputFile.Text) && !string.IsNullOrWhiteSpace(txtBatchConverterOutputFile.Text)) {
                InputFiles.Add(txtBatchConverterInputFile.Text);
                OutputFiles.Add(txtBatchConverterOutputFile.Text);
                ListViewItem NewQueue = new($" {txtBatchConverterInputFile.Text}");
                NewQueue.SubItems.Add(txtBatchConverterOutputFile.Text);
                if (string.IsNullOrWhiteSpace(txtBatchConverterCustomConversionArguments.Text)) {
                    Arguments.Add(null);
                    NewQueue.SubItems.Add("(default)");
                }
                else {
                    Arguments.Add(txtBatchConverterCustomConversionArguments.Text);
                    NewQueue.SubItems.Add(txtBatchConverterCustomConversionArguments.Text);
                }
                NewQueue.ImageIndex = 0;
                lvBatchConvertQueue.Items.Add(NewQueue);
                btnBatchConverterStartStopExit.Enabled = true;
            }
        }

        private void RemoveItemsFromList() {
            if (lvBatchConvertQueue.SelectedIndices.Count > 0 && !InProgress) {
                for (int i = lvBatchConvertQueue.Items.Count - 1; i >= 0; i--) {
                    if (lvBatchConvertQueue.Items[i].Selected) {
                        lvBatchConvertQueue.Items[i].Remove();
                        InputFiles.RemoveAt(i);
                        OutputFiles.RemoveAt(i);
                        Arguments.RemoveAt(i);
                    }
                }

                if (lvBatchConvertQueue.Items.Count == 0) {
                    btnBatchConverterStartStopExit.Enabled = false;
                }
            }
        }

        private void txtBatchDownloadLink_ButtonClick(object sender, EventArgs e) {
            SelectInput();
        }

        private void txtBatchConverterOutput_ButtonClick(object sender, EventArgs e) {
            SelectOutput();
        }

        private void btnBatchConverterStartStopExit_Click(object sender, EventArgs e) {
            if (InProgress) {
                Converter.Invoke((Action)delegate {
                    Converter.Abort();
                });
            }
            else if (lvBatchConvertQueue.Items.Count > 0) {
                InProgress = true;
                bool AbortConversions = false;
                btnBatchConverterStartStopExit.Text = Program.lang.GenericStop;
                sbBatchConverter.Text = Program.lang.sbBatchConverterConverting;
                ConversionThread = new(() => {
                    for (int i = 0; i < InputFiles.Count; i++) {
                        lvBatchConvertQueue.Invoke((Action)delegate {
                            lvBatchConvertQueue.Items[i].ImageIndex = (int)BatchHelpers.StatusIcon.Processing;
                        });
                        NewInfo = new() {
                            BatchConversion = true,
                            InputFile = InputFiles[i],
                            OutputFile = OutputFiles[i],
                        };
                        if (Arguments[i] == null) {
                            NewInfo.Type = ConversionType.FfmpegDefault;
                        }
                        else {
                            NewInfo.Type = ConversionType.Custom;
                            NewInfo.CustomArguments = Arguments[i];
                        }

                        Converter = new(NewInfo);
                        switch (Converter.ShowDialog()) {
                            case DialogResult.Yes: {
                                lvBatchConvertQueue.Invoke((Action)delegate {
                                    lvBatchConvertQueue.Items[i].ImageIndex = (int)BatchHelpers.StatusIcon.Finished;
                                });
                            } break;

                            case DialogResult.No: {
                                lvBatchConvertQueue.Invoke((Action)delegate {
                                    lvBatchConvertQueue.Items[i].ImageIndex = (int)BatchHelpers.StatusIcon.Errored;
                                });
                            } break;

                            case DialogResult.Abort: {
                                lvBatchConvertQueue.Invoke((Action)delegate {
                                    lvBatchConvertQueue.Items[i].ImageIndex = (int)BatchHelpers.StatusIcon.Waiting;
                                });
                                AbortConversions = true;
                            } break;

                            case DialogResult.Ignore: {
                                lvBatchConvertQueue.Invoke((Action)delegate {
                                    lvBatchConvertQueue.Items[i].ImageIndex = (int)BatchHelpers.StatusIcon.Waiting;
                                });
                            } break;

                            default: {
                                lvBatchConvertQueue.Invoke((Action)delegate {
                                    lvBatchConvertQueue.Items[i].ImageIndex = (int)BatchHelpers.StatusIcon.Finished;
                                });
                            } break;
                        }

                        if (AbortConversions)
                            break;
                    }
                    InProgress = false;
                    lvBatchConvertQueue.Invoke((Action)delegate {
                        if (AbortConversions) {
                            sbBatchConverter.Text = Program.lang.sbBatchConverterAborted;
                            AbortConversions = false;
                        }
                        else {
                            sbBatchConverter.Text = Program.lang.sbBatchConverterFinished;
                        }
                        btnBatchConverterStartStopExit.Text = Program.lang.GenericStart;
                    });
                    System.Media.SystemSounds.Exclamation.Play();
                }) {
                    Name = "Conversion thread",
                };
                ConversionThread.SetApartmentState(ApartmentState.STA);
                ConversionThread.Start();
            }
        }

        private void lvBatchConvertQueue_SelectedIndexChanged(object sender, EventArgs e) {
            btnBatchConverterRemoveSelected.Enabled = lvBatchConvertQueue.SelectedItems.Count > 0;
        }

        private void btnBatchConverterAdd_Click(object sender, EventArgs e) {
            AddItem();
            if (!Program.IsDebug) {
                txtBatchConverterInputFile.Clear();
                txtBatchConverterOutputFile.Clear();
            }
        }

        private void txtBatchConverterOutputFile_TextChanged(object sender, EventArgs e) {
            btnBatchConverterAdd.Enabled = !string.IsNullOrWhiteSpace(txtBatchConverterInputFile.Text) && !string.IsNullOrWhiteSpace(txtBatchConverterOutputFile.Text);
        }

        private void txtBatchConverterInputFile_TextChanged(object sender, EventArgs e) {
            btnBatchConverterAdd.Enabled = !string.IsNullOrWhiteSpace(txtBatchConverterInputFile.Text) && !string.IsNullOrWhiteSpace(txtBatchConverterOutputFile.Text);
        }

        private void btnBatchConverterRemoveSelected_Click(object sender, EventArgs e) {
            RemoveItemsFromList();
        }

        private void lvBatchConvertQueue_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control && e.KeyCode == Keys.A) {
                for (int i = 0; i < lvBatchConvertQueue.Items.Count; i++) {
                    lvBatchConvertQueue.Items[i].Selected = true;
                }
            }
        }

        private void lvBatchConvertQueue_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                RemoveItemsFromList();
            }
        }

        private void frmBatchConverter_FormClosing(object sender, FormClosingEventArgs e) {
            if (InProgress) {
                Converter.Invoke((Action)delegate {
                    Converter.Abort();
                });
                e.Cancel = true;
            }
            else {
                this.Dispose();
            }
        }
    }
}
