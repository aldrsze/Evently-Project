using System;
using System.Windows.Forms;

namespace Evently.Forms
{
    public partial class ReviewsForm : Form
    {
        public ReviewsForm()
        {
            InitializeComponent();
        }

        private void eventComboBox_SelectedIndexChanged(object sender, EventArgs e) { /* TODO: Load URL */ }
        private void saveUrlButton_Click(object sender, EventArgs e) { /* TODO: Save URL */ }
        private void sendRequestButton_Click(object sender, EventArgs e) { /* TODO: Send rating request emails */ }
        private void importReviewsButton_Click(object sender, EventArgs e) { /* TODO: Import review CSV */ }
    }
}