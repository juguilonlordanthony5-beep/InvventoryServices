using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace InvventoryServices
{
    public partial class Form1 : Form
    {
        // Keep this in sync with Register connection string or move to a shared location.
        private const string connectionString = @"Data Source=ACER-SWIFT3\SQLEXPRESS;Initial Catalog=InventoryDb;Integrated Security=True;TrustServerCertificate=True;";


        public Form1()
        {
            InitializeComponent();

            // Ensure controls are present in designer. If names differ, update Designer or this code.
            textBox2.UseSystemPasswordChar = true;
            button1.Click += Button1_Click; // Login
            button2.Click += Button2_Click; // Register
        }

        private void Button2_Click(object? sender, EventArgs e)
        {
            using var registerForm = new Register { StartPosition = FormStartPosition.CenterParent };
            Hide();
            registerForm.ShowDialog(this);
            Show();
        }

        private async void Button1_Click(object? sender, EventArgs e)
        {
            var email = textBox1.Text.Trim();
            var password = textBox2.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.", "Missing credentials", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = new SqlConnection(connectionString);
                await conn.OpenAsync();

                using var cmd = new SqlCommand("SELECT PasswordHash, PasswordSalt FROM dbo.Users WHERE Email = @email", conn);
                cmd.Parameters.AddWithValue("@email", email);

                using var reader = await cmd.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                {
                    MessageBox.Show("Invalid email or password.", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var hash = (byte[])reader["PasswordHash"];
                var salt = (byte[])reader["PasswordSalt"];

                var verified = PasswordHelper.Verify(password, salt, hash);
                if (verified)
                {
                    var dashboard = new Dashboard { StartPosition = FormStartPosition.CenterScreen };
                    dashboard.FormClosed += (s, args) => Show();
                    Hide();
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Invalid email or password.", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL error: {sqlEx.Message}", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}



