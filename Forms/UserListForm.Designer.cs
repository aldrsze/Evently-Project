#nullable disable
namespace Evently.Forms
{
    partial class UserListForm
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
            this.usersDataGridView = new System.Windows.Forms.DataGridView();
            this.usernameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addUserWrapperPanel = new System.Windows.Forms.Panel();
            this.addUserGroupBox = new System.Windows.Forms.GroupBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.roleLabel = new System.Windows.Forms.Label();
            this.roleComboBox = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.deactivateButton = new System.Windows.Forms.Button();
            this.reactivateButton = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).BeginInit();
            this.addUserWrapperPanel.SuspendLayout();
            this.addUserGroupBox.SuspendLayout();
            this.actionPanel.SuspendLayout();
            this.SuspendLayout();
            // headerPanel
            this.headerPanel.Controls.Add(this.titleLabel);
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
            this.titleLabel.Size = new System.Drawing.Size(1256, 64);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Manage Users";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // contentPanel
            this.contentPanel.Controls.Add(this.usersDataGridView);
            this.contentPanel.Controls.Add(this.addUserWrapperPanel);
            this.contentPanel.Controls.Add(this.actionPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 64);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(12);
            this.contentPanel.Size = new System.Drawing.Size(1280, 656);
            this.contentPanel.TabIndex = 1;
            // usersDataGridView
            this.usersDataGridView.AllowUserToAddRows = false;
            this.usersDataGridView.AllowUserToDeleteRows = false;
            this.usersDataGridView.AllowUserToResizeRows = false;
            this.usersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.usersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usernameColumn,
            this.roleColumn,
            this.activeColumn});
            this.usersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usersDataGridView.Location = new System.Drawing.Point(12, 12);
            this.usersDataGridView.MultiSelect = false;
            this.usersDataGridView.Name = "usersDataGridView";
            this.usersDataGridView.ReadOnly = true;
            this.usersDataGridView.RowHeadersVisible = false;
            this.usersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersDataGridView.Size = new System.Drawing.Size(1256, 484);
            this.usersDataGridView.TabIndex = 0;
            // usernameColumn
            this.usernameColumn.HeaderText = "Username";
            this.usernameColumn.Name = "usernameColumn";
            this.usernameColumn.ReadOnly = true;
            // roleColumn
            this.roleColumn.HeaderText = "Role";
            this.roleColumn.Name = "roleColumn";
            this.roleColumn.ReadOnly = true;
            // activeColumn
            this.activeColumn.HeaderText = "Active";
            this.activeColumn.Name = "activeColumn";
            this.activeColumn.ReadOnly = true;
            // addUserWrapperPanel
            this.addUserWrapperPanel.Controls.Add(this.addUserGroupBox);
            this.addUserWrapperPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.addUserWrapperPanel.Location = new System.Drawing.Point(12, 496);
            this.addUserWrapperPanel.Name = "addUserWrapperPanel";
            this.addUserWrapperPanel.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.addUserWrapperPanel.Size = new System.Drawing.Size(1256, 102);
            this.addUserWrapperPanel.TabIndex = 1;
            // addUserGroupBox
            this.addUserGroupBox.Controls.Add(this.usernameLabel);
            this.addUserGroupBox.Controls.Add(this.usernameTextBox);
            this.addUserGroupBox.Controls.Add(this.passwordLabel);
            this.addUserGroupBox.Controls.Add(this.passwordTextBox);
            this.addUserGroupBox.Controls.Add(this.roleLabel);
            this.addUserGroupBox.Controls.Add(this.roleComboBox);
            this.addUserGroupBox.Controls.Add(this.addButton);
            this.addUserGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addUserGroupBox.Location = new System.Drawing.Point(0, 16);
            this.addUserGroupBox.Name = "addUserGroupBox";
            this.addUserGroupBox.Size = new System.Drawing.Size(1256, 86);
            this.addUserGroupBox.TabIndex = 0;
            this.addUserGroupBox.TabStop = false;
            this.addUserGroupBox.Text = "Add User";
            // usernameLabel
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(12, 29);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username:";
            // usernameTextBox
            this.usernameTextBox.Location = new System.Drawing.Point(82, 26);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(140, 23);
            this.usernameTextBox.TabIndex = 1;
            // passwordLabel
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(238, 29);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password:";
            // passwordTextBox
            this.passwordTextBox.Location = new System.Drawing.Point(306, 26);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(140, 23);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // roleLabel
            this.roleLabel.AutoSize = true;
            this.roleLabel.Location = new System.Drawing.Point(462, 29);
            this.roleLabel.Name = "roleLabel";
            this.roleLabel.TabIndex = 4;
            this.roleLabel.Text = "Role:";
            // roleComboBox
            this.roleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleComboBox.FormattingEnabled = true;
            this.roleComboBox.Items.AddRange(new object[] { "ADMIN", "STAFF" });
            this.roleComboBox.Location = new System.Drawing.Point(504, 26);
            this.roleComboBox.Name = "roleComboBox";
            this.roleComboBox.Size = new System.Drawing.Size(100, 23);
            this.roleComboBox.TabIndex = 5;
            // addButton
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.addButton.Location = new System.Drawing.Point(1154, 26);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(90, 30);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "&Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // actionPanel
            this.actionPanel.Controls.Add(this.deactivateButton);
            this.actionPanel.Controls.Add(this.reactivateButton);
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.actionPanel.Location = new System.Drawing.Point(12, 598);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(1256, 54);
            this.actionPanel.TabIndex = 2;
            // deactivateButton
            this.deactivateButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.deactivateButton.Location = new System.Drawing.Point(1068, 16);
            this.deactivateButton.Name = "deactivateButton";
            this.deactivateButton.Size = new System.Drawing.Size(90, 30);
            this.deactivateButton.TabIndex = 0;
            this.deactivateButton.Text = "&Deactivate";
            this.deactivateButton.UseVisualStyleBackColor = true;
            this.deactivateButton.Click += new System.EventHandler(this.deactivateButton_Click);
            // reactivateButton
            this.reactivateButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.reactivateButton.Location = new System.Drawing.Point(1166, 16);
            this.reactivateButton.Name = "reactivateButton";
            this.reactivateButton.Size = new System.Drawing.Size(90, 30);
            this.reactivateButton.TabIndex = 1;
            this.reactivateButton.Text = "&Reactivate";
            this.reactivateButton.UseVisualStyleBackColor = true;
            this.reactivateButton.Click += new System.EventHandler(this.reactivateButton_Click);
            // UserListForm
            this.AcceptButton = this.addButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "UserListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Users";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).EndInit();
            this.addUserWrapperPanel.ResumeLayout(false);
            this.addUserGroupBox.ResumeLayout(false);
            this.addUserGroupBox.PerformLayout();
            this.actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.DataGridView usersDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn activeColumn;
        private System.Windows.Forms.Panel addUserWrapperPanel;
        private System.Windows.Forms.GroupBox addUserGroupBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label roleLabel;
        private System.Windows.Forms.ComboBox roleComboBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.Button deactivateButton;
        private System.Windows.Forms.Button reactivateButton;
    }
}
