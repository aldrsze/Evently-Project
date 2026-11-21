using System;
using System.Data;
using System.Windows.Forms;
using Evently.Core.Services;

namespace Evently.Forms
{
    public partial class AttendeesForm : Form
    {
        public AttendeesForm()
        {
            InitializeComponent();
            attendeesDataGridView.AutoGenerateColumns = false;
            LoadEvents();
        }

        private void LoadEvents()
        {
            DataTable eventsTable = EventService.GetEvent();
            eventComboBox.DisplayMember = "name";
            eventComboBox.ValueMember = "event_id";
            eventComboBox.DataSource = eventsTable;

            if (eventComboBox.SelectedValue != null && int.TryParse(eventComboBox.SelectedValue.ToString(), out int eventId))
            {
                LoadAttendees(eventId);
            }
        }

        private void LoadAttendees(int eventId)
        {
            attendeesDataGridView.DataSource = TicketService.GetAttendeesByEvent(eventId);
        }

        private void EventComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (eventComboBox.SelectedValue != null && int.TryParse(eventComboBox.SelectedValue.ToString(), out int eventId))
            {
                LoadAttendees(eventId);
            }
        }

        private void AddAttendeeButton_Click(object sender, EventArgs e)
        {
            if (eventComboBox.SelectedValue == null || !int.TryParse(eventComboBox.SelectedValue.ToString(), out int eventId))
            {
                MessageBox.Show("Select an event first.", "No Event", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string firstName = firstNameTextBox.Text.Trim();
            string lastName = lastNameTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();
            DateTime birthdate = birthdateDateTimePicker.Value;

            if (firstName == "" || lastName == "" || email == "")
            {
                MessageBox.Show("Fill in first name, last name, and email.", "Add Attendee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!email.Contains('@') || !email.Contains('.'))
            {
                MessageBox.Show("Enter a valid email address.", "Add Attendee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (TicketService.AddAttendee(eventId, firstName, lastName, email, birthdate))
                {
                    MessageBox.Show("Attendee added to event.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    firstNameTextBox.Clear();
                    lastNameTextBox.Clear();
                    emailTextBox.Clear();
                    birthdateDateTimePicker.Value = DateTime.Today;
                    LoadAttendees(eventId);
                }
                else
                {
                    MessageBox.Show("Could not add attendee. The attendee may already be registered for this event.", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving attendee: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (attendeesDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Select an attendee in the list first.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (eventComboBox.SelectedValue == null || !int.TryParse(eventComboBox.SelectedValue.ToString(), out int eventId))
            {
                return;
            }

            int attendeeId = Convert.ToInt32(attendeesDataGridView.CurrentRow.Cells["attendeeIdColumn"].Value);
            string firstName = Convert.ToString(attendeesDataGridView.CurrentRow.Cells["firstNameColumn"].Value) ?? "";
            string lastName = Convert.ToString(attendeesDataGridView.CurrentRow.Cells["lastNameColumn"].Value) ?? "";
            string email = Convert.ToString(attendeesDataGridView.CurrentRow.Cells["emailColumn"].Value) ?? "";
            DateTime birthdate = DateTime.Today;
            object? bVal = attendeesDataGridView.CurrentRow.Cells["birthdateColumn"].Value;
            if (bVal != null && bVal != DBNull.Value && DateTime.TryParse(bVal.ToString(), out DateTime parsed))
            {
                birthdate = parsed;
            }

            using AttendeeEditForm dialog = new(attendeeId, firstName, lastName, email, birthdate);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    if (TicketService.UpdateAttendee(dialog.AttendeeIdValue, dialog.FirstNameValue, dialog.LastNameValue, dialog.EmailValue, dialog.BirthdateValue))
                    {
                        MessageBox.Show("Attendee updated.", "Attendee saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAttendees(eventId);
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Email may already be in use.", "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The change could not be saved. " + ex.Message, "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (attendeesDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Select an attendee in the list first.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (eventComboBox.SelectedValue == null || !int.TryParse(eventComboBox.SelectedValue.ToString(), out int eventId))
            {
                return;
            }

            int attendeeId = Convert.ToInt32(attendeesDataGridView.CurrentRow.Cells["attendeeIdColumn"].Value);
            string attendeeName = Convert.ToString(attendeesDataGridView.CurrentRow.Cells["attendeeNameColumn"].Value) ?? "this attendee";

            DialogResult confirm = MessageBox.Show(
                $"Remove '{attendeeName}' from this event?\n\nWarning: This will also delete their ticket for this event.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (TicketService.DeleteAttendee(eventId, attendeeId))
                    {
                        MessageBox.Show("Attendee removed.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAttendees(eventId);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not remove attendee: " + ex.Message, "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ImportCsvButton_Click(object sender, EventArgs e) { /* TODO: Import CSV logic */ }

        private void SendTicketsButton_Click(object sender, EventArgs e)
        {
            if (eventComboBox.SelectedValue == null || !int.TryParse(eventComboBox.SelectedValue.ToString(), out int eventId))
            {
                MessageBox.Show("Please select an event first.", "Send Tickets", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable unemailedTickets = TicketService.GetUnemailedTicketsByEvent(eventId);
            if (unemailedTickets.Rows.Count == 0)
            {
                MessageBox.Show("All attendees for this event have already received their tickets.", "Send Tickets", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int sentCount = 0;
            int failedCount = 0;

            foreach (DataRow row in unemailedTickets.Rows)
            {
                string ticketId = row["ticket_id"].ToString() ?? "";
                string recipientEmail = row["email"].ToString() ?? "";
                string attendeeName = row["attendee_name"].ToString() ?? "";
                string eventName = row["event_name"].ToString() ?? "";
                string venue = row["venue"].ToString() ?? "";
                DateTime eventDate = Convert.ToDateTime(row["event_date"]);

                bool success = EmailService.SendTicketEmail(recipientEmail, attendeeName, eventName, venue, eventDate, ticketId);
                if (success)
                {
                    TicketService.MarkTicketAsEmailed(ticketId);
                    sentCount++;
                }
                else
                {
                    failedCount++;
                }
            }

            string resultMsg = $"Tickets sent: {sentCount}";
            if (failedCount > 0)
            {
                resultMsg += $"\nFailed: {failedCount}";
            }

            resultLabel.Text = resultMsg;
            MessageBox.Show(resultMsg, "Send Tickets", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportCsvButton_Click(object sender, EventArgs e) { /* TODO: Export CSV */ }
    }
}
