namespace youtube_dl_gui {
    partial class frmBatchDownloader {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBatchDownloader));
            this.txtBatchDownloadLink = new System.Windows.Forms.TextBox();
            this.cbBatchDownloadType = new System.Windows.Forms.ComboBox();
            this.lbBatchDownloadLink = new System.Windows.Forms.Label();
            this.lbDownloadType = new System.Windows.Forms.Label();
            this.txtBatchDownloadVideoSpecificArgument = new System.Windows.Forms.TextBox();
            this.lbArg = new System.Windows.Forms.Label();
            this.listLink = new System.Windows.Forms.ListBox();
            this.listType = new System.Windows.Forms.ListBox();
            this.listArgs = new System.Windows.Forms.ListBox();
            this.btnBatchDownloadAdd = new System.Windows.Forms.Button();
            this.btnBatchDownloadRemoveSelected = new System.Windows.Forms.Button();
            this.btnBatchDownloadStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBatchDownloadLink
            // 
            this.txtBatchDownloadLink.Location = new System.Drawing.Point(12, 25);
            this.txtBatchDownloadLink.Name = "txtBatchDownloadLink";
            this.txtBatchDownloadLink.Size = new System.Drawing.Size(256, 20);
            this.txtBatchDownloadLink.TabIndex = 0;
            // 
            // cbBatchDownloadType
            // 
            this.cbBatchDownloadType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBatchDownloadType.FormattingEnabled = true;
            this.cbBatchDownloadType.Items.AddRange(new object[] {
            "Video",
            "Audio",
            "Custom (args.txt)",
            "Custom (settings)",
            "Custom              ->"});
            this.cbBatchDownloadType.Location = new System.Drawing.Point(278, 25);
            this.cbBatchDownloadType.Name = "cbBatchDownloadType";
            this.cbBatchDownloadType.Size = new System.Drawing.Size(121, 21);
            this.cbBatchDownloadType.TabIndex = 1;
            // 
            // lbBatchDownloadLink
            // 
            this.lbBatchDownloadLink.AutoSize = true;
            this.lbBatchDownloadLink.Location = new System.Drawing.Point(9, 9);
            this.lbBatchDownloadLink.Name = "lbBatchDownloadLink";
            this.lbBatchDownloadLink.Size = new System.Drawing.Size(74, 13);
            this.lbBatchDownloadLink.TabIndex = 2;
            this.lbBatchDownloadLink.Text = "Download link";
            // 
            // lbDownloadType
            // 
            this.lbDownloadType.AutoSize = true;
            this.lbDownloadType.Location = new System.Drawing.Point(275, 9);
            this.lbDownloadType.Name = "lbDownloadType";
            this.lbDownloadType.Size = new System.Drawing.Size(78, 13);
            this.lbDownloadType.TabIndex = 3;
            this.lbDownloadType.Text = "Download type";
            // 
            // txtBatchDownloadVideoSpecificArgument
            // 
            this.txtBatchDownloadVideoSpecificArgument.Location = new System.Drawing.Point(409, 25);
            this.txtBatchDownloadVideoSpecificArgument.Name = "txtBatchDownloadVideoSpecificArgument";
            this.txtBatchDownloadVideoSpecificArgument.Size = new System.Drawing.Size(154, 20);
            this.txtBatchDownloadVideoSpecificArgument.TabIndex = 4;
            // 
            // lbArg
            // 
            this.lbArg.AutoSize = true;
            this.lbArg.Location = new System.Drawing.Point(406, 9);
            this.lbArg.Name = "lbArg";
            this.lbArg.Size = new System.Drawing.Size(120, 13);
            this.lbArg.TabIndex = 5;
            this.lbArg.Text = "Video-specific argument";
            // 
            // listLink
            // 
            this.listLink.FormattingEnabled = true;
            this.listLink.Location = new System.Drawing.Point(12, 51);
            this.listLink.Name = "listLink";
            this.listLink.Size = new System.Drawing.Size(256, 225);
            this.listLink.TabIndex = 6;
            this.listLink.SelectedIndexChanged += new System.EventHandler(this.listLink_SelectedIndexChanged);
            // 
            // listType
            // 
            this.listType.Enabled = false;
            this.listType.FormattingEnabled = true;
            this.listType.Location = new System.Drawing.Point(278, 51);
            this.listType.Name = "listType";
            this.listType.Size = new System.Drawing.Size(121, 225);
            this.listType.TabIndex = 7;
            // 
            // listArgs
            // 
            this.listArgs.Enabled = false;
            this.listArgs.FormattingEnabled = true;
            this.listArgs.Location = new System.Drawing.Point(409, 51);
            this.listArgs.Name = "listArgs";
            this.listArgs.Size = new System.Drawing.Size(154, 225);
            this.listArgs.TabIndex = 8;
            // 
            // btnBatchDownloadAdd
            // 
            this.btnBatchDownloadAdd.Location = new System.Drawing.Point(569, 23);
            this.btnBatchDownloadAdd.Name = "btnBatchDownloadAdd";
            this.btnBatchDownloadAdd.Size = new System.Drawing.Size(75, 23);
            this.btnBatchDownloadAdd.TabIndex = 9;
            this.btnBatchDownloadAdd.Text = "Add";
            this.btnBatchDownloadAdd.UseVisualStyleBackColor = true;
            this.btnBatchDownloadAdd.Click += new System.EventHandler(this.btnBatchDownloadAdd_Click);
            // 
            // btnBatchDownloadRemoveSelected
            // 
            this.btnBatchDownloadRemoveSelected.Location = new System.Drawing.Point(569, 70);
            this.btnBatchDownloadRemoveSelected.Name = "btnBatchDownloadRemoveSelected";
            this.btnBatchDownloadRemoveSelected.Size = new System.Drawing.Size(75, 37);
            this.btnBatchDownloadRemoveSelected.TabIndex = 10;
            this.btnBatchDownloadRemoveSelected.Text = "Remove selected";
            this.btnBatchDownloadRemoveSelected.UseVisualStyleBackColor = true;
            this.btnBatchDownloadRemoveSelected.Click += new System.EventHandler(this.btnBatchDownloadRemoveSelected_Click);
            // 
            // btnBatchDownloadStart
            // 
            this.btnBatchDownloadStart.Location = new System.Drawing.Point(569, 253);
            this.btnBatchDownloadStart.Name = "btnBatchDownloadStart";
            this.btnBatchDownloadStart.Size = new System.Drawing.Size(75, 23);
            this.btnBatchDownloadStart.TabIndex = 11;
            this.btnBatchDownloadStart.Text = "Start";
            this.btnBatchDownloadStart.UseVisualStyleBackColor = true;
            this.btnBatchDownloadStart.Click += new System.EventHandler(this.btnBatchDownloadStart_Click);
            // 
            // frmBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(648, 282);
            this.Controls.Add(this.btnBatchDownloadStart);
            this.Controls.Add(this.btnBatchDownloadRemoveSelected);
            this.Controls.Add(this.btnBatchDownloadAdd);
            this.Controls.Add(this.listArgs);
            this.Controls.Add(this.listType);
            this.Controls.Add(this.listLink);
            this.Controls.Add(this.lbArg);
            this.Controls.Add(this.txtBatchDownloadVideoSpecificArgument);
            this.Controls.Add(this.lbDownloadType);
            this.Controls.Add(this.lbBatchDownloadLink);
            this.Controls.Add(this.cbBatchDownloadType);
            this.Controls.Add(this.txtBatchDownloadLink);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(656, 312);
            this.MinimumSize = new System.Drawing.Size(656, 312);
            this.Name = "frmBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batch downloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBatchDownloadLink;
        private System.Windows.Forms.ComboBox cbBatchDownloadType;
        private System.Windows.Forms.Label lbBatchDownloadLink;
        private System.Windows.Forms.Label lbDownloadType;
        private System.Windows.Forms.TextBox txtBatchDownloadVideoSpecificArgument;
        private System.Windows.Forms.Label lbArg;
        private System.Windows.Forms.ListBox listLink;
        private System.Windows.Forms.ListBox listType;
        private System.Windows.Forms.ListBox listArgs;
        private System.Windows.Forms.Button btnBatchDownloadAdd;
        private System.Windows.Forms.Button btnBatchDownloadRemoveSelected;
        private System.Windows.Forms.Button btnBatchDownloadStart;
    }
}