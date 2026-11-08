#nullable disable
namespace Evently.Forms
{
    partial class AttendeesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.eventComboBox = new System.Windows.Forms.ComboBox();
            this.attendeesDataGridView = new System.Windows.Forms.DataGridView();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.addAttendeeButton = new System.Windows.Forms.Button();
            this.importCsvButton = new System.Windows.Forms.Button();
            this.sendTicketsButton = new System.Windows.Forms.Button();
            this.exportCsvButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.attendeesDataGridView)).BeginInit();
            this.SuspendLayout();
            // eventComboBox
            this.eventComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.eventComboBox.FormattingEnabled = true;
            this.eventComboBox.Location = new System.Drawing.Point(12, 12);
            this.eventComboBox.Name = "eventComboBox";
            this.eventComboBox.Size = new System.Drawing.Size(660, 23);
            this.eventComboBox.SelectedIndexChanged += new System.EventHandler(this.eventComboBox_SelectedIndexChanged);
            // attendeesDataGridView
            this.attendeesDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.attendeesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.attendeesDataGridView.Location = new System.Drawing.Point(12, 45);
            this.attendeesDataGridView.Name = "attendeesDataGridView";
            this.attendeesDataGridView.Size = new System.Drawing.Size(660, 300);
            // nameTextBox
            this.nameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.nameTextBox.Location = new System.Drawing.Point(12, 355);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.PlaceholderText = "Full Name";
            this.nameTextBox.Size = new System.Drawing.Size(150, 23);
            // emailTextBox
            this.emailTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.emailTextBox.Location = new System.Drawing.Point(168, 355);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.PlaceholderText = "Email Address";
            this.emailTextBox.Size = new System.Drawing.Size(150, 23);
            // addAttendeeButton
            this.addAttendeeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.addAttendeeButton.Location = new System.Drawing.Point(324, 353);
            this.addAttendeeButton.Name = "addAttendeeButton";
            this.addAttendeeButton.Size = new System.Drawing.Size(70, 27);
            this.addAttendeeButton.Text = "Add";
            this.addAttendeeButton.Click += new System.EventHandler(this.addAttendeeButton_Click);
            // resultLabel
            this.resultLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(405, 359);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Text = "";
            // importCsvButton
            this.importCsvButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.importCsvButton.Location = new System.Drawing.Point(374, 395);
            this.importCsvButton.Name = "importCsvButton";
            this.importCsvButton.Size = new System.Drawing.Size(95, 30);
            this.importCsvButton.Text = "Import CSV";
            this.importCsvButton.Click += new System.EventHandler(this.importCsvButton_Click);
            // sendTicketsButton
            this.sendTicketsButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.sendTicketsButton.Location = new System.Drawing.Point(475, 395);
            this.sendTicketsButton.Name = "sendTicketsButton";
            this.sendTicketsButton.Size = new System.Drawing.Size(95, 30);
            this.sendTicketsButton.Text = "Send Tickets";
            this.sendTicketsButton.Click += new System.EventHandler(this.sendTicketsButton_Click);
            // exportCsvButton
            this.exportCsvButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.exportCsvButton.Location = new System.Drawing.Point(576, 395);
            this.exportCsvButton.Name = "exportCsvButton";
            this.exportCsvButton.Size = new System.Drawing.Size(95, 30);
            this.exportCsvButton.Text = "Export CSV";
            this.exportCsvButton.Click += new System.EventHandler(this.exportCsvButton_Click);
            // AttendeesForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 441);
            this.Controls.Add(this.eventComboBox);
            this.Controls.Add(this.attendeesDataGridView);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.addAttendeeButton);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.importCsvButton);
            this.Controls.Add(this.sendTicketsButton);
            this.Controls.Add(this.exportCsvButton);
            this.Name = "AttendeesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Attendees";
            ((System.ComponentModel.ISupportInitialize)(this.attendeesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox eventComboBox;
        private System.Windows.Forms.DataGridView attendeesDataGridView;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Button addAttendeeButton;
        private System.Windows.Forms.Button importCsvButton;
        private System.Windows.Forms.Button sendTicketsButton;
        private System.Windows.Forms.Button exportCsvButton;
        private System.Windows.Forms.Label resultLabel;
    }
}