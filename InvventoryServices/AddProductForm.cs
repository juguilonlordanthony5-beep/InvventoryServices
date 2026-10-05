using Microsoft.Data.SqlClient;

namespace InvventoryServices
{
    public partial class AddProductForm : Form
    {
        private int? _productId;

        public AddProductForm()
        {
            InitializeComponent();
        }

        public AddProductForm(int productId, string name, string category, string sku, int currentStock, int minStock, decimal price)
            : this()
        {
            _productId = productId;
            txtName.Text = name;
            txtCategory.Text = category;
            txtSKU.Text = sku;
            numCurrentStock.Value = Math.Clamp(currentStock, numCurrentStock.Minimum, numCurrentStock.Maximum);
            numMinStock.Value = Math.Clamp(minStock, numMinStock.Minimum, numMinStock.Maximum);
            numPrice.Value = Math.Clamp(price, numPrice.Minimum, numPrice.Maximum);
            this.Text = "Update Product";
            btnSave.Text = "Update";
        }

        public string ProductNameValue => txtName.Text.Trim();
        public string CategoryValue => txtCategory.Text.Trim();
        public string SKUValue => txtSKU.Text.Trim();
        public int CurrentStock => (int)numCurrentStock.Value;
        public int MinStock => (int)numMinStock.Value;
        public decimal Price => numPrice.Value;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductNameValue))
            {
                MessageBox.Show("Please enter a product name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            try
            {
                EnsureProductsTable();
                if (_productId.HasValue)
                {
                    UpdateProduct(_productId.Value);
                }
                else
                {
                    InsertProduct();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save product:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private static void EnsureProductsTable()
        {
            using var conn = DatabaseService.CreateConnection();
            conn.Open();
            using var cmd = new SqlCommand(
                @"IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Products')
                  BEGIN
                    CREATE TABLE dbo.Products (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        ProductName NVARCHAR(200) NOT NULL,
                        Category NVARCHAR(100) NULL,
                        SKU NVARCHAR(100) NULL,
                        CurrentStock INT NOT NULL DEFAULT 0,
                        MinStock INT NOT NULL DEFAULT 0,
                        Price DECIMAL(18,2) NOT NULL DEFAULT 0,
                        CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
                    )
                  END", conn);
            cmd.ExecuteNonQuery();
        }

        private void InsertProduct()
        {
            using var conn = DatabaseService.CreateConnection();
            conn.Open();
            using var cmd = new SqlCommand(
                @"INSERT INTO dbo.Products (ProductName, Category, SKU, CurrentStock, MinStock, Price)
                  VALUES (@name, @category, @sku, @currentStock, @minStock, @price);
                  SELECT SCOPE_IDENTITY();", conn);
            cmd.Parameters.AddWithValue("@name", ProductNameValue);
            cmd.Parameters.AddWithValue("@category", (object?)CategoryValue ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@sku", (object?)SKUValue ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@currentStock", CurrentStock);
            cmd.Parameters.AddWithValue("@minStock", MinStock);
            cmd.Parameters.AddWithValue("@price", Price);
            var result = cmd.ExecuteScalar();
            int newProductId = 0;
            if (result != null && int.TryParse(result.ToString(), out var nid))
            {
                newProductId = nid;
            }

            // create an initial batch record for this product so it appears in Batch Tracking
            try
            {
                EnsureProductBatchesTable(conn);
                InsertInitialBatch(conn, newProductId);
            }
            catch
            {
                // ignore batch insert errors to avoid blocking product creation
            }

            // persist dashboard stock snapshot after product creation
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
                DatabaseService.SaveRecentTransaction("Product", $"Added product: {ProductNameValue} (Id={newProductId})");
            }
            catch { }
        }

        private static void EnsureProductBatchesTable(SqlConnection conn)
        {
            using var cmd = new SqlCommand(
                @"IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ProductBatches')
                  BEGIN
                    CREATE TABLE dbo.ProductBatches (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        ProductId INT NOT NULL,
                        BatchNo NVARCHAR(100) NULL,
                        Qty INT NOT NULL DEFAULT 0,
                        UnitCost DECIMAL(18,2) NOT NULL DEFAULT 0,
                        ExpiryDate DATETIME2 NULL,
                        CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
                    )
                  END", conn);
            cmd.ExecuteNonQuery();

            // update dashboard stock snapshot after product update
            try
            {
                DatabaseService.SaveStockSummarySnapshot();
            }
            catch
            {
                // ignore
            }
        }

        private void InsertInitialBatch(SqlConnection conn, int productId)
        {
            if (productId <= 0) return;

            var batchNo = !string.IsNullOrWhiteSpace(SKUValue) ? SKUValue : $"BATCH-{productId}-{DateTime.UtcNow:yyyyMMddHHmmss}";

            using var cmd = new SqlCommand(
                @"INSERT INTO dbo.ProductBatches (ProductId, BatchNo, Qty, UnitCost, ExpiryDate)
                  VALUES (@productId, @batchNo, @qty, @unitCost, @expiry)", conn);
            cmd.Parameters.AddWithValue("@productId", productId);
            cmd.Parameters.AddWithValue("@batchNo", (object)batchNo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@qty", CurrentStock);
            cmd.Parameters.AddWithValue("@unitCost", Price);
            cmd.Parameters.AddWithValue("@expiry", DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        private void UpdateProduct(int id)
        {
            using var conn = DatabaseService.CreateConnection();
            conn.Open();
            using var cmd = new SqlCommand(
                @"UPDATE dbo.Products
                  SET ProductName = @name, Category = @category, SKU = @sku,
                      CurrentStock = @currentStock, MinStock = @minStock, Price = @price
                  WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", ProductNameValue);
            cmd.Parameters.AddWithValue("@category", (object?)CategoryValue ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@sku", (object?)SKUValue ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@currentStock", CurrentStock);
            cmd.Parameters.AddWithValue("@minStock", MinStock);
            cmd.Parameters.AddWithValue("@price", Price);
            cmd.ExecuteNonQuery();

            try
            {
                DatabaseService.SaveRecentTransaction("Product", $"Updated product: {ProductNameValue} (Id={id})");
            }
            catch { }
        }
    }
}
