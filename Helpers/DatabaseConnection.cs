using MySqlConnector;

namespace Evently.Helpers
{
    public static class DatabaseConnection
    {
        public static readonly string connectionString = "Server=localhost;Database=evently_db;User ID=aldrsze;Password=;";

        public static MySqlConnection getConnection()
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static void testConnection()
        {
            using (var conn = getConnection())
            {
                MessageBox.Show("Database Connected Successfully.");
            }
        }

        public static string? getPasswordHash(string username)
        {
            using (var conn = getConnection())
            {
                string query = "SELECT password FROM users WHERE username = @username";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    return cmd.ExecuteScalar()?.ToString();
                }
            }
        }
    }
}