#nullable disable
namespace Evently.Forms
{
    partial class CheckInForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.heroSublineLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.eventLabel = new System.Windows.Forms.Label();
            this.eventComboBox = new System.Windows.Forms.ComboBox();
            this.cameraPreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.resultMessageLabel = new System.Windows.Forms.Label();
            this.insideCountLabel = new System.Windows.Forms.Label();
            this.scannerGuidanceLabel = new System.Windows.Forms.Label();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraPreviewPictureBox)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // headerPanel
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.heroSublineLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.headerPanel.Size = new System.Drawing.Size(1280, 64);
            this.headerPanel.TabIndex = 0;
            // titleLabel
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(12, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(167, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Check-In Scanner";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // heroSublineLabel
            this.heroSublineLabel.AutoSize = true;
            this.heroSublineLabel.BackColor = System.Drawing.Color.Transparent;
            this.heroSublineLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.heroSublineLabel.ForeColor = System.Drawing.Color.FromArgb(218, 230, 245);
            this.heroSublineLabel.Location = new System.Drawing.Point(12, 38);
            this.heroSublineLabel.Name = "heroSublineLabel";
            this.heroSublineLabel.Size = new System.Drawing.Size(433, 15);
            this.heroSublineLabel.TabIndex = 1;
            this.heroSublineLabel.Text = "Scan attendee QR codes at entrance and exit for real-time venue tracking.";
            this.heroSublineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // contentPanel
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.cameraPreviewPictureBox);
            this.contentPanel.Controls.Add(this.bottomPanel);
            this.contentPanel.Controls.Add(this.topPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 64);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(12);
            this.contentPanel.Size = new System.Drawing.Size(1280, 656);
            this.contentPanel.TabIndex = 1;
            // topPanel
            this.topPanel.BackColor = System.Drawing.Color.White;
            this.topPanel.Controls.Add(this.eventLabel);
            this.topPanel.Controls.Add(this.eventComboBox);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(12, 12);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1256, 40);
            this.topPanel.TabIndex = 0;
            // eventLabel
            this.eventLabel.AutoSize = true;
            this.eventLabel.Location = new System.Drawing.Point(0, 11);
            this.eventLabel.Name = "eventLabel";
            this.eventLabel.TabIndex = 0;
            this.eventLabel.Text = "Event:";
            // eventComboBox
            this.eventComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.eventComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventComboBox.FormattingEnabled = true;
            this.eventComboBox.Location = new System.Drawing.Point(58, 8);
            this.eventComboBox.Name = "eventComboBox";
            this.eventComboBox.Size = new System.Drawing.Size(1198, 23);
            this.eventComboBox.TabIndex = 1;
            this.eventComboBox.SelectedIndexChanged += new System.EventHandler(this.eventComboBox_SelectedIndexChanged);
            // cameraPreviewPictureBox
            this.cameraPreviewPictureBox.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            this.cameraPreviewPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraPreviewPictureBox.Location = new System.Drawing.Point(12, 52);
            this.cameraPreviewPictureBox.Name = "cameraPreviewPictureBox";
            this.cameraPreviewPictureBox.Size = new System.Drawing.Size(1256, 452);
            this.cameraPreviewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cameraPreviewPictureBox.TabIndex = 1;
            this.cameraPreviewPictureBox.TabStop = false;
            // bottomPanel
            this.bottomPanel.BackColor = System.Drawing.Color.White;
            this.bottomPanel.Controls.Add(this.resultMessageLabel);
            this.bottomPanel.Controls.Add(this.insideCountLabel);
            this.bottomPanel.Controls.Add(this.scannerGuidanceLabel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(12, 504);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.bottomPanel.Size = new System.Drawing.Size(1256, 140);
            this.bottomPanel.TabIndex = 2;
            // resultMessageLabel
            this.resultMessageLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.resultMessageLabel.AutoSize = false;
            this.resultMessageLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.resultMessageLabel.Location = new System.Drawing.Point(0, 8);
            this.resultMessageLabel.Name = "resultMessageLabel";
            this.resultMessageLabel.Size = new System.Drawing.Size(1256, 44);
            this.resultMessageLabel.TabIndex = 0;
            this.resultMessageLabel.Text = "Ready to scan";
            this.resultMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // insideCountLabel
            this.insideCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.insideCountLabel.AutoSize = false;
            this.insideCountLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.insideCountLabel.ForeColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.insideCountLabel.Location = new System.Drawing.Point(0, 56);
            this.insideCountLabel.Name = "insideCountLabel";
            this.insideCountLabel.Size = new System.Drawing.Size(1256, 40);
            this.insideCountLabel.TabIndex = 1;
            this.insideCountLabel.Text = "0 inside";
            this.insideCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // scannerGuidanceLabel
            this.scannerGuidanceLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.scannerGuidanceLabel.AutoSize = false;
            this.scannerGuidanceLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.scannerGuidanceLabel.ForeColor = System.Drawing.Color.FromArgb(95, 95, 95);
            this.scannerGuidanceLabel.Location = new System.Drawing.Point(0, 102);
            this.scannerGuidanceLabel.Name = "scannerGuidanceLabel";
            this.scannerGuidanceLabel.Size = new System.Drawing.Size(1256, 26);
            this.scannerGuidanceLabel.TabIndex = 2;
            this.scannerGuidanceLabel.Text = "First scan marks guest as checked in; second scan marks guest as checked out.";
            this.scannerGuidanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // CheckInForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "CheckInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check-In Scanner";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraPreviewPictureBox)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label eventLabel;
        private System.Windows.Forms.ComboBox eventComboBox;
        private System.Windows.Forms.PictureBox cameraPreviewPictureBox;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Label resultMessageLabel;
        private System.Windows.Forms.Label insideCountLabel;
        private System.Windows.Forms.Label scannerGuidanceLabel;
        private System.Windows.Forms.Label heroSublineLabel;
    }
}
