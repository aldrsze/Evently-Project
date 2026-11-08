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
            this.eventComboBox = new System.Windows.Forms.ComboBox();
            this.lastUpdatedLabel = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.checkedInLabel = new System.Windows.Forms.Label();
            this.insideLabel = new System.Windows.Forms.Label();
            this.notArrivedLabel = new System.Windows.Forms.Label();
            this.averageRatingLabel = new System.Windows.Forms.Label();
            this.responseRateLabel = new System.Windows.Forms.Label();
            this.ticketsEmailedLabel = new System.Windows.Forms.Label();
            this.reviewRequestLabel = new System.Windows.Forms.Label();
            this.recentCheckInsListBox = new System.Windows.Forms.ListBox();
            this.dashboardTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // eventComboBox
            this.eventComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.eventComboBox.FormattingEnabled = true;
            this.eventComboBox.Location = new System.Drawing.Point(12, 12);
            this.eventComboBox.Name = "eventComboBox";
            this.eventComboBox.Size = new System.Drawing.Size(610, 23);
            this.eventComboBox.SelectedIndexChanged += new System.EventHandler(this.eventComboBox_SelectedIndexChanged);
            // lastUpdatedLabel
            this.lastUpdatedLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lastUpdatedLabel.AutoSize = true;
            this.lastUpdatedLabel.Location = new System.Drawing.Point(470, 42);
            this.lastUpdatedLabel.Name = "lastUpdatedLabel";
            this.lastUpdatedLabel.Text = "Last updated: --:--";
            // progressLabel
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(12, 42);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Text = "Registered: 0 of 0";
            // progressBar
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.progressBar.Location = new System.Drawing.Point(12, 60);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(610, 20);
            // checkedInLabel
            this.checkedInLabel.AutoSize = true;
            this.checkedInLabel.Location = new System.Drawing.Point(12, 95);
            this.checkedInLabel.Name = "checkedInLabel";
            this.checkedInLabel.Text = "Checked in: 0";
            // insideLabel
            this.insideLabel.AutoSize = true;
            this.insideLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.insideLabel.Location = new System.Drawing.Point(12, 120);
            this.insideLabel.Name = "insideLabel";
            this.insideLabel.Text = "Currently inside: 0";
            // notArrivedLabel
            this.notArrivedLabel.AutoSize = true;
            this.notArrivedLabel.Location = new System.Drawing.Point(12, 150);
            this.notArrivedLabel.Name = "notArrivedLabel";
            this.notArrivedLabel.Text = "Not yet arrived: 0";
            // averageRatingLabel
            this.averageRatingLabel.AutoSize = true;
            this.averageRatingLabel.Location = new System.Drawing.Point(12, 185);
            this.averageRatingLabel.Name = "averageRatingLabel";
            this.averageRatingLabel.Text = "Average rating: -";
            // responseRateLabel
            this.responseRateLabel.AutoSize = true;
            this.responseRateLabel.Location = new System.Drawing.Point(12, 210);
            this.responseRateLabel.Name = "responseRateLabel";
            this.responseRateLabel.Text = "Response rate: 0%";
            // ticketsEmailedLabel
            this.ticketsEmailedLabel.AutoSize = true;
            this.ticketsEmailedLabel.Location = new System.Drawing.Point(12, 245);
            this.ticketsEmailedLabel.Name = "ticketsEmailedLabel";
            this.ticketsEmailedLabel.Text = "Tickets emailed: 0 of 0";
            // reviewRequestLabel
            this.reviewRequestLabel.AutoSize = true;
            this.reviewRequestLabel.Location = new System.Drawing.Point(12, 270);
            this.reviewRequestLabel.Name = "reviewRequestLabel";
            this.reviewRequestLabel.Text = "Review requests sent: 0";
            // recentCheckInsListBox
            this.recentCheckInsListBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.recentCheckInsListBox.FormattingEnabled = true;
            this.recentCheckInsListBox.Location = new System.Drawing.Point(342, 95);
            this.recentCheckInsListBox.Name = "recentCheckInsListBox";
            this.recentCheckInsListBox.Size = new System.Drawing.Size(280, 229);
            // dashboardTimer
            this.dashboardTimer.Enabled = true;
            this.dashboardTimer.Interval = 5000;
            this.dashboardTimer.Tick += new System.EventHandler(this.dashboardTimer_Tick);
            // DashboardForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 341);
            this.Controls.Add(this.eventComboBox);
            this.Controls.Add(this.lastUpdatedLabel);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.checkedInLabel);
            this.Controls.Add(this.insideLabel);
            this.Controls.Add(this.notArrivedLabel);
            this.Controls.Add(this.averageRatingLabel);
            this.Controls.Add(this.responseRateLabel);
            this.Controls.Add(this.ticketsEmailedLabel);
            this.Controls.Add(this.reviewRequestLabel);
            this.Controls.Add(this.recentCheckInsListBox);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Live Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox eventComboBox;
        private System.Windows.Forms.Label lastUpdatedLabel;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label checkedInLabel;
        private System.Windows.Forms.Label insideLabel;
        private System.Windows.Forms.Label notArrivedLabel;
        private System.Windows.Forms.Label averageRatingLabel;
        private System.Windows.Forms.Label responseRateLabel;
        private System.Windows.Forms.Label ticketsEmailedLabel;
        private System.Windows.Forms.Label reviewRequestLabel;
        private System.Windows.Forms.ListBox recentCheckInsListBox;
        private System.Windows.Forms.Timer dashboardTimer;
    }
}