#nullable disable
namespace Evently.Forms
{
    partial class EventListForm
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
            this.gridHostPanel = new System.Windows.Forms.Panel();
            this.eventsDataGridView = new System.Windows.Forms.DataGridView();
            this.eventIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.venueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addEventWrapperPanel = new System.Windows.Forms.Panel();
            this.addEventGroupBox = new System.Windows.Forms.GroupBox();
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
            this.addButton = new System.Windows.Forms.Button();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.helperLabel = new System.Windows.Forms.Label();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.gridHostPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventsDataGridView)).BeginInit();
            this.addEventWrapperPanel.SuspendLayout();
            this.addEventGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capacityNumericUpDown)).BeginInit();
            this.actionPanel.SuspendLayout();
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
            this.titleLabel.Size = new System.Drawing.Size(70, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Events";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // heroSublineLabel
            this.heroSublineLabel.AutoSize = true;
            this.heroSublineLabel.BackColor = System.Drawing.Color.Transparent;
            this.heroSublineLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.heroSublineLabel.ForeColor = System.Drawing.Color.FromArgb(218, 230, 245);
            this.heroSublineLabel.Location = new System.Drawing.Point(12, 38);
            this.heroSublineLabel.Name = "heroSublineLabel";
            this.heroSublineLabel.Size = new System.Drawing.Size(370, 15);
            this.heroSublineLabel.TabIndex = 1;
            this.heroSublineLabel.Text = "Create events, set guest capacities, and manage your schedules.";
            this.heroSublineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // contentPanel
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.gridHostPanel);
            this.contentPanel.Controls.Add(this.addEventWrapperPanel);
            this.contentPanel.Controls.Add(this.actionPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 64);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(12);
            this.contentPanel.Size = new System.Drawing.Size(1280, 656);
            this.contentPanel.TabIndex = 1;
            // gridHostPanel
            this.gridHostPanel.BackColor = System.Drawing.Color.White;
            this.gridHostPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gridHostPanel.Controls.Add(this.eventsDataGridView);
            this.gridHostPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHostPanel.Location = new System.Drawing.Point(12, 12);
            this.gridHostPanel.Name = "gridHostPanel";
            this.gridHostPanel.Size = new System.Drawing.Size(1256, 452);
            this.gridHostPanel.TabIndex = 0;
            // eventsDataGridView
            this.eventsDataGridView.AllowUserToAddRows = false;
            this.eventsDataGridView.AllowUserToDeleteRows = false;
            this.eventsDataGridView.AllowUserToResizeRows = false;
            this.eventsDataGridView.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.eventsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.eventsDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.eventsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventsDataGridView.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.eventsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.eventsDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.eventsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.eventsDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.eventsDataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.eventsDataGridView.ColumnHeadersHeight = 36;
            this.eventsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.eventsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eventIdColumn,
            this.eventNameColumn,
            this.venueColumn,
            this.dateColumn,
            this.capacityColumn,
            this.descriptionColumn});
            this.eventsDataGridView.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.eventsDataGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(233, 238, 246);
            this.eventsDataGridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.eventsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventsDataGridView.EnableHeadersVisualStyles = false;
            this.eventsDataGridView.GridColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.eventsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.eventsDataGridView.MultiSelect = false;
            this.eventsDataGridView.Name = "eventsDataGridView";
            this.eventsDataGridView.AutoGenerateColumns = false;
            this.eventsDataGridView.ReadOnly = true;
            this.eventsDataGridView.RowHeadersVisible = false;
            this.eventsDataGridView.RowTemplate.Height = 28;
            this.eventsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventsDataGridView.Size = new System.Drawing.Size(1254, 450);
            this.eventsDataGridView.TabIndex = 0;
            // eventIdColumn
            this.eventIdColumn.DataPropertyName = "event_id";
            this.eventIdColumn.HeaderText = "ID";
            this.eventIdColumn.Name = "eventIdColumn";
            this.eventIdColumn.ReadOnly = true;
            this.eventIdColumn.Visible = false;
            // eventNameColumn
            this.eventNameColumn.HeaderText = "Name";
            this.eventNameColumn.Name = "eventNameColumn";
            this.eventNameColumn.ReadOnly = true;
            this.eventNameColumn.DataPropertyName = "name";
            // venueColumn
            this.venueColumn.FillWeight = 60F;
            this.venueColumn.HeaderText = "Venue";
            this.venueColumn.Name = "venueColumn";
            this.venueColumn.ReadOnly = true;
            this.venueColumn.DataPropertyName = "venue";
            // dateColumn
            this.dateColumn.DefaultCellStyle.Format = "MMM d, yyyy  h:mm tt";
            this.dateColumn.FillWeight = 70F;
            this.dateColumn.HeaderText = "Date";
            this.dateColumn.Name = "dateColumn";
            this.dateColumn.ReadOnly = true;
            this.dateColumn.DataPropertyName = "event_date";
            // capacityColumn
            this.capacityColumn.FillWeight = 40F;
            this.capacityColumn.HeaderText = "Capacity";
            this.capacityColumn.Name = "capacityColumn";
            this.capacityColumn.ReadOnly = true;
            this.capacityColumn.DataPropertyName = "capacity";
            // descriptionColumn
            this.descriptionColumn.FillWeight = 110F;
            this.descriptionColumn.HeaderText = "Description";
            this.descriptionColumn.Name = "descriptionColumn";
            this.descriptionColumn.ReadOnly = true;
            this.descriptionColumn.DataPropertyName = "description";
            // addEventWrapperPanel
            this.addEventWrapperPanel.BackColor = System.Drawing.Color.White;
            this.addEventWrapperPanel.Controls.Add(this.addEventGroupBox);
            this.addEventWrapperPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.addEventWrapperPanel.Location = new System.Drawing.Point(12, 464);
            this.addEventWrapperPanel.Name = "addEventWrapperPanel";
            this.addEventWrapperPanel.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.addEventWrapperPanel.Size = new System.Drawing.Size(1256, 126);
            this.addEventWrapperPanel.TabIndex = 1;
            // addEventGroupBox
            this.addEventGroupBox.BackColor = System.Drawing.Color.White;
            this.addEventGroupBox.Controls.Add(this.nameLabel);
            this.addEventGroupBox.Controls.Add(this.nameTextBox);
            this.addEventGroupBox.Controls.Add(this.venueLabel);
            this.addEventGroupBox.Controls.Add(this.venueTextBox);
            this.addEventGroupBox.Controls.Add(this.dateLabel);
            this.addEventGroupBox.Controls.Add(this.eventDatePicker);
            this.addEventGroupBox.Controls.Add(this.capacityLabel);
            this.addEventGroupBox.Controls.Add(this.capacityNumericUpDown);
            this.addEventGroupBox.Controls.Add(this.descriptionLabel);
            this.addEventGroupBox.Controls.Add(this.descriptionTextBox);
            this.addEventGroupBox.Controls.Add(this.addButton);
            this.addEventGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addEventGroupBox.Location = new System.Drawing.Point(0, 16);
            this.addEventGroupBox.Name = "addEventGroupBox";
            this.addEventGroupBox.Size = new System.Drawing.Size(1256, 110);
            this.addEventGroupBox.TabIndex = 0;
            this.addEventGroupBox.TabStop = false;
            this.addEventGroupBox.Text = "Add Event";
            // nameLabel
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 29);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // nameTextBox
            this.nameTextBox.Location = new System.Drawing.Point(94, 26);
            this.nameTextBox.MaxLength = 100;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(200, 27);
            this.nameTextBox.TabIndex = 1;
            // venueLabel
            this.venueLabel.AutoSize = true;
            this.venueLabel.Location = new System.Drawing.Point(306, 29);
            this.venueLabel.Name = "venueLabel";
            this.venueLabel.TabIndex = 2;
            this.venueLabel.Text = "Venue:";
            // venueTextBox
            this.venueTextBox.Location = new System.Drawing.Point(364, 26);
            this.venueTextBox.MaxLength = 100;
            this.venueTextBox.Name = "venueTextBox";
            this.venueTextBox.Size = new System.Drawing.Size(170, 27);
            this.venueTextBox.TabIndex = 3;
            // dateLabel
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(546, 29);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.TabIndex = 4;
            this.dateLabel.Text = "Date:";
            // eventDatePicker
            this.eventDatePicker.CustomFormat = "MMMM d, yyyy  h:mm tt";
            this.eventDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.eventDatePicker.Location = new System.Drawing.Point(594, 26);
            this.eventDatePicker.Name = "eventDatePicker";
            this.eventDatePicker.ShowUpDown = true;
            this.eventDatePicker.Size = new System.Drawing.Size(240, 27);
            this.eventDatePicker.TabIndex = 5;
            // capacityLabel
            this.capacityLabel.AutoSize = true;
            this.capacityLabel.Location = new System.Drawing.Point(12, 65);
            this.capacityLabel.Name = "capacityLabel";
            this.capacityLabel.TabIndex = 6;
            this.capacityLabel.Text = "Capacity:";
            // capacityNumericUpDown
            this.capacityNumericUpDown.Location = new System.Drawing.Point(94, 62);
            this.capacityNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.capacityNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.capacityNumericUpDown.Name = "capacityNumericUpDown";
            this.capacityNumericUpDown.Size = new System.Drawing.Size(80, 27);
            this.capacityNumericUpDown.TabIndex = 7;
            this.capacityNumericUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // descriptionLabel
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(186, 65);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.TabIndex = 8;
            this.descriptionLabel.Text = "Description:";
            // descriptionTextBox
            this.descriptionTextBox.Location = new System.Drawing.Point(278, 62);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(496, 27);
            this.descriptionTextBox.TabIndex = 9;
            // addButton
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.addButton.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Location = new System.Drawing.Point(1154, 26);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(90, 30);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "&Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // actionPanel
            this.actionPanel.BackColor = System.Drawing.Color.White;
            this.actionPanel.Controls.Add(this.helperLabel);
            this.actionPanel.Controls.Add(this.editButton);
            this.actionPanel.Controls.Add(this.deleteButton);
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.actionPanel.Location = new System.Drawing.Point(12, 590);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(1256, 54);
            this.actionPanel.TabIndex = 2;
            // helperLabel
            this.helperLabel.AutoSize = true;
            this.helperLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.helperLabel.ForeColor = System.Drawing.Color.FromArgb(95, 95, 95);
            this.helperLabel.Location = new System.Drawing.Point(0, 22);
            this.helperLabel.Name = "helperLabel";
            this.helperLabel.Size = new System.Drawing.Size(370, 15);
            this.helperLabel.TabIndex = 2;
            this.helperLabel.Text = "Select an event to edit or delete, or fill in the form above to add one.";
            // editButton
            this.editButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.editButton.Location = new System.Drawing.Point(1068, 16);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(90, 30);
            this.editButton.TabIndex = 0;
            this.editButton.Text = "&Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // deleteButton
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.deleteButton.Location = new System.Drawing.Point(1166, 16);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(90, 30);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "&Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // EventListForm
            this.AcceptButton = this.addButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "EventListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Events";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.gridHostPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventsDataGridView)).EndInit();
            this.addEventWrapperPanel.ResumeLayout(false);
            this.addEventGroupBox.ResumeLayout(false);
            this.addEventGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capacityNumericUpDown)).EndInit();
            this.actionPanel.ResumeLayout(false);
            this.actionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel gridHostPanel;
        private System.Windows.Forms.DataGridView eventsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn venueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionColumn;
        private System.Windows.Forms.Panel addEventWrapperPanel;
        private System.Windows.Forms.GroupBox addEventGroupBox;
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
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.Label helperLabel;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label heroSublineLabel;
    }
}
