using System;
using System.Windows.Forms;
using Evently.Core.Services;

namespace Evently.Forms
{
    public partial class EventListForm : Form
    {
        public EventListForm()
        {
            InitializeComponent();
            LoadEvents();
        }

        private void LoadEvents()
        {
            eventsDataGridView.DataSource = null;
            eventsDataGridView.DataSource = EventService.GetEvent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text.Trim();
            string venue = venueTextBox.Text.Trim();
            DateTime date = eventDatePicker.Value;
            int capacity =  (int) capacityNumericUpDown.Value;
            string desc = descriptionTextBox.Text;

            if (name == "" || venue == "" || desc == "")
            { 
                MessageBox.Show("Fill in name, venue, and description.", "Add event", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                return; 
            }

            try
            {
                if (EventService.AddEvent(name, venue, desc, date, capacity))
                {
                    MessageBox.Show("Event created.", "Event added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nameTextBox.Clear();
                    venueTextBox.Clear();
                    eventDatePicker.Value = DateTime.Now;
                    capacityNumericUpDown.Value = 100;
                    descriptionTextBox.Clear();
                    LoadEvents();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("The change could not be saved. " + ex.Message, "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditButton_Click(object sender, EventArgs e) 
        {
            if (eventsDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Select an event in the list first.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int eventId = Convert.ToInt32(eventsDataGridView.CurrentRow.Cells[0].Value);
            string name = Convert.ToString(eventsDataGridView.CurrentRow.Cells[1].Value) ?? "";
            string venue = Convert.ToString(eventsDataGridView.CurrentRow.Cells[2].Value) ?? "";
            DateTime eventDate = Convert.ToDateTime(eventsDataGridView.CurrentRow.Cells[3].Value);
            int capacity = Convert.ToInt32(eventsDataGridView.CurrentRow.Cells[4].Value);
            string description = Convert.ToString(eventsDataGridView.CurrentRow.Cells[5].Value) ?? "";

            using EventEditForm dialog = new(eventId, name, venue, description, eventDate, capacity);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                // TODO: save with EventService.UpdateEvent(eventId, ...) before reloading
                LoadEvents();
            }
        }
        private void DeleteButton_Click(object sender, EventArgs e) { /* TODO: Delete selected event */ }
    }
}