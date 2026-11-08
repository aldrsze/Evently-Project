#nullable disable
namespace Evently.Forms
{
    partial class LoginForm
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
            this.centerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.loginHintLabel = new System.Windows.Forms.Label();
            this.reassuranceLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.centerLayoutPanel.SuspendLayout();
            this.loginPanel.SuspendLayout();
            this.SuspendLayout();
            // headerPanel
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.heroSublineLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
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
            this.titleLabel.Size = new System.Drawing.Size(77, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Evently";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // heroSublineLabel
            this.heroSublineLabel.AutoSize = true;
            this.heroSublineLabel.BackColor = System.Drawing.Color.Transparent;
            this.heroSublineLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.heroSublineLabel.ForeColor = System.Drawing.Color.FromArgb(218, 230, 245);
            this.heroSublineLabel.Location = new System.Drawing.Point(12, 38);
            this.heroSublineLabel.Name = "heroSublineLabel";
            this.heroSublineLabel.Size = new System.Drawing.Size(462, 15);
            this.heroSublineLabel.TabIndex = 1;
            this.heroSublineLabel.Text = "Register attendees, issue QR tickets, and monitor venue capacity in real time.";
            this.heroSublineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.centerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.centerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerLayoutPanel.Controls.Add(this.loginPanel, 1, 1);
            this.centerLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.centerLayoutPanel.Name = "centerLayoutPanel";
            this.centerLayoutPanel.RowCount = 3;
            this.centerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.centerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerLayoutPanel.Size = new System.Drawing.Size(1256, 632);
            this.centerLayoutPanel.TabIndex = 0;
            // loginPanel
            this.loginPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginPanel.BackColor = System.Drawing.Color.White;
            this.loginPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginPanel.Controls.Add(this.usernameLabel);
            this.loginPanel.Controls.Add(this.usernameTextBox);
            this.loginPanel.Controls.Add(this.passwordLabel);
            this.loginPanel.Controls.Add(this.passwordTextBox);
            this.loginPanel.Controls.Add(this.errorLabel);
            this.loginPanel.Controls.Add(this.loginHintLabel);
            this.loginPanel.Controls.Add(this.reassuranceLabel);
            this.loginPanel.Controls.Add(this.loginButton);
            this.loginPanel.Location = new System.Drawing.Point(428, 206);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(400, 220);
            this.loginPanel.TabIndex = 0;
            // usernameLabel
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(24, 32);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username:";
            // usernameTextBox
            this.usernameTextBox.Location = new System.Drawing.Point(120, 29);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(250, 23);
            this.usernameTextBox.TabIndex = 1;
            // passwordLabel
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(24, 72);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password:";
            // passwordTextBox
            this.passwordTextBox.Location = new System.Drawing.Point(120, 69);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(250, 23);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // errorLabel
            this.errorLabel.AutoSize = false;
            this.errorLabel.Location = new System.Drawing.Point(24, 100);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(350, 18);
            this.errorLabel.TabIndex = 4;
            this.errorLabel.Text = "";
            // loginHintLabel
            this.loginHintLabel.AutoSize = true;
            this.loginHintLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.loginHintLabel.ForeColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.loginHintLabel.Location = new System.Drawing.Point(24, 126);
            this.loginHintLabel.Name = "loginHintLabel";
            this.loginHintLabel.Size = new System.Drawing.Size(326, 13);
            this.loginHintLabel.TabIndex = 6;
            this.loginHintLabel.Text = "Sign in with your assigned administrator or staff credentials";
            // reassuranceLabel
            this.reassuranceLabel.AutoSize = true;
            this.reassuranceLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.reassuranceLabel.ForeColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.reassuranceLabel.Location = new System.Drawing.Point(24, 170);
            this.reassuranceLabel.Name = "reassuranceLabel";
            this.reassuranceLabel.Size = new System.Drawing.Size(222, 13);
            this.reassuranceLabel.TabIndex = 7;
            this.reassuranceLabel.Text = "Data stays stored in your local database";
            // loginButton
            this.loginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.Location = new System.Drawing.Point(286, 160);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(90, 30);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "&Login";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // LoginForm
            this.AcceptButton = this.loginButton;
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
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evently - Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.centerLayoutPanel.ResumeLayout(false);
            this.centerLayoutPanel.PerformLayout();
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.TableLayoutPanel centerLayoutPanel;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label loginHintLabel;
        private System.Windows.Forms.Label reassuranceLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label heroSublineLabel;
    }
}
