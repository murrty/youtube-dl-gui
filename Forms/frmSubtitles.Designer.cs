namespace youtube_dl_gui {
    partial class frmSubtitles {
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
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lbSubtitlesHeader = new System.Windows.Forms.Label();
            this.lbSubtitlesUrl = new System.Windows.Forms.Label();
            this.lbSubtitlesLanguages = new System.Windows.Forms.Label();
            this.txtLanguage = new System.Windows.Forms.TextBox();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.btnSubtitlesAddLanguages = new System.Windows.Forms.Button();
            this.btnSubtitlesDownload = new System.Windows.Forms.Button();
            this.btnSubtitlesClearLanguages = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(30, 55);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(260, 20);
            this.txtURL.TabIndex = 2;
            // 
            // lbSubtitlesHeader
            // 
            this.lbSubtitlesHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSubtitlesHeader.Location = new System.Drawing.Point(12, 9);
            this.lbSubtitlesHeader.Name = "lbSubtitlesHeader";
            this.lbSubtitlesHeader.Size = new System.Drawing.Size(288, 20);
            this.lbSubtitlesHeader.TabIndex = 0;
            this.lbSubtitlesHeader.Text = "lbSubtitlesHeader";
            this.lbSubtitlesHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSubtitlesUrl
            // 
            this.lbSubtitlesUrl.AutoSize = true;
            this.lbSubtitlesUrl.Location = new System.Drawing.Point(23, 39);
            this.lbSubtitlesUrl.Name = "lbSubtitlesUrl";
            this.lbSubtitlesUrl.Size = new System.Drawing.Size(68, 13);
            this.lbSubtitlesUrl.TabIndex = 1;
            this.lbSubtitlesUrl.Text = "lbSubtitlesUrl";
            // 
            // lbSubtitlesLanguages
            // 
            this.lbSubtitlesLanguages.AutoSize = true;
            this.lbSubtitlesLanguages.Location = new System.Drawing.Point(23, 82);
            this.lbSubtitlesLanguages.Name = "lbSubtitlesLanguages";
            this.lbSubtitlesLanguages.Size = new System.Drawing.Size(68, 13);
            this.lbSubtitlesLanguages.TabIndex = 3;
            this.lbSubtitlesLanguages.Text = "lbLanguages";
            // 
            // txtLanguage
            // 
            this.txtLanguage.Location = new System.Drawing.Point(30, 98);
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.ReadOnly = true;
            this.txtLanguage.Size = new System.Drawing.Size(137, 20);
            this.txtLanguage.TabIndex = 4;
            this.txtLanguage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLanguage_KeyPress);
            // 
            // cbLanguage
            // 
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Items.AddRange(new object[] {
            "All Subtitles",
            "af",
            "am",
            "ar",
            "az",
            "be",
            "bg",
            "bn",
            "bs",
            "ca",
            "ceb",
            "co",
            "cs",
            "cy",
            "da",
            "de",
            "el",
            "en",
            "eo",
            "es",
            "et",
            "eu",
            "fa",
            "fi",
            "fil",
            "fr",
            "fy",
            "ga",
            "gd",
            "gl",
            "gu",
            "ha",
            "haw",
            "hi",
            "hmn",
            "hr",
            "ht",
            "hu",
            "hy",
            "id",
            "ig",
            "is",
            "it",
            "iw",
            "ja",
            "jv",
            "ka",
            "kk",
            "km",
            "kn",
            "ko",
            "ku",
            "ky",
            "la",
            "lb",
            "lo",
            "lt",
            "lv",
            "mg",
            "mi",
            "mk",
            "ml",
            "mn",
            "mr",
            "ms",
            "mt",
            "my",
            "ne",
            "nl",
            "no",
            "ny",
            "pa",
            "pl",
            "ps",
            "pt",
            "ro",
            "ru",
            "sd",
            "si",
            "sk",
            "sl",
            "sm",
            "sn",
            "so",
            "sq",
            "sr",
            "st",
            "su",
            "sv",
            "sw",
            "ta",
            "te",
            "tg",
            "th",
            "tr",
            "uk",
            "ur",
            "uz",
            "vi",
            "xh",
            "yi",
            "yo",
            "zh-Hans",
            "zh-Hant",
            "zu"});
            this.cbLanguage.Location = new System.Drawing.Point(173, 98);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(75, 21);
            this.cbLanguage.TabIndex = 5;
            // 
            // btnSubtitlesAddLanguages
            // 
            this.btnSubtitlesAddLanguages.Location = new System.Drawing.Point(254, 97);
            this.btnSubtitlesAddLanguages.Name = "btnSubtitlesAddLanguages";
            this.btnSubtitlesAddLanguages.Size = new System.Drawing.Size(36, 23);
            this.btnSubtitlesAddLanguages.TabIndex = 6;
            this.btnSubtitlesAddLanguages.Text = "btnSubtitlesAddLanguage";
            this.btnSubtitlesAddLanguages.UseVisualStyleBackColor = true;
            this.btnSubtitlesAddLanguages.Click += new System.EventHandler(this.btnSubtitlesAddLanguages_Click);
            // 
            // btnSubtitlesDownload
            // 
            this.btnSubtitlesDownload.Location = new System.Drawing.Point(95, 133);
            this.btnSubtitlesDownload.Name = "btnSubtitlesDownload";
            this.btnSubtitlesDownload.Size = new System.Drawing.Size(123, 23);
            this.btnSubtitlesDownload.TabIndex = 8;
            this.btnSubtitlesDownload.Text = "btnSubtitlesDownload";
            this.btnSubtitlesDownload.UseVisualStyleBackColor = true;
            this.btnSubtitlesDownload.Click += new System.EventHandler(this.btnSubtitlesDownload_Click);
            // 
            // btnSubtitlesClearLanguages
            // 
            this.btnSubtitlesClearLanguages.Location = new System.Drawing.Point(250, 125);
            this.btnSubtitlesClearLanguages.Name = "btnSubtitlesClearLanguages";
            this.btnSubtitlesClearLanguages.Size = new System.Drawing.Size(40, 23);
            this.btnSubtitlesClearLanguages.TabIndex = 7;
            this.btnSubtitlesClearLanguages.Text = "btnSubtitlesClear";
            this.btnSubtitlesClearLanguages.UseVisualStyleBackColor = true;
            this.btnSubtitlesClearLanguages.Click += new System.EventHandler(this.btnSubtitlesClearLanguages_Click);
            // 
            // frmSubtitles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(312, 170);
            this.Controls.Add(this.btnSubtitlesClearLanguages);
            this.Controls.Add(this.btnSubtitlesDownload);
            this.Controls.Add(this.btnSubtitlesAddLanguages);
            this.Controls.Add(this.cbLanguage);
            this.Controls.Add(this.lbSubtitlesLanguages);
            this.Controls.Add(this.txtLanguage);
            this.Controls.Add(this.lbSubtitlesUrl);
            this.Controls.Add(this.lbSubtitlesHeader);
            this.Controls.Add(this.txtURL);
            this.MaximumSize = new System.Drawing.Size(320, 200);
            this.MinimumSize = new System.Drawing.Size(320, 200);
            this.Name = "frmSubtitles";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSubtitles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label lbSubtitlesHeader;
        private System.Windows.Forms.Label lbSubtitlesUrl;
        private System.Windows.Forms.Label lbSubtitlesLanguages;
        private System.Windows.Forms.TextBox txtLanguage;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.Button btnSubtitlesAddLanguages;
        private System.Windows.Forms.Button btnSubtitlesDownload;
        private System.Windows.Forms.Button btnSubtitlesClearLanguages;
    }
}