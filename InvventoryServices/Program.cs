namespace InvventoryServices
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // Debug-only database connectivity test. Does not run in Release builds.
#if DEBUG
            try
            {
                var (ok, err) = DatabaseService.TestConnectionAsync().GetAwaiter().GetResult();
                if (!ok)
                {
                    MessageBox.Show($"Database connection test failed:\n{err}", "DB Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database test error: {ex.Message}", "DB Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
#endif
            Application.Run(new Form1());
        }
    }
}