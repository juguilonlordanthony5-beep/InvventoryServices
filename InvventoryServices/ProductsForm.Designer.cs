namespace InvventoryServices
{
    partial class ProductsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            leftPanel = new Panel();
            navPanel = new FlowLayoutPanel();
            btnDashboard = new Button();
            btnProducts = new Button();
            btnStockLevels = new Button();
            button7 = new Button();
            button2 = new Button();
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            button8 = new Button();
            topPanel = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            lblTitle = new Label();
            btnAddProduct = new Button();
            contentPanel = new Panel();
            searchPanel = new Panel();
            txtSearch = new TextBox();
            cmbCategory = new ComboBox();
            cmbStatus = new ComboBox();
            btnSearch = new Button();
            cardsPanel = new FlowLayoutPanel();
            cardTotalProducts = new Panel();
            lblTotalProductsValue = new Label();
            lblTotalProducts = new Label();
            cardCategories = new Panel();
            lblCategoriesValue = new Label();
            lblCategories = new Label();
            cardLowStock = new Panel();
            lblLowStockValue = new Label();
            lblLowStock = new Label();
            cardTotalValue = new Panel();
            lblTotalValueAmount = new Label();
            lblTotalValue = new Label();
            gridPanel = new Panel();
            productsGrid = new DataGridView();
            Column1 = new DataGridViewCheckBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            Category = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewButtonColumn();
            Column8 = new DataGridViewButtonColumn();
            actionsPanel = new Panel();
            label1 = new Label();
            btnExport = new Button();
            btnViewAll = new Button();
            btnStockOut = new Button();
            leftPanel.SuspendLayout();
            navPanel.SuspendLayout();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            contentPanel.SuspendLayout();
            searchPanel.SuspendLayout();
            cardsPanel.SuspendLayout();
            cardTotalProducts.SuspendLayout();
            cardCategories.SuspendLayout();
            cardLowStock.SuspendLayout();
            cardTotalValue.SuspendLayout();
            gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productsGrid).BeginInit();
            actionsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.FromArgb(22, 56, 92);
            leftPanel.BackgroundImage = Properties.Resources._63e90850_52c4_492e_b68d_b47d67cf844b__1_;
            leftPanel.Controls.Add(navPanel);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Margin = new Padding(4);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(250, 1090);
            leftPanel.TabIndex = 0;
            leftPanel.Paint += leftPanel_Paint;
            // 
            // navPanel
            // 
            navPanel.Controls.Add(btnDashboard);
            navPanel.Controls.Add(btnProducts);
            navPanel.Controls.Add(btnStockLevels);
            navPanel.Controls.Add(button7);
            navPanel.Controls.Add(button2);
            navPanel.Controls.Add(button1);
            navPanel.Controls.Add(button3);
            navPanel.Controls.Add(button4);
            navPanel.Controls.Add(button8);
            navPanel.FlowDirection = FlowDirection.TopDown;
            navPanel.Location = new Point(12, 25);
            navPanel.Margin = new Padding(4);
            navPanel.Name = "navPanel";
            navPanel.Size = new Size(209, 862);
            navPanel.TabIndex = 0;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.Transparent;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(4, 4);
            btnDashboard.Margin = new Padding(4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(200, 50);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.FromArgb(22, 56, 92);
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProducts.ForeColor = Color.White;
            btnProducts.Location = new Point(4, 62);
            btnProducts.Margin = new Padding(4);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(200, 50);
            btnProducts.TabIndex = 1;
            btnProducts.Text = "Products";
            btnProducts.UseVisualStyleBackColor = false;
            // 
            // btnStockLevels
            // 
            btnStockLevels.BackColor = Color.Transparent;
            btnStockLevels.FlatStyle = FlatStyle.Flat;
            btnStockLevels.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStockLevels.ForeColor = Color.White;
            btnStockLevels.Location = new Point(4, 120);
            btnStockLevels.Margin = new Padding(4);
            btnStockLevels.Name = "btnStockLevels";
            btnStockLevels.Size = new Size(200, 50);
            btnStockLevels.TabIndex = 2;
            btnStockLevels.Text = "Stock Levels";
            btnStockLevels.UseVisualStyleBackColor = false;
            btnStockLevels.Click += btnStockLevels_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.Transparent;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.White;
            button7.Location = new Point(4, 178);
            button7.Margin = new Padding(4);
            button7.Name = "button7";
            button7.Size = new Size(200, 50);
            button7.TabIndex = 27;
            button7.Text = "Stock Transfer";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(4, 236);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(200, 50);
            button2.TabIndex = 23;
            button2.Text = "Low-Stock Alerts";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(4, 294);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(200, 50);
            button1.TabIndex = 22;
            button1.Text = "Adjustment";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(4, 352);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(200, 50);
            button3.TabIndex = 21;
            button3.Text = "Expiry & Batch Tracking";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(4, 410);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(200, 71);
            button4.TabIndex = 24;
            button4.Text = "Inventory Valuation";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.Red;
            button8.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.White;
            button8.Location = new Point(3, 488);
            button8.Name = "button8";
            button8.Size = new Size(200, 50);
            button8.TabIndex = 28;
            button8.Text = "Log out";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.White;
            topPanel.Controls.Add(label2);
            topPanel.Controls.Add(pictureBox1);
            topPanel.Controls.Add(lblTitle);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(250, 0);
            topPanel.Margin = new Padding(4);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1695, 92);
            topPanel.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(126, 58);
            label2.Name = "label2";
            label2.Size = new Size(445, 25);
            label2.TabIndex = 2;
            label2.Text = "Manage product information and inventory details";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.box__2_;
            pictureBox1.Location = new Point(25, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(94, 59);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(126, 20);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(132, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Products";
            lblTitle.Click += lblTitle_Click;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddProduct.BackColor = Color.Blue;
            btnAddProduct.ForeColor = Color.White;
            btnAddProduct.Location = new Point(1401, 10);
            btnAddProduct.Margin = new Padding(4);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(216, 53);
            btnAddProduct.TabIndex = 1;
            btnAddProduct.Text = "+ Add Product";
            btnAddProduct.UseVisualStyleBackColor = false;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.Gainsboro;
            contentPanel.Controls.Add(searchPanel);
            contentPanel.Controls.Add(cardsPanel);
            contentPanel.Controls.Add(gridPanel);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(250, 92);
            contentPanel.Margin = new Padding(4);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1695, 998);
            contentPanel.TabIndex = 2;
            contentPanel.Paint += contentPanel_Paint;
            // 
            // searchPanel
            // 
            searchPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchPanel.BackColor = Color.White;
            searchPanel.Controls.Add(txtSearch);
            searchPanel.Controls.Add(cmbCategory);
            searchPanel.Controls.Add(cmbStatus);
            searchPanel.Controls.Add(btnSearch);
            searchPanel.Location = new Point(25, 12);
            searchPanel.Margin = new Padding(4);
            searchPanel.Name = "searchPanel";
            searchPanel.Size = new Size(1645, 62);
            searchPanel.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(0, 12);
            txtSearch.Margin = new Padding(4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search product name, category, or SKU...";
            txtSearch.Size = new Size(624, 31);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "All Categories" });
            cmbCategory.Location = new Point(638, 12);
            cmbCategory.Margin = new Padding(4);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(174, 33);
            cmbCategory.TabIndex = 1;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "All Status" });
            cmbStatus.Location = new Point(825, 12);
            cmbStatus.Margin = new Padding(4);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(174, 33);
            cmbStatus.TabIndex = 2;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Blue;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(1012, 10);
            btnSearch.Margin = new Padding(4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(125, 38);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // cardsPanel
            // 
            cardsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cardsPanel.Controls.Add(cardTotalProducts);
            cardsPanel.Controls.Add(cardCategories);
            cardsPanel.Controls.Add(cardLowStock);
            cardsPanel.Controls.Add(cardTotalValue);
            cardsPanel.Location = new Point(244, 100);
            cardsPanel.Margin = new Padding(4);
            cardsPanel.Name = "cardsPanel";
            cardsPanel.Size = new Size(1193, 123);
            cardsPanel.TabIndex = 1;
            cardsPanel.WrapContents = false;
            cardsPanel.Paint += cardsPanel_Paint;
            // 
            // cardTotalProducts
            // 
            cardTotalProducts.BackColor = Color.Blue;
            cardTotalProducts.BorderStyle = BorderStyle.FixedSingle;
            cardTotalProducts.Controls.Add(lblTotalProductsValue);
            cardTotalProducts.Controls.Add(lblTotalProducts);
            cardTotalProducts.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cardTotalProducts.ForeColor = SystemColors.ButtonHighlight;
            cardTotalProducts.Location = new Point(10, 10);
            cardTotalProducts.Margin = new Padding(10);
            cardTotalProducts.Name = "cardTotalProducts";
            cardTotalProducts.Size = new Size(206, 100);
            cardTotalProducts.TabIndex = 0;
            // 
            // lblTotalProductsValue
            // 
            lblTotalProductsValue.AutoSize = true;
            lblTotalProductsValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalProductsValue.Location = new Point(10, 35);
            lblTotalProductsValue.Name = "lblTotalProductsValue";
            lblTotalProductsValue.Size = new Size(83, 48);
            lblTotalProductsValue.TabIndex = 0;
            lblTotalProductsValue.Text = "128";
            // 
            // lblTotalProducts
            // 
            lblTotalProducts.AutoSize = true;
            lblTotalProducts.Location = new Point(10, 10);
            lblTotalProducts.Name = "lblTotalProducts";
            lblTotalProducts.Size = new Size(148, 28);
            lblTotalProducts.TabIndex = 1;
            lblTotalProducts.Text = "Total Products";
            lblTotalProducts.Click += lblTotalProducts_Click;
            // 
            // cardCategories
            // 
            cardCategories.BackColor = Color.FromArgb(0, 192, 0);
            cardCategories.BorderStyle = BorderStyle.FixedSingle;
            cardCategories.Controls.Add(lblCategoriesValue);
            cardCategories.Controls.Add(lblCategories);
            cardCategories.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cardCategories.ForeColor = SystemColors.ButtonHighlight;
            cardCategories.Location = new Point(236, 10);
            cardCategories.Margin = new Padding(10);
            cardCategories.Name = "cardCategories";
            cardCategories.Size = new Size(220, 100);
            cardCategories.TabIndex = 0;
            // 
            // lblCategoriesValue
            // 
            lblCategoriesValue.AutoSize = true;
            lblCategoriesValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCategoriesValue.Location = new Point(10, 35);
            lblCategoriesValue.Name = "lblCategoriesValue";
            lblCategoriesValue.Size = new Size(62, 48);
            lblCategoriesValue.TabIndex = 0;
            lblCategoriesValue.Text = "12";
            // 
            // lblCategories
            // 
            lblCategories.AutoSize = true;
            lblCategories.Location = new Point(10, 10);
            lblCategories.Name = "lblCategories";
            lblCategories.Size = new Size(117, 28);
            lblCategories.TabIndex = 1;
            lblCategories.Text = "Total Stock";
            // 
            // cardLowStock
            // 
            cardLowStock.BackColor = Color.FromArgb(255, 128, 0);
            cardLowStock.BorderStyle = BorderStyle.FixedSingle;
            cardLowStock.Controls.Add(lblLowStockValue);
            cardLowStock.Controls.Add(lblLowStock);
            cardLowStock.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cardLowStock.ForeColor = SystemColors.ButtonHighlight;
            cardLowStock.Location = new Point(476, 10);
            cardLowStock.Margin = new Padding(10);
            cardLowStock.Name = "cardLowStock";
            cardLowStock.Size = new Size(220, 100);
            cardLowStock.TabIndex = 0;
            // 
            // lblLowStockValue
            // 
            lblLowStockValue.AutoSize = true;
            lblLowStockValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblLowStockValue.Location = new Point(10, 35);
            lblLowStockValue.Name = "lblLowStockValue";
            lblLowStockValue.Size = new Size(41, 48);
            lblLowStockValue.TabIndex = 0;
            lblLowStockValue.Text = "8";
            // 
            // lblLowStock
            // 
            lblLowStock.AutoSize = true;
            lblLowStock.Location = new Point(10, 10);
            lblLowStock.Name = "lblLowStock";
            lblLowStock.Size = new Size(166, 28);
            lblLowStock.TabIndex = 1;
            lblLowStock.Text = "Low Stock Items";
            // 
            // cardTotalValue
            // 
            cardTotalValue.BackColor = Color.FromArgb(128, 128, 255);
            cardTotalValue.BorderStyle = BorderStyle.FixedSingle;
            cardTotalValue.Controls.Add(lblTotalValueAmount);
            cardTotalValue.Controls.Add(lblTotalValue);
            cardTotalValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cardTotalValue.ForeColor = SystemColors.ButtonHighlight;
            cardTotalValue.Location = new Point(716, 10);
            cardTotalValue.Margin = new Padding(10);
            cardTotalValue.Name = "cardTotalValue";
            cardTotalValue.Size = new Size(220, 100);
            cardTotalValue.TabIndex = 0;
            // 
            // lblTotalValueAmount
            // 
            lblTotalValueAmount.AutoSize = true;
            lblTotalValueAmount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalValueAmount.Location = new Point(10, 35);
            lblTotalValueAmount.Name = "lblTotalValueAmount";
            lblTotalValueAmount.Size = new Size(224, 38);
            lblTotalValueAmount.TabIndex = 0;
            lblTotalValueAmount.Text = "PHP 268,750.00";
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Location = new Point(10, 10);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(116, 28);
            lblTotalValue.TabIndex = 1;
            lblTotalValue.Text = "Total Value";
            // 
            // gridPanel
            // 
            gridPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridPanel.Controls.Add(productsGrid);
            gridPanel.Controls.Add(actionsPanel);
            gridPanel.Location = new Point(25, 250);
            gridPanel.Margin = new Padding(4);
            gridPanel.Name = "gridPanel";
            gridPanel.Size = new Size(1645, 711);
            gridPanel.TabIndex = 2;
            // 
            // productsGrid
            // 
            productsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            productsGrid.BackgroundColor = Color.White;
            productsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productsGrid.Columns.AddRange(new DataGridViewColumn[] { Column1, ProductName, Category, Column2, Column3, Column4, Column5, Column6, Column7, Column8 });
            productsGrid.Location = new Point(0, 74);
            productsGrid.Margin = new Padding(4);
            productsGrid.Name = "productsGrid";
            productsGrid.RowHeadersWidth = 62;
            productsGrid.RowTemplate.Height = 29;
            productsGrid.Size = new Size(1637, 633);
            productsGrid.TabIndex = 0;
            productsGrid.CellContentClick += productsGrid_CellContentClick;
            productsGrid.CellDoubleClick += productsGrid_CellDoubleClick;
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
            Column7.Text = "Remove";
            Column7.UseColumnTextForButtonValue = true;
            Column7.Width = 150;
            // 
            // Column8
            // 
            Column8.HeaderText = "Alerts";
            Column8.MinimumWidth = 8;
            Column8.Name = "Column8";
            Column8.Text = "Alerts";
            Column8.UseColumnTextForButtonValue = true;
            Column8.Width = 150;
            // 
            // actionsPanel
            // 
            actionsPanel.BackColor = Color.White;
            actionsPanel.Controls.Add(label1);
            actionsPanel.Controls.Add(btnExport);
            actionsPanel.Controls.Add(btnAddProduct);
            actionsPanel.Controls.Add(btnViewAll);
            actionsPanel.Dock = DockStyle.Top;
            actionsPanel.Location = new Point(0, 0);
            actionsPanel.Margin = new Padding(4);
            actionsPanel.Name = "actionsPanel";
            actionsPanel.Size = new Size(1645, 74);
            actionsPanel.TabIndex = 1;
            actionsPanel.Paint += actionsPanel_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(18, 13);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(185, 38);
            label1.TabIndex = 2;
            label1.Text = "Products List";
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.Blue;
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(926, 10);
            btnExport.Margin = new Padding(4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(100, 53);
            btnExport.TabIndex = 0;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnViewAll
            // 
            btnViewAll.BackColor = Color.Blue;
            btnViewAll.ForeColor = Color.White;
            btnViewAll.Location = new Point(1051, 10);
            btnViewAll.Margin = new Padding(4);
            btnViewAll.Name = "btnViewAll";
            btnViewAll.Size = new Size(100, 53);
            btnViewAll.TabIndex = 1;
            btnViewAll.Text = "View All";
            btnViewAll.UseVisualStyleBackColor = false;
            btnViewAll.Click += btnViewAll_Click;
            // 
            // btnStockOut
            // 
            btnStockOut.BackColor = Color.Transparent;
            btnStockOut.FlatStyle = FlatStyle.Flat;
            btnStockOut.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStockOut.ForeColor = Color.White;
            btnStockOut.Location = new Point(4, 584);
            btnStockOut.Margin = new Padding(4);
            btnStockOut.Name = "btnStockOut";
            btnStockOut.Size = new Size(200, 50);
            btnStockOut.TabIndex = 29;
            btnStockOut.Text = "Stock Out";
            btnStockOut.UseVisualStyleBackColor = false;
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1945, 1090);
            Controls.Add(contentPanel);
            Controls.Add(topPanel);
            Controls.Add(leftPanel);
            Margin = new Padding(4);
            Name = "ProductsForm";
            Text = "Products";
            leftPanel.ResumeLayout(false);
            navPanel.ResumeLayout(false);
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            contentPanel.ResumeLayout(false);
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            cardsPanel.ResumeLayout(false);
            cardTotalProducts.ResumeLayout(false);
            cardTotalProducts.PerformLayout();
            cardCategories.ResumeLayout(false);
            cardCategories.PerformLayout();
            cardLowStock.ResumeLayout(false);
            cardLowStock.PerformLayout();
            cardTotalValue.ResumeLayout(false);
            cardTotalValue.PerformLayout();
            gridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)productsGrid).EndInit();
            actionsPanel.ResumeLayout(false);
            actionsPanel.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.DataGridView productsGrid;
        private DataGridViewButtonColumn Column8;
        private System.Windows.Forms.Panel actionsPanel;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnViewAll;
        private FlowLayoutPanel navPanel;
        private Button btnDashboard;
        private Button btnProducts;
        private Button btnStockLevels;
        private Button button2;
        private Button button7;
        private Button button4;
        private Button button3;
        private Button button1;
        private Button button8;
        private DataGridViewCheckBoxColumn Column1;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewButtonColumn Column7;
        private FlowLayoutPanel cardsPanel;
        private Panel cardTotalProducts;
        private Label lblTotalProductsValue;
        private Label lblTotalProducts;
        private Panel cardCategories;
        private Label lblCategoriesValue;
        private Label lblCategories;
        private Panel cardLowStock;
        private Label lblLowStockValue;
        private Label lblLowStock;
        private Panel cardTotalValue;
        private Label lblTotalValueAmount;
        private Label lblTotalValue;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Button btnStockOut;
    }
}
