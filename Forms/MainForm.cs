using System;
using System.Windows.Forms;

namespace Evently.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void eventsButton_Click(object sender, EventArgs e) { /* TODO: Show EventListForm */ }
        private void attendeesButton_Click(object sender, EventArgs e) { /* TODO: Show AttendeesForm */ }
        private void reviewsButton_Click(object sender, EventArgs e) { /* TODO: Show ReviewsForm */ }
        private void checkInButton_Click(object sender, EventArgs e) { /* TODO: Show CheckInForm */ }
        private void dashboardButton_Click(object sender, EventArgs e) { /* TODO: Show DashboardForm */ }
        private void usersButton_Click(object sender, EventArgs e) { /* TODO: Show UserListForm */ }
        private void logoutButton_Click(object sender, EventArgs e) { /* TODO: Handle logout */ }
    }
}