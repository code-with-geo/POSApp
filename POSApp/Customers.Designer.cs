namespace POSApp
{
    partial class Customers
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
            button5 = new Button();
            btnExit = new Button();
            txtLocationId = new TextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label1 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // button5
            // 
            button5.BackColor = Color.Black;
            button5.Cursor = Cursors.Hand;
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = Color.White;
            button5.Location = new Point(371, 222);
            button5.Margin = new Padding(4);
            button5.Name = "button5";
            button5.Size = new Size(171, 80);
            button5.TabIndex = 17;
            button5.Text = "SKIP";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Black;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(13, 222);
            btnExit.Margin = new Padding(4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(171, 80);
            btnExit.TabIndex = 16;
            btnExit.Text = "NEW CUSTOMER";
            btnExit.UseVisualStyleBackColor = false;
            // 
            // txtLocationId
            // 
            txtLocationId.Location = new Point(63, 85);
            txtLocationId.Name = "txtLocationId";
            txtLocationId.PlaceholderText = "First Name";
            txtLocationId.Size = new Size(211, 26);
            txtLocationId.TabIndex = 18;
            txtLocationId.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(290, 85);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Last Name";
            textBox1.Size = new Size(211, 26);
            textBox1.TabIndex = 19;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(63, 129);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Contact No.";
            textBox2.Size = new Size(438, 26);
            textBox2.TabIndex = 20;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(63, 176);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Email Address";
            textBox3.Size = new Size(438, 26);
            textBox3.TabIndex = 21;
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(114, 32);
            label1.Name = "label1";
            label1.Size = new Size(334, 27);
            label1.TabIndex = 22;
            label1.Text = "ATTACH CUSTOMER ON SALE";
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(192, 222);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(171, 80);
            button2.TabIndex = 24;
            button2.Text = "SEARCH";
            button2.UseVisualStyleBackColor = false;
            // 
            // Customers
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(554, 327);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(txtLocationId);
            Controls.Add(button5);
            Controls.Add(btnExit);
            Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "Customers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customers";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button5;
        private Button btnExit;
        private TextBox txtLocationId;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label1;
        private Button button2;
    }
}