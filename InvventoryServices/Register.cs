using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace InvventoryServices
{
    public partial class Register : Form
    {
        // Keep this in sync with Form1 connection string or move to a shared location.
        private const string connectionString = @"Data Source=ACER-SWIFT3\SQLEXPRESS;Initial Catalog=InventoryDb;Integrated Security=True;TrustServerCertificate=True;";
        public Register()
        {
            InitializeComponent();

            // Hook Register button and mask the password textbox
            button1.Click += Button1_Click;
            textBox3.UseSystemPasswordChar = true;
        }

        private async void Button1_Click(object? sender, EventArgs e)
        {
            var name = textBox1.Text.Trim();
            var email = textBox2.Text.Trim();
            var password = textBox3.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill Name, Email and Password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PasswordHelper.CreateHash(password, out var salt, out var hash);

            try
            {
                using var conn = new SqlConnection(connectionString);
                await conn.OpenAsync();

                // Check email existence
                using (var checkCmd = new SqlCommand("SELECT COUNT(1) FROM dbo.Users WHERE Email = @email", conn))
                {
                    checkCmd.Parameters.AddWithValue("@email", email);
                    var exists = Convert.ToInt32(await checkCmd.ExecuteScalarAsync()) > 0;
                    if (exists)
                    {
                        MessageBox.Show("Email already registered.", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                using var cmd = new SqlCommand(
                    "INSERT INTO dbo.Users (Name, Email, PasswordHash, PasswordSalt, CreatedAt) VALUES (@name, @email, @hash, @salt, SYSUTCDATETIME())",
                    conn);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@hash", hash);
                cmd.Parameters.AddWithValue("@salt", salt);

                var rows = await cmd.ExecuteNonQueryAsync();
                if (rows == 1)
                {
                    MessageBox.Show("Registration successful. Returning to login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close(); // returns to login (Form1) which opened this form
                }
                else
                {
                    MessageBox.Show("Registration failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Designer references label2_Click; provide an empty handler to satisfy the event hookup.
        private void label2_Click(object sender, EventArgs e)
        {
            // no-op
        }
    }
}
