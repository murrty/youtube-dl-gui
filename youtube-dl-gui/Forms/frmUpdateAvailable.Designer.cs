namespace youtube_dl_gui {
    partial class frmUpdateAvailable {
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
            this.txtUpdateAvailableName = new System.Windows.Forms.TextBox();
            this.lbUpdateAvailableChangelog = new System.Windows.Forms.Label();
            this.rtbUpdateAvailableChangelog = new murrty.controls.ExtendedRichTextBox();
            this.lbUpdateAvailableCurrentVersion = new System.Windows.Forms.Label();
            this.lbUpdateAvailableUpdateVersion = new System.Windows.Forms.Label();
            this.lbUpdateAvailableHeader = new System.Windows.Forms.Label();
            this.pnLower = new System.Windows.Forms.Panel();
            this.btnUpdateAvailableOk = new System.Windows.Forms.Button();
            this.btnUpdateAvailableSkip = new System.Windows.Forms.Button();
            this.btnUpdateAvailableUpdate = new System.Windows.Forms.Button();
            this.lbUpdateSize = new System.Windows.Forms.Label();
            this.pnLower.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUpdateAvailableName
            // 
            this.txtUpdateAvailableName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpdateAvailableName.Location = new System.Drawing.Point(11, 107);
            this.txtUpdateAvailableName.Name = "txtUpdateAvailableName";
            this.txtUpdateAvailableName.ReadOnly = true;
            this.txtUpdateAvailableName.Size = new System.Drawing.Size(300, 22);
            this.txtUpdateAvailableName.TabIndex = 13;
            // 
            // lbUpdateAvailableChangelog
            // 
            this.lbUpdateAvailableChangelog.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdateAvailableChangelog.Location = new System.Drawing.Point(8, 83);
            this.lbUpdateAvailableChangelog.Name = "lbUpdateAvailableChangelog";
            this.lbUpdateAvailableChangelog.Size = new System.Drawing.Size(303, 21);
            this.lbUpdateAvailableChangelog.TabIndex = 12;
            this.lbUpdateAvailableChangelog.Text = "Changelog:";
            // 
            // rtbUpdateAvailableChangelog
            // 
            this.rtbUpdateAvailableChangelog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbUpdateAvailableChangelog.Location = new System.Drawing.Point(11, 133);
            this.rtbUpdateAvailableChangelog.Name = "rtbUpdateAvailableChangelog";
            this.rtbUpdateAvailableChangelog.ReadOnly = true;
            this.rtbUpdateAvailableChangelog.Size = new System.Drawing.Size(300, 140);
            this.rtbUpdateAvailableChangelog.TabIndex = 14;
            this.rtbUpdateAvailableChangelog.Text = "";
            // 
            // lbUpdateAvailableCurrentVersion
            // 
            this.lbUpdateAvailableCurrentVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdateAvailableCurrentVersion.Location = new System.Drawing.Point(36, 55);
            this.lbUpdateAvailableCurrentVersion.Name = "lbUpdateAvailableCurrentVersion";
            this.lbUpdateAvailableCurrentVersion.Size = new System.Drawing.Size(275, 21);
            this.lbUpdateAvailableCurrentVersion.TabIndex = 11;
            this.lbUpdateAvailableCurrentVersion.Text = "Current version: 0.0";
            // 
            // lbUpdateAvailableUpdateVersion
            // 
            this.lbUpdateAvailableUpdateVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdateAvailableUpdateVersion.Location = new System.Drawing.Point(35, 34);
            this.lbUpdateAvailableUpdateVersion.Name = "lbUpdateAvailableUpdateVersion";
            this.lbUpdateAvailableUpdateVersion.Size = new System.Drawing.Size(276, 21);
            this.lbUpdateAvailableUpdateVersion.TabIndex = 10;
            this.lbUpdateAvailableUpdateVersion.Text = "Update version: 0.0";
            // 
            // lbUpdateAvailableHeader
            // 
            this.lbUpdateAvailableHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdateAvailableHeader.Location = new System.Drawing.Point(11, 9);
            this.lbUpdateAvailableHeader.Name = "lbUpdateAvailableHeader";
            this.lbUpdateAvailableHeader.Size = new System.Drawing.Size(300, 23);
            this.lbUpdateAvailableHeader.TabIndex = 9;
            this.lbUpdateAvailableHeader.Text = "An update is available";
            // 
            // pnLower
            // 
            this.pnLower.BackColor = System.Drawing.SystemColors.Menu;
            this.pnLower.Controls.Add(this.btnUpdateAvailableOk);
            this.pnLower.Controls.Add(this.btnUpdateAvailableSkip);
            this.pnLower.Controls.Add(this.btnUpdateAvailableUpdate);
            this.pnLower.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnLower.Location = new System.Drawing.Point(0, 303);
            this.pnLower.Name = "pnLower";
            this.pnLower.Size = new System.Drawing.Size(324, 42);
            this.pnLower.TabIndex = 18;
            // 
            // btnUpdateAvailableOk
            // 
            this.btnUpdateAvailableOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateAvailableOk.Location = new System.Drawing.Point(237, 7);
            this.btnUpdateAvailableOk.Name = "btnUpdateAvailableOk";
            this.btnUpdateAvailableOk.Size = new System.Drawing.Size(75, 24);
            this.btnUpdateAvailableOk.TabIndex = 17;
            this.btnUpdateAvailableOk.Text = "OK";
            this.btnUpdateAvailableOk.UseVisualStyleBackColor = true;
            this.btnUpdateAvailableOk.Click += new System.EventHandler(this.btnUpdateAvailableOk_Click);
            // 
            // btnUpdateAvailableSkip
            // 
            this.btnUpdateAvailableSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdateAvailableSkip.Location = new System.Drawing.Point(12, 7);
            this.btnUpdateAvailableSkip.Name = "btnUpdateAvailableSkip";
            this.btnUpdateAvailableSkip.Size = new System.Drawing.Size(80, 24);
            this.btnUpdateAvailableSkip.TabIndex = 15;
            this.btnUpdateAvailableSkip.Text = "Skip version";
            this.btnUpdateAvailableSkip.UseVisualStyleBackColor = true;
            this.btnUpdateAvailableSkip.Click += new System.EventHandler(this.btnUpdateAvailableSkip_Click);
            // 
            // btnUpdateAvailableUpdate
            // 
            this.btnUpdateAvailableUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdateAvailableUpdate.Location = new System.Drawing.Point(154, 7);
            this.btnUpdateAvailableUpdate.Name = "btnUpdateAvailableUpdate";
            this.btnUpdateAvailableUpdate.Size = new System.Drawing.Size(75, 24);
            this.btnUpdateAvailableUpdate.TabIndex = 16;
            this.btnUpdateAvailableUpdate.Text = "Update";
            this.btnUpdateAvailableUpdate.UseVisualStyleBackColor = true;
            this.btnUpdateAvailableUpdate.Click += new System.EventHandler(this.btnUpdateAvailableUpdate_Click);
            // 
            // lbUpdateSize
            // 
            this.lbUpdateSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbUpdateSize.AutoSize = true;
            this.lbUpdateSize.Location = new System.Drawing.Point(12, 280);
            this.lbUpdateSize.Name = "lbUpdateSize";
            this.lbUpdateSize.Size = new System.Drawing.Size(157, 13);
            this.lbUpdateSize.TabIndex = 19;
            this.lbUpdateSize.Text = "The new executable size is 0B";
            // 
            // frmUpdateAvailable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(324, 345);
            this.Controls.Add(this.lbUpdateSize);
            this.Controls.Add(this.txtUpdateAvailableName);
            this.Controls.Add(this.lbUpdateAvailableChangelog);
            this.Controls.Add(this.rtbUpdateAvailableChangelog);
            this.Controls.Add(this.lbUpdateAvailableCurrentVersion);
            this.Controls.Add(this.lbUpdateAvailableUpdateVersion);
            this.Controls.Add(this.lbUpdateAvailableHeader);
            this.Controls.Add(this.pnLower);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = global::youtube_dl_gui.Properties.Resources.ProgramIcon;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(340, 380);
            this.Name = "frmUpdateAvailable";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update available";
            this.Load += new System.EventHandler(this.frmUpdateAvailable_Load);
            this.pnLower.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUpdateAvailableName;
        private System.Windows.Forms.Button btnUpdateAvailableSkip;
        private System.Windows.Forms.Button btnUpdateAvailableOk;
        private System.Windows.Forms.Button btnUpdateAvailableUpdate;
        private System.Windows.Forms.Label lbUpdateAvailableChangelog;
        private murrty.controls.ExtendedRichTextBox rtbUpdateAvailableChangelog;
        private System.Windows.Forms.Label lbUpdateAvailableCurrentVersion;
        private System.Windows.Forms.Label lbUpdateAvailableUpdateVersion;
        private System.Windows.Forms.Label lbUpdateAvailableHeader;
        private System.Windows.Forms.Panel pnLower;
        private System.Windows.Forms.Label lbUpdateSize;
    }
}