using System;
using System.Windows.Forms;

namespace Evently.Forms
{
    public partial class EventEditForm : Form
    {
        public EventEditForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e) { /* TODO: Validate and save event */ }
        private void cancelButton_Click(object sender, EventArgs e) { Close(); }
    }
}