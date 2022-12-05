namespace youtube_dl_gui {
    partial class frmArchiveDownloader {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            this.btnDownload = new System.Windows.Forms.Button();
            this.lbArchiveDownloaderDescription = new System.Windows.Forms.Label();
            this.txtArchiveDownloaderHint = new murrty.controls.ExtendedTextBox();
            this.btnExtendedDownload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(186, 80);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(86, 23);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "btnDownload";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // lbArchiveDownloaderDescription
            // 
            this.lbArchiveDownloaderDescription.Location = new System.Drawing.Point(12, 9);
            this.lbArchiveDownloaderDescription.Name = "lbArchiveDownloaderDescription";
            this.lbArchiveDownloaderDescription.Size = new System.Drawing.Size(260, 40);
            this.lbArchiveDownloaderDescription.TabIndex = 2;
            this.lbArchiveDownloaderDescription.Text = "lbArchiveDownloaderDescription";
            this.lbArchiveDownloaderDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtArchiveDownloaderHint
            // 
            this.txtArchiveDownloaderHint.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtArchiveDownloaderHint.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtArchiveDownloaderHint.ButtonFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArchiveDownloaderHint.ButtonImageIndex = -1;
            this.txtArchiveDownloaderHint.ButtonSize = new System.Drawing.Size(75, 21);
            this.txtArchiveDownloaderHint.ButtonText = "";
            this.txtArchiveDownloaderHint.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtArchiveDownloaderHint.Location = new System.Drawing.Point(12, 52);
            this.txtArchiveDownloaderHint.Name = "txtArchiveDownloaderHint";
            this.txtArchiveDownloaderHint.Size = new System.Drawing.Size(260, 22);
            this.txtArchiveDownloaderHint.TabIndex = 0;
            this.txtArchiveDownloaderHint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtArchiveDownloaderHint.TextHint = "txtArchiveDownloaderHint";
            // 
            // btnExtendedDownload
            // 
            this.btnExtendedDownload.Location = new System.Drawing.Point(15, 80);
            this.btnExtendedDownload.Name = "btnExtendedDownload";
            this.btnExtendedDownload.Size = new System.Drawing.Size(165, 23);
            this.btnExtendedDownload.TabIndex = 3;
            this.btnExtendedDownload.Text = "btnExtendedDownload";
            this.btnExtendedDownload.UseVisualStyleBackColor = true;
            this.btnExtendedDownload.Click += new System.EventHandler(this.btnExtendedDownload_Click);
            // 
            // frmArchiveDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 115);
            this.Controls.Add(this.btnExtendedDownload);
            this.Controls.Add(this.lbArchiveDownloaderDescription);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtArchiveDownloaderHint);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = global::youtube_dl_gui.Properties.Resources.ProgramIcon;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 150);
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "frmArchiveDownloader";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "frmArchiveDownloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private murrty.controls.ExtendedTextBox txtArchiveDownloaderHint;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label lbArchiveDownloaderDescription;
        private System.Windows.Forms.Button btnExtendedDownload;
    }
}