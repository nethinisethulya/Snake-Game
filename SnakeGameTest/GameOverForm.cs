using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SnakeGameTest
{
    public partial class GameOverForm : Form
    {
        private int playerScore;

        // Constructor now accepts score only, as we will get the playerID from the SessionManager
        public GameOverForm(int score)
        {
            InitializeComponent();
            playerScore = score;
            CheckAndDisplayScore();
        }

        // Check if the player's score is a new high score
        private void CheckAndDisplayScore()
        {
            if (SessionManager.IsLoggedIn)
            {
                int playerID = SessionManager.LoggedInUserId; // Get the logged-in player's ID

                using (var connection = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT MAX(Points) FROM Score WHERE PlayerID = @PlayerID";
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PlayerID", playerID);
                        connection.Open();

                        object result = cmd.ExecuteScalar();
                        int? currentHighScore = result != DBNull.Value ? (int?)result : null;

                        if (!currentHighScore.HasValue || playerScore > currentHighScore)
                        {
                            lblScoreInfo.Text = "High Score!";
                            lblScore.Text = $"{playerScore}";
                        }
                        else
                        {
                            lblScoreInfo.Text = $"Your score:";
                            lblScore.Text = $"{playerScore}";
                        }
                    }
                }
            }
            else
            {
                lblScoreInfo.Text = $"Your score:";
                lblScore.Text = $"{playerScore}";
            }
        }

        private bool IsPlayerValid()
        {
            int playerID = SessionManager.LoggedInUserId; // Get the logged-in player's ID

            using (var connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT COUNT(1) FROM Player WHERE PlayerID = @PlayerID";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PlayerID", playerID);
                    connection.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // Return true if player exists, false otherwise
                }
            }
        }

        private void SaveScoreToDatabase()
        {
            if (SessionManager.IsLoggedIn)  // Only save if the user is logged in
            {
                int playerID = SessionManager.LoggedInUserId;  // Get the player's ID from SessionManager

                if (playerID == 0 || !IsPlayerValid())  // Validate playerID
                {
                    MessageBox.Show("Invalid Player ID or player does not exist.");
                    return;
                }

                using (var connection = DatabaseHelper.GetConnection())
                {
                    try
                    {
                        connection.Open();
                        string query = "INSERT INTO Score (Points, PlayerID) VALUES (@Points, @PlayerID)";
                        using (var cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Points", playerScore);
                            cmd.Parameters.AddWithValue("@PlayerID", playerID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show("SQL Error: " + sqlEx.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving score: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("You are not logged in. Score will not be saved.");
            }
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            SaveScoreToDatabase();
            GameplayForm gameplayForm = new GameplayForm();
            gameplayForm.Show();
            this.Close();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            SaveScoreToDatabase();
            MainMenuForm mainMenuForm = new MainMenuForm();
            mainMenuForm.Show();
            this.Close();
        }

        private void GameOverForm_Load(object sender, EventArgs e)
        { }
    }
}
