namespace InvventoryServices
{
    partial class Form1
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
            groupBox1 = new GroupBox();
            radioButton1 = new RadioButton();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button2 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(385, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(577, 732);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(108, 416);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(153, 29);
            radioButton1.TabIndex = 5;
            radioButton1.TabStop = true;
            radioButton1.Text = "Remember me";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.BackColor = Color.Blue;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(107, 467);
            button1.Name = "button1";
            button1.Size = new Size(374, 64);
            button1.TabIndex = 4;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(103, 314);
            label2.Name = "label2";
            label2.Size = new Size(87, 25);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(103, 189);
            label1.Name = "label1";
            label1.Size = new Size(54, 25);
            label1.TabIndex = 2;
            label1.Text = "Email";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(103, 355);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(378, 31);
            textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(103, 243);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(378, 31);
            textBox1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.Blue;
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(212, 609);
            button2.Name = "button2";
            button2.Size = new Size(161, 53);
            button2.TabIndex = 6;
            button2.Text = "Register";
            button2.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._63e90850_52c4_492e_b68d_b47d67cf844b__1_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1358, 780);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
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
        private RadioButton radioButton1;
        private Button button2;
    }
}
