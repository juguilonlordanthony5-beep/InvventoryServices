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
    public partial class Stock_In : Form
    {
        public Stock_In()
        {
            InitializeComponent();
            InitializeHandlers();
        }

        private void InitializeHandlers()
        {
            // Wire up all navigation button handlers
            btnDashboard.Click -= btnDashboard_Click;
            btnDashboard.Click += btnDashboard_Click;
            btnProducts.Click -= btnProducts_Click;
            btnProducts.Click += btnProducts_Click;
            btnStockLevels.Click -= btnStockLevels_Click;
            btnStockLevels.Click += btnStockLevels_Click;
            btnStockIn.Click -= btnStockIn_Click;
            btnStockIn.Click += btnStockIn_Click;
            btnStockOut.Click -= btnStockOut_Click;
            btnStockOut.Click += btnStockOut_Click;

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

        private void btnProducts_Click(object sender, EventArgs e)
        {
            // Navigate to Products
            var productsForm = new ProductsForm();
            productsForm.StartPosition = FormStartPosition.CenterScreen;
            productsForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            productsForm.Show();
        }

        private void btnStockLevels_Click(object sender, EventArgs e)
        {
            // Navigate to Products (Stock Levels button goes to Products)
            var productsForm = new ProductsForm();
            productsForm.StartPosition = FormStartPosition.CenterScreen;
            productsForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            productsForm.Show();
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            // Navigate to Products (Stock-In button goes to Products)
            // Since we're already on Stock-In page, show info
            MessageBox.Show("You are already on the Products page.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnStockOut_Click(object sender, EventArgs e)
        {
            // Stock-Out removed: inform the user
            MessageBox.Show("Stock-Out feature has been removed in this build.", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            // Log out
            Logout.Execute(this);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
