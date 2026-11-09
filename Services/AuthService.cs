using _.Helpers;
using MySqlConnector;

namespace Evently.Services
{
    public static class AuthService
    {
        public static Boolean VerifyAuth(String username, String password)
        {
            try
            {
                string? storedHash = GetPasswordHash(username);

                if (storedHash != null && PasswordHelper.VerifyPassword(password, storedHash))
                {
                    MessageBox.Show("Login Successful.");
                    return true;
                } // end if
                else
                {
                    MessageBox.Show("Invalid username or password.");
                    return false;
                } // end else
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            } // end catch
        }
        public static string? GetPasswordHash(string username)
        {
            using var conn = DatabaseConnection.GetConnection();
            string query = "SELECT password FROM users WHERE username = @username";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            return cmd.ExecuteScalar()?.ToString();
        }
    }
}