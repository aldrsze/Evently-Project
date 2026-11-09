using MySqlConnector;

namespace _.Helpers
{
    public static class DatabaseConnection
    {
        public static readonly string connectionString = "Server=localhost;Database=evently_db;User ID=aldrsze;Password=;";

        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static void TestConnection()
        {
            using var conn = GetConnection();
            MessageBox.Show("Database Connected Successfully.");
        }

        public static string? GetPasswordHash(string username)
        {
            using var conn = GetConnection();
            string query = "SELECT password FROM users WHERE username = @username";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            return cmd.ExecuteScalar()?.ToString();
        }
    }
}