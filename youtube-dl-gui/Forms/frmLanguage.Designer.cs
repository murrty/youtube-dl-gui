namespace youtube_dl_gui {
    partial class frmLanguage {
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
            this.cbLanguages = new System.Windows.Forms.ComboBox();
            this.btnLanguageRefresh = new System.Windows.Forms.Button();
            this.btnLanguageSave = new System.Windows.Forms.Button();
            this.btnLanguageCancel = new System.Windows.Forms.Button();
            this.lbCurrentLanguageShort = new System.Windows.Forms.Label();
            this.ttLanguage = new System.Windows.Forms.ToolTip(this.components);
            this.btnLanguageDownload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbLanguages
            // 
            this.cbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguages.FormattingEnabled = true;
            this.cbLanguages.Items.AddRange(new object[] {
            "English (Internal)"});
            this.cbLanguages.Location = new System.Drawing.Point(12, 29);
            this.cbLanguages.Name = "cbLanguages";
            this.cbLanguages.Size = new System.Drawing.Size(187, 21);
            this.cbLanguages.TabIndex = 0;
            // 
            // btnLanguageRefresh
            // 
            this.btnLanguageRefresh.Location = new System.Drawing.Point(205, 12);
            this.btnLanguageRefresh.Name = "btnLanguageRefresh";
            this.btnLanguageRefresh.Size = new System.Drawing.Size(75, 24);
            this.btnLanguageRefresh.TabIndex = 1;
            this.btnLanguageRefresh.Text = "btnLanguageRefresh";
            this.btnLanguageRefresh.UseVisualStyleBackColor = true;
            this.btnLanguageRefresh.Click += new System.EventHandler(this.btnLanguageRefresh_Click);
            // 
            // btnLanguageSave
            // 
            this.btnLanguageSave.Location = new System.Drawing.Point(205, 77);
            this.btnLanguageSave.Name = "btnLanguageSave";
            this.btnLanguageSave.Size = new System.Drawing.Size(75, 24);
            this.btnLanguageSave.TabIndex = 3;
            this.btnLanguageSave.Text = "btnLanguageSave";
            this.btnLanguageSave.UseVisualStyleBackColor = true;
            this.btnLanguageSave.Click += new System.EventHandler(this.btnLanguageSave_Click);
            // 
            // btnLanguageCancel
            // 
            this.btnLanguageCancel.Location = new System.Drawing.Point(124, 77);
            this.btnLanguageCancel.Name = "btnLanguageCancel";
            this.btnLanguageCancel.Size = new System.Drawing.Size(75, 24);
            this.btnLanguageCancel.TabIndex = 2;
            this.btnLanguageCancel.Text = "btnLanguageCancel";
            this.btnLanguageCancel.UseVisualStyleBackColor = true;
            this.btnLanguageCancel.Click += new System.EventHandler(this.btnLanguageCancel_Click);
            // 
            // lbCurrentLanguageShort
            // 
            this.lbCurrentLanguageShort.AutoSize = true;
            this.lbCurrentLanguageShort.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentLanguageShort.Location = new System.Drawing.Point(12, 87);
            this.lbCurrentLanguageShort.Name = "lbCurrentLanguageShort";
            this.lbCurrentLanguageShort.Size = new System.Drawing.Size(135, 13);
            this.lbCurrentLanguageShort.TabIndex = 4;
            this.lbCurrentLanguageShort.Text = "lbCurrentLanguageShort";
            // 
            // btnLanguageDownload
            // 
            this.btnLanguageDownload.Location = new System.Drawing.Point(205, 42);
            this.btnLanguageDownload.Name = "btnLanguageDownload";
            this.btnLanguageDownload.Size = new System.Drawing.Size(75, 23);
            this.btnLanguageDownload.TabIndex = 5;
            this.btnLanguageDownload.Text = "btnLanguageDownload";
            this.btnLanguageDownload.UseVisualStyleBackColor = true;
            this.btnLanguageDownload.Click += new System.EventHandler(this.btnLanguageDownload_Click);
            // 
            // frmLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(292, 113);
            this.Controls.Add(this.btnLanguageDownload);
            this.Controls.Add(this.btnLanguageCancel);
            this.Controls.Add(this.btnLanguageSave);
            this.Controls.Add(this.btnLanguageRefresh);
            this.Controls.Add(this.cbLanguages);
            this.Controls.Add(this.lbCurrentLanguageShort);
            this.Icon = global::youtube_dl_gui.Properties.Resources.ProgramIcon;
            this.MaximizeBox = false;
            this.Name = "frmLanguage";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLanguage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLanguages;
        private System.Windows.Forms.Button btnLanguageRefresh;
        private System.Windows.Forms.Button btnLanguageSave;
        private System.Windows.Forms.Button btnLanguageCancel;
        private System.Windows.Forms.Label lbCurrentLanguageShort;
        private System.Windows.Forms.ToolTip ttLanguage;
        private System.Windows.Forms.Button btnLanguageDownload;
    }
}