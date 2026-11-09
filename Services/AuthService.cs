using _.Helpers;
using MySqlConnector;

namespace _.Services
{
    public static class AuthService
    {
        public static bool VerifyAuth(string username, string password)
        {
            string? storedHash = GetPasswordHash(username);

            if (storedHash == null)
            {
                return false;
            }

            return PasswordHelper.VerifyPassword(password, storedHash);
        } // end VerifyAuth

        public static string? GetPasswordHash(string username)
        {
            using var conn = DatabaseConnection.GetConnection();
            string query = "SELECT password FROM users WHERE username = @username AND is_active = 1";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            return cmd.ExecuteScalar()?.ToString();
        }
    }
}