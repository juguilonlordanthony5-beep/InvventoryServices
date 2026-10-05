using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvventoryServices
{
    public partial class Stock_Levels : Form
    {
        public Stock_Levels()
        {
            InitializeComponent();
            InitializeHandlers();
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            btnSearch.Click += btnSearch_Click;
            btnExport.Click += btnExport_Click;
            btnAddProduct.Click += btnAddProduct_Click;
            btnViewAll.Click += btnViewAll_Click;
            txtSearch.TextChanged += txtSearch_TextChanged;
            this.Load += Stock_Levels_Load;
            LoadStockLevels();
        }

        public static void RefreshAllOpenStockLevelsForms()
        {
            foreach (var form in Application.OpenForms.OfType<Stock_Levels>())
            {
                form.LoadStockLevels();
            }
        }

        private void LoadStockLevels(string searchTerm = "")
        {
            try
            {
                if (dataGridView1 == null)
                    return;

                dataGridView1.Rows.Clear();

                using var conn = DatabaseService.CreateConnection();
                conn.Open();

                var sql = @"SELECT Id, ProductName, Category, SKU, CurrentStock, MinStock,
                             CASE WHEN CurrentStock <= MinStock THEN 'Low Stock' ELSE 'In Stock' END AS Status
                      FROM dbo.Products";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    sql += " WHERE ProductName LIKE @term OR Category LIKE @term OR SKU LIKE @term";
                }

                sql += " ORDER BY ProductName";

                using var cmd = new Microsoft.Data.SqlClient.SqlCommand(sql, conn);
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    cmd.Parameters.AddWithValue("@term", "%" + searchTerm.Trim() + "%");
                }

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var name = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    var category = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    var sku = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    var currentStock = reader.GetInt32(4);
                    var minStock = reader.GetInt32(5);
                    var status = reader.GetString(6);

                    var rowIndex = dataGridView1.Rows.Add(false, name, category, sku, currentStock, minStock, status, currentStock <= minStock ? "Low" : "OK", "Remove");
                    dataGridView1.Rows[rowIndex].Tag = id;
                }

                if (dataGridView1.Rows.Count == 0)
                {
                    dataGridView1.Rows.Add(false, "No products", "", "", "0", "0", "No Stock", "-", "-");
                }

                UpdateStockSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load stock levels:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStockSummary()
        {
            try
            {
                using var conn = DatabaseService.CreateConnection();
                conn.Open();

                using var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                    @"SELECT
                        COUNT(*) AS TotalProducts,
                        SUM(CASE WHEN CurrentStock > 0 AND CurrentStock > MinStock THEN 1 ELSE 0 END) AS InStock,
                        SUM(CASE WHEN CurrentStock <= MinStock AND CurrentStock > 0 THEN 1 ELSE 0 END) AS LowStock,
                        SUM(CASE WHEN CurrentStock <= 0 THEN 1 ELSE 0 END) AS OutOfStock
                    FROM dbo.Products", conn);

                using var reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    SetSummaryValues(0, 0, 0, 0);
                    return;
                }

                var totalProducts = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                var inStock = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                var lowStock = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                var outOfStock = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

                SetSummaryValues(totalProducts, inStock, lowStock, outOfStock);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load stock summary:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetSummaryValues(int totalProducts, int inStock, int lowStock, int outOfStock)
        {
            if (lblTotalProductsValue != null)
                lblTotalProductsValue.Text = totalProducts.ToString();

            if (lblCategoriesValue != null)
                lblCategoriesValue.Text = inStock.ToString();

            if (lblLowStockValue != null)
                lblLowStockValue.Text = lowStock.ToString();

            if (lblTotalValueAmount != null)
                lblTotalValueAmount.Text = outOfStock.ToString();
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
            MessageBox.Show("You are already on the Stock Levels page.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            // Stock-Out removed: inform user
            MessageBox.Show("Stock-Out feature has been removed in this build.", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStockLevels(txtSearch.Text);
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadStockLevels();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            using var frm = new AddProductForm();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                LoadStockLevels(txtSearch.Text);
                RefreshAllOpenStockLevelsForms();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = "StockLevels.csv",
                Title = "Export Stock Levels"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("Product Name,Category,SKU,Current Stock,Min Stock,Status,Stock Level");

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    var name = row.Cells["ProductName"].Value?.ToString() ?? "";
                    var category = row.Cells["Category"].Value?.ToString() ?? "";
                    var sku = row.Cells["SKU"].Value?.ToString() ?? "";
                    var currentStock = row.Cells["CurrentStock"].Value?.ToString() ?? "";
                    var minStock = row.Cells["MinStock"].Value?.ToString() ?? "";
                    var status = row.Cells["Status"].Value?.ToString() ?? "";
                    var stockLevel = row.Cells["StockLevel"].Value?.ToString() ?? "";

                    sb.AppendLine($"{EscapeCsv(name)},{EscapeCsv(category)},{EscapeCsv(sku)},{currentStock},{minStock},{EscapeCsv(status)},{EscapeCsv(stockLevel)}");
                }

                System.IO.File.WriteAllText(dialog.FileName, sb.ToString());
                MessageBox.Show("Stock levels exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to export stock levels:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string EscapeCsv(string value)
        {
            if (value.Contains(',') || value.Contains('"') || value.Contains('\n'))
            {
                return '"' + value.Replace("\"", "\"\"") + '"';
            }

            return value;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name != "Action")
                return;

            var row = dataGridView1.Rows[e.RowIndex];
            if (row.Tag is not int id)
                return;

            var productName = row.Cells["ProductName"].Value?.ToString() ?? "this product";
            var result = MessageBox.Show($"Remove {productName}?", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
                return;

            try
            {
                using var conn = DatabaseService.CreateConnection();
                conn.Open();
                using var cmd = new Microsoft.Data.SqlClient.SqlCommand("DELETE FROM dbo.Products WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                LoadStockLevels(txtSearch.Text);
                RefreshAllOpenStockLevelsForms();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to remove product:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadStockLevels();
                return;
            }

            LoadStockLevels(txtSearch.Text);
        }

        private void Stock_Levels_Load(object sender, EventArgs e)
        {
            LoadStockLevels();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
