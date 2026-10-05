using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace InvventoryServices
{
    public partial class Adjustment : Form
    {
        private sealed class ProductComboItem
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Category { get; set; } = string.Empty;
            public string Sku { get; set; } = string.Empty;

            public override string ToString()
            {
                var info = string.IsNullOrWhiteSpace(Category) ? Name : $"{Name} ({Category})";
                return string.IsNullOrWhiteSpace(Sku) ? info : $"{info} - {Sku}";
            }
        }

        public Adjustment()
        {
            InitializeComponent();
            InitializeHandlers();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            InitializeAdjustmentForm();
            LoadProducts();
            LoadAdjustmentRecords();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is ProductComboItem selectedProduct)
            {
                textBox4.Text = selectedProduct.Category;
            }
        }

        private void InitializeAdjustmentForm()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();

            comboBox2.Items.AddRange(new object[] { "Stock In", "Stock Out", "Correction" });
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.AddRange(new object[] { "Inventory Count", "Damaged", "Returned", "Sales", "Other" });
            comboBox3.SelectedIndex = 0;

            textBox2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            textBox2.ReadOnly = true;
            textBox4.Clear();
        }

        private void LoadProducts()
        {
            comboBox1.Items.Clear();

            try
            {
                using var conn = DatabaseService.CreateConnection();
                conn.Open();
                using var cmd = new SqlCommand(
                    "SELECT Id, ProductName, Category, SKU FROM dbo.Products ORDER BY ProductName", conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var product = new ProductComboItem
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Category = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Sku = reader.IsDBNull(3) ? string.Empty : reader.GetString(3)
                    };

                    comboBox1.Items.Add(product);
                }

                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                    if (comboBox1.SelectedItem is ProductComboItem firstProduct)
                    {
                        textBox4.Text = firstProduct.Category;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load products:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAdjustmentRecords()
        {
            try
            {
                dataGridView1.Rows.Clear();

                using var conn = DatabaseService.CreateConnection();
                conn.Open();

                using var cmd = new SqlCommand(
                    @"SELECT a.Id, p.ProductName, p.Category, p.SKU, a.AdjustmentType, a.Quantity, a.Reason, a.AdjustedAt, a.AdjustedBy
                      FROM dbo.InventoryAdjustments a
                      INNER JOIN dbo.Products p ON p.Id = a.ProductId
                      ORDER BY a.AdjustedAt DESC", conn);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var productName = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    var category = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    var sku = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    var type = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    var quantity = reader.GetInt32(5);
                    var reason = reader.IsDBNull(6) ? "" : reader.GetString(6);
                    var adjustedAt = reader.GetDateTime(7);
                    var adjustedBy = reader.IsDBNull(8) ? "System" : reader.GetString(8);

                    var rowIndex = dataGridView1.Rows.Add(adjustedAt.ToString("yyyy-MM-dd HH:mm"), productName, category, sku, type, quantity, reason, adjustedBy, "Remove");
                    dataGridView1.Rows[rowIndex].Tag = id;
                }
            }
            catch (Exception)
            {
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SaveAdjustmentRecord();
        }

        private void SaveAdjustmentRecord()
        {
            try
            {
                if (comboBox1.SelectedItem is not ProductComboItem selectedProduct)
                {
                    MessageBox.Show("Please select a product before saving.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox1.Text) || !int.TryParse(textBox1.Text, out var quantity) || quantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity greater than 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                var adjustmentType = comboBox2.SelectedItem?.ToString() ?? "Stock In";
                var reason = comboBox3.SelectedItem?.ToString() ?? "Other";
                var notes = textBox3.Text.Trim();
                var adjustedBy = "Admin";
                var category = selectedProduct.Category;

                EnsureAdjustmentTable();

                using var conn = DatabaseService.CreateConnection();
                conn.Open();
                using var transaction = conn.BeginTransaction();

                var currentStock = GetCurrentStock(conn, selectedProduct.Id, transaction);
                var newStock = adjustmentType == "Stock Out" ? currentStock - quantity : currentStock + quantity;
                if (newStock < 0)
                {
                    MessageBox.Show("The new stock would become negative. Please reduce the quantity.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var cmd = new SqlCommand(
                    @"INSERT INTO dbo.InventoryAdjustments (ProductId, ProductName, Category, SKU, AdjustmentType, Quantity, Reason, Notes, AdjustedBy, AdjustedAt)
                      VALUES (@productId, @productName, @category, @sku, @adjustmentType, @quantity, @reason, @notes, @adjustedBy, @adjustedAt)", conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@productId", selectedProduct.Id);
                    cmd.Parameters.AddWithValue("@productName", selectedProduct.Name);
                    cmd.Parameters.AddWithValue("@category", (object?)category ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@sku", (object?)selectedProduct.Sku ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@adjustmentType", adjustmentType);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@reason", reason);
                    cmd.Parameters.AddWithValue("@notes", (object?)notes ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@adjustedBy", adjustedBy);
                    cmd.Parameters.AddWithValue("@adjustedAt", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new SqlCommand(
                    @"UPDATE dbo.Products
                      SET CurrentStock = @newStock
                      WHERE Id = @productId", conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@newStock", newStock);
                    cmd.Parameters.AddWithValue("@productId", selectedProduct.Id);
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();

                MessageBox.Show("Adjustment saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // persist dashboard stock snapshot after adjustment
                try
                {
                    DatabaseService.SaveStockSummarySnapshot();
                }
                catch
                {
                    // ignore
                }

                try
                {
                    // log recent transaction
                    var desc = $"{adjustmentType}: {quantity} x {selectedProduct.Name} ({selectedProduct.Sku}) - {reason}";
                    DatabaseService.SaveRecentTransaction("Adjustment", desc);
                }
                catch { }

                ClearAdjustmentForm();
                LoadProducts();
                LoadAdjustmentRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save adjustment:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static int GetCurrentStock(SqlConnection conn, int productId, SqlTransaction transaction)
        {
            using var cmd = new SqlCommand("SELECT ISNULL(CurrentStock, 0) FROM dbo.Products WHERE Id = @id", conn, transaction);
            cmd.Parameters.AddWithValue("@id", productId);
            var result = cmd.ExecuteScalar();
            return result is null || result is DBNull ? 0 : Convert.ToInt32(result);
        }

        private static void EnsureAdjustmentTable()
        {
            using var conn = DatabaseService.CreateConnection();
            conn.Open();
            using var cmd = new SqlCommand(
                @"IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'InventoryAdjustments')
                  BEGIN
                    CREATE TABLE dbo.InventoryAdjustments (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        ProductId INT NOT NULL,
                        ProductName NVARCHAR(200) NOT NULL,
                        Category NVARCHAR(100) NULL,
                        SKU NVARCHAR(100) NULL,
                        AdjustmentType NVARCHAR(50) NOT NULL,
                        Quantity INT NOT NULL,
                        Reason NVARCHAR(200) NULL,
                        Notes NVARCHAR(500) NULL,
                        AdjustedBy NVARCHAR(100) NULL,
                        AdjustedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
                        CONSTRAINT FK_InventoryAdjustments_Products FOREIGN KEY (ProductId) REFERENCES dbo.Products(Id)
                    )
                  END
                  ELSE
                  BEGIN
                    IF COL_LENGTH('dbo.InventoryAdjustments', 'Category') IS NULL
                    BEGIN
                        ALTER TABLE dbo.InventoryAdjustments ADD Category NVARCHAR(100) NULL;
                    END
                  END", conn);
            cmd.ExecuteNonQuery();
        }

        private void ClearAdjustmentForm()
        {
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }

        private void InitializeHandlers()
        {
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
            // Stock-Out removed: inform the user
            MessageBox.Show("Stock-Out feature has been removed in this build.", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Logout.Execute(this);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name != "Action")
                return;

            var row = dataGridView1.Rows[e.RowIndex];
            if (row.Tag is not int adjustmentId)
                return;

            var productName = row.Cells["ProductName"].Value?.ToString() ?? "this adjustment";
            var result = MessageBox.Show($"Remove adjustment for {productName}?", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
                return;

            try
            {
                using var conn = DatabaseService.CreateConnection();
                conn.Open();

                using var cmd = new SqlCommand("DELETE FROM dbo.InventoryAdjustments WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", adjustmentId);
                cmd.ExecuteNonQuery();

                LoadAdjustmentRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to remove adjustment:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadAdjustmentRecords();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            // keep category selection in sync in the adjustment form
        }
    }
}
