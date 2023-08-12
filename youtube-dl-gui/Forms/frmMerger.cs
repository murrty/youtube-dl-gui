namespace youtube_dl_gui;

using System.IO;
using System.Windows.Forms;

public partial class frmMerger : LocalizedForm {

    private List<FfprobeData> LoadedMediaFiles { get; } = new();

    public frmMerger() {
        InitializeComponent();
        LoadLanguage();

        tvSelectedSources.HandleCreated += (s, e) => murrty.controls.natives.NativeMethods.SetWindowTheme(tvSelectedSources.Handle, "Explorer", null);
        tvSelectedStreams.HandleCreated += (s, e) => murrty.controls.natives.NativeMethods.SetWindowTheme(tvSelectedStreams.Handle, "Explorer", null);
    }
    private void frmMerger_DragEnter(object sender, DragEventArgs e) {
        if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
            string[] Files = (string[])e.Data.GetData(DataFormats.FileDrop);
            e.Effect = File.Exists(Files[0]) ? DragDropEffects.Copy : DragDropEffects.None;
        }
    }
    private void frmMerger_DragDrop(object sender, DragEventArgs e) {
        string[] Files = (string[])e.Data.GetData(DataFormats.FileDrop);
        AddFiles(Files);
    }

    public override void LoadLanguage() {
        this.Text = Language.frmMerger;
        btnAddFiles.Text = Language.GenericAdd;
        btnRemoveFiles.Text = Language.GenericRemove;
        btnAddFiles.Text = Language.GenericAdd;
        btnMergeFiles.Text = Language.btnMerge;

        tvSelectedSources.Nodes[1].Text = Language.frmMergerVideoSources;
        tvSelectedSources.Nodes[2].Text = Language.frmMergerAudioSources;
        tvSelectedSources.Nodes[3].Text = Language.frmMergerSubtitleSources;
        tvSelectedSources.Nodes[4].Text = Language.frmMergerAttatchmentSources;

        tvSelectedStreams.Nodes[0].Text = Language.frmMergerVideoSources;
        tvSelectedStreams.Nodes[1].Text = Language.frmMergerAudioSources;
        tvSelectedStreams.Nodes[2].Text = Language.frmMergerSubtitleSources;
        tvSelectedStreams.Nodes[3].Text = Language.frmMergerAttatchmentSources;

    }
    private string GenerateList() {
        List<string> Files = new();
        StringBuilder InputArgument = new(string.Empty);
        StringBuilder MapArgument = new(string.Empty);

        int FileIndex;
        FfprobeNodeTag CurrentFile;
        foreach (TreeNode RootNode in tvSelectedStreams.Nodes) {
            if (RootNode.Nodes.Count > 0) {
                for (int i = 0; i < RootNode.Nodes.Count; i++) {
                    CurrentFile = (FfprobeNodeTag)RootNode.Nodes[i].Tag;
                    FileIndex = Files.IndexOf(CurrentFile.ParentFile.Format.filename);
                    if (FileIndex == -1) {
                        Files.Add(CurrentFile.ParentFile.Format.filename);
                        InputArgument.Append($"-i \"{CurrentFile.ParentFile.Format.filename}\" ");
                        FileIndex = Files.Count - 1;
                    }
                    MapArgument.Append($"-map {FileIndex}:{CurrentFile.Stream.index} ");
                }
            }
        }

        return Files.Count > 0 ? $"{InputArgument}{MapArgument.ToString().Trim()}" : null;
    }
    private bool AddFile(string FilePath) {
        string ffdata = string.Empty;
        try {
            FfprobeData NewData = FfprobeData.GenerateData(FilePath, out ffdata);

            if (NewData is null || NewData.MediaStreams is null || NewData.MediaStreams.Length < 1)
                return false;

            for (int x = 0; x < NewData.MediaStreams.Length; x++) {
                FfprobeNodeTag CurrentTag = new() {
                    ParentFile = NewData,
                    Stream = NewData.MediaStreams[x]
                };

                NewData.MediaStreams[x].Node = new TreeNode($"{x} - {NewData.MediaStreams[x].codec_long_name}") {
                    Tag = CurrentTag
                };

                NewData.MediaStreams[x].QueuedNode = new TreeNode($"{x} - {NewData.MediaStreams[x].codec_long_name}") {
                    Tag = CurrentTag
                };
            }
            LoadedMediaFiles.Add(NewData);
            lbFileSources.Items.Add(FilePath);
            NewData.FileName = FilePath;
            NewData.FilePath = FilePath;
            return true;
        }
        catch (Exception ex) {
            Log.ReportException(ex, ffdata);
        }
        return false;
    }
    private void AddFiles(string[] Files) {
        int Failures = 0;
        for (int i = 0; i < Files.Length; i++) {
            if (!AddFile(Files[i]))
                Failures++;
        }
        if (Failures > 0)
            System.Media.SystemSounds.Exclamation.Play();
    }

    private void btnAddFiles_Click(object sender, EventArgs e) {
        using OpenFileDialog ofd = new() {
            Title = "Select media sources to add to the merge",
            Multiselect = true
        };

        if (ofd.ShowDialog() != DialogResult.OK)
            return;

        AddFiles(ofd.FileNames);
    }
    private void btnRemoveFiles_Click(object sender, EventArgs e) {
        if (lbFileSources.SelectedItems.Count > 0) {
            int index = lbFileSources.SelectedIndex;
            for (int i = 0; i < LoadedMediaFiles[index].MediaStreams.Length; i++) {
                LoadedMediaFiles[index].MediaStreams[i].Node.Remove();
                LoadedMediaFiles[index].MediaStreams[i].QueuedNode.Remove();
            }
            LoadedMediaFiles.RemoveAt(index);
            lbFileSources.Items.RemoveAt(index);
            if (lbFileSources.Items.Count <= index) {
                index--;
            }
            lbFileSources.SelectedIndex = index;
        }
    }
    private void btnMergeFiles_Click(object sender, EventArgs e) {
        string Argument = GenerateList();
        if (Argument is not null) {
            using SaveFileDialog sfd = new();
            sfd.Title = "Select a place to save the merged file to";
            if (sfd.ShowDialog() == DialogResult.OK) {
                ConvertInfo MergerInfo = new() {
                    CustomArguments = Argument + $" \"{sfd.FileName}\"",
                    FullCustomArguments = true
                };
                frmConverter Merger = new(MergerInfo);
                Merger.Show();
            }
        }
    }

    private void lbFileSources_SelectedIndexChanged(object sender, EventArgs e) {
        tvSelectedSources.Nodes[1].Nodes.Clear();
        tvSelectedSources.Nodes[2].Nodes.Clear();
        tvSelectedSources.Nodes[3].Nodes.Clear();
        tvSelectedSources.Nodes[4].Nodes.Clear();

        if (lbFileSources.SelectedItems.Count > 0) {
            tvSelectedSources.Nodes[0].Text = System.IO.Path.GetFileName(LoadedMediaFiles[lbFileSources.SelectedIndex].Format.filename);
            for (int i = 0; i < LoadedMediaFiles[lbFileSources.SelectedIndex].MediaStreams.Length; i++) {
                switch (LoadedMediaFiles[lbFileSources.SelectedIndex].MediaStreams[i].codec_type.ToLowerInvariant()) {
                    case "video": {
                        tvSelectedSources.Nodes[1].Nodes.Add(LoadedMediaFiles[lbFileSources.SelectedIndex].MediaStreams[i].Node);
                    } break;

                    case "audio": {
                        tvSelectedSources.Nodes[2].Nodes.Add(LoadedMediaFiles[lbFileSources.SelectedIndex].MediaStreams[i].Node);
                    } break;

                    case "subtitles":
                    case "subtitle": {
                        tvSelectedSources.Nodes[3].Nodes.Add(LoadedMediaFiles[lbFileSources.SelectedIndex].MediaStreams[i].Node);
                    } break;

                    case "attatchments":
                    case "attatchment": {
                        tvSelectedSources.Nodes[4].Nodes.Add(LoadedMediaFiles[lbFileSources.SelectedIndex].MediaStreams[i].Node);
                    } break;
                }
            }
            ttFiles.SetToolTip(lbFileSources, LoadedMediaFiles[lbFileSources.SelectedIndex].FilePath);
        }
        else {
            tvSelectedSources.Nodes[0].Text = "<---";
            ttFiles.SetToolTip(lbFileSources, null);
        }
    }
    private void tvSelectedSources_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
        if (e.Node is null)
            return;

        if (e.Node.Parent is null) {
            if (tvSelectedSources.Nodes[1].Nodes.Count > 0) {
                for (int i = 0; i < tvSelectedSources.Nodes[1].Nodes.Count; i++) {
                    tvSelectedStreams.Nodes[0].Nodes.Add(((FfprobeNodeTag)tvSelectedSources.Nodes[1].Nodes[i].Tag).Stream.QueuedNode);
                }
            }

            if (tvSelectedSources.Nodes[2].Nodes.Count > 0) {
                for (int i = 0; i < tvSelectedSources.Nodes[2].Nodes.Count; i++) {
                    tvSelectedStreams.Nodes[1].Nodes.Add(((FfprobeNodeTag)tvSelectedSources.Nodes[2].Nodes[i].Tag).Stream.QueuedNode);
                }
            }

            if (tvSelectedSources.Nodes[3].Nodes.Count > 0) {
                for (int i = 0; i < tvSelectedSources.Nodes[3].Nodes.Count; i++) {
                    tvSelectedStreams.Nodes[2].Nodes.Add(((FfprobeNodeTag)tvSelectedSources.Nodes[3].Nodes[i].Tag).Stream.QueuedNode);
                }
            }

            if (tvSelectedSources.Nodes[4].Nodes.Count > 0) {
                for (int i = 0; i < tvSelectedSources.Nodes[4].Nodes.Count; i++) {
                    tvSelectedStreams.Nodes[3].Nodes.Add(((FfprobeNodeTag)tvSelectedSources.Nodes[4].Nodes[i].Tag).Stream.QueuedNode);
                }
            }

            return;
        }

        TreeNode Node = ((FfprobeNodeTag)tvSelectedSources.SelectedNode.Tag).Stream.QueuedNode;
        int SelectedIndex = tvSelectedSources.SelectedNode.Parent.Index - 1;

        if (tvSelectedStreams.Nodes[SelectedIndex].Nodes.Contains(Node)) {
            tvSelectedStreams.Focus();
            tvSelectedStreams.SelectedNode = Node;
            System.Media.SystemSounds.Asterisk.Play();
            return;
        }
        
        tvSelectedStreams.Nodes[SelectedIndex].Nodes.Add(Node);
        //tvSelectedStreams.Nodes[tvSelectedSources.SelectedNode.Parent.Index - 1].Nodes.Add(
        //    ((FfprobeNodeTag)tvSelectedSources.SelectedNode.Tag).Stream.QueuedNode);
    }
    private void tvSelectedStreams_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
        tvSelectedStreams.SelectedNode.Remove();
    }
}