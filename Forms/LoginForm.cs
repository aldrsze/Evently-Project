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
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        } // end loginButton_Click

    } // end class

} // end namespace
