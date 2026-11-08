#nullable disable
namespace Evently.Forms
{
    partial class EventEditForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.venueLabel = new System.Windows.Forms.Label();
            this.venueTextBox = new System.Windows.Forms.TextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.capacityLabel = new System.Windows.Forms.Label();
            this.capacityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.descLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.capacityNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // nameLabel
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Text = "Name:";
            // nameTextBox
            this.nameTextBox.Location = new System.Drawing.Point(90, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(282, 23);
            // venueLabel
            this.venueLabel.AutoSize = true;
            this.venueLabel.Location = new System.Drawing.Point(12, 47);
            this.venueLabel.Name = "venueLabel";
            this.venueLabel.Text = "Venue:";
            // venueTextBox
            this.venueTextBox.Location = new System.Drawing.Point(90, 44);
            this.venueTextBox.Name = "venueTextBox";
            this.venueTextBox.Size = new System.Drawing.Size(282, 23);
            // dateLabel
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(12, 79);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Text = "Date / Time:";
            // datePicker
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(90, 76);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(120, 23);
            // timePicker
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.Location = new System.Drawing.Point(216, 76);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(110, 23);
            // capacityLabel
            this.capacityLabel.AutoSize = true;
            this.capacityLabel.Location = new System.Drawing.Point(12, 111);
            this.capacityLabel.Name = "capacityLabel";
            this.capacityLabel.Text = "Capacity:";
            // capacityNumericUpDown
            this.capacityNumericUpDown.Location = new System.Drawing.Point(90, 108);
            this.capacityNumericUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.capacityNumericUpDown.Name = "capacityNumericUpDown";
            this.capacityNumericUpDown.Size = new System.Drawing.Size(120, 23);
            // descLabel
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(12, 143);
            this.descLabel.Name = "descLabel";
            this.descLabel.Text = "Description:";
            // descriptionTextBox
            this.descriptionTextBox.Location = new System.Drawing.Point(90, 140);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(282, 80);
            // saveButton
            this.saveButton.Location = new System.Drawing.Point(186, 230);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(90, 30);
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // cancelButton
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(282, 230);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(90, 30);
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // EventEditForm
            this.AcceptButton = this.saveButton;
            this.CancelButton = this.cancelButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 271);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.venueLabel);
            this.Controls.Add(this.venueTextBox);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.capacityLabel);
            this.Controls.Add(this.capacityNumericUpDown);
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EventEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Event";
            ((System.ComponentModel.ISupportInitialize)(this.capacityNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label venueLabel;
        private System.Windows.Forms.TextBox venueTextBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.Label capacityLabel;
        private System.Windows.Forms.NumericUpDown capacityNumericUpDown;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}