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
            this.btnDownloaderCancelExit = new System.Windows.Forms.Button();
            this.chkDownloaderCloseAfterDownload = new System.Windows.Forms.CheckBox();
            this.rtbConsoleOutput = new Controls.ExtendedRichTextBox();
            this.tmrTitleActivity = new System.Windows.Forms.Timer(this.components);
            this.txtArgumentsGenerated = new System.Windows.Forms.TextBox();
            this.btnDownloaderAbortBatchDownload = new System.Windows.Forms.Button();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDownloaderCancelExit
            // 
            this.btnDownloaderCancelExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloaderCancelExit.Location = new System.Drawing.Point(318, 254);
            this.btnDownloaderCancelExit.Name = "btnDownloaderCancelExit";
            this.btnDownloaderCancelExit.Size = new System.Drawing.Size(82, 24);
            this.btnDownloaderCancelExit.TabIndex = 3;
            this.btnDownloaderCancelExit.Text = "btnDownloaderCancelExit";
            this.btnDownloaderCancelExit.UseVisualStyleBackColor = true;
            this.btnDownloaderCancelExit.Click += new System.EventHandler(this.btnDownloaderCancelExit_Click);
            // 
            // chkDownloaderCloseAfterDownload
            // 
            this.chkDownloaderCloseAfterDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDownloaderCloseAfterDownload.AutoSize = true;
            this.chkDownloaderCloseAfterDownload.Checked = true;
            this.chkDownloaderCloseAfterDownload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDownloaderCloseAfterDownload.Location = new System.Drawing.Point(12, 259);
            this.chkDownloaderCloseAfterDownload.Name = "chkDownloaderCloseAfterDownload";
            this.chkDownloaderCloseAfterDownload.Size = new System.Drawing.Size(196, 17);
            this.chkDownloaderCloseAfterDownload.TabIndex = 2;
            this.chkDownloaderCloseAfterDownload.Text = "chkDownloaderCloseAfterDownload";
            this.chkDownloaderCloseAfterDownload.UseVisualStyleBackColor = true;
            // 
            // rtbConsoleOutput
            // 
            this.rtbConsoleOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbConsoleOutput.Location = new System.Drawing.Point(12, 12);
            this.rtbConsoleOutput.Name = "rtbConsoleOutput";
            this.rtbConsoleOutput.ReadOnly = true;
            this.rtbConsoleOutput.Size = new System.Drawing.Size(388, 211);
            this.rtbConsoleOutput.TabIndex = 0;
            this.rtbConsoleOutput.Text = "";
            // 
            // tmrTitleActivity
            // 
            this.tmrTitleActivity.Enabled = true;
            this.tmrTitleActivity.Interval = 1000;
            this.tmrTitleActivity.Tick += new System.EventHandler(this.tmrTitleActivity_Tick);
            // 
            // txtArgumentsGenerated
            // 
            this.txtArgumentsGenerated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArgumentsGenerated.Location = new System.Drawing.Point(12, 229);
            this.txtArgumentsGenerated.Name = "txtArgumentsGenerated";
            this.txtArgumentsGenerated.ReadOnly = true;
            this.txtArgumentsGenerated.Size = new System.Drawing.Size(388, 20);
            this.txtArgumentsGenerated.TabIndex = 1;
            // 
            // btnDownloaderAbortBatchDownload
            // 
            this.btnDownloaderAbortBatchDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloaderAbortBatchDownload.Location = new System.Drawing.Point(189, 255);
            this.btnDownloaderAbortBatchDownload.Name = "btnDownloaderAbortBatchDownload";
            this.btnDownloaderAbortBatchDownload.Size = new System.Drawing.Size(123, 23);
            this.btnDownloaderAbortBatchDownload.TabIndex = 4;
            this.btnDownloaderAbortBatchDownload.Text = "btnDownloaderAbortBatchDownload";
            this.btnDownloaderAbortBatchDownload.UseVisualStyleBackColor = true;
            this.btnDownloaderAbortBatchDownload.Visible = false;
            this.btnDownloaderAbortBatchDownload.Click += new System.EventHandler(this.btnDownloaderAbortBatchDownload_Click);
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.Location = new System.Drawing.Point(318, 227);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(82, 23);
            this.btnClearOutput.TabIndex = 5;
            this.btnClearOutput.Text = "Clear Output";
            this.btnClearOutput.UseVisualStyleBackColor = true;
            this.btnClearOutput.Visible = false;
            this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
            // 
            // frmDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 290);
            this.Controls.Add(this.btnClearOutput);
            this.Controls.Add(this.btnDownloaderAbortBatchDownload);
            this.Controls.Add(this.txtArgumentsGenerated);
            this.Controls.Add(this.chkDownloaderCloseAfterDownload);
            this.Controls.Add(this.btnDownloaderCancelExit);
            this.Controls.Add(this.rtbConsoleOutput);
            this.Icon = global::youtube_dl_gui.Properties.Resources.youtube_dl_gui;
            this.MinimumSize = new System.Drawing.Size(420, 320);
            this.Name = "frmDownloader";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "frmDownloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDownloader_FormClosing);
            this.Load += new System.EventHandler(this.frmDownloader_Load);
            this.Shown += new System.EventHandler(this.frmDownloader_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDownloaderCancelExit;
        private System.Windows.Forms.CheckBox chkDownloaderCloseAfterDownload;
        private Controls.ExtendedRichTextBox rtbConsoleOutput;
        private System.Windows.Forms.Timer tmrTitleActivity;
        private System.Windows.Forms.TextBox txtArgumentsGenerated;
        private System.Windows.Forms.Button btnDownloaderAbortBatchDownload;
        private System.Windows.Forms.Button btnClearOutput;
    }
}