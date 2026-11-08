#nullable disable
namespace Evently.Forms
{
    partial class ReviewsForm
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
            this.urlLabel = new System.Windows.Forms.Label();
            this.reviewFormUrlTextBox = new System.Windows.Forms.TextBox();
            this.saveUrlButton = new System.Windows.Forms.Button();
            this.sendRequestButton = new System.Windows.Forms.Button();
            this.importReviewsButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // eventComboBox
            this.eventComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.eventComboBox.FormattingEnabled = true;
            this.eventComboBox.Location = new System.Drawing.Point(12, 12);
            this.eventComboBox.Name = "eventComboBox";
            this.eventComboBox.Size = new System.Drawing.Size(460, 23);
            this.eventComboBox.SelectedIndexChanged += new System.EventHandler(this.eventComboBox_SelectedIndexChanged);
            // urlLabel
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(12, 50);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Text = "Google Form URL:";
            // reviewFormUrlTextBox
            this.reviewFormUrlTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.reviewFormUrlTextBox.Location = new System.Drawing.Point(120, 47);
            this.reviewFormUrlTextBox.Name = "reviewFormUrlTextBox";
            this.reviewFormUrlTextBox.Size = new System.Drawing.Size(352, 23);
            // saveUrlButton
            this.saveUrlButton.Location = new System.Drawing.Point(120, 76);
            this.saveUrlButton.Name = "saveUrlButton";
            this.saveUrlButton.Size = new System.Drawing.Size(90, 30);
            this.saveUrlButton.Text = "Save URL";
            this.saveUrlButton.Click += new System.EventHandler(this.saveUrlButton_Click);
            // sendRequestButton
            this.sendRequestButton.Location = new System.Drawing.Point(120, 120);
            this.sendRequestButton.Name = "sendRequestButton";
            this.sendRequestButton.Size = new System.Drawing.Size(150, 30);
            this.sendRequestButton.Text = "Send Review Request";
            this.sendRequestButton.Click += new System.EventHandler(this.sendRequestButton_Click);
            // importReviewsButton
            this.importReviewsButton.Location = new System.Drawing.Point(280, 120);
            this.importReviewsButton.Name = "importReviewsButton";
            this.importReviewsButton.Size = new System.Drawing.Size(150, 30);
            this.importReviewsButton.Text = "Import Reviews CSV";
            this.importReviewsButton.Click += new System.EventHandler(this.importReviewsButton_Click);
            // resultLabel
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(120, 165);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Text = "";
            // ReviewsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.eventComboBox);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.reviewFormUrlTextBox);
            this.Controls.Add(this.saveUrlButton);
            this.Controls.Add(this.sendRequestButton);
            this.Controls.Add(this.importReviewsButton);
            this.Controls.Add(this.resultLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ReviewsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Collect Reviews";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox eventComboBox;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.TextBox reviewFormUrlTextBox;
        private System.Windows.Forms.Button saveUrlButton;
        private System.Windows.Forms.Button sendRequestButton;
        private System.Windows.Forms.Button importReviewsButton;
        private System.Windows.Forms.Label resultLabel;
    }
}