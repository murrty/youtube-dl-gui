namespace youtube_dl_gui {
    partial class frmAuthentication {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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
            this.txtCookiesFile = new murrty.controls.ExtendedTextBox();
            this.lbAuthCookiesFromFile = new System.Windows.Forms.Label();
            this.txtCookiesFromBrowser = new System.Windows.Forms.TextBox();
            this.lbAuthCookiesFromBrowser = new System.Windows.Forms.Label();
            this.llCookiesFromBrowserHint = new murrty.controls.ExtendedLinkLabel();
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
            this.lbAuthUsername.Location = new System.Drawing.Point(15, 49);
            this.lbAuthUsername.Name = "lbAuthUsername";
            this.lbAuthUsername.Size = new System.Drawing.Size(106, 20);
            this.lbAuthUsername.TabIndex = 1;
            this.lbAuthUsername.Text = "lbAuthUsername";
            this.lbAuthUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(127, 50);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(165, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(127, 76);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(165, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // lbAuthPassword
            // 
            this.lbAuthPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAuthPassword.Location = new System.Drawing.Point(15, 75);
            this.lbAuthPassword.Name = "lbAuthPassword";
            this.lbAuthPassword.Size = new System.Drawing.Size(106, 20);
            this.lbAuthPassword.TabIndex = 3;
            this.lbAuthPassword.Text = "lbAuthPassword";
            this.lbAuthPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt2Factor
            // 
            this.txt2Factor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt2Factor.Location = new System.Drawing.Point(127, 102);
            this.txt2Factor.Name = "txt2Factor";
            this.txt2Factor.Size = new System.Drawing.Size(165, 20);
            this.txt2Factor.TabIndex = 7;
            // 
            // lbAuth2Factor
            // 
            this.lbAuth2Factor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAuth2Factor.Location = new System.Drawing.Point(15, 101);
            this.lbAuth2Factor.Name = "lbAuth2Factor";
            this.lbAuth2Factor.Size = new System.Drawing.Size(106, 20);
            this.lbAuth2Factor.TabIndex = 6;
            this.lbAuth2Factor.Text = "lbAuth2Factor";
            this.lbAuth2Factor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVideoPassword
            // 
            this.txtVideoPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVideoPassword.Location = new System.Drawing.Point(127, 128);
            this.txtVideoPassword.Name = "txtVideoPassword";
            this.txtVideoPassword.PasswordChar = '●';
            this.txtVideoPassword.Size = new System.Drawing.Size(165, 20);
            this.txtVideoPassword.TabIndex = 9;
            // 
            // lbAuthVideoPassword
            // 
            this.lbAuthVideoPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAuthVideoPassword.Location = new System.Drawing.Point(15, 127);
            this.lbAuthVideoPassword.Name = "lbAuthVideoPassword";
            this.lbAuthVideoPassword.Size = new System.Drawing.Size(106, 20);
            this.lbAuthVideoPassword.TabIndex = 8;
            this.lbAuthVideoPassword.Text = "lbAuthVideoPassword";
            this.lbAuthVideoPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAuthBeginDownload
            // 
            this.btnAuthBeginDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuthBeginDownload.Location = new System.Drawing.Point(124, 266);
            this.btnAuthBeginDownload.Name = "btnAuthBeginDownload";
            this.btnAuthBeginDownload.Size = new System.Drawing.Size(107, 23);
            this.btnAuthBeginDownload.TabIndex = 13;
            this.btnAuthBeginDownload.Text = "btnAuthBeginDownload";
            this.btnAuthBeginDownload.UseVisualStyleBackColor = true;
            this.btnAuthBeginDownload.Click += new System.EventHandler(this.btnAuthBeginDownload_Click);
            // 
            // btnAuthGenericCancel
            // 
            this.btnAuthGenericCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuthGenericCancel.Location = new System.Drawing.Point(237, 266);
            this.btnAuthGenericCancel.Name = "btnAuthGenericCancel";
            this.btnAuthGenericCancel.Size = new System.Drawing.Size(75, 23);
            this.btnAuthGenericCancel.TabIndex = 14;
            this.btnAuthGenericCancel.Text = "btnAuthGenericCancel";
            this.btnAuthGenericCancel.UseVisualStyleBackColor = true;
            this.btnAuthGenericCancel.Click += new System.EventHandler(this.btnAuthGenericCancel_Click);
            // 
            // lbAuthNoSave
            // 
            this.lbAuthNoSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAuthNoSave.Location = new System.Drawing.Point(12, 233);
            this.lbAuthNoSave.Name = "lbAuthNoSave";
            this.lbAuthNoSave.Size = new System.Drawing.Size(300, 28);
            this.lbAuthNoSave.TabIndex = 12;
            this.lbAuthNoSave.Text = "lbAuthNoSave";
            this.lbAuthNoSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkVideoPassVisible
            // 
            this.chkVideoPassVisible.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkVideoPassVisible.AutoSize = true;
            this.chkVideoPassVisible.Location = new System.Drawing.Point(298, 132);
            this.chkVideoPassVisible.Name = "chkVideoPassVisible";
            this.chkVideoPassVisible.Size = new System.Drawing.Size(14, 13);
            this.chkVideoPassVisible.TabIndex = 10;
            this.chkVideoPassVisible.UseVisualStyleBackColor = true;
            this.chkVideoPassVisible.CheckedChanged += new System.EventHandler(this.chkVideoPassVisible_CheckedChanged);
            // 
            // chkPasswordVisible
            // 
            this.chkPasswordVisible.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkPasswordVisible.AutoSize = true;
            this.chkPasswordVisible.Location = new System.Drawing.Point(298, 80);
            this.chkPasswordVisible.Name = "chkPasswordVisible";
            this.chkPasswordVisible.Size = new System.Drawing.Size(14, 13);
            this.chkPasswordVisible.TabIndex = 5;
            this.chkPasswordVisible.UseVisualStyleBackColor = true;
            this.chkPasswordVisible.CheckedChanged += new System.EventHandler(this.chkPasswordVisible_CheckedChanged);
            // 
            // chkAuthUseNetrc
            // 
            this.chkAuthUseNetrc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkAuthUseNetrc.AutoSize = true;
            this.chkAuthUseNetrc.Location = new System.Drawing.Point(107, 211);
            this.chkAuthUseNetrc.Name = "chkAuthUseNetrc";
            this.chkAuthUseNetrc.Size = new System.Drawing.Size(110, 17);
            this.chkAuthUseNetrc.TabIndex = 11;
            this.chkAuthUseNetrc.Text = "chkAuthUseNetrc";
            this.chkAuthUseNetrc.UseVisualStyleBackColor = true;
            // 
            // txtCookiesFile
            // 
            this.txtCookiesFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCookiesFile.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtCookiesFile.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtCookiesFile.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCookiesFile.ButtonImageIndex = -1;
            this.txtCookiesFile.ButtonSize = new System.Drawing.Size(24, 19);
            this.txtCookiesFile.ButtonText = "...";
            this.txtCookiesFile.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtCookiesFile.Location = new System.Drawing.Point(127, 154);
            this.txtCookiesFile.Name = "txtCookiesFile";
            this.txtCookiesFile.ShowButton = true;
            this.txtCookiesFile.Size = new System.Drawing.Size(185, 20);
            this.txtCookiesFile.TabIndex = 15;
            // 
            // lbAuthCookiesFromFile
            // 
            this.lbAuthCookiesFromFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAuthCookiesFromFile.Location = new System.Drawing.Point(15, 153);
            this.lbAuthCookiesFromFile.Name = "lbAuthCookiesFromFile";
            this.lbAuthCookiesFromFile.Size = new System.Drawing.Size(106, 20);
            this.lbAuthCookiesFromFile.TabIndex = 16;
            this.lbAuthCookiesFromFile.Text = "lbAuthCookiesFromFile";
            this.lbAuthCookiesFromFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCookiesFromBrowser
            // 
            this.txtCookiesFromBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCookiesFromBrowser.Location = new System.Drawing.Point(127, 180);
            this.txtCookiesFromBrowser.Name = "txtCookiesFromBrowser";
            this.txtCookiesFromBrowser.Size = new System.Drawing.Size(185, 20);
            this.txtCookiesFromBrowser.TabIndex = 18;
            // 
            // lbAuthCookiesFromBrowser
            // 
            this.lbAuthCookiesFromBrowser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAuthCookiesFromBrowser.Location = new System.Drawing.Point(15, 179);
            this.lbAuthCookiesFromBrowser.Name = "lbAuthCookiesFromBrowser";
            this.lbAuthCookiesFromBrowser.Size = new System.Drawing.Size(106, 20);
            this.lbAuthCookiesFromBrowser.TabIndex = 17;
            this.lbAuthCookiesFromBrowser.Text = "lbAuthCookiesFromBrowser";
            this.lbAuthCookiesFromBrowser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // llCookiesFromBrowserHint
            // 
            this.llCookiesFromBrowserHint.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.llCookiesFromBrowserHint.AutoSize = true;
            this.llCookiesFromBrowserHint.Location = new System.Drawing.Point(299, 203);
            this.llCookiesFromBrowserHint.Name = "llCookiesFromBrowserHint";
            this.llCookiesFromBrowserHint.Size = new System.Drawing.Size(13, 13);
            this.llCookiesFromBrowserHint.TabIndex = 19;
            this.llCookiesFromBrowserHint.TabStop = true;
            this.llCookiesFromBrowserHint.Text = "?";
            this.llCookiesFromBrowserHint.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.llCookiesFromBrowserHint.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCookiesFromBrowserHint_LinkClicked);
            // 
            // frmAuthentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(324, 305);
            this.Controls.Add(this.llCookiesFromBrowserHint);
            this.Controls.Add(this.txtCookiesFromBrowser);
            this.Controls.Add(this.lbAuthCookiesFromBrowser);
            this.Controls.Add(this.lbAuthCookiesFromFile);
            this.Controls.Add(this.txtCookiesFile);
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
            this.Icon = global::youtube_dl_gui.Properties.Resources.ProgramIcon;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(340, 340);
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
        private murrty.controls.ExtendedTextBox txtCookiesFile;
        private System.Windows.Forms.Label lbAuthCookiesFromFile;
        private System.Windows.Forms.TextBox txtCookiesFromBrowser;
        private System.Windows.Forms.Label lbAuthCookiesFromBrowser;
        private murrty.controls.ExtendedLinkLabel llCookiesFromBrowserHint;
    }
}