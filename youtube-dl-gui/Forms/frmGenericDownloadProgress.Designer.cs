namespace youtube_dl_gui {
    partial class frmGenericDownloadProgress {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            this.pbProgress = new murrty.controls.ExtendedProgressBar();
            this.SuspendLayout();
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgress.ContainerParent = this;
            this.pbProgress.FastValueUpdate = true;
            this.pbProgress.Location = new System.Drawing.Point(12, 12);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.ShowText = true;
            this.pbProgress.Size = new System.Drawing.Size(200, 21);
            this.pbProgress.TabIndex = 0;
            this.pbProgress.Text = "0% (0B / 0B)";
            // 
            // frmGenericDownloadProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(224, 45);
            this.Controls.Add(this.pbProgress);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = global::youtube_dl_gui.Properties.Resources.ProgramIcon;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(240, 80);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(240, 80);
            this.Name = "frmGenericDownloadProgress";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGenericDownloadProgress";
            this.ResumeLayout(false);

        }

        #endregion

        private murrty.controls.ExtendedProgressBar pbProgress;
    }
}