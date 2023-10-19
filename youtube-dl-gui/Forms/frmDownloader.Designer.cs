namespace youtube_dl_gui {
    partial class frmDownloader {
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
            this.tmrTitleActivity = new System.Windows.Forms.Timer(this.components);
            this.chkDownloaderCloseAfterDownload = new System.Windows.Forms.CheckBox();
            this.txtGeneratedArguments = new System.Windows.Forms.TextBox();
            this.btnDownloaderCancelExit = new System.Windows.Forms.Button();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.btnDownloaderRetryAbortBatch = new System.Windows.Forms.Button();
            this.pnStatuses = new System.Windows.Forms.Panel();
            this.pbStatus = new murrty.controls.ExtendedProgressBar();
            this.pnLowerControls = new System.Windows.Forms.Panel();
            this.rtbVerbose = new murrty.controls.ExtendedRichTextBox();
            this.pnStatuses.SuspendLayout();
            this.pnLowerControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrTitleActivity
            // 
            this.tmrTitleActivity.Interval = 1000;
            this.tmrTitleActivity.Tick += new System.EventHandler(this.tmrTitleActivity_Tick);
            // 
            // chkDownloaderCloseAfterDownload
            // 
            this.chkDownloaderCloseAfterDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDownloaderCloseAfterDownload.AutoSize = true;
            this.chkDownloaderCloseAfterDownload.Location = new System.Drawing.Point(12, 11);
            this.chkDownloaderCloseAfterDownload.Name = "chkDownloaderCloseAfterDownload";
            this.chkDownloaderCloseAfterDownload.Size = new System.Drawing.Size(214, 17);
            this.chkDownloaderCloseAfterDownload.TabIndex = 5;
            this.chkDownloaderCloseAfterDownload.Text = "chkDownloaderCloseAfterDownload";
            this.chkDownloaderCloseAfterDownload.UseVisualStyleBackColor = true;
            // 
            // txtGeneratedArguments
            // 
            this.txtGeneratedArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGeneratedArguments.Location = new System.Drawing.Point(12, 3);
            this.txtGeneratedArguments.Name = "txtGeneratedArguments";
            this.txtGeneratedArguments.ReadOnly = true;
            this.txtGeneratedArguments.Size = new System.Drawing.Size(279, 22);
            this.txtGeneratedArguments.TabIndex = 3;
            // 
            // btnDownloaderCancelExit
            // 
            this.btnDownloaderCancelExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloaderCancelExit.Location = new System.Drawing.Point(297, 7);
            this.btnDownloaderCancelExit.Name = "btnDownloaderCancelExit";
            this.btnDownloaderCancelExit.Size = new System.Drawing.Size(75, 23);
            this.btnDownloaderCancelExit.TabIndex = 2;
            this.btnDownloaderCancelExit.Text = "btnDownloaderCancelExit";
            this.btnDownloaderCancelExit.UseVisualStyleBackColor = true;
            this.btnDownloaderCancelExit.Click += new System.EventHandler(this.btnDownloaderCancelExit_Click);
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearOutput.Location = new System.Drawing.Point(297, 2);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(75, 23);
            this.btnClearOutput.TabIndex = 7;
            this.btnClearOutput.Text = "btnClearOutput";
            this.btnClearOutput.UseVisualStyleBackColor = true;
            this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
            // 
            // btnDownloaderRetryAbortBatch
            // 
            this.btnDownloaderRetryAbortBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloaderRetryAbortBatch.Location = new System.Drawing.Point(168, 7);
            this.btnDownloaderRetryAbortBatch.Name = "btnDownloaderRetryAbortBatch";
            this.btnDownloaderRetryAbortBatch.Size = new System.Drawing.Size(123, 23);
            this.btnDownloaderRetryAbortBatch.TabIndex = 6;
            this.btnDownloaderRetryAbortBatch.Text = "btnDownloaderAbortBatchDownload";
            this.btnDownloaderRetryAbortBatch.UseVisualStyleBackColor = true;
            this.btnDownloaderRetryAbortBatch.Visible = false;
            this.btnDownloaderRetryAbortBatch.Click += new System.EventHandler(this.btnDownloaderRetryAbortBatch_Click);
            // 
            // pnStatuses
            // 
            this.pnStatuses.Controls.Add(this.pbStatus);
            this.pnStatuses.Controls.Add(this.btnClearOutput);
            this.pnStatuses.Controls.Add(this.txtGeneratedArguments);
            this.pnStatuses.Controls.Add(this.pnLowerControls);
            this.pnStatuses.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnStatuses.Location = new System.Drawing.Point(0, 213);
            this.pnStatuses.Name = "pnStatuses";
            this.pnStatuses.Size = new System.Drawing.Size(384, 102);
            this.pnStatuses.TabIndex = 9;
            // 
            // pbStatus
            // 
            this.pbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbStatus.ContainerParent = this;
            this.pbStatus.FastValueUpdate = true;
            this.pbStatus.Location = new System.Drawing.Point(12, 31);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.ShowText = true;
            this.pbStatus.Size = new System.Drawing.Size(360, 20);
            this.pbStatus.TabIndex = 1;
            this.pbStatus.Text = ".  .  .";
            // 
            // pnLowerControls
            // 
            this.pnLowerControls.BackColor = System.Drawing.SystemColors.Menu;
            this.pnLowerControls.Controls.Add(this.btnDownloaderRetryAbortBatch);
            this.pnLowerControls.Controls.Add(this.btnDownloaderCancelExit);
            this.pnLowerControls.Controls.Add(this.chkDownloaderCloseAfterDownload);
            this.pnLowerControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnLowerControls.Location = new System.Drawing.Point(0, 60);
            this.pnLowerControls.Name = "pnLowerControls";
            this.pnLowerControls.Size = new System.Drawing.Size(384, 42);
            this.pnLowerControls.TabIndex = 8;
            // 
            // rtbVerbose
            // 
            this.rtbVerbose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbVerbose.Location = new System.Drawing.Point(12, 12);
            this.rtbVerbose.Name = "rtbVerbose";
            this.rtbVerbose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbVerbose.Size = new System.Drawing.Size(360, 198);
            this.rtbVerbose.TabIndex = 0;
            this.rtbVerbose.Text = "";
            // 
            // frmDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(384, 315);
            this.Controls.Add(this.rtbVerbose);
            this.Controls.Add(this.pnStatuses);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = global::youtube_dl_gui.Properties.Resources.ProgramIcon;
            this.MinimumSize = new System.Drawing.Size(400, 340);
            this.Name = "frmDownloader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDownloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExtendedMassDownloader_FormClosing);
            this.Load += new System.EventHandler(this.frmExtendedMassDownloader_Load);
            this.Shown += new System.EventHandler(this.frmExtendedMassDownloader_Shown);
            this.pnStatuses.ResumeLayout(false);
            this.pnStatuses.PerformLayout();
            this.pnLowerControls.ResumeLayout(false);
            this.pnLowerControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private murrty.controls.ExtendedRichTextBox rtbVerbose;
        private System.Windows.Forms.Timer tmrTitleActivity;
        private System.Windows.Forms.CheckBox chkDownloaderCloseAfterDownload;
        private System.Windows.Forms.TextBox txtGeneratedArguments;
        private System.Windows.Forms.Button btnDownloaderCancelExit;
        private System.Windows.Forms.Button btnClearOutput;
        private murrty.controls.ExtendedProgressBar pbStatus;
        private System.Windows.Forms.Panel pnStatuses;
        private System.Windows.Forms.Button btnDownloaderRetryAbortBatch;
        private System.Windows.Forms.Panel pnLowerControls;
    }
}