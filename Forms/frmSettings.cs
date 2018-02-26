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
    public partial class frmSettings : Form {

        public frmSettings() {
            InitializeComponent();
        }
        private void frmSettings_Shown(object sender, EventArgs e) {
            loadSettings();
        }

        #region Methods
        private void loadSettings() {
            txtDownloadLocation.Text = Settings.Default.DownloadDir;
            chkHoverURL.Checked = Settings.Default.HoverURL;
            chkAutoClearURL.Checked = Settings.Default.ClearURL;
            chkDeleteExecutable.Checked = Settings.Default.DeleteAfterClose;
            chkUpdate.Checked = Settings.Default.UpdateDL;
            numUpdateDays.Value = Settings.Default.DaysBetweenUpdate;
            chkSaveArgs.Checked = Settings.Default.saveArgs;
            chkSaveToMaster.Checked = Settings.Default.SaveToMaster;
            chkUpdateCheck.Checked = Settings.Default.updateCheck;
            chkSaveDLParams.Checked = Settings.Default.saveDlParams;
            chkSaveConvParams.Checked = Settings.Default.saveConvParams;
            chkSeperateDownloads.Checked = Settings.Default.sortDownloads;
            chkStaticYTDL.Checked = Settings.Default.staticYTD;
            txtYtDl.Text = Settings.Default.youtubedlDir;

            if (chkStaticYTDL.Checked) {
                btnYtDl.Enabled = true;
            }
            else {
                btnYtDl.Enabled = false;
            }
        }
        private void saveSettings() {
            if (Settings.Default.DownloadDir != txtDownloadLocation.Text)
                Settings.Default.DownloadDir = txtDownloadLocation.Text;
            if (Settings.Default.HoverURL != chkHoverURL.Checked)
                Settings.Default.HoverURL = chkHoverURL.Checked;
            if (Settings.Default.ClearURL != chkAutoClearURL.Checked)
                Settings.Default.ClearURL = chkAutoClearURL.Checked;
            if (Settings.Default.DeleteAfterClose != chkDeleteExecutable.Checked)
                Settings.Default.DeleteAfterClose = chkDeleteExecutable.Checked;
            if (Settings.Default.UpdateDL != chkUpdate.Checked)
                Settings.Default.UpdateDL = chkUpdate.Checked;
            if (Settings.Default.DaysBetweenUpdate != Convert.ToInt32(numUpdateDays.Value))
                Settings.Default.DaysBetweenUpdate = Convert.ToInt32(numUpdateDays.Value);
            if (Settings.Default.saveArgs != chkSaveArgs.Checked)
                Settings.Default.saveArgs = chkSaveArgs.Checked;
            if (Settings.Default.SaveToMaster != chkSaveToMaster.Checked)
                Settings.Default.SaveToMaster = chkSaveToMaster.Checked;
            if (Settings.Default.updateCheck != chkUpdateCheck.Checked)
                Settings.Default.updateCheck = chkUpdateCheck.Checked;
            if (Settings.Default.saveDlParams != chkSaveDLParams.Checked)
                Settings.Default.saveDlParams = chkSaveDLParams.Checked;
            if (Settings.Default.saveConvParams != chkSaveConvParams.Checked)
                Settings.Default.saveConvParams = chkSaveConvParams.Checked;
            if (Settings.Default.sortDownloads != chkSeperateDownloads.Checked)
                Settings.Default.sortDownloads = chkSeperateDownloads.Checked;
            if (Settings.Default.staticYTD != chkStaticYTDL.Checked)
                Settings.Default.staticYTD = chkStaticYTDL.Checked;
            if (Settings.Default.staticYTD && Settings.Default.youtubedlDir != txtYtDl.Text)
                Settings.Default.youtubedlDir = txtYtDl.Text;

            Settings.Default.Save();
        }
        #endregion

        private void btnBrws_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog { Description = "Select a folder to save downloads to" };
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtDownloadLocation.Text = fbd.SelectedPath;
        }
        private void btnYtDl_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog { Description = "Select a folder to store youtube-dl.exe" };
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK){
                txtYtDl.Text = fbd.SelectedPath;
            }
            else {
                txtYtDl.Text = Settings.Default.youtubedlDir + @"\youtube-dl.exe";
            }
        }
        private void chkStaticYTDL_CheckedChanged(object sender, EventArgs e) {
            if (chkStaticYTDL.Checked) {
                FolderBrowserDialog fbd = new FolderBrowserDialog { Description = "Select a folder to store youtube-dl.exe" };
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    btnYtDl.Enabled = true;
                    txtYtDl.Text = fbd.SelectedPath + "\\youtube-dl.exe";
                }
                else {
                    btnYtDl.Enabled = false;
                    chkStaticYTDL.Checked = false;
                    txtYtDl.Text = Environment.CurrentDirectory + "\\youtube-dl.exe";
                }
            }
            else {
                btnYtDl.Enabled = false;
            }
        }
        private void btnRedownload_Click(object sender, EventArgs e) {
            Download.downloadYoutubeDL(Settings.Default.youtubedlDir);
        }
        private void btnSave_Click(object sender, EventArgs e) {
            saveSettings();
            this.Dispose();
        }
        private void btnCancel_Click(object sender, EventArgs e) {
            this.Dispose();
        }

    }
}
