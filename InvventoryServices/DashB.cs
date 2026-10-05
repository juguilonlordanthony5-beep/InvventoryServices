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
    public partial class DashB : Form
    {
        private readonly string _userEmail;
        private List<KeyValuePair<string, int>> _lowStockByCategory = new();

        public DashB()
        {
            InitializeComponent();
            InitializeHandlers();
            InitializeChart();
            this.Load += DashB_Load;
            this.VisibleChanged += DashB_VisibleChanged;
        }

    private void SaveStockSummary(int totalProducts, int totalStock, int lowStock, decimal totalValue)
    {
        try
        {
            using var conn = DatabaseService.CreateConnection();
            conn.Open();

            using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(@"
                IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'StockSummaries')
                BEGIN
                    CREATE TABLE dbo.StockSummaries(
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        SummaryDate DATE NOT NULL,
                        TotalProducts INT NULL,
                        TotalStock INT NULL,
                        LowStockCount INT NULL,
                        TotalValue DECIMAL(18,2) NULL,
                        CreatedAt DATETIME NOT NULL DEFAULT(GETDATE())
                    );
                END", conn))
            {
                cmd.ExecuteNonQuery();
            }

            using var icmd = new Microsoft.Data.SqlClient.SqlCommand(@"INSERT INTO dbo.StockSummaries (SummaryDate, TotalProducts, TotalStock, LowStockCount, TotalValue) VALUES (CAST(GETDATE() AS DATE), @totalProducts, @totalStock, @lowStock, @totalValue);", conn);
            icmd.Parameters.AddWithValue("@totalProducts", totalProducts);
            icmd.Parameters.AddWithValue("@totalStock", totalStock);
            icmd.Parameters.AddWithValue("@lowStock", lowStock);
            icmd.Parameters.AddWithValue("@totalValue", totalValue);
            icmd.ExecuteNonQuery();
        }
        catch
        {
            // ignore persistence errors
        }
    }

        public DashB(string userEmail)
        {
            InitializeComponent();
            _userEmail = userEmail;
            InitializeHandlers();
            InitializeChart();
            this.Load += DashB_Load;
            this.VisibleChanged += DashB_VisibleChanged;
        }

        private void InitializeHandlers()
        {
            // wire navigation handlers (designer wires some already)
            btnDashboard.Click -= btnDashboard_Click;
            btnDashboard.Click += btnDashboard_Click;
            btnProducts.Click -= btnProducts_Click;
            btnProducts.Click += btnProducts_Click;
            if (btnStockLevels != null)
            {
                btnStockLevels.Click -= btnStockLevels_Click;
                btnStockLevels.Click += btnStockLevels_Click;
            }
            if (btnStockIn != null)
            {
                btnStockIn.Click -= btnStockIn_Click;
                btnStockIn.Click += btnStockIn_Click;
            }

            // other sidebar buttons (named generically in designer as button1..button7)
            if (button1 != null)
            {
                button1.Click -= button1_Click; // Adjustment
                button1.Click += button1_Click;
            }
            if (button2 != null)
            {
                button2.Click -= button2_Click; // Low-Stock Alerts
                button2.Click += button2_Click;
            }
            if (button3 != null)
            {
                button3.Click -= button3_Click; // Expiry & Batch Tracking
                button3.Click += button3_Click;
            }
            if (button7 != null)
            {
                button7.Click -= button7_Click; // Stock Transfer
                button7.Click += button7_Click;
            }

            // Logout button
            if (button8 != null)
            {
                button8.Click -= button8_Click;
                button8.Click += button8_Click;
            }

            // Make dashboard summary cards clickable
            if (cardTotalProducts != null)
                WireCardClick(cardTotalProducts, CardTotalProducts_Click);
            if (cardCategories != null)
                WireCardClick(cardCategories, CardCategories_Click);
            if (cardLowStock != null)
                WireCardClick(cardLowStock, CardLowStock_Click);
            if (cardTotalValue != null)
                WireCardClick(cardTotalValue, CardTotalValue_Click);
        }

        private void SwitchTo(Form frm)
        {
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormClosed += (s, args) =>
            {
                if (!this.IsDisposed && !this.Disposing)
                {
                    this.Show();
                }
            };

            this.Hide();
            frm.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            // Open the Products form and hide this dashboard
            SwitchTo(new ProductsForm());
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void btnStockLevels_Click(object sender, EventArgs e)
        {
            // Open the Stock Levels form and hide this dashboard
            SwitchTo(new Stock_Levels());
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            // Open the Stock-In form and hide this dashboard
            SwitchTo(new Stock_In());
        }

        private void btnStockOut_Click(object sender, EventArgs e)
        {
            // Stock-Out removed: inform the user instead of opening the form
            MessageBox.Show("Stock-Out feature has been removed in this build.", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // Already on the dashboard, no action needed
        }

        private void btnStockLevels_Click_1(object sender, EventArgs e)
        {
            btnStockLevels_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SwitchTo(new Adjustment());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SwitchTo(new Low_Stock_Alerts());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SwitchTo(new ExpiryBatch_Tracking());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SwitchTo(new Stock_Transfer());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Log out
            Logout.Execute(this);
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Logout.Execute(this);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void DashB_Load(object sender, EventArgs e) => LoadSummary();

        private void DashB_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadSummary();
            }
        }

        private void InitializeChart()
        {
            if (lowStockChartPanel == null) return;
            lowStockChartPanel.Paint += lowStockChartPanel_Paint;
            lowStockChartPanel.Resize += (s, e) => lowStockChartPanel.Invalidate();
        }

        private void LoadSummary()
        {
            try
            {
                using var conn = DatabaseService.CreateConnection();
                conn.Open();

                using (var existsCmd = new Microsoft.Data.SqlClient.SqlCommand(
                    "SELECT COUNT(1) FROM sys.tables WHERE name = 'Products'", conn))
                {
                    if ((int)existsCmd.ExecuteScalar() == 0)
                    {
                        UpdateSummary(0, 0, 0, 0m);
                        return;
                    }
                }

                using var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                    @"SELECT
                        COUNT(1),
                        ISNULL(SUM(CurrentStock), 0),
                        ISNULL(SUM(CASE WHEN CurrentStock <= MinStock THEN 1 ELSE 0 END), 0),
                        ISNULL(SUM(CAST(CurrentStock AS DECIMAL(18,2)) * Price), 0)
                      FROM dbo.Products", conn);
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var totalProducts = reader.GetInt32(0);
                    var totalStock = reader.GetInt32(1);
                    var lowStock = reader.GetInt32(2);
                    var totalValue = reader.GetDecimal(3);

                    UpdateSummary(totalProducts, totalStock, lowStock, totalValue);

                    // persist stock summary snapshot
                    try
                    {
                        SaveStockSummary(totalProducts, totalStock, lowStock, totalValue);
                    }
                    catch
                    {
                        // ignore persistence errors
                    }
                }
                reader.Close();

                // also load batch expiry summary (ProductBatches)
                try
                {
                    using var bcmd = new Microsoft.Data.SqlClient.SqlCommand(@"
                        SELECT
                            COUNT(1) AS TotalBatches,
                            ISNULL(SUM(CASE WHEN ExpiryDate IS NOT NULL AND ExpiryDate < CAST(GETDATE() AS DATE) THEN 1 ELSE 0 END), 0) AS ExpiredBatches,
                            ISNULL(SUM(CASE WHEN ExpiryDate IS NOT NULL AND ExpiryDate >= CAST(GETDATE() AS DATE) AND ExpiryDate <= DATEADD(day,30,CAST(GETDATE() AS DATE)) THEN 1 ELSE 0 END), 0) AS ExpiringSoon,
                            ISNULL(SUM(ISNULL(Qty,0) * ISNULL(UnitCost,0)), 0) AS TotalBatchValue
                        FROM dbo.ProductBatches", conn);

                    using var breader = bcmd.ExecuteReader();
                    if (breader.Read())
                    {
                        var totalBatches = breader.IsDBNull(0) ? 0 : breader.GetInt32(0);
                        var expired = breader.IsDBNull(1) ? 0 : breader.GetInt32(1);
                        var expiringSoon = breader.IsDBNull(2) ? 0 : breader.GetInt32(2);
                        var totalBatchValue = breader.IsDBNull(3) ? 0m : breader.GetDecimal(3);

                        // repurpose the existing summary cards to show batch metrics
                        try
                        {
                            lblTotalProductsValue.Text = totalBatches.ToString(); // Total Batch
                            lblCategoriesValue.Text = expiringSoon.ToString(); // Expiring Soon
                            lblLowStockValue.Text = expired.ToString(); // Expired Batch
                            lblTotalValueAmount.Text = "PHP " + totalBatchValue.ToString("N2"); // Total Stock Value
                        }
                        catch
                        {
                            // ignore UI update errors
                        }
                    }
                    breader.Close();
                }
                catch
                {
                    // ignore batch summary failures
                }

                LoadLowStockChartData(conn);
                LoadLowStockGridData(conn);
                // load recent transactions into panel textBox1 if present
                try
                {
                    using var rcmd = new Microsoft.Data.SqlClient.SqlCommand(@"IF OBJECT_ID('dbo.RecentTransactions') IS NOT NULL SELECT TOP(20) Type, Description, CreatedAt FROM dbo.RecentTransactions ORDER BY CreatedAt DESC", conn);
                    using var rreader = rcmd.ExecuteReader();
                    var sb = new System.Text.StringBuilder();
                    while (rreader.Read())
                    {
                        var type = rreader.IsDBNull(0) ? "" : rreader.GetString(0);
                        var desc = rreader.IsDBNull(1) ? "" : rreader.GetString(1);
                        var at = rreader.IsDBNull(2) ? DateTime.MinValue : rreader.GetDateTime(2);
                        sb.AppendLine($"[{at:yyyy-MM-dd HH:mm}] {type}: {desc}");
                    }
                    try { textBox1.Text = sb.ToString(); } catch { }
                    rreader.Close();
                }
                catch
                {
                    // ignore
                }
            }
            catch
            {
                // leave placeholder values if the database is unavailable
            }
        }

        private void LoadLowStockChartData(Microsoft.Data.SqlClient.SqlConnection conn)
        {
            if (lowStockChartPanel == null) return;
            var data = new List<KeyValuePair<string, int>>();
            try
            {
                using var chartCmd = new Microsoft.Data.SqlClient.SqlCommand(
                    @"SELECT ISNULL(NULLIF(Category, ''), 'Uncategorized') AS Category, COUNT(1) AS Cnt
                      FROM dbo.Products
                      WHERE CurrentStock <= MinStock
                      GROUP BY ISNULL(NULLIF(Category, ''), 'Uncategorized')
                      ORDER BY Cnt DESC", conn);
                using var chartReader = chartCmd.ExecuteReader();
                while (chartReader.Read())
                {
                    var category = chartReader.IsDBNull(0) ? "Uncategorized" : chartReader.GetString(0);
                    data.Add(new KeyValuePair<string, int>(category, chartReader.GetInt32(1)));
                }
            }
            catch
            {
                // keep previous chart data if the query fails
                return;
            }

            _lowStockByCategory = data;
            lowStockChartPanel.Invalidate();
        }

        private void LoadLowStockGridData(Microsoft.Data.SqlClient.SqlConnection conn)
        {
            if (dataGridView1 == null)
            {
                return;
            }

            dataGridView1.Rows.Clear();

            try
            {
                using var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                    @"SELECT ProductName, CurrentStock, MinStock
                      FROM dbo.Products
                      WHERE CurrentStock <= MinStock
                      ORDER BY ProductName", conn);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var productName = reader.IsDBNull(0) ? "Unknown Product" : reader.GetString(0);
                    var currentStock = reader.GetInt32(1);
                    var minStock = reader.GetInt32(2);
                    var status = currentStock <= minStock ? "Low Stock" : "Healthy";

                    dataGridView1.Rows.Add(productName, currentStock, minStock, status);
                }
            }
            catch
            {
                // ignore data grid load failures and leave grid empty
            }

            if (dataGridView1.Rows.Count == 0)
            {
                dataGridView1.Rows.Add("No low stock items", "-", "-", "Healthy");
            }
        }

        private void lowStockChartPanel_Paint(object sender, PaintEventArgs e)
        {
            if (lowStockChartPanel == null) return;
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(lowStockChartPanel.BackColor);

            if (_lowStockByCategory.Count == 0)
            {
                using var emptyBrush = new SolidBrush(Color.Gray);
                var size = g.MeasureString("No low stock items", lowStockChartPanel.Font);
                g.DrawString("No low stock items", lowStockChartPanel.Font, emptyBrush,
                    (lowStockChartPanel.Width - size.Width) / 2, (lowStockChartPanel.Height - size.Height) / 2);
                return;
            }

            int paddingLeft = 40, paddingBottom = 40, paddingTop = 20, paddingRight = 20;
            int chartWidth = lowStockChartPanel.Width - paddingLeft - paddingRight;
            int chartHeight = lowStockChartPanel.Height - paddingTop - paddingBottom;
            if (chartWidth <= 0 || chartHeight <= 0) return;

            int maxCount = 0;
            foreach (var kv in _lowStockByCategory) maxCount = Math.Max(maxCount, kv.Value);
            if (maxCount == 0) maxCount = 1;

            // axes
            using var axisPen = new Pen(Color.DarkGray);
            g.DrawLine(axisPen, paddingLeft, paddingTop, paddingLeft, paddingTop + chartHeight);
            g.DrawLine(axisPen, paddingLeft, paddingTop + chartHeight, paddingLeft + chartWidth, paddingTop + chartHeight);

            using var barBrush = new SolidBrush(Color.FromArgb(255, 128, 0));
            using var textBrush = new SolidBrush(Color.Black);
            using var font = new Font("Segoe UI", 8F);

            int count = _lowStockByCategory.Count;
            int slot = chartWidth / count;
            int barWidth = Math.Max(10, (int)(slot * 0.6));

            for (int i = 0; i < count; i++)
            {
                var (category, value) = _lowStockByCategory[i];
                int barHeight = (int)((value / (double)maxCount) * (chartHeight - 10));
                int x = paddingLeft + i * slot + (slot - barWidth) / 2;
                int y = paddingTop + chartHeight - barHeight;

                g.FillRectangle(barBrush, x, y, barWidth, barHeight);

                // value label above bar
                var valueText = value.ToString();
                var valueSize = g.MeasureString(valueText, font);
                g.DrawString(valueText, font, textBrush, x + (barWidth - valueSize.Width) / 2, y - valueSize.Height - 2);

                // category label below axis (truncated)
                var label = category.Length > 12 ? category.Substring(0, 12) + "…" : category;
                var labelSize = g.MeasureString(label, font);
                g.DrawString(label, font, textBrush,
                    Math.Max(paddingLeft, x + (barWidth - labelSize.Width) / 2), paddingTop + chartHeight + 5);
            }
        }

        private void UpdateSummary(int totalProducts, int totalStock, int lowStock, decimal totalValue)
        {
            lblTotalProductsValue.Text = totalProducts.ToString();
            lblCategoriesValue.Text = totalStock.ToString();
            lblLowStockValue.Text = lowStock.ToString();
            lblTotalValueAmount.Text = "PHP " + totalValue.ToString("N2");
        }

        private void WireCardClick(Control card, EventHandler handler)
        {
            card.Cursor = Cursors.Hand;
            card.Click -= handler;
            card.Click += handler;
            foreach (Control child in card.Controls)
            {
                child.Cursor = Cursors.Hand;
                child.Click -= handler;
                child.Click += handler;
            }
        }

        private void CardTotalProducts_Click(object sender, EventArgs e)
        {
            SwitchTo(new ProductsForm());
        }

        private void CardCategories_Click(object sender, EventArgs e)
        {
            SwitchTo(new Stock_Levels());
        }

        private void CardLowStock_Click(object sender, EventArgs e)
        {
            SwitchTo(new Low_Stock_Alerts());
        }

        private void CardTotalValue_Click(object sender, EventArgs e)
        {
            SwitchTo(new Inventory_Valuation());
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void btnStockOut_Click_1(object sender, EventArgs e)
        {
            SwitchTo(new Inventory_Valuation());
        }
    }
}
