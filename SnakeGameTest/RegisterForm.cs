using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGameTest
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string email = txtEmail.Text;
            string region = cmbRegion.SelectedItem?.ToString();

            // Check for empty fields
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(region))
            {
                MessageBox.Show("All fields are required!");
                return;
            }

            // Validate email format
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address!");
                return;
            }

            // Validate passwords match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            // Validate region selection
            if (cmbRegion.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a region!");
                return;
            }


            // Proceed with registration
            using (var connection = DatabaseHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Player (Username, Password, Email, Region) VALUES (@Username, @Password, @Email, @Region)";
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Region", region);

                        cmd.ExecuteNonQuery();

                        // Now log in the user after successful registration
                        string loginQuery = "SELECT PlayerID FROM Player WHERE Username = @Username";
                        using (var loginCmd = new SqlCommand(loginQuery, connection))
                        {
                            loginCmd.Parameters.AddWithValue("@Username", username);
                            using (var reader = loginCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Set the session manager values
                                    SessionManager.IsLoggedIn = true;
                                    SessionManager.LoggedInUsername = username;
                                    SessionManager.LoggedInUserId = (int)reader["PlayerID"];

                                    MessageBox.Show($"Registration successful! Welcome, {username}!");
                                    MainMenuForm mainMenuForm = new MainMenuForm();
                                    this.Close();
                                    mainMenuForm.Show();

                                    // Close the registration form
                                    this.Close();
                                }
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

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenuForm = new MainMenuForm();
            this.Close();
            mainMenuForm.Show();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
