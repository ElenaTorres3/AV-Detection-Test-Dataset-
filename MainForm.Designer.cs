namespace AVDetectionTest
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.samplesGroupBox = new System.Windows.Forms.GroupBox();
            this.samplesListBox = new System.Windows.Forms.CheckedListBox();
            this.importGroupBox = new System.Windows.Forms.GroupBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.importButton = new System.Windows.Forms.Button();
            this.scanGroupBox = new System.Windows.Forms.GroupBox();
            this.avNameLabel = new System.Windows.Forms.Label();
            this.avNameTextBox = new System.Windows.Forms.TextBox();
            this.scanButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.reportButton = new System.Windows.Forms.Button();
            this.samplesGroupBox.SuspendLayout();
            this.importGroupBox.SuspendLayout();
            this.scanGroupBox.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // samplesGroupBox
            // 
            this.samplesGroupBox.Controls.Add(this.samplesListBox);
            this.samplesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.samplesGroupBox.Name = "samplesGroupBox";
            this.samplesGroupBox.Size = new System.Drawing.Size(400, 300);
            this.samplesGroupBox.TabIndex = 0;
            this.samplesGroupBox.TabStop = false;
            this.samplesGroupBox.Text = "Malware Samples";
            // 
            // samplesListBox
            // 
            this.samplesListBox.CheckOnClick = true;
            this.samplesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.samplesListBox.FormattingEnabled = true;
            this.samplesListBox.Location = new System.Drawing.Point(3, 19);
            this.samplesListBox.Name = "samplesListBox";
            this.samplesListBox.Size = new System.Drawing.Size(394, 278);
            this.samplesListBox.TabIndex = 0;
            // 
            // importGroupBox
            // 
            this.importGroupBox.Controls.Add(this.categoryLabel);
            this.importGroupBox.Controls.Add(this.categoryTextBox);
            this.importGroupBox.Controls.Add(this.importButton);
            this.importGroupBox.Location = new System.Drawing.Point(418, 12);
            this.importGroupBox.Name = "importGroupBox";
            this.importGroupBox.Size = new System.Drawing.Size(250, 120);
            this.importGroupBox.TabIndex = 1;
            this.importGroupBox.TabStop = false;
            this.importGroupBox.Text = "Import Dataset";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(6, 25);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(58, 15);
            this.categoryLabel.TabIndex = 2;
            this.categoryLabel.Text = "Category:";
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(6, 43);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(238, 23);
            this.categoryTextBox.TabIndex = 1;
            this.categoryTextBox.Text = "Ransomware";
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(6, 75);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(238, 32);
            this.importButton.TabIndex = 0;
            this.importButton.Text = "Import Samples";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // scanGroupBox
            // 
            this.scanGroupBox.Controls.Add(this.avNameLabel);
            this.scanGroupBox.Controls.Add(this.avNameTextBox);
            this.scanGroupBox.Controls.Add(this.scanButton);
            this.scanGroupBox.Location = new System.Drawing.Point(418, 138);
            this.scanGroupBox.Name = "scanGroupBox";
            this.scanGroupBox.Size = new System.Drawing.Size(250, 120);
            this.scanGroupBox.TabIndex = 2;
            this.scanGroupBox.TabStop = false;
            this.scanGroupBox.Text = "Scan Samples";
            // 
            // avNameLabel
            // 
            this.avNameLabel.AutoSize = true;
            this.avNameLabel.Location = new System.Drawing.Point(6, 25);
            this.avNameLabel.Name = "avNameLabel";
            this.avNameLabel.Size = new System.Drawing.Size(102, 15);
            this.avNameLabel.TabIndex = 2;
            this.avNameLabel.Text = "Antivirus Product:";
            // 
            // avNameTextBox
            // 
            this.avNameTextBox.Location = new System.Drawing.Point(6, 43);
            this.avNameTextBox.Name = "avNameTextBox";
            this.avNameTextBox.Size = new System.Drawing.Size(238, 23);
            this.avNameTextBox.TabIndex = 1;
            this.avNameTextBox.Text = "Windows Defender";
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(6, 75);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(238, 32);
            this.scanButton.TabIndex = 0;
            this.scanButton.Text = "Scan Selected Samples";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 328);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(680, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(68, 17);
            this.statusLabel.Text = "Ready to go";
            // 
            // reportButton
            // 
            this.reportButton.Location = new System.Drawing.Point(418, 264);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(250, 32);
            this.reportButton.TabIndex = 4;
            this.reportButton.Text = "Generate HTML Report";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.generateReportButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 350);
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.scanGroupBox);
            this.Controls.Add(this.importGroupBox);
            this.Controls.Add(this.samplesGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "AV Detection Test Dataset";
            this.samplesGroupBox.ResumeLayout(false);
            this.importGroupBox.ResumeLayout(false);
            this.importGroupBox.PerformLayout();
            this.scanGroupBox.ResumeLayout(false);
            this.scanGroupBox.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox samplesGroupBox;
        private System.Windows.Forms.CheckedListBox samplesListBox;
        private System.Windows.Forms.GroupBox importGroupBox;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.GroupBox scanGroupBox;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.TextBox avNameTextBox;
        private System.Windows.Forms.Label avNameLabel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button reportButton;
    }
}
