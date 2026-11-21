using MySqlConnector;

namespace Evently.Core.Helpers
{
    public static class DatabaseConnection
    {
        private static string BuildConnectionString()
        {
            // The build copies db.config next to the exe, so the path is always known.
            string configPath = Path.Combine(AppContext.BaseDirectory, "db.config");

            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException("db.config not found next to the app.", configPath);
            }

            string[] lines = File.ReadAllLines(configPath);

            string server = ReadValue(lines, "Server");
            string database = ReadValue(lines, "Database");
            string user = ReadValue(lines, "User");
            string password = ReadValue(lines, "Password");

            if (server.Length == 0)
            {
                throw new InvalidDataException("db.config has no Server.");
            }

            if (database.Length == 0)
            {
                throw new InvalidDataException("db.config has no Database.");
            }

            if (user.Length == 0)
            {
                throw new InvalidDataException("db.config has no User.");
            }

            // Password stays unchecked, a local MySQL user often has none.
            return "Server=" + server + ";Database=" + database + ";User ID=" + user + ";Password=" + password + ";";
        }

        // Returns "" when the key is not in the file.
        public static string ReadValue(string[] lines, string wantedKey)
        {
            foreach (string line in lines)
            {
                string text = line.Trim();

                if (text.Length == 0)
                {
                    continue;
                }

                if (text.StartsWith('#'))
                {
                    continue;
                }

                int splitAt = text.IndexOf('=');

                if (splitAt < 0)
                {
                    continue;
                }

                string key = text.Substring(0, splitAt).Trim();

                if (key != wantedKey)
                {
                    continue;
                }

                return text.Substring(splitAt + 1).Trim();
            }

            return "";
        }

        public static MySqlConnection GetConnection()
        {
            string connectionString = BuildConnectionString();

            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static bool TestConnection()
        {
            using var conn = GetConnection();
            return conn.State == System.Data.ConnectionState.Open;
        }

    }
}
