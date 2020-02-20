using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmAbout : Form {
        Thread checkUpdates;

        public frmAbout() {
            InitializeComponent();
        }
        private void frmAbout_Shown(object sender, EventArgs e) {
            if (!Properties.Settings.Default.jsonSupport)
                llbCheckForUpdates.Enabled = false;

            lbVersion.Text = "v" + Properties.Settings.Default.appVersion.ToString();
            lbBody.Text = lbBody.Text.Replace("{DEBUG}", Properties.Settings.Default.debugDate);
        }

        private void llbCheckForUpdates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (!Properties.Settings.Default.jsonSupport)
                return;

            checkUpdates = new Thread(() => {
                decimal cV = Updater.getCloudVersion();
                if (Updater.isUpdateAvailable(cV)) {
                    if (MessageBox.Show("An update is available.\nNew verison: " + cV.ToString() + " | Your version: " + Properties.Settings.Default.appVersion.ToString() + "\n\nWould you like to update?", "youtube-dl-gui", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                        if (Updater.downloadNewVersion(cV)) {
                            Updater.runMerge();
                            Environment.Exit(0);
                        }
                    }
                }
                else {
                    MessageBox.Show("No update is available at this time.");
                }
                this.Invoke((MethodInvoker)(() => checkUpdates.Abort()));
            });
            checkUpdates.Start();
        }
        private void pbIcon_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/murrty/youtube-dl-gui/");
        }

        private void llbGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/murrty/youtube-dl-gui");
        }

        private void llbGitlab_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            //Process.Start("https://gitlab.com/murrty/youtube-dl-gui");
        }
    }
}
