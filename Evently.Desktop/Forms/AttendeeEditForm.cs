using System;
using System.Windows.Forms;

namespace Evently.Forms
{
    public partial class AttendeeEditForm : Form
    {
        private readonly int attendeeId;

        public AttendeeEditForm()
        {
            InitializeComponent();
        }

        public AttendeeEditForm(int attendeeId, string firstName, string lastName, string email, DateTime birthdate)
        {
            InitializeComponent();
            this.attendeeId = attendeeId;
            firstNameTextBox.Text = firstName;
            lastNameTextBox.Text = lastName;
            emailTextBox.Text = email;
            birthdatePicker.Value = birthdate;
        }

        public int AttendeeIdValue
        {
            get { return attendeeId; }
        }

        public string FirstNameValue
        {
            get { return firstNameTextBox.Text.Trim(); }
        }

        public string LastNameValue
        {
            get { return lastNameTextBox.Text.Trim(); }
        }

        public string EmailValue
        {
            get { return emailTextBox.Text.Trim(); }
        }

        public DateTime BirthdateValue
        {
            get { return birthdatePicker.Value; }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (firstNameTextBox.Text.Trim() == "" || lastNameTextBox.Text.Trim() == "" || emailTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Fill in first name, last name, and email.", "Attendee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email = emailTextBox.Text.Trim();
            if (!email.Contains('@') || !email.Contains('.'))
            {
                MessageBox.Show("Enter a valid email address.", "Attendee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
