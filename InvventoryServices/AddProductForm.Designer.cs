namespace InvventoryServices
{
    partial class AddProductForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblName = new Label();
            txtName = new TextBox();
            lblCategory = new Label();
            txtCategory = new TextBox();
            lblSKU = new Label();
            txtSKU = new TextBox();
            lblCurrentStock = new Label();
            numCurrentStock = new NumericUpDown();
            lblMinStock = new Label();
            numMinStock = new NumericUpDown();
            lblPrice = new Label();
            numPrice = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numCurrentStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMinStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(20, 25);
            lblName.Name = "lblName";
            lblName.Size = new Size(107, 25);
            lblName.TabIndex = 0;
            lblName.Text = "Product Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(160, 22);
            txtName.Name = "txtName";
            txtName.Size = new Size(280, 31);
            txtName.TabIndex = 1;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(20, 70);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(84, 25);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category";
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(160, 67);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(280, 31);
            txtCategory.TabIndex = 3;
            // 
            // lblSKU
            // 
            lblSKU.AutoSize = true;
            lblSKU.Location = new Point(20, 115);
            lblSKU.Name = "lblSKU";
            lblSKU.Size = new Size(44, 25);
            lblSKU.TabIndex = 4;
            lblSKU.Text = "SKU";
            // 
            // txtSKU
            // 
            txtSKU.Location = new Point(160, 112);
            txtSKU.Name = "txtSKU";
            txtSKU.Size = new Size(280, 31);
            txtSKU.TabIndex = 5;
            // 
            // lblCurrentStock
            // 
            lblCurrentStock.AutoSize = true;
            lblCurrentStock.Location = new Point(20, 160);
            lblCurrentStock.Name = "lblCurrentStock";
            lblCurrentStock.Size = new Size(111, 25);
            lblCurrentStock.TabIndex = 6;
            lblCurrentStock.Text = "Current Stock";
            // 
            // numCurrentStock
            // 
            numCurrentStock.Location = new Point(160, 158);
            numCurrentStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numCurrentStock.Name = "numCurrentStock";
            numCurrentStock.Size = new Size(150, 31);
            numCurrentStock.TabIndex = 7;
            // 
            // lblMinStock
            // 
            lblMinStock.AutoSize = true;
            lblMinStock.Location = new Point(20, 205);
            lblMinStock.Name = "lblMinStock";
            lblMinStock.Size = new Size(87, 25);
            lblMinStock.TabIndex = 8;
            lblMinStock.Text = "Min Stock";
            // 
            // numMinStock
            // 
            numMinStock.Location = new Point(160, 203);
            numMinStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numMinStock.Name = "numMinStock";
            numMinStock.Size = new Size(150, 31);
            numMinStock.TabIndex = 9;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(20, 250);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(49, 25);
            lblPrice.TabIndex = 10;
            lblPrice.Text = "Price";
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(160, 248);
            numPrice.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(150, 31);
            numPrice.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(22, 56, 92);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(160, 305);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 42);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(310, 305);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 42);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 375);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(numPrice);
            Controls.Add(lblPrice);
            Controls.Add(numMinStock);
            Controls.Add(lblMinStock);
            Controls.Add(numCurrentStock);
            Controls.Add(lblCurrentStock);
            Controls.Add(txtSKU);
            Controls.Add(lblSKU);
            Controls.Add(txtCategory);
            Controls.Add(lblCategory);
            Controls.Add(txtName);
            Controls.Add(lblName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddProductForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Product";
            ((System.ComponentModel.ISupportInitialize)numCurrentStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMinStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Label lblCategory;
        private TextBox txtCategory;
        private Label lblSKU;
        private TextBox txtSKU;
        private Label lblCurrentStock;
        private NumericUpDown numCurrentStock;
        private Label lblMinStock;
        private NumericUpDown numMinStock;
        private Label lblPrice;
        private NumericUpDown numPrice;
        private Button btnSave;
        private Button btnCancel;
    }
}
