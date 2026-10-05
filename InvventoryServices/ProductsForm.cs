using System;
using System.Linq;
using System.Windows.Forms;

namespace InvventoryServices
{
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();
            InitializeHandlers();
            btnAddProduct.Click -= btnAddProduct_Click;
            btnAddProduct.Click += btnAddProduct_Click;
            this.Load -= ProductsForm_Load;
            this.Load += ProductsForm_Load;
        }

        public void SetFilters(string category = null, string location = null, string status = null, string search = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(category) && cmbCategory != null && cmbCategory.Items.Contains(category))
                {
                    cmbCategory.SelectedItem = category;
                }

                // call LoadProducts with provided filters
                LoadProducts(search ?? string.Empty, category, location, status);
            }
            catch
            {
                // ignore
            }
        }

        public static void RefreshAllOpenProductForms()
        {
            foreach (var form in Application.OpenForms.OfType<ProductsForm>())
            {
                form.LoadProducts(form.txtSearch.Text);
            }
        }

        private void InitializeHandlers()
        {
            // Wire up all navigation button handlers
            btnDashboard.Click -= btnDashboard_Click;
            btnDashboard.Click += btnDashboard_Click;
            if (btnStockLevels != null)
            {
                btnStockLevels.Click -= btnStockLevels_Click;
                btnStockLevels.Click += btnStockLevels_Click;
            }
            // Stock-In navigation button may not be present in this layout; skip if absent
            if (btnStockOut != null)
            {
                btnStockOut.Click -= btnStockOut_Click;
                btnStockOut.Click += btnStockOut_Click;
            }

            // Wire up logout button if it exists
            foreach (Control control in Controls)
            {
                if (control is Button btn && btn.Name == "button8")
                {
                    btn.Click -= Button8_Click;
                    btn.Click += Button8_Click;
                }
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // Go back to Dashboard
            var dashboardForm = new DashB();
            dashboardForm.StartPosition = FormStartPosition.CenterScreen;
            dashboardForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            dashboardForm.Show();
        }

        private void btnStockLevels_Click(object sender, EventArgs e)
        {
            // Navigate to Stock Levels
            var stockLevelsForm = new Stock_Levels();
            stockLevelsForm.StartPosition = FormStartPosition.CenterScreen;
            stockLevelsForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            stockLevelsForm.Show();
        }

        private void btnStockOut_Click(object sender, EventArgs e)
        {
            // Navigate to Stock-Out
            var stockOutForm = new Inventory_Valuation();
            stockOutForm.StartPosition = FormStartPosition.CenterScreen;
            stockOutForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            stockOutForm.Show();
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            // Navigate to Stock-In
            var stockInForm = new Stock_In();
            stockInForm.StartPosition = FormStartPosition.CenterScreen;
            stockInForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            stockInForm.Show();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            // Log out
            Logout.Execute(this);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text);
        }

        private void cardsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text);
        }

        private void actionsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = "Products.csv",
                Title = "Export Products"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                ExportProducts(dialog.FileName);
                LoadProducts();
                MessageBox.Show("Products exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to export products:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportProducts(string filePath)
        {
            using var conn = DatabaseService.CreateConnection();
            conn.Open();

            if (!TableExists(conn))
            {
                MessageBox.Show("No products to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sb = new System.Text.StringBuilder();
            sb.AppendLine("Product Name,Category,SKU,Current Stock,Min Stock,Price,Status");

            int totalProducts = 0, totalStock = 0, lowStock = 0;
            decimal totalValue = 0m;

            using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                "SELECT ProductName, Category, SKU, CurrentStock, MinStock, Price FROM dbo.Products ORDER BY ProductName", conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var name = reader.GetString(0);
                    var category = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    var sku = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    var currentStock = reader.GetInt32(3);
                    var minStock = reader.GetInt32(4);
                    var price = reader.GetDecimal(5);
                    var status = currentStock <= minStock ? "Low Stock" : "In Stock";

                    sb.AppendLine(string.Join(",",
                        EscapeCsv(name), EscapeCsv(category), EscapeCsv(sku),
                        currentStock, minStock, price.ToString("0.00"), status));

                    totalProducts++;
                    totalStock += currentStock;
                    if (currentStock <= minStock) lowStock++;
                    totalValue += currentStock * price;
                }
            }

            sb.AppendLine();
            sb.AppendLine($"Total Products,{totalProducts}");
            sb.AppendLine($"Total Stock,{totalStock}");
            sb.AppendLine($"Low Stock Items,{lowStock}");
            sb.AppendLine($"Total Inventory Value,PHP {totalValue:N2}");

            System.IO.File.WriteAllText(filePath, sb.ToString());

            UpdateSummary(totalProducts, totalStock, lowStock, totalValue);
        }

        private static string EscapeCsv(string value)
        {
            if (value.Contains(',') || value.Contains('"') || value.Contains('\n'))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }
            return value;
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {

        }

        private void productsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            // Remove button clicked in the Action column
            if (productsGrid.Columns[e.ColumnIndex].Name == "Column7")
            {
                var row = productsGrid.Rows[e.RowIndex];
                if (row.Tag is not int id)
                {
                    return;
                }

                var productName = row.Cells["ProductName"].Value?.ToString() ?? "this product";
                var result = MessageBox.Show(
                    $"Remove {productName}?",
                    "Confirm Remove",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteProduct(id);
                    LoadProducts();
                }
            }
            else if (productsGrid.Columns[e.ColumnIndex].Name == "Column8")
            {
                var row = productsGrid.Rows[e.RowIndex];
                if (row.Tag is not int id2)
                {
                    return;
                }

                // Open Low-Stock Alerts filtered to this product
                Low_Stock_Alerts.OpenAndFilterByProductId(id2);
            }
        }

        private void productsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = productsGrid.Rows[e.RowIndex];
            if (row.Tag is int id && id > 0)
            {
                Low_Stock_Alerts.OpenAndFilterByProductId(id);
            }
        }

        private void DeleteProduct(int id)
        {
            try
            {
                using var conn = DatabaseService.CreateConnection();
                conn.Open();
                using var transaction = conn.BeginTransaction();

                using (var deleteAdjustments = new Microsoft.Data.SqlClient.SqlCommand(
                    "DELETE FROM dbo.InventoryAdjustments WHERE ProductId = @id", conn, transaction))
                {
                    deleteAdjustments.Parameters.AddWithValue("@id", id);
                    deleteAdjustments.ExecuteNonQuery();
                }

                using (var deleteProduct = new Microsoft.Data.SqlClient.SqlCommand(
                    "DELETE FROM dbo.Products WHERE Id = @id", conn, transaction))
                {
                    deleteProduct.Parameters.AddWithValue("@id", id);
                    deleteProduct.ExecuteNonQuery();
                }

                transaction.Commit();
                Stock_Levels.RefreshAllOpenStockLevelsForms();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to remove product:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void leftPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Logout.Execute(this);
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            // populate category dropdown from DB then load products
            LoadCategoryOptions();
            LoadProducts();
        }

        private void LoadCategoryOptions()
        {
            try
            {
                cmbCategory.Items.Clear();
                cmbCategory.Items.Add("All Categories");

                using var conn = DatabaseService.CreateConnection();
                conn.Open();
                using var cmd = new Microsoft.Data.SqlClient.SqlCommand(@"SELECT DISTINCT ISNULL(NULLIF(Category,''),'Uncategorized') FROM dbo.Products ORDER BY 1", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var cat = reader.IsDBNull(0) ? "Uncategorized" : reader.GetString(0);
                    var trimmed = cat?.Trim() ?? "Uncategorized";
                    if (!cmbCategory.Items.Contains(trimmed))
                        cmbCategory.Items.Add(trimmed);
                }

                cmbCategory.SelectedIndex = 0;
            }
            catch
            {
                // ignore and leave default
                if (cmbCategory.Items.Count == 0)
                {
                    cmbCategory.Items.Add("All Categories");
                    cmbCategory.SelectedIndex = 0;
                }
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            using var frm = new AddProductForm();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                LoadProducts(txtSearch.Text);
                RefreshAllOpenProductForms();
                Stock_Levels.RefreshAllOpenStockLevelsForms();
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            productsGrid.EndEdit();
            productsGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);

            var row = GetSelectedProductRow();
            if (row == null || row.Tag is not int id)
            {
                MessageBox.Show("Please select a product to update.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var name = row.Cells["ProductName"].Value?.ToString() ?? "";
            var category = row.Cells["Category"].Value?.ToString() ?? "";
            var sku = row.Cells["Column2"].Value?.ToString() ?? "";
            int.TryParse(row.Cells["Column3"].Value?.ToString(), out var currentStock);
            int.TryParse(row.Cells["Column4"].Value?.ToString(), out var minStock);
            decimal.TryParse(row.Cells["Column5"].Value?.ToString(), out var price);

            using var frm = new AddProductForm(id, name, category, sku, currentStock, minStock, price);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                LoadProducts(txtSearch.Text);
                RefreshAllOpenProductForms();
                Stock_Levels.RefreshAllOpenStockLevelsForms();
            }
        }

        private DataGridViewRow GetSelectedProductRow()
        {
            foreach (DataGridViewRow row in productsGrid.Rows)
            {
                if (row.Cells["Column1"].Value is bool isChecked && isChecked)
                {
                    return row;
                }
            }

            if (productsGrid.SelectedRows.Count > 0)
            {
                return productsGrid.SelectedRows[0];
            }

            return productsGrid.CurrentRow;
        }

        public void LoadProducts(string searchTerm = "", string category = null, string location = null, string status = null)
        {
            try
            {
                productsGrid.Rows.Clear();
                using var conn = DatabaseService.CreateConnection();
                conn.Open();

                if (!TableExists(conn))
                {
                    UpdateSummary(0, 0, 0, 0m);
                    return;
                }

                var sql = "SELECT Id, ProductName, Category, SKU, CurrentStock, MinStock, Price FROM dbo.Products";
                // build dynamic WHERE clause
                var where = new List<string>();
                var parameters = new List<Microsoft.Data.SqlClient.SqlParameter>();

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    where.Add("(ProductName LIKE @term OR SKU LIKE @term OR Category LIKE @term)");
                    parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@term", "%" + searchTerm.Trim() + "%"));
                }

                if (!string.IsNullOrEmpty(category) && category != "All Categories")
                {
                    where.Add("ISNULL(NULLIF(Category,''),'Uncategorized') = @cat");
                    parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@cat", category));
                }

                if (!string.IsNullOrEmpty(location) && location != "All Locations")
                {
                    // only include location filter if column exists
                    try
                    {
                        using var checkConn = DatabaseService.CreateConnection();
                        checkConn.Open();
                        using var ccmd = new Microsoft.Data.SqlClient.SqlCommand("SELECT COUNT(1) FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Products') AND name = 'Location'", checkConn);
                        var v = ccmd.ExecuteScalar();
                        if (v != null && Convert.ToInt32(v) > 0)
                        {
                            where.Add("ISNULL(NULLIF(Location,''),'Unspecified') = @loc");
                            parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@loc", location));
                        }
                    }
                    catch
                    {
                        // ignore missing column
                    }
                }

                if (!string.IsNullOrEmpty(status) && status != "All Status")
                {
                    if (status == "Normal stock")
                        where.Add("CurrentStock > MinStock");
                    else if (status == "Critical (0-5 units)")
                    {
                        where.Add("CurrentStock <= MinStock");
                        where.Add("CurrentStock <= 5");
                    }
                    else if (status == "Warning (6-15 units)")
                    {
                        where.Add("CurrentStock <= MinStock");
                        where.Add("CurrentStock BETWEEN 6 AND 15");
                    }
                    else
                    {
                        // default to low stock for other values
                        where.Add("CurrentStock <= MinStock");
                    }
                }

                if (where.Count > 0)
                {
                    sql += " WHERE " + string.Join(" AND ", where);
                }

                sql += " ORDER BY ProductName";

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(sql, conn))
                {
                    if (parameters.Count > 0)
                        cmd.Parameters.AddRange(parameters.ToArray());

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            var name = reader.GetString(1);
                            var categoryVal = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            var sku = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            var currentStock = reader.GetInt32(4);
                            var minStock = reader.GetInt32(5);
                            var price = reader.GetDecimal(6);
                            var statusVal = currentStock <= minStock ? "Low Stock" : "In Stock";

                            var rowIndex = productsGrid.Rows.Add(false, name, categoryVal, sku, currentStock, minStock, price.ToString("0.00"), statusVal, null);
                            productsGrid.Rows[rowIndex].Tag = id;
                        }
                    }
                }

                LoadSummary(conn, searchTerm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load products:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSummary(Microsoft.Data.SqlClient.SqlConnection conn, string searchTerm = "")
        {
            var sql = @"SELECT
                    COUNT(1),
                    ISNULL(SUM(CurrentStock), 0),
                    ISNULL(SUM(CASE WHEN CurrentStock <= MinStock THEN 1 ELSE 0 END), 0),
                    ISNULL(SUM(CAST(CurrentStock AS DECIMAL(18,2)) * Price), 0)
                  FROM dbo.Products";
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                sql += " WHERE ProductName LIKE @term OR Category LIKE @term OR SKU LIKE @term";
            }

            using var cmd = new Microsoft.Data.SqlClient.SqlCommand(sql, conn);
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                cmd.Parameters.AddWithValue("@term", "%" + searchTerm.Trim() + "%");
            }

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var totalProducts = reader.GetInt32(0);
                var totalStock = reader.GetInt32(1);
                var lowStock = reader.GetInt32(2);
                var totalValue = reader.GetDecimal(3);
                UpdateSummary(totalProducts, totalStock, lowStock, totalValue);
            }
        }

        private void UpdateSummary(int totalProducts, int totalStock, int lowStock, decimal totalValue)
        {
            lblTotalProductsValue.Text = totalProducts.ToString();
            lblCategoriesValue.Text = totalStock.ToString();
            lblLowStockValue.Text = lowStock.ToString();
            lblTotalValueAmount.Text = "PHP " + totalValue.ToString("N2");
        }

        private static bool TableExists(Microsoft.Data.SqlClient.SqlConnection conn)
        {
            using var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                "SELECT COUNT(1) FROM sys.tables WHERE name = 'Products'", conn);
            return (int)cmd.ExecuteScalar() > 0;
        }

        private void lblTotalProducts_Click(object sender, EventArgs e)
        {

        }

        public void SelectProductById(int id)
        {
            try
            {
                // Ensure grid is loaded
                LoadProducts();

                foreach (DataGridViewRow row in productsGrid.Rows)
                {
                    if (row.Tag is int rid && rid == id)
                    {
                        row.Selected = true;
                        productsGrid.CurrentCell = row.Cells[1];
                        productsGrid.FirstDisplayedScrollingRowIndex = row.Index;
                        return;
                    }
                }
            }
            catch
            {
                // ignore errors
            }
        }

        public static void OpenAndSelectProduct(int id)
        {
            var form = new ProductsForm();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Shown += (s, e) =>
            {
                form.SelectProductById(id);
            };
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            var dashboardForm = new Stock_Transfer();
            dashboardForm.StartPosition = FormStartPosition.CenterScreen;
            dashboardForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            dashboardForm.Show();
        }

        private void btnStockIn_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dashboardForm = new Low_Stock_Alerts();
            dashboardForm.StartPosition = FormStartPosition.CenterScreen;
            dashboardForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            dashboardForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dashboardForm = new Adjustment();
            dashboardForm.StartPosition = FormStartPosition.CenterScreen;
            dashboardForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            dashboardForm.Show();
        }
    }
}
