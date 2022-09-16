namespace youtube_dl_gui_updater {
    partial class frmUpdater {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lbUpdaterHeader = new System.Windows.Forms.Label();
            this.lbUpdaterDetails = new System.Windows.Forms.Label();
            this.tmrForm = new System.Windows.Forms.Timer(this.components);
            this.pbDownloadProgress = new murrty.controls.ExtendedProgressBar();
            this.lbUpdaterVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbUpdaterHeader
            // 
            this.lbUpdaterHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUpdaterHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdaterHeader.Location = new System.Drawing.Point(12, 9);
            this.lbUpdaterHeader.Name = "lbUpdaterHeader";
            this.lbUpdaterHeader.Size = new System.Drawing.Size(210, 26);
            this.lbUpdaterHeader.TabIndex = 1;
            this.lbUpdaterHeader.Text = "lbUpdaterHeader";
            this.lbUpdaterHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbUpdaterDetails
            // 
            this.lbUpdaterDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUpdaterDetails.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdaterDetails.Location = new System.Drawing.Point(12, 38);
            this.lbUpdaterDetails.Name = "lbUpdaterDetails";
            this.lbUpdaterDetails.Size = new System.Drawing.Size(210, 44);
            this.lbUpdaterDetails.TabIndex = 2;
            this.lbUpdaterDetails.Text = "lbUpdaterDetails";
            this.lbUpdaterDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tmrForm
            // 
            this.tmrForm.Enabled = true;
            this.tmrForm.Interval = 1000;
            this.tmrForm.Tick += new System.EventHandler(this.tmrForm_Tick);
            // 
            // pbDownloadProgress
            // 
            this.pbDownloadProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDownloadProgress.ContainerParent = this;
            this.pbDownloadProgress.FastValueUpdate = true;
            this.pbDownloadProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbDownloadProgress.Location = new System.Drawing.Point(12, 84);
            this.pbDownloadProgress.Maximum = 200;
            this.pbDownloadProgress.Name = "pbDownloadProgress";
            this.pbDownloadProgress.ProgressState = murrty.controls.ProgressBarState.Normal;
            this.pbDownloadProgress.ShowInTaskbar = true;
            this.pbDownloadProgress.ShowText = true;
            this.pbDownloadProgress.Size = new System.Drawing.Size(210, 24);
            this.pbDownloadProgress.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
            this.pbDownloadProgress.TabIndex = 0;
            this.pbDownloadProgress.Text = "pbDownloadProgressPreparing";
            // 
            // lbUpdaterVersion
            // 
            this.lbUpdaterVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbUpdaterVersion.AutoSize = true;
            this.lbUpdaterVersion.Location = new System.Drawing.Point(9, 113);
            this.lbUpdaterVersion.Name = "lbUpdaterVersion";
            this.lbUpdaterVersion.Size = new System.Drawing.Size(88, 13);
            this.lbUpdaterVersion.TabIndex = 3;
            this.lbUpdaterVersion.Text = "lbUpdaterVersion";
            // 
            // frmUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(234, 135);
            this.Controls.Add(this.lbUpdaterVersion);
            this.Controls.Add(this.pbDownloadProgress);
            this.Controls.Add(this.lbUpdaterDetails);
            this.Controls.Add(this.lbUpdaterHeader);
            this.Icon = global::youtube_dl_gui_updater.Properties.Resources.ProgramIcon;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(250, 170);
            this.MinimumSize = new System.Drawing.Size(250, 170);
            this.Name = "frmUpdater";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUpdater";
            this.Shown += new System.EventHandler(this.frmUpdater_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private murrty.controls.ExtendedProgressBar pbDownloadProgress;
        private System.Windows.Forms.Label lbUpdaterHeader;
        private System.Windows.Forms.Label lbUpdaterDetails;
        private System.Windows.Forms.Timer tmrForm;
        private System.Windows.Forms.Label lbUpdaterVersion;
    }
}

