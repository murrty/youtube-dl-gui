namespace youtube_dl_gui;
using System;
using System.Data.SqlTypes;
using System.IO;
using System.Text;
using System.Windows.Forms;

public partial class frmExtendedConverter : LocalizedForm {

    private readonly List<int> DisabledVideoStreams = new();
    private readonly List<int> DisabledAudioStreams = new();
    private readonly List<int> DisabledSubtitles = new();
    private readonly List<int> DisabledAttachments = new();
    private readonly List<int> DisabledData = new();

    private ExtendedConversionDetails SelectedConversion;

    public frmExtendedConverter() {
        InitializeComponent();

        cbVideoPreset.SelectedIndex = 5;
        cbVideoProfile.SelectedIndex = 1;
    }
    public frmExtendedConverter(string Input) : this() => ChangeInputFile(Input);
    public frmExtendedConverter(string Input, string Output) : this(Input) => ChangeOutputFile(Output);

    public override void LoadLanguage() {
    }

    private string GetArgs(string Input, string Output) {
        bool CopyCodecs = chkCopyCodecs.Checked && Input[Input.LastIndexOf('.')..].ToLowerInvariant() == Output[Output.LastIndexOf('.')..].ToLowerInvariant();
        StringBuilder Args = new();

        Args.AppendArg($"-i \"{Input}\"");

        #region Options
        if (tpStartingTime.HasValue) {
            Args.AppendArg($"-ss {tpStartingTime.Value}");

            if (tpEndingTime.HasValue)
                Args.AppendArg($"-to {tpEndingTime.Value}");
        }
        else if (tpEndingTime.HasValue) {
            Args.AppendArg($"-ss 0:00 -to {tpEndingTime.Value}");
        }

        Args.AppendArg("-map 0");

        if (CopyCodecs) {
            Args.AppendArg("-c copy");

            if (lvVideoStreams.Items.Count > 0) {
                for (int i = 0; i < lvVideoStreams.Items.Count; i++) {
                    if (!lvVideoStreams.Items[i].Checked)
                        DisabledVideoStreams.Add((lvVideoStreams.Items[i].Tag as FfprobeSubdata.Stream).index);
                }

                if (DisabledVideoStreams.Count > 0) {
                    if (DisabledVideoStreams.Count == lvVideoStreams.Items.Count)
                        Args.AppendArg("-map -0:v");
                    else
                        DisabledVideoStreams.For((Stream) => Args.AppendArg($"-map -0:v:{Stream}"));
                }
            }

            if (lvAudioStreams.Items.Count > 0) {
                for (int i = 0; i < lvAudioStreams.Items.Count; i++) {
                    if (!lvAudioStreams.Items[i].Checked)
                        DisabledAudioStreams.Add((lvAudioStreams.Items[i].Tag as FfprobeSubdata.Stream).index);
                }

                if (DisabledAudioStreams.Count > 0) {
                    if (DisabledAudioStreams.Count == lvAudioStreams.Items.Count)
                        Args.AppendArg("-map -0:a");
                    else
                        DisabledAudioStreams.For((Stream) => Args.AppendArg($"-map -0:a:{Stream}"));
                }
            }

            if (lvSubtitles.Items.Count > 0) {
                for (int i = 0; i < lvSubtitles.Items.Count; i++) {
                    if (!lvSubtitles.Items[i].Checked)
                        DisabledSubtitles.Add((lvSubtitles.Items[i].Tag as FfprobeSubdata.Stream).index);
                }

                if (DisabledSubtitles.Count > 0) {
                    if (DisabledSubtitles.Count == lvSubtitles.Items.Count)
                        Args.AppendArg("-map -0:a");
                    else
                        DisabledSubtitles.For((Stream) => Args.AppendArg($"-map -0:s:{Stream}"));
                }
            }

            if (lvAttachments.Items.Count > 0) {
                for (int i = 0; i < lvAttachments.Items.Count; i++) {
                    if (!lvAttachments.Items[i].Checked)
                        DisabledAttachments.Add((lvAttachments.Items[i].Tag as FfprobeSubdata.Stream).index);
                }

                if (DisabledAttachments.Count > 0) {
                    if (DisabledAttachments.Count == lvAttachments.Items.Count)
                        Args.AppendArg("-map -0:a");
                    else
                        DisabledAttachments.For((Stream) => Args.AppendArg($"-map -0:t:{Stream}"));
                }
            }

            if (lvData.Items.Count > 0) {
                for (int i = 0; i < lvData.Items.Count; i++) {
                    if (!lvData.Items[i].Checked)
                        DisabledData.Add((lvData.Items[i].Tag as FfprobeSubdata.Stream).index);
                }

                if (DisabledData.Count > 0) {
                    if (DisabledData.Count == lvData.Items.Count)
                        Args.AppendArg("-map -0:a");
                    else
                        DisabledData.For((Stream) => Args.AppendArg($"-map -0:d:{Stream}"));
                }
            }
        }

        if (chkRemoveMetadata.Checked)
            Args.AppendArg("-map_metadata -1");

        if (chkHideFfmpegMetadata.Checked)
            Args.AppendArg("-hide_banner -fflags +bitexact -flags:v +bitexact -flags:a +bitexact");
        #endregion

        Args.Append($"\"{Output}\"");
        return Args.ToString();
    }
    private bool ChangeInputFile(string InputFile) {
        if (!File.Exists(InputFile)) {
            txtInput.Focus();
            System.Media.SystemSounds.Exclamation.Play();
            return false;
        }

        ExtendedConversionDetails NewDetails = new() {
            InputFilePath = InputFile
        };

        try {
            NewDetails.GetMediaInfo();
        }
        catch {
            System.Media.SystemSounds.Exclamation.Play();
            return false;
        }

        SelectedConversion = NewDetails;
        txtInput.Text = InputFile;

        if (lvVideoStreams.Items.Count > 0)
            lvVideoStreams.Items.Clear();
        if (SelectedConversion.VideoItems.Count > 0) {
            SelectedConversion.VideoItems.For((Stream) => lvVideoStreams.Items.Add(Stream));
            if (!tcMain.TabPages.Contains(tpVideoStreams))
                tcMain.TabPages.Add(tpVideoStreams);
        }
        else if (tcMain.TabPages.Contains(tpVideoStreams))
            tcMain.TabPages.Remove(tpVideoStreams);

        if (lvAudioStreams.Items.Count > 0)
            lvAudioStreams.Items.Clear();
        if (SelectedConversion.AudioItems.Count > 0) {
            SelectedConversion.AudioItems.For((Stream) => lvAudioStreams.Items.Add(Stream));
            if (!tcMain.TabPages.Contains(tpAudioStreams))
                tcMain.TabPages.Add(tpAudioStreams);
        }
        else if (tcMain.TabPages.Contains(tpAudioStreams))
            tcMain.TabPages.Remove(tpAudioStreams);

        if (lvSubtitles.Items.Count > 0)
            lvSubtitles.Items.Clear();
        if (SelectedConversion.SubtitleItems.Count > 0) {
            SelectedConversion.SubtitleItems.For((Stream) => lvSubtitles.Items.Add(Stream));
            if (!tcMain.TabPages.Contains(tpSubtitles))
                tcMain.TabPages.Add(tpSubtitles);
        }
        else if (tcMain.TabPages.Contains(tpSubtitles))
            tcMain.TabPages.Remove(tpSubtitles);

        if (lvAttachments.Items.Count > 0)
            lvAttachments.Items.Clear();
        if (SelectedConversion.AttachmentItems.Count > 0) {
            SelectedConversion.AttachmentItems.For((Stream) => lvAttachments.Items.Add(Stream));
            if (!tcMain.TabPages.Contains(tpAttachments))
                tcMain.TabPages.Add(tpAttachments);
        }
        else if (tcMain.TabPages.Contains(tpAttachments))
            tcMain.TabPages.Remove(tpAttachments);

        if (lvData.Items.Count > 0)
            lvData.Items.Clear();
        if (SelectedConversion.DataFileItems.Count > 0) {
            SelectedConversion.DataFileItems.For((Stream) => lvData.Items.Add(Stream));
            if (!tcMain.TabPages.Contains(tpData))
                tcMain.TabPages.Add(tpData);
        }
        else if (tcMain.TabPages.Contains(tpData))
            tcMain.TabPages.Remove(tpData);

        return true;
    }
    private void ChangeOutputFile(string OutputFile) {
        SelectedConversion.OutputFilePath = OutputFile;
        txtOutput.Text = OutputFile;
    }

    private void SaveMediaOptions() {
        if (SelectedConversion is null)
            return;

        SelectedConversion.RemoveMetadata = chkRemoveMetadata.Checked;
        SelectedConversion.HideFfmpegMetadata = chkHideFfmpegMetadata.Checked;
        SelectedConversion.CopyCodecs = chkCopyCodecs.Checked;
        SelectedConversion.StartTime = tpStartingTime.Value;
        SelectedConversion.EndTime = tpEndingTime.Value;

        SelectedConversion.VideoBitrate = numVideoBitrate.Value;
        SelectedConversion.VideoUseCRF = chkVideoUseCRF.Checked;
        SelectedConversion.VideoCRF = cbVideoCRF.SelectedIndex;
        SelectedConversion.VideoFastStart = chkVideoFaststart.Checked;
        SelectedConversion.VideoPreset = (VideoPresets)cbVideoPreset.SelectedIndex;
        SelectedConversion.VideoProfile = (VideoProfiles)cbVideoProfile.SelectedIndex;

        SelectedConversion.AudioBitrate = numAudioBitrate.Value;
        SelectedConversion.AudioUseVBR = chkAudioUseVBR.Checked;
        SelectedConversion.AudioVBR = cbAudioVBR.SelectedIndex;
    }
    private void LoadMediaOptions() {
        if (SelectedConversion is null)
            return;

        chkRemoveMetadata.Checked = SelectedConversion.RemoveMetadata;
        chkHideFfmpegMetadata.Checked = SelectedConversion.HideFfmpegMetadata;
        chkCopyCodecs.Checked = SelectedConversion.CopyCodecs;
        tpStartingTime.Value = SelectedConversion.StartTime;
        tpEndingTime.Value = SelectedConversion.EndTime;

        numVideoBitrate.Value = SelectedConversion.VideoBitrate;
        chkVideoUseCRF.Checked = SelectedConversion.VideoUseCRF;
        cbVideoCRF.SelectedIndex = SelectedConversion.VideoCRF;
        chkVideoFaststart.Checked = SelectedConversion.VideoFastStart;
        cbVideoPreset.SelectedIndex = (int)SelectedConversion.VideoPreset;
        cbVideoProfile.SelectedIndex = (int)SelectedConversion.VideoProfile;

        numAudioBitrate.Value = SelectedConversion.AudioBitrate;
        chkAudioUseVBR.Checked = SelectedConversion.AudioUseVBR;
        cbAudioVBR.SelectedIndex = SelectedConversion.AudioVBR;
    }

    private bool IsStreamDisabled() { 
        if (lvVideoStreams.Items.Count > 0) {
            for (int i = 0; i < lvVideoStreams.Items.Count; i++) {
                if (!lvVideoStreams.Items[i].Checked)
                    return true;
            }
        }
        if (lvAudioStreams.Items.Count > 0) {
            for (int i = 0; i < lvAudioStreams.Items.Count; i++) {
                if (!lvAudioStreams.Items[i].Checked)
                    return true;
            }
        }
        if (lvSubtitles.Items.Count > 0) {
            for (int i = 0; i < lvSubtitles.Items.Count; i++) {
                if (!lvSubtitles.Items[i].Checked)
                    return true;
            }
        }
        if (lvAttachments.Items.Count > 0) {
            for (int i = 0; i < lvAttachments.Items.Count; i++) {
                if (!lvAttachments.Items[i].Checked)
                    return true;
            }
        }
        if (lvData.Items.Count > 0) {
            for (int i = 0; i < lvData.Items.Count; i++) {
                if (!lvData.Items[i].Checked)
                    return true;
            }
        }
        return false;
    }

    private void txtInput_ButtonClick(object sender, EventArgs e) {
        using OpenFileDialog ofd = new() {
            Filter = Formats.AllFormats,
            Multiselect = false,
            Title = "Select a input file"
        };

        if (ofd.ShowDialog() != DialogResult.OK)
            return;

        ChangeInputFile(ofd.FileName);

        if (chkSelectOutputOnOk.Checked)
            txtOutput_ButtonClick(this, EventArgs.Empty);
    }
    private void txtOutput_ButtonClick(object sender, EventArgs e) {
        using SaveFileDialog sfd = new() {
            Filter = Formats.AllFormats,
            Title = "Save the output as..."
        };
        if (sfd.ShowDialog() != DialogResult.OK)
            return;

        ChangeOutputFile(sfd.FileName);
    }
    private void btnConvert_Click(object sender, EventArgs e) {
        if (txtInput.Text.IsNullEmptyWhitespace()) {
            txtInput.Focus();
            System.Media.SystemSounds.Asterisk.Play();
            return;
        }
        if (txtOutput.Text.IsNullEmptyWhitespace()) {
            using SaveFileDialog sfd = new() { };
            if (sfd.ShowDialog() != DialogResult.OK) {
                txtOutput.Focus();
                System.Media.SystemSounds.Asterisk.Play();
                return;
            }
            txtOutput.Text = sfd.FileName;
        }

        if (!Verification.FfmpegAvailable) {
            Verification.RefreshFFmpegLocation();
            if (!Verification.FfmpegAvailable) {
                Log.MessageBox("Could not find ffmpeg.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
        }

        //if (IsStreamDisabled() && (txtInput.Text[txtInput.Text.LastIndexOf('.')..].ToLowerInvariant() != txtOutput.Text[txtOutput.Text.LastIndexOf('.')..].ToLowerInvariant())) {
        //    switch (Log.MessageBox("Disabling streams requires copying codecs (and using the same container as the input file). Would you like to make a buffer and re-encode?", MessageBoxButtons.YesNoCancel)) {
        //        case DialogResult.Yes: {

        //        } break;
        //        case DialogResult.Cancel: return;
        //    }
        //}

        string Args = GetArgs(txtInput.Text, txtOutput.Text);
        txtGeneratedArgs.Text = Args;
        System.Diagnostics.Process.Start(Verification.FFmpegPath, Args);
    }
    private void chkVideoUseCRF_CheckedChanged(object sender, EventArgs e) {
        if (chkVideoUseCRF.Checked) {
            cbVideoCRF.Enabled = cbVideoCRF.Visible = true;
            numVideoBitrate.Enabled = numVideoBitrate.Visible = lbVideoBitrate.Visible = false; 
        }
        else {
            cbVideoCRF.Enabled = cbVideoCRF.Visible = false;
            numVideoBitrate.Enabled = numVideoBitrate.Visible = lbVideoBitrate.Visible = true;
        }
    }
    private void btnDebugGenerateArgs_Click(object sender, EventArgs e) {
        if (txtOutput.Text.IsNullEmptyWhitespace()) {
            using SaveFileDialog sfd = new() { };
            if (sfd.ShowDialog() != DialogResult.OK) {
                txtOutput.Focus();
                System.Media.SystemSounds.Asterisk.Play();
                return;
            }
            txtOutput.Text = sfd.FileName;
        }
        txtGeneratedArgs.Text = SelectedConversion.GenerateArguments(); //GetArgs(txtInput.Text, txtOutput.Text);
    }

    private void frmExtendedConverter_DragEnter(object sender, DragEventArgs e) {
        if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
            string[] Files = (string[])e.Data.GetData(DataFormats.FileDrop);
            e.Effect = File.Exists(Files[0]) ? DragDropEffects.Copy : DragDropEffects.None;
        }
    }
    private void frmExtendedConverter_DragDrop(object sender, DragEventArgs e) {
        string[] Files = (string[])e.Data.GetData(DataFormats.FileDrop);
        if (ChangeInputFile(Files[0]))
            System.Media.SystemSounds.Asterisk.Play();
    }

}