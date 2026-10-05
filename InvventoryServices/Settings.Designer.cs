namespace InvventoryServices
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel3 = new Panel();
            cardsPanel = new FlowLayoutPanel();
            panel2 = new Panel();
            btnSearch = new Button();
            cmbStatus = new ComboBox();
            cmbCategory = new ComboBox();
            txtSearch = new TextBox();
            lblTitle = new Label();
            button2 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button1 = new Button();
            btnStockOut = new Button();
            btnStockIn = new Button();
            btnStockLevels = new Button();
            btnProducts = new Button();
            btnDashboard = new Button();
            button8 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(cardsPanel);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(lblTitle);
            panel1.Location = new Point(229, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(1365, 861);
            panel1.TabIndex = 95;
            // 
            // panel3
            // 
            panel3.Location = new Point(10, 330);
            panel3.Name = "panel3";
            panel3.Size = new Size(1353, 505);
            panel3.TabIndex = 5;
            // 
            // cardsPanel
            // 
            cardsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cardsPanel.Location = new Point(11, 157);
            cardsPanel.Margin = new Padding(4);
            cardsPanel.Name = "cardsPanel";
            cardsPanel.Size = new Size(10704, 150);
            cardsPanel.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSearch);
            panel2.Controls.Add(cmbStatus);
            panel2.Controls.Add(cmbCategory);
            panel2.Controls.Add(txtSearch);
            panel2.Location = new Point(11, 65);
            panel2.Name = "panel2";
            panel2.Size = new Size(1350, 85);
            panel2.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1063, 26);
            btnSearch.Margin = new Padding(4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 38);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "All Status" });
            cmbStatus.Location = new Point(866, 26);
            cmbStatus.Margin = new Padding(4);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(174, 33);
            cmbStatus.TabIndex = 4;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "All Categories" });
            cmbCategory.Location = new Point(668, 26);
            cmbCategory.Margin = new Padding(4);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(174, 33);
            cmbCategory.TabIndex = 4;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(7, 26);
            txtSearch.Margin = new Padding(4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search product name, category, or SKU...";
            txtSearch.Size = new Size(624, 31);
            txtSearch.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(18, 12);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(124, 38);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Settings";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(22, 56, 92);
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(22, 440);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(200, 50);
            button2.TabIndex = 90;
            button2.Text = "Low-Stock Alerts";
            button2.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(22, 56, 92);
            button7.FlatStyle = FlatStyle.Flat;
            button7.ForeColor = Color.White;
            button7.Location = new Point(22, 324);
            button7.Margin = new Padding(4);
            button7.Name = "button7";
            button7.Size = new Size(200, 50);
            button7.TabIndex = 94;
            button7.Text = "Stock Transfer";
            button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(22, 56, 92);
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = Color.White;
            button6.Location = new Point(22, 672);
            button6.Margin = new Padding(4);
            button6.Name = "button6";
            button6.Size = new Size(200, 50);
            button6.TabIndex = 93;
            button6.Text = "Setings";
            button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(22, 56, 92);
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = Color.White;
            button5.Location = new Point(22, 614);
            button5.Margin = new Padding(4);
            button5.Name = "button5";
            button5.Size = new Size(200, 50);
            button5.TabIndex = 92;
            button5.Text = "Reports";
            button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(22, 56, 92);
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.White;
            button4.Location = new Point(22, 556);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(200, 50);
            button4.TabIndex = 91;
            button4.Text = "Inventory Valuation";
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(22, 56, 92);
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.White;
            button3.Location = new Point(22, 498);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(200, 50);
            button3.TabIndex = 88;
            button3.Text = "Expiry & Batch Tracking";
            button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(22, 56, 92);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(22, 382);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(200, 50);
            button1.TabIndex = 89;
            button1.Text = "Adjustment";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnStockOut
            // 
            btnStockOut.BackColor = Color.FromArgb(22, 56, 92);
            btnStockOut.FlatStyle = FlatStyle.Flat;
            btnStockOut.ForeColor = Color.White;
            btnStockOut.Location = new Point(22, 265);
            btnStockOut.Margin = new Padding(4);
            btnStockOut.Name = "btnStockOut";
            btnStockOut.Size = new Size(200, 50);
            btnStockOut.TabIndex = 87;
            btnStockOut.Text = "Stock-Out";
            btnStockOut.UseVisualStyleBackColor = false;
            // 
            // btnStockIn
            // 
            btnStockIn.BackColor = Color.FromArgb(22, 56, 92);
            btnStockIn.FlatStyle = FlatStyle.Flat;
            btnStockIn.ForeColor = Color.White;
            btnStockIn.Location = new Point(22, 207);
            btnStockIn.Margin = new Padding(4);
            btnStockIn.Name = "btnStockIn";
            btnStockIn.Size = new Size(200, 50);
            btnStockIn.TabIndex = 86;
            btnStockIn.Text = "Stock-In";
            btnStockIn.UseVisualStyleBackColor = false;
            // 
            // btnStockLevels
            // 
            btnStockLevels.BackColor = Color.FromArgb(22, 56, 92);
            btnStockLevels.FlatStyle = FlatStyle.Flat;
            btnStockLevels.ForeColor = Color.White;
            btnStockLevels.Location = new Point(22, 149);
            btnStockLevels.Margin = new Padding(4);
            btnStockLevels.Name = "btnStockLevels";
            btnStockLevels.Size = new Size(200, 50);
            btnStockLevels.TabIndex = 85;
            btnStockLevels.Text = "Stock Levels";
            btnStockLevels.UseVisualStyleBackColor = false;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.FromArgb(22, 56, 92);
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.ForeColor = Color.White;
            btnProducts.Location = new Point(22, 92);
            btnProducts.Margin = new Padding(4);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(200, 50);
            btnProducts.TabIndex = 84;
            btnProducts.Text = "Products";
            btnProducts.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(22, 56, 92);
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(22, 34);
            btnDashboard.Margin = new Padding(4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(200, 50);
            btnDashboard.TabIndex = 83;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            button8.BackColor = Color.Red;
            button8.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.White;
            button8.Location = new Point(23, 811);
            button8.Name = "button8";
            button8.Size = new Size(200, 50);
            button8.TabIndex = 84;
            button8.Text = "Log out";
            button8.UseVisualStyleBackColor = false;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 56, 92);
            BackgroundImage = Properties.Resources._63e90850_52c4_492e_b68d_b47d67cf844b__1_;
            ClientSize = new Size(1653, 950);
            Controls.Add(button8);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(btnStockOut);
            Controls.Add(btnStockIn);
            Controls.Add(btnStockLevels);
            Controls.Add(btnProducts);
            Controls.Add(btnDashboard);
            Name = "Settings";
            Text = "Settings";
            Load += Settings_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private FlowLayoutPanel cardsPanel;
        private Panel panel2;
        private Button btnSearch;
        private ComboBox cmbStatus;
        private ComboBox cmbCategory;
        private TextBox txtSearch;
        private Label lblTitle;
        private Button button2;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button1;
        private Button btnStockOut;
        private Button btnStockIn;
        private Button btnStockLevels;
        private Button btnProducts;
        private Button btnDashboard;
        private Button button8;
    }
}