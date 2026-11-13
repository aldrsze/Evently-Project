#nullable disable
namespace Evently.Forms
{
    partial class OrganizersForm
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.eventLabel = new System.Windows.Forms.Label();
            this.eventComboBox = new System.Windows.Forms.ComboBox();
            this.gridHostPanel = new System.Windows.Forms.Panel();
            this.organizersDataGridView = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.organizationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addManagerWrapperPanel = new System.Windows.Forms.Panel();
            this.addManagerGroupBox = new System.Windows.Forms.GroupBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.organizationLabel = new System.Windows.Forms.Label();
            this.organizationTextBox = new System.Windows.Forms.TextBox();
            this.managerHelperLabel = new System.Windows.Forms.Label();
            this.addManagerButton = new System.Windows.Forms.Button();
            this.actionPanel = new System.Windows.Forms.Panel();
            this.actionHintLabel = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            this.removeManagerButton = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.gridHostPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.organizersDataGridView)).BeginInit();
            this.addManagerWrapperPanel.SuspendLayout();
            this.addManagerGroupBox.SuspendLayout();
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
            this.titleLabel.Size = new System.Drawing.Size(262, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Manage Event Managers";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // heroSublineLabel
            this.heroSublineLabel.AutoSize = true;
            this.heroSublineLabel.BackColor = System.Drawing.Color.Transparent;
            this.heroSublineLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.heroSublineLabel.ForeColor = System.Drawing.Color.FromArgb(218, 230, 245);
            this.heroSublineLabel.Location = new System.Drawing.Point(12, 38);
            this.heroSublineLabel.Name = "heroSublineLabel";
            this.heroSublineLabel.Size = new System.Drawing.Size(468, 15);
            this.heroSublineLabel.TabIndex = 1;
            this.heroSublineLabel.Text = "Assign organizers to an event and keep their contact details in one place.";
            this.heroSublineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // contentPanel
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.gridHostPanel);
            this.contentPanel.Controls.Add(this.addManagerWrapperPanel);
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
            this.gridHostPanel.Controls.Add(this.organizersDataGridView);
            this.gridHostPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHostPanel.Location = new System.Drawing.Point(12, 52);
            this.gridHostPanel.Name = "gridHostPanel";
            this.gridHostPanel.Size = new System.Drawing.Size(1256, 426);
            this.gridHostPanel.TabIndex = 1;
            // organizersDataGridView
            this.organizersDataGridView.AllowUserToAddRows = false;
            this.organizersDataGridView.AllowUserToDeleteRows = false;
            this.organizersDataGridView.AllowUserToResizeRows = false;
            this.organizersDataGridView.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(249, 249, 249);
            this.organizersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.organizersDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.organizersDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.organizersDataGridView.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.organizersDataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.organizersDataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.organizersDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.organizersDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.organizersDataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.organizersDataGridView.ColumnHeadersHeight = 36;
            this.organizersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.organizersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.emailColumn,
            this.phoneColumn,
            this.organizationColumn});
            this.organizersDataGridView.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.organizersDataGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.organizersDataGridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.organizersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.organizersDataGridView.EnableHeadersVisualStyles = false;
            this.organizersDataGridView.GridColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.organizersDataGridView.Location = new System.Drawing.Point(0, 0);
            this.organizersDataGridView.MultiSelect = false;
            this.organizersDataGridView.Name = "organizersDataGridView";
            this.organizersDataGridView.ReadOnly = true;
            this.organizersDataGridView.RowHeadersVisible = false;
            this.organizersDataGridView.RowTemplate.Height = 28;
            this.organizersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.organizersDataGridView.Size = new System.Drawing.Size(1254, 424);
            this.organizersDataGridView.TabIndex = 0;
            // nameColumn
            this.nameColumn.FillWeight = 70F;
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            // emailColumn
            this.emailColumn.FillWeight = 80F;
            this.emailColumn.HeaderText = "Email";
            this.emailColumn.Name = "emailColumn";
            this.emailColumn.ReadOnly = true;
            // phoneColumn
            this.phoneColumn.FillWeight = 50F;
            this.phoneColumn.HeaderText = "Phone";
            this.phoneColumn.Name = "phoneColumn";
            this.phoneColumn.ReadOnly = true;
            // organizationColumn
            this.organizationColumn.FillWeight = 80F;
            this.organizationColumn.HeaderText = "Organization";
            this.organizationColumn.Name = "organizationColumn";
            this.organizationColumn.ReadOnly = true;
            // addManagerWrapperPanel
            this.addManagerWrapperPanel.BackColor = System.Drawing.Color.White;
            this.addManagerWrapperPanel.Controls.Add(this.addManagerGroupBox);
            this.addManagerWrapperPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.addManagerWrapperPanel.Location = new System.Drawing.Point(12, 478);
            this.addManagerWrapperPanel.Name = "addManagerWrapperPanel";
            this.addManagerWrapperPanel.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.addManagerWrapperPanel.Size = new System.Drawing.Size(1256, 102);
            this.addManagerWrapperPanel.TabIndex = 2;
            // addManagerGroupBox
            this.addManagerGroupBox.BackColor = System.Drawing.Color.White;
            this.addManagerGroupBox.Controls.Add(this.nameLabel);
            this.addManagerGroupBox.Controls.Add(this.nameTextBox);
            this.addManagerGroupBox.Controls.Add(this.emailLabel);
            this.addManagerGroupBox.Controls.Add(this.emailTextBox);
            this.addManagerGroupBox.Controls.Add(this.phoneLabel);
            this.addManagerGroupBox.Controls.Add(this.phoneTextBox);
            this.addManagerGroupBox.Controls.Add(this.organizationLabel);
            this.addManagerGroupBox.Controls.Add(this.organizationTextBox);
            this.addManagerGroupBox.Controls.Add(this.managerHelperLabel);
            this.addManagerGroupBox.Controls.Add(this.addManagerButton);
            this.addManagerGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addManagerGroupBox.Location = new System.Drawing.Point(0, 16);
            this.addManagerGroupBox.Name = "addManagerGroupBox";
            this.addManagerGroupBox.Size = new System.Drawing.Size(1256, 86);
            this.addManagerGroupBox.TabIndex = 0;
            this.addManagerGroupBox.TabStop = false;
            this.addManagerGroupBox.Text = "Add Event Manager";
            // nameLabel
            this.nameLabel.AutoSize = false;
            this.nameLabel.Location = new System.Drawing.Point(12, 26);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(96, 23);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // nameTextBox
            this.nameTextBox.Location = new System.Drawing.Point(116, 26);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(170, 23);
            this.nameTextBox.TabIndex = 1;
            // emailLabel
            this.emailLabel.AutoSize = false;
            this.emailLabel.Location = new System.Drawing.Point(310, 26);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(96, 23);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "Email:";
            this.emailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // emailTextBox
            this.emailTextBox.Location = new System.Drawing.Point(414, 26);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(200, 23);
            this.emailTextBox.TabIndex = 3;
            // phoneLabel
            this.phoneLabel.AutoSize = false;
            this.phoneLabel.Location = new System.Drawing.Point(638, 26);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(96, 23);
            this.phoneLabel.TabIndex = 4;
            this.phoneLabel.Text = "Phone:";
            this.phoneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // phoneTextBox
            this.phoneTextBox.Location = new System.Drawing.Point(742, 26);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(130, 23);
            this.phoneTextBox.TabIndex = 5;
            // organizationLabel
            this.organizationLabel.AutoSize = false;
            this.organizationLabel.Location = new System.Drawing.Point(12, 56);
            this.organizationLabel.Name = "organizationLabel";
            this.organizationLabel.Size = new System.Drawing.Size(96, 23);
            this.organizationLabel.TabIndex = 4;
            this.organizationLabel.Text = "Organization:";
            this.organizationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // organizationTextBox
            this.organizationTextBox.Location = new System.Drawing.Point(116, 56);
            this.organizationTextBox.Name = "organizationTextBox";
            this.organizationTextBox.Size = new System.Drawing.Size(560, 23);
            this.organizationTextBox.TabIndex = 5;
            // managerHelperLabel
            this.managerHelperLabel.AutoSize = true;
            this.managerHelperLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.managerHelperLabel.ForeColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.managerHelperLabel.Location = new System.Drawing.Point(696, 59);
            this.managerHelperLabel.Name = "managerHelperLabel";
            this.managerHelperLabel.Size = new System.Drawing.Size(180, 13);
            this.managerHelperLabel.TabIndex = 6;
            this.managerHelperLabel.Text = "Saved to your organizer list";
            // addManagerButton
            this.addManagerButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.addManagerButton.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.addManagerButton.FlatAppearance.BorderSize = 0;
            this.addManagerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addManagerButton.ForeColor = System.Drawing.Color.White;
            this.addManagerButton.Location = new System.Drawing.Point(1154, 26);
            this.addManagerButton.Name = "addManagerButton";
            this.addManagerButton.Size = new System.Drawing.Size(90, 30);
            this.addManagerButton.TabIndex = 7;
            this.addManagerButton.Text = "&Add";
            this.addManagerButton.UseVisualStyleBackColor = false;
            this.addManagerButton.Click += new System.EventHandler(this.addManagerButton_Click);
            // actionPanel
            this.actionPanel.BackColor = System.Drawing.Color.White;
            this.actionPanel.Controls.Add(this.actionHintLabel);
            this.actionPanel.Controls.Add(this.resultLabel);
            this.actionPanel.Controls.Add(this.removeManagerButton);
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.actionPanel.Location = new System.Drawing.Point(12, 580);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(1256, 64);
            this.actionPanel.TabIndex = 3;
            // resultLabel
            this.resultLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.resultLabel.AutoSize = false;
            this.resultLabel.ForeColor = System.Drawing.Color.FromArgb(95, 95, 95);
            this.resultLabel.Location = new System.Drawing.Point(0, 4);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(1030, 20);
            this.resultLabel.TabIndex = 1;
            this.resultLabel.Text = "";
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // actionHintLabel
            this.actionHintLabel.AutoSize = true;
            this.actionHintLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.actionHintLabel.ForeColor = System.Drawing.Color.FromArgb(95, 95, 95);
            this.actionHintLabel.Location = new System.Drawing.Point(0, 30);
            this.actionHintLabel.Name = "actionHintLabel";
            this.actionHintLabel.Size = new System.Drawing.Size(437, 15);
            this.actionHintLabel.TabIndex = 2;
            this.actionHintLabel.Text = "Removing a manager only unlinks them from this event, not the organizer list.";
            // removeManagerButton
            this.removeManagerButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.removeManagerButton.Location = new System.Drawing.Point(1154, 17);
            this.removeManagerButton.Name = "removeManagerButton";
            this.removeManagerButton.Size = new System.Drawing.Size(100, 30);
            this.removeManagerButton.TabIndex = 0;
            this.removeManagerButton.Text = "&Remove";
            this.removeManagerButton.UseVisualStyleBackColor = true;
            this.removeManagerButton.Click += new System.EventHandler(this.removeManagerButton_Click);
            // OrganizersForm
            this.AcceptButton = this.addManagerButton;
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
            this.Name = "OrganizersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Event Managers";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.gridHostPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.organizersDataGridView)).EndInit();
            this.addManagerWrapperPanel.ResumeLayout(false);
            this.addManagerGroupBox.ResumeLayout(false);
            this.addManagerGroupBox.PerformLayout();
            this.actionPanel.ResumeLayout(false);
            this.actionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label heroSublineLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label eventLabel;
        private System.Windows.Forms.ComboBox eventComboBox;
        private System.Windows.Forms.Panel gridHostPanel;
        private System.Windows.Forms.DataGridView organizersDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn organizationColumn;
        private System.Windows.Forms.Panel addManagerWrapperPanel;
        private System.Windows.Forms.GroupBox addManagerGroupBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Label organizationLabel;
        private System.Windows.Forms.TextBox organizationTextBox;
        private System.Windows.Forms.Label managerHelperLabel;
        private System.Windows.Forms.Button addManagerButton;
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.Label actionHintLabel;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button removeManagerButton;
    }
}
