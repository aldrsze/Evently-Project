using System;
using System.Windows.Forms;

namespace Evently.Forms
{
    public partial class CheckInForm : Form
    {
        public CheckInForm()
        {
            InitializeComponent();
        }

        private void eventComboBox_SelectedIndexChanged(object sender, EventArgs e) { /* TODO: Setup checkin context */ }
        // TODO: Handle webcam rendering and barcode parsing
    }
}