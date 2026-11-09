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

            if (Session.CurrentRole != "ADMIN")
            {
                roleComboBox.Enabled = false;
            }
        }

        private void LoadUsers()
        {
            usersDataGridView.DataSource = null;
            usersDataGridView.DataSource = UserService.GetUser();
        }

        private void AddButton_Click(object sender, EventArgs e) 
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string role = roleComboBox.Text;

            if (username == "" || password == "" || role == "") { MessageBox.Show("Please complete all fields."); return; }

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

            if (isActive == false && username == Session.CurrentUsername)
            {
                MessageBox.Show("You cannot deactivate your own account.");
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

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (usersDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Select a user first.");
                return;
            }

            string username = Convert.ToString(usersDataGridView.CurrentRow.Cells[0].Value) ?? "";
            string role = Convert.ToString(usersDataGridView.CurrentRow.Cells[1].Value) ?? "";

            // only an admin may change roles, and nobody changes their own
            bool lockRole = username == Session.CurrentUsername || Session.CurrentRole != "ADMIN";

            using UserEditForm dialog = new(username, role, lockRole);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SaveUserChanges(username, dialog.UsernameValue, dialog.RoleValue, dialog.NewPasswordValue);
            }
        }

        private void SaveUserChanges(string oldUsername, string newUsername, string role, string newPassword)
        {
            try
            {
                if (UserService.UpdateUser(oldUsername, newUsername, role, newPassword))
                {
                    if (oldUsername == Session.CurrentUsername)
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