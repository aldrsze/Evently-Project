using System;
using System.Windows.Forms;

namespace Evently.Forms
{
    public partial class MainForm : Form
    {
        private Form? currentForm;
        private bool loggingOut;

        public MainForm()
        {
            InitializeComponent();
            FormClosing += MainForm_FormClosing;
            ShowForm(new EventListForm());
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

        private void MainForm_FormClosing(object? form, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !loggingOut)
            {
                e.Cancel = true; // Prevents the window from closing
                // Optional: Show a warning message
                MessageBox.Show("Please use the designated logout button inside the app.", "Action Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            DialogResult answer = MessageBox.Show("Log out of Evently?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                loggingOut = true;
                Close();
            }
        }
    }
}
