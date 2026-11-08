using System;
using System.Windows.Forms;

namespace Evently.Forms
{
    public partial class AttendeesForm : Form
    {
        public AttendeesForm()
        {
            InitializeComponent();
        }

        private void eventComboBox_SelectedIndexChanged(object sender, EventArgs e) { /* TODO: Load attendees */ }
        private void addAttendeeButton_Click(object sender, EventArgs e) { /* TODO: Manual register */ }
        private void importCsvButton_Click(object sender, EventArgs e) { /* TODO: Import CSV logic */ }
        private void sendTicketsButton_Click(object sender, EventArgs e) { /* TODO: Send emails */ }
        private void exportCsvButton_Click(object sender, EventArgs e) { /* TODO: Export CSV */ }
    }
}