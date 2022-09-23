namespace youtube_dl_gui {
    partial class frmConverter {
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
            this.chkConverterCloseAfterConversion = new System.Windows.Forms.CheckBox();
            this.btnConverterCancelExit = new System.Windows.Forms.Button();
            this.rtbConsoleOutput = new murrty.controls.ExtendedRichTextBox();
            this.tmrTitleActivity = new System.Windows.Forms.Timer(this.components);
            this.txtArgumentsGenerated = new System.Windows.Forms.TextBox();
            this.btnConverterAbortBatchConversions = new System.Windows.Forms.Button();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkConverterCloseAfterConversion
            // 
            this.chkConverterCloseAfterConversion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkConverterCloseAfterConversion.AutoSize = true;
            this.chkConverterCloseAfterConversion.Checked = true;
            this.chkConverterCloseAfterConversion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConverterCloseAfterConversion.Location = new System.Drawing.Point(12, 259);
            this.chkConverterCloseAfterConversion.Name = "chkConverterCloseAfterConversion";
            this.chkConverterCloseAfterConversion.Size = new System.Drawing.Size(190, 17);
            this.chkConverterCloseAfterConversion.TabIndex = 3;
            this.chkConverterCloseAfterConversion.Text = "chkConverterCloseAfterConversion";
            this.chkConverterCloseAfterConversion.UseVisualStyleBackColor = true;
            // 
            // btnConverterCancelExit
            // 
            this.btnConverterCancelExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConverterCancelExit.Location = new System.Drawing.Point(318, 254);
            this.btnConverterCancelExit.Name = "btnConverterCancelExit";
            this.btnConverterCancelExit.Size = new System.Drawing.Size(82, 24);
            this.btnConverterCancelExit.TabIndex = 4;
            this.btnConverterCancelExit.Text = "btnConverterCancelExit";
            this.btnConverterCancelExit.UseVisualStyleBackColor = true;
            this.btnConverterCancelExit.Click += new System.EventHandler(this.btnConverterCancelExit_Click);
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
            // btnConverterAbortBatchConversions
            // 
            this.btnConverterAbortBatchConversions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConverterAbortBatchConversions.Location = new System.Drawing.Point(189, 255);
            this.btnConverterAbortBatchConversions.Name = "btnConverterAbortBatchConversions";
            this.btnConverterAbortBatchConversions.Size = new System.Drawing.Size(123, 23);
            this.btnConverterAbortBatchConversions.TabIndex = 5;
            this.btnConverterAbortBatchConversions.Text = "btnConverterAbortBatchConversions";
            this.btnConverterAbortBatchConversions.UseVisualStyleBackColor = true;
            this.btnConverterAbortBatchConversions.Visible = false;
            this.btnConverterAbortBatchConversions.Click += new System.EventHandler(this.btnConverterAbortBatchConversions_Click);
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.Location = new System.Drawing.Point(318, 227);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(82, 23);
            this.btnClearOutput.TabIndex = 6;
            this.btnClearOutput.Text = "Clear Output";
            this.btnClearOutput.UseVisualStyleBackColor = true;
            this.btnClearOutput.Visible = false;
            this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
            // 
            // frmConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 290);
            this.Controls.Add(this.btnClearOutput);
            this.Controls.Add(this.btnConverterAbortBatchConversions);
            this.Controls.Add(this.chkConverterCloseAfterConversion);
            this.Controls.Add(this.btnConverterCancelExit);
            this.Controls.Add(this.rtbConsoleOutput);
            this.Controls.Add(this.txtArgumentsGenerated);
            this.Icon = global::youtube_dl_gui.Properties.Resources.ProgramIcon;
            this.MinimumSize = new System.Drawing.Size(420, 320);
            this.Name = "frmConverter";
            this.Text = "frmConverter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConverter_FormClosing);
            this.Load += new System.EventHandler(this.frmConverter_Load);
            this.Shown += new System.EventHandler(this.frmConverter_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkConverterCloseAfterConversion;
        private System.Windows.Forms.Button btnConverterCancelExit;
        private murrty.controls.ExtendedRichTextBox rtbConsoleOutput;
        private System.Windows.Forms.Timer tmrTitleActivity;
        private System.Windows.Forms.TextBox txtArgumentsGenerated;
        private System.Windows.Forms.Button btnConverterAbortBatchConversions;
        private System.Windows.Forms.Button btnClearOutput;
    }
}