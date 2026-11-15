namespace Evently.Forms
{
    partial class UserEditForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.roleLabel = new System.Windows.Forms.Label();
            this.roleComboBox = new System.Windows.Forms.ComboBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordHintLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // usernameLabel
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(24, 24);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(63, 15);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username:";
            // usernameTextBox
            this.usernameTextBox.Location = new System.Drawing.Point(140, 21);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(240, 23);
            this.usernameTextBox.TabIndex = 1;
            // roleLabel
            this.roleLabel.AutoSize = true;
            this.roleLabel.Location = new System.Drawing.Point(24, 64);
            this.roleLabel.Name = "roleLabel";
            this.roleLabel.Size = new System.Drawing.Size(33, 15);
            this.roleLabel.TabIndex = 2;
            this.roleLabel.Text = "Role:";
            // roleComboBox
            this.roleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleComboBox.FormattingEnabled = true;
            this.roleComboBox.Items.AddRange(new object[] { "ADMIN", "STAFF" });
            this.roleComboBox.Location = new System.Drawing.Point(140, 61);
            this.roleComboBox.Name = "roleComboBox";
            this.roleComboBox.Size = new System.Drawing.Size(140, 23);
            this.roleComboBox.TabIndex = 3;
            // passwordLabel
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(24, 104);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(87, 15);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "New password:";
            // passwordTextBox
            this.passwordTextBox.Location = new System.Drawing.Point(140, 101);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(240, 23);
            this.passwordTextBox.TabIndex = 5;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // passwordHintLabel
            this.passwordHintLabel.AutoSize = true;
            this.passwordHintLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.passwordHintLabel.ForeColor = System.Drawing.Color.FromArgb(95, 95, 95);
            this.passwordHintLabel.Location = new System.Drawing.Point(140, 128);
            this.passwordHintLabel.Name = "passwordHintLabel";
            this.passwordHintLabel.Size = new System.Drawing.Size(230, 15);
            this.passwordHintLabel.TabIndex = 6;
            this.passwordHintLabel.Text = "Leave blank to keep the current password.";
            // saveButton
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(210, 200);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(80, 30);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // cancelButton
            this.cancelButton.Location = new System.Drawing.Point(300, 200);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(80, 30);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // UserEditForm
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(404, 256);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.roleLabel);
            this.Controls.Add(this.roleComboBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordHintLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserEditForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit User";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label roleLabel;
        private System.Windows.Forms.ComboBox roleComboBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordHintLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
