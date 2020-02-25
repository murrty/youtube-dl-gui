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
        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent() {
            this.lbUpdateAvailableHeader = new System.Windows.Forms.Label();
            this.lbUpdateAvailableUpdateVersion = new System.Windows.Forms.Label();
            this.lbUpdateAvailableCurrentVersion = new System.Windows.Forms.Label();
            this.rtbUpdateAvailableChangelog = new System.Windows.Forms.RichTextBox();
            this.lbUpdateAvailableChangelog = new System.Windows.Forms.Label();
            this.btnUpdateAvailableUpdate = new System.Windows.Forms.Button();
            this.btnUpdateAvailableOk = new System.Windows.Forms.Button();
            this.btnUpdateAvailableSkip = new System.Windows.Forms.Button();
            this.txtUpdateAvailableName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbUpdateAvailableHeader
            // 
            this.lbUpdateAvailableHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdateAvailableHeader.Location = new System.Drawing.Point(8, 9);
            this.lbUpdateAvailableHeader.Name = "lbUpdateAvailableHeader";
            this.lbUpdateAvailableHeader.Size = new System.Drawing.Size(302, 23);
            this.lbUpdateAvailableHeader.TabIndex = 0;
            this.lbUpdateAvailableHeader.Text = "An update is available";
            // 
            // lbUpdateAvailableUpdateVersion
            // 
            this.lbUpdateAvailableUpdateVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdateAvailableUpdateVersion.Location = new System.Drawing.Point(35, 34);
            this.lbUpdateAvailableUpdateVersion.Name = "lbUpdateAvailableUpdateVersion";
            this.lbUpdateAvailableUpdateVersion.Size = new System.Drawing.Size(275, 21);
            this.lbUpdateAvailableUpdateVersion.TabIndex = 1;
            this.lbUpdateAvailableUpdateVersion.Text = "Update version: 0.0";
            // 
            // lbUpdateAvailableCurrentVersion
            // 
            this.lbUpdateAvailableCurrentVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdateAvailableCurrentVersion.Location = new System.Drawing.Point(36, 55);
            this.lbUpdateAvailableCurrentVersion.Name = "lbUpdateAvailableCurrentVersion";
            this.lbUpdateAvailableCurrentVersion.Size = new System.Drawing.Size(274, 21);
            this.lbUpdateAvailableCurrentVersion.TabIndex = 2;
            this.lbUpdateAvailableCurrentVersion.Text = "Current version: 0.0";
            // 
            // rtbUpdateAvailableChangelog
            // 
            this.rtbUpdateAvailableChangelog.Location = new System.Drawing.Point(12, 133);
            this.rtbUpdateAvailableChangelog.Name = "rtbUpdateAvailableChangelog";
            this.rtbUpdateAvailableChangelog.ReadOnly = true;
            this.rtbUpdateAvailableChangelog.Size = new System.Drawing.Size(298, 137);
            this.rtbUpdateAvailableChangelog.TabIndex = 5;
            this.rtbUpdateAvailableChangelog.Text = "";
            // 
            // lbUpdateAvailableChangelog
            // 
            this.lbUpdateAvailableChangelog.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdateAvailableChangelog.Location = new System.Drawing.Point(9, 83);
            this.lbUpdateAvailableChangelog.Name = "lbUpdateAvailableChangelog";
            this.lbUpdateAvailableChangelog.Size = new System.Drawing.Size(301, 21);
            this.lbUpdateAvailableChangelog.TabIndex = 3;
            this.lbUpdateAvailableChangelog.Text = "Changelog:";
            // 
            // btnUpdateAvailableUpdate
            // 
            this.btnUpdateAvailableUpdate.Location = new System.Drawing.Point(108, 276);
            this.btnUpdateAvailableUpdate.Name = "btnUpdateAvailableUpdate";
            this.btnUpdateAvailableUpdate.Size = new System.Drawing.Size(75, 24);
            this.btnUpdateAvailableUpdate.TabIndex = 7;
            this.btnUpdateAvailableUpdate.Text = "Update";
            this.btnUpdateAvailableUpdate.UseVisualStyleBackColor = true;
            this.btnUpdateAvailableUpdate.Click += new System.EventHandler(this.btnUpdateAvailableUpdate_Click);
            // 
            // btnUpdateAvailableOk
            // 
            this.btnUpdateAvailableOk.Location = new System.Drawing.Point(235, 276);
            this.btnUpdateAvailableOk.Name = "btnUpdateAvailableOk";
            this.btnUpdateAvailableOk.Size = new System.Drawing.Size(75, 24);
            this.btnUpdateAvailableOk.TabIndex = 8;
            this.btnUpdateAvailableOk.Text = "OK";
            this.btnUpdateAvailableOk.UseVisualStyleBackColor = true;
            this.btnUpdateAvailableOk.Click += new System.EventHandler(this.btnUpdateAvailableOk_Click);
            // 
            // btnUpdateAvailableSkip
            // 
            this.btnUpdateAvailableSkip.Location = new System.Drawing.Point(12, 276);
            this.btnUpdateAvailableSkip.Name = "btnUpdateAvailableSkip";
            this.btnUpdateAvailableSkip.Size = new System.Drawing.Size(90, 24);
            this.btnUpdateAvailableSkip.TabIndex = 6;
            this.btnUpdateAvailableSkip.Text = "Skip version";
            this.btnUpdateAvailableSkip.UseVisualStyleBackColor = true;
            this.btnUpdateAvailableSkip.Click += new System.EventHandler(this.btnUpdateAvailableSkip_Click);
            // 
            // txtUpdateAvailableName
            // 
            this.txtUpdateAvailableName.Location = new System.Drawing.Point(12, 107);
            this.txtUpdateAvailableName.Name = "txtUpdateAvailableName";
            this.txtUpdateAvailableName.ReadOnly = true;
            this.txtUpdateAvailableName.Size = new System.Drawing.Size(298, 20);
            this.txtUpdateAvailableName.TabIndex = 4;
            // 
            // frmUpdateAvailable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(322, 312);
            this.Controls.Add(this.txtUpdateAvailableName);
            this.Controls.Add(this.btnUpdateAvailableSkip);
            this.Controls.Add(this.btnUpdateAvailableOk);
            this.Controls.Add(this.btnUpdateAvailableUpdate);
            this.Controls.Add(this.lbUpdateAvailableChangelog);
            this.Controls.Add(this.rtbUpdateAvailableChangelog);
            this.Controls.Add(this.lbUpdateAvailableCurrentVersion);
            this.Controls.Add(this.lbUpdateAvailableUpdateVersion);
            this.Controls.Add(this.lbUpdateAvailableHeader);
            this.MaximizeBox = false;
            this.Name = "frmUpdateAvailable";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update available";
            this.Load += new System.EventHandler(this.frmUpdateAvailable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUpdateAvailableHeader;
        private System.Windows.Forms.Label lbUpdateAvailableUpdateVersion;
        private System.Windows.Forms.Label lbUpdateAvailableCurrentVersion;
        private System.Windows.Forms.RichTextBox rtbUpdateAvailableChangelog;
        private System.Windows.Forms.Label lbUpdateAvailableChangelog;
        private System.Windows.Forms.Button btnUpdateAvailableUpdate;
        private System.Windows.Forms.Button btnUpdateAvailableOk;
        private System.Windows.Forms.Button btnUpdateAvailableSkip;
        private System.Windows.Forms.TextBox txtUpdateAvailableName;
    }
}

