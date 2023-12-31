#nullable enable
namespace youtube_dl_gui;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Windows.Forms;
public partial class frmBatchConverter : LocalizedProcessingForm {
    private readonly List<string> InputFiles = [];
    private readonly List<string> OutputFiles = [];
    private readonly List<string?> Arguments = [];

    [MemberNotNullWhen(true, nameof(ConversionThread), nameof(Converter))]
    private bool InProgress { get; set; }

    private bool AbortConversions;
    private Thread? ConversionThread;
    private frmConverter? Converter;
    private ConvertInfo? NewInfo;

    public frmBatchConverter() {
        InitializeComponent();
        LoadLanguage();
        lvBatchConvertQueue.SmallImageList = Program.BatchStatusImages;

        this.Load += (s, e) => {
            if (Saved.BatchConverterLocation.Valid) {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = Saved.BatchConverterLocation;
            }
        };
        this.FormClosing += (s, e) => Saved.BatchConverterLocation = this.Location;
    }

    public override void LoadLanguage() {
        btnBatchConverterAdd.Text = Language.GenericAdd;
        btnBatchConverterRemoveSelected.Text = Language.GenericRemoveSelected;
        btnBatchConverterStartStopExit.Text = Language.GenericStart;
        this.Text = Language.frmBatchConverter;
        lbBatchConverterInput.Text = Language.lbBatchConverterInput;
        txtBatchConverterInputFile.TextHint = Language.txtBatchConverterInputFile;
        lbBatchConverterOutput.Text = Language.lbBatchConverterOutput;
        txtBatchConverterOutputFile.TextHint = Language.txtBatchConverterOutputFile;
        txtBatchConverterCustomConversionArguments.TextHint = Language.txtBatchConverterCustomConversionArguments;
        sbBatchConverter.Text = Language.sbBatchConverterIdle;
        chInput.Text = Language.GenericInput;
        chOutput.Text = Language.GenericOutput;
        chArguments.Text = Language.GenericArguments;
        if (AbortConversions) {
            sbBatchConverter.Text = Language.sbBatchConverterAborted;
        }
        else {
            sbBatchConverter.Text = InProgress ? Language.sbBatchConverterConverting : Language.sbBatchConverterIdle;
        }
    }

    private void SelectInput() {
        using OpenFileDialog ofd = new();
        ofd.Title = Language.dlgConvertSelectFileToConvert;
        ofd.AutoUpgradeEnabled = true;
        ofd.Multiselect = false;
        ofd.Filter = Formats.JoinFormats([
            Formats.AllFiles,
            Formats.VideoFormats,
            Formats.AudioFormats,
            !Formats.CustomFormats.IsNullEmptyWhitespace() ? Formats.CustomFormats : ""
        ]);

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
        sfd.Title = Language.dlgSaveOutputFileAs;
        sfd.Filter = Formats.JoinFormats([
            Formats.AllFiles,
            Formats.VideoFormats,
            Formats.AudioFormats,
            !Formats.CustomFormats.IsNullEmptyWhitespace() ? Formats.CustomFormats : ""
        ]);

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
            NewQueue.ImageIndex = StatusIcon.Waiting;
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
            Log.Write($"Starting batch conversion with {lvBatchConvertQueue.Items.Count} links to download.");
            InProgress = true;
            AbortConversions = false;
            btnBatchConverterStartStopExit.Text = Language.GenericStop;
            sbBatchConverter.Text = Language.sbBatchConverterConverting;
            ConversionThread = new(() => {
                for (int i = 0; i < InputFiles.Count; i++) {
                    lvBatchConvertQueue.Invoke((Action)delegate {
                        lvBatchConvertQueue.Items[i].ImageIndex = StatusIcon.Processing;
                    });
                    NewInfo = new(InputFiles[i], OutputFiles[i]) {
                        BatchConversion = true,
                    };

                    if (Arguments[i].IsNullEmptyWhitespace()) {
                        NewInfo.Type = ConversionType.FfmpegDefault;
                    }
                    else {
                        NewInfo.Type = ConversionType.Custom;
                        NewInfo.CustomArguments = Arguments[i]!;
                    }

                    Converter = new(NewInfo);
                    switch (Converter.ShowDialog()) {
                        case DialogResult.Yes: {
                            lvBatchConvertQueue.Invoke((Action)delegate {
                                lvBatchConvertQueue.Items[i].ImageIndex = StatusIcon.Finished;
                            });
                        } break;

                        case DialogResult.No: {
                            lvBatchConvertQueue.Invoke((Action)delegate {
                                lvBatchConvertQueue.Items[i].ImageIndex = StatusIcon.Errored;
                            });
                        } break;

                        case DialogResult.Abort: {
                            lvBatchConvertQueue.Invoke((Action)delegate {
                                lvBatchConvertQueue.Items[i].ImageIndex = StatusIcon.Waiting;
                            });
                            Log.Write($"Batch conversion aborted, {i} conversion finished.");
                            AbortConversions = true;
                        } break;

                        case DialogResult.Ignore: {
                            lvBatchConvertQueue.Invoke((Action)delegate {
                                lvBatchConvertQueue.Items[i].ImageIndex = StatusIcon.Waiting;
                            });
                        } break;

                        default: {
                            lvBatchConvertQueue.Invoke((Action)delegate {
                                lvBatchConvertQueue.Items[i].ImageIndex = StatusIcon.Finished;
                            });
                        } break;
                    }

                    if (AbortConversions)
                        break;
                }
                lvBatchConvertQueue.Invoke((Action)delegate {
                    if (AbortConversions) {
                        sbBatchConverter.Text = Language.sbBatchConverterAborted;
                    }
                    else {
                        sbBatchConverter.Text = Language.sbBatchConverterFinished;
                    }
                    btnBatchConverterStartStopExit.Text = Language.GenericStart;
                });
                System.Media.SystemSounds.Exclamation.Play();
                InProgress = false;
                Log.Write("Batch conversion finished running.");
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
        if (!Program.DebugMode) {
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