namespace youtube_dl_gui_updater {
    partial class frmUpdaterInvalidData {
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
            this.pnMain = new System.Windows.Forms.Panel();
            this.lbUpdaterInvalidData = new System.Windows.Forms.Label();
            this.pnControls = new System.Windows.Forms.Panel();
            this.btnUpdaterInvalidDataDoNotUpdate = new System.Windows.Forms.Button();
            this.btnUpdaterInvalidDataUpdatePreRelease = new System.Windows.Forms.Button();
            this.btnUpdaterInvalidDataUpdateLatest = new System.Windows.Forms.Button();
            this.pnMain.SuspendLayout();
            this.pnControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.BackColor = System.Drawing.SystemColors.Window;
            this.pnMain.Controls.Add(this.lbUpdaterInvalidData);
            this.pnMain.Controls.Add(this.pnControls);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(364, 125);
            this.pnMain.TabIndex = 0;
            // 
            // lbUpdaterInvalidData
            // 
            this.lbUpdaterInvalidData.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUpdaterInvalidData.Location = new System.Drawing.Point(12, 5);
            this.lbUpdaterInvalidData.Name = "lbUpdaterInvalidData";
            this.lbUpdaterInvalidData.Size = new System.Drawing.Size(340, 74);
            this.lbUpdaterInvalidData.TabIndex = 1;
            this.lbUpdaterInvalidData.Text = "lbUpdaterInvalidData";
            this.lbUpdaterInvalidData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnControls
            // 
            this.pnControls.BackColor = System.Drawing.SystemColors.Menu;
            this.pnControls.Controls.Add(this.btnUpdaterInvalidDataDoNotUpdate);
            this.pnControls.Controls.Add(this.btnUpdaterInvalidDataUpdatePreRelease);
            this.pnControls.Controls.Add(this.btnUpdaterInvalidDataUpdateLatest);
            this.pnControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnControls.Location = new System.Drawing.Point(0, 83);
            this.pnControls.Name = "pnControls";
            this.pnControls.Size = new System.Drawing.Size(364, 42);
            this.pnControls.TabIndex = 0;
            // 
            // btnUpdaterInvalidDataDoNotUpdate
            // 
            this.btnUpdaterInvalidDataDoNotUpdate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnUpdaterInvalidDataDoNotUpdate.Location = new System.Drawing.Point(248, 7);
            this.btnUpdaterInvalidDataDoNotUpdate.Name = "btnUpdaterInvalidDataDoNotUpdate";
            this.btnUpdaterInvalidDataDoNotUpdate.Size = new System.Drawing.Size(104, 23);
            this.btnUpdaterInvalidDataDoNotUpdate.TabIndex = 2;
            this.btnUpdaterInvalidDataDoNotUpdate.Text = "btnUpdaterInvalidDataDoNotUpdate";
            this.btnUpdaterInvalidDataDoNotUpdate.UseVisualStyleBackColor = true;
            // 
            // btnUpdaterInvalidDataUpdatePreRelease
            // 
            this.btnUpdaterInvalidDataUpdatePreRelease.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnUpdaterInvalidDataUpdatePreRelease.Location = new System.Drawing.Point(130, 7);
            this.btnUpdaterInvalidDataUpdatePreRelease.Name = "btnUpdaterInvalidDataUpdatePreRelease";
            this.btnUpdaterInvalidDataUpdatePreRelease.Size = new System.Drawing.Size(104, 23);
            this.btnUpdaterInvalidDataUpdatePreRelease.TabIndex = 1;
            this.btnUpdaterInvalidDataUpdatePreRelease.Text = "btnUpdaterInvalidDataUpdatePreRelease";
            this.btnUpdaterInvalidDataUpdatePreRelease.UseVisualStyleBackColor = true;
            // 
            // btnUpdaterInvalidDataUpdateLatest
            // 
            this.btnUpdaterInvalidDataUpdateLatest.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnUpdaterInvalidDataUpdateLatest.Location = new System.Drawing.Point(12, 7);
            this.btnUpdaterInvalidDataUpdateLatest.Name = "btnUpdaterInvalidDataUpdateLatest";
            this.btnUpdaterInvalidDataUpdateLatest.Size = new System.Drawing.Size(104, 23);
            this.btnUpdaterInvalidDataUpdateLatest.TabIndex = 0;
            this.btnUpdaterInvalidDataUpdateLatest.Text = "btnUpdaterInvalidDataUpdateLatest";
            this.btnUpdaterInvalidDataUpdateLatest.UseVisualStyleBackColor = true;
            // 
            // frmUpdaterInvalidData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(364, 125);
            this.Controls.Add(this.pnMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = global::youtube_dl_gui_updater.Properties.Resources.ProgramIcon;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(380, 160);
            this.MinimumSize = new System.Drawing.Size(380, 160);
            this.Name = "frmUpdaterInvalidData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUpdaterInvalidData";
            this.pnMain.ResumeLayout(false);
            this.pnControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Panel pnControls;
        private System.Windows.Forms.Label lbUpdaterInvalidData;
        private System.Windows.Forms.Button btnUpdaterInvalidDataDoNotUpdate;
        private System.Windows.Forms.Button btnUpdaterInvalidDataUpdatePreRelease;
        private System.Windows.Forms.Button btnUpdaterInvalidDataUpdateLatest;
    }
}