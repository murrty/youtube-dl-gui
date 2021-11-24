namespace youtube_dl_gui_updater {
    partial class frmUpdater {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdater));
            this.pbDownloadProgress = new System.Windows.Forms.ProgressBar();
            this.lbUpdaterHeader = new System.Windows.Forms.Label();
            this.lbUpdaterDescription = new System.Windows.Forms.Label();
            this.tmrForm = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pbDownloadProgress
            // 
            this.pbDownloadProgress.Location = new System.Drawing.Point(12, 83);
            this.pbDownloadProgress.Name = "pbDownloadProgress";
            this.pbDownloadProgress.Size = new System.Drawing.Size(208, 19);
            this.pbDownloadProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbDownloadProgress.TabIndex = 0;
            // 
            // lbUpdaterHeader
            // 
            this.lbUpdaterHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdaterHeader.Location = new System.Drawing.Point(12, 9);
            this.lbUpdaterHeader.Name = "lbUpdaterHeader";
            this.lbUpdaterHeader.Size = new System.Drawing.Size(208, 26);
            this.lbUpdaterHeader.TabIndex = 1;
            this.lbUpdaterHeader.Text = "lbUpdaterHeader";
            this.lbUpdaterHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbUpdaterDescription
            // 
            this.lbUpdaterDescription.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdaterDescription.Location = new System.Drawing.Point(12, 38);
            this.lbUpdaterDescription.Name = "lbUpdaterDescription";
            this.lbUpdaterDescription.Size = new System.Drawing.Size(208, 38);
            this.lbUpdaterDescription.TabIndex = 2;
            this.lbUpdaterDescription.Text = "lbUpdaterDescription";
            this.lbUpdaterDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tmrForm
            // 
            this.tmrForm.Enabled = true;
            this.tmrForm.Interval = 1000;
            this.tmrForm.Tick += new System.EventHandler(this.tmrForm_Tick);
            // 
            // frmUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(232, 113);
            this.Controls.Add(this.lbUpdaterDescription);
            this.Controls.Add(this.lbUpdaterHeader);
            this.Controls.Add(this.pbDownloadProgress);
            this.Icon = Properties.Resources.youtube_dl_gui;
            this.MaximizeBox = false;
            this.Name = "frmUpdater";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUpdater";
            this.Shown += new System.EventHandler(this.frmUpdater_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbDownloadProgress;
        private System.Windows.Forms.Label lbUpdaterHeader;
        private System.Windows.Forms.Label lbUpdaterDescription;
        private System.Windows.Forms.Timer tmrForm;
    }
}

