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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.heroSublineLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.centerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.editPanel = new System.Windows.Forms.Panel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.venueLabel = new System.Windows.Forms.Label();
            this.venueTextBox = new System.Windows.Forms.TextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.capacityLabel = new System.Windows.Forms.Label();
            this.capacityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.capacityHelperLabel = new System.Windows.Forms.Label();
            this.descLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.centerLayoutPanel.SuspendLayout();
            this.editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capacityNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // headerPanel
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.heroSublineLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.headerPanel.Size = new System.Drawing.Size(1280, 64);
            this.headerPanel.TabIndex = 0;
            // titleLabel
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(12, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(100, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Edit Event";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // heroSublineLabel
            this.heroSublineLabel.AutoSize = true;
            this.heroSublineLabel.BackColor = System.Drawing.Color.Transparent;
            this.heroSublineLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.heroSublineLabel.ForeColor = System.Drawing.Color.FromArgb(218, 230, 245);
            this.heroSublineLabel.Location = new System.Drawing.Point(12, 38);
            this.heroSublineLabel.Name = "heroSublineLabel";
            this.heroSublineLabel.Size = new System.Drawing.Size(395, 15);
            this.heroSublineLabel.TabIndex = 1;
            this.heroSublineLabel.Text = "Define event details, venue location, and maximum guest capacity.";
            this.heroSublineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // contentPanel
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.centerLayoutPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 64);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(12);
            this.contentPanel.Size = new System.Drawing.Size(1280, 656);
            this.contentPanel.TabIndex = 1;
            // centerLayoutPanel
            this.centerLayoutPanel.ColumnCount = 3;
            this.centerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 520F));
            this.centerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerLayoutPanel.Controls.Add(this.editPanel, 1, 1);
            this.centerLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.centerLayoutPanel.Name = "centerLayoutPanel";
            this.centerLayoutPanel.RowCount = 3;
            this.centerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.centerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerLayoutPanel.Size = new System.Drawing.Size(1256, 632);
            this.centerLayoutPanel.TabIndex = 0;
            // editPanel
            this.editPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editPanel.BackColor = System.Drawing.Color.White;
            this.editPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editPanel.Controls.Add(this.nameLabel);
            this.editPanel.Controls.Add(this.nameTextBox);
            this.editPanel.Controls.Add(this.venueLabel);
            this.editPanel.Controls.Add(this.venueTextBox);
            this.editPanel.Controls.Add(this.dateLabel);
            this.editPanel.Controls.Add(this.datePicker);
            this.editPanel.Controls.Add(this.timePicker);
            this.editPanel.Controls.Add(this.capacityLabel);
            this.editPanel.Controls.Add(this.capacityNumericUpDown);
            this.editPanel.Controls.Add(this.capacityHelperLabel);
            this.editPanel.Controls.Add(this.descLabel);
            this.editPanel.Controls.Add(this.descriptionTextBox);
            this.editPanel.Controls.Add(this.saveButton);
            this.editPanel.Controls.Add(this.cancelButton);
            this.editPanel.Location = new System.Drawing.Point(368, 151);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(520, 330);
            this.editPanel.TabIndex = 0;
            // nameLabel
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(24, 27);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // nameTextBox
            this.nameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.nameTextBox.Location = new System.Drawing.Point(140, 24);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(356, 23);
            this.nameTextBox.TabIndex = 1;
            // venueLabel
            this.venueLabel.AutoSize = true;
            this.venueLabel.Location = new System.Drawing.Point(24, 63);
            this.venueLabel.Name = "venueLabel";
            this.venueLabel.TabIndex = 2;
            this.venueLabel.Text = "Venue:";
            // venueTextBox
            this.venueTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.venueTextBox.Location = new System.Drawing.Point(140, 60);
            this.venueTextBox.Name = "venueTextBox";
            this.venueTextBox.Size = new System.Drawing.Size(356, 23);
            this.venueTextBox.TabIndex = 3;
            // dateLabel
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(24, 99);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.TabIndex = 4;
            this.dateLabel.Text = "Date / Time:";
            // datePicker
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(140, 96);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(140, 23);
            this.datePicker.TabIndex = 5;
            // timePicker
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.Location = new System.Drawing.Point(288, 96);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(120, 23);
            this.timePicker.TabIndex = 6;
            // capacityLabel
            this.capacityLabel.AutoSize = true;
            this.capacityLabel.Location = new System.Drawing.Point(24, 135);
            this.capacityLabel.Name = "capacityLabel";
            this.capacityLabel.TabIndex = 7;
            this.capacityLabel.Text = "Capacity:";
            // capacityNumericUpDown
            this.capacityNumericUpDown.Location = new System.Drawing.Point(140, 132);
            this.capacityNumericUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.capacityNumericUpDown.Name = "capacityNumericUpDown";
            this.capacityNumericUpDown.Size = new System.Drawing.Size(120, 23);
            this.capacityNumericUpDown.TabIndex = 8;
            // capacityHelperLabel
            this.capacityHelperLabel.AutoSize = true;
            this.capacityHelperLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.capacityHelperLabel.ForeColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.capacityHelperLabel.Location = new System.Drawing.Point(268, 137);
            this.capacityHelperLabel.Name = "capacityHelperLabel";
            this.capacityHelperLabel.Size = new System.Drawing.Size(215, 13);
            this.capacityHelperLabel.TabIndex = 9;
            this.capacityHelperLabel.Text = "Guest limit enforced during registration";
            // descLabel
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(24, 171);
            this.descLabel.Name = "descLabel";
            this.descLabel.TabIndex = 9;
            this.descLabel.Text = "Description:";
            // descriptionTextBox
            this.descriptionTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.descriptionTextBox.Location = new System.Drawing.Point(140, 168);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(356, 100);
            this.descriptionTextBox.TabIndex = 10;
            // saveButton
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(406, 282);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(90, 30);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // cancelButton
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(308, 282);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(90, 30);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // EventEditForm
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "EventEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Event";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.centerLayoutPanel.ResumeLayout(false);
            this.centerLayoutPanel.PerformLayout();
            this.editPanel.ResumeLayout(false);
            this.editPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capacityNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.TableLayoutPanel centerLayoutPanel;
        private System.Windows.Forms.Panel editPanel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label venueLabel;
        private System.Windows.Forms.TextBox venueTextBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.Label capacityLabel;
        private System.Windows.Forms.NumericUpDown capacityNumericUpDown;
        private System.Windows.Forms.Label capacityHelperLabel;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label heroSublineLabel;
    }
}
