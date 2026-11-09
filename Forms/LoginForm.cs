using _.Helpers;
using _.Services;

namespace Evently.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            try
            {
                if (AuthService.VerifyAuth(username, password))
                {
                    Session.SignIn(username, AuthService.GetRole(username) ?? "");
                    MessageBox.Show("You are signed in. Opening Evently now.", "Signed in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    usernameTextBox.Text = "";
                    passwordTextBox.Text = "";
                    Hide();
                    using var mainForm = new MainForm();
                    mainForm.ShowDialog(this);
                    Session.SignOut();
                    Show();
                }
                else { MessageBox.Show("That username and password do not match an active account.", "Sign-in failed", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not sign in. " + ex.Message, "Sign-in error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        } // end loginButton_Click

    } // end class

} // end namespace
