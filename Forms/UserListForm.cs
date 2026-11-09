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

            if (username == "" || password == "" || role == "") { MessageBox.Show("Fill in username, password, and role.", "Add account", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (password.Length < UserService.MinPasswordLength)
            {
                MessageBox.Show("Use at least " + UserService.MinPasswordLength + " characters for the password.", "Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (UserService.AddUser(username, password, role))
                {
                    MessageBox.Show("Account created. It can sign in right away.", "Account added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    usernameTextBox.Text = "";
                    passwordTextBox.Text = "";
                    LoadUsers();
                }
                else { MessageBox.Show("That username is already taken. Choose another one.", "Username taken", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The change could not be saved. " + ex.Message, "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Select a user in the list first.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = Convert.ToString(usersDataGridView.CurrentRow.Cells[0].Value) ?? "";
            username = username.Trim();

            bool isSelf = string.Equals(username, Session.CurrentUsername, StringComparison.OrdinalIgnoreCase);

            if (isActive == false && isSelf)
            {
                MessageBox.Show("You cannot deactivate the account you are signed in with.", "Own account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isActive == false && WouldRemoveLastAdmin(username))
            {
                MessageBox.Show("This is the only active admin. Create another admin before deactivating this one.", "Last active admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (UserService.SetUserActive(username, isActive))
                {
                    if (isActive) { MessageBox.Show("Account reactivated. It can sign in again.", "Account updated", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else { MessageBox.Show("Account deactivated. It can no longer sign in.", "Account updated", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("Nothing changed. The account is missing or already in that state.", "No change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The change could not be saved. " + ex.Message, "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Select a user in the list first.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Enter a username.", "Edit account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != "" && newPassword.Length < UserService.MinPasswordLength)
            {
                MessageBox.Show("Use at least " + UserService.MinPasswordLength + " characters for the password.", "Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (role != "ADMIN" && WouldRemoveLastAdmin(oldUsername))
            {
                MessageBox.Show("This is the only active admin. Give another account the admin role first.", "Last active admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (UserService.UpdateUser(oldUsername, newUsername, role, newPassword))
                {
                    if (string.Equals(oldUsername, Session.CurrentUsername, StringComparison.OrdinalIgnoreCase))
                    {
                        Session.RenameCurrentUser(newUsername);
                    }
                    MessageBox.Show("Account updated.", "Account saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("That username is already taken. Choose another one.", "Username taken", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The change could not be saved. " + ex.Message, "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}