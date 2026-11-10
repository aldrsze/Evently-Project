using MySqlConnector;
using System.IO;

namespace _.Helpers
{
    public static class DatabaseConnection
    {
        public static readonly string connectionString = BuildConnectionString();

        private static string BuildConnectionString()
        {
            string server = "localhost";
            string database = "evently_db";
            string user = "aldrsze";
            string password = "";

            string configPath = Path.Combine(AppContext.BaseDirectory, "db.config");

            // No db.config means we fall back to the local defaults above.
            if (File.Exists(configPath))
            {
                string[] lines = File.ReadAllLines(configPath);

                foreach (string line in lines)
                {
                    string text = line.Trim();

                    if (text.Length == 0 || text.StartsWith("#"))
                    {
                        continue;
                    }

                    int splitAt = text.IndexOf('=');

                    if (splitAt < 0)
                    {
                        continue;
                    }

                    string key = text.Substring(0, splitAt).Trim();
                    string value = text.Substring(splitAt + 1).Trim();

                    if (key == "Server")
                    {
                        server = value;
                    }
                    else if (key == "Database")
                    {
                        database = value;
                    }
                    else if (key == "User")
                    {
                        user = value;
                    }
                    else if (key == "Password")
                    {
                        password = value;
                    }
                }
            }

            return "Server=" + server + ";Database=" + database + ";User ID=" + user + ";Password=" + password + ";";
        }

        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static void TestConnection()
        {
            using var conn = GetConnection();
            MessageBox.Show("Connected to the Evently database.", "Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
