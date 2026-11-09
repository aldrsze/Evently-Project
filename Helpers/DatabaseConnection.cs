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
            MessageBox.Show("Connected to the Evently database.", "Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}