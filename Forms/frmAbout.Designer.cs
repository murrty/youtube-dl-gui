namespace youtube_dl_gui
{
    partial class frmAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.lbVersion = new System.Windows.Forms.Label();
            this.llbCheckForUpdates = new System.Windows.Forms.LinkLabel();
            this.lbHeader = new System.Windows.Forms.Label();
            this.lbBody = new System.Windows.Forms.Label();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.llbGithub = new System.Windows.Forms.LinkLabel();
            this.llbGitlab = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Location = new System.Drawing.Point(191, 14);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(28, 13);
            this.lbVersion.TabIndex = 0;
            this.lbVersion.Text = "v0.0";
            // 
            // llbCheckForUpdates
            // 
            this.llbCheckForUpdates.AutoSize = true;
            this.llbCheckForUpdates.Location = new System.Drawing.Point(85, 120);
            this.llbCheckForUpdates.Name = "llbCheckForUpdates";
            this.llbCheckForUpdates.Size = new System.Drawing.Size(94, 13);
            this.llbCheckForUpdates.TabIndex = 1;
            this.llbCheckForUpdates.TabStop = true;
            this.llbCheckForUpdates.Text = "Check for updates";
            this.llbCheckForUpdates.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbCheckForUpdates_LinkClicked);
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.Location = new System.Drawing.Point(71, 8);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(123, 20);
            this.lbHeader.TabIndex = 2;
            this.lbHeader.Text = "youtube-dl-gui";
            // 
            // lbBody
            // 
            this.lbBody.Location = new System.Drawing.Point(12, 36);
            this.lbBody.Name = "lbBody";
            this.lbBody.Size = new System.Drawing.Size(240, 79);
            this.lbBody.TabIndex = 3;
            this.lbBody.Text = "youtube-dl by rg3\r\nyoutube-dl-gui by murrty\r\ncoded in VisualStudio 2013\r\n\r\n\r\nliku" +
    "lau best boye.";
            this.lbBody.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbIcon
            // 
            this.pbIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbIcon.Image")));
            this.pbIcon.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbIcon.InitialImage")));
            this.pbIcon.Location = new System.Drawing.Point(38, 3);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(32, 32);
            this.pbIcon.TabIndex = 4;
            this.pbIcon.TabStop = false;
            this.pbIcon.Click += new System.EventHandler(this.pbIcon_Click);
            // 
            // llbGithub
            // 
            this.llbGithub.AutoSize = true;
            this.llbGithub.LinkColor = System.Drawing.Color.Blue;
            this.llbGithub.Location = new System.Drawing.Point(222, 110);
            this.llbGithub.Name = "llbGithub";
            this.llbGithub.Size = new System.Drawing.Size(38, 13);
            this.llbGithub.TabIndex = 5;
            this.llbGithub.TabStop = true;
            this.llbGithub.Text = "Github";
            this.llbGithub.Visible = false;
            this.llbGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbGithub_LinkClicked);
            // 
            // llbGitlab
            // 
            this.llbGitlab.AutoSize = true;
            this.llbGitlab.Location = new System.Drawing.Point(226, 128);
            this.llbGitlab.Name = "llbGitlab";
            this.llbGitlab.Size = new System.Drawing.Size(34, 13);
            this.llbGitlab.TabIndex = 6;
            this.llbGitlab.TabStop = true;
            this.llbGitlab.Text = "Gitlab";
            this.llbGitlab.Visible = false;
            this.llbGitlab.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbGitlab_LinkClicked);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(272, 150);
            this.Controls.Add(this.llbGitlab);
            this.Controls.Add(this.llbGithub);
            this.Controls.Add(this.pbIcon);
            this.Controls.Add(this.lbBody);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.llbCheckForUpdates);
            this.Controls.Add(this.lbVersion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(280, 180);
            this.MinimumSize = new System.Drawing.Size(280, 180);
            this.Name = "frmAbout";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About youtube-dl-gui";
            this.Shown += new System.EventHandler(this.frmAbout_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.LinkLabel llbCheckForUpdates;
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.Label lbBody;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.LinkLabel llbGithub;
        private System.Windows.Forms.LinkLabel llbGitlab;
    }
}