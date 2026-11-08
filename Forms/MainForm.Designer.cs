#nullable disable
namespace Evently.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.eventsButton = new System.Windows.Forms.Button();
            this.attendeesButton = new System.Windows.Forms.Button();
            this.reviewsButton = new System.Windows.Forms.Button();
            this.checkInButton = new System.Windows.Forms.Button();
            this.dashboardButton = new System.Windows.Forms.Button();
            this.usersButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // menuPanel
            this.menuPanel.Controls.Add(this.eventsButton);
            this.menuPanel.Controls.Add(this.attendeesButton);
            this.menuPanel.Controls.Add(this.reviewsButton);
            this.menuPanel.Controls.Add(this.checkInButton);
            this.menuPanel.Controls.Add(this.dashboardButton);
            this.menuPanel.Controls.Add(this.usersButton);
            this.menuPanel.Controls.Add(this.logoutButton);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.menuPanel.Location = new System.Drawing.Point(12, 12);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(260, 336);
            // eventsButton
            this.eventsButton.Location = new System.Drawing.Point(3, 3);
            this.eventsButton.Name = "eventsButton";
            this.eventsButton.Size = new System.Drawing.Size(250, 40);
            this.eventsButton.Text = "Events";
            this.eventsButton.Click += new System.EventHandler(this.eventsButton_Click);
            // attendeesButton
            this.attendeesButton.Location = new System.Drawing.Point(3, 49);
            this.attendeesButton.Name = "attendeesButton";
            this.attendeesButton.Size = new System.Drawing.Size(250, 40);
            this.attendeesButton.Text = "Attendees";
            this.attendeesButton.Click += new System.EventHandler(this.attendeesButton_Click);
            // reviewsButton
            this.reviewsButton.Location = new System.Drawing.Point(3, 95);
            this.reviewsButton.Name = "reviewsButton";
            this.reviewsButton.Size = new System.Drawing.Size(250, 40);
            this.reviewsButton.Text = "Reviews";
            this.reviewsButton.Click += new System.EventHandler(this.reviewsButton_Click);
            // checkInButton
            this.checkInButton.Location = new System.Drawing.Point(3, 141);
            this.checkInButton.Name = "checkInButton";
            this.checkInButton.Size = new System.Drawing.Size(250, 40);
            this.checkInButton.Text = "Check-In Scanner";
            this.checkInButton.Click += new System.EventHandler(this.checkInButton_Click);
            // dashboardButton
            this.dashboardButton.Location = new System.Drawing.Point(3, 187);
            this.dashboardButton.Name = "dashboardButton";
            this.dashboardButton.Size = new System.Drawing.Size(250, 40);
            this.dashboardButton.Text = "Live Dashboard";
            this.dashboardButton.Click += new System.EventHandler(this.dashboardButton_Click);
            // usersButton
            this.usersButton.Location = new System.Drawing.Point(3, 233);
            this.usersButton.Name = "usersButton";
            this.usersButton.Size = new System.Drawing.Size(250, 40);
            this.usersButton.Text = "Manage Users";
            this.usersButton.Click += new System.EventHandler(this.usersButton_Click);
            // logoutButton
            this.logoutButton.Location = new System.Drawing.Point(3, 279);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(250, 40);
            this.logoutButton.Text = "Logout";
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 360);
            this.Controls.Add(this.menuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evently - Main Menu";
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.FlowLayoutPanel menuPanel;
        private System.Windows.Forms.Button eventsButton;
        private System.Windows.Forms.Button attendeesButton;
        private System.Windows.Forms.Button reviewsButton;
        private System.Windows.Forms.Button checkInButton;
        private System.Windows.Forms.Button dashboardButton;
        private System.Windows.Forms.Button usersButton;
        private System.Windows.Forms.Button logoutButton;
    }
}