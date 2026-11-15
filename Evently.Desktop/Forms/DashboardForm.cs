using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Evently.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly List<EventSnapshot> _events = new();
        private readonly Random _random = new();

        public DashboardForm()
        {
            InitializeComponent();
            InitializeMockData();
            LoadEventsIntoDropdown();
        }

        private void InitializeMockData()
        {
            _events.Add(new EventSnapshot
            {
                Id = 1,
                Name = "Annual Tech Symposium 2026",
                Capacity = 200,
                Registered = 185,
                CurrentlyInside = 128,
                CheckedOut = 24,
                AverageRating = 4.7,
                ReviewCount = 42,
                ReviewRequestsSent = 152,
                TicketsEmailed = 185,
                Timeline = new List<(string Time, int Count)>
                {
                    ("8:00 AM", 8),
                    ("8:30 AM", 24),
                    ("9:00 AM", 62),
                    ("9:30 AM", 95),
                    ("10:00 AM", 120),
                    ("10:30 AM", 138),
                    ("11:00 AM", 152)
                },
                RecentCheckIns = new List<string>
                {
                    "Sarah Jenkins - 11:02 AM [Check-in]",
                    "Michael Chang - 10:58 AM [Check-in]",
                    "Chloe Alcantara - 10:55 AM [Check-out]",
                    "David Miller - 10:51 AM [Check-in]",
                    "Angela Reyes - 10:48 AM [Check-in]",
                    "Brian Gomez - 10:40 AM [Check-out]",
                    "Patricia Diaz - 10:34 AM [Check-in]",
                    "Ethan Morales - 10:29 AM [Check-in]"
                }
            });

            _events.Add(new EventSnapshot
            {
                Id = 2,
                Name = "Campus Career & Internship Fair",
                Capacity = 350,
                Registered = 310,
                CurrentlyInside = 184,
                CheckedOut = 56,
                AverageRating = 4.4,
                ReviewCount = 68,
                ReviewRequestsSent = 240,
                TicketsEmailed = 310,
                Timeline = new List<(string Time, int Count)>
                {
                    ("9:00 AM", 15),
                    ("9:30 AM", 48),
                    ("10:00 AM", 110),
                    ("10:30 AM", 165),
                    ("11:00 AM", 212),
                    ("11:30 AM", 240)
                },
                RecentCheckIns = new List<string>
                {
                    "Johnathan Cole - 11:32 AM [Check-in]",
                    "Valerie Vance - 11:28 AM [Check-in]",
                    "Marcus Cruz - 11:21 AM [Check-out]",
                    "Elena Rostova - 11:15 AM [Check-in]",
                    "Kenneth Lim - 11:09 AM [Check-in]"
                }
            });

            _events.Add(new EventSnapshot
            {
                Id = 3,
                Name = "Freshmen Orientation & Night Gala",
                Capacity = 150,
                Registered = 150,
                CurrentlyInside = 110,
                CheckedOut = 15,
                AverageRating = 4.9,
                ReviewCount = 54,
                ReviewRequestsSent = 125,
                TicketsEmailed = 150,
                Timeline = new List<(string Time, int Count)>
                {
                    ("4:00 PM", 20),
                    ("4:30 PM", 55),
                    ("5:00 PM", 92),
                    ("5:30 PM", 118),
                    ("6:00 PM", 125)
                },
                RecentCheckIns = new List<string>
                {
                    "Katelyn Smith - 6:01 PM [Check-in]",
                    "Noah Anderson - 5:58 PM [Check-in]",
                    "Samantha Reed - 5:52 PM [Check-out]",
                    "Lucas Rivera - 5:45 PM [Check-in]"
                }
            });
        }

        private void LoadEventsIntoDropdown()
        {
            eventComboBox.DisplayMember = nameof(EventSnapshot.Name);
            eventComboBox.ValueMember = nameof(EventSnapshot.Id);
            eventComboBox.DataSource = _events;

            if (_events.Count > 0)
            {
                eventComboBox.SelectedIndex = 0;
            }
        }

        private void eventComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (eventComboBox.SelectedItem is EventSnapshot snapshot)
            {
                RenderEventDashboard(snapshot);
            }
        }

        private void dashboardTimer_Tick(object sender, EventArgs e)
        {
            if (eventComboBox.SelectedItem is not EventSnapshot currentEvent)
                return;

            // Simulate occasional live gate scans to exhibit real-time visual chart feedback
            if (_random.Next(0, 3) == 0 && currentEvent.TotalCheckedIn < currentEvent.Registered)
            {
                currentEvent.CurrentlyInside++;
                string timeString = DateTime.Now.ToString("h:mm tt");
                currentEvent.RecentCheckIns.Insert(0, $"Guest #{currentEvent.TotalCheckedIn} - {timeString} [Check-in]");
                if (currentEvent.RecentCheckIns.Count > 15)
                {
                    currentEvent.RecentCheckIns.RemoveAt(currentEvent.RecentCheckIns.Count - 1);
                }

                // Append or adjust timeline velocity
                if (currentEvent.Timeline.Count > 0)
                {
                    var last = currentEvent.Timeline[^1];
                    currentEvent.Timeline[^1] = (last.Time, currentEvent.TotalCheckedIn);
                }
            }

            RenderEventDashboard(currentEvent);
        }

        private void RenderEventDashboard(EventSnapshot snapshot)
        {
            // 1. Text Metrics & Progress
            double registeredPercent = snapshot.Capacity > 0 ? (double)snapshot.Registered / snapshot.Capacity : 0;
            progressLabel.Text = $"Registered: {snapshot.Registered} of {snapshot.Capacity} ({registeredPercent:P0})";
            progressBar.Maximum = Math.Max(1, snapshot.Capacity);
            progressBar.Value = Math.Clamp(snapshot.Registered, 0, progressBar.Maximum);

            insideLabel.Text = $"Currently inside: {snapshot.CurrentlyInside}";
            double turnoutPercent = snapshot.Registered > 0 ? (double)snapshot.TotalCheckedIn / snapshot.Registered : 0;
            checkedInLabel.Text = $"Checked in: {snapshot.TotalCheckedIn} ({turnoutPercent:P0} turnout)";
            notArrivedLabel.Text = $"Not yet arrived: {snapshot.NotArrived}";

            averageRatingLabel.Text = $"Average rating: {snapshot.AverageRating:F1} / 5.0 ({snapshot.ReviewCount} reviews)";
            double responsePercent = snapshot.TotalCheckedIn > 0 ? (double)snapshot.ReviewCount / snapshot.TotalCheckedIn : 0;
            responseRateLabel.Text = $"Response rate: {responsePercent:P0}";
            reviewRequestLabel.Text = $"Review requests sent: {snapshot.ReviewRequestsSent} of {snapshot.TotalCheckedIn}";

            ticketsEmailedLabel.Text = $"Tickets emailed: {snapshot.TicketsEmailed} of {snapshot.Registered}";
            lastUpdatedLabel.Text = $"Last updated: {DateTime.Now:hh:mm:ss tt}";

            // 2. Attendance Doughnut Chart
            BindAttendancePieChart(snapshot);

            // 3. Check-Ins Over Time Spline Chart
            BindTimelineChart(snapshot);

            // 4. Recent Check-Ins Feed
            recentCheckInsListBox.BeginUpdate();
            recentCheckInsListBox.Items.Clear();
            foreach (var record in snapshot.RecentCheckIns)
            {
                recentCheckInsListBox.Items.Add(record);
            }
            recentCheckInsListBox.EndUpdate();
        }

        private void BindAttendancePieChart(EventSnapshot snapshot)
        {
            var series = attendancePieChart.Series["AttendanceBreakdown"];
            series.Points.Clear();

            // Slice 1: Currently Inside
            var pInside = new DataPoint();
            pInside.SetValueXY("Inside", snapshot.CurrentlyInside);
            pInside.LegendText = $"Inside ({snapshot.CurrentlyInside})";
            pInside.Color = Color.FromArgb(43, 87, 154); // Theme Blue
            pInside.ToolTip = $"Inside: {snapshot.CurrentlyInside}";
            series.Points.Add(pInside);

            // Slice 2: Checked Out
            var pOut = new DataPoint();
            pOut.SetValueXY("Checked Out", snapshot.CheckedOut);
            pOut.LegendText = $"Checked Out ({snapshot.CheckedOut})";
            pOut.Color = Color.FromArgb(91, 142, 219); // Muted Steel Blue
            pOut.ToolTip = $"Checked Out: {snapshot.CheckedOut}";
            series.Points.Add(pOut);

            // Slice 3: Not Arrived
            int notArrived = snapshot.NotArrived;
            var pNotArrived = new DataPoint();
            pNotArrived.SetValueXY("Not Arrived", notArrived);
            pNotArrived.LegendText = $"Not Arrived ({notArrived})";
            pNotArrived.Color = Color.FromArgb(220, 226, 235); // Clean Slate Gray
            pNotArrived.ToolTip = $"Not Arrived: {notArrived}";
            series.Points.Add(pNotArrived);
        }

        private void BindTimelineChart(EventSnapshot snapshot)
        {
            var series = timelineChart.Series["Check-ins"];
            series.Points.Clear();

            foreach (var (timeSlot, count) in snapshot.Timeline)
            {
                var point = new DataPoint();
                point.SetValueXY(timeSlot, count);
                point.ToolTip = $"{timeSlot}: {count} total check-ins";
                series.Points.Add(point);
            }
        }

        private class EventSnapshot
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public int Capacity { get; set; }
            public int Registered { get; set; }
            public int CurrentlyInside { get; set; }
            public int CheckedOut { get; set; }
            public int TotalCheckedIn => CurrentlyInside + CheckedOut;
            public int NotArrived => Math.Max(0, Registered - TotalCheckedIn);
            public double AverageRating { get; set; }
            public int ReviewCount { get; set; }
            public int ReviewRequestsSent { get; set; }
            public int TicketsEmailed { get; set; }
            public List<(string Time, int Count)> Timeline { get; set; } = new();
            public List<string> RecentCheckIns { get; set; } = new();
        }
    }
}
