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
            this.eventComboBox = new System.Windows.Forms.ComboBox();
            this.cameraPreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.resultMessageLabel = new System.Windows.Forms.Label();
            this.insideCountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cameraPreviewPictureBox)).BeginInit();
            this.SuspendLayout();
            // eventComboBox
            this.eventComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.eventComboBox.FormattingEnabled = true;
            this.eventComboBox.Location = new System.Drawing.Point(12, 12);
            this.eventComboBox.Name = "eventComboBox";
            this.eventComboBox.Size = new System.Drawing.Size(610, 23);
            this.eventComboBox.SelectedIndexChanged += new System.EventHandler(this.eventComboBox_SelectedIndexChanged);
            // cameraPreviewPictureBox
            this.cameraPreviewPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.cameraPreviewPictureBox.BackColor = System.Drawing.Color.Black;
            this.cameraPreviewPictureBox.Location = new System.Drawing.Point(12, 45);
            this.cameraPreviewPictureBox.Name = "cameraPreviewPictureBox";
            this.cameraPreviewPictureBox.Size = new System.Drawing.Size(610, 350);
            this.cameraPreviewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // resultMessageLabel
            this.resultMessageLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.resultMessageLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.resultMessageLabel.Location = new System.Drawing.Point(12, 410);
            this.resultMessageLabel.Name = "resultMessageLabel";
            this.resultMessageLabel.Size = new System.Drawing.Size(610, 40);
            this.resultMessageLabel.Text = "Ready to scan";
            this.resultMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // insideCountLabel
            this.insideCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.insideCountLabel.AutoSize = true;
            this.insideCountLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.insideCountLabel.Location = new System.Drawing.Point(520, 460);
            this.insideCountLabel.Name = "insideCountLabel";
            this.insideCountLabel.Text = "0 inside";
            // CheckInForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 491);
            this.Controls.Add(this.eventComboBox);
            this.Controls.Add(this.cameraPreviewPictureBox);
            this.Controls.Add(this.resultMessageLabel);
            this.Controls.Add(this.insideCountLabel);
            this.Name = "CheckInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Check-In Scanner";
            ((System.ComponentModel.ISupportInitialize)(this.cameraPreviewPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox eventComboBox;
        private System.Windows.Forms.PictureBox cameraPreviewPictureBox;
        private System.Windows.Forms.Label resultMessageLabel;
        private System.Windows.Forms.Label insideCountLabel;
    }
}