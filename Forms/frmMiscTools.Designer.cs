namespace youtube_dl_gui {
    partial class frmMiscTools {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMiscTools));
            this.btnMiscToolsRemoveAudio = new System.Windows.Forms.Button();
            this.miscTips = new System.Windows.Forms.ToolTip(this.components);
            this.btnMiscToolsExtractAudio = new System.Windows.Forms.Button();
            this.btnMiscToolsVideoToGif = new System.Windows.Forms.Button();
            this.btnMiscToolsHiddenAttribute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMiscToolsRemoveAudio
            // 
            this.btnMiscToolsRemoveAudio.Location = new System.Drawing.Point(18, 16);
            this.btnMiscToolsRemoveAudio.Name = "btnMiscToolsRemoveAudio";
            this.btnMiscToolsRemoveAudio.Size = new System.Drawing.Size(102, 26);
            this.btnMiscToolsRemoveAudio.TabIndex = 0;
            this.btnMiscToolsRemoveAudio.Text = "btnMiscToolsRemoveAudio";
            this.miscTips.SetToolTip(this.btnMiscToolsRemoveAudio, "Removes audio from a selected file");
            this.btnMiscToolsRemoveAudio.UseVisualStyleBackColor = true;
            this.btnMiscToolsRemoveAudio.Click += new System.EventHandler(this.btnMiscToolsRemoveAudio_Click);
            // 
            // miscTips
            // 
            this.miscTips.AutoPopDelay = 10000;
            this.miscTips.InitialDelay = 500;
            this.miscTips.ReshowDelay = 100;
            // 
            // btnMiscToolsExtractAudio
            // 
            this.btnMiscToolsExtractAudio.Location = new System.Drawing.Point(132, 16);
            this.btnMiscToolsExtractAudio.Name = "btnMiscToolsExtractAudio";
            this.btnMiscToolsExtractAudio.Size = new System.Drawing.Size(102, 26);
            this.btnMiscToolsExtractAudio.TabIndex = 1;
            this.btnMiscToolsExtractAudio.Text = "btnMiscToolsExtractAudio";
            this.miscTips.SetToolTip(this.btnMiscToolsExtractAudio, "Extracts the audio from a video file");
            this.btnMiscToolsExtractAudio.UseVisualStyleBackColor = true;
            this.btnMiscToolsExtractAudio.Click += new System.EventHandler(this.btnMiscToolsExtractAudio_Click);
            // 
            // btnMiscToolsVideoToGif
            // 
            this.btnMiscToolsVideoToGif.Location = new System.Drawing.Point(18, 52);
            this.btnMiscToolsVideoToGif.Name = "btnMiscToolsVideoToGif";
            this.btnMiscToolsVideoToGif.Size = new System.Drawing.Size(102, 26);
            this.btnMiscToolsVideoToGif.TabIndex = 2;
            this.btnMiscToolsVideoToGif.Text = "btnMiscToolsVideoToGif";
            this.miscTips.SetToolTip(this.btnMiscToolsVideoToGif, "Convert videos to gif, requires ImageMagick");
            this.btnMiscToolsVideoToGif.UseVisualStyleBackColor = true;
            this.btnMiscToolsVideoToGif.Click += new System.EventHandler(this.btnMiscToolsVideoToGif_Click);
            // 
            // btnMiscToolsHiddenAttribute
            // 
            this.btnMiscToolsHiddenAttribute.Location = new System.Drawing.Point(132, 52);
            this.btnMiscToolsHiddenAttribute.Name = "btnMiscToolsHiddenAttribute";
            this.btnMiscToolsHiddenAttribute.Size = new System.Drawing.Size(102, 26);
            this.btnMiscToolsHiddenAttribute.TabIndex = 3;
            this.btnMiscToolsHiddenAttribute.Text = "btnMiscToolsHiddenAttribute";
            this.btnMiscToolsHiddenAttribute.UseVisualStyleBackColor = true;
            this.btnMiscToolsHiddenAttribute.Click += new System.EventHandler(this.btnMiscToolsHiddenAttribute_Click);
            // 
            // frmMiscTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(252, 160);
            this.Controls.Add(this.btnMiscToolsHiddenAttribute);
            this.Controls.Add(this.btnMiscToolsVideoToGif);
            this.Controls.Add(this.btnMiscToolsExtractAudio);
            this.Controls.Add(this.btnMiscToolsRemoveAudio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(260, 190);
            this.MinimumSize = new System.Drawing.Size(260, 190);
            this.Name = "frmMiscTools";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTools_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMiscToolsRemoveAudio;
        private System.Windows.Forms.ToolTip miscTips;
        private System.Windows.Forms.Button btnMiscToolsExtractAudio;
        private System.Windows.Forms.Button btnMiscToolsVideoToGif;
        private System.Windows.Forms.Button btnMiscToolsHiddenAttribute;
    }
}