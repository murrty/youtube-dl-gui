namespace youtube_dl_gui {
    partial class frmBatch {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBatch));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.frmLink = new System.Windows.Forms.Label();
            this.lbDownloadType = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lbArg = new System.Windows.Forms.Label();
            this.listLink = new System.Windows.Forms.ListBox();
            this.listType = new System.Windows.Forms.ListBox();
            this.listArgs = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(256, 20);
            this.textBox1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Video",
            "Audio",
            "Custom (args.txt)",
            "Custom (settings)",
            "Custom              ->"});
            this.comboBox1.Location = new System.Drawing.Point(278, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // frmLink
            // 
            this.frmLink.AutoSize = true;
            this.frmLink.Location = new System.Drawing.Point(9, 9);
            this.frmLink.Name = "frmLink";
            this.frmLink.Size = new System.Drawing.Size(74, 13);
            this.frmLink.TabIndex = 2;
            this.frmLink.Text = "Download link";
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
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(409, 25);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(154, 20);
            this.textBox2.TabIndex = 4;
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
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(569, 23);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(569, 70);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 37);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Remove selected";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(569, 253);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // frmBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(648, 282);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listArgs);
            this.Controls.Add(this.listType);
            this.Controls.Add(this.listLink);
            this.Controls.Add(this.lbArg);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lbDownloadType);
            this.Controls.Add(this.frmLink);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
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

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label frmLink;
        private System.Windows.Forms.Label lbDownloadType;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lbArg;
        private System.Windows.Forms.ListBox listLink;
        private System.Windows.Forms.ListBox listType;
        private System.Windows.Forms.ListBox listArgs;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnStart;
    }
}