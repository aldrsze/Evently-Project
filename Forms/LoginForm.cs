using System;
using System.Windows.Forms;
using Evently.Helpers;

namespace Evently.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            DatabaseConnection.testConnection();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            String username = usernameTextBox.Text;
            String password = passwordTextBox.Text;

            try
            {
                string? storedHash = DatabaseConnection.getPasswordHash(username);

                if (storedHash != null && PasswordHelper.verifyPassword(password, storedHash))
                {
                    MessageBox.Show("Login Successful.");
                    usernameTextBox.Text = "";
                    passwordTextBox.Text = "";
                    Hide();
                    using (var mainForm = new MainForm())
                    {
                        mainForm.ShowDialog(this);
                    }
                    Show();
                } // end if
                else
                {
                    MessageBox.Show("Invalid username or password.");
                } // end else
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            } // end catch
        } // end loginButton_Click
    } // end class
} // end namespace
