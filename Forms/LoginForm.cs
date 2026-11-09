using Evently.Services;

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
            String username = usernameTextBox.Text;
            String password = passwordTextBox.Text;

            if (AuthService.VerifyAuth(username, password))
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
            }
            else { MessageBox.Show("Invalid username or password."); }

        } // end loginButton_Click

    } // end class

} // end namespace
