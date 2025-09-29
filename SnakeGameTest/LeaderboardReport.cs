using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGameTest
{
    public partial class LeaderboardReport : Form
    {
        public LeaderboardReport()
        {
            InitializeComponent();
        }

        private void LeaderboardReport_Load(object sender, EventArgs e)
        {
            // Get the leaderboard data from the database
            DataTable leaderboardData = DatabaseHelper.GetLeaderboardWithHighScore();

            // Create a new report object
            GlobalLeaderboardReport report = new GlobalLeaderboardReport();

            // Set the data source for the report
            report.SetDataSource(leaderboardData);

            // Assign the report to the Crystal Report Viewer
            crystalReportViewer1.ReportSource = report;
        }



    }
}
