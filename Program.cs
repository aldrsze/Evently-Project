using System;
using System.Windows.Forms;
using Evently.Forms;

namespace Evently
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
            Application.Run(new MainForm());
            Application.Run(new UserListForm());
            Application.Run(new EventListForm());
            Application.Run(new EventEditForm());
            Application.Run(new AttendeesForm());
            Application.Run(new ReviewsForm());
            Application.Run(new CheckInForm());
            Application.Run(new DashboardForm());
        }
    }
}