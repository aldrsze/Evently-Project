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
        private void DeactivateButton_Click(object sender, EventArgs e) { /* TODO: Deactivate user */ }
        private void ReactivateButton_Click(object sender, EventArgs e) { /* TODO: Reactivate user */ }
    }
}