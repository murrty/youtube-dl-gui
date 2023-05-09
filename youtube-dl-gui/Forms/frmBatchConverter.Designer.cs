namespace youtube_dl_gui {
    partial class frmBatchConverter {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            this.sbBatchConverter = new System.Windows.Forms.StatusBar();
            this.btnBatchConverterStartStopExit = new System.Windows.Forms.Button();
            this.lbBatchConverterInput = new System.Windows.Forms.Label();
            this.lbBatchConverterOutput = new System.Windows.Forms.Label();
            this.btnBatchConverterRemoveSelected = new System.Windows.Forms.Button();
            this.btnBatchConverterAdd = new System.Windows.Forms.Button();
            this.scConversionFiles = new System.Windows.Forms.SplitContainer();
            this.txtBatchConverterInputFile = new murrty.controls.ExtendedTextBox();
            this.txtBatchConverterOutputFile = new murrty.controls.ExtendedTextBox();
            this.sbBatchConversionLoadArgs = new murrty.controls.SplitButton();
            this.txtBatchConverterCustomConversionArguments = new murrty.controls.ExtendedTextBox();
            this.lvBatchConvertQueue = new murrty.controls.ExtendedListView();
            this.chInput = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOutput = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chArguments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.scConversionFiles)).BeginInit();
            this.scConversionFiles.Panel1.SuspendLayout();
            this.scConversionFiles.Panel2.SuspendLayout();
            this.scConversionFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbBatchConverter
            // 
            this.sbBatchConverter.Location = new System.Drawing.Point(0, 283);
            this.sbBatchConverter.Name = "sbBatchConverter";
            this.sbBatchConverter.Size = new System.Drawing.Size(654, 22);
            this.sbBatchConverter.TabIndex = 17;
            this.sbBatchConverter.Text = "sbBatchConverter";
            // 
            // btnBatchConverterStartStopExit
            // 
            this.btnBatchConverterStartStopExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchConverterStartStopExit.Enabled = false;
            this.btnBatchConverterStartStopExit.Location = new System.Drawing.Point(536, 254);
            this.btnBatchConverterStartStopExit.Name = "btnBatchConverterStartStopExit";
            this.btnBatchConverterStartStopExit.Size = new System.Drawing.Size(106, 23);
            this.btnBatchConverterStartStopExit.TabIndex = 19;
            this.btnBatchConverterStartStopExit.Text = "btnBatchConverterStartStopExit";
            this.btnBatchConverterStartStopExit.UseVisualStyleBackColor = true;
            this.btnBatchConverterStartStopExit.Click += new System.EventHandler(this.btnBatchConverterStartStopExit_Click);
            // 
            // lbBatchConverterInput
            // 
            this.lbBatchConverterInput.AutoSize = true;
            this.lbBatchConverterInput.Location = new System.Drawing.Point(3, 3);
            this.lbBatchConverterInput.Name = "lbBatchConverterInput";
            this.lbBatchConverterInput.Size = new System.Drawing.Size(113, 13);
            this.lbBatchConverterInput.TabIndex = 20;
            this.lbBatchConverterInput.Text = "lbBatchConverterInput";
            // 
            // lbBatchConverterOutput
            // 
            this.lbBatchConverterOutput.AutoSize = true;
            this.lbBatchConverterOutput.Location = new System.Drawing.Point(2, 2);
            this.lbBatchConverterOutput.Name = "lbBatchConverterOutput";
            this.lbBatchConverterOutput.Size = new System.Drawing.Size(121, 13);
            this.lbBatchConverterOutput.TabIndex = 22;
            this.lbBatchConverterOutput.Text = "lbBatchConverterOutput";
            // 
            // btnBatchConverterRemoveSelected
            // 
            this.btnBatchConverterRemoveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchConverterRemoveSelected.Enabled = false;
            this.btnBatchConverterRemoveSelected.Location = new System.Drawing.Point(536, 53);
            this.btnBatchConverterRemoveSelected.Name = "btnBatchConverterRemoveSelected";
            this.btnBatchConverterRemoveSelected.Size = new System.Drawing.Size(106, 37);
            this.btnBatchConverterRemoveSelected.TabIndex = 25;
            this.btnBatchConverterRemoveSelected.Text = "GenericRemoveSelected";
            this.btnBatchConverterRemoveSelected.UseVisualStyleBackColor = true;
            this.btnBatchConverterRemoveSelected.Click += new System.EventHandler(this.btnBatchConverterRemoveSelected_Click);
            // 
            // btnBatchConverterAdd
            // 
            this.btnBatchConverterAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchConverterAdd.Enabled = false;
            this.btnBatchConverterAdd.Location = new System.Drawing.Point(536, 24);
            this.btnBatchConverterAdd.Name = "btnBatchConverterAdd";
            this.btnBatchConverterAdd.Size = new System.Drawing.Size(106, 23);
            this.btnBatchConverterAdd.TabIndex = 24;
            this.btnBatchConverterAdd.Text = "GenericAdd";
            this.btnBatchConverterAdd.UseVisualStyleBackColor = true;
            this.btnBatchConverterAdd.Click += new System.EventHandler(this.btnBatchConverterAdd_Click);
            // 
            // scConversionFiles
            // 
            this.scConversionFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scConversionFiles.Location = new System.Drawing.Point(10, 7);
            this.scConversionFiles.Name = "scConversionFiles";
            // 
            // scConversionFiles.Panel1
            // 
            this.scConversionFiles.Panel1.Controls.Add(this.txtBatchConverterInputFile);
            this.scConversionFiles.Panel1.Controls.Add(this.lbBatchConverterInput);
            this.scConversionFiles.Panel1MinSize = 75;
            // 
            // scConversionFiles.Panel2
            // 
            this.scConversionFiles.Panel2.Controls.Add(this.txtBatchConverterOutputFile);
            this.scConversionFiles.Panel2.Controls.Add(this.lbBatchConverterOutput);
            this.scConversionFiles.Panel2MinSize = 75;
            this.scConversionFiles.Size = new System.Drawing.Size(522, 42);
            this.scConversionFiles.SplitterDistance = 261;
            this.scConversionFiles.TabIndex = 27;
            // 
            // txtBatchConverterInputFile
            // 
            this.txtBatchConverterInputFile.AllowDrop = true;
            this.txtBatchConverterInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatchConverterInputFile.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtBatchConverterInputFile.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtBatchConverterInputFile.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchConverterInputFile.ButtonImageIndex = -1;
            this.txtBatchConverterInputFile.ButtonSize = new System.Drawing.Size(24, 19);
            this.txtBatchConverterInputFile.ButtonText = "...";
            this.txtBatchConverterInputFile.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtBatchConverterInputFile.Location = new System.Drawing.Point(5, 19);
            this.txtBatchConverterInputFile.Name = "txtBatchConverterInputFile";
            this.txtBatchConverterInputFile.ShowButton = true;
            this.txtBatchConverterInputFile.Size = new System.Drawing.Size(251, 20);
            this.txtBatchConverterInputFile.TabIndex = 21;
            this.txtBatchConverterInputFile.TextHint = "txtBatchConverterInputFile";
            this.txtBatchConverterInputFile.ButtonClick += new System.EventHandler(this.txtBatchDownloadLink_ButtonClick);
            this.txtBatchConverterInputFile.TextChanged += new System.EventHandler(this.txtBatchConverterInputFile_TextChanged);
            // 
            // txtBatchConverterOutputFile
            // 
            this.txtBatchConverterOutputFile.AllowDrop = true;
            this.txtBatchConverterOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatchConverterOutputFile.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtBatchConverterOutputFile.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtBatchConverterOutputFile.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchConverterOutputFile.ButtonImageIndex = -1;
            this.txtBatchConverterOutputFile.ButtonSize = new System.Drawing.Size(24, 19);
            this.txtBatchConverterOutputFile.ButtonText = "...";
            this.txtBatchConverterOutputFile.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtBatchConverterOutputFile.Location = new System.Drawing.Point(5, 19);
            this.txtBatchConverterOutputFile.Name = "txtBatchConverterOutputFile";
            this.txtBatchConverterOutputFile.ShowButton = true;
            this.txtBatchConverterOutputFile.Size = new System.Drawing.Size(247, 20);
            this.txtBatchConverterOutputFile.TabIndex = 23;
            this.txtBatchConverterOutputFile.TextHint = "txtBatchConverterOutputFile";
            this.txtBatchConverterOutputFile.ButtonClick += new System.EventHandler(this.txtBatchConverterOutput_ButtonClick);
            this.txtBatchConverterOutputFile.TextChanged += new System.EventHandler(this.txtBatchConverterOutputFile_TextChanged);
            // 
            // sbBatchConversionLoadArgs
            // 
            this.sbBatchConversionLoadArgs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbBatchConversionLoadArgs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sbBatchConversionLoadArgs.Location = new System.Drawing.Point(536, 96);
            this.sbBatchConversionLoadArgs.Name = "sbBatchConversionLoadArgs";
            this.sbBatchConversionLoadArgs.Size = new System.Drawing.Size(106, 23);
            this.sbBatchConversionLoadArgs.TabIndex = 28;
            this.sbBatchConversionLoadArgs.Text = "sbBatchDownloadLoadArgs";
            this.sbBatchConversionLoadArgs.UseVisualStyleBackColor = true;
            this.sbBatchConversionLoadArgs.Visible = false;
            // 
            // txtBatchConverterCustomConversionArguments
            // 
            this.txtBatchConverterCustomConversionArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatchConverterCustomConversionArguments.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtBatchConverterCustomConversionArguments.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtBatchConverterCustomConversionArguments.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchConverterCustomConversionArguments.ButtonImageIndex = -1;
            this.txtBatchConverterCustomConversionArguments.ButtonSize = new System.Drawing.Size(75, 19);
            this.txtBatchConverterCustomConversionArguments.ButtonText = "";
            this.txtBatchConverterCustomConversionArguments.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtBatchConverterCustomConversionArguments.Location = new System.Drawing.Point(15, 52);
            this.txtBatchConverterCustomConversionArguments.Name = "txtBatchConverterCustomConversionArguments";
            this.txtBatchConverterCustomConversionArguments.Size = new System.Drawing.Size(515, 20);
            this.txtBatchConverterCustomConversionArguments.TabIndex = 26;
            this.txtBatchConverterCustomConversionArguments.TextHint = "txtBatchConverterCustomConversionArguments";
            // 
            // lvBatchConvertQueue
            // 
            this.lvBatchConvertQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBatchConvertQueue.BackColor = System.Drawing.SystemColors.Window;
            this.lvBatchConvertQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chInput,
            this.chOutput,
            this.chArguments});
            this.lvBatchConvertQueue.FullRowSelect = true;
            this.lvBatchConvertQueue.HideSelection = false;
            this.lvBatchConvertQueue.Location = new System.Drawing.Point(12, 78);
            this.lvBatchConvertQueue.Name = "lvBatchConvertQueue";
            this.lvBatchConvertQueue.Size = new System.Drawing.Size(518, 199);
            this.lvBatchConvertQueue.TabIndex = 18;
            this.lvBatchConvertQueue.UseCompatibleStateImageBehavior = false;
            this.lvBatchConvertQueue.View = System.Windows.Forms.View.Details;
            this.lvBatchConvertQueue.SelectedIndexChanged += new System.EventHandler(this.lvBatchConvertQueue_SelectedIndexChanged);
            this.lvBatchConvertQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvBatchConvertQueue_KeyDown);
            this.lvBatchConvertQueue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvBatchConvertQueue_KeyUp);
            // 
            // chInput
            // 
            this.chInput.Text = "chInput";
            this.chInput.Width = 246;
            // 
            // chOutput
            // 
            this.chOutput.Text = "chOutput";
            this.chOutput.Width = 194;
            // 
            // chArguments
            // 
            this.chArguments.Text = "chArguments";
            this.chArguments.Width = 67;
            // 
            // frmBatchConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 305);
            this.Controls.Add(this.sbBatchConversionLoadArgs);
            this.Controls.Add(this.txtBatchConverterCustomConversionArguments);
            this.Controls.Add(this.btnBatchConverterRemoveSelected);
            this.Controls.Add(this.btnBatchConverterAdd);
            this.Controls.Add(this.lvBatchConvertQueue);
            this.Controls.Add(this.btnBatchConverterStartStopExit);
            this.Controls.Add(this.sbBatchConverter);
            this.Controls.Add(this.scConversionFiles);
            this.Icon = global::youtube_dl_gui.Properties.Resources.ProgramIcon;
            this.MinimumSize = new System.Drawing.Size(670, 340);
            this.Name = "frmBatchConverter";
            this.Text = "frmBatchConverter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBatchConverter_FormClosing);
            this.scConversionFiles.Panel1.ResumeLayout(false);
            this.scConversionFiles.Panel1.PerformLayout();
            this.scConversionFiles.Panel2.ResumeLayout(false);
            this.scConversionFiles.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scConversionFiles)).EndInit();
            this.scConversionFiles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusBar sbBatchConverter;
        private murrty.controls.ExtendedListView lvBatchConvertQueue;
        private System.Windows.Forms.ColumnHeader chInput;
        private System.Windows.Forms.ColumnHeader chOutput;
        private System.Windows.Forms.Button btnBatchConverterStartStopExit;
        private murrty.controls.ExtendedTextBox txtBatchConverterInputFile;
        private System.Windows.Forms.Label lbBatchConverterInput;
        private murrty.controls.ExtendedTextBox txtBatchConverterOutputFile;
        private System.Windows.Forms.Label lbBatchConverterOutput;
        private System.Windows.Forms.Button btnBatchConverterRemoveSelected;
        private System.Windows.Forms.Button btnBatchConverterAdd;
        private murrty.controls.ExtendedTextBox txtBatchConverterCustomConversionArguments;
        private System.Windows.Forms.ColumnHeader chArguments;
        private System.Windows.Forms.SplitContainer scConversionFiles;
        private murrty.controls.SplitButton sbBatchConversionLoadArgs;
    }
}