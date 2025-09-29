public static class SessionManager
{
    public static bool IsLoggedIn { get; set; } = false;
    public static string LoggedInUsername { get; set; } = null;
    public static int LoggedInUserId { get; set; } = 0;

    public static void Logout()
    {
        IsLoggedIn = false;
        LoggedInUsername = null;
        LoggedInUserId = 0;
    }
}
