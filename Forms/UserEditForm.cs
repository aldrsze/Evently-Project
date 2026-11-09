using _.Services;

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
                // nobody changes their own role
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
            string username = usernameTextBox.Text.Trim();

            if (username == "")
            {
                MessageBox.Show("Enter a username.", "Edit account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (passwordTextBox.Text != "" && passwordTextBox.Text.Length < UserService.MinPasswordLength)
            {
                MessageBox.Show("Use at least " + UserService.MinPasswordLength + " characters for the password.", "Edit account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            usernameTextBox.Text = username;
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
