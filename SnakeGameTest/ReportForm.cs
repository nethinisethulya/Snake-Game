using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace SnakeGameTest
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            if (!SessionManager.IsLoggedIn)
            {
                MessageBox.Show("No player is logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            try
            {
                // Create and load the Crystal Report
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load("D:\\NIBM\\NIBM Lecture Notes - Diploma\\GUI\\SnakeGameTest\\SnakeGameTest\\SnakeGameTest\\PlayerScoreHistoryReport.rpt");

                // Set database connection
                ConnectionInfo connectionInfo = new ConnectionInfo
                {
                    ServerName = "DESKTOP-EQ55Q8H",
                    DatabaseName = "snakegamedb",
                    IntegratedSecurity = true
                };

                foreach (Table table in reportDocument.Database.Tables)
                {
                    TableLogOnInfo logOnInfo = table.LogOnInfo;
                    logOnInfo.ConnectionInfo = connectionInfo;
                    table.ApplyLogOnInfo(logOnInfo);
                }

                // Pass parameters
                reportDocument.SetParameterValue("PlayerID", SessionManager.LoggedInUserId);
                reportDocument.SetParameterValue("Username", SessionManager.LoggedInUsername);

                // Set the report source for the viewer
                crystalReportViewer1.ReportSource = reportDocument;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}