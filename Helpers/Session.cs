namespace _.Helpers
{
    // who is logged in right now, kept for the whole app run
    public static class Session
    {
        private static string currentUsername = "";
        private static string currentRole = "";

        public static string CurrentUsername
        {
            get { return currentUsername; }
        }

        public static string CurrentRole
        {
            get { return currentRole; }
        }

        public static void SignIn(string username, string role)
        {
            currentUsername = username;
            currentRole = role;
        }

        public static void SignOut()
        {
            currentUsername = "";
            currentRole = "";
        }

        // used when the logged in user renames his own account
        public static void RenameCurrentUser(string newUsername)
        {
            currentUsername = newUsername;
        }
    }
}
