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
            @"Data Source=ACER-SWIFT3\SQLEXPRESS;Initial Catalog=InventoryDb;Integrated Security=True;TrustServerCertificate=True;";

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