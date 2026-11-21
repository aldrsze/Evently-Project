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
        }
        private void DeleteButton_Click(object sender, EventArgs e) { /* TODO: Delete selected event */ }
    }
}