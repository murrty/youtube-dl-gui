namespace youtube_dl_gui {
    partial class frmDownloadLanguage {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            this.lvAvailableLanguages = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chHash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnDownloadSelected = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvAvailableLanguages
            // 
            this.lvAvailableLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAvailableLanguages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chHash});
            this.lvAvailableLanguages.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvAvailableLanguages.FullRowSelect = true;
            this.lvAvailableLanguages.HideSelection = false;
            this.lvAvailableLanguages.Location = new System.Drawing.Point(12, 12);
            this.lvAvailableLanguages.MultiSelect = false;
            this.lvAvailableLanguages.Name = "lvAvailableLanguages";
            this.lvAvailableLanguages.ShowItemToolTips = true;
            this.lvAvailableLanguages.Size = new System.Drawing.Size(308, 230);
            this.lvAvailableLanguages.TabIndex = 0;
            this.lvAvailableLanguages.TileSize = new System.Drawing.Size(284, 40);
            this.lvAvailableLanguages.UseCompatibleStateImageBehavior = false;
            this.lvAvailableLanguages.View = System.Windows.Forms.View.Tile;
            this.lvAvailableLanguages.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // chName
            // 
            this.chName.Text = "Language name";
            // 
            // chHash
            // 
            this.chHash.Text = "SHA1";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(246, 258);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "btnGenericOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnDownloadSelected
            // 
            this.btnDownloadSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDownloadSelected.Enabled = false;
            this.btnDownloadSelected.Location = new System.Drawing.Point(12, 258);
            this.btnDownloadSelected.Name = "btnDownloadSelected";
            this.btnDownloadSelected.Size = new System.Drawing.Size(75, 23);
            this.btnDownloadSelected.TabIndex = 2;
            this.btnDownloadSelected.Text = "btnDownloadLanguage";
            this.btnDownloadSelected.UseVisualStyleBackColor = true;
            this.btnDownloadSelected.Click += new System.EventHandler(this.btnDownloadSelected_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(165, 258);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "btnGenericCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmDownloadLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 295);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDownloadSelected);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lvAvailableLanguages);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = global::youtube_dl_gui.Properties.Resources.youtube_dl_gui;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 330);
            this.Name = "frmDownloadLanguage";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "frmDownloadLanguage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvAvailableLanguages;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chHash;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnDownloadSelected;
        private System.Windows.Forms.Button btnCancel;
    }
}