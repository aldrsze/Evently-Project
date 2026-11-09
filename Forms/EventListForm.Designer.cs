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
            this.eventNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.venueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.helperLabel = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.gridHostPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventsDataGridView)).BeginInit();
            this.bottomPanel.SuspendLayout();
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
            this.contentPanel.Controls.Add(this.bottomPanel);
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
            this.gridHostPanel.Size = new System.Drawing.Size(1256, 586);
            this.gridHostPanel.TabIndex = 0;
            // eventsDataGridView
            this.eventsDataGridView.AllowUserToAddRows = false;
            this.eventsDataGridView.AllowUserToDeleteRows = false;
            this.eventsDataGridView.AllowUserToResizeRows = false;
            this.eventsDataGridView.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(249, 249, 249);
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
            this.eventNameColumn,
            this.venueColumn,
            this.dateColumn,
            this.capacityColumn});
            this.eventsDataGridView.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.eventsDataGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.eventsDataGridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.eventsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventsDataGridView.EnableHeadersVisualStyles = false;
            this.eventsDataGridView.GridColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.eventsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.eventsDataGridView.MultiSelect = false;
            this.eventsDataGridView.Name = "eventsDataGridView";
            this.eventsDataGridView.ReadOnly = true;
            this.eventsDataGridView.RowHeadersVisible = false;
            this.eventsDataGridView.RowTemplate.Height = 28;
            this.eventsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eventsDataGridView.Size = new System.Drawing.Size(1254, 584);
            this.eventsDataGridView.TabIndex = 0;
            // eventNameColumn
            this.eventNameColumn.HeaderText = "Name";
            this.eventNameColumn.Name = "eventNameColumn";
            this.eventNameColumn.ReadOnly = true;
            // venueColumn
            this.venueColumn.HeaderText = "Venue";
            this.venueColumn.Name = "venueColumn";
            this.venueColumn.ReadOnly = true;
            // dateColumn
            this.dateColumn.HeaderText = "Date";
            this.dateColumn.Name = "dateColumn";
            this.dateColumn.ReadOnly = true;
            // capacityColumn
            this.capacityColumn.HeaderText = "Capacity";
            this.capacityColumn.Name = "capacityColumn";
            this.capacityColumn.ReadOnly = true;
            // bottomPanel
            this.bottomPanel.BackColor = System.Drawing.Color.White;
            this.bottomPanel.Controls.Add(this.helperLabel);
            this.bottomPanel.Controls.Add(this.createButton);
            this.bottomPanel.Controls.Add(this.editButton);
            this.bottomPanel.Controls.Add(this.deleteButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(12, 598);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.bottomPanel.Size = new System.Drawing.Size(1256, 46);
            this.bottomPanel.TabIndex = 1;
            // helperLabel
            this.helperLabel.AutoSize = true;
            this.helperLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.helperLabel.ForeColor = System.Drawing.Color.FromArgb(95, 95, 95);
            this.helperLabel.Location = new System.Drawing.Point(0, 22);
            this.helperLabel.Name = "helperLabel";
            this.helperLabel.Size = new System.Drawing.Size(370, 15);
            this.helperLabel.TabIndex = 3;
            this.helperLabel.Text = "Select an event to edit or delete, or click Create to set up a new event.";
            // createButton
            this.createButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.createButton.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.createButton.FlatAppearance.BorderSize = 0;
            this.createButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createButton.ForeColor = System.Drawing.Color.White;
            this.createButton.Location = new System.Drawing.Point(970, 16);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(90, 30);
            this.createButton.TabIndex = 0;
            this.createButton.Text = "&Create";
            this.createButton.UseVisualStyleBackColor = false;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // editButton
            this.editButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.editButton.Location = new System.Drawing.Point(1068, 16);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(90, 30);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "&Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // deleteButton
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.deleteButton.Location = new System.Drawing.Point(1166, 16);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(90, 30);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "&Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // EventListForm
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
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel gridHostPanel;
        private System.Windows.Forms.DataGridView eventsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn venueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacityColumn;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Label helperLabel;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label heroSublineLabel;
    }
}
