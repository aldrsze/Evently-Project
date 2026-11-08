#nullable disable
namespace Evently.Forms
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea pieChartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend pieLegend = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series pieSeries = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea timelineChartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend timelineLegend = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series timelineSeries = new System.Windows.Forms.DataVisualization.Charting.Series();

            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.heroSublineLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.eventLabel = new System.Windows.Forms.Label();
            this.eventComboBox = new System.Windows.Forms.ComboBox();
            this.autoRefreshLabel = new System.Windows.Forms.Label();
            this.lastUpdatedLabel = new System.Windows.Forms.Label();
            this.dashboardLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.attendanceGroupBox = new System.Windows.Forms.GroupBox();
            this.attendanceSubLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.attendanceMetricsPanel = new System.Windows.Forms.Panel();
            this.progressLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.insideLabel = new System.Windows.Forms.Label();
            this.checkedInLabel = new System.Windows.Forms.Label();
            this.notArrivedLabel = new System.Windows.Forms.Label();
            this.attendancePieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timelineGroupBox = new System.Windows.Forms.GroupBox();
            this.timelineChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.metricsBottomLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.reviewsGroupBox = new System.Windows.Forms.GroupBox();
            this.averageRatingLabel = new System.Windows.Forms.Label();
            this.responseRateLabel = new System.Windows.Forms.Label();
            this.reviewRequestLabel = new System.Windows.Forms.Label();
            this.emailsGroupBox = new System.Windows.Forms.GroupBox();
            this.ticketsEmailedLabel = new System.Windows.Forms.Label();
            this.emailsHelperLabel = new System.Windows.Forms.Label();
            this.recentCheckInsGroupBox = new System.Windows.Forms.GroupBox();
            this.recentCheckInsListBox = new System.Windows.Forms.ListBox();
            this.dashboardTimer = new System.Windows.Forms.Timer(this.components);

            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.dashboardLayoutPanel.SuspendLayout();
            this.attendanceGroupBox.SuspendLayout();
            this.attendanceSubLayoutPanel.SuspendLayout();
            this.attendanceMetricsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attendancePieChart)).BeginInit();
            this.timelineGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timelineChart)).BeginInit();
            this.metricsBottomLayoutPanel.SuspendLayout();
            this.reviewsGroupBox.SuspendLayout();
            this.emailsGroupBox.SuspendLayout();
            this.recentCheckInsGroupBox.SuspendLayout();
            this.SuspendLayout();

            // headerPanel
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.heroSublineLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.headerPanel.Size = new System.Drawing.Size(1024, 64);
            this.headerPanel.TabIndex = 0;

            // titleLabel
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(12, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(149, 25);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Live Dashboard";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // heroSublineLabel
            this.heroSublineLabel.AutoSize = true;
            this.heroSublineLabel.BackColor = System.Drawing.Color.Transparent;
            this.heroSublineLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.heroSublineLabel.ForeColor = System.Drawing.Color.FromArgb(218, 230, 245);
            this.heroSublineLabel.Location = new System.Drawing.Point(12, 38);
            this.heroSublineLabel.Name = "heroSublineLabel";
            this.heroSublineLabel.Size = new System.Drawing.Size(434, 15);
            this.heroSublineLabel.TabIndex = 1;
            this.heroSublineLabel.Text = "Live headcount, entry progress, and attendee satisfaction metrics.";
            this.heroSublineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // contentPanel
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.dashboardLayoutPanel);
            this.contentPanel.Controls.Add(this.topPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 64);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(12);
            this.contentPanel.Size = new System.Drawing.Size(1024, 656);
            this.contentPanel.TabIndex = 1;

            // topPanel
            this.topPanel.BackColor = System.Drawing.Color.White;
            this.topPanel.Controls.Add(this.eventLabel);
            this.topPanel.Controls.Add(this.eventComboBox);
            this.topPanel.Controls.Add(this.autoRefreshLabel);
            this.topPanel.Controls.Add(this.lastUpdatedLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(12, 12);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1000, 38);
            this.topPanel.TabIndex = 0;

            // eventLabel
            this.eventLabel.AutoSize = true;
            this.eventLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.eventLabel.Location = new System.Drawing.Point(0, 10);
            this.eventLabel.Name = "eventLabel";
            this.eventLabel.Size = new System.Drawing.Size(42, 15);
            this.eventLabel.TabIndex = 0;
            this.eventLabel.Text = "Event:";

            // eventComboBox
            this.eventComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.eventComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventComboBox.FormattingEnabled = true;
            this.eventComboBox.Location = new System.Drawing.Point(48, 7);
            this.eventComboBox.Name = "eventComboBox";
            this.eventComboBox.Size = new System.Drawing.Size(580, 23);
            this.eventComboBox.TabIndex = 1;
            this.eventComboBox.SelectedIndexChanged += new System.EventHandler(this.eventComboBox_SelectedIndexChanged);

            // autoRefreshLabel
            this.autoRefreshLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.autoRefreshLabel.AutoSize = true;
            this.autoRefreshLabel.ForeColor = System.Drawing.Color.FromArgb(95, 95, 95);
            this.autoRefreshLabel.Location = new System.Drawing.Point(642, 10);
            this.autoRefreshLabel.Name = "autoRefreshLabel";
            this.autoRefreshLabel.Size = new System.Drawing.Size(232, 15);
            this.autoRefreshLabel.TabIndex = 2;
            this.autoRefreshLabel.Text = "Refreshes automatically every 5 seconds";

            // lastUpdatedLabel
            this.lastUpdatedLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lastUpdatedLabel.AutoSize = true;
            this.lastUpdatedLabel.ForeColor = System.Drawing.Color.FromArgb(95, 95, 95);
            this.lastUpdatedLabel.Location = new System.Drawing.Point(850, 10);
            this.lastUpdatedLabel.Name = "lastUpdatedLabel";
            this.lastUpdatedLabel.Size = new System.Drawing.Size(112, 15);
            this.lastUpdatedLabel.TabIndex = 3;
            this.lastUpdatedLabel.Text = "Updated: --:--";

            // dashboardLayoutPanel
            this.dashboardLayoutPanel.ColumnCount = 2;
            this.dashboardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dashboardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dashboardLayoutPanel.Controls.Add(this.attendanceGroupBox, 0, 0);
            this.dashboardLayoutPanel.Controls.Add(this.timelineGroupBox, 1, 0);
            this.dashboardLayoutPanel.Controls.Add(this.metricsBottomLayoutPanel, 0, 1);
            this.dashboardLayoutPanel.Controls.Add(this.recentCheckInsGroupBox, 1, 1);
            this.dashboardLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardLayoutPanel.Location = new System.Drawing.Point(12, 50);
            this.dashboardLayoutPanel.Name = "dashboardLayoutPanel";
            this.dashboardLayoutPanel.RowCount = 2;
            this.dashboardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54F));
            this.dashboardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.dashboardLayoutPanel.Size = new System.Drawing.Size(1000, 594);
            this.dashboardLayoutPanel.TabIndex = 1;

            // attendanceGroupBox
            this.attendanceGroupBox.BackColor = System.Drawing.Color.White;
            this.attendanceGroupBox.Controls.Add(this.attendanceSubLayoutPanel);
            this.attendanceGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attendanceGroupBox.Location = new System.Drawing.Point(4, 4);
            this.attendanceGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.attendanceGroupBox.Name = "attendanceGroupBox";
            this.attendanceGroupBox.Padding = new System.Windows.Forms.Padding(8);
            this.attendanceGroupBox.Size = new System.Drawing.Size(492, 312);
            this.attendanceGroupBox.TabIndex = 0;
            this.attendanceGroupBox.TabStop = false;
            this.attendanceGroupBox.Text = "Attendance";

            // attendanceSubLayoutPanel
            this.attendanceSubLayoutPanel.ColumnCount = 2;
            this.attendanceSubLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.attendanceSubLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.attendanceSubLayoutPanel.Controls.Add(this.attendanceMetricsPanel, 0, 0);
            this.attendanceSubLayoutPanel.Controls.Add(this.attendancePieChart, 1, 0);
            this.attendanceSubLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attendanceSubLayoutPanel.Location = new System.Drawing.Point(8, 24);
            this.attendanceSubLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.attendanceSubLayoutPanel.Name = "attendanceSubLayoutPanel";
            this.attendanceSubLayoutPanel.RowCount = 1;
            this.attendanceSubLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.attendanceSubLayoutPanel.Size = new System.Drawing.Size(476, 280);
            this.attendanceSubLayoutPanel.TabIndex = 0;

            // attendanceMetricsPanel
            this.attendanceMetricsPanel.Controls.Add(this.progressLabel);
            this.attendanceMetricsPanel.Controls.Add(this.progressBar);
            this.attendanceMetricsPanel.Controls.Add(this.insideLabel);
            this.attendanceMetricsPanel.Controls.Add(this.checkedInLabel);
            this.attendanceMetricsPanel.Controls.Add(this.notArrivedLabel);
            this.attendanceMetricsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attendanceMetricsPanel.Location = new System.Drawing.Point(0, 0);
            this.attendanceMetricsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.attendanceMetricsPanel.Name = "attendanceMetricsPanel";
            this.attendanceMetricsPanel.Padding = new System.Windows.Forms.Padding(4);
            this.attendanceMetricsPanel.Size = new System.Drawing.Size(228, 280);
            this.attendanceMetricsPanel.TabIndex = 0;

            // progressLabel
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(4, 10);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(97, 15);
            this.progressLabel.TabIndex = 0;
            this.progressLabel.Text = "Registered: 0 of 0";

            // progressBar
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.progressBar.Location = new System.Drawing.Point(4, 32);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(218, 16);
            this.progressBar.TabIndex = 1;

            // insideLabel
            this.insideLabel.AutoSize = true;
            this.insideLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.insideLabel.ForeColor = System.Drawing.Color.FromArgb(43, 87, 154);
            this.insideLabel.Location = new System.Drawing.Point(4, 62);
            this.insideLabel.Name = "insideLabel";
            this.insideLabel.Size = new System.Drawing.Size(150, 21);
            this.insideLabel.TabIndex = 2;
            this.insideLabel.Text = "Currently inside: 0";

            // checkedInLabel
            this.checkedInLabel.AutoSize = true;
            this.checkedInLabel.Location = new System.Drawing.Point(4, 94);
            this.checkedInLabel.Name = "checkedInLabel";
            this.checkedInLabel.Size = new System.Drawing.Size(81, 15);
            this.checkedInLabel.TabIndex = 3;
            this.checkedInLabel.Text = "Checked in: 0";

            // notArrivedLabel
            this.notArrivedLabel.AutoSize = true;
            this.notArrivedLabel.Location = new System.Drawing.Point(4, 118);
            this.notArrivedLabel.Name = "notArrivedLabel";
            this.notArrivedLabel.Size = new System.Drawing.Size(100, 15);
            this.notArrivedLabel.TabIndex = 4;
            this.notArrivedLabel.Text = "Not yet arrived: 0";

            // attendancePieChart
            pieChartArea.BackColor = System.Drawing.Color.White;
            pieChartArea.Name = "PieArea";
            this.attendancePieChart.ChartAreas.Add(pieChartArea);
            this.attendancePieChart.Dock = System.Windows.Forms.DockStyle.Fill;
            pieLegend.BackColor = System.Drawing.Color.Transparent;
            pieLegend.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            pieLegend.Font = new System.Drawing.Font("Segoe UI", 8F);
            pieLegend.Name = "PieLegend";
            this.attendancePieChart.Legends.Add(pieLegend);
            this.attendancePieChart.Location = new System.Drawing.Point(232, 0);
            this.attendancePieChart.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.attendancePieChart.Name = "attendancePieChart";
            pieSeries.ChartArea = "PieArea";
            pieSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            pieSeries.CustomProperties = "DoughnutRadius=55, PieLabelStyle=Disabled";
            pieSeries.Legend = "PieLegend";
            pieSeries.Name = "AttendanceBreakdown";
            this.attendancePieChart.Series.Add(pieSeries);
            this.attendancePieChart.Size = new System.Drawing.Size(244, 280);
            this.attendancePieChart.TabIndex = 1;

            // timelineGroupBox
            this.timelineGroupBox.BackColor = System.Drawing.Color.White;
            this.timelineGroupBox.Controls.Add(this.timelineChart);
            this.timelineGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timelineGroupBox.Location = new System.Drawing.Point(504, 4);
            this.timelineGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.timelineGroupBox.Name = "timelineGroupBox";
            this.timelineGroupBox.Padding = new System.Windows.Forms.Padding(8);
            this.timelineGroupBox.Size = new System.Drawing.Size(492, 312);
            this.timelineGroupBox.TabIndex = 1;
            this.timelineGroupBox.TabStop = false;
            this.timelineGroupBox.Text = "Check-Ins Over Time";

            // timelineChart
            timelineChartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
            timelineChartArea.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(95, 95, 95);
            timelineChartArea.AxisX.LineColor = System.Drawing.Color.FromArgb(210, 210, 210);
            timelineChartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(242, 242, 242);
            timelineChartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
            timelineChartArea.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(95, 95, 95);
            timelineChartArea.AxisY.LineColor = System.Drawing.Color.FromArgb(210, 210, 210);
            timelineChartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(242, 242, 242);
            timelineChartArea.BackColor = System.Drawing.Color.White;
            timelineChartArea.Name = "TimelineArea";
            this.timelineChart.ChartAreas.Add(timelineChartArea);
            this.timelineChart.Dock = System.Windows.Forms.DockStyle.Fill;
            timelineLegend.Alignment = System.Drawing.StringAlignment.Far;
            timelineLegend.BackColor = System.Drawing.Color.Transparent;
            timelineLegend.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            timelineLegend.Font = new System.Drawing.Font("Segoe UI", 8F);
            timelineLegend.Name = "TimelineLegend";
            this.timelineChart.Legends.Add(timelineLegend);
            this.timelineChart.Location = new System.Drawing.Point(8, 24);
            this.timelineChart.Name = "timelineChart";
            timelineSeries.BorderWidth = 3;
            timelineSeries.ChartArea = "TimelineArea";
            timelineSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            timelineSeries.Color = System.Drawing.Color.FromArgb(43, 87, 154);
            timelineSeries.Legend = "TimelineLegend";
            timelineSeries.MarkerColor = System.Drawing.Color.FromArgb(43, 87, 154);
            timelineSeries.MarkerSize = 6;
            timelineSeries.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            timelineSeries.Name = "Check-ins";
            this.timelineChart.Series.Add(timelineSeries);
            this.timelineChart.Size = new System.Drawing.Size(476, 280);
            this.timelineChart.TabIndex = 0;

            // metricsBottomLayoutPanel
            this.metricsBottomLayoutPanel.ColumnCount = 2;
            this.metricsBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.metricsBottomLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.metricsBottomLayoutPanel.Controls.Add(this.reviewsGroupBox, 0, 0);
            this.metricsBottomLayoutPanel.Controls.Add(this.emailsGroupBox, 1, 0);
            this.metricsBottomLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metricsBottomLayoutPanel.Location = new System.Drawing.Point(0, 320);
            this.metricsBottomLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.metricsBottomLayoutPanel.Name = "metricsBottomLayoutPanel";
            this.metricsBottomLayoutPanel.RowCount = 1;
            this.metricsBottomLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.metricsBottomLayoutPanel.Size = new System.Drawing.Size(500, 274);
            this.metricsBottomLayoutPanel.TabIndex = 2;

            // reviewsGroupBox
            this.reviewsGroupBox.BackColor = System.Drawing.Color.White;
            this.reviewsGroupBox.Controls.Add(this.averageRatingLabel);
            this.reviewsGroupBox.Controls.Add(this.responseRateLabel);
            this.reviewsGroupBox.Controls.Add(this.reviewRequestLabel);
            this.reviewsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reviewsGroupBox.Location = new System.Drawing.Point(4, 4);
            this.reviewsGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.reviewsGroupBox.Name = "reviewsGroupBox";
            this.reviewsGroupBox.Padding = new System.Windows.Forms.Padding(8);
            this.reviewsGroupBox.Size = new System.Drawing.Size(252, 266);
            this.reviewsGroupBox.TabIndex = 0;
            this.reviewsGroupBox.TabStop = false;
            this.reviewsGroupBox.Text = "Reviews";

            // averageRatingLabel
            this.averageRatingLabel.AutoSize = true;
            this.averageRatingLabel.Location = new System.Drawing.Point(8, 28);
            this.averageRatingLabel.Name = "averageRatingLabel";
            this.averageRatingLabel.Size = new System.Drawing.Size(96, 15);
            this.averageRatingLabel.TabIndex = 0;
            this.averageRatingLabel.Text = "Average rating: -";

            // responseRateLabel
            this.responseRateLabel.AutoSize = true;
            this.responseRateLabel.Location = new System.Drawing.Point(8, 56);
            this.responseRateLabel.Name = "responseRateLabel";
            this.responseRateLabel.Size = new System.Drawing.Size(107, 15);
            this.responseRateLabel.TabIndex = 1;
            this.responseRateLabel.Text = "Response rate: 0%";

            // reviewRequestLabel
            this.reviewRequestLabel.AutoSize = true;
            this.reviewRequestLabel.Location = new System.Drawing.Point(8, 84);
            this.reviewRequestLabel.Name = "reviewRequestLabel";
            this.reviewRequestLabel.Size = new System.Drawing.Size(130, 15);
            this.reviewRequestLabel.TabIndex = 2;
            this.reviewRequestLabel.Text = "Review requests sent: 0";

            // emailsGroupBox
            this.emailsGroupBox.BackColor = System.Drawing.Color.White;
            this.emailsGroupBox.Controls.Add(this.ticketsEmailedLabel);
            this.emailsGroupBox.Controls.Add(this.emailsHelperLabel);
            this.emailsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailsGroupBox.Location = new System.Drawing.Point(264, 4);
            this.emailsGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.emailsGroupBox.Name = "emailsGroupBox";
            this.emailsGroupBox.Padding = new System.Windows.Forms.Padding(8);
            this.emailsGroupBox.Size = new System.Drawing.Size(232, 266);
            this.emailsGroupBox.TabIndex = 1;
            this.emailsGroupBox.TabStop = false;
            this.emailsGroupBox.Text = "Emails";

            // ticketsEmailedLabel
            this.ticketsEmailedLabel.AutoSize = true;
            this.ticketsEmailedLabel.Location = new System.Drawing.Point(8, 28);
            this.ticketsEmailedLabel.Name = "ticketsEmailedLabel";
            this.ticketsEmailedLabel.Size = new System.Drawing.Size(126, 15);
            this.ticketsEmailedLabel.TabIndex = 0;
            this.ticketsEmailedLabel.Text = "Tickets emailed: 0 of 0";

            // emailsHelperLabel
            this.emailsHelperLabel.AutoSize = true;
            this.emailsHelperLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.emailsHelperLabel.ForeColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.emailsHelperLabel.Location = new System.Drawing.Point(8, 56);
            this.emailsHelperLabel.MaximumSize = new System.Drawing.Size(210, 0);
            this.emailsHelperLabel.Name = "emailsHelperLabel";
            this.emailsHelperLabel.Size = new System.Drawing.Size(207, 26);
            this.emailsHelperLabel.TabIndex = 1;
            this.emailsHelperLabel.Text = "Emailed tickets count only attendees with confirmed delivery";

            // recentCheckInsGroupBox
            this.recentCheckInsGroupBox.BackColor = System.Drawing.Color.White;
            this.recentCheckInsGroupBox.Controls.Add(this.recentCheckInsListBox);
            this.recentCheckInsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recentCheckInsGroupBox.Location = new System.Drawing.Point(504, 324);
            this.recentCheckInsGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.recentCheckInsGroupBox.Name = "recentCheckInsGroupBox";
            this.recentCheckInsGroupBox.Padding = new System.Windows.Forms.Padding(8);
            this.recentCheckInsGroupBox.Size = new System.Drawing.Size(492, 266);
            this.recentCheckInsGroupBox.TabIndex = 3;
            this.recentCheckInsGroupBox.TabStop = false;
            this.recentCheckInsGroupBox.Text = "Recent Check-Ins";

            // recentCheckInsListBox
            this.recentCheckInsListBox.BackColor = System.Drawing.Color.White;
            this.recentCheckInsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.recentCheckInsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recentCheckInsListBox.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.recentCheckInsListBox.FormattingEnabled = true;
            this.recentCheckInsListBox.IntegralHeight = false;
            this.recentCheckInsListBox.ItemHeight = 15;
            this.recentCheckInsListBox.Location = new System.Drawing.Point(8, 24);
            this.recentCheckInsListBox.Name = "recentCheckInsListBox";
            this.recentCheckInsListBox.Size = new System.Drawing.Size(476, 234);
            this.recentCheckInsListBox.TabIndex = 0;

            // dashboardTimer
            this.dashboardTimer.Enabled = true;
            this.dashboardTimer.Interval = 5000;
            this.dashboardTimer.Tick += new System.EventHandler(this.dashboardTimer_Tick);

            // DashboardForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 720);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(960, 640);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Live Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;

            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.dashboardLayoutPanel.ResumeLayout(false);
            this.attendanceGroupBox.ResumeLayout(false);
            this.attendanceSubLayoutPanel.ResumeLayout(false);
            this.attendanceMetricsPanel.ResumeLayout(false);
            this.attendanceMetricsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attendancePieChart)).EndInit();
            this.timelineGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timelineChart)).EndInit();
            this.metricsBottomLayoutPanel.ResumeLayout(false);
            this.reviewsGroupBox.ResumeLayout(false);
            this.reviewsGroupBox.PerformLayout();
            this.emailsGroupBox.ResumeLayout(false);
            this.emailsGroupBox.PerformLayout();
            this.recentCheckInsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label heroSublineLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label eventLabel;
        private System.Windows.Forms.ComboBox eventComboBox;
        private System.Windows.Forms.Label autoRefreshLabel;
        private System.Windows.Forms.Label lastUpdatedLabel;
        private System.Windows.Forms.TableLayoutPanel dashboardLayoutPanel;
        private System.Windows.Forms.GroupBox attendanceGroupBox;
        private System.Windows.Forms.TableLayoutPanel attendanceSubLayoutPanel;
        private System.Windows.Forms.Panel attendanceMetricsPanel;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label insideLabel;
        private System.Windows.Forms.Label checkedInLabel;
        private System.Windows.Forms.Label notArrivedLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart attendancePieChart;
        private System.Windows.Forms.GroupBox timelineGroupBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart timelineChart;
        private System.Windows.Forms.TableLayoutPanel metricsBottomLayoutPanel;
        private System.Windows.Forms.GroupBox reviewsGroupBox;
        private System.Windows.Forms.Label averageRatingLabel;
        private System.Windows.Forms.Label responseRateLabel;
        private System.Windows.Forms.Label reviewRequestLabel;
        private System.Windows.Forms.GroupBox emailsGroupBox;
        private System.Windows.Forms.Label ticketsEmailedLabel;
        private System.Windows.Forms.Label emailsHelperLabel;
        private System.Windows.Forms.GroupBox recentCheckInsGroupBox;
        private System.Windows.Forms.ListBox recentCheckInsListBox;
        private System.Windows.Forms.Timer dashboardTimer;
    }
}
