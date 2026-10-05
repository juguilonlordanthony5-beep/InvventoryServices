using System;
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
    public partial class ExpiryBatch_Tracking : Form
    {
        private int _currentBatchId = 0;

        public ExpiryBatch_Tracking()
        {
            InitializeComponent();
            InitializeHandlers();

            // load product options and batch list
            try
            {
                LoadProductOptions();
                LoadBatchTracking();
            }


            catch
            {
                // ignore load errors
            }



            // wire local button and grid handlers
            try
            {
                btnAddBatch.Click -= BtnAddBatch_Click;
                btnAddBatch.Click += BtnAddBatch_Click;
                btnSaveBatches.Click -= BtnSaveBatches_Click;
                btnSaveBatches.Click += BtnSaveBatches_Click;

                btnSearch.Click -= BtnSearch_Click;
                btnSearch.Click += BtnSearch_Click;

                button5.Click -= Button5_Click;
                button5.Click += Button5_Click;
                // wire the 'View Expired' button to toggle expired filter
                try
                {
                    button6.Click -= Button6_Click;
                    button6.Click += Button6_Click;
                }
                catch { }

                dataGridView1.CellContentClick -= DataGridView1_CellContentClick;
                dataGridView1.CellContentClick += DataGridView1_CellContentClick;
                dataGridView1.SelectionChanged -= DataGridView1_SelectionChanged;
                dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
                dataGridView1.CellValueChanged -= DataGridView1_CellValueChanged;
                dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
                dataGridView1.CurrentCellDirtyStateChanged -= DataGridView1_CurrentCellDirtyStateChanged;
                dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;

                // wire detail panel fields
                textBox6.TextChanged -= TextBoxExpiry_TextChanged;
                textBox6.TextChanged += TextBoxExpiry_TextChanged;
                textBox2.TextChanged -= TextBoxQtyOrUnit_TextChanged;
                textBox2.TextChanged += TextBoxQtyOrUnit_TextChanged;
                textBox3.TextChanged -= TextBoxQtyOrUnit_TextChanged;
                textBox3.TextChanged += TextBoxQtyOrUnit_TextChanged;

                // panel save button (button10)
                button10.Click -= Button10_Click;
                button10.Click += Button10_Click;
            }
            catch
            {
                // ignore wiring errors
            }
        }
        private void LoadProductOptions()
        {
            try
            {
                var col = ProductName as DataGridViewComboBoxColumn;
                if (col == null) return;

                var list = new List<(int Id, string Name)>();
                using var conn = DatabaseService.CreateConnection();
                conn.Open();
                using var cmd = new Microsoft.Data.SqlClient.SqlCommand("SELECT Id, ProductName FROM dbo.Products ORDER BY ProductName", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    var name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    list.Add((id, name));
                }

                // persist batch summary for auditing/history
                try
                {
                    // reuse the same computation used for UI
                    using var summaryCmd = new Microsoft.Data.SqlClient.SqlCommand(@"
                        SELECT
                            COUNT(1) AS TotalBatches,
                            ISNULL(SUM(CASE WHEN ExpiryDate IS NOT NULL AND ExpiryDate < CAST(GETDATE() AS DATE) THEN 1 ELSE 0 END), 0) AS ExpiredBatches,
                            ISNULL(SUM(CASE WHEN ExpiryDate IS NOT NULL AND ExpiryDate >= CAST(GETDATE() AS DATE) AND ExpiryDate <= DATEADD(day,30,CAST(GETDATE() AS DATE)) THEN 1 ELSE 0 END), 0) AS ExpiringSoon,
                            ISNULL(SUM(ISNULL(Qty,0) * ISNULL(UnitCost,0)), 0) AS TotalBatchValue
                        FROM dbo.ProductBatches", conn);

                    using var sreader = summaryCmd.ExecuteReader();
                    if (sreader.Read())
                    {
                        var total = sreader.IsDBNull(0) ? 0 : sreader.GetInt32(0);
                        var expired = sreader.IsDBNull(1) ? 0 : sreader.GetInt32(1);
                        var expiring = sreader.IsDBNull(2) ? 0 : sreader.GetInt32(2);
                        var value = sreader.IsDBNull(3) ? 0m : sreader.GetDecimal(3);
                        // save summary row
                        SaveBatchSummary(total, expiring, expired, value);
                    }
                    sreader.Close();
                }
                catch
                {
                    // ignore summary persistence errors
                }

                var ds = list.Select(x => new { Id = x.Id, Name = x.Name }).ToList();
                col.DataSource = ds;
                col.ValueMember = "Id";
                col.DisplayMember = "Name";

                // also populate the panel product combobox so Batch Details can use it
                try
                {
                    comboBox1.DataSource = null;
                    comboBox1.DataSource = ds;
                    comboBox1.ValueMember = "Id";
                    comboBox1.DisplayMember = "Name";
                }
                catch
                {
                    // ignore
                }
            }
            catch
            {
                // ignore
            }
        }

        private void LoadBatchTracking()
        {
            try
            {
                dataGridView1.Rows.Clear();
                using var conn = DatabaseService.CreateConnection();
                conn.Open();

                // ensure ProductBatches exists
                using (var checkCmd = new Microsoft.Data.SqlClient.SqlCommand("SELECT COUNT(1) FROM sys.tables WHERE name = 'ProductBatches'", conn))
                {
                    var exists = Convert.ToInt32(checkCmd.ExecuteScalar() ?? 0) > 0;
                    if (!exists) return;
                }

                var sql = @"SELECT pb.Id, pb.ProductId, p.ProductName, pb.BatchNo, pb.Qty, pb.UnitCost, pb.ExpiryDate
                             FROM dbo.ProductBatches pb
                             LEFT JOIN dbo.Products p ON p.Id = pb.ProductId
                             ORDER BY p.ProductName, pb.ExpiryDate";

                using var cmd = new Microsoft.Data.SqlClient.SqlCommand(sql, conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    var productId = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                    var pname = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    var batchNo = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    var qty = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                    var unitCost = reader.IsDBNull(5) ? 0m : reader.GetDecimal(5);
                    DateTime? expiry = null;
                    if (!reader.IsDBNull(6)) expiry = reader.GetDateTime(6);

                    string expiryText = expiry?.ToString("yyyy-MM-dd") ?? string.Empty;
                    string daysLeftText;
                    string status;
                    if (!expiry.HasValue)
                    {
                        daysLeftText = "-";
                        status = "No Expiry";
                    }
                    else
                    {
                        var days = (expiry.Value.Date - DateTime.Today).Days;
                        daysLeftText = days.ToString();
                        if (days < 0) status = "Expired";
                        else if (days <= 30) status = "Expiring Soon";
                        else status = "OK";
                    }

                    // for ProductName (combo) column we set the productId as the cell value
                    var rowIndex = dataGridView1.Rows.Add(false, productId, batchNo, qty, unitCost.ToString("0.00"), expiryText, daysLeftText, status, "Remove");
                    dataGridView1.Rows[rowIndex].Tag = id;
                }

                // compute batch summary metrics and update cards
                try
                {
                    using var summaryCmd = new Microsoft.Data.SqlClient.SqlCommand(@"
                        SELECT
                            COUNT(1) AS TotalBatches,
                            ISNULL(SUM(CASE WHEN ExpiryDate IS NOT NULL AND ExpiryDate < CAST(GETDATE() AS DATE) THEN 1 ELSE 0 END), 0) AS ExpiredBatches,
                            ISNULL(SUM(CASE WHEN ExpiryDate IS NOT NULL AND ExpiryDate >= CAST(GETDATE() AS DATE) AND ExpiryDate <= DATEADD(day,30,CAST(GETDATE() AS DATE)) THEN 1 ELSE 0 END), 0) AS ExpiringSoon,
                            ISNULL(SUM(ISNULL(Qty,0) * ISNULL(UnitCost,0)), 0) AS TotalBatchValue
                        FROM dbo.ProductBatches", conn);

                    using var sreader = summaryCmd.ExecuteReader();
                    if (sreader.Read())
                    {
                        var total = sreader.IsDBNull(0) ? 0 : sreader.GetInt32(0);
                        var expired = sreader.IsDBNull(1) ? 0 : sreader.GetInt32(1);
                        var expiring = sreader.IsDBNull(2) ? 0 : sreader.GetInt32(2);
                        var value = sreader.IsDBNull(3) ? 0m : sreader.GetDecimal(3);

                        try
                        {
                            // update numeric labels (legacy)
                            lblTotalProductsValue.Text = total.ToString();
                            lblCategoriesValue.Text = expiring.ToString();
                            lblLowStockValue.Text = expired.ToString();
                            lblTotalValueAmount.Text = "PHP " + value.ToString("N2");

                            // update textboxes (preferred) and ensure visible on top
                            try
                            {
                                if (txtTotalBatches != null)
                                {
                                    txtTotalBatches.Text = total.ToString();
                                    txtTotalBatches.BringToFront();
                                }
                            }
                            catch { }
                            try
                            {
                                if (txtExpiringSoon != null)
                                {
                                    txtExpiringSoon.Text = expiring.ToString();
                                    txtExpiringSoon.BringToFront();
                                }
                            }
                            catch { }
                            try
                            {
                                if (txtExpiredBatches != null)
                                {
                                    txtExpiredBatches.Text = expired.ToString();
                                    txtExpiredBatches.BringToFront();
                                }
                            }
                            catch { }
                            try
                            {
                                if (txtTotalStockValue != null)
                                {
                                    txtTotalStockValue.Text = "PHP " + value.ToString("N2");
                                    txtTotalStockValue.BringToFront();
                                }
                            }
                            catch { }

                            // hide legacy labels so textboxes are visible and not overlapped
                            try { lblTotalProductsValue.Visible = false; } catch { }
                            try { lblCategoriesValue.Visible = false; } catch { }
                            try { lblLowStockValue.Visible = false; } catch { }
                            try { lblTotalValueAmount.Visible = false; } catch { }
                        }
                        catch
                        {
                            // ignore UI update errors
                        }
                    }
                    sreader.Close();
                }
                catch
                {
                    // ignore summary failures
                }
            }
            catch
            {
                // ignore load errors
            }
        }

        private void BtnAddBatch_Click(object sender, EventArgs e)
        {
            try
            {
                // add an editable empty row at top
                // For ProductName (ComboBox) column we set default to first product Id if available
                int defaultProductId = 0;
                try
                {
                    // try to get first product id from database
                    using var conn = DatabaseService.CreateConnection();
                    conn.Open();
                    using var cmd = new Microsoft.Data.SqlClient.SqlCommand("SELECT TOP(1) Id FROM dbo.Products ORDER BY ProductName", conn);
                    var r = cmd.ExecuteScalar();
                    if (r != null) int.TryParse(r.ToString(), out defaultProductId);
                }
                catch
                {
                    // ignore
                }

                var idx = dataGridView1.Rows.Add(false, defaultProductId == 0 ? (object)DBNull.Value : defaultProductId, "", 0, "0.00", "", "-", "", "Save");
                dataGridView1.FirstDisplayedScrollingRowIndex = Math.Max(0, idx - 2);
                dataGridView1.CurrentCell = dataGridView1.Rows[idx].Cells[1];
                dataGridView1.BeginEdit(true);
            }
            catch
            {
                // ignore
            }
        }

        private void BtnSaveBatches_Click(object sender, EventArgs e)
        {
            try
            {
                int saved = 0, skipped = 0;
                using var conn = DatabaseService.CreateConnection();
                conn.Open();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;
                    // ProductName column is a ComboBox and stores ProductId as its value
                    var prodVal = row.Cells["ProductName"].Value;
                    int productId = 0;
                    if (prodVal != null && int.TryParse(prodVal.ToString(), out var pid)) productId = pid;
                    if (productId <= 0)
                    {
                        skipped++;
                        continue;
                    }

                    var batchNo = row.Cells["BatchNo"].Value?.ToString() ?? string.Empty;
                    int.TryParse(row.Cells["Qty"].Value?.ToString(), out var qty);
                    decimal.TryParse(row.Cells["UnitCost"].Value?.ToString(), out var unitCost);
                    DateTime? expiry = null;
                    var expiryText = row.Cells["ExpiryDate"].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(expiryText) && DateTime.TryParse(expiryText, out var d)) expiry = d;
                    // update or insert
                    if (row.Tag is int id && id > 0)
                    {
                        using var ucmd = new Microsoft.Data.SqlClient.SqlCommand(@"UPDATE dbo.ProductBatches
                                                                                   SET ProductId = @productId, BatchNo = @batchNo, Qty = @qty, UnitCost = @unitCost, ExpiryDate = @expiry
                                                                                   WHERE Id = @id", conn);
                        ucmd.Parameters.AddWithValue("@productId", productId);
                        ucmd.Parameters.AddWithValue("@batchNo", (object)batchNo ?? DBNull.Value);
                        ucmd.Parameters.AddWithValue("@qty", qty);
                        ucmd.Parameters.AddWithValue("@unitCost", unitCost);
                        ucmd.Parameters.AddWithValue("@expiry", expiry.HasValue ? (object)expiry.Value : DBNull.Value);
                        ucmd.Parameters.AddWithValue("@id", id);
                        ucmd.ExecuteNonQuery();
                        saved++;
                    }
                    else
                    {
                        using var icmd = new Microsoft.Data.SqlClient.SqlCommand(@"INSERT INTO dbo.ProductBatches (ProductId, BatchNo, Qty, UnitCost, ExpiryDate)
                                                                                   VALUES (@productId, @batchNo, @qty, @unitCost, @expiry);
                                                                                   SELECT SCOPE_IDENTITY();", conn);
                        icmd.Parameters.AddWithValue("@productId", productId);
                        icmd.Parameters.AddWithValue("@batchNo", (object)batchNo ?? DBNull.Value);
                        icmd.Parameters.AddWithValue("@qty", qty);
                        icmd.Parameters.AddWithValue("@unitCost", unitCost);
                        icmd.Parameters.AddWithValue("@expiry", expiry.HasValue ? (object)expiry.Value : DBNull.Value);
                        var nid = icmd.ExecuteScalar();
                        if (nid != null && int.TryParse(nid.ToString(), out var nidv))
                            row.Tag = nidv;
                        saved++;
                    }
                }
                try { DatabaseService.SaveRecentTransaction("Batch", $"Saved batches: {saved}"); } catch { }
                LoadBatchTracking();
                MessageBox.Show($"Saved: {saved}. Skipped: {skipped} (missing product name or product not found).", "Save Batches", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save batches:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var term = txtSearch.Text?.Trim() ?? string.Empty;
                if (string.IsNullOrEmpty(term))
                {
                    // show all
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                        row.Visible = true;
                    return;
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;
                    var pname = row.Cells["ProductName"].FormattedValue?.ToString() ?? string.Empty;
                    var batch = row.Cells["BatchNo"].Value?.ToString() ?? string.Empty;
                    var unit = row.Cells["UnitCost"].Value?.ToString() ?? string.Empty;
                    var matches = pname.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                  batch.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                  unit.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0;
                    row.Visible = matches;
                }
            }
            catch
            {
                // ignore
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            // Export visible batches to CSV
            try
            {
                using var dialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv",
                    FileName = "Batches.csv",
                    Title = "Export Batches"
                };

                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                var sb = new System.Text.StringBuilder();
                sb.AppendLine("Product Name,Batch No,Qty,Unit Cost,Expiry Date,Days Left,Status");

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow || !row.Visible) continue;
                    var pname = row.Cells["ProductName"].FormattedValue?.ToString() ?? string.Empty;
                    var batch = row.Cells["BatchNo"].Value?.ToString() ?? string.Empty;
                    var qty = row.Cells["Qty"].Value?.ToString() ?? "0";
                    var unit = row.Cells["UnitCost"].Value?.ToString() ?? "0.00";
                    var expiry = row.Cells["ExpiryDate"].Value?.ToString() ?? string.Empty;
                    var days = row.Cells["DaysLeft"].Value?.ToString() ?? string.Empty;
                    var status = row.Cells["Status"].Value?.ToString() ?? string.Empty;
                    sb.AppendLine(string.Join(",", EscapeCsv(pname), EscapeCsv(batch), EscapeCsv(qty), EscapeCsv(unit), EscapeCsv(expiry), EscapeCsv(days), EscapeCsv(status)));
                }

                System.IO.File.WriteAllText(dialog.FileName, sb.ToString());
                MessageBox.Show("Batches exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to export batches:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string EscapeCsv(string value)
        {
            if (value.Contains(',') || value.Contains('"') || value.Contains('\n'))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }
            return value;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var col = dataGridView1.Columns[e.ColumnIndex];
            if (col == null) return;
            if (col.Name == "Action")
            {
                var row = dataGridView1.Rows[e.RowIndex];
                var val = row.Cells[e.ColumnIndex].Value?.ToString() ?? string.Empty;
                if (string.Equals(val, "View", StringComparison.OrdinalIgnoreCase))
                {
                    // show details
                    var details = $"Product: {row.Cells["ProductName"].FormattedValue}\nBatch: {row.Cells["BatchNo"].Value}\nQty: {row.Cells["Qty"].Value}\nUnitCost: {row.Cells["UnitCost"].Value}\nExpiry: {row.Cells["ExpiryDate"].Value}\nStatus: {row.Cells["Status"].Value}";
                    MessageBox.Show(details, "Batch Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (string.Equals(val, "Remove", StringComparison.OrdinalIgnoreCase) || string.Equals(val, "Delete", StringComparison.OrdinalIgnoreCase))
                {
                    // confirm and delete
                    if (MessageBox.Show("Delete this batch?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (row.Tag is int id && id > 0)
                        {
                            try
                            {
                                using var conn = DatabaseService.CreateConnection();
                                conn.Open();
                                using var cmd = new Microsoft.Data.SqlClient.SqlCommand("DELETE FROM dbo.ProductBatches WHERE Id = @id", conn);
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                                try { DatabaseService.SaveRecentTransaction("Batch", $"Deleted batch id={id}"); } catch { }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Failed to delete batch:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.IsCurrentCellDirty)
                {
                    // commit edit so CellValueChanged fires immediately (useful for ComboBox and checkbox cells)
                    dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch
            {
                // ignore
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                var col = dataGridView1.Columns[e.ColumnIndex];
                if (col == null) return;

                var row = dataGridView1.Rows[e.RowIndex];

                // handle expiry date changes to compute days left and status
                if (string.Equals(col.Name, "ExpiryDate", StringComparison.OrdinalIgnoreCase))
                {
                    var expiryText = row.Cells["ExpiryDate"].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(expiryText) && DateTime.TryParse(expiryText, out var exp))
                    {
                        var days = (exp.Date - DateTime.Today).Days;
                        row.Cells["DaysLeft"].Value = days.ToString();
                        if (days < 0) row.Cells["Status"].Value = "Expired";
                        else if (days <= 30) row.Cells["Status"].Value = "Expiring Soon";
                        else row.Cells["Status"].Value = "OK";
                    }
                    else
                    {
                        row.Cells["DaysLeft"].Value = "-";
                        row.Cells["Status"].Value = "No Expiry";
                    }

                    // if this row is selected, update the detail panel as well
                    if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0] == row)
                    {
                        textBox6.Text = row.Cells["ExpiryDate"].Value?.ToString() ?? string.Empty;
                        textBox7.Text = row.Cells["DaysLeft"].Value?.ToString() ?? string.Empty;
                        textBox8.Text = row.Cells["Status"].Value?.ToString() ?? string.Empty;
                    }
                }
                else if (string.Equals(col.Name, "Qty", StringComparison.OrdinalIgnoreCase) || string.Equals(col.Name, "UnitCost", StringComparison.OrdinalIgnoreCase))
                {
                    // update formatted unit cost and keep Days/Status unchanged
                    // if selected row, update total in panel
                    if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0] == row)
                    {
                        if (int.TryParse(row.Cells["Qty"].Value?.ToString(), out var q) && decimal.TryParse(row.Cells["UnitCost"].Value?.ToString(), out var uc))
                        {
                            textBox2.Text = q.ToString();
                            textBox3.Text = uc.ToString("0.00");
                            textBox4.Text = (q * uc).ToString("0.00");
                        }
                    }
                }
            }
            catch
            {
                // ignore
            }
        }

        private void TextBoxExpiry_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var txt = textBox6.Text?.Trim();
                if (!string.IsNullOrWhiteSpace(txt) && DateTime.TryParse(txt, out var exp))
                {
                    var days = (exp.Date - DateTime.Today).Days;
                    textBox7.Text = days.ToString();
                    if (days < 0) textBox8.Text = "Expired";
                    else if (days <= 30) textBox8.Text = "Expiring Soon";
                    else textBox8.Text = "OK";
                }
                else
                {
                    textBox7.Text = "-";
                    textBox8.Text = "No Expiry";
                }
            }
            catch
            {
                // ignore
            }
        }

        private void TextBoxQtyOrUnit_TextChanged(object? sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(textBox2.Text, out var q) && decimal.TryParse(textBox3.Text, out var uc))
                {
                    textBox4.Text = (q * uc).ToString("0.00");
                }
                else textBox4.Text = string.Empty;
            }
            catch
            {
                // ignore
            }
        }

        private void DataGridView1_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    _currentBatchId = 0;
                    return;
                }

                var row = dataGridView1.SelectedRows[0];
                if (row == null) return;

                _currentBatchId = row.Tag is int idVal ? idVal : 0;

                // ProductId is stored in the ProductName cell value
                var prodVal = row.Cells["ProductName"].Value;
                if (prodVal != null && int.TryParse(prodVal.ToString(), out var pid))
                {
                    try { comboBox1.SelectedValue = pid; } catch { }
                }
                else
                {
                    comboBox1.SelectedIndex = -1;
                }

                textBox1.Text = row.Cells["BatchNo"].Value?.ToString() ?? string.Empty; // Batch Number
                textBox2.Text = row.Cells["Qty"].Value?.ToString() ?? string.Empty; // Qty
                textBox3.Text = row.Cells["UnitCost"].Value?.ToString() ?? string.Empty; // Unit Cost

                // total cost = qty * unitcost
                if (int.TryParse(textBox2.Text, out var q) && decimal.TryParse(textBox3.Text, out var uc))
                    textBox4.Text = (q * uc).ToString("0.00");
                else textBox4.Text = string.Empty;

                textBox5.Text = string.Empty; // Received date not stored in grid
                textBox6.Text = row.Cells["ExpiryDate"].Value?.ToString() ?? string.Empty; // Expiry
                textBox7.Text = row.Cells["DaysLeft"].Value?.ToString() ?? string.Empty; // Days Left
                textBox8.Text = row.Cells["Status"].Value?.ToString() ?? string.Empty; // Status
            }
            catch
            {
                // ignore
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            try
            {
                // validate
                if (comboBox1.SelectedValue == null || !int.TryParse(comboBox1.SelectedValue.ToString(), out var productId) || productId <= 0)
                {
                    MessageBox.Show("Please select a product.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var batchNo = textBox1.Text.Trim();
                if (string.IsNullOrWhiteSpace(batchNo))
                {
                    MessageBox.Show("Please enter Batch Number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int.TryParse(textBox2.Text, out var qty);
                decimal.TryParse(textBox3.Text, out var unitCost);
                DateTime? expiry = null;
                if (DateTime.TryParse(textBox6.Text, out var d)) expiry = d;

                using var conn = DatabaseService.CreateConnection();
                conn.Open();
                if (_currentBatchId > 0)
                {
                    using var cmd = new Microsoft.Data.SqlClient.SqlCommand(@"UPDATE dbo.ProductBatches SET ProductId=@productId, BatchNo=@batchNo, Qty=@qty, UnitCost=@unitCost, ExpiryDate=@expiry WHERE Id=@id", conn);
                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.Parameters.AddWithValue("@batchNo", batchNo);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@unitCost", unitCost);
                    cmd.Parameters.AddWithValue("@expiry", expiry.HasValue ? (object)expiry.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", _currentBatchId);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    using var cmd = new Microsoft.Data.SqlClient.SqlCommand(@"INSERT INTO dbo.ProductBatches (ProductId,BatchNo,Qty,UnitCost,ExpiryDate) VALUES(@productId,@batchNo,@qty,@unitCost,@expiry); SELECT SCOPE_IDENTITY();", conn);
                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.Parameters.AddWithValue("@batchNo", batchNo);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@unitCost", unitCost);
                    cmd.Parameters.AddWithValue("@expiry", expiry.HasValue ? (object)expiry.Value : DBNull.Value);
                    var nid = cmd.ExecuteScalar();
                    if (nid != null && int.TryParse(nid.ToString(), out var nidv)) _currentBatchId = nidv;
                }

                try { DatabaseService.SaveRecentTransaction("Batch", $"Saved batch id={_currentBatchId} for product {productId}"); } catch { }

                LoadBatchTracking();
                MessageBox.Show("Batch saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save batch:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            case "button6":
                                btn.Click -= Button6_Click;
                                btn.Click += Button6_Click;
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
            // Stock-Out removed: inform the user
            MessageBox.Show("Stock-Out feature has been removed in this build.", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            // Toggle between showing expired batches and showing all
            try
            {
                if (sender is Button btn && btn.Text == "View Expired")
                {
                    // filter to expired only
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;
                        var status = row.Cells["Status"].Value?.ToString() ?? string.Empty;
                        row.Visible = string.Equals(status, "Expired", StringComparison.OrdinalIgnoreCase);
                    }
                    btn.Text = "View All";
                }
                else
                {
                    // show all
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;
                        row.Visible = true;
                    }
                    if (sender is Button b) b.Text = "View Expired";
                }
            }
            catch
            {
                // ignore
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // product list moved into the main batch grid as columns; any product-related interactions
        // should be implemented against dataGridView1 rows instead.

        private void SaveBatchSummary(int totalBatches, int expiringSoon, int expiredBatches, decimal totalValue)
        {
            try
            {
                using var conn = DatabaseService.CreateConnection();
                conn.Open();

                // ensure summary table exists
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(@"
                    IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'BatchSummaries')
                    BEGIN
                        CREATE TABLE dbo.BatchSummaries(
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            SummaryDate DATE NOT NULL,
                            TotalBatches INT NULL,
                            ExpiringSoon INT NULL,
                            ExpiredBatches INT NULL,
                            TotalValue DECIMAL(18,2) NULL,
                            CreatedAt DATETIME NOT NULL DEFAULT(GETDATE())
                        );
                    END", conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using var icmd = new Microsoft.Data.SqlClient.SqlCommand(@"INSERT INTO dbo.BatchSummaries (SummaryDate, TotalBatches, ExpiringSoon, ExpiredBatches, TotalValue) VALUES (CAST(GETDATE() AS DATE), @total, @expiring, @expired, @value);", conn);
                icmd.Parameters.AddWithValue("@total", totalBatches);
                icmd.Parameters.AddWithValue("@expiring", expiringSoon);
                icmd.Parameters.AddWithValue("@expired", expiredBatches);
                icmd.Parameters.AddWithValue("@value", totalValue);
                icmd.ExecuteNonQuery();
            }
            catch
            {
                // ignore persistence errors
            }
        }
    }
}
