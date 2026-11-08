using System;
using System.Windows.Forms;

namespace Evently.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Hide();

            using (var mainForm = new MainForm())
            {
                mainForm.ShowDialog(this);
            }

            Show();
        }
    }
}
