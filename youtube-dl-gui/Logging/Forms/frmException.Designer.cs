namespace murrty.forms {
    partial class frmException {

        /// <summary>
        /// Contains the forms' controls.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes the form.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Generates the forms' controls and configurations of them.
        /// <para>This should only be ran in the initializer once.</para>
        /// </summary>
        private void InitializeComponent() {
            this.btnExceptionOk = new System.Windows.Forms.Button();
            this.lbVersion = new System.Windows.Forms.Label();
            this.btnExceptionGithub = new System.Windows.Forms.Button();
            this.btnExceptionRetry = new System.Windows.Forms.Button();
            this.lbDate = new System.Windows.Forms.Label();
            this.pnLower = new System.Windows.Forms.Panel();
            this.pnDWM = new System.Windows.Forms.Panel();
            this.lbExceptionHeader = new System.Windows.Forms.Label();
            this.rtbExceptionDetails = new murrty.controls.ExtendedRichTextBox();
            this.lbExceptionDescription = new System.Windows.Forms.Label();
            this.tcExceptionDetails = new System.Windows.Forms.TabControl();
            this.tabExceptionDetails = new System.Windows.Forms.TabPage();
            this.tabExceptionExtraInfo = new System.Windows.Forms.TabPage();
            this.rtbExtraData = new murrty.controls.ExtendedRichTextBox();
            this.pnExceptionDescription = new System.Windows.Forms.Panel();
            this.pnLower.SuspendLayout();
            this.pnDWM.SuspendLayout();
            this.tcExceptionDetails.SuspendLayout();
            this.tabExceptionDetails.SuspendLayout();
            this.tabExceptionExtraInfo.SuspendLayout();
            this.pnExceptionDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExceptionOk
            // 
            this.btnExceptionOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExceptionOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExceptionOk.Location = new System.Drawing.Point(387, 7);
            this.btnExceptionOk.Name = "btnExceptionOk";
            this.btnExceptionOk.Size = new System.Drawing.Size(75, 23);
            this.btnExceptionOk.TabIndex = 3;
            this.btnExceptionOk.Text = "GenericOk";
            this.btnExceptionOk.UseVisualStyleBackColor = true;
            // 
            // lbVersion
            // 
            this.lbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(12, 13);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(55, 13);
            this.lbVersion.TabIndex = 4;
            this.lbVersion.Text = "lbVersion";
            // 
            // btnExceptionGithub
            // 
            this.btnExceptionGithub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExceptionGithub.Location = new System.Drawing.Point(225, 7);
            this.btnExceptionGithub.Name = "btnExceptionGithub";
            this.btnExceptionGithub.Size = new System.Drawing.Size(75, 23);
            this.btnExceptionGithub.TabIndex = 5;
            this.btnExceptionGithub.Text = "btnExceptionGithub";
            this.btnExceptionGithub.UseVisualStyleBackColor = true;
            this.btnExceptionGithub.Visible = false;
            this.btnExceptionGithub.Click += new System.EventHandler(this.btnExceptionGithub_Click);
            // 
            // btnExceptionRetry
            // 
            this.btnExceptionRetry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExceptionRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnExceptionRetry.Location = new System.Drawing.Point(306, 7);
            this.btnExceptionRetry.Name = "btnExceptionRetry";
            this.btnExceptionRetry.Size = new System.Drawing.Size(75, 23);
            this.btnExceptionRetry.TabIndex = 14;
            this.btnExceptionRetry.Text = "GenericRetry";
            this.btnExceptionRetry.UseVisualStyleBackColor = true;
            this.btnExceptionRetry.Visible = false;
            // 
            // lbDate
            // 
            this.lbDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDate.Location = new System.Drawing.Point(106, 7);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(113, 24);
            this.lbDate.TabIndex = 15;
            this.lbDate.Text = "99/99/99 99:99:98";
            this.lbDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnLower
            // 
            this.pnLower.BackColor = System.Drawing.SystemColors.Menu;
            this.pnLower.Controls.Add(this.btnExceptionOk);
            this.pnLower.Controls.Add(this.lbVersion);
            this.pnLower.Controls.Add(this.lbDate);
            this.pnLower.Controls.Add(this.btnExceptionGithub);
            this.pnLower.Controls.Add(this.btnExceptionRetry);
            this.pnLower.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnLower.Location = new System.Drawing.Point(0, 243);
            this.pnLower.Name = "pnLower";
            this.pnLower.Size = new System.Drawing.Size(474, 42);
            this.pnLower.TabIndex = 16;
            // 
            // pnDWM
            // 
            this.pnDWM.Controls.Add(this.lbExceptionHeader);
            this.pnDWM.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnDWM.Location = new System.Drawing.Point(0, 0);
            this.pnDWM.Name = "pnDWM";
            this.pnDWM.Size = new System.Drawing.Size(474, 37);
            this.pnDWM.TabIndex = 0;
            this.pnDWM.Visible = false;
            // 
            // lbExceptionHeader
            // 
            this.lbExceptionHeader.AutoSize = true;
            this.lbExceptionHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbExceptionHeader.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbExceptionHeader.Location = new System.Drawing.Point(7, 0);
            this.lbExceptionHeader.Name = "lbExceptionHeader";
            this.lbExceptionHeader.Size = new System.Drawing.Size(174, 25);
            this.lbExceptionHeader.TabIndex = 17;
            this.lbExceptionHeader.Text = "lbExceptionHeader";
            this.lbExceptionHeader.Visible = false;
            // 
            // rtbExceptionDetails
            // 
            this.rtbExceptionDetails.DetectUrls = false;
            this.rtbExceptionDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbExceptionDetails.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbExceptionDetails.Location = new System.Drawing.Point(3, 3);
            this.rtbExceptionDetails.Name = "rtbExceptionDetails";
            this.rtbExceptionDetails.ReadOnly = true;
            this.rtbExceptionDetails.Size = new System.Drawing.Size(460, 149);
            this.rtbExceptionDetails.TabIndex = 19;
            this.rtbExceptionDetails.Text = "rtbExceptionDetails";
            // 
            // lbExceptionDescription
            // 
            this.lbExceptionDescription.AutoSize = true;
            this.lbExceptionDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExceptionDescription.Location = new System.Drawing.Point(14, 3);
            this.lbExceptionDescription.Name = "lbExceptionDescription";
            this.lbExceptionDescription.Size = new System.Drawing.Size(141, 17);
            this.lbExceptionDescription.TabIndex = 1;
            this.lbExceptionDescription.Text = "lbExceptionDescription";
            // 
            // tcExceptionDetails
            // 
            this.tcExceptionDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcExceptionDetails.Controls.Add(this.tabExceptionDetails);
            this.tcExceptionDetails.Controls.Add(this.tabExceptionExtraInfo);
            this.tcExceptionDetails.Location = new System.Drawing.Point(0, 62);
            this.tcExceptionDetails.Name = "tcExceptionDetails";
            this.tcExceptionDetails.SelectedIndex = 0;
            this.tcExceptionDetails.Size = new System.Drawing.Size(474, 181);
            this.tcExceptionDetails.TabIndex = 20;
            // 
            // tabExceptionDetails
            // 
            this.tabExceptionDetails.Controls.Add(this.rtbExceptionDetails);
            this.tabExceptionDetails.Location = new System.Drawing.Point(4, 22);
            this.tabExceptionDetails.Name = "tabExceptionDetails";
            this.tabExceptionDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabExceptionDetails.Size = new System.Drawing.Size(466, 155);
            this.tabExceptionDetails.TabIndex = 0;
            this.tabExceptionDetails.Text = "tabExceptionDetails";
            this.tabExceptionDetails.UseVisualStyleBackColor = true;
            // 
            // tabExceptionExtraInfo
            // 
            this.tabExceptionExtraInfo.Controls.Add(this.rtbExtraData);
            this.tabExceptionExtraInfo.Location = new System.Drawing.Point(4, 22);
            this.tabExceptionExtraInfo.Name = "tabExceptionExtraInfo";
            this.tabExceptionExtraInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabExceptionExtraInfo.Size = new System.Drawing.Size(466, 155);
            this.tabExceptionExtraInfo.TabIndex = 1;
            this.tabExceptionExtraInfo.Text = "tabExceptionExtraInfo";
            this.tabExceptionExtraInfo.UseVisualStyleBackColor = true;
            // 
            // rtbExtraData
            // 
            this.rtbExtraData.DetectUrls = false;
            this.rtbExtraData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbExtraData.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbExtraData.Location = new System.Drawing.Point(3, 3);
            this.rtbExtraData.Name = "rtbExtraData";
            this.rtbExtraData.ReadOnly = true;
            this.rtbExtraData.Size = new System.Drawing.Size(460, 149);
            this.rtbExtraData.TabIndex = 20;
            this.rtbExtraData.Text = "rtbExtraData";
            // 
            // pnExceptionDescription
            // 
            this.pnExceptionDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnExceptionDescription.Controls.Add(this.lbExceptionDescription);
            this.pnExceptionDescription.Location = new System.Drawing.Point(0, 37);
            this.pnExceptionDescription.Name = "pnExceptionDescription";
            this.pnExceptionDescription.Size = new System.Drawing.Size(474, 26);
            this.pnExceptionDescription.TabIndex = 21;
            // 
            // frmException
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(474, 285);
            this.Controls.Add(this.tcExceptionDetails);
            this.Controls.Add(this.pnLower);
            this.Controls.Add(this.pnExceptionDescription);
            this.Controls.Add(this.pnDWM);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(490, 320);
            this.Name = "frmException";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmException";
            this.Load += new System.EventHandler(this.frmError_Load);
            this.pnLower.ResumeLayout(false);
            this.pnLower.PerformLayout();
            this.pnDWM.ResumeLayout(false);
            this.pnDWM.PerformLayout();
            this.tcExceptionDetails.ResumeLayout(false);
            this.tabExceptionDetails.ResumeLayout(false);
            this.tabExceptionExtraInfo.ResumeLayout(false);
            this.pnExceptionDescription.ResumeLayout(false);
            this.pnExceptionDescription.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExceptionOk;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Button btnExceptionGithub;
        private System.Windows.Forms.Button btnExceptionRetry;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Panel pnLower;
        private System.Windows.Forms.Panel pnDWM;
        private System.Windows.Forms.Label lbExceptionHeader;
        private murrty.controls.ExtendedRichTextBox rtbExceptionDetails;
        private System.Windows.Forms.Label lbExceptionDescription;
        private System.Windows.Forms.TabControl tcExceptionDetails;
        private System.Windows.Forms.TabPage tabExceptionDetails;
        private System.Windows.Forms.TabPage tabExceptionExtraInfo;
        private murrty.controls.ExtendedRichTextBox rtbExtraData;
        private System.Windows.Forms.Panel pnExceptionDescription;
    }
}