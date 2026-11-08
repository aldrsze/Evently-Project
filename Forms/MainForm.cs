using System;
using System.Windows.Forms;

namespace Evently.Forms
{
    public partial class MainForm : Form
    {
        private Form? currentForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ShowForm(Form form)
        {
            if (currentForm != null)
            {
                contentPlaceholderPanel.Controls.Remove(currentForm);
                currentForm.Dispose();
            }

            currentForm = form;
            form.WindowState = FormWindowState.Normal;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.MinimumSize = new System.Drawing.Size(0, 0);
            form.Dock = DockStyle.Fill;
            contentPlaceholderPanel.Controls.Add(form);
            form.Show();
        }

        private void eventsButton_Click(object sender, EventArgs e)
        {
            ShowForm(new EventListForm());
        }

        private void attendeesButton_Click(object sender, EventArgs e)
        {
            ShowForm(new AttendeesForm());
        }

        private void reviewsButton_Click(object sender, EventArgs e)
        {
            ShowForm(new ReviewsForm());
        }

        private void checkInButton_Click(object sender, EventArgs e)
        {
            ShowForm(new CheckInForm());
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            ShowForm(new DashboardForm());
        }

        private void usersButton_Click(object sender, EventArgs e)
        {
            ShowForm(new UserListForm());
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
