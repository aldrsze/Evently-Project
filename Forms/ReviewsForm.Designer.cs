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
            this.heroSublineLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.eventLabel = new System.Windows.Forms.Label();
            this.eventComboBox = new System.Windows.Forms.ComboBox();
            this.gridHostPanel = new System.Windows.Forms.Panel();
            this.reviewsDataGridView = new System.Windows.Forms.DataGridView();
            this.attendeeNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratingColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reviewFormWrapperPanel = new System.Windows.Forms.Panel();
            this.reviewFormGroupBox = new System.Windows.Forms.GroupBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.reviewFormUrlTextBox = new System.Windows.Forms.TextBox();
            this.urlHelperLabel = new System.Windows.Forms.Label();
            this.saveUrlButton = new System.Windows.Forms.Button();
            this.resultPanel = new System.Windows.Forms.Panel();
            this.resultLabel = new System.Windows.Forms.Label();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.actionHintLabel = new System.Windows.Forms.Label();
            this.sendRequestButton = new System.Windows.Forms.Button();
            this.importReviewsButton = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.gridHostPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reviewsDataGridView)).BeginInit();
            this.reviewFormWrapperPanel.SuspendLayout();
            this.reviewFormGroupBox.SuspendLayout();
            this.resultPanel.SuspendLayout();
            this.actionPanel.SuspendLayout();
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
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(12, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(175, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Collect Reviews";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // heroSublineLabel
            this.heroSublineLabel.AutoSize = true;
            this.heroSublineLabel.BackColor = System.Drawing.Color.Transparent;
            this.heroSublineLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.heroSublineLabel.ForeColor = System.Drawing.Color.FromArgb(218, 230, 245);
            this.heroSublineLabel.Location = new System.Drawing.Point(12, 38);
            this.heroSublineLabel.Name = "heroSublineLabel";
            this.heroSublineLabel.Size = new System.Drawing.Size(465, 15);
            this.heroSublineLabel.TabIndex = 1;
            this.heroSublineLabel.Text = "Distribute Google Form rating links and import attendee responses from CSV.";
            this.heroSublineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // contentPanel
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.gridHostPanel);
            this.contentPanel.Controls.Add(this.reviewFormWrapperPanel);
            this.contentPanel.Controls.Add(this.resultPanel);
            this.contentPanel.Controls.Add(this.actionPanel);
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
            // gridHostPanel
            this.gridHostPanel.BackColor = System.Drawing.Color.White;
            this.gridHostPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gridHostPanel.Controls.Add(this.reviewsDataGridView);
            this.gridHostPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHostPanel.Location = new System.Drawing.Point(12, 52);
            this.gridHostPanel.Name = "gridHostPanel";
            this.gridHostPanel.Size = new System.Drawing.Size(1256, 402);
            this.gridHostPanel.TabIndex = 1;
            // reviewsDataGridView
            this.reviewsDataGridView.AllowUserToAddRows = false;
            this.reviewsDataGridView.AllowUserToDeleteRows = false;
            this.reviewsDataGridView.AllowUserToResizeRows = false;
            this.reviewsDataGridView.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(249, 249, 249);
            this.reviewsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.reviewsDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.reviewsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reviewsDataGridView.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.reviewsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.reviewsDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.reviewsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.reviewsDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.reviewsDataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.reviewsDataGridView.ColumnHeadersHeight = 36;
            this.reviewsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.reviewsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.attendeeNameColumn,
            this.ratingColumn,
            this.commentColumn});
            this.reviewsDataGridView.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.reviewsDataGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.reviewsDataGridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.reviewsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reviewsDataGridView.EnableHeadersVisualStyles = false;
            this.reviewsDataGridView.GridColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.reviewsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.reviewsDataGridView.MultiSelect = false;
            this.reviewsDataGridView.Name = "reviewsDataGridView";
            this.reviewsDataGridView.ReadOnly = true;
            this.reviewsDataGridView.RowHeadersVisible = false;
            this.reviewsDataGridView.RowTemplate.Height = 28;
            this.reviewsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reviewsDataGridView.Size = new System.Drawing.Size(1254, 400);
            this.reviewsDataGridView.TabIndex = 0;
            // attendeeNameColumn
            this.attendeeNameColumn.FillWeight = 80F;
            this.attendeeNameColumn.HeaderText = "Name";
            this.attendeeNameColumn.Name = "attendeeNameColumn";
            this.attendeeNameColumn.ReadOnly = true;
            // ratingColumn
            this.ratingColumn.FillWeight = 30F;
            this.ratingColumn.HeaderText = "Rating";
            this.ratingColumn.Name = "ratingColumn";
            this.ratingColumn.ReadOnly = true;
            // commentColumn
            this.commentColumn.FillWeight = 100F;
            this.commentColumn.HeaderText = "Comment";
            this.commentColumn.Name = "commentColumn";
            this.commentColumn.ReadOnly = true;
            // reviewFormWrapperPanel
            this.reviewFormWrapperPanel.BackColor = System.Drawing.Color.White;
            this.reviewFormWrapperPanel.Controls.Add(this.reviewFormGroupBox);
            this.reviewFormWrapperPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.reviewFormWrapperPanel.Location = new System.Drawing.Point(12, 454);
            this.reviewFormWrapperPanel.Name = "reviewFormWrapperPanel";
            this.reviewFormWrapperPanel.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.reviewFormWrapperPanel.Size = new System.Drawing.Size(1256, 102);
            this.reviewFormWrapperPanel.TabIndex = 2;
            // reviewFormGroupBox
            this.reviewFormGroupBox.BackColor = System.Drawing.Color.White;
            this.reviewFormGroupBox.Controls.Add(this.urlLabel);
            this.reviewFormGroupBox.Controls.Add(this.reviewFormUrlTextBox);
            this.reviewFormGroupBox.Controls.Add(this.urlHelperLabel);
            this.reviewFormGroupBox.Controls.Add(this.saveUrlButton);
            this.reviewFormGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reviewFormGroupBox.Location = new System.Drawing.Point(0, 16);
            this.reviewFormGroupBox.Name = "reviewFormGroupBox";
            this.reviewFormGroupBox.Size = new System.Drawing.Size(1256, 86);
            this.reviewFormGroupBox.TabIndex = 0;
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
            this.reviewFormUrlTextBox.Location = new System.Drawing.Point(138, 26);
            this.reviewFormUrlTextBox.Name = "reviewFormUrlTextBox";
            this.reviewFormUrlTextBox.Size = new System.Drawing.Size(1004, 23);
            this.reviewFormUrlTextBox.TabIndex = 1;
            // urlHelperLabel
            this.urlHelperLabel.AutoSize = true;
            this.urlHelperLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.urlHelperLabel.ForeColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.urlHelperLabel.Location = new System.Drawing.Point(136, 56);
            this.urlHelperLabel.Name = "urlHelperLabel";
            this.urlHelperLabel.Size = new System.Drawing.Size(258, 13);
            this.urlHelperLabel.TabIndex = 3;
            this.urlHelperLabel.Text = "Attendees use this link to submit their 1 to 5 ratings";
            // saveUrlButton
            this.saveUrlButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.saveUrlButton.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.saveUrlButton.FlatAppearance.BorderSize = 0;
            this.saveUrlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveUrlButton.ForeColor = System.Drawing.Color.White;
            this.saveUrlButton.Location = new System.Drawing.Point(1154, 26);
            this.saveUrlButton.Name = "saveUrlButton";
            this.saveUrlButton.Size = new System.Drawing.Size(90, 30);
            this.saveUrlButton.TabIndex = 2;
            this.saveUrlButton.Text = "&Save URL";
            this.saveUrlButton.UseVisualStyleBackColor = false;
            this.saveUrlButton.Click += new System.EventHandler(this.saveUrlButton_Click);
            // resultPanel
            this.resultPanel.BackColor = System.Drawing.Color.White;
            this.resultPanel.Controls.Add(this.resultLabel);
            this.resultPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.resultPanel.Location = new System.Drawing.Point(12, 556);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.resultPanel.Size = new System.Drawing.Size(1256, 36);
            this.resultPanel.TabIndex = 3;
            // resultLabel
            this.resultLabel.AutoSize = false;
            this.resultLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultLabel.ForeColor = System.Drawing.Color.FromArgb(95, 95, 95);
            this.resultLabel.Location = new System.Drawing.Point(0, 8);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(1256, 28);
            this.resultLabel.TabIndex = 0;
            this.resultLabel.Text = "";
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // actionPanel
            this.actionPanel.BackColor = System.Drawing.Color.White;
            this.actionPanel.Controls.Add(this.actionHintLabel);
            this.actionPanel.Controls.Add(this.sendRequestButton);
            this.actionPanel.Controls.Add(this.importReviewsButton);
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.actionPanel.Location = new System.Drawing.Point(12, 592);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(1256, 46);
            this.actionPanel.TabIndex = 4;
            // actionHintLabel
            this.actionHintLabel.AutoSize = true;
            this.actionHintLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.actionHintLabel.ForeColor = System.Drawing.Color.FromArgb(95, 95, 95);
            this.actionHintLabel.Location = new System.Drawing.Point(0, 14);
            this.actionHintLabel.Name = "actionHintLabel";
            this.actionHintLabel.Size = new System.Drawing.Size(468, 15);
            this.actionHintLabel.TabIndex = 2;
            this.actionHintLabel.Text = "Review requests are only sent to guests who checked in at the door";
            // sendRequestButton
            this.sendRequestButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.sendRequestButton.Location = new System.Drawing.Point(1028, 8);
            this.sendRequestButton.Name = "sendRequestButton";
            this.sendRequestButton.Size = new System.Drawing.Size(118, 30);
            this.sendRequestButton.TabIndex = 0;
            this.sendRequestButton.Text = "Send &Request";
            this.sendRequestButton.UseVisualStyleBackColor = true;
            this.sendRequestButton.Click += new System.EventHandler(this.sendRequestButton_Click);
            // importReviewsButton
            this.importReviewsButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.importReviewsButton.Location = new System.Drawing.Point(1154, 8);
            this.importReviewsButton.Name = "importReviewsButton";
            this.importReviewsButton.Size = new System.Drawing.Size(100, 30);
            this.importReviewsButton.TabIndex = 1;
            this.importReviewsButton.Text = "I&mport CSV";
            this.importReviewsButton.UseVisualStyleBackColor = true;
            this.importReviewsButton.Click += new System.EventHandler(this.importReviewsButton_Click);
            // ReviewsForm
            this.AcceptButton = this.saveUrlButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
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
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.gridHostPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reviewsDataGridView)).EndInit();
            this.reviewFormWrapperPanel.ResumeLayout(false);
            this.reviewFormGroupBox.ResumeLayout(false);
            this.reviewFormGroupBox.PerformLayout();
            this.resultPanel.ResumeLayout(false);
            this.actionPanel.ResumeLayout(false);
            this.actionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label heroSublineLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label eventLabel;
        private System.Windows.Forms.ComboBox eventComboBox;
        private System.Windows.Forms.Panel gridHostPanel;
        private System.Windows.Forms.DataGridView reviewsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn attendeeNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratingColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentColumn;
        private System.Windows.Forms.Panel reviewFormWrapperPanel;
        private System.Windows.Forms.GroupBox reviewFormGroupBox;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.TextBox reviewFormUrlTextBox;
        private System.Windows.Forms.Label urlHelperLabel;
        private System.Windows.Forms.Button saveUrlButton;
        private System.Windows.Forms.Panel resultPanel;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.Label actionHintLabel;
        private System.Windows.Forms.Button sendRequestButton;
        private System.Windows.Forms.Button importReviewsButton;
    }
}
