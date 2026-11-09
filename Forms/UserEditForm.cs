namespace Evently.Forms
{
    public partial class UserEditForm : Form
    {
        public UserEditForm(string username, string role, bool lockRole)
        {
            InitializeComponent();
            usernameTextBox.Text = username;
            roleComboBox.Text = role;

            if (lockRole)
            {
                // only admins change roles, and nobody changes their own
                roleComboBox.Enabled = false;
            }
        }

        // values the caller reads after the dialog closes with OK
        public string UsernameValue
        {
            get { return usernameTextBox.Text; }
        }

        public string RoleValue
        {
            get { return roleComboBox.Text; }
        }

        public string NewPasswordValue
        {
            get { return passwordTextBox.Text; }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "")
            {
                MessageBox.Show("Username is required.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
