using _.Helpers;

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
            DatabaseConnection.TestConnection();
        }

        private void ShowForm(Form form)
        {
            if (currentForm != null) // if form is already shown on the panel detach it.
            {
                contentPlaceholderPanel.Controls.Remove(currentForm); // take it off the panel first
                currentForm.Dispose(); // Dispose frees the old form's controls and memory
            }

            // keep the new form in currentForm so the next call can dispose it
            currentForm = form;
            form.WindowState = FormWindowState.Normal; // Normal makes the DoctStyle.Fill possible
            form.FormBorderStyle = FormBorderStyle.None; // removes title bar
            form.TopLevel = false; // must be false, a top level form cannot be added to a panel
            form.MinimumSize = new System.Drawing.Size(0, 0); // stops shrinking
            form.Dock = DockStyle.Fill; // follows the panel when the window resizes
            contentPlaceholderPanel.Controls.Add(form); // puts the form inside the panel
            form.Show(); // adding a child form does not show it, Show does
        }

        private void EventsButton_Click(object sender, EventArgs e)
        {
            ShowForm(new EventListForm());
        }

        private void AttendeesButton_Click(object sender, EventArgs e)
        {
            ShowForm(new AttendeesForm());
        }

        private void ManagersButton_Click(object sender, EventArgs e)
        {
            ShowForm(new OrganizersForm());
        }

        private void ReviewsButton_Click(object sender, EventArgs e)
        {
            ShowForm(new ReviewsForm());
        }

        private void CheckInButton_Click(object sender, EventArgs e)
        {
            ShowForm(new CheckInForm());
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            ShowForm(new DashboardForm());
        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            ShowForm(new UserListForm());
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Log out of Evently? You will need your password to sign in again.", "Confirm logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                loggingOut = true;
                Close();
            }
        }

        private void MainForm_FormClosing(object? form, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !loggingOut)
            {
                e.Cancel = true; // Prevents the window from closing
                // Optional: Show a warning message
                MessageBox.Show("Close this window with Log out in the sidebar.", "Use Log out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
