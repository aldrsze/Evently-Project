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
            this.usersDataGridView = new System.Windows.Forms.DataGridView();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.roleComboBox = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.deactivateButton = new System.Windows.Forms.Button();
            this.reactivateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).BeginInit();
            this.SuspendLayout();
            // usersDataGridView
            this.usersDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.usersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDataGridView.Location = new System.Drawing.Point(12, 12);
            this.usersDataGridView.Name = "usersDataGridView";
            this.usersDataGridView.Size = new System.Drawing.Size(560, 250);
            this.usersDataGridView.TabIndex = 0;
            // usernameTextBox
            this.usernameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.usernameTextBox.Location = new System.Drawing.Point(12, 275);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.PlaceholderText = "Username";
            this.usernameTextBox.Size = new System.Drawing.Size(120, 23);
            // passwordTextBox
            this.passwordTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.passwordTextBox.Location = new System.Drawing.Point(138, 275);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PlaceholderText = "Password";
            this.passwordTextBox.Size = new System.Drawing.Size(120, 23);
            // roleComboBox
            this.roleComboBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.roleComboBox.FormattingEnabled = true;
            this.roleComboBox.Items.AddRange(new object[] { "ADMIN", "STAFF" });
            this.roleComboBox.Location = new System.Drawing.Point(264, 275);
            this.roleComboBox.Name = "roleComboBox";
            this.roleComboBox.Size = new System.Drawing.Size(100, 23);
            // addButton
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.addButton.Location = new System.Drawing.Point(370, 273);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(60, 26);
            this.addButton.Text = "Add";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // deactivateButton
            this.deactivateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.deactivateButton.Location = new System.Drawing.Point(386, 310);
            this.deactivateButton.Name = "deactivateButton";
            this.deactivateButton.Size = new System.Drawing.Size(90, 30);
            this.deactivateButton.Text = "Deactivate";
            this.deactivateButton.Click += new System.EventHandler(this.deactivateButton_Click);
            // reactivateButton
            this.reactivateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.reactivateButton.Location = new System.Drawing.Point(482, 310);
            this.reactivateButton.Name = "reactivateButton";
            this.reactivateButton.Size = new System.Drawing.Size(90, 30);
            this.reactivateButton.Text = "Reactivate";
            this.reactivateButton.Click += new System.EventHandler(this.reactivateButton_Click);
            // UserListForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 352);
            this.Controls.Add(this.usersDataGridView);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.roleComboBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.deactivateButton);
            this.Controls.Add(this.reactivateButton);
            this.Name = "UserListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Users";
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView usersDataGridView;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.ComboBox roleComboBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deactivateButton;
        private System.Windows.Forms.Button reactivateButton;
    }
}