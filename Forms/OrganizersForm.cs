using System;
using System.Windows.Forms;

namespace Evently.Forms
{
    public partial class OrganizersForm : Form
    {
        public OrganizersForm()
        {
            InitializeComponent();
        }

        private void eventComboBox_SelectedIndexChanged(object sender, EventArgs e) { /* TODO: Load managers for event */ }
        private void addManagerButton_Click(object sender, EventArgs e) { /* TODO: Save organizer and link to event */ }
        private void removeManagerButton_Click(object sender, EventArgs e) { /* TODO: Unlink selected manager */ }
    }
}
