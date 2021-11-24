namespace youtube_dl_gui.Forms {
    partial class frmBatchConverter {
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
            this.sbBatchDownloader = new System.Windows.Forms.StatusBar();
            this.lvBatchConvertQueue = new youtube_dl_gui.Controls.VistaListView();
            this.clInput = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clOutput = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clArgs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBatchConvertStartStopExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sbBatchDownloader
            // 
            this.sbBatchDownloader.Location = new System.Drawing.Point(0, 281);
            this.sbBatchDownloader.Name = "sbBatchDownloader";
            this.sbBatchDownloader.Size = new System.Drawing.Size(652, 22);
            this.sbBatchDownloader.SizingGrip = false;
            this.sbBatchDownloader.TabIndex = 17;
            this.sbBatchDownloader.Text = "sbBatchConverter";
            // 
            // lvBatchConvertQueue
            // 
            this.lvBatchConvertQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBatchConvertQueue.BackColor = System.Drawing.SystemColors.Window;
            this.lvBatchConvertQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clInput,
            this.clOutput,
            this.clArgs});
            this.lvBatchConvertQueue.EnableVistaView = true;
            this.lvBatchConvertQueue.FullRowSelect = true;
            this.lvBatchConvertQueue.Location = new System.Drawing.Point(12, 51);
            this.lvBatchConvertQueue.Name = "lvBatchConvertQueue";
            this.lvBatchConvertQueue.Size = new System.Drawing.Size(547, 224);
            this.lvBatchConvertQueue.TabIndex = 18;
            this.lvBatchConvertQueue.UseCompatibleStateImageBehavior = false;
            this.lvBatchConvertQueue.View = System.Windows.Forms.View.Details;
            // 
            // clInput
            // 
            this.clInput.Text = "Input";
            this.clInput.Width = 191;
            // 
            // clOutput
            // 
            this.clOutput.Text = "Output";
            this.clOutput.Width = 197;
            // 
            // clArgs
            // 
            this.clArgs.Text = "Args";
            this.clArgs.Width = 150;
            // 
            // btnBatchConvertStartStopExit
            // 
            this.btnBatchConvertStartStopExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchConvertStartStopExit.Enabled = false;
            this.btnBatchConvertStartStopExit.Location = new System.Drawing.Point(565, 252);
            this.btnBatchConvertStartStopExit.Name = "btnBatchConvertStartStopExit";
            this.btnBatchConvertStartStopExit.Size = new System.Drawing.Size(75, 23);
            this.btnBatchConvertStartStopExit.TabIndex = 19;
            this.btnBatchConvertStartStopExit.Text = "btnBatchDownloadStart";
            this.btnBatchConvertStartStopExit.UseVisualStyleBackColor = true;
            // 
            // frmBatchConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 303);
            this.Controls.Add(this.lvBatchConvertQueue);
            this.Controls.Add(this.btnBatchConvertStartStopExit);
            this.Controls.Add(this.sbBatchDownloader);
            this.MinimumSize = new System.Drawing.Size(670, 340);
            this.Name = "frmBatchConverter";
            this.Text = "frmBatchConverter";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusBar sbBatchDownloader;
        private youtube_dl_gui.Controls.VistaListView lvBatchConvertQueue;
        private System.Windows.Forms.ColumnHeader clInput;
        private System.Windows.Forms.ColumnHeader clOutput;
        private System.Windows.Forms.ColumnHeader clArgs;
        private System.Windows.Forms.Button btnBatchConvertStartStopExit;
    }
}