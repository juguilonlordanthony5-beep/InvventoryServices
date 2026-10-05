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
    public partial class Low_Stock_Alerts : Form
    {
        private readonly List<(int Id, string ProductName, string Category, string SKU, int CurrentStock, int MinStock, string Location)> _lowStockProducts;

        public Low_Stock_Alerts()
            : this(new List<(int Id, string ProductName, string Category, string SKU, int CurrentStock, int MinStock, string Location)>())
        {
        }

        // Allow other forms to programmatically set the location filter
        public void SetLocationFilter(string? location)
        {
            if (string.IsNullOrWhiteSpace(location)) return;
            try
            {
                // ensure the filter options are loaded
                if (comboBox3 != null && comboBox3.Items.Count == 0)
                {
                    LoadFilterOptions();
                }

                if (comboBox3 != null)
                {
                    var idx = comboBox3.Items.IndexOf(location);
                    if (idx >= 0)
                    {
                        comboBox3.SelectedIndex = idx;
                    }
                    else
                    {
                        comboBox3.Items.Add(location);
                        comboBox3.SelectedItem = location;
                    }

                    // refresh results after setting the filter
                    LoadLowStockProducts();
                }
            }
            catch
            {
                // ignore any problems setting the filter
            }
        }

        public Low_Stock_Alerts(List<(int Id, string ProductName, string Category, string SKU, int CurrentStock, int MinStock, string Location)> lowStockProducts)
        {
            InitializeComponent();
            _lowStockProducts = lowStockProducts ?? new List<(int Id, string ProductName, string Category, string SKU, int CurrentStock, int MinStock, string Location)>();
            InitializeHandlers();
            LoadFilterOptions();
            LoadLowStockProducts();
        }

        private void LoadFilterOptions()
        {
            // Populate category and location filter dropdowns from DB, fall back to defaults
            try
            {
                using var conn = DatabaseService.CreateConnection();
                conn.Open();

                using var cmd = new SqlCommand(@"SELECT DISTINCT ISNULL(NULLIF(Category, ''), 'Uncategorized') AS Category, ISNULL(NULLIF(Location, ''), 'Unspecified') AS Location FROM dbo.Products ORDER BY Category, Location", conn);
                using var reader = cmd.ExecuteReader();
                var categories = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "All Categories" };
                var locations = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "All Locations" };
                while (reader.Read())
                {
                    var cat = reader.IsDBNull(0) ? "Uncategorized" : reader.GetString(0);
                    var loc = reader.IsDBNull(1) ? "Unspecified" : reader.GetString(1);
                    categories.Add(string.IsNullOrWhiteSpace(cat) ? "Uncategorized" : cat);
                    locations.Add(string.IsNullOrWhiteSpace(loc) ? "Unspecified" : loc);
                }

                if (comboBox2 != null)
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(categories.OrderBy(x => x).ToArray());
                    comboBox2.SelectedIndex = 0;
                }

                if (comboBox3 != null)
                {
                    comboBox3.Items.Clear();
                    comboBox3.Items.AddRange(locations.OrderBy(x => x).ToArray());
                    comboBox3.SelectedIndex = 0;
                }
            }
            catch
            {
                // ignore and leave defaults
                if (comboBox2 != null && comboBox2.Items.Count == 0)
                {
                    comboBox2.Items.Add("All Categories");
                    comboBox2.SelectedIndex = 0;
                }
                if (comboBox3 != null && comboBox3.Items.Count == 0)
                {
                    comboBox3.Items.Add("All Locations");
                    comboBox3.SelectedIndex = 0;
                }
            }

            // Status options
            if (comboBox4 != null)
            {
                comboBox4.Items.Clear();
                comboBox4.Items.AddRange(new object[] { "All Status", "Critical (0-5 units)", "Warning (6-15 units)", "Normal stock" });
                comboBox4.SelectedIndex = 0;
            }
        }

        private static bool IsPlaceholderProductName(string? productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
                return true;

            var value = productName.Trim();
            if (value.Length < 3)
                return true;

            var lowered = value.ToLowerInvariant();
            return lowered.Contains("dads") || lowered.Contains("dsad") || lowered.Contains("zab") ||
                   lowered.Contains("test") || lowered.Contains("sample") || lowered.Contains("dummy") ||
                   lowered.Contains("placeholder") || lowered.Contains("example");
        }

        private void LoadLowStockProducts(int? productId = null)
        {
            var products = new List<(int Id, string ProductName, string Category, string SKU, int CurrentStock, int MinStock, string Location)>();

            try
            {
                using var conn = DatabaseService.CreateConnection();
                conn.Open();

                var sb = new StringBuilder();
                sb.Append("SELECT Id, ProductName, ISNULL(Category, ''), ISNULL(SKU, ''), CurrentStock, MinStock, ISNULL(Location, '') FROM dbo.Products");

                // build filters
                var where = new List<string>();
                // store parameter name/value pairs to avoid reusing SqlParameter instances
                var parameters = new List<(string name, object value)>();

                // product id will be applied at the end so the product is included even if it doesn't match other filters

                // status filter (comboBox4)
                var statusSel = comboBox4?.SelectedItem?.ToString() ?? "All Status";
                if (statusSel == "Normal stock")
                {
                    where.Add("CurrentStock > MinStock");
                }
                else
                {
                    // default to low stock
                    where.Add("CurrentStock <= MinStock");
                    if (statusSel == "Critical (0-5 units)")
                    {
                        where.Add("CurrentStock <= 5");
                    }
                    else if (statusSel == "Warning (6-15 units)")
                    {
                        where.Add("CurrentStock BETWEEN 6 AND 15");
                    }
                }

                // category filter (comboBox2)
                var catSel = comboBox2?.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(catSel) && catSel != "All Categories")
                {
                    where.Add("ISNULL(NULLIF(Category,''),'Uncategorized') = @cat");
                    parameters.Add(("@cat", catSel));
                }

                // location filter (comboBox3)
                var locSel = comboBox3?.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(locSel) && locSel != "All Locations")
                {
                    where.Add("ISNULL(NULLIF(Location,''),'Unspecified') = @loc");
                    parameters.Add(("@loc", locSel));
                }

                // text search (txtSearch)
                var search = txtSearch?.Text?.Trim();
                if (!string.IsNullOrEmpty(search))
                {
                    where.Add("(ProductName LIKE @search OR SKU LIKE @search OR Category LIKE @search)");
                    parameters.Add(("@search", "%" + search + "%"));
                }

                // build final where clause and ensure productId is included if requested
                string finalWhere = string.Empty;
                if (where.Count > 0)
                {
                    finalWhere = " WHERE " + string.Join(" AND ", where);
                }

                if (productId.HasValue)
                {
                    // include the specific product even if it doesn't match other filters
                    if (!string.IsNullOrEmpty(finalWhere))
                    {
                        finalWhere = finalWhere + " OR Id = @pid";
                    }
                    else
                    {
                        finalWhere = " WHERE Id = @pid";
                    }
                    parameters.Add(("@pid", productId.Value));
                }

                // load summary counts for the cards using same filters
                try
                {
                    var countsSql = @"SELECT 
                                        ISNULL(SUM(CASE WHEN CurrentStock <= MinStock THEN 1 ELSE 0 END),0) AS TotalLow,
                                        ISNULL(SUM(CASE WHEN CurrentStock <= MinStock AND CurrentStock <= 5 THEN 1 ELSE 0 END),0) AS Critical,
                                        ISNULL(SUM(CASE WHEN CurrentStock <= MinStock AND CurrentStock BETWEEN 6 AND 15 THEN 1 ELSE 0 END),0) AS Warning,
                                        ISNULL(SUM(CASE WHEN CurrentStock > MinStock THEN 1 ELSE 0 END),0) AS Normal
                                       FROM dbo.Products" + finalWhere;

                    using var countsCmd = new SqlCommand(countsSql, conn);
                    if (parameters.Count > 0)
                    {
                        foreach (var p in parameters)
                        {
                            countsCmd.Parameters.AddWithValue(p.name, p.value ?? DBNull.Value);
                        }
                    }
#if DEBUG
                    try
                    {
                        System.Diagnostics.Debug.WriteLine("[LowStock] Counts SQL: " + countsCmd.CommandText);
                        foreach (SqlParameter dp in countsCmd.Parameters)
                        {
                            System.Diagnostics.Debug.WriteLine($"[LowStock] Param: {dp.ParameterName} = {dp.Value ?? "<null>"}");
                        }
                    }
                    catch { }
#endif
                    using var countsReader = countsCmd.ExecuteReader();
                    if (countsReader.Read())
                    {
                        lblTotalProductsValue.Text = countsReader.GetInt32(0).ToString();
                        lblCategoriesValue.Text = countsReader.GetInt32(1).ToString();
                        lblLowStockValue.Text = countsReader.GetInt32(2).ToString();
                        lblTotalValueAmount.Text = countsReader.GetInt32(3).ToString();
                    }
                }
                catch
                {
                    // ignore summary failures and leave existing labels
                }

                sb.Append(finalWhere);
                sb.Append(" ORDER BY ProductName");

                using var cmd = new SqlCommand(sb.ToString(), conn);
                if (parameters.Count > 0)
                {
                    foreach (var p in parameters)
                    {
                        cmd.Parameters.AddWithValue(p.name, p.value ?? DBNull.Value);
                    }
                }
#if DEBUG
                try
                {
                    System.Diagnostics.Debug.WriteLine("[LowStock] Final SQL: " + cmd.CommandText);
                    foreach (SqlParameter dp in cmd.Parameters)
                    {
                        System.Diagnostics.Debug.WriteLine($"[LowStock] Param: {dp.ParameterName} = {dp.Value ?? "<null>"}");
                    }
                }
                catch { }
#endif
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    var productName = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    if (IsPlaceholderProductName(productName))
                        continue;

                    var category = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    var sku = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    var current = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                    var min = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                    var location = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);

                    products.Add((id, productName, category, sku, current, min, location));
                }
            }
            catch
            {
                products = _lowStockProducts
                    .Where(p => !IsPlaceholderProductName(p.ProductName))
                    .ToList();
            }

            if (products.Count == 0 && _lowStockProducts.Count > 0)
            {
                products = _lowStockProducts
                    .Where(p => !IsPlaceholderProductName(p.ProductName))
                    .ToList();
            }

            // Populate the DataGridView that exists in the designer so headers and labels stay visible.
            if (dataGridView1 == null)
            {
                return;
            }

            dataGridView1.Rows.Clear();
            if (products.Count == 0)
            {
                // first column is a checkbox column (boolean) so provide a boolean value
                dataGridView1.Rows.Add(false, "No low stock items", "-", "-", "-", "-", "Healthy", "-", "-");
                UpdateCards(new List<(int Id, string ProductName, string Category, string SKU, int CurrentStock, int MinStock, string Location)>());
                return;
            }

            foreach (var product in products)
            {
                var status = product.CurrentStock <= product.MinStock ? "Low Stock" : "Healthy";
                int rowIndex = dataGridView1.Rows.Add(false, product.ProductName, product.Category, product.SKU, product.CurrentStock, product.MinStock, status, product.Location, "View");
                var row = dataGridView1.Rows[rowIndex];
                // attach id directly
                row.Tag = product.Id;
                // color-code the status cell
                if (status == "Low Stock")
                {
                    row.Cells[6].Style.BackColor = Color.Orange;
                    row.Cells[6].Style.ForeColor = Color.White;
                }
            }

            // update cards based on the products currently shown (fallback if DB counts failed earlier)
            try
            {
                lblTotalProductsValue.Text = products.Count.ToString();
                lblCategoriesValue.Text = products.Count(p => p.CurrentStock <= 5).ToString(); // critical
                lblLowStockValue.Text = products.Count(p => p.CurrentStock >= 6 && p.CurrentStock <= 15).ToString(); // warning
                lblTotalValueAmount.Text = products.Count(p => p.CurrentStock > p.MinStock).ToString(); // normal
            }
            catch
            {
                // ignore
            }
        }

        public static void OpenAndFilterByProductId(int id)
        {
            var form = new Low_Stock_Alerts();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Shown += (s, e) =>
            {
                try
                {
                    form.LoadLowStockProducts(id);
                }
                catch
                {
                    // ignore
                }
            };
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var col = dataGridView1.Columns[e.ColumnIndex];
            if (col == null) return;

            if (col.Name == "Action")
            {
                var row = dataGridView1.Rows[e.RowIndex];
                if (row.Tag is int id && id > 0)
                {
                    // Open products form and select this product
                    ProductsForm.OpenAndSelectProduct(id);
                }
                else
                {
                    MessageBox.Show("Product details not available.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void UpdateCards(List<(int Id, string ProductName, string Category, string SKU, int CurrentStock, int MinStock, string Location)> products)
        {
            if (products == null) return;
            lblTotalProductsValue.Text = products.Count.ToString();
            lblCategoriesValue.Text = products.Select(p => string.IsNullOrEmpty(p.Category) ? "Uncategorized" : p.Category).Distinct().Count().ToString();
            lblLowStockValue.Text = products.Count.ToString();
            // total value is not calculated here (requires Price); keep placeholder
            lblTotalValueAmount.Text = "PHP -";
        }

        // Called by other forms to update the checkbox state for a product row
        public void SetProductRowChecked(int productId, bool isChecked)
        {
            if (dataGridView1 == null) return;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var row = dataGridView1.Rows[i];
                if (row.Tag is int id && id == productId)
                {
                    // first column is checkbox
                    try
                    {
                        row.Cells[0].Value = isChecked;
                    }
                    catch
                    {
                        // ignore
                    }
                    break;
                }
            }
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

            // wire refresh/search handlers
            if (btnSearch != null)
            {
                btnSearch.Click -= BtnRefresh_Click;
                btnSearch.Click += BtnRefresh_Click;
            }

            if (button5 != null)
            {
                button5.Click -= BtnRefresh_Click;
                button5.Click += BtnRefresh_Click;
            }

            // add Apply Filters button dynamically to panel5 (saves Category/Location to DB for filtered rows)
            try
            {
                if (panel5 != null)
                {
                    var applyBtn = new Button();
                    applyBtn.Name = "btnApplyFilters";
                    applyBtn.Text = "Apply";
                    applyBtn.BackColor = Color.Green;
                    applyBtn.ForeColor = Color.White;
                    applyBtn.Size = new Size(374, 54);
                    // place below existing refresh button (button5)
                    applyBtn.Location = new Point(15, 506);
                    applyBtn.Click += BtnApply_Click;
                    // avoid adding duplicate
                    var exists = panel5.Controls.OfType<Button>().Any(b => b.Name == applyBtn.Name);
                    if (!exists)
                    {
                        panel5.Controls.Add(applyBtn);
                    }
                }
            }
            catch
            {
                // ignore UI creation errors
            }

            if (txtSearch != null)
            {
                txtSearch.KeyDown -= TxtSearch_KeyDown;
                txtSearch.KeyDown += TxtSearch_KeyDown;
            }

            // wire filter dropdowns
            if (comboBox2 != null)
            {
                comboBox2.SelectedIndexChanged -= Filters_Changed;
                comboBox2.SelectedIndexChanged += Filters_Changed;
            }
            if (comboBox3 != null)
            {
                comboBox3.SelectedIndexChanged -= Filters_Changed;
                comboBox3.SelectedIndexChanged += Filters_Changed;
            }
            if (comboBox4 != null)
            {
                comboBox4.SelectedIndexChanged -= Filters_Changed;
                comboBox4.SelectedIndexChanged += Filters_Changed;
            }
        }

        private void Filters_Changed(object? sender, EventArgs e)
        {
            LoadLowStockProducts();
            // propagate filters to any open ProductsForm
            try
            {
                var catSel = comboBox2?.SelectedItem?.ToString();
                var locSel = comboBox3?.SelectedItem?.ToString();
                var statusSel = comboBox4?.SelectedItem?.ToString();
                var search = txtSearch?.Text?.Trim();

                foreach (var frm in Application.OpenForms.OfType<ProductsForm>())
                {
                    try
                    {
                        // use public setter to apply filters
                        frm.SetFilters(catSel, locSel, statusSel, search ?? string.Empty);
                    }
                    catch
                    {
                        // ignore individual form errors
                    }
                }
            }
            catch
            {
                // ignore propagation errors
            }
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            LoadLowStockProducts();
        }

        private void TxtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadLowStockProducts();
            }
        }

        private void BtnApply_Click(object? sender, EventArgs e)
        {
            // Gather filter selections and ensure columns exist before building SQL
            var statusSel = comboBox4?.SelectedItem?.ToString() ?? "All Status";
            var catSel = comboBox2?.SelectedItem?.ToString();
            var locSel = comboBox3?.SelectedItem?.ToString();
            var search = txtSearch?.Text?.Trim();

            try
            {
                using var conn = DatabaseService.CreateConnection();
                conn.Open();

                // helper to check column existence
                bool ColumnExists(string tbl, string col)
                {
                    using var c = new SqlCommand("SELECT COUNT(1) FROM sys.columns WHERE object_id = OBJECT_ID(@tbl) AND name = @col", conn);
                    c.Parameters.AddWithValue("@tbl", tbl);
                    c.Parameters.AddWithValue("@col", col);
                    var v = c.ExecuteScalar();
                    return (v != null && Convert.ToInt32(v) > 0);
                }

                var hasCategory = ColumnExists("dbo.Products", "Category");
                var hasLocation = ColumnExists("dbo.Products", "Location");

                // If target columns don't exist offer to create them
                if (!string.IsNullOrEmpty(catSel) && catSel != "All Categories" && !hasCategory)
                {
                    var createCat = MessageBox.Show("Column 'Category' does not exist in Products table. Create it?", "Create Column", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (createCat == DialogResult.Yes)
                    {
                        using var addCmd = new SqlCommand("ALTER TABLE dbo.Products ADD Category NVARCHAR(200) NULL", conn);
                        addCmd.ExecuteNonQuery();
                        hasCategory = true;
                    }
                    else
                    {
                        return;
                    }
                }

                if (!string.IsNullOrEmpty(locSel) && locSel != "All Locations" && !hasLocation)
                {
                    var createLoc = MessageBox.Show("Column 'Location' does not exist in Products table. Create it?", "Create Column", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (createLoc == DialogResult.Yes)
                    {
                        using var addCmd = new SqlCommand("ALTER TABLE dbo.Products ADD Location NVARCHAR(200) NULL", conn);
                        addCmd.ExecuteNonQuery();
                        hasLocation = true;
                    }
                    else
                    {
                        return;
                    }
                }

                // build where and parameters using only available columns
                var where = new List<string>();
                var parameters = new List<(string name, object value)>();

                if (statusSel == "Normal stock")
                {
                    where.Add("CurrentStock > MinStock");
                }
                else
                {
                    where.Add("CurrentStock <= MinStock");
                    if (statusSel == "Critical (0-5 units)") where.Add("CurrentStock <= 5");
                    else if (statusSel == "Warning (6-15 units)") where.Add("CurrentStock BETWEEN 6 AND 15");
                }

                if (!string.IsNullOrEmpty(catSel) && catSel != "All Categories" && hasCategory)
                {
                    // validate that the selected category actually exists in the Products table
                    try
                    {
                        using var vc = new SqlCommand("SELECT COUNT(1) FROM dbo.Products WHERE ISNULL(NULLIF(Category,''),'Uncategorized') = @val", conn);
                        vc.Parameters.AddWithValue("@val", catSel);
                        var cnt = (int)vc.ExecuteScalar();
                        if (cnt == 0)
                        {
                            MessageBox.Show($"Selected category '{catSel}' does not exist in the database. Clear or choose a different category.", "Filter Value Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    catch
                    {
                        // if validation fails, fall back to adding the filter (non-fatal)
                    }

                    where.Add("ISNULL(NULLIF(Category,''),'Uncategorized') = @cat");
                    parameters.Add(("@cat", catSel));
                }

                if (!string.IsNullOrEmpty(locSel) && locSel != "All Locations" && hasLocation)
                {
                    // validate that the selected location exists in the Products table
                    try
                    {
                        using var vl = new SqlCommand("SELECT COUNT(1) FROM dbo.Products WHERE ISNULL(NULLIF(Location,''),'Unspecified') = @val", conn);
                        vl.Parameters.AddWithValue("@val", locSel);
                        var cntLoc = (int)vl.ExecuteScalar();
                        if (cntLoc == 0)
                        {
                            MessageBox.Show($"Selected location '{locSel}' does not exist in the database. Clear or choose a different location.", "Filter Value Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    catch
                    {
                        // if validation fails, fall back to adding the filter
                    }

                    where.Add("ISNULL(NULLIF(Location,''),'Unspecified') = @loc");
                    parameters.Add(("@loc", locSel));
                }

                if (!string.IsNullOrEmpty(search))
                {
                    where.Add("(ProductName LIKE @search OR SKU LIKE @search" + (hasCategory ? " OR Category LIKE @search" : "") + ")");
                    parameters.Add(("@search", "%" + search + "%"));
                }

                // Determine which columns to update
                var setClauses = new List<string>();
                // store set-parameter name/value pairs separately
                var setParams = new List<(string name, object value)>();
                if (!string.IsNullOrEmpty(catSel) && catSel != "All Categories" && hasCategory)
                {
                    setClauses.Add("Category = @newCat");
                    setParams.Add(("@newCat", catSel));
                }
                if (!string.IsNullOrEmpty(locSel) && locSel != "All Locations" && hasLocation)
                {
                    setClauses.Add("Location = @newLoc");
                    setParams.Add(("@newLoc", locSel));
                }

                if (setClauses.Count == 0)
                {
                    MessageBox.Show("No target column selected to update. Choose a Category or Location to apply.", "Apply Filters", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var whereSql = where.Count > 0 ? " WHERE " + string.Join(" AND ", where) : string.Empty;

                // count affected rows
                using var countCmd = new SqlCommand("SELECT COUNT(1) FROM dbo.Products" + whereSql, conn);
                if (parameters.Count > 0)
                {
                    foreach (var p in parameters)
                    {
                        countCmd.Parameters.AddWithValue(p.name, p.value ?? DBNull.Value);
                    }
                }
                var affected = (int)countCmd.ExecuteScalar();

                if (affected == 0)
                {
                    MessageBox.Show("No products match the selected filters.", "Apply Filters", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var confirm = MessageBox.Show($"This will update {affected} product(s). Continue?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;

                using var tran = conn.BeginTransaction();
                try
                {
                    var updateSql = "UPDATE dbo.Products SET " + string.Join(", ", setClauses) + whereSql;
                    using var updateCmd = new SqlCommand(updateSql, conn, tran);
                    if (setParams.Count > 0)
                    {
                        foreach (var p in setParams)
                        {
                            updateCmd.Parameters.AddWithValue(p.name, p.value ?? DBNull.Value);
                        }
                    }
                    if (parameters.Count > 0)
                    {
                        foreach (var p in parameters)
                        {
                            updateCmd.Parameters.AddWithValue(p.name, p.value ?? DBNull.Value);
                        }
                    }
                    var rows = updateCmd.ExecuteNonQuery();
                    tran.Commit();
                    MessageBox.Show($"Updated {rows} product(s).", "Apply Filters", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show($"Failed to update products:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to apply filters:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // refresh UI
            LoadFilterOptions();
            LoadLowStockProducts();
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
            var productsForm = new ProductsForm();
            productsForm.StartPosition = FormStartPosition.CenterScreen;
            productsForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            productsForm.Show();
        }

        private void BtnStockIn_Click(object sender, EventArgs e)
        {
            var productsForm = new ProductsForm();
            productsForm.StartPosition = FormStartPosition.CenterScreen;
            productsForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            productsForm.Show();
        }

        private void BtnStockOut_Click(object sender, EventArgs e)
        {
            // Stock-Out is not implemented; avoid opening a blank window
            MessageBox.Show("Stock-Out is not available in this version.", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
