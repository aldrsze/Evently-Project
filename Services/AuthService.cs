using _.Helpers;

namespace Evently.Services
{
    public static class AuthService
    {
        public static Boolean VerifyAuth(String username, String password)
        {
            try
            {
                string? storedHash = DatabaseConnection.GetPasswordHash(username);

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
    }
}