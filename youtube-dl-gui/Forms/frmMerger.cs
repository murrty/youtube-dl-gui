using System.Diagnostics;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmMerger : Form {

        private readonly List<FfprobeData> LoadedMediaFiles = new();

        public frmMerger() {
            InitializeComponent();
        }

        private string GenerateList() {
            List<string> Files = new();
            StringBuilder InputArgument = new(string.Empty);
            StringBuilder MapArgument = new(string.Empty);

            int FileIndex = -1;
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
                        //switch (RootNode.Index) {
                        //    case 0: { // vid
                        //        Arguments[FileIndex].Append($"-map {FileIndex}:{CurrentFile.Stream.index}");
                        //    } break;
                        //    case 1: { // aud
                        //        Arguments[FileIndex].Append($"-map {FileIndex}:{CurrentFile.Stream.index}");
                        //    } break;
                        //    case 2: { // sub
                        //        Arguments[FileIndex].Append($"-map {FileIndex}:{CurrentFile.Stream.index}");
                        //    } break;
                        //    case 3: { // att
                        //        Arguments[FileIndex].Append($"-map {FileIndex}:{CurrentFile.Stream.index}");
                        //    } break;
                        //}
                    }
                }
            }

            return Files.Count > 0 ? $"{InputArgument}{MapArgument.ToString().Trim()}" : null;
        }

        private void btnAddFiles_Click(object sender, EventArgs e) {
            using OpenFileDialog ofd = new() {
                Title = "Select media sources to add to the merge",
                Multiselect = true
            };
            if (ofd.ShowDialog() == DialogResult.OK) {
                string ffdata = null;
                for (int i = 0; i < ofd.FileNames.Length; i++) {
                    try {
                        FfprobeData NewData = FfprobeData.GenerateData(ofd.FileNames[i], out ffdata);
                        if (NewData.MediaStreams.Length > 0) {
                            for (int x = 0; x < NewData.MediaStreams.Length; x++) {
                                FfprobeNodeTag CurrentTag = new() {
                                    ParentFile = NewData,
                                    Stream = NewData.MediaStreams[x]
                                };
                                NewData.MediaStreams[x].Node = new TreeNode(NewData.MediaStreams[x].codec_long_name) {
                                    Tag = CurrentTag
                                };

                                NewData.MediaStreams[x].QueuedNode = new TreeNode(NewData.MediaStreams[x].codec_long_name) {
                                    Tag = CurrentTag
                                };
                            }
                            LoadedMediaFiles.Add(NewData);
                            lbFileSources.Items.Add(ofd.SafeFileNames[i]);
                        }
                    }
                    catch (Exception ex) {
                        Log.ReportException(ex, ffdata);
                    }
                }
            }
            Console.WriteLine();
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

        private void lbFileSources_SelectedIndexChanged(object sender, EventArgs e) {
            tvSelectedSources.Nodes[1].Nodes.Clear();
            tvSelectedSources.Nodes[2].Nodes.Clear();
            tvSelectedSources.Nodes[3].Nodes.Clear();
            tvSelectedSources.Nodes[4].Nodes.Clear();

            if (lbFileSources.SelectedItems.Count > 0) {
                tvSelectedSources.Nodes[0].Text = System.IO.Path.GetFileName(LoadedMediaFiles[lbFileSources.SelectedIndex].Format.filename);
                for (int i = 0; i < LoadedMediaFiles[lbFileSources.SelectedIndex].MediaStreams.Length; i++) {
                    switch (LoadedMediaFiles[lbFileSources.SelectedIndex].MediaStreams[i].codec_type.ToLower()) {
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
            }
            else {
                tvSelectedSources.Nodes[0].Text = "<---";
            }
        }

        private void tvSelectedSources_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            tvSelectedStreams.Nodes[tvSelectedSources.SelectedNode.Parent.Index - 1].Nodes.Add(
                ((FfprobeNodeTag)tvSelectedSources.SelectedNode.Tag).Stream.QueuedNode);
        }

        private void tvSelectedStreams_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            tvSelectedStreams.SelectedNode.Remove();
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
    }
}
