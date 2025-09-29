using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SnakeGameTest
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();

            if (SessionManager.IsLoggedIn)
            {
                btnLogin.Text = "Logout";
                lblPlayerName.Text = $"{SessionManager.LoggedInUsername}";
                lblPlayerHighscore.Visible = true;

                // Get and display the player's high score
                int highScore = GetPlayerHighScore(SessionManager.LoggedInUserId);
                lblHighscoreLabel.Visible = true ;
                lblPlayerHighscore.Text = $"{highScore}";
            }
            else
            {
                btnLogin.Text = "Login/Register";
                lblPlayerHighscore.Visible = false;
                lblPlayerName.Text = $"Guest Player";
            }
        }

        private int GetPlayerHighScore(int playerId)
        {
            int highScore = 0; // Default score for new players
            using (var connection = DatabaseHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MAX(Points) FROM Score WHERE PlayerID = @PlayerID";
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PlayerID", playerId);
                        var result = cmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            highScore = Convert.ToInt32(result); // If there's a high score, use it
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching high score: " + ex.Message);
                }
            }
            return highScore;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            GameplayForm gameplayForm = new GameplayForm();
            this.Hide();
            gameplayForm.Show();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        { }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsLoggedIn)
            {
                LoginForm loginForm = new LoginForm();
                this.Hide();
                loginForm.Show();
            }
            else
            {
                SessionManager.Logout();
                this.Close();
                MainMenuForm mainMenu = new MainMenuForm();
                mainMenu.Show();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnScoreboard_Click(object sender, EventArgs e)
        {
            ReportForm scoreReportView = new ReportForm();
            scoreReportView.Show();
        }

        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
            LeaderboardReport leaderboardReport = new LeaderboardReport();
            leaderboardReport.Show();
        }
    }
}
