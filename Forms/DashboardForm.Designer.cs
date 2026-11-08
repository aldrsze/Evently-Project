#nullable disable
namespace Evently.Forms
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.heroSublineLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.dashboardLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.attendanceGroupBox = new System.Windows.Forms.GroupBox();
            this.progressLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.checkedInLabel = new System.Windows.Forms.Label();
            this.insideLabel = new System.Windows.Forms.Label();
            this.notArrivedLabel = new System.Windows.Forms.Label();
            this.reviewsGroupBox = new System.Windows.Forms.GroupBox();
            this.averageRatingLabel = new System.Windows.Forms.Label();
            this.responseRateLabel = new System.Windows.Forms.Label();
            this.reviewRequestLabel = new System.Windows.Forms.Label();
            this.emailsGroupBox = new System.Windows.Forms.GroupBox();
            this.ticketsEmailedLabel = new System.Windows.Forms.Label();
            this.emailsHelperLabel = new System.Windows.Forms.Label();
            this.recentCheckInsGroupBox = new System.Windows.Forms.GroupBox();
            this.recentCheckInsListBox = new System.Windows.Forms.ListBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.eventLabel = new System.Windows.Forms.Label();
            this.eventComboBox = new System.Windows.Forms.ComboBox();
            this.autoRefreshLabel = new System.Windows.Forms.Label();
            this.lastUpdatedLabel = new System.Windows.Forms.Label();
            this.dashboardTimer = new System.Windows.Forms.Timer(this.components);
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.dashboardLayoutPanel.SuspendLayout();
            this.attendanceGroupBox.SuspendLayout();
            this.reviewsGroupBox.SuspendLayout();
            this.emailsGroupBox.SuspendLayout();
            this.recentCheckInsGroupBox.SuspendLayout();
            this.topPanel.SuspendLayout();
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
            this.titleLabel.Size = new System.Drawing.Size(149, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Live Dashboard";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // heroSublineLabel
            this.heroSublineLabel.AutoSize = true;
            this.heroSublineLabel.BackColor = System.Drawing.Color.Transparent;
            this.heroSublineLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.heroSublineLabel.ForeColor = System.Drawing.Color.FromArgb(218, 230, 245);
            this.heroSublineLabel.Location = new System.Drawing.Point(12, 38);
            this.heroSublineLabel.Name = "heroSublineLabel";
            this.heroSublineLabel.Size = new System.Drawing.Size(434, 15);
            this.heroSublineLabel.TabIndex = 1;
            this.heroSublineLabel.Text = "Live headcount, entry progress, and attendee satisfaction metrics.";
            this.heroSublineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // contentPanel
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.dashboardLayoutPanel);
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
            this.topPanel.Controls.Add(this.autoRefreshLabel);
            this.topPanel.Controls.Add(this.lastUpdatedLabel);
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
            this.eventComboBox.Size = new System.Drawing.Size(810, 23);
            this.eventComboBox.TabIndex = 1;
            this.eventComboBox.SelectedIndexChanged += new System.EventHandler(this.eventComboBox_SelectedIndexChanged);
            // autoRefreshLabel
            this.autoRefreshLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.autoRefreshLabel.AutoSize = true;
            this.autoRefreshLabel.ForeColor = System.Drawing.Color.FromArgb(95, 95, 95);
            this.autoRefreshLabel.Location = new System.Drawing.Point(880, 12);
            this.autoRefreshLabel.Name = "autoRefreshLabel";
            this.autoRefreshLabel.Size = new System.Drawing.Size(232, 15);
            this.autoRefreshLabel.TabIndex = 2;
            this.autoRefreshLabel.Text = "Refreshes automatically every 5 seconds";
            // lastUpdatedLabel
            this.lastUpdatedLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lastUpdatedLabel.AutoSize = true;
            this.lastUpdatedLabel.ForeColor = System.Drawing.Color.FromArgb(95, 95, 95);
            this.lastUpdatedLabel.Location = new System.Drawing.Point(1134, 12);
            this.lastUpdatedLabel.Name = "lastUpdatedLabel";
            this.lastUpdatedLabel.Size = new System.Drawing.Size(100, 15);
            this.lastUpdatedLabel.TabIndex = 3;
            this.lastUpdatedLabel.Text = "Last updated: --:--";
            // dashboardLayoutPanel
            this.dashboardLayoutPanel.ColumnCount = 2;
            this.dashboardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.dashboardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.dashboardLayoutPanel.Controls.Add(this.attendanceGroupBox, 0, 0);
            this.dashboardLayoutPanel.Controls.Add(this.reviewsGroupBox, 0, 1);
            this.dashboardLayoutPanel.Controls.Add(this.emailsGroupBox, 0, 2);
            this.dashboardLayoutPanel.Controls.Add(this.recentCheckInsGroupBox, 1, 0);
            this.dashboardLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardLayoutPanel.Location = new System.Drawing.Point(12, 52);
            this.dashboardLayoutPanel.Name = "dashboardLayoutPanel";
            this.dashboardLayoutPanel.RowCount = 3;
            this.dashboardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.dashboardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.dashboardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.dashboardLayoutPanel.SetRowSpan(this.recentCheckInsGroupBox, 3);
            this.dashboardLayoutPanel.Size = new System.Drawing.Size(1256, 592);
            this.dashboardLayoutPanel.TabIndex = 1;
            // attendanceGroupBox
            this.attendanceGroupBox.BackColor = System.Drawing.Color.White;
            this.attendanceGroupBox.Controls.Add(this.progressLabel);
            this.attendanceGroupBox.Controls.Add(this.progressBar);
            this.attendanceGroupBox.Controls.Add(this.checkedInLabel);
            this.attendanceGroupBox.Controls.Add(this.insideLabel);
            this.attendanceGroupBox.Controls.Add(this.notArrivedLabel);
            this.attendanceGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attendanceGroupBox.Location = new System.Drawing.Point(8, 8);
            this.attendanceGroupBox.Margin = new System.Windows.Forms.Padding(8);
            this.attendanceGroupBox.Name = "attendanceGroupBox";
            this.attendanceGroupBox.Size = new System.Drawing.Size(549, 250);
            this.attendanceGroupBox.TabIndex = 0;
            this.attendanceGroupBox.TabStop = false;
            this.attendanceGroupBox.Text = "Attendance";
            // progressLabel
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(12, 29);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.TabIndex = 0;
            this.progressLabel.Text = "Registered: 0 of 0";
            // progressBar
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.progressBar.Location = new System.Drawing.Point(12, 49);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(525, 20);
            this.progressBar.TabIndex = 1;
            // checkedInLabel
            this.checkedInLabel.AutoSize = true;
            this.checkedInLabel.Location = new System.Drawing.Point(12, 81);
            this.checkedInLabel.Name = "checkedInLabel";
            this.checkedInLabel.TabIndex = 2;
            this.checkedInLabel.Text = "Checked in: 0";
            // insideLabel
            this.insideLabel.AutoSize = true;
            this.insideLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.insideLabel.ForeColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.insideLabel.Location = new System.Drawing.Point(12, 107);
            this.insideLabel.Name = "insideLabel";
            this.insideLabel.TabIndex = 3;
            this.insideLabel.Text = "Currently inside: 0";
            // notArrivedLabel
            this.notArrivedLabel.AutoSize = true;
            this.notArrivedLabel.Location = new System.Drawing.Point(12, 141);
            this.notArrivedLabel.Name = "notArrivedLabel";
            this.notArrivedLabel.TabIndex = 4;
            this.notArrivedLabel.Text = "Not yet arrived: 0";
            // reviewsGroupBox
            this.reviewsGroupBox.BackColor = System.Drawing.Color.White;
            this.reviewsGroupBox.Controls.Add(this.averageRatingLabel);
            this.reviewsGroupBox.Controls.Add(this.responseRateLabel);
            this.reviewsGroupBox.Controls.Add(this.reviewRequestLabel);
            this.reviewsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reviewsGroupBox.Location = new System.Drawing.Point(8, 274);
            this.reviewsGroupBox.Margin = new System.Windows.Forms.Padding(8);
            this.reviewsGroupBox.Name = "reviewsGroupBox";
            this.reviewsGroupBox.Size = new System.Drawing.Size(549, 173);
            this.reviewsGroupBox.TabIndex = 1;
            this.reviewsGroupBox.TabStop = false;
            this.reviewsGroupBox.Text = "Reviews";
            // averageRatingLabel
            this.averageRatingLabel.AutoSize = true;
            this.averageRatingLabel.Location = new System.Drawing.Point(12, 29);
            this.averageRatingLabel.Name = "averageRatingLabel";
            this.averageRatingLabel.TabIndex = 0;
            this.averageRatingLabel.Text = "Average rating: -";
            // responseRateLabel
            this.responseRateLabel.AutoSize = true;
            this.responseRateLabel.Location = new System.Drawing.Point(12, 57);
            this.responseRateLabel.Name = "responseRateLabel";
            this.responseRateLabel.TabIndex = 1;
            this.responseRateLabel.Text = "Response rate: 0%";
            // reviewRequestLabel
            this.reviewRequestLabel.AutoSize = true;
            this.reviewRequestLabel.Location = new System.Drawing.Point(12, 85);
            this.reviewRequestLabel.Name = "reviewRequestLabel";
            this.reviewRequestLabel.TabIndex = 2;
            this.reviewRequestLabel.Text = "Review requests sent: 0";
            // emailsGroupBox
            this.emailsGroupBox.BackColor = System.Drawing.Color.White;
            this.emailsGroupBox.Controls.Add(this.ticketsEmailedLabel);
            this.emailsGroupBox.Controls.Add(this.emailsHelperLabel);
            this.emailsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailsGroupBox.Location = new System.Drawing.Point(8, 463);
            this.emailsGroupBox.Margin = new System.Windows.Forms.Padding(8);
            this.emailsGroupBox.Name = "emailsGroupBox";
            this.emailsGroupBox.Size = new System.Drawing.Size(549, 121);
            this.emailsGroupBox.TabIndex = 2;
            this.emailsGroupBox.TabStop = false;
            this.emailsGroupBox.Text = "Emails";
            // ticketsEmailedLabel
            this.ticketsEmailedLabel.AutoSize = true;
            this.ticketsEmailedLabel.Location = new System.Drawing.Point(12, 26);
            this.ticketsEmailedLabel.Name = "ticketsEmailedLabel";
            this.ticketsEmailedLabel.TabIndex = 0;
            this.ticketsEmailedLabel.Text = "Tickets emailed: 0 of 0";
            // emailsHelperLabel
            this.emailsHelperLabel.AutoSize = true;
            this.emailsHelperLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.emailsHelperLabel.ForeColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.emailsHelperLabel.Location = new System.Drawing.Point(12, 54);
            this.emailsHelperLabel.Name = "emailsHelperLabel";
            this.emailsHelperLabel.Size = new System.Drawing.Size(306, 13);
            this.emailsHelperLabel.TabIndex = 1;
            this.emailsHelperLabel.Text = "Emailed tickets count only attendees with confirmed delivery";
            // recentCheckInsGroupBox
            this.recentCheckInsGroupBox.BackColor = System.Drawing.Color.White;
            this.recentCheckInsGroupBox.Controls.Add(this.recentCheckInsListBox);
            this.recentCheckInsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recentCheckInsGroupBox.Location = new System.Drawing.Point(573, 8);
            this.recentCheckInsGroupBox.Margin = new System.Windows.Forms.Padding(8);
            this.recentCheckInsGroupBox.Name = "recentCheckInsGroupBox";
            this.recentCheckInsGroupBox.Padding = new System.Windows.Forms.Padding(12);
            this.recentCheckInsGroupBox.Size = new System.Drawing.Size(675, 576);
            this.recentCheckInsGroupBox.TabIndex = 3;
            this.recentCheckInsGroupBox.TabStop = false;
            this.recentCheckInsGroupBox.Text = "Recent Check-Ins";
            // recentCheckInsListBox
            this.recentCheckInsListBox.BackColor = System.Drawing.Color.White;
            this.recentCheckInsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.recentCheckInsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recentCheckInsListBox.FormattingEnabled = true;
            this.recentCheckInsListBox.IntegralHeight = false;
            this.recentCheckInsListBox.Location = new System.Drawing.Point(12, 28);
            this.recentCheckInsListBox.Name = "recentCheckInsListBox";
            this.recentCheckInsListBox.Size = new System.Drawing.Size(651, 536);
            this.recentCheckInsListBox.TabIndex = 0;
            // dashboardTimer
            this.dashboardTimer.Enabled = true;
            this.dashboardTimer.Interval = 5000;
            this.dashboardTimer.Tick += new System.EventHandler(this.dashboardTimer_Tick);
            // DashboardForm
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
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Live Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.dashboardLayoutPanel.ResumeLayout(false);
            this.attendanceGroupBox.ResumeLayout(false);
            this.attendanceGroupBox.PerformLayout();
            this.reviewsGroupBox.ResumeLayout(false);
            this.reviewsGroupBox.PerformLayout();
            this.emailsGroupBox.ResumeLayout(false);
            this.emailsGroupBox.PerformLayout();
            this.recentCheckInsGroupBox.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.TableLayoutPanel dashboardLayoutPanel;
        private System.Windows.Forms.GroupBox attendanceGroupBox;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label checkedInLabel;
        private System.Windows.Forms.Label insideLabel;
        private System.Windows.Forms.Label notArrivedLabel;
        private System.Windows.Forms.GroupBox reviewsGroupBox;
        private System.Windows.Forms.Label averageRatingLabel;
        private System.Windows.Forms.Label responseRateLabel;
        private System.Windows.Forms.Label reviewRequestLabel;
        private System.Windows.Forms.GroupBox emailsGroupBox;
        private System.Windows.Forms.Label ticketsEmailedLabel;
        private System.Windows.Forms.Label emailsHelperLabel;
        private System.Windows.Forms.GroupBox recentCheckInsGroupBox;
        private System.Windows.Forms.ListBox recentCheckInsListBox;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label eventLabel;
        private System.Windows.Forms.ComboBox eventComboBox;
        private System.Windows.Forms.Label autoRefreshLabel;
        private System.Windows.Forms.Label lastUpdatedLabel;
        private System.Windows.Forms.Timer dashboardTimer;
        private System.Windows.Forms.Label heroSublineLabel;
    }
}
