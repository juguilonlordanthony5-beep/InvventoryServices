using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace InvventoryServices
{
    public partial class Stock_Transfer : Form
    {
        public Stock_Transfer()
        {
            InitializeComponent();
            InitializeHandlers();

            button9.Click += button9_Click;
            button5.Click += button5_Click;
            button5.Click += (s, e) => ResetForm();

            LoadProductsForTransfer();
            LoadLocations();
            LoadRecentTransfers();
        }

        private void LoadProductsForTransfer()
        {
            cmbCategory.Items.Clear();

            try
            {
                using var conn = DatabaseService.CreateConnection();
                conn.Open();
                using var cmd = new SqlCommand("SELECT ProductName FROM dbo.Products ORDER BY ProductName", conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var productName = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    if (!string.IsNullOrWhiteSpace(productName))
                    {
                        cmbCategory.Items.Add(productName);
                    }
                }

                if (cmbCategory.Items.Count > 0)
                {
                    cmbCategory.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load products:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLocations()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            var locations = new[]
            {
                "Main Warehouse",
                "Sales Floor",
                "Storage Room",
                "Outlet",
                "Cold Storage"
            };

            comboBox1.Items.AddRange(locations);
            comboBox2.Items.AddRange(locations);

            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
            if (comboBox2.Items.Count > 1) comboBox2.SelectedIndex = 1;
        }

        private void LoadRecentTransfers()
        {
            try
            {
                dataGridView1.Rows.Clear();
                EnsureTransfersTable();

                using var conn = DatabaseService.CreateConnection();
                conn.Open();

                using var cmd = new SqlCommand(
                    @"SELECT Id, ProductName, Quantity, FromLocation, ToLocation, Remarks, TransferDate
                      FROM dbo.InventoryTransfers ORDER BY TransferDate DESC", conn);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var productName = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    var quantity = reader.GetInt32(2);
                    var fromLocation = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    var toLocation = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    var remarks = reader.IsDBNull(5) ? "" : reader.GetString(5);
                    var transferDate = reader.GetDateTime(6);

                    var rowIndex = dataGridView1.Rows.Add(transferDate.ToString("yyyy-MM-dd HH:mm"), productName, quantity, fromLocation, toLocation, remarks, "Remove");
                    dataGridView1.Rows[rowIndex].Tag = id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load recent transfers:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SaveTransfer();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
            if (comboBox2.Items.Count > 1) comboBox2.SelectedIndex = 1;
            textBox1.Clear();
            textBox2.Clear();
        }

        private void SaveTransfer()
        {
            try
            {
                var productName = cmbCategory.SelectedItem?.ToString();
                if (string.IsNullOrWhiteSpace(productName))
                {
                    MessageBox.Show("Please select a product.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox1.Text) || !int.TryParse(textBox1.Text, out var quantity) || quantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity greater than 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                var fromLocation = comboBox1.SelectedItem?.ToString();
                var toLocation = comboBox2.SelectedItem?.ToString();

                if (string.IsNullOrWhiteSpace(fromLocation) || string.IsNullOrWhiteSpace(toLocation))
                {
                    MessageBox.Show("Please select both transfer locations.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.Equals(fromLocation, toLocation, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("From location and To location cannot be the same.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                EnsureTransfersTable();

                using var conn = DatabaseService.CreateConnection();
                conn.Open();
                using var cmd = new SqlCommand(
                    @"INSERT INTO dbo.InventoryTransfers (ProductName, Quantity, FromLocation, ToLocation, Remarks, TransferDate)
                      VALUES (@productName, @quantity, @fromLocation, @toLocation, @remarks, @transferDate)", conn);

                cmd.Parameters.AddWithValue("@productName", productName);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@fromLocation", fromLocation);
                cmd.Parameters.AddWithValue("@toLocation", toLocation);
                cmd.Parameters.AddWithValue("@remarks", string.IsNullOrWhiteSpace(textBox2.Text) ? (object)DBNull.Value : textBox2.Text);
                cmd.Parameters.AddWithValue("@transferDate", DateTime.Now);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Stock transfer saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                LoadRecentTransfers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save stock transfer:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void EnsureTransfersTable()
        {
            using var conn = DatabaseService.CreateConnection();
            conn.Open();
            using var cmd = new SqlCommand(
                @"IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'InventoryTransfers')
                  BEGIN
                    CREATE TABLE dbo.InventoryTransfers (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        ProductName NVARCHAR(200) NOT NULL,
                        Quantity INT NOT NULL,
                        FromLocation NVARCHAR(100) NOT NULL,
                        ToLocation NVARCHAR(100) NOT NULL,
                        Remarks NVARCHAR(500) NULL,
                        TransferDate DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
                    )
                  END", conn);
            cmd.ExecuteNonQuery();
        }

        private void InitializeHandlers()
        {
            // Wire up all navigation button handlers
            if (Controls.Count > 0)
            {
                foreach (Control control in Controls)
                {
                    if (control is Button btn)
                    {
                        switch (btn.Name)
                        {
                            case "btnDashboard":
                                btn.Click -= BtnDashboard_Click;
                                btn.Click += BtnDashboard_Click;
                                break;
                            case "btnProducts":
                                btn.Click -= BtnProducts_Click;
                                btn.Click += BtnProducts_Click;
                                break;
                            case "btnStockLevels":
                                btn.Click -= BtnStockLevels_Click;
                                btn.Click += BtnStockLevels_Click;
                                break;
                            case "btnStockIn":
                                btn.Click -= BtnStockIn_Click;
                                btn.Click += BtnStockIn_Click;
                                break;
                            case "btnStockOut":
                                btn.Click -= BtnStockOut_Click;
                                btn.Click += BtnStockOut_Click;
                                break;
                            case "button1":
                                btn.Click -= Button1_Click;
                                btn.Click += Button1_Click;
                                break;
                            case "button2":
                                btn.Click -= Button2_Click;
                                btn.Click += Button2_Click;
                                break;
                            case "button3":
                                btn.Click -= Button3_Click;
                                btn.Click += Button3_Click;
                                break;
                            case "button4":
                                btn.Click -= Button4_Click;
                                btn.Click += Button4_Click;
                                break;
                            case "button5":
                                btn.Click -= Button5_Click;
                                btn.Click += Button5_Click;
                                break;
                            case "button6":
                                btn.Click -= Button6_Click;
                                btn.Click += Button6_Click;
                                break;
                            case "button7":
                                btn.Click -= Button7_Click;
                                btn.Click += Button7_Click;
                                break;
                            case "button8":
                                btn.Click -= Button8_Click;
                                btn.Click += Button8_Click;
                                break;
                        }
                    }
                }
            }
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            var dashboardForm = new DashB();
            dashboardForm.StartPosition = FormStartPosition.CenterScreen;
            dashboardForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            dashboardForm.Show();
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            var productsForm = new ProductsForm();
            productsForm.StartPosition = FormStartPosition.CenterScreen;
            productsForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            productsForm.Show();
        }

        private void BtnStockLevels_Click(object sender, EventArgs e)
        {
            var stockLevelsForm = new Stock_Levels();
            stockLevelsForm.StartPosition = FormStartPosition.CenterScreen;
            stockLevelsForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            stockLevelsForm.Show();
        }

        private void BtnStockIn_Click(object sender, EventArgs e)
        {
            var stockInForm = new Stock_In();
            stockInForm.StartPosition = FormStartPosition.CenterScreen;
            stockInForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            stockInForm.Show();
        }

        private void BtnStockOut_Click(object sender, EventArgs e)
        {
            // Stock-Out form is not implemented in this build. Avoid opening a blank window.
            MessageBox.Show("Stock-Out is not available in this version.", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already on the Stock Transfer page.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var frm = new Adjustment();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormClosed += (s, args) => this.Show();
            this.Hide();
            frm.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var frm = new Low_Stock_Alerts();
            frm.StartPosition = FormStartPosition.CenterScreen;
            try
            {
                // propagate the currently selected 'From' location to the alerts filter
                var currentFrom = comboBox1?.SelectedItem?.ToString();
                if (!string.IsNullOrWhiteSpace(currentFrom))
                {
                    frm.SetLocationFilter(currentFrom);
                }
            }
            catch
            {
                // ignore if unable to propagate
            }
            frm.FormClosed += (s, args) => this.Show();
            this.Hide();
            frm.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var frm = new ExpiryBatch_Tracking();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormClosed += (s, args) => this.Show();
            this.Hide();
            frm.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var frm = new Inventory_Valuation();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormClosed += (s, args) => this.Show();
            this.Hide();
            frm.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reports is not available in this version.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            var frm = new Settings();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormClosed += (s, args) => this.Show();
            this.Hide();
            frm.Show();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Logout.Execute(this);
        }

        private void Stock_Transfer_Load(object sender, EventArgs e)
        {
            LoadRecentTransfers();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
        }
    }
}
