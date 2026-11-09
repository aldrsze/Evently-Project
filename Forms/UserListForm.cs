using _.Helpers;

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

        private void AddButton_Click(object sender, EventArgs e) { /* TODO: Add user */ }
        private void DeactivateButton_Click(object sender, EventArgs e) { /* TODO: Deactivate user */ }
        private void ReactivateButton_Click(object sender, EventArgs e) { /* TODO: Reactivate user */ }
    }
}