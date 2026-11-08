using System;
using System.Windows.Forms;

namespace Evently.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void eventComboBox_SelectedIndexChanged(object sender, EventArgs e) { /* TODO: Refresh dashboard immediately */ }
        private void dashboardTimer_Tick(object sender, EventArgs e) { /* TODO: Refresh dashboard data */ }
    }
}