using System.Windows.Forms;

namespace youtube_dl_gui.Tests {
    public partial class frmMerger : Form {

        private readonly List<FfprobeData> LoadedMediaFiles = new();

        public frmMerger() {
            InitializeComponent();
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
                                NewData.MediaStreams[x].Node = new TreeNode(NewData.MediaStreams[x].codec_long_name) {
                                    Tag = NewData
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
            tvSelectedStreams.Nodes[tvSelectedSources.SelectedNode.Parent.Index - 1].Nodes.Add((TreeNode)tvSelectedSources.SelectedNode.Clone());
        }

        private void tvSelectedStreams_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            tvSelectedStreams.SelectedNode.Remove();
        }
    }
}
