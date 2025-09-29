using System.Data;
using System.Data.SqlClient;

public static class DatabaseHelper
{
    private static string connectionString = @"Server=DESKTOP-EQ55Q8H;Database=snakegamedb;Trusted_Connection=True;";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

    public static DataTable GetLeaderboardWithHighScore()
    {
        using (SqlConnection conn = DatabaseHelper.GetConnection())
        {
            string query = @"
            SELECT 
                P.PlayerID, 
                P.Username, 
                P.Region, 
                ISNULL((SELECT MAX(S.Points) 
                        FROM Score S 
                        WHERE S.PlayerID = P.PlayerID), 0) AS HighScore
            FROM 
                Player P
            ORDER BY 
                HighScore DESC;";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }
    }

}
