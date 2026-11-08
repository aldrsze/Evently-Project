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
            this.eventsDataGridView = new System.Windows.Forms.DataGridView();
            this.createButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventsDataGridView)).BeginInit();
            this.SuspendLayout();
            // eventsDataGridView
            this.eventsDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.eventsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.eventsDataGridView.Name = "eventsDataGridView";
            this.eventsDataGridView.Size = new System.Drawing.Size(560, 330);
            this.eventsDataGridView.TabIndex = 0;
            // createButton
            this.createButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.createButton.Location = new System.Drawing.Point(290, 350);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(90, 30);
            this.createButton.Text = "Create";
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // editButton
            this.editButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.editButton.Location = new System.Drawing.Point(386, 350);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(90, 30);
            this.editButton.Text = "Edit";
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // deleteButton
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.deleteButton.Location = new System.Drawing.Point(482, 350);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(90, 30);
            this.deleteButton.Text = "Delete";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // EventListForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 392);
            this.Controls.Add(this.eventsDataGridView);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.deleteButton);
            this.Name = "EventListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Events";
            ((System.ComponentModel.ISupportInitialize)(this.eventsDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView eventsDataGridView;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
    }
}