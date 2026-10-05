namespace InvventoryServices
{
    partial class Stock_Transfer
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
            label1 = new Label();
            button2 = new Button();
            button7 = new Button();
            button4 = new Button();
            button3 = new Button();
            button1 = new Button();
            btnStockLevels = new Button();
            btnProducts = new Button();
            btnDashboard = new Button();
            panel1 = new Panel();
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            label9 = new Label();
            panel2 = new Panel();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            button9 = new Button();
            button5 = new Button();
            textBox2 = new TextBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            label3 = new Label();
            cmbCategory = new ComboBox();
            panel3 = new Panel();
            comboBox3 = new ComboBox();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            Datetime = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            FromLocation = new DataGridViewTextBoxColumn();
            ToLocation = new DataGridViewTextBoxColumn();
            Remarks = new DataGridViewTextBoxColumn();
            Action = new DataGridViewTextBoxColumn();
            txtSearch = new TextBox();
            button8 = new Button();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(100, 20);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(203, 38);
            label1.TabIndex = 0;
            label1.Text = "Stock Transfer";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(22, 56, 92);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(25, 299);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(227, 50);
            button2.TabIndex = 76;
            button2.Text = "Low-Stock Alerts";
            button2.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(22, 56, 92);
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.White;
            button7.Location = new Point(25, 182);
            button7.Margin = new Padding(4);
            button7.Name = "button7";
            button7.Size = new Size(227, 50);
            button7.TabIndex = 80;
            button7.Text = "Stock Transfer";
            button7.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(22, 56, 92);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(24, 415);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(228, 50);
            button4.TabIndex = 77;
            button4.Text = "Inventory Valuation";
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(22, 56, 92);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(25, 357);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(227, 50);
            button3.TabIndex = 74;
            button3.Text = "Expiry & Batch Tracking";
            button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(22, 56, 92);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(25, 241);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(227, 50);
            button1.TabIndex = 75;
            button1.Text = "Adjustment";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnStockLevels
            // 
            btnStockLevels.BackColor = Color.FromArgb(22, 56, 92);
            btnStockLevels.FlatStyle = FlatStyle.Flat;
            btnStockLevels.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStockLevels.ForeColor = Color.White;
            btnStockLevels.Location = new Point(25, 124);
            btnStockLevels.Margin = new Padding(4);
            btnStockLevels.Name = "btnStockLevels";
            btnStockLevels.Size = new Size(227, 50);
            btnStockLevels.TabIndex = 71;
            btnStockLevels.Text = "Stock Levels";
            btnStockLevels.UseVisualStyleBackColor = false;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.FromArgb(22, 56, 92);
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProducts.ForeColor = Color.White;
            btnProducts.Location = new Point(25, 67);
            btnProducts.Margin = new Padding(4);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(227, 50);
            btnProducts.TabIndex = 70;
            btnProducts.Text = "Products";
            btnProducts.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(22, 56, 92);
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(25, 9);
            btnDashboard.Margin = new Padding(4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(227, 50);
            btnDashboard.TabIndex = 69;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel3);
            panel1.Location = new Point(305, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1264, 1112);
            panel1.TabIndex = 81;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(pictureBox1);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(label1);
            panel4.Location = new Point(0, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(1261, 109);
            panel4.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.recent__2_;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(95, 94);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(100, 58);
            label9.Name = "label9";
            label9.Size = new Size(572, 25);
            label9.TabIndex = 15;
            label9.Text = "Move stock between locations and keep your inventory balanced.";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(button9);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(comboBox2);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(cmbCategory);
            panel2.Location = new Point(20, 126);
            panel2.Name = "panel2";
            panel2.Size = new Size(1212, 325);
            panel2.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(13, 186);
            label8.Name = "label8";
            label8.Size = new Size(87, 25);
            label8.TabIndex = 15;
            label8.Text = "Quantity";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(13, 75);
            label7.Name = "label7";
            label7.Size = new Size(79, 25);
            label7.TabIndex = 14;
            label7.Text = "Product";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(402, 186);
            label6.Name = "label6";
            label6.Size = new Size(110, 25);
            label6.TabIndex = 13;
            label6.Text = "To Location";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(402, 71);
            label5.Name = "label5";
            label5.Size = new Size(133, 25);
            label5.TabIndex = 12;
            label5.Text = "From Location";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(721, 71);
            label4.Name = "label4";
            label4.Size = new Size(178, 25);
            label4.TabIndex = 11;
            label4.Text = "Remarks (Optional)";
            // 
            // button9
            // 
            button9.BackColor = Color.Blue;
            button9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.ForeColor = Color.White;
            button9.Location = new Point(923, 242);
            button9.Name = "button9";
            button9.Size = new Size(245, 61);
            button9.TabIndex = 10;
            button9.Text = "Transfer Stock";
            button9.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(761, 250);
            button5.Name = "button5";
            button5.Size = new Size(141, 44);
            button5.TabIndex = 9;
            button5.Text = "Reset";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(721, 104);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(459, 121);
            textBox2.TabIndex = 8;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "All Categories" });
            comboBox2.Location = new Point(402, 215);
            comboBox2.Margin = new Padding(4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(277, 33);
            comboBox2.TabIndex = 7;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "All Categories" });
            comboBox1.Location = new Point(402, 104);
            comboBox1.Margin = new Padding(4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(277, 33);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(13, 215);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(277, 31);
            textBox1.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label3.Location = new Point(13, 12);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(270, 38);
            label3.TabIndex = 1;
            label3.Text = "New Stock Transfer";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "All Categories" });
            cmbCategory.Location = new Point(13, 104);
            cmbCategory.Margin = new Padding(4);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(277, 33);
            cmbCategory.TabIndex = 4;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(comboBox3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(dataGridView1);
            panel3.Controls.Add(txtSearch);
            panel3.Location = new Point(20, 462);
            panel3.Name = "panel3";
            panel3.Size = new Size(1212, 626);
            panel3.TabIndex = 5;
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "All Categories" });
            comboBox3.Location = new Point(982, 13);
            comboBox3.Margin = new Padding(4);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(211, 33);
            comboBox3.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(4, 13);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(299, 38);
            label2.TabIndex = 6;
            label2.Text = "Recent Stock Transfer";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Datetime, ProductName, Quantity, FromLocation, ToLocation, Remarks, Action });
            dataGridView1.Location = new Point(0, 63);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1217, 560);
            dataGridView1.TabIndex = 6;
            // 
            // Datetime
            // 
            Datetime.HeaderText = "Date & Time";
            Datetime.MinimumWidth = 10;
            Datetime.Name = "Datetime";
            Datetime.Width = 150;
            // 
            // ProductName
            // 
            ProductName.HeaderText = "Product Name";
            ProductName.MinimumWidth = 10;
            ProductName.Name = "ProductName";
            ProductName.Width = 150;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 8;
            Quantity.Name = "Quantity";
            Quantity.Width = 150;
            // 
            // FromLocation
            // 
            FromLocation.HeaderText = "From Location";
            FromLocation.MinimumWidth = 10;
            FromLocation.Name = "FromLocation";
            FromLocation.Width = 170;
            // 
            // ToLocation
            // 
            ToLocation.HeaderText = "To Location";
            ToLocation.MinimumWidth = 8;
            ToLocation.Name = "ToLocation";
            ToLocation.Width = 170;
            // 
            // Remarks
            // 
            Remarks.HeaderText = "Remarks";
            Remarks.MinimumWidth = 8;
            Remarks.Name = "Remarks";
            Remarks.Width = 170;
            // 
            // Action
            // 
            Action.HeaderText = "Action";
            Action.MinimumWidth = 10;
            Action.Name = "Action";
            Action.Width = 190;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(511, 13);
            txtSearch.Margin = new Padding(4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search product name, category, or SKU...";
            txtSearch.Size = new Size(449, 31);
            txtSearch.TabIndex = 2;
            // 
            // button8
            // 
            button8.BackColor = Color.Red;
            button8.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.White;
            button8.Location = new Point(24, 472);
            button8.Name = "button8";
            button8.Size = new Size(227, 50);
            button8.TabIndex = 85;
            button8.Text = "Log out";
            button8.UseVisualStyleBackColor = false;
            // 
            // Stock_Transfer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 56, 92);
            BackgroundImage = Properties.Resources._63e90850_52c4_492e_b68d_b47d67cf844b__1_;
            ClientSize = new Size(1564, 1099);
            Controls.Add(button8);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(button7);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(btnStockLevels);
            Controls.Add(btnProducts);
            Controls.Add(btnDashboard);
            Margin = new Padding(4);
            Name = "Stock_Transfer";
            Text = "Stock Transfer";
            Load += Stock_Transfer_Load;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Button button2;
        private Button button7;
        private Button button4;
        private Button button3;
        private Button button1;
        private Button btnStockLevels;
        private Button btnProducts;
        private Button btnDashboard;
        private Panel panel1;
        private ComboBox cmbCategory;
        private TextBox txtSearch;
        private Button button8;
        private Panel panel3;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Datetime;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn FromLocation;
        private DataGridViewTextBoxColumn ToLocation;
        private DataGridViewTextBoxColumn Remarks;
        private DataGridViewTextBoxColumn Action;
        private Label label2;
        private Panel panel2;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label3;
        private Button button9;
        private Button button5;
        private TextBox textBox2;
        private ComboBox comboBox2;
        private Panel panel4;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label9;
        private ComboBox comboBox3;
        private PictureBox pictureBox1;
    }
}
