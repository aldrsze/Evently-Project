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

        private void createButton_Click(object sender, EventArgs e) { /* TODO: Create event */ }
        private void editButton_Click(object sender, EventArgs e) { /* TODO: Edit selected event */ }
        private void deleteButton_Click(object sender, EventArgs e) { /* TODO: Delete selected event */ }
    }
}