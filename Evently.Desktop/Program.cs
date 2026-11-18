using System;
using System.Windows.Forms;
using Evently.Forms;
using Evently.Core.Helpers;

namespace Evently
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (DatabaseConnection.TestConnection())
            {
                MessageBox.Show("Connected to the Evently database.", "Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("NOT Connected to the Evently database.", "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Run(new LoginForm());

        }
    }
}
