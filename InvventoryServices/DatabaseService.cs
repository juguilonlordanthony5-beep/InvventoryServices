using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace InvventoryServices
{
    internal static class DatabaseService
    {
        private const string EnvConnectionName = "INVENTORYDB_CONNECTION";

        // Local development connection string.
        private const string DefaultConnectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=InvventoryServicesDB;Integrated Security=True;TrustServerCertificate=True;";

        /// <summary>
        /// Gets the database connection string from the environment variable.
        /// Falls back to the local development connection string if not configured.
        /// </summary>
        public static string GetConnectionString()
        {
            var env = Environment.GetEnvironmentVariable(EnvConnectionName);

            if (!string.IsNullOrWhiteSpace(env))
            {
                return env;
            }

            return DefaultConnectionString;
        }

        /// <summary>
        /// Creates a new SQL connection.
        /// Caller must dispose the returned connection.
        /// </summary>
        public static SqlConnection CreateConnection()
        {
            var connectionString = GetConnectionString();
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// Persist a simple recent transaction record.
        /// </summary>
        public static void SaveRecentTransaction(string type, string description)
        {
            try
            {
                using var conn = CreateConnection();
                conn.Open();

                using (var cmd = new SqlCommand(@"
                    IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'RecentTransactions')
                    BEGIN
                        CREATE TABLE dbo.RecentTransactions(
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            Type NVARCHAR(100) NULL,
                            Description NVARCHAR(1000) NULL,
                            CreatedAt DATETIME NOT NULL DEFAULT(GETDATE())
                        );
                    END", conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using var icmd = new SqlCommand(@"INSERT INTO dbo.RecentTransactions (Type, Description) VALUES (@type, @desc);", conn);
                icmd.Parameters.AddWithValue("@type", (object?)type ?? DBNull.Value);
                icmd.Parameters.AddWithValue("@desc", (object?)description ?? DBNull.Value);
                icmd.ExecuteNonQuery();
            }
            catch
            {
                // ignore
            }
        }

        /// <summary>
        /// Compute current product totals and persist a stock summary snapshot to dbo.StockSummaries.
        /// This is safe to call after product/batch updates to keep historical snapshots.
        /// </summary>
        public static void SaveStockSummarySnapshot()
        {
            try
            {
                using var conn = CreateConnection();
                conn.Open();

                // compute totals from products
                using var cmd = new SqlCommand(@"SELECT
                        COUNT(1) AS TotalProducts,
                        ISNULL(SUM(CurrentStock),0) AS TotalStock,
                        ISNULL(SUM(CASE WHEN CurrentStock <= MinStock THEN 1 ELSE 0 END),0) AS LowStockCount,
                        ISNULL(SUM(CAST(CurrentStock AS DECIMAL(18,2)) * Price),0) AS TotalValue
                    FROM dbo.Products", conn);

                using var reader = cmd.ExecuteReader();
                if (!reader.Read()) return;

                var totalProducts = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                var totalStock = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                var lowStock = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                var totalValue = reader.IsDBNull(3) ? 0m : reader.GetDecimal(3);
                reader.Close();

                // ensure StockSummaries table exists
                using (var c2 = new SqlCommand(@"
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
                    c2.ExecuteNonQuery();
                }

                using var icmd = new SqlCommand(@"INSERT INTO dbo.StockSummaries (SummaryDate, TotalProducts, TotalStock, LowStockCount, TotalValue) VALUES (CAST(GETDATE() AS DATE), @totalProducts, @totalStock, @lowStock, @totalValue);", conn);
                icmd.Parameters.AddWithValue("@totalProducts", totalProducts);
                icmd.Parameters.AddWithValue("@totalStock", totalStock);
                icmd.Parameters.AddWithValue("@lowStock", lowStock);
                icmd.Parameters.AddWithValue("@totalValue", totalValue);
                icmd.ExecuteNonQuery();
            }
            catch
            {
                // ignore persistence errors to avoid affecting UI flows
            }
        }

        /// <summary>
        /// Tests database connectivity.
        /// Returns (true, null) on success or (false, errorMessage) on failure.
        /// </summary>
        public static async Task<(bool Success, string? ErrorMessage)> TestConnectionAsync(
            int timeoutSeconds = 5)
        {
            try
            {
                using var conn = CreateConnection();

                var builder = new SqlConnectionStringBuilder(conn.ConnectionString)
                {
                    ConnectTimeout = timeoutSeconds
                };

                conn.ConnectionString = builder.ConnectionString;

                await conn.OpenAsync();
                await conn.CloseAsync();

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
