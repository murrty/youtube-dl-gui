namespace youtube_dl_gui {
    partial class frmDownloader {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownloader));
            this.btnDownloaderCancelExit = new System.Windows.Forms.Button();
            this.chkDownloaderCloseAfterDownloader = new System.Windows.Forms.CheckBox();
            this.rtbConsoleOutput = new System.Windows.Forms.RichTextBox();
            this.tmrTitleActivity = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnDownloaderCancelExit
            // 
            this.btnDownloaderCancelExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloaderCancelExit.Location = new System.Drawing.Point(318, 254);
            this.btnDownloaderCancelExit.Name = "btnDownloaderCancelExit";
            this.btnDownloaderCancelExit.Size = new System.Drawing.Size(82, 24);
            this.btnDownloaderCancelExit.TabIndex = 1;
            this.btnDownloaderCancelExit.Text = "btnDownloaderCancelExit";
            this.btnDownloaderCancelExit.UseVisualStyleBackColor = true;
            this.btnDownloaderCancelExit.Click += new System.EventHandler(this.btnDownloaderCancelExit_Click);
            // 
            // chkDownloaderCloseAfterDownloader
            // 
            this.chkDownloaderCloseAfterDownloader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDownloaderCloseAfterDownloader.AutoSize = true;
            this.chkDownloaderCloseAfterDownloader.Checked = true;
            this.chkDownloaderCloseAfterDownloader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDownloaderCloseAfterDownloader.Location = new System.Drawing.Point(12, 259);
            this.chkDownloaderCloseAfterDownloader.Name = "chkDownloaderCloseAfterDownloader";
            this.chkDownloaderCloseAfterDownloader.Size = new System.Drawing.Size(205, 17);
            this.chkDownloaderCloseAfterDownloader.TabIndex = 2;
            this.chkDownloaderCloseAfterDownloader.Text = "chkDownloaderCloseAfterDownloader";
            this.chkDownloaderCloseAfterDownloader.UseVisualStyleBackColor = true;
            // 
            // rtbConsoleOutput
            // 
            this.rtbConsoleOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbConsoleOutput.Location = new System.Drawing.Point(12, 12);
            this.rtbConsoleOutput.Name = "rtbConsoleOutput";
            this.rtbConsoleOutput.ReadOnly = true;
            this.rtbConsoleOutput.Size = new System.Drawing.Size(388, 236);
            this.rtbConsoleOutput.TabIndex = 0;
            this.rtbConsoleOutput.Text = "";
            // 
            // tmrTitleActivity
            // 
            this.tmrTitleActivity.Interval = 1000;
            this.tmrTitleActivity.Tick += new System.EventHandler(this.tmrTitleActivity_Tick);
            // 
            // frmDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 290);
            this.Controls.Add(this.chkDownloaderCloseAfterDownloader);
            this.Controls.Add(this.btnDownloaderCancelExit);
            this.Controls.Add(this.rtbConsoleOutput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(420, 320);
            this.Name = "frmDownloader";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "frmDownloader";
            this.Shown += new System.EventHandler(this.frmDownloader_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDownloaderCancelExit;
        private System.Windows.Forms.CheckBox chkDownloaderCloseAfterDownloader;
        private System.Windows.Forms.RichTextBox rtbConsoleOutput;
        private System.Windows.Forms.Timer tmrTitleActivity;
    }
}