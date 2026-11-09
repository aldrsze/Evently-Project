using _.Helpers;
using _.Services;

namespace Evently.Forms
{
    public partial class UserListForm : Form
    {
        public UserListForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            usersDataGridView.DataSource = null;
            usersDataGridView.DataSource = UserService.GetUser();
        }

        private void AddButton_Click(object sender, EventArgs e) 
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text;
            string role = roleComboBox.Text;

            if (username == "" || password == "" || role == "") { MessageBox.Show("Please complete all fields."); return; }

            if (password.Length < UserService.MinPasswordLength)
            {
                MessageBox.Show("Password must be at least " + UserService.MinPasswordLength + " characters.");
                return;
            }

            try
            {
                if (UserService.AddUser(username, password, role))
                {
                    MessageBox.Show("User added.");
                    usernameTextBox.Text = "";
                    passwordTextBox.Text = "";
                    LoadUsers();
                }
                else { MessageBox.Show("Username already used."); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void DeactivateButton_Click(object sender, EventArgs e)
        {
            SetSelectedUserActive(false);
        }

        private void ReactivateButton_Click(object sender, EventArgs e)
        {
            SetSelectedUserActive(true);
        }

        private void SetSelectedUserActive(bool isActive)
        {
            if (usersDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Select a user first.");
                return;
            }

            string username = Convert.ToString(usersDataGridView.CurrentRow.Cells[0].Value) ?? "";
            username = username.Trim();

            bool isSelf = string.Equals(username, Session.CurrentUsername, StringComparison.OrdinalIgnoreCase);

            if (isActive == false && isSelf)
            {
                MessageBox.Show("You cannot deactivate your own account.");
                return;
            }

            if (isActive == false && WouldRemoveLastAdmin(username))
            {
                MessageBox.Show("This is the last active admin. Deactivating it would lock everyone out.");
                return;
            }

            try
            {
                if (UserService.SetUserActive(username, isActive))
                {
                    if (isActive) { MessageBox.Show("User reactivated."); }
                    else { MessageBox.Show("User deactivated."); }
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("No change. The user is missing or already in that state.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private static bool WouldRemoveLastAdmin(string username)
        {
            string role = AuthService.GetRole(username) ?? "";

            if (role != "ADMIN")
            {
                return false; // not an admin, nothing to protect
            }

            return UserService.CountActiveAdmins() <= 1;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (usersDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Select a user first.");
                return;
            }

            string username = Convert.ToString(usersDataGridView.CurrentRow.Cells[0].Value) ?? "";
            string role = Convert.ToString(usersDataGridView.CurrentRow.Cells[1].Value) ?? "";

            // nobody changes their own role
            bool lockRole = string.Equals(username, Session.CurrentUsername, StringComparison.OrdinalIgnoreCase);

            using UserEditForm dialog = new(username, role, lockRole);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SaveUserChanges(username, dialog.UsernameValue, dialog.RoleValue, dialog.NewPasswordValue);
            }
        }

        private void SaveUserChanges(string oldUsername, string newUsername, string role, string newPassword)
        {
            newUsername = newUsername.Trim();

            if (newUsername == "")
            {
                MessageBox.Show("Username is required.");
                return;
            }

            if (newPassword != "" && newPassword.Length < UserService.MinPasswordLength)
            {
                MessageBox.Show("Password must be at least " + UserService.MinPasswordLength + " characters.");
                return;
            }

            if (role != "ADMIN" && WouldRemoveLastAdmin(oldUsername))
            {
                MessageBox.Show("This is the last active admin. Changing its role would lock everyone out.");
                return;
            }

            try
            {
                if (UserService.UpdateUser(oldUsername, newUsername, role, newPassword))
                {
                    if (string.Equals(oldUsername, Session.CurrentUsername, StringComparison.OrdinalIgnoreCase))
                    {
                        Session.CurrentUsername = newUsername;
                    }
                    MessageBox.Show("User updated.");
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("Username already used.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}