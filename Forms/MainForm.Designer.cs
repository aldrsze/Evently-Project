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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.signedInLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.contentPlaceholderPanel = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.eventsButton = new System.Windows.Forms.Button();
            this.attendeesButton = new System.Windows.Forms.Button();
            this.reviewsButton = new System.Windows.Forms.Button();
            this.checkInButton = new System.Windows.Forms.Button();
            this.dashboardButton = new System.Windows.Forms.Button();
            this.usersButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // headerPanel
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.signedInLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.headerPanel.Size = new System.Drawing.Size(1280, 64);
            this.headerPanel.TabIndex = 0;
            // titleLabel
            this.titleLabel.AutoSize = false;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(12, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(1024, 64);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Evently";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // signedInLabel
            this.signedInLabel.AutoSize = false;
            this.signedInLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.signedInLabel.Location = new System.Drawing.Point(1036, 0);
            this.signedInLabel.Name = "signedInLabel";
            this.signedInLabel.Size = new System.Drawing.Size(220, 64);
            this.signedInLabel.TabIndex = 1;
            this.signedInLabel.Text = "";
            this.signedInLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // contentPanel
            this.contentPanel.Controls.Add(this.contentPlaceholderPanel);
            this.contentPanel.Controls.Add(this.menuPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 64);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(12);
            this.contentPanel.Size = new System.Drawing.Size(1280, 656);
            this.contentPanel.TabIndex = 1;
            // contentPlaceholderPanel
            this.contentPlaceholderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentPlaceholderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPlaceholderPanel.Location = new System.Drawing.Point(248, 12);
            this.contentPlaceholderPanel.Name = "contentPlaceholderPanel";
            this.contentPlaceholderPanel.Size = new System.Drawing.Size(1020, 632);
            this.contentPlaceholderPanel.TabIndex = 1;
            // menuPanel
            this.menuPanel.AutoScroll = true;
            this.menuPanel.Controls.Add(this.eventsButton);
            this.menuPanel.Controls.Add(this.attendeesButton);
            this.menuPanel.Controls.Add(this.reviewsButton);
            this.menuPanel.Controls.Add(this.checkInButton);
            this.menuPanel.Controls.Add(this.dashboardButton);
            this.menuPanel.Controls.Add(this.usersButton);
            this.menuPanel.Controls.Add(this.logoutButton);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.menuPanel.Location = new System.Drawing.Point(12, 12);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.menuPanel.Size = new System.Drawing.Size(236, 632);
            this.menuPanel.TabIndex = 0;
            this.menuPanel.WrapContents = false;
            // eventsButton
            this.eventsButton.Location = new System.Drawing.Point(3, 4);
            this.eventsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.eventsButton.Name = "eventsButton";
            this.eventsButton.Size = new System.Drawing.Size(200, 40);
            this.eventsButton.TabIndex = 0;
            this.eventsButton.Text = "&Events";
            this.eventsButton.UseVisualStyleBackColor = true;
            this.eventsButton.Click += new System.EventHandler(this.eventsButton_Click);
            // attendeesButton
            this.attendeesButton.Location = new System.Drawing.Point(3, 52);
            this.attendeesButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.attendeesButton.Name = "attendeesButton";
            this.attendeesButton.Size = new System.Drawing.Size(200, 40);
            this.attendeesButton.TabIndex = 1;
            this.attendeesButton.Text = "At&tendees";
            this.attendeesButton.UseVisualStyleBackColor = true;
            this.attendeesButton.Click += new System.EventHandler(this.attendeesButton_Click);
            // reviewsButton
            this.reviewsButton.Location = new System.Drawing.Point(3, 100);
            this.reviewsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reviewsButton.Name = "reviewsButton";
            this.reviewsButton.Size = new System.Drawing.Size(200, 40);
            this.reviewsButton.TabIndex = 2;
            this.reviewsButton.Text = "&Reviews";
            this.reviewsButton.UseVisualStyleBackColor = true;
            this.reviewsButton.Click += new System.EventHandler(this.reviewsButton_Click);
            // checkInButton
            this.checkInButton.Location = new System.Drawing.Point(3, 148);
            this.checkInButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkInButton.Name = "checkInButton";
            this.checkInButton.Size = new System.Drawing.Size(200, 40);
            this.checkInButton.TabIndex = 3;
            this.checkInButton.Text = "Check-&In Scanner";
            this.checkInButton.UseVisualStyleBackColor = true;
            this.checkInButton.Click += new System.EventHandler(this.checkInButton_Click);
            // dashboardButton
            this.dashboardButton.Location = new System.Drawing.Point(3, 196);
            this.dashboardButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dashboardButton.Name = "dashboardButton";
            this.dashboardButton.Size = new System.Drawing.Size(200, 40);
            this.dashboardButton.TabIndex = 4;
            this.dashboardButton.Text = "&Live Dashboard";
            this.dashboardButton.UseVisualStyleBackColor = true;
            this.dashboardButton.Click += new System.EventHandler(this.dashboardButton_Click);
            // usersButton
            this.usersButton.Location = new System.Drawing.Point(3, 244);
            this.usersButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.usersButton.Name = "usersButton";
            this.usersButton.Size = new System.Drawing.Size(200, 40);
            this.usersButton.TabIndex = 5;
            this.usersButton.Text = "&Manage Users";
            this.usersButton.UseVisualStyleBackColor = true;
            this.usersButton.Click += new System.EventHandler(this.usersButton_Click);
            // logoutButton
            this.logoutButton.Location = new System.Drawing.Point(3, 308);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(3, 20, 3, 4);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(200, 40);
            this.logoutButton.TabIndex = 6;
            this.logoutButton.Text = "L&ogout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evently - Main Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label signedInLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel contentPlaceholderPanel;
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
