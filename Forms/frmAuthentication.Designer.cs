namespace youtube_dl_gui {
    partial class frmAuthentication {
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
            this.lbAuthNotice = new System.Windows.Forms.Label();
            this.lbAuthUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lbAuthPassword = new System.Windows.Forms.Label();
            this.txt2Factor = new System.Windows.Forms.TextBox();
            this.lbAuth2Factor = new System.Windows.Forms.Label();
            this.txtVideoPassword = new System.Windows.Forms.TextBox();
            this.lbAuthVideoPassword = new System.Windows.Forms.Label();
            this.btnAuthBeginDownload = new System.Windows.Forms.Button();
            this.btnAuthGenericCancel = new System.Windows.Forms.Button();
            this.lbAuthNoSave = new System.Windows.Forms.Label();
            this.chkVideoPassVisible = new System.Windows.Forms.CheckBox();
            this.chkPasswordVisible = new System.Windows.Forms.CheckBox();
            this.chkAuthUseNetrc = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbAuthNotice
            // 
            this.lbAuthNotice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAuthNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAuthNotice.Location = new System.Drawing.Point(12, 11);
            this.lbAuthNotice.Name = "lbAuthNotice";
            this.lbAuthNotice.Size = new System.Drawing.Size(300, 29);
            this.lbAuthNotice.TabIndex = 0;
            this.lbAuthNotice.Text = "lbAuthNotice";
            this.lbAuthNotice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbAuthUsername
            // 
            this.lbAuthUsername.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAuthUsername.Location = new System.Drawing.Point(15, 51);
            this.lbAuthUsername.Name = "lbAuthUsername";
            this.lbAuthUsername.Size = new System.Drawing.Size(106, 20);
            this.lbAuthUsername.TabIndex = 1;
            this.lbAuthUsername.Text = "lbAuthUsername";
            this.lbAuthUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(127, 52);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(134, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(127, 78);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(134, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // lbAuthPassword
            // 
            this.lbAuthPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAuthPassword.Location = new System.Drawing.Point(15, 77);
            this.lbAuthPassword.Name = "lbAuthPassword";
            this.lbAuthPassword.Size = new System.Drawing.Size(106, 20);
            this.lbAuthPassword.TabIndex = 3;
            this.lbAuthPassword.Text = "lbAuthPassword";
            this.lbAuthPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt2Factor
            // 
            this.txt2Factor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt2Factor.Location = new System.Drawing.Point(127, 104);
            this.txt2Factor.Name = "txt2Factor";
            this.txt2Factor.Size = new System.Drawing.Size(134, 20);
            this.txt2Factor.TabIndex = 7;
            // 
            // lbAuth2Factor
            // 
            this.lbAuth2Factor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAuth2Factor.Location = new System.Drawing.Point(15, 103);
            this.lbAuth2Factor.Name = "lbAuth2Factor";
            this.lbAuth2Factor.Size = new System.Drawing.Size(106, 20);
            this.lbAuth2Factor.TabIndex = 6;
            this.lbAuth2Factor.Text = "lbAuth2Factor";
            this.lbAuth2Factor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVideoPassword
            // 
            this.txtVideoPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVideoPassword.Location = new System.Drawing.Point(127, 130);
            this.txtVideoPassword.Name = "txtVideoPassword";
            this.txtVideoPassword.PasswordChar = '●';
            this.txtVideoPassword.Size = new System.Drawing.Size(134, 20);
            this.txtVideoPassword.TabIndex = 11;
            // 
            // lbAuthVideoPassword
            // 
            this.lbAuthVideoPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAuthVideoPassword.Location = new System.Drawing.Point(15, 129);
            this.lbAuthVideoPassword.Name = "lbAuthVideoPassword";
            this.lbAuthVideoPassword.Size = new System.Drawing.Size(106, 20);
            this.lbAuthVideoPassword.TabIndex = 10;
            this.lbAuthVideoPassword.Text = "lbAuthVideoPassword";
            this.lbAuthVideoPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAuthBeginDownload
            // 
            this.btnAuthBeginDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuthBeginDownload.Location = new System.Drawing.Point(124, 216);
            this.btnAuthBeginDownload.Name = "btnAuthBeginDownload";
            this.btnAuthBeginDownload.Size = new System.Drawing.Size(107, 23);
            this.btnAuthBeginDownload.TabIndex = 14;
            this.btnAuthBeginDownload.Text = "btnAuthBeginDownload";
            this.btnAuthBeginDownload.UseVisualStyleBackColor = true;
            this.btnAuthBeginDownload.Click += new System.EventHandler(this.btnAuthBeginDownload_Click);
            // 
            // btnAuthGenericCancel
            // 
            this.btnAuthGenericCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuthGenericCancel.Location = new System.Drawing.Point(237, 216);
            this.btnAuthGenericCancel.Name = "btnAuthGenericCancel";
            this.btnAuthGenericCancel.Size = new System.Drawing.Size(75, 23);
            this.btnAuthGenericCancel.TabIndex = 15;
            this.btnAuthGenericCancel.Text = "btnAuthGenericCancel";
            this.btnAuthGenericCancel.UseVisualStyleBackColor = true;
            this.btnAuthGenericCancel.Click += new System.EventHandler(this.btnAuthGenericCancel_Click);
            // 
            // lbAuthNoSave
            // 
            this.lbAuthNoSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAuthNoSave.Location = new System.Drawing.Point(12, 183);
            this.lbAuthNoSave.Name = "lbAuthNoSave";
            this.lbAuthNoSave.Size = new System.Drawing.Size(300, 28);
            this.lbAuthNoSave.TabIndex = 13;
            this.lbAuthNoSave.Text = "lbAuthNoSave";
            this.lbAuthNoSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkVideoPassVisible
            // 
            this.chkVideoPassVisible.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkVideoPassVisible.AutoSize = true;
            this.chkVideoPassVisible.Location = new System.Drawing.Point(267, 133);
            this.chkVideoPassVisible.Name = "chkVideoPassVisible";
            this.chkVideoPassVisible.Size = new System.Drawing.Size(15, 14);
            this.chkVideoPassVisible.TabIndex = 12;
            this.chkVideoPassVisible.UseVisualStyleBackColor = true;
            this.chkVideoPassVisible.CheckedChanged += new System.EventHandler(this.chkVideoPassVisible_CheckedChanged);
            // 
            // chkPasswordVisible
            // 
            this.chkPasswordVisible.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkPasswordVisible.AutoSize = true;
            this.chkPasswordVisible.Location = new System.Drawing.Point(267, 81);
            this.chkPasswordVisible.Name = "chkPasswordVisible";
            this.chkPasswordVisible.Size = new System.Drawing.Size(15, 14);
            this.chkPasswordVisible.TabIndex = 5;
            this.chkPasswordVisible.UseVisualStyleBackColor = true;
            this.chkPasswordVisible.CheckedChanged += new System.EventHandler(this.chkPasswordVisible_CheckedChanged);
            // 
            // chkAuthUseNetrc
            // 
            this.chkAuthUseNetrc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkAuthUseNetrc.AutoSize = true;
            this.chkAuthUseNetrc.Location = new System.Drawing.Point(107, 161);
            this.chkAuthUseNetrc.Name = "chkAuthUseNetrc";
            this.chkAuthUseNetrc.Size = new System.Drawing.Size(111, 17);
            this.chkAuthUseNetrc.TabIndex = 16;
            this.chkAuthUseNetrc.Text = "chkAuthUseNetrc";
            this.chkAuthUseNetrc.UseVisualStyleBackColor = true;
            // 
            // frmAuthentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(324, 251);
            this.Controls.Add(this.chkAuthUseNetrc);
            this.Controls.Add(this.chkPasswordVisible);
            this.Controls.Add(this.chkVideoPassVisible);
            this.Controls.Add(this.lbAuthNoSave);
            this.Controls.Add(this.btnAuthGenericCancel);
            this.Controls.Add(this.btnAuthBeginDownload);
            this.Controls.Add(this.txtVideoPassword);
            this.Controls.Add(this.lbAuthVideoPassword);
            this.Controls.Add(this.txt2Factor);
            this.Controls.Add(this.lbAuth2Factor);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lbAuthPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lbAuthUsername);
            this.Controls.Add(this.lbAuthNotice);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(340, 290);
            this.Name = "frmAuthentication";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAuthentication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbAuthNotice;
        private System.Windows.Forms.Label lbAuthUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lbAuthPassword;
        private System.Windows.Forms.TextBox txt2Factor;
        private System.Windows.Forms.Label lbAuth2Factor;
        private System.Windows.Forms.TextBox txtVideoPassword;
        private System.Windows.Forms.Label lbAuthVideoPassword;
        private System.Windows.Forms.Button btnAuthBeginDownload;
        private System.Windows.Forms.Button btnAuthGenericCancel;
        private System.Windows.Forms.Label lbAuthNoSave;
        private System.Windows.Forms.CheckBox chkVideoPassVisible;
        private System.Windows.Forms.CheckBox chkPasswordVisible;
        private System.Windows.Forms.CheckBox chkAuthUseNetrc;
    }
}