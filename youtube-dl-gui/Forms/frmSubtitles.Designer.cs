namespace youtube_dl_gui {
    partial class frmSubtitles {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent() {
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lbSubtitlesUrl = new System.Windows.Forms.Label();
            this.lbSubtitlesLanguages = new System.Windows.Forms.Label();
            this.txtLanguage = new System.Windows.Forms.TextBox();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.btnSubtitlesAddLanguages = new System.Windows.Forms.Button();
            this.btnSubtitlesDownload = new System.Windows.Forms.Button();
            this.btnSubtitlesClearLanguages = new System.Windows.Forms.Button();
            this.lbSubtitlesHeader = new System.Windows.Forms.Label();
            this.chkSubtitlesGeneratedSubtitles = new System.Windows.Forms.CheckBox();
            this.chkSubtitlesUploadedSubtitles = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(35, 53);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(282, 20);
            this.txtURL.TabIndex = 2;
            // 
            // lbSubtitlesUrl
            // 
            this.lbSubtitlesUrl.AutoSize = true;
            this.lbSubtitlesUrl.Location = new System.Drawing.Point(28, 37);
            this.lbSubtitlesUrl.Name = "lbSubtitlesUrl";
            this.lbSubtitlesUrl.Size = new System.Drawing.Size(68, 13);
            this.lbSubtitlesUrl.TabIndex = 1;
            this.lbSubtitlesUrl.Text = "lbSubtitlesUrl";
            // 
            // lbSubtitlesLanguages
            // 
            this.lbSubtitlesLanguages.AutoSize = true;
            this.lbSubtitlesLanguages.Location = new System.Drawing.Point(28, 80);
            this.lbSubtitlesLanguages.Name = "lbSubtitlesLanguages";
            this.lbSubtitlesLanguages.Size = new System.Drawing.Size(68, 13);
            this.lbSubtitlesLanguages.TabIndex = 3;
            this.lbSubtitlesLanguages.Text = "lbLanguages";
            // 
            // txtLanguage
            // 
            this.txtLanguage.Location = new System.Drawing.Point(35, 96);
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
            this.cbLanguage.Location = new System.Drawing.Point(178, 95);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(75, 21);
            this.cbLanguage.TabIndex = 5;
            // 
            // btnSubtitlesAddLanguages
            // 
            this.btnSubtitlesAddLanguages.Location = new System.Drawing.Point(259, 94);
            this.btnSubtitlesAddLanguages.Name = "btnSubtitlesAddLanguages";
            this.btnSubtitlesAddLanguages.Size = new System.Drawing.Size(58, 23);
            this.btnSubtitlesAddLanguages.TabIndex = 6;
            this.btnSubtitlesAddLanguages.Text = "btnSubtitlesAddLanguage";
            this.btnSubtitlesAddLanguages.UseVisualStyleBackColor = true;
            this.btnSubtitlesAddLanguages.Click += new System.EventHandler(this.btnSubtitlesAddLanguages_Click);
            // 
            // btnSubtitlesDownload
            // 
            this.btnSubtitlesDownload.Location = new System.Drawing.Point(111, 165);
            this.btnSubtitlesDownload.Name = "btnSubtitlesDownload";
            this.btnSubtitlesDownload.Size = new System.Drawing.Size(123, 23);
            this.btnSubtitlesDownload.TabIndex = 8;
            this.btnSubtitlesDownload.Text = "btnSubtitlesDownload";
            this.btnSubtitlesDownload.UseVisualStyleBackColor = true;
            this.btnSubtitlesDownload.Click += new System.EventHandler(this.btnSubtitlesDownload_Click);
            // 
            // btnSubtitlesClearLanguages
            // 
            this.btnSubtitlesClearLanguages.Location = new System.Drawing.Point(255, 122);
            this.btnSubtitlesClearLanguages.Name = "btnSubtitlesClearLanguages";
            this.btnSubtitlesClearLanguages.Size = new System.Drawing.Size(62, 23);
            this.btnSubtitlesClearLanguages.TabIndex = 7;
            this.btnSubtitlesClearLanguages.Text = "btnSubtitlesClear";
            this.btnSubtitlesClearLanguages.UseVisualStyleBackColor = true;
            this.btnSubtitlesClearLanguages.Click += new System.EventHandler(this.btnSubtitlesClearLanguages_Click);
            // 
            // lbSubtitlesHeader
            // 
            this.lbSubtitlesHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSubtitlesHeader.Location = new System.Drawing.Point(12, 9);
            this.lbSubtitlesHeader.Name = "lbSubtitlesHeader";
            this.lbSubtitlesHeader.Size = new System.Drawing.Size(319, 20);
            this.lbSubtitlesHeader.TabIndex = 0;
            this.lbSubtitlesHeader.Text = "lbSubtitlesHeader";
            this.lbSubtitlesHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkSubtitlesGeneratedSubtitles
            // 
            this.chkSubtitlesGeneratedSubtitles.AutoSize = true;
            this.chkSubtitlesGeneratedSubtitles.Location = new System.Drawing.Point(35, 141);
            this.chkSubtitlesGeneratedSubtitles.Name = "chkSubtitlesGeneratedSubtitles";
            this.chkSubtitlesGeneratedSubtitles.Size = new System.Drawing.Size(173, 17);
            this.chkSubtitlesGeneratedSubtitles.TabIndex = 9;
            this.chkSubtitlesGeneratedSubtitles.Text = "chkSubtitlesGeneratedSubtitles";
            this.chkSubtitlesGeneratedSubtitles.UseVisualStyleBackColor = true;
            // 
            // chkSubtitlesUploadedSubtitles
            // 
            this.chkSubtitlesUploadedSubtitles.AutoSize = true;
            this.chkSubtitlesUploadedSubtitles.Checked = true;
            this.chkSubtitlesUploadedSubtitles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSubtitlesUploadedSubtitles.Location = new System.Drawing.Point(35, 122);
            this.chkSubtitlesUploadedSubtitles.Name = "chkSubtitlesUploadedSubtitles";
            this.chkSubtitlesUploadedSubtitles.Size = new System.Drawing.Size(169, 17);
            this.chkSubtitlesUploadedSubtitles.TabIndex = 10;
            this.chkSubtitlesUploadedSubtitles.Text = "chkSubtitlesUploadedSubtitles";
            this.chkSubtitlesUploadedSubtitles.UseVisualStyleBackColor = true;
            // 
            // frmSubtitles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(344, 205);
            this.Controls.Add(this.chkSubtitlesUploadedSubtitles);
            this.Controls.Add(this.chkSubtitlesGeneratedSubtitles);
            this.Controls.Add(this.btnSubtitlesClearLanguages);
            this.Controls.Add(this.btnSubtitlesDownload);
            this.Controls.Add(this.btnSubtitlesAddLanguages);
            this.Controls.Add(this.cbLanguage);
            this.Controls.Add(this.lbSubtitlesLanguages);
            this.Controls.Add(this.txtLanguage);
            this.Controls.Add(this.lbSubtitlesUrl);
            this.Controls.Add(this.lbSubtitlesHeader);
            this.Controls.Add(this.txtURL);
            this.Icon = global::youtube_dl_gui.Properties.Resources.ProgramIcon;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(360, 240);
            this.MinimumSize = new System.Drawing.Size(360, 240);
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
        private System.Windows.Forms.Label lbSubtitlesUrl;
        private System.Windows.Forms.Label lbSubtitlesLanguages;
        private System.Windows.Forms.TextBox txtLanguage;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.Button btnSubtitlesAddLanguages;
        private System.Windows.Forms.Button btnSubtitlesDownload;
        private System.Windows.Forms.Button btnSubtitlesClearLanguages;
        private System.Windows.Forms.Label lbSubtitlesHeader;
        private System.Windows.Forms.CheckBox chkSubtitlesGeneratedSubtitles;
        private System.Windows.Forms.CheckBox chkSubtitlesUploadedSubtitles;
    }
}