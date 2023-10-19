#nullable enable
namespace youtube_dl_gui;
using System;
using System.Data.SqlTypes;
using System.IO;
using System.Text;
using System.Windows.Forms;
public partial class frmExtendedConverter : LocalizedForm {
    private ExtendedConversionDetails? SelectedConversion;

    public frmExtendedConverter() {
        InitializeComponent();

        cbVideoPreset.SelectedIndex = 5;
        cbVideoProfile.SelectedIndex = 1;
        cbAudioSampleRate.SelectedIndex = 1;
    }
    public frmExtendedConverter(string Input) : this() => ChangeInputFile(Input);
    public frmExtendedConverter(string Input, string Output) : this(Input) => ChangeOutputFile(Output);

    public override void LoadLanguage() {
    }

    private bool ChangeInputFile(string InputFile) {
        if (!File.Exists(InputFile)) {
            txtInput.Focus();
            System.Media.SystemSounds.Exclamation.Play();
            return false;
        }

        ExtendedConversionDetails NewDetails = new(InputFile);
        if (!txtOutput.Text.IsNullEmptyWhitespace()) {
            NewDetails.OutputFilePath = txtOutput.Text;
        }

        try {
            NewDetails.GetMediaDetails();
        }
        catch {
            System.Media.SystemSounds.Exclamation.Play();
            return false;
        }

        SelectedConversion = NewDetails;
        txtInput.Text = InputFile;

        if (lvVideoStreams.Items.Count > 0) {
            lvVideoStreams.Items.Clear();
        }
        if (SelectedConversion.VideoItems.Count > 0) {
            SelectedConversion.VideoItems.For((Stream) => lvVideoStreams.Items.Add(Stream));
            if (!tcMain.TabPages.Contains(tpVideoStreams)) {
                tcMain.TabPages.Add(tpVideoStreams);
            }
        }
        else if (tcMain.TabPages.Contains(tpVideoStreams)) {
            tcMain.TabPages.Remove(tpVideoStreams);
        }

        if (lvAudioStreams.Items.Count > 0) {
            lvAudioStreams.Items.Clear();
        }
        if (SelectedConversion.AudioItems.Count > 0) {
            SelectedConversion.AudioItems.For((Stream) => lvAudioStreams.Items.Add(Stream));
            if (!tcMain.TabPages.Contains(tpAudioStreams)) {
                tcMain.TabPages.Add(tpAudioStreams);
            }
        }
        else if (tcMain.TabPages.Contains(tpAudioStreams)) {
            tcMain.TabPages.Remove(tpAudioStreams);
        }

        if (lvSubtitles.Items.Count > 0) {
            lvSubtitles.Items.Clear();
        }
        if (SelectedConversion.SubtitleItems.Count > 0) {
            SelectedConversion.SubtitleItems.For((Stream) => lvSubtitles.Items.Add(Stream));
            if (!tcMain.TabPages.Contains(tpSubtitles)) {
                tcMain.TabPages.Add(tpSubtitles);
            }
        }
        else if (tcMain.TabPages.Contains(tpSubtitles)) {
            tcMain.TabPages.Remove(tpSubtitles);
        }

        if (lvAttachments.Items.Count > 0) {
            lvAttachments.Items.Clear();
        }
        if (SelectedConversion.AttachmentItems.Count > 0) {
            SelectedConversion.AttachmentItems.For((Stream) => lvAttachments.Items.Add(Stream));
            if (!tcMain.TabPages.Contains(tpAttachments)) {
                tcMain.TabPages.Add(tpAttachments);
            }
        }
        else if (tcMain.TabPages.Contains(tpAttachments)) {
            tcMain.TabPages.Remove(tpAttachments);
        }

        if (lvData.Items.Count > 0) {
            lvData.Items.Clear();
        }
        if (SelectedConversion.DataFileItems.Count > 0) {
            SelectedConversion.DataFileItems.For((Stream) => lvData.Items.Add(Stream));
            if (!tcMain.TabPages.Contains(tpData)) {
                tcMain.TabPages.Add(tpData);
            }
        }
        else if (tcMain.TabPages.Contains(tpData)) {
            tcMain.TabPages.Remove(tpData);
        }

        return true;
    }
    private void ChangeOutputFile(string OutputFile) {
        if (SelectedConversion is null) {
            return;
        }

        SelectedConversion.OutputFilePath = OutputFile;
        txtOutput.Text = OutputFile;
    }

    // TODO: Add the "Set x" into the details.
    private void SaveMediaOptions() {
        if (SelectedConversion is null) {
            return;
        }

        SelectedConversion.RemoveMetadata = chkRemoveMetadata.Checked;
        SelectedConversion.HideFfmpegMetadata = chkHideFfmpegMetadata.Checked;
        SelectedConversion.CopyCodecs = chkCopyCodecs.Checked;
        SelectedConversion.StartTime = tpStartingTime.Value;
        SelectedConversion.EndTime = tpEndingTime.Value;

        if (chkSetVideoQuality.Checked) {
            SelectedConversion.VideoBitrate = numVideoBitrate.Value;
            SelectedConversion.VideoUseCRF = chkVideoUseCRF.Checked;
            SelectedConversion.VideoCRF = cbVideoCRF.SelectedIndex;
        }
        else {
            SelectedConversion.VideoUseCRF = false;
            SelectedConversion.VideoCRF = 0;
            SelectedConversion.VideoBitrate = 0;
        }
        SelectedConversion.VideoPreset = chkVideoSetPreset.Checked ? (VideoPresets)cbVideoPreset.SelectedIndex : VideoPresets.none;
        SelectedConversion.VideoProfile = chkVideoSetProfile.Checked ? (VideoProfiles)cbVideoProfile.SelectedIndex : VideoProfiles.none;
        SelectedConversion.VideoFastStart = chkVideoFaststart.Checked;

        if (chkSetAudioQuality.Checked) {
            SelectedConversion.AudioBitrate = numAudioBitrate.Value;
            SelectedConversion.AudioUseVBR = chkAudioUseVBR.Checked;
            SelectedConversion.AudioVBR = cbAudioVBR.SelectedIndex;
        }
        else {
            SelectedConversion.AudioBitrate = 0;
            SelectedConversion.AudioUseVBR = false;
            SelectedConversion.AudioVBR = 0;
        }
        SelectedConversion.AudioSampleRate = chkAudioSampleRate.Checked ? (AudioSampleRates)cbAudioSampleRate.SelectedIndex : AudioSampleRates.none;
    }
    private void LoadMediaOptions() {
        if (SelectedConversion is null) {
            return;
        }

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
                if (!lvVideoStreams.Items[i].Checked) {
                    return true;
                }
            }
        }
        if (lvAudioStreams.Items.Count > 0) {
            for (int i = 0; i < lvAudioStreams.Items.Count; i++) {
                if (!lvAudioStreams.Items[i].Checked) {
                    return true;
                }
            }
        }
        if (lvSubtitles.Items.Count > 0) {
            for (int i = 0; i < lvSubtitles.Items.Count; i++) {
                if (!lvSubtitles.Items[i].Checked) {
                    return true;
                }
            }
        }
        if (lvAttachments.Items.Count > 0) {
            for (int i = 0; i < lvAttachments.Items.Count; i++) {
                if (!lvAttachments.Items[i].Checked) {
                    return true;
                }
            }
        }
        if (lvData.Items.Count > 0) {
            for (int i = 0; i < lvData.Items.Count; i++) {
                if (!lvData.Items[i].Checked) {
                    return true;
                }
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

        if (ofd.ShowDialog() != DialogResult.OK) {
            return;
        }

        ChangeInputFile(ofd.FileName);

        if (chkSelectOutputOnOk.Checked)
            txtOutput_ButtonClick(this, EventArgs.Empty);
    }
    private void txtOutput_ButtonClick(object sender, EventArgs e) {
        using SaveFileDialog sfd = new() {
            Filter = Formats.AllFormats,
            Title = "Save the output as..."
        };

        if (sfd.ShowDialog() != DialogResult.OK) {
            return;
        }

        ChangeOutputFile(sfd.FileName);
    }
    private void btnConvert_Click(object sender, EventArgs e) {
        if (SelectedConversion is null) {
            return;
        }

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

        SaveMediaOptions();
        SelectedConversion.OutputFilePath = txtOutput.Text;
        SelectedConversion.GenerateArguments();

        //string Args = GetArgs(txtInput.Text, txtOutput.Text);
        System.Diagnostics.Process.Start(Verification.FFmpegPath, SelectedConversion.Arguments);
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
        //txtGeneratedArgs.Text = SelectedConversion.GenerateArguments(); //GetArgs(txtInput.Text, txtOutput.Text);
    }

    private void frmExtendedConverter_DragEnter(object sender, DragEventArgs e) {
        if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
            string[] Files = (string[])e.Data.GetData(DataFormats.FileDrop);
            e.Effect = File.Exists(Files[0]) ? DragDropEffects.Copy : DragDropEffects.None;
        }
    }
    private void frmExtendedConverter_DragDrop(object sender, DragEventArgs e) {
        string[] Files = (string[])e.Data.GetData(DataFormats.FileDrop);
        if (ChangeInputFile(Files[0])) {
            System.Media.SystemSounds.Asterisk.Play();
        }
    }

    private void chkSetVideoQuality_CheckedChanged(object sender, EventArgs e) {
        numVideoBitrate.Enabled = chkSetVideoQuality.Checked;
        cbVideoCRF.Enabled = chkSetVideoQuality.Checked;
        chkVideoUseCRF.Enabled = chkSetVideoQuality.Checked;
    }
    private void chkVideoSetPreset_CheckedChanged(object sender, EventArgs e) {
        cbVideoPreset.Enabled = chkVideoSetPreset.Checked;
    }
    private void chkVideoSetProfile_CheckedChanged(object sender, EventArgs e) {
        cbVideoProfile.Enabled = chkVideoSetProfile.Checked;
    }

    private void chkSetAudioQuality_CheckedChanged(object sender, EventArgs e) {
        numAudioBitrate.Enabled = chkSetAudioQuality.Checked;
        cbAudioVBR.Enabled = chkSetAudioQuality.Checked;
        chkAudioUseVBR.Enabled = chkSetAudioQuality.Checked;
    }
    private void chkAudioSampleRate_CheckedChanged(object sender, EventArgs e) {
        cbAudioSampleRate.Enabled = chkAudioSampleRate.Checked;
    }
}