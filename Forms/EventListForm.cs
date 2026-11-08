using System;
using System.Windows.Forms;

namespace Evently.Forms
{
    public partial class EventListForm : Form
    {
        public EventListForm()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e) { /* TODO: Open EventEditForm for new event */ }
        private void editButton_Click(object sender, EventArgs e) { /* TODO: Open EventEditForm for selected event */ }
        private void deleteButton_Click(object sender, EventArgs e) { /* TODO: Delete selected event */ }
    }
}