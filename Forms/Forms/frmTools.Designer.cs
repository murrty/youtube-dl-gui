namespace youtube_dl_gui {
    partial class frmTools {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTools));
            this.btnRemoveAudio = new System.Windows.Forms.Button();
            this.miscTips = new System.Windows.Forms.ToolTip(this.components);
            this.btnExtractAudio = new System.Windows.Forms.Button();
            this.btnVideoToGif = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRemoveAudio
            // 
            this.btnRemoveAudio.Location = new System.Drawing.Point(18, 16);
            this.btnRemoveAudio.Name = "btnRemoveAudio";
            this.btnRemoveAudio.Size = new System.Drawing.Size(102, 26);
            this.btnRemoveAudio.TabIndex = 0;
            this.btnRemoveAudio.Text = "Remove audio...";
            this.miscTips.SetToolTip(this.btnRemoveAudio, "Removes audio from a selected file");
            this.btnRemoveAudio.UseVisualStyleBackColor = true;
            this.btnRemoveAudio.Click += new System.EventHandler(this.btnRemoveAudio_Click);
            // 
            // miscTips
            // 
            this.miscTips.AutoPopDelay = 10000;
            this.miscTips.InitialDelay = 500;
            this.miscTips.ReshowDelay = 100;
            // 
            // btnExtractAudio
            // 
            this.btnExtractAudio.Location = new System.Drawing.Point(132, 16);
            this.btnExtractAudio.Name = "btnExtractAudio";
            this.btnExtractAudio.Size = new System.Drawing.Size(102, 26);
            this.btnExtractAudio.TabIndex = 1;
            this.btnExtractAudio.Text = "Extract audio...";
            this.miscTips.SetToolTip(this.btnExtractAudio, "Extracts the audio from a video file");
            this.btnExtractAudio.UseVisualStyleBackColor = true;
            this.btnExtractAudio.Click += new System.EventHandler(this.btnExtractAudio_Click);
            // 
            // btnVideoToGif
            // 
            this.btnVideoToGif.Location = new System.Drawing.Point(18, 52);
            this.btnVideoToGif.Name = "btnVideoToGif";
            this.btnVideoToGif.Size = new System.Drawing.Size(102, 26);
            this.btnVideoToGif.TabIndex = 2;
            this.btnVideoToGif.Text = "Video to gif...";
            this.miscTips.SetToolTip(this.btnVideoToGif, "Convert videos to gif, requires ImageMagick");
            this.btnVideoToGif.UseVisualStyleBackColor = true;
            this.btnVideoToGif.Visible = false;
            this.btnVideoToGif.Click += new System.EventHandler(this.btnVideoToGif_Click);
            // 
            // frmTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(252, 160);
            this.Controls.Add(this.btnVideoToGif);
            this.Controls.Add(this.btnExtractAudio);
            this.Controls.Add(this.btnRemoveAudio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(260, 190);
            this.MinimumSize = new System.Drawing.Size(260, 190);
            this.Name = "frmTools";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Misc Tools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTools_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveAudio;
        private System.Windows.Forms.ToolTip miscTips;
        private System.Windows.Forms.Button btnExtractAudio;
        private System.Windows.Forms.Button btnVideoToGif;
    }
}