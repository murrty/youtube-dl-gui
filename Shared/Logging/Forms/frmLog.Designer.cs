namespace murrty.logging {
    partial class frmLog {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.panelControls = new System.Windows.Forms.Panel();
            this.btnTestLine = new System.Windows.Forms.Button();
            this.lbLines = new System.Windows.Forms.Label();
            this.btnClear = new murrty.controls.ExtendedButton();
            this.btnClose = new murrty.controls.ExtendedButton();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpMainLog = new System.Windows.Forms.TabPage();
            this.rtbLog = new murrty.controls.ExtendedRichTextBox();
            this.tpExceptions = new System.Windows.Forms.TabPage();
            this.lbExceptionDetails = new System.Windows.Forms.Label();
            this.btnRemoveException = new System.Windows.Forms.Button();
            this.tcExceptions = new System.Windows.Forms.TabControl();
            this.cmLog = new System.Windows.Forms.ContextMenu();
            this.mCopyText = new System.Windows.Forms.MenuItem();
            this.vmLogger = new wyDay.Controls.VistaMenu(this.components);
            this.panelControls.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tpMainLog.SuspendLayout();
            this.tpExceptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vmLogger)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.SystemColors.Menu;
            this.panelControls.Controls.Add(this.btnTestLine);
            this.panelControls.Controls.Add(this.lbLines);
            this.panelControls.Controls.Add(this.btnClear);
            this.panelControls.Controls.Add(this.btnClose);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControls.Location = new System.Drawing.Point(0, 453);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(634, 42);
            this.panelControls.TabIndex = 0;
            // 
            // btnTestLine
            // 
            this.btnTestLine.Location = new System.Drawing.Point(466, 9);
            this.btnTestLine.Name = "btnTestLine";
            this.btnTestLine.Size = new System.Drawing.Size(75, 23);
            this.btnTestLine.TabIndex = 3;
            this.btnTestLine.Text = "write line";
            this.btnTestLine.UseVisualStyleBackColor = true;
            this.btnTestLine.Click += new System.EventHandler(this.btnTestLine_Click);
            // 
            // lbLines
            // 
            this.lbLines.AutoSize = true;
            this.lbLines.Location = new System.Drawing.Point(93, 14);
            this.lbLines.Name = "lbLines";
            this.lbLines.Size = new System.Drawing.Size(69, 13);
            this.lbLines.TabIndex = 3;
            this.lbLines.Text = "log count: 0";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 9);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(547, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tcMain
            // 
            this.tcMain.AccessibleDescription = "";
            this.tcMain.Controls.Add(this.tpMainLog);
            this.tcMain.Controls.Add(this.tpExceptions);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(634, 453);
            this.tcMain.TabIndex = 1;
            // 
            // tpMainLog
            // 
            this.tpMainLog.Controls.Add(this.rtbLog);
            this.tpMainLog.Location = new System.Drawing.Point(4, 22);
            this.tpMainLog.Name = "tpMainLog";
            this.tpMainLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpMainLog.Size = new System.Drawing.Size(626, 427);
            this.tpMainLog.TabIndex = 0;
            this.tpMainLog.Text = "main log";
            this.tpMainLog.UseVisualStyleBackColor = true;
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.SystemColors.Control;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLog.Location = new System.Drawing.Point(3, 3);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ShowLineNumbers = true;
            this.rtbLog.Size = new System.Drawing.Size(620, 421);
            this.rtbLog.TabIndex = 1;
            this.rtbLog.Text = "";
            // 
            // tpExceptions
            // 
            this.tpExceptions.Controls.Add(this.lbExceptionDetails);
            this.tpExceptions.Controls.Add(this.btnRemoveException);
            this.tpExceptions.Controls.Add(this.tcExceptions);
            this.tpExceptions.Location = new System.Drawing.Point(4, 22);
            this.tpExceptions.Name = "tpExceptions";
            this.tpExceptions.Padding = new System.Windows.Forms.Padding(3);
            this.tpExceptions.Size = new System.Drawing.Size(626, 427);
            this.tpExceptions.TabIndex = 1;
            this.tpExceptions.Text = "exceptions";
            this.tpExceptions.UseVisualStyleBackColor = true;
            // 
            // lbExceptionDetails
            // 
            this.lbExceptionDetails.AutoSize = true;
            this.lbExceptionDetails.Location = new System.Drawing.Point(8, 9);
            this.lbExceptionDetails.Name = "lbExceptionDetails";
            this.lbExceptionDetails.Size = new System.Drawing.Size(173, 13);
            this.lbExceptionDetails.TabIndex = 2;
            this.lbExceptionDetails.Text = "past exceptions will appear here";
            // 
            // btnRemoveException
            // 
            this.btnRemoveException.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveException.Enabled = false;
            this.btnRemoveException.Location = new System.Drawing.Point(539, 4);
            this.btnRemoveException.Name = "btnRemoveException";
            this.btnRemoveException.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveException.TabIndex = 1;
            this.btnRemoveException.Text = "remove";
            this.btnRemoveException.UseVisualStyleBackColor = true;
            this.btnRemoveException.Click += new System.EventHandler(this.btnRemoveException_Click);
            // 
            // tcExceptions
            // 
            this.tcExceptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcExceptions.Location = new System.Drawing.Point(8, 31);
            this.tcExceptions.Name = "tcExceptions";
            this.tcExceptions.SelectedIndex = 0;
            this.tcExceptions.Size = new System.Drawing.Size(612, 390);
            this.tcExceptions.TabIndex = 0;
            // 
            // cmLog
            // 
            this.cmLog.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mCopyText});
            // 
            // mCopyText
            // 
            this.vmLogger.SetImage(this.mCopyText, global::aphrodite.Properties.Resources.CopyIcon);
            this.mCopyText.Index = 0;
            this.mCopyText.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.mCopyText.Text = "Copy   ";
            this.mCopyText.Click += new System.EventHandler(this.mCopyText_Click);
            // 
            // vmLogger
            // 
            this.vmLogger.ContainerControl = this;
            // 
            // frmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(634, 495);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.panelControls);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(360, 260);
            this.Name = "frmLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "aphrodite log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLog_FormClosing);
            this.Load += new System.EventHandler(this.frmLog_Load);
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.tpMainLog.ResumeLayout(false);
            this.tpExceptions.ResumeLayout(false);
            this.tpExceptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vmLogger)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public murrty.controls.ExtendedRichTextBox rtbLog;
        private System.Windows.Forms.Panel panelControls;
        private murrty.controls.ExtendedButton btnClear;
        private murrty.controls.ExtendedButton btnClose;
        private System.Windows.Forms.Label lbLines;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpMainLog;
        private System.Windows.Forms.TabPage tpExceptions;
        private System.Windows.Forms.Button btnRemoveException;
        private System.Windows.Forms.TabControl tcExceptions;
        private System.Windows.Forms.Label lbExceptionDetails;
        private System.Windows.Forms.ContextMenu cmLog;
        private System.Windows.Forms.MenuItem mCopyText;
        private System.Windows.Forms.Button btnTestLine;
        private wyDay.Controls.VistaMenu vmLogger;
    }
}