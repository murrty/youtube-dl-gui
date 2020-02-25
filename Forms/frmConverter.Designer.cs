namespace youtube_dl_gui.Forms {
    partial class frmConverter {
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
            this.chkConverterCloseAfterDownloader = new System.Windows.Forms.CheckBox();
            this.btnConverterCancelExit = new System.Windows.Forms.Button();
            this.rtbConsoleOutput = new System.Windows.Forms.RichTextBox();
            this.tmrTitleActivity = new System.Windows.Forms.Timer(this.components);
            this.txtArgumentsGenerated = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chkConverterCloseAfterDownloader
            // 
            this.chkConverterCloseAfterDownloader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkConverterCloseAfterDownloader.AutoSize = true;
            this.chkConverterCloseAfterDownloader.Checked = true;
            this.chkConverterCloseAfterDownloader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConverterCloseAfterDownloader.Location = new System.Drawing.Point(12, 259);
            this.chkConverterCloseAfterDownloader.Name = "chkConverterCloseAfterDownloader";
            this.chkConverterCloseAfterDownloader.Size = new System.Drawing.Size(205, 17);
            this.chkConverterCloseAfterDownloader.TabIndex = 3;
            this.chkConverterCloseAfterDownloader.Text = "chkDownloaderCloseAfterDownloader";
            this.chkConverterCloseAfterDownloader.UseVisualStyleBackColor = true;
            // 
            // btnConverterCancelExit
            // 
            this.btnConverterCancelExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConverterCancelExit.Location = new System.Drawing.Point(318, 254);
            this.btnConverterCancelExit.Name = "btnConverterCancelExit";
            this.btnConverterCancelExit.Size = new System.Drawing.Size(82, 24);
            this.btnConverterCancelExit.TabIndex = 4;
            this.btnConverterCancelExit.Text = "btnDownloaderCancelExit";
            this.btnConverterCancelExit.UseVisualStyleBackColor = true;
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
            this.rtbConsoleOutput.TabIndex = 1;
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
            this.txtArgumentsGenerated.TabIndex = 2;
            // 
            // frmConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 290);
            this.Controls.Add(this.chkConverterCloseAfterDownloader);
            this.Controls.Add(this.btnConverterCancelExit);
            this.Controls.Add(this.rtbConsoleOutput);
            this.Controls.Add(this.txtArgumentsGenerated);
            this.MinimumSize = new System.Drawing.Size(420, 320);
            this.Name = "frmConverter";
            this.Text = "frmConverter";
            this.Load += new System.EventHandler(this.frmConverter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkConverterCloseAfterDownloader;
        private System.Windows.Forms.Button btnConverterCancelExit;
        private System.Windows.Forms.RichTextBox rtbConsoleOutput;
        private System.Windows.Forms.Timer tmrTitleActivity;
        private System.Windows.Forms.TextBox txtArgumentsGenerated;
    }
}