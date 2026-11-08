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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.centerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.reviewsPanel = new System.Windows.Forms.Panel();
            this.eventLabel = new System.Windows.Forms.Label();
            this.eventComboBox = new System.Windows.Forms.ComboBox();
            this.reviewFormGroupBox = new System.Windows.Forms.GroupBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.reviewFormUrlTextBox = new System.Windows.Forms.TextBox();
            this.saveUrlButton = new System.Windows.Forms.Button();
            this.actionsGroupBox = new System.Windows.Forms.GroupBox();
            this.sendRequestButton = new System.Windows.Forms.Button();
            this.importReviewsButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.centerLayoutPanel.SuspendLayout();
            this.reviewsPanel.SuspendLayout();
            this.reviewFormGroupBox.SuspendLayout();
            this.actionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // headerPanel
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.headerPanel.Size = new System.Drawing.Size(1280, 64);
            this.headerPanel.TabIndex = 0;
            // titleLabel
            this.titleLabel.AutoSize = false;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(12, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(1256, 64);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Collect Reviews";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // contentPanel
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.centerLayoutPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 64);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(12);
            this.contentPanel.Size = new System.Drawing.Size(1280, 656);
            this.contentPanel.TabIndex = 1;
            // centerLayoutPanel
            this.centerLayoutPanel.ColumnCount = 3;
            this.centerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 560F));
            this.centerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerLayoutPanel.Controls.Add(this.reviewsPanel, 1, 1);
            this.centerLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.centerLayoutPanel.Name = "centerLayoutPanel";
            this.centerLayoutPanel.RowCount = 3;
            this.centerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.centerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerLayoutPanel.Size = new System.Drawing.Size(1256, 632);
            this.centerLayoutPanel.TabIndex = 0;
            // reviewsPanel
            this.reviewsPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.reviewsPanel.BackColor = System.Drawing.Color.White;
            this.reviewsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reviewsPanel.Controls.Add(this.eventLabel);
            this.reviewsPanel.Controls.Add(this.eventComboBox);
            this.reviewsPanel.Controls.Add(this.reviewFormGroupBox);
            this.reviewsPanel.Controls.Add(this.actionsGroupBox);
            this.reviewsPanel.Controls.Add(this.resultLabel);
            this.reviewsPanel.Location = new System.Drawing.Point(348, 151);
            this.reviewsPanel.Name = "reviewsPanel";
            this.reviewsPanel.Size = new System.Drawing.Size(560, 330);
            this.reviewsPanel.TabIndex = 0;
            // eventLabel
            this.eventLabel.AutoSize = true;
            this.eventLabel.Location = new System.Drawing.Point(24, 27);
            this.eventLabel.Name = "eventLabel";
            this.eventLabel.TabIndex = 0;
            this.eventLabel.Text = "Event:";
            // eventComboBox
            this.eventComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.eventComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventComboBox.FormattingEnabled = true;
            this.eventComboBox.Location = new System.Drawing.Point(90, 24);
            this.eventComboBox.Name = "eventComboBox";
            this.eventComboBox.Size = new System.Drawing.Size(446, 23);
            this.eventComboBox.TabIndex = 1;
            this.eventComboBox.SelectedIndexChanged += new System.EventHandler(this.eventComboBox_SelectedIndexChanged);
            // reviewFormGroupBox
            this.reviewFormGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.reviewFormGroupBox.BackColor = System.Drawing.Color.White;
            this.reviewFormGroupBox.Controls.Add(this.urlLabel);
            this.reviewFormGroupBox.Controls.Add(this.reviewFormUrlTextBox);
            this.reviewFormGroupBox.Controls.Add(this.saveUrlButton);
            this.reviewFormGroupBox.Location = new System.Drawing.Point(24, 60);
            this.reviewFormGroupBox.Name = "reviewFormGroupBox";
            this.reviewFormGroupBox.Size = new System.Drawing.Size(512, 110);
            this.reviewFormGroupBox.TabIndex = 2;
            this.reviewFormGroupBox.TabStop = false;
            this.reviewFormGroupBox.Text = "Review Form";
            // urlLabel
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(12, 29);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.TabIndex = 0;
            this.urlLabel.Text = "Google Form URL:";
            // reviewFormUrlTextBox
            this.reviewFormUrlTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.reviewFormUrlTextBox.Location = new System.Drawing.Point(130, 26);
            this.reviewFormUrlTextBox.Name = "reviewFormUrlTextBox";
            this.reviewFormUrlTextBox.Size = new System.Drawing.Size(370, 23);
            this.reviewFormUrlTextBox.TabIndex = 1;
            // saveUrlButton
            this.saveUrlButton.Location = new System.Drawing.Point(130, 58);
            this.saveUrlButton.Name = "saveUrlButton";
            this.saveUrlButton.Size = new System.Drawing.Size(90, 30);
            this.saveUrlButton.TabIndex = 2;
            this.saveUrlButton.Text = "&Save URL";
            this.saveUrlButton.UseVisualStyleBackColor = true;
            this.saveUrlButton.Click += new System.EventHandler(this.saveUrlButton_Click);
            // actionsGroupBox
            this.actionsGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.actionsGroupBox.BackColor = System.Drawing.Color.White;
            this.actionsGroupBox.Controls.Add(this.sendRequestButton);
            this.actionsGroupBox.Controls.Add(this.importReviewsButton);
            this.actionsGroupBox.Location = new System.Drawing.Point(24, 186);
            this.actionsGroupBox.Name = "actionsGroupBox";
            this.actionsGroupBox.Size = new System.Drawing.Size(512, 70);
            this.actionsGroupBox.TabIndex = 3;
            this.actionsGroupBox.TabStop = false;
            this.actionsGroupBox.Text = "Actions";
            // sendRequestButton
            this.sendRequestButton.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.sendRequestButton.FlatAppearance.BorderSize = 0;
            this.sendRequestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendRequestButton.ForeColor = System.Drawing.Color.White;
            this.sendRequestButton.Location = new System.Drawing.Point(12, 24);
            this.sendRequestButton.Name = "sendRequestButton";
            this.sendRequestButton.Size = new System.Drawing.Size(170, 30);
            this.sendRequestButton.TabIndex = 0;
            this.sendRequestButton.Text = "Send &Review Request";
            this.sendRequestButton.UseVisualStyleBackColor = false;
            this.sendRequestButton.Click += new System.EventHandler(this.sendRequestButton_Click);
            // importReviewsButton
            this.importReviewsButton.Location = new System.Drawing.Point(190, 24);
            this.importReviewsButton.Name = "importReviewsButton";
            this.importReviewsButton.Size = new System.Drawing.Size(170, 30);
            this.importReviewsButton.TabIndex = 1;
            this.importReviewsButton.Text = "&Import Reviews CSV";
            this.importReviewsButton.UseVisualStyleBackColor = true;
            this.importReviewsButton.Click += new System.EventHandler(this.importReviewsButton_Click);
            // resultLabel
            this.resultLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.resultLabel.AutoSize = false;
            this.resultLabel.ForeColor = System.Drawing.Color.FromArgb(95, 95, 95);
            this.resultLabel.Location = new System.Drawing.Point(24, 272);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(512, 22);
            this.resultLabel.TabIndex = 4;
            this.resultLabel.Text = "";
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // ReviewsForm
            this.AcceptButton = this.saveUrlButton;
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
            this.Name = "ReviewsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collect Reviews";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.centerLayoutPanel.ResumeLayout(false);
            this.centerLayoutPanel.PerformLayout();
            this.reviewsPanel.ResumeLayout(false);
            this.reviewsPanel.PerformLayout();
            this.reviewFormGroupBox.ResumeLayout(false);
            this.reviewFormGroupBox.PerformLayout();
            this.actionsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.TableLayoutPanel centerLayoutPanel;
        private System.Windows.Forms.Panel reviewsPanel;
        private System.Windows.Forms.Label eventLabel;
        private System.Windows.Forms.ComboBox eventComboBox;
        private System.Windows.Forms.GroupBox reviewFormGroupBox;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.TextBox reviewFormUrlTextBox;
        private System.Windows.Forms.Button saveUrlButton;
        private System.Windows.Forms.GroupBox actionsGroupBox;
        private System.Windows.Forms.Button sendRequestButton;
        private System.Windows.Forms.Button importReviewsButton;
        private System.Windows.Forms.Label resultLabel;
    }
}
