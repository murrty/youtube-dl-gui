namespace youtube_dl_gui {
    partial class frmException {
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
        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent() {
            this.lbExceptionHeader = new System.Windows.Forms.Label();
            this.lbExceptionDescription = new System.Windows.Forms.Label();
            this.rtbExceptionDetails = new System.Windows.Forms.RichTextBox();
            this.btnExceptionOk = new System.Windows.Forms.Button();
            this.lbVersion = new System.Windows.Forms.Label();
            this.btnExceptionGithub = new System.Windows.Forms.Button();
            this.lbDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbExceptionHeader
            // 
            this.lbExceptionHeader.AutoSize = true;
            this.lbExceptionHeader.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExceptionHeader.Location = new System.Drawing.Point(12, 3);
            this.lbExceptionHeader.Name = "lbExceptionHeader";
            this.lbExceptionHeader.Size = new System.Drawing.Size(171, 25);
            this.lbExceptionHeader.TabIndex = 0;
            this.lbExceptionHeader.Text = "lbExceptionHeader";
            // 
            // lbExceptionDescription
            // 
            this.lbExceptionDescription.AutoSize = true;
            this.lbExceptionDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExceptionDescription.Location = new System.Drawing.Point(13, 34);
            this.lbExceptionDescription.Name = "lbExceptionDescription";
            this.lbExceptionDescription.Size = new System.Drawing.Size(141, 17);
            this.lbExceptionDescription.TabIndex = 1;
            this.lbExceptionDescription.Text = "lbExceptionDescription";
            // 
            // rtbExceptionDetails
            // 
            this.rtbExceptionDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbExceptionDetails.Location = new System.Drawing.Point(12, 61);
            this.rtbExceptionDetails.Name = "rtbExceptionDetails";
            this.rtbExceptionDetails.ReadOnly = true;
            this.rtbExceptionDetails.Size = new System.Drawing.Size(448, 150);
            this.rtbExceptionDetails.TabIndex = 2;
            this.rtbExceptionDetails.Text = "rtbExceptionDetails";
            // 
            // btnExceptionOk
            // 
            this.btnExceptionOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExceptionOk.Location = new System.Drawing.Point(385, 217);
            this.btnExceptionOk.Name = "btnExceptionOk";
            this.btnExceptionOk.Size = new System.Drawing.Size(75, 24);
            this.btnExceptionOk.TabIndex = 5;
            this.btnExceptionOk.Text = "btnExceptionOk";
            this.btnExceptionOk.UseVisualStyleBackColor = true;
            this.btnExceptionOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lbVersion
            // 
            this.lbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(14, 223);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(50, 13);
            this.lbVersion.TabIndex = 3;
            this.lbVersion.Text = "lbVersion";
            // 
            // btnExceptionGithub
            // 
            this.btnExceptionGithub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExceptionGithub.Location = new System.Drawing.Point(294, 217);
            this.btnExceptionGithub.Name = "btnExceptionGithub";
            this.btnExceptionGithub.Size = new System.Drawing.Size(85, 24);
            this.btnExceptionGithub.TabIndex = 4;
            this.btnExceptionGithub.Text = "btnExceptionGithub";
            this.btnExceptionGithub.UseVisualStyleBackColor = true;
            this.btnExceptionGithub.Click += new System.EventHandler(this.btnGithub_Click);
            // 
            // lbDate
            // 
            this.lbDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDate.Location = new System.Drawing.Point(169, 217);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(113, 24);
            this.lbDate.TabIndex = 6;
            this.lbDate.Text = "99/99/99 99:99:98";
            this.lbDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmException
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 253);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.btnExceptionGithub);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.btnExceptionOk);
            this.Controls.Add(this.rtbExceptionDetails);
            this.Controls.Add(this.lbExceptionDescription);
            this.Controls.Add(this.lbExceptionHeader);
            this.Icon = global::youtube_dl_gui.Properties.Resources.youtube_dl_gui;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(490, 290);
            this.Name = "frmException";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmError";
            this.Load += new System.EventHandler(this.frmError_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbExceptionHeader;
        private System.Windows.Forms.Label lbExceptionDescription;
        private System.Windows.Forms.RichTextBox rtbExceptionDetails;
        private System.Windows.Forms.Button btnExceptionOk;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Button btnExceptionGithub;
        private System.Windows.Forms.Label lbDate;
    }
}