using System.Data;
using MySqlConnector;
using _.Helpers;

namespace _.Services
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

        public static bool AddUser(string username, string password, string role)
        {
            string hashPassword = PasswordHelper.HashPassword(password);
            using var conn = DatabaseConnection.GetConnection();
            string query = @"INSERT INTO users(username, password, role)
                             VALUES
                             (@username, @hashPassword, @role)";

            using MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@hashPassword", hashPassword);
            cmd.Parameters.AddWithValue("@role", role);

            try
            {
                return cmd.ExecuteNonQuery() > 0; // checks if it changes a row in a table 1 > 0 == true
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) { return false; } // catches duplicates
                throw;
            }
        }

        public static bool SetUserActive(string username, bool isActive)
        {
            using var conn = DatabaseConnection.GetConnection();
            string query = @"UPDATE users
                             SET is_active = @isActive
                             WHERE username = @username AND is_active <> @isActive";

            using MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@isActive", isActive);
            cmd.Parameters.AddWithValue("@username", username);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool UpdateUser(string oldUsername, string newUsername, string role, string newPassword)
        {
            bool changePassword = newPassword != "";

            using var conn = DatabaseConnection.GetConnection();
            string query;

            if (changePassword)
            {
                query = @"UPDATE users
                          SET username = @newUsername, role = @role, password = @password
                          WHERE username = @oldUsername";
            }
            else
            {
                query = @"UPDATE users
                          SET username = @newUsername, role = @role
                          WHERE username = @oldUsername";
            }

            using MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@newUsername", newUsername);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@oldUsername", oldUsername);

            if (changePassword)
            {
                cmd.Parameters.AddWithValue("@password", PasswordHelper.HashPassword(newPassword));
            }

            try
            {
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) { return false; } // new username already taken
                throw;
            }
        }


    }
}