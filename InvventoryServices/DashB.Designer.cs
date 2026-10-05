namespace InvventoryServices
{
    partial class DashB
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
            btnStockLevels = new Button();
            btnStockIn = new Button();
            btnDashboard = new Button();
            btnProducts = new Button();
            lowStockChartPanel = new Panel();
            panel1 = new Panel();
            panel4 = new Panel();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            lblTitle = new Label();
            label8 = new Label();
            panel3 = new Panel();
            textBox1 = new TextBox();
            button10 = new Button();
            label1 = new Label();
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
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            ProductName = new DataGridViewTextBoxColumn();
            CurrentStock = new DataGridViewTextBoxColumn();
            MinStock = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            button9 = new Button();
            label7 = new Label();
            button2 = new Button();
            button7 = new Button();
            button3 = new Button();
            button1 = new Button();
            button8 = new Button();
            button4 = new Button();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            cardsPanel.SuspendLayout();
            cardTotalProducts.SuspendLayout();
            cardCategories.SuspendLayout();
            cardLowStock.SuspendLayout();
            cardTotalValue.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnStockLevels
            // 
            btnStockLevels.BackColor = Color.FromArgb(22, 56, 92);
            btnStockLevels.FlatStyle = FlatStyle.Flat;
            btnStockLevels.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStockLevels.ForeColor = Color.White;
            btnStockLevels.Location = new Point(22, 149);
            btnStockLevels.Margin = new Padding(4);
            btnStockLevels.Name = "btnStockLevels";
            btnStockLevels.Size = new Size(200, 50);
            btnStockLevels.TabIndex = 3;
            btnStockLevels.Text = "Stock Levels";
            btnStockLevels.UseVisualStyleBackColor = false;
            btnStockLevels.Click += btnStockLevels_Click_1;
            // 
            // btnStockIn
            // 
            btnStockIn.BackColor = Color.FromArgb(22, 56, 92);
            btnStockIn.FlatStyle = FlatStyle.Flat;
            btnStockIn.ForeColor = Color.White;
            btnStockIn.Location = new Point(22, 448);
            btnStockIn.Name = "btnStockIn";
            btnStockIn.Size = new Size(200, 50);
            btnStockIn.TabIndex = 15;
            btnStockIn.Text = "Stock-In";
            btnStockIn.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(22, 56, 92);
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(22, 34);
            btnDashboard.Margin = new Padding(4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(200, 50);
            btnDashboard.TabIndex = 6;
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
            btnProducts.Location = new Point(22, 92);
            btnProducts.Margin = new Padding(4);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(200, 50);
            btnProducts.TabIndex = 7;
            btnProducts.Text = "Products";
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += btnProducts_Click;
            // 
            // lowStockChartPanel
            // 
            lowStockChartPanel.BackColor = Color.White;
            lowStockChartPanel.Location = new Point(687, 129);
            lowStockChartPanel.Name = "lowStockChartPanel";
            lowStockChartPanel.Size = new Size(632, 123);
            lowStockChartPanel.TabIndex = 17;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(cardsPanel);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(229, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1431, 1013);
            panel1.TabIndex = 8;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(pictureBox2);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(lblTitle);
            panel4.Controls.Add(label8);
            panel4.Location = new Point(0, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(1428, 105);
            panel4.TabIndex = 16;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.box__2_;
            pictureBox2.Location = new Point(8, 16);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(94, 59);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(1228, 22);
            label2.Name = "label2";
            label2.Size = new Size(68, 25);
            label2.TabIndex = 14;
            label2.Text = "Admin";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(101, 9);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(159, 38);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Dashboard";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(101, 47);
            label8.Name = "label8";
            label8.Size = new Size(389, 28);
            label8.TabIndex = 13;
            label8.Text = "Overview of your inventory management";
            label8.Click += label8_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(button10);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(687, 290);
            panel3.Name = "panel3";
            panel3.Size = new Size(632, 510);
            panel3.TabIndex = 15;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(16, 76);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(601, 421);
            textBox1.TabIndex = 4;
            // 
            // button10
            // 
            button10.BackColor = Color.Blue;
            button10.ForeColor = Color.White;
            button10.Location = new Point(491, 16);
            button10.Name = "button10";
            button10.Size = new Size(112, 44);
            button10.TabIndex = 3;
            button10.Text = "View";
            button10.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(96, 28);
            label1.Name = "label1";
            label1.Size = new Size(222, 24);
            label1.TabIndex = 2;
            label1.Text = "Recent Transaction";
            // 
            // cardsPanel
            // 
            cardsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cardsPanel.Controls.Add(cardTotalProducts);
            cardsPanel.Controls.Add(cardCategories);
            cardsPanel.Controls.Add(cardLowStock);
            cardsPanel.Controls.Add(cardTotalValue);
            cardsPanel.Location = new Point(189, 129);
            cardsPanel.Margin = new Padding(4);
            cardsPanel.Name = "cardsPanel";
            cardsPanel.Size = new Size(1018, 123);
            cardsPanel.TabIndex = 14;
            cardsPanel.WrapContents = false;
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
            cardTotalProducts.Size = new Size(201, 100);
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
            // 
            // cardCategories
            // 
            cardCategories.BackColor = Color.FromArgb(0, 192, 0);
            cardCategories.BorderStyle = BorderStyle.FixedSingle;
            cardCategories.Controls.Add(lblCategoriesValue);
            cardCategories.Controls.Add(lblCategories);
            cardCategories.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cardCategories.ForeColor = SystemColors.ButtonHighlight;
            cardCategories.Location = new Point(231, 10);
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
            cardLowStock.Location = new Point(471, 10);
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
            cardTotalValue.Location = new Point(711, 10);
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
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(button9);
            panel2.Controls.Add(label7);
            panel2.Location = new Point(21, 290);
            panel2.Name = "panel2";
            panel2.Size = new Size(635, 510);
            panel2.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Alerts__2_;
            pictureBox1.Location = new Point(13, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(74, 53);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ProductName, CurrentStock, MinStock, Status });
            dataGridView1.Location = new Point(1, 75);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(634, 435);
            dataGridView1.TabIndex = 3;
            // 
            // ProductName
            // 
            ProductName.HeaderText = "Product Name";
            ProductName.MinimumWidth = 8;
            ProductName.Name = "ProductName";
            ProductName.Width = 150;
            // 
            // CurrentStock
            // 
            CurrentStock.HeaderText = "Current Stock";
            CurrentStock.MinimumWidth = 8;
            CurrentStock.Name = "CurrentStock";
            CurrentStock.Width = 150;
            // 
            // MinStock
            // 
            MinStock.HeaderText = "Min Stock";
            MinStock.MinimumWidth = 8;
            MinStock.Name = "MinStock";
            MinStock.Width = 150;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 8;
            Status.Name = "Status";
            Status.Width = 150;
            // 
            // button9
            // 
            button9.BackColor = Color.Blue;
            button9.ForeColor = Color.White;
            button9.Location = new Point(499, 18);
            button9.Name = "button9";
            button9.Size = new Size(112, 44);
            button9.TabIndex = 2;
            button9.Text = "View";
            button9.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Stencil", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(93, 26);
            label7.Name = "label7";
            label7.Size = new Size(195, 24);
            label7.TabIndex = 1;
            label7.Text = "Low Stock Alerts";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(22, 56, 92);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(22, 323);
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
            button7.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.White;
            button7.Location = new Point(22, 207);
            button7.Margin = new Padding(4);
            button7.Name = "button7";
            button7.Size = new Size(200, 50);
            button7.TabIndex = 27;
            button7.Text = "Stock Transfer";
            button7.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(22, 56, 92);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(22, 381);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(200, 69);
            button3.TabIndex = 21;
            button3.Text = "Expiry & Batch Tracking";
            button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(22, 56, 92);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(22, 265);
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
            button8.Location = new Point(22, 528);
            button8.Name = "button8";
            button8.Size = new Size(200, 50);
            button8.TabIndex = 14;
            button8.Text = "Log out";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click_1;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(22, 56, 92);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(22, 458);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(200, 63);
            button4.TabIndex = 28;
            button4.Text = "Inventory Evaluation";
            button4.UseVisualStyleBackColor = false;
            // 
            // DashB
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 56, 92);
            BackgroundImage = Properties.Resources._63e90850_52c4_492e_b68d_b47d67cf844b__1_;
            ClientSize = new Size(1653, 1043);
            Controls.Add(button4);
            Controls.Add(button8);
            Controls.Add(button2);
            Controls.Add(button7);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(btnProducts);
            Controls.Add(btnDashboard);
            Controls.Add(btnStockLevels);
            Name = "DashB";
            Text = "DashBoard";
            Load += DashB_Load;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            cardsPanel.ResumeLayout(false);
            cardTotalProducts.ResumeLayout(false);
            cardTotalProducts.PerformLayout();
            cardCategories.ResumeLayout(false);
            cardCategories.PerformLayout();
            cardLowStock.ResumeLayout(false);
            cardLowStock.PerformLayout();
            cardTotalValue.ResumeLayout(false);
            cardTotalValue.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnStockLevels;
        private Button btnDashboard;
        private Button btnProducts;
        private Panel panel1;
        private Label lblTitle;
        private Panel panel2;
        private Label label7;
        private Button button2;
        private Button button7;
        private Button button3;
        private Button button1;
        private Label label8;
        private Button button8;
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
        private Button button9;
        private DataGridView dataGridView1;
        private PictureBox pictureBox1;
        private Panel panel3;
        private TextBox textBox1;
        private Button button10;
        private Label label1;
        private Panel panel4;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn CurrentStock;
        private DataGridViewTextBoxColumn MinStock;
        private DataGridViewTextBoxColumn Status;
        private Label label2;
        private Button btnStockIn;
        private Panel lowStockChartPanel;
        private PictureBox pictureBox2;
        private Button button4;
    }
}