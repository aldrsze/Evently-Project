using System.Data;
using MySqlConnector;

namespace _.Helpers
{
    public static class UserService
    {
        public static DataTable GetUser()
        {
            using var conn = DatabaseConnection.GetConnection();
            string query = "SELECT username, role, is_active FROM users";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


    }
}