using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmBatch : Form {
        public string argsText = string.Empty;

        public frmBatch() {
            InitializeComponent();
            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\args.txt")) {
                argsText = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\args.txt");

                if (argsText.Replace(" ", "") == "")
                    argsText = "<empty args.txt>";
            }
            else {
                argsText = "<args.txt unavailable>";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            if (comboBox1.SelectedIndex < 0) {
                return;
            }

            listLink.Items.Add(textBox1.Text);
            listType.Items.Add(comboBox1.GetItemText(comboBox1.SelectedItem));
            switch (comboBox1.SelectedIndex) {
                case 2:
                    listArgs.Items.Add(argsText);
                    break;
                case 3:
                    if (Saved.Default.downloadArgs.Replace(" ", "") == "") {
                        listArgs.Items.Add("<saved args empty>");
                    }
                    else {
                        listArgs.Items.Add(Saved.Default.downloadArgs);
                    }
                    break;
                case 4:
                    listArgs.Items.Add(textBox2.Text);
                    break;
                default:
                    listArgs.Items.Add("<n/a>");
                    break;
            }
            if (comboBox1.SelectedIndex < 4) {
            }
            else {
            }

            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            if (listLink.SelectedIndex == -1) {
                return;
            }

            int currentIndex = listLink.SelectedIndex;
            listLink.Items.RemoveAt(currentIndex);
            listType.Items.RemoveAt(currentIndex);
            listArgs.Items.RemoveAt(currentIndex);
            if (currentIndex + 1 > listLink.Items.Count) {
                listLink.SelectedIndex = currentIndex - 1;
            }
            else {
                listLink.SelectedIndex = currentIndex;
            }
        }

        private void btnStart_Click(object sender, EventArgs e) {

        }

        private void listLink_SelectedIndexChanged(object sender, EventArgs e) {
            listType.SelectedIndex = listLink.SelectedIndex;
            listArgs.SelectedIndex = listLink.SelectedIndex;
        }
    }
}
