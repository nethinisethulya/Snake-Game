using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGameTest
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            using (var connection = DatabaseHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT PlayerID, Password FROM Player WHERE Username = @Username";
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPassword = reader["Password"].ToString();

                                // Compare the entered password with the stored one
                                if (password == storedPassword)
                                {
                                    // Successful login
                                    SessionManager.IsLoggedIn = true;
                                    SessionManager.LoggedInUsername = username;
                                    SessionManager.LoggedInUserId = (int)reader["PlayerID"];

                                    MainMenuForm mainMenuForm = new MainMenuForm();
                                    this.Close();
                                    mainMenuForm.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid username or password.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenuForm = new MainMenuForm();
            this.Close();
            mainMenuForm.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            this.Close();
            registerForm.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MainMenuForm m = new MainMenuForm();
            m.Show();
            this.Hide();
        }
    }
}
