#nullable disable
namespace Evently.Forms
{
    partial class EventEditForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.venueLabel = new System.Windows.Forms.Label();
            this.venueTextBox = new System.Windows.Forms.TextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.eventDatePicker = new System.Windows.Forms.DateTimePicker();
            this.capacityLabel = new System.Windows.Forms.Label();
            this.capacityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.capacityNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // nameLabel
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(24, 24);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(52, 15);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // nameTextBox
            this.nameTextBox.Location = new System.Drawing.Point(140, 21);
            this.nameTextBox.MaxLength = 100;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(240, 23);
            this.nameTextBox.TabIndex = 1;
            // venueLabel
            this.venueLabel.AutoSize = true;
            this.venueLabel.Location = new System.Drawing.Point(24, 64);
            this.venueLabel.Name = "venueLabel";
            this.venueLabel.Size = new System.Drawing.Size(47, 15);
            this.venueLabel.TabIndex = 2;
            this.venueLabel.Text = "Venue:";
            // venueTextBox
            this.venueTextBox.Location = new System.Drawing.Point(140, 61);
            this.venueTextBox.MaxLength = 100;
            this.venueTextBox.Name = "venueTextBox";
            this.venueTextBox.Size = new System.Drawing.Size(240, 23);
            this.venueTextBox.TabIndex = 3;
            // dateLabel
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(24, 104);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(38, 15);
            this.dateLabel.TabIndex = 4;
            this.dateLabel.Text = "Date:";
            // eventDatePicker
            this.eventDatePicker.CustomFormat = "MMM d, yyyy  h:mm tt";
            this.eventDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eventDatePicker.Location = new System.Drawing.Point(140, 101);
            this.eventDatePicker.Name = "eventDatePicker";
            this.eventDatePicker.Size = new System.Drawing.Size(180, 23);
            this.eventDatePicker.TabIndex = 5;
            // capacityLabel
            this.capacityLabel.AutoSize = true;
            this.capacityLabel.Location = new System.Drawing.Point(24, 144);
            this.capacityLabel.Name = "capacityLabel";
            this.capacityLabel.Size = new System.Drawing.Size(64, 15);
            this.capacityLabel.TabIndex = 6;
            this.capacityLabel.Text = "Capacity:";
            // capacityNumericUpDown
            this.capacityNumericUpDown.Location = new System.Drawing.Point(140, 141);
            this.capacityNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.capacityNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.capacityNumericUpDown.Name = "capacityNumericUpDown";
            this.capacityNumericUpDown.Size = new System.Drawing.Size(80, 23);
            this.capacityNumericUpDown.TabIndex = 7;
            this.capacityNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.capacityNumericUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // descriptionLabel
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(24, 184);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(75, 15);
            this.descriptionLabel.TabIndex = 8;
            this.descriptionLabel.Text = "Description:";
            // descriptionTextBox
            this.descriptionTextBox.AcceptsReturn = true;
            this.descriptionTextBox.Location = new System.Drawing.Point(140, 181);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(240, 90);
            this.descriptionTextBox.TabIndex = 9;
            // saveButton
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(210, 294);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(80, 30);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // cancelButton
            this.cancelButton.Location = new System.Drawing.Point(300, 294);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(80, 30);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // EventEditForm
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(404, 350);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.venueLabel);
            this.Controls.Add(this.venueTextBox);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.eventDatePicker);
            this.Controls.Add(this.capacityLabel);
            this.Controls.Add(this.capacityNumericUpDown);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventEditForm";
            this.ShowInTaskbar = false;
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
        private System.Windows.Forms.DateTimePicker eventDatePicker;
        private System.Windows.Forms.Label capacityLabel;
        private System.Windows.Forms.NumericUpDown capacityNumericUpDown;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
