namespace Evently.Forms
{
    public partial class EventEditForm : Form
    {
        private readonly int eventId;

        public EventEditForm()
        {
            InitializeComponent();
        }

        // used by Edit: fills the fields with the selected event
        public EventEditForm(int eventId, string name, string venue, string description, DateTime eventDate, int capacity)
        {
            InitializeComponent();
            this.eventId = eventId;
            nameTextBox.Text = name;
            venueTextBox.Text = venue;
            descriptionTextBox.Text = description;
            eventDatePicker.Value = eventDate;
            capacityNumericUpDown.Value = capacity;
        }

        // the id the caller passed in, so an update knows which row to change
        public int EventIdValue
        {
            get { return eventId; }
        }

        // TODO: validate the fields, then close with DialogResult.OK
        private void SaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
