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
            this.lbSubtitleFormats = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(35, 57);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(282, 20);
            this.txtURL.TabIndex = 2;
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
            // lbSubtitlesUrl
            // 
            this.lbSubtitlesUrl.AutoSize = true;
            this.lbSubtitlesUrl.Location = new System.Drawing.Point(28, 41);
            this.lbSubtitlesUrl.Name = "lbSubtitlesUrl";
            this.lbSubtitlesUrl.Size = new System.Drawing.Size(68, 13);
            this.lbSubtitlesUrl.TabIndex = 1;
            this.lbSubtitlesUrl.Text = "lbSubtitlesUrl";
            // 
            // lbSubtitlesLanguages
            // 
            this.lbSubtitlesLanguages.AutoSize = true;
            this.lbSubtitlesLanguages.Location = new System.Drawing.Point(28, 84);
            this.lbSubtitlesLanguages.Name = "lbSubtitlesLanguages";
            this.lbSubtitlesLanguages.Size = new System.Drawing.Size(68, 13);
            this.lbSubtitlesLanguages.TabIndex = 3;
            this.lbSubtitlesLanguages.Text = "lbLanguages";
            // 
            // txtLanguage
            // 
            this.txtLanguage.Location = new System.Drawing.Point(35, 100);
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
            this.cbLanguage.Location = new System.Drawing.Point(178, 100);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(75, 21);
            this.cbLanguage.TabIndex = 5;
            // 
            // btnSubtitlesAddLanguages
            // 
            this.btnSubtitlesAddLanguages.Location = new System.Drawing.Point(259, 99);
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
            this.btnSubtitlesClearLanguages.Location = new System.Drawing.Point(255, 127);
            this.btnSubtitlesClearLanguages.Name = "btnSubtitlesClearLanguages";
            this.btnSubtitlesClearLanguages.Size = new System.Drawing.Size(62, 23);
            this.btnSubtitlesClearLanguages.TabIndex = 7;
            this.btnSubtitlesClearLanguages.Text = "btnSubtitlesClear";
            this.btnSubtitlesClearLanguages.UseVisualStyleBackColor = true;
            this.btnSubtitlesClearLanguages.Click += new System.EventHandler(this.btnSubtitlesClearLanguages_Click);
            // 
            // lbSubtitleFormats
            // 
            this.lbSubtitleFormats.AutoSize = true;
            this.lbSubtitleFormats.Location = new System.Drawing.Point(28, 132);
            this.lbSubtitleFormats.Name = "lbSubtitleFormats";
            this.lbSubtitleFormats.Size = new System.Drawing.Size(87, 13);
            this.lbSubtitleFormats.TabIndex = 9;
            this.lbSubtitleFormats.Text = "lbSubtitleFormats";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(121, 129);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(101, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // frmSubtitles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(344, 201);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbSubtitleFormats);
            this.Controls.Add(this.btnSubtitlesClearLanguages);
            this.Controls.Add(this.btnSubtitlesDownload);
            this.Controls.Add(this.btnSubtitlesAddLanguages);
            this.Controls.Add(this.cbLanguage);
            this.Controls.Add(this.lbSubtitlesLanguages);
            this.Controls.Add(this.txtLanguage);
            this.Controls.Add(this.lbSubtitlesUrl);
            this.Controls.Add(this.lbSubtitlesHeader);
            this.Controls.Add(this.txtURL);
            this.Icon = Properties.Resources.youtube_dl_gui;
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
        private System.Windows.Forms.Label lbSubtitlesHeader;
        private System.Windows.Forms.Label lbSubtitlesUrl;
        private System.Windows.Forms.Label lbSubtitlesLanguages;
        private System.Windows.Forms.TextBox txtLanguage;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.Button btnSubtitlesAddLanguages;
        private System.Windows.Forms.Button btnSubtitlesDownload;
        private System.Windows.Forms.Button btnSubtitlesClearLanguages;
        private System.Windows.Forms.Label lbSubtitleFormats;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}