namespace InvventoryServices
{
    partial class Stock_In
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
            btnDashboard = new Button();
            btnProducts = new Button();
            btnStockLevels = new Button();
            btnStockIn = new Button();
            btnStockOut = new Button();
            panel1 = new Panel();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox5 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            panel3 = new Panel();
            productsGrid = new DataGridView();
            Column1 = new DataGridViewCheckBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            Category = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
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
            button8 = new Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productsGrid).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(22, 56, 92);
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(24, 56);
            btnDashboard.Margin = new Padding(4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(200, 50);
            btnDashboard.TabIndex = 8;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.FromArgb(22, 56, 92);
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.ForeColor = Color.White;
            btnProducts.Location = new Point(24, 114);
            btnProducts.Margin = new Padding(4);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(200, 50);
            btnProducts.TabIndex = 9;
            btnProducts.Text = "Products";
            btnProducts.UseVisualStyleBackColor = false;
            // 
            // btnStockLevels
            // 
            btnStockLevels.BackColor = Color.FromArgb(22, 56, 92);
            btnStockLevels.FlatStyle = FlatStyle.Flat;
            btnStockLevels.ForeColor = Color.White;
            btnStockLevels.Location = new Point(24, 172);
            btnStockLevels.Margin = new Padding(4);
            btnStockLevels.Name = "btnStockLevels";
            btnStockLevels.Size = new Size(200, 50);
            btnStockLevels.TabIndex = 10;
            btnStockLevels.Text = "Stock Levels";
            btnStockLevels.UseVisualStyleBackColor = false;
            // 
            // btnStockIn
            // 
            btnStockIn.BackColor = Color.FromArgb(22, 56, 92);
            btnStockIn.FlatStyle = FlatStyle.Flat;
            btnStockIn.ForeColor = Color.White;
            btnStockIn.Location = new Point(24, 230);
            btnStockIn.Margin = new Padding(4);
            btnStockIn.Name = "btnStockIn";
            btnStockIn.Size = new Size(200, 50);
            btnStockIn.TabIndex = 11;
            btnStockIn.Text = "Stock-In";
            btnStockIn.UseVisualStyleBackColor = false;
            // 
            // btnStockOut
            // 
            btnStockOut.BackColor = Color.FromArgb(22, 56, 92);
            btnStockOut.FlatStyle = FlatStyle.Flat;
            btnStockOut.ForeColor = Color.White;
            btnStockOut.Location = new Point(24, 288);
            btnStockOut.Margin = new Padding(4);
            btnStockOut.Name = "btnStockOut";
            btnStockOut.Size = new Size(200, 50);
            btnStockOut.TabIndex = 12;
            btnStockOut.Text = "Stock-Out";
            btnStockOut.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(lblTitle);
            panel1.Location = new Point(231, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(1735, 1148);
            panel1.TabIndex = 13;
            panel1.Paint += panel1_Paint;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(128, 128, 255);
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(1056, 175);
            label6.Name = "label6";
            label6.Size = new Size(214, 28);
            label6.TabIndex = 25;
            label6.Text = "Total Inventory Value";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1083, 175);
            label5.Name = "label5";
            label5.Size = new Size(0, 25);
            label5.TabIndex = 32;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(255, 128, 0);
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(795, 177);
            label3.Name = "label3";
            label3.Size = new Size(168, 25);
            label3.TabIndex = 31;
            label3.Text = "Low Stock Items";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Green;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(551, 177);
            label2.Name = "label2";
            label2.Size = new Size(117, 28);
            label2.TabIndex = 30;
            label2.Text = "Total Stock";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.HotTrack;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(288, 177);
            label1.Name = "label1";
            label1.Size = new Size(148, 28);
            label1.TabIndex = 24;
            label1.Text = "Total Products";
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.FromArgb(128, 128, 255);
            textBox5.Location = new Point(1026, 160);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(258, 151);
            textBox5.TabIndex = 29;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(255, 128, 0);
            textBox3.Location = new Point(762, 160);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(258, 151);
            textBox3.TabIndex = 28;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Green;
            textBox2.Location = new Point(499, 160);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(258, 151);
            textBox2.TabIndex = 27;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.HotTrack;
            textBox1.Location = new Point(235, 162);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(258, 151);
            textBox1.TabIndex = 26;
            // 
            // panel3
            // 
            panel3.Controls.Add(productsGrid);
            panel3.Location = new Point(11, 336);
            panel3.Name = "panel3";
            panel3.Size = new Size(1452, 554);
            panel3.TabIndex = 5;
            // 
            // productsGrid
            // 
            productsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            productsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productsGrid.Columns.AddRange(new DataGridViewColumn[] { Column1, ProductName, Category, Column2, Column3, Column4, Column5, Column6, Column7 });
            productsGrid.Location = new Point(0, 69);
            productsGrid.Margin = new Padding(4);
            productsGrid.Name = "productsGrid";
            productsGrid.RowHeadersWidth = 62;
            productsGrid.RowTemplate.Height = 29;
            productsGrid.Size = new Size(1414, 481);
            productsGrid.TabIndex = 1;
            // 
            // Column1
            // 
            Column1.HeaderText = "";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            Column1.Width = 150;
            // 
            // ProductName
            // 
            ProductName.HeaderText = "Product Name";
            ProductName.MinimumWidth = 8;
            ProductName.Name = "ProductName";
            ProductName.Resizable = DataGridViewTriState.True;
            ProductName.SortMode = DataGridViewColumnSortMode.NotSortable;
            ProductName.Width = 150;
            // 
            // Category
            // 
            Category.HeaderText = "Category";
            Category.MinimumWidth = 8;
            Category.Name = "Category";
            Category.Resizable = DataGridViewTriState.True;
            Category.SortMode = DataGridViewColumnSortMode.NotSortable;
            Category.Width = 150;
            // 
            // Column2
            // 
            Column2.HeaderText = "SKU";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            Column2.Resizable = DataGridViewTriState.True;
            Column2.SortMode = DataGridViewColumnSortMode.NotSortable;
            Column2.Width = 150;
            // 
            // Column3
            // 
            Column3.HeaderText = "Current Stock";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            Column3.Width = 150;
            // 
            // Column4
            // 
            Column4.HeaderText = "Min Stock";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            Column4.Width = 150;
            // 
            // Column5
            // 
            Column5.HeaderText = "Price";
            Column5.MinimumWidth = 8;
            Column5.Name = "Column5";
            Column5.Width = 150;
            // 
            // Column6
            // 
            Column6.HeaderText = "Status";
            Column6.MinimumWidth = 8;
            Column6.Name = "Column6";
            Column6.Width = 150;
            // 
            // Column7
            // 
            Column7.HeaderText = "Action";
            Column7.MinimumWidth = 8;
            Column7.Name = "Column7";
            Column7.Width = 150;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSearch);
            panel2.Controls.Add(cmbStatus);
            panel2.Controls.Add(cmbCategory);
            panel2.Controls.Add(txtSearch);
            panel2.Location = new Point(102, 53);
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
            lblTitle.Text = "Stock-In";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(22, 56, 92);
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(24, 461);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(200, 50);
            button2.TabIndex = 23;
            button2.Text = "Low-Stock Alerts";
            button2.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(22, 56, 92);
            button7.FlatStyle = FlatStyle.Flat;
            button7.ForeColor = Color.White;
            button7.Location = new Point(24, 345);
            button7.Margin = new Padding(4);
            button7.Name = "button7";
            button7.Size = new Size(200, 50);
            button7.TabIndex = 27;
            button7.Text = "Stock Transfer";
            button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(22, 56, 92);
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = Color.White;
            button6.Location = new Point(24, 693);
            button6.Margin = new Padding(4);
            button6.Name = "button6";
            button6.Size = new Size(200, 50);
            button6.TabIndex = 26;
            button6.Text = "Setings";
            button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(22, 56, 92);
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = Color.White;
            button5.Location = new Point(24, 635);
            button5.Margin = new Padding(4);
            button5.Name = "button5";
            button5.Size = new Size(200, 50);
            button5.TabIndex = 25;
            button5.Text = "Reports";
            button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(22, 56, 92);
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.White;
            button4.Location = new Point(24, 577);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(200, 50);
            button4.TabIndex = 24;
            button4.Text = "Inventory Valuation";
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(22, 56, 92);
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.White;
            button3.Location = new Point(24, 519);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(200, 50);
            button3.TabIndex = 21;
            button3.Text = "Expiry & Batch Tracking";
            button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(22, 56, 92);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(24, 403);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(200, 50);
            button1.TabIndex = 22;
            button1.Text = "Adjustment";
            button1.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            button8.BackColor = Color.Red;
            button8.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.White;
            button8.Location = new Point(25, 750);
            button8.Name = "button8";
            button8.Size = new Size(200, 50);
            button8.TabIndex = 87;
            button8.Text = "Log out";
            button8.UseVisualStyleBackColor = false;
            // 
            // Stock_In
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 56, 92);
            BackgroundImage = Properties.Resources._63e90850_52c4_492e_b68d_b47d67cf844b__1_;
            ClientSize = new Size(1978, 1241);
            Controls.Add(button8);
            Controls.Add(button2);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(btnStockOut);
            Controls.Add(btnStockIn);
            Controls.Add(btnStockLevels);
            Controls.Add(btnProducts);
            Controls.Add(btnDashboard);
            Name = "Stock_In";
            Text = "Stock_In";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)productsGrid).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDashboard;
        private Button btnProducts;
        private Button btnStockLevels;
        private Button btnStockIn;
        private Button btnStockOut;
        private Panel panel1;
        private Panel panel3;
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
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox5;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private DataGridView productsGrid;
        private DataGridViewCheckBoxColumn Column1;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private Button button8;
    }
}