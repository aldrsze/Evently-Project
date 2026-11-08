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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.eventLabel = new System.Windows.Forms.Label();
            this.eventComboBox = new System.Windows.Forms.ComboBox();
            this.gridHostPanel = new System.Windows.Forms.Panel();
            this.attendeesDataGridView = new System.Windows.Forms.DataGridView();
            this.attendeeNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ticketEmailedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkedInColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkedOutColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratingColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addAttendeeWrapperPanel = new System.Windows.Forms.Panel();
            this.addAttendeeGroupBox = new System.Windows.Forms.GroupBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.addAttendeeButton = new System.Windows.Forms.Button();
            this.resultPanel = new System.Windows.Forms.Panel();
            this.resultLabel = new System.Windows.Forms.Label();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.importCsvButton = new System.Windows.Forms.Button();
            this.sendTicketsButton = new System.Windows.Forms.Button();
            this.exportCsvButton = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.gridHostPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attendeesDataGridView)).BeginInit();
            this.addAttendeeWrapperPanel.SuspendLayout();
            this.addAttendeeGroupBox.SuspendLayout();
            this.resultPanel.SuspendLayout();
            this.actionPanel.SuspendLayout();
            this.SuspendLayout();
            // headerPanel
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.headerPanel.Size = new System.Drawing.Size(1280, 64);
            this.headerPanel.TabIndex = 0;
            // titleLabel
            this.titleLabel.AutoSize = false;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(12, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(1256, 64);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Manage Attendees";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // contentPanel
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.gridHostPanel);
            this.contentPanel.Controls.Add(this.addAttendeeWrapperPanel);
            this.contentPanel.Controls.Add(this.resultPanel);
            this.contentPanel.Controls.Add(this.actionPanel);
            this.contentPanel.Controls.Add(this.topPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 64);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(12);
            this.contentPanel.Size = new System.Drawing.Size(1280, 656);
            this.contentPanel.TabIndex = 1;
            // topPanel
            this.topPanel.BackColor = System.Drawing.Color.White;
            this.topPanel.Controls.Add(this.eventLabel);
            this.topPanel.Controls.Add(this.eventComboBox);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(12, 12);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1256, 40);
            this.topPanel.TabIndex = 0;
            // eventLabel
            this.eventLabel.AutoSize = true;
            this.eventLabel.Location = new System.Drawing.Point(0, 11);
            this.eventLabel.Name = "eventLabel";
            this.eventLabel.TabIndex = 0;
            this.eventLabel.Text = "Event:";
            // eventComboBox
            this.eventComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.eventComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventComboBox.FormattingEnabled = true;
            this.eventComboBox.Location = new System.Drawing.Point(58, 8);
            this.eventComboBox.Name = "eventComboBox";
            this.eventComboBox.Size = new System.Drawing.Size(1198, 23);
            this.eventComboBox.TabIndex = 1;
            this.eventComboBox.SelectedIndexChanged += new System.EventHandler(this.eventComboBox_SelectedIndexChanged);
            // gridHostPanel
            this.gridHostPanel.BackColor = System.Drawing.Color.White;
            this.gridHostPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gridHostPanel.Controls.Add(this.attendeesDataGridView);
            this.gridHostPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHostPanel.Location = new System.Drawing.Point(12, 52);
            this.gridHostPanel.Name = "gridHostPanel";
            this.gridHostPanel.Size = new System.Drawing.Size(1256, 402);
            this.gridHostPanel.TabIndex = 1;
            // attendeesDataGridView
            this.attendeesDataGridView.AllowUserToAddRows = false;
            this.attendeesDataGridView.AllowUserToDeleteRows = false;
            this.attendeesDataGridView.AllowUserToResizeRows = false;
            this.attendeesDataGridView.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(249, 249, 249);
            this.attendeesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.attendeesDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.attendeesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.attendeesDataGridView.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.attendeesDataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.attendeesDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.attendeesDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.attendeesDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.attendeesDataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.attendeesDataGridView.ColumnHeadersHeight = 36;
            this.attendeesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.attendeesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.attendeeNameColumn,
            this.emailColumn,
            this.ticketEmailedColumn,
            this.checkedInColumn,
            this.checkedOutColumn,
            this.ratingColumn});
            this.attendeesDataGridView.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.attendeesDataGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.attendeesDataGridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.attendeesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attendeesDataGridView.EnableHeadersVisualStyles = false;
            this.attendeesDataGridView.GridColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.attendeesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.attendeesDataGridView.MultiSelect = false;
            this.attendeesDataGridView.Name = "attendeesDataGridView";
            this.attendeesDataGridView.ReadOnly = true;
            this.attendeesDataGridView.RowHeadersVisible = false;
            this.attendeesDataGridView.RowTemplate.Height = 28;
            this.attendeesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.attendeesDataGridView.Size = new System.Drawing.Size(1254, 400);
            this.attendeesDataGridView.TabIndex = 0;
            // attendeeNameColumn
            this.attendeeNameColumn.HeaderText = "Name";
            this.attendeeNameColumn.Name = "attendeeNameColumn";
            this.attendeeNameColumn.ReadOnly = true;
            // emailColumn
            this.emailColumn.HeaderText = "Email";
            this.emailColumn.Name = "emailColumn";
            this.emailColumn.ReadOnly = true;
            // ticketEmailedColumn
            this.ticketEmailedColumn.HeaderText = "Ticket Emailed";
            this.ticketEmailedColumn.Name = "ticketEmailedColumn";
            this.ticketEmailedColumn.ReadOnly = true;
            // checkedInColumn
            this.checkedInColumn.HeaderText = "Checked In";
            this.checkedInColumn.Name = "checkedInColumn";
            this.checkedInColumn.ReadOnly = true;
            // checkedOutColumn
            this.checkedOutColumn.HeaderText = "Checked Out";
            this.checkedOutColumn.Name = "checkedOutColumn";
            this.checkedOutColumn.ReadOnly = true;
            // ratingColumn
            this.ratingColumn.HeaderText = "Rating";
            this.ratingColumn.Name = "ratingColumn";
            this.ratingColumn.ReadOnly = true;
            // addAttendeeWrapperPanel
            this.addAttendeeWrapperPanel.BackColor = System.Drawing.Color.White;
            this.addAttendeeWrapperPanel.Controls.Add(this.addAttendeeGroupBox);
            this.addAttendeeWrapperPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.addAttendeeWrapperPanel.Location = new System.Drawing.Point(12, 454);
            this.addAttendeeWrapperPanel.Name = "addAttendeeWrapperPanel";
            this.addAttendeeWrapperPanel.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.addAttendeeWrapperPanel.Size = new System.Drawing.Size(1256, 102);
            this.addAttendeeWrapperPanel.TabIndex = 2;
            // addAttendeeGroupBox
            this.addAttendeeGroupBox.BackColor = System.Drawing.Color.White;
            this.addAttendeeGroupBox.Controls.Add(this.nameLabel);
            this.addAttendeeGroupBox.Controls.Add(this.nameTextBox);
            this.addAttendeeGroupBox.Controls.Add(this.emailLabel);
            this.addAttendeeGroupBox.Controls.Add(this.emailTextBox);
            this.addAttendeeGroupBox.Controls.Add(this.addAttendeeButton);
            this.addAttendeeGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addAttendeeGroupBox.Location = new System.Drawing.Point(0, 16);
            this.addAttendeeGroupBox.Name = "addAttendeeGroupBox";
            this.addAttendeeGroupBox.Size = new System.Drawing.Size(1256, 86);
            this.addAttendeeGroupBox.TabIndex = 0;
            this.addAttendeeGroupBox.TabStop = false;
            this.addAttendeeGroupBox.Text = "Add Attendee";
            // nameLabel
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 29);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // nameTextBox
            this.nameTextBox.Location = new System.Drawing.Point(58, 26);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(160, 23);
            this.nameTextBox.TabIndex = 1;
            // emailLabel
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(234, 29);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "Email:";
            // emailTextBox
            this.emailTextBox.Location = new System.Drawing.Point(280, 26);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(220, 23);
            this.emailTextBox.TabIndex = 3;
            // addAttendeeButton
            this.addAttendeeButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.addAttendeeButton.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.addAttendeeButton.FlatAppearance.BorderSize = 0;
            this.addAttendeeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAttendeeButton.ForeColor = System.Drawing.Color.White;
            this.addAttendeeButton.Location = new System.Drawing.Point(1154, 26);
            this.addAttendeeButton.Name = "addAttendeeButton";
            this.addAttendeeButton.Size = new System.Drawing.Size(90, 30);
            this.addAttendeeButton.TabIndex = 4;
            this.addAttendeeButton.Text = "&Add";
            this.addAttendeeButton.UseVisualStyleBackColor = false;
            this.addAttendeeButton.Click += new System.EventHandler(this.addAttendeeButton_Click);
            // resultPanel
            this.resultPanel.BackColor = System.Drawing.Color.White;
            this.resultPanel.Controls.Add(this.resultLabel);
            this.resultPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.resultPanel.Location = new System.Drawing.Point(12, 556);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.resultPanel.Size = new System.Drawing.Size(1256, 36);
            this.resultPanel.TabIndex = 3;
            // resultLabel
            this.resultLabel.AutoSize = false;
            this.resultLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultLabel.ForeColor = System.Drawing.Color.FromArgb(95, 95, 95);
            this.resultLabel.Location = new System.Drawing.Point(0, 8);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(1256, 28);
            this.resultLabel.TabIndex = 0;
            this.resultLabel.Text = "";
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // actionPanel
            this.actionPanel.BackColor = System.Drawing.Color.White;
            this.actionPanel.Controls.Add(this.importCsvButton);
            this.actionPanel.Controls.Add(this.sendTicketsButton);
            this.actionPanel.Controls.Add(this.exportCsvButton);
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.actionPanel.Location = new System.Drawing.Point(12, 592);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(1256, 46);
            this.actionPanel.TabIndex = 4;
            // importCsvButton
            this.importCsvButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.importCsvButton.Location = new System.Drawing.Point(930, 8);
            this.importCsvButton.Name = "importCsvButton";
            this.importCsvButton.Size = new System.Drawing.Size(100, 30);
            this.importCsvButton.TabIndex = 0;
            this.importCsvButton.Text = "&Import CSV";
            this.importCsvButton.UseVisualStyleBackColor = true;
            this.importCsvButton.Click += new System.EventHandler(this.importCsvButton_Click);
            // sendTicketsButton
            this.sendTicketsButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.sendTicketsButton.Location = new System.Drawing.Point(1038, 8);
            this.sendTicketsButton.Name = "sendTicketsButton";
            this.sendTicketsButton.Size = new System.Drawing.Size(110, 30);
            this.sendTicketsButton.TabIndex = 1;
            this.sendTicketsButton.Text = "Send &Tickets";
            this.sendTicketsButton.UseVisualStyleBackColor = true;
            this.sendTicketsButton.Click += new System.EventHandler(this.sendTicketsButton_Click);
            // exportCsvButton
            this.exportCsvButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.exportCsvButton.Location = new System.Drawing.Point(1156, 8);
            this.exportCsvButton.Name = "exportCsvButton";
            this.exportCsvButton.Size = new System.Drawing.Size(100, 30);
            this.exportCsvButton.TabIndex = 2;
            this.exportCsvButton.Text = "&Export CSV";
            this.exportCsvButton.UseVisualStyleBackColor = true;
            this.exportCsvButton.Click += new System.EventHandler(this.exportCsvButton_Click);
            // AttendeesForm
            this.AcceptButton = this.addAttendeeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "AttendeesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Attendees";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.gridHostPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.attendeesDataGridView)).EndInit();
            this.addAttendeeWrapperPanel.ResumeLayout(false);
            this.addAttendeeGroupBox.ResumeLayout(false);
            this.addAttendeeGroupBox.PerformLayout();
            this.resultPanel.ResumeLayout(false);
            this.actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label eventLabel;
        private System.Windows.Forms.ComboBox eventComboBox;
        private System.Windows.Forms.Panel gridHostPanel;
        private System.Windows.Forms.DataGridView attendeesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn attendeeNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketEmailedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkedInColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkedOutColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratingColumn;
        private System.Windows.Forms.Panel addAttendeeWrapperPanel;
        private System.Windows.Forms.GroupBox addAttendeeGroupBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Button addAttendeeButton;
        private System.Windows.Forms.Panel resultPanel;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.Button importCsvButton;
        private System.Windows.Forms.Button sendTicketsButton;
        private System.Windows.Forms.Button exportCsvButton;
    }
}
