using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui.Forms {
    public partial class frmConverter : Form {
        public bool Debugging = false;

        private Process ConvertProcess = new Process();
        private Thread ConvertThread = new Thread(() => { });
        private int ExitCode = -1;
        private bool ConvertFinished = false;
        private bool ConvertAborted = false;
        private bool ConvertErrored = false;
        private bool CloseFromMethod = false;

        public frmConverter() {
            InitializeComponent();
            this.Icon = Properties.Resources.youtube_dl_gui;
        }

        private void frmConverter_Load(object sender, EventArgs e) {

        }
        private void tmrTitleActivity_Tick(object sender, EventArgs e) {

        }

    }
}
