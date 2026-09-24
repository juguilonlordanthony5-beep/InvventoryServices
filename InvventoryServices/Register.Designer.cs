namespace InvventoryServices
{
    partial class Register
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
            groupBox1 = new GroupBox();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            label3 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(395, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(577, 732);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Blue;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(107, 519);
            button1.Name = "button1";
            button1.Size = new Size(374, 64);
            button1.TabIndex = 4;
            button1.Text = "Register Now";
            button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(107, 404);
            label2.Name = "label2";
            label2.Size = new Size(87, 25);
            label2.TabIndex = 3;
            label2.Text = "Password";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(107, 296);
            label1.Name = "label1";
            label1.Size = new Size(54, 25);
            label1.TabIndex = 2;
            label1.Text = "Email";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(107, 341);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(378, 31);
            textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(107, 230);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(378, 31);
            textBox1.TabIndex = 0;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(107, 449);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(378, 31);
            textBox3.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(107, 177);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 6;
            label3.Text = "Name";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._63e90850_52c4_492e_b68d_b47d67cf844b__1_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1366, 774);
            Controls.Add(groupBox1);
            Name = "Register";
            Text = "Register";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button button1;
        private Label label2;
        private Label label1;
        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox textBox3;
        private Label label3;
    }
}