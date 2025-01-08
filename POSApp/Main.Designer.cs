namespace POSApp
{
    partial class Main
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            dataGridView1 = new DataGridView();
            cbTransType = new ComboBox();
            txtBarcode = new TextBox();
            label2 = new Label();
            label3 = new Label();
            lblTotalAmount = new Label();
            lblDiscount = new Label();
            panel1 = new Panel();
            lblTotalAmountHeader = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            btnTender = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            panel2 = new Panel();
            label11 = new Label();
            lblVatExempt = new Label();
            label9 = new Label();
            lblVatAmount = new Label();
            label7 = new Label();
            lblVatSale = new Label();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            btnEmployee = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 30;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = SystemColors.Control;
            dataGridView1.Location = new Point(11, 98);
            dataGridView1.Margin = new Padding(2, 3, 2, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.ShowEditingIcon = false;
            dataGridView1.Size = new Size(702, 336);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // cbTransType
            // 
            cbTransType.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cbTransType.FormattingEnabled = true;
            cbTransType.Items.AddRange(new object[] { "Retail", "Wholesale" });
            cbTransType.Location = new Point(11, 70);
            cbTransType.Margin = new Padding(2, 3, 2, 3);
            cbTransType.Name = "cbTransType";
            cbTransType.Size = new Size(112, 23);
            cbTransType.TabIndex = 0;
            cbTransType.Text = "Retail";
            cbTransType.SelectedIndexChanged += cbTransType_SelectedIndexChanged;
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(127, 70);
            txtBarcode.Margin = new Padding(2, 3, 2, 3);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.PlaceholderText = "Barcode";
            txtBarcode.Size = new Size(586, 22);
            txtBarcode.TabIndex = 3;
            txtBarcode.TextAlign = HorizontalAlignment.Center;
            txtBarcode.KeyDown += txtBarcode_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 10);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(71, 16);
            label2.TabIndex = 10;
            label2.Text = "DISCOUNT";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(17, 123);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(128, 18);
            label3.TabIndex = 11;
            label3.Text = "Total Amount";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotalAmount.ForeColor = Color.Green;
            lblTotalAmount.Location = new Point(465, 123);
            lblTotalAmount.Margin = new Padding(2, 0, 2, 0);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(48, 18);
            lblTotalAmount.TabIndex = 14;
            lblTotalAmount.Text = "0.00";
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new Point(467, 10);
            lblDiscount.Margin = new Padding(2, 0, 2, 0);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(39, 16);
            lblDiscount.TabIndex = 13;
            lblDiscount.Text = "0.00";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(lblTotalAmountHeader);
            panel1.Location = new Point(-6, -4);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1153, 68);
            panel1.TabIndex = 16;
            // 
            // lblTotalAmountHeader
            // 
            lblTotalAmountHeader.AutoSize = true;
            lblTotalAmountHeader.Font = new Font("Courier New", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotalAmountHeader.ForeColor = Color.White;
            lblTotalAmountHeader.Location = new Point(1033, 19);
            lblTotalAmountHeader.Margin = new Padding(2, 0, 2, 0);
            lblTotalAmountHeader.Name = "lblTotalAmountHeader";
            lblTotalAmountHeader.Size = new Size(82, 32);
            lblTotalAmountHeader.TabIndex = 21;
            lblTotalAmountHeader.Text = "0.00";
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.BackgroundImageLayout = ImageLayout.Center;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.Black;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(1057, 286);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(73, 65);
            button1.TabIndex = 17;
            button1.Text = "Actions";
            button1.TextAlign = ContentAlignment.BottomLeft;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.BackgroundImageLayout = ImageLayout.Center;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.Black;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(718, 214);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(161, 121);
            button2.TabIndex = 18;
            button2.Text = "Browse Product";
            button2.TextAlign = ContentAlignment.BottomLeft;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.BackgroundImageLayout = ImageLayout.Center;
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.Black;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(719, 475);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(161, 121);
            button3.TabIndex = 19;
            button3.Text = "Hold Customer";
            button3.TextAlign = ContentAlignment.BottomLeft;
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.BackgroundImageLayout = ImageLayout.Center;
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button4.ForeColor = Color.Black;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(719, 343);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(161, 124);
            button4.TabIndex = 20;
            button4.Text = "View Cart";
            button4.TextAlign = ContentAlignment.BottomLeft;
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.White;
            button5.BackgroundImageLayout = ImageLayout.Center;
            button5.Cursor = Cursors.Hand;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button5.ForeColor = Color.Black;
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.Location = new Point(718, 69);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(161, 137);
            button5.TabIndex = 21;
            button5.Text = "Empty Cart";
            button5.TextAlign = ContentAlignment.BottomLeft;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // btnTender
            // 
            btnTender.BackColor = Color.White;
            btnTender.BackgroundImageLayout = ImageLayout.Center;
            btnTender.Cursor = Cursors.Hand;
            btnTender.FlatAppearance.BorderSize = 0;
            btnTender.FlatStyle = FlatStyle.Flat;
            btnTender.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnTender.ForeColor = Color.Black;
            btnTender.Image = Properties.Resources.tender;
            btnTender.Location = new Point(550, 439);
            btnTender.Margin = new Padding(3, 4, 3, 4);
            btnTender.Name = "btnTender";
            btnTender.Size = new Size(163, 157);
            btnTender.TabIndex = 22;
            btnTender.Text = "Tenders";
            btnTender.TextAlign = ContentAlignment.BottomLeft;
            btnTender.UseVisualStyleBackColor = false;
            btnTender.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.White;
            button7.BackgroundImageLayout = ImageLayout.Center;
            button7.Cursor = Cursors.Hand;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button7.ForeColor = Color.Black;
            button7.Image = (Image)resources.GetObject("button7.Image");
            button7.Location = new Point(1057, 214);
            button7.Margin = new Padding(3, 4, 3, 4);
            button7.Name = "button7";
            button7.Size = new Size(73, 64);
            button7.TabIndex = 23;
            button7.Text = "Receipts";
            button7.TextAlign = ContentAlignment.BottomLeft;
            button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            button8.BackColor = Color.White;
            button8.BackgroundImageLayout = ImageLayout.Center;
            button8.Cursor = Cursors.Hand;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button8.ForeColor = Color.Black;
            button8.Image = (Image)resources.GetObject("button8.Image");
            button8.Location = new Point(1057, 141);
            button8.Margin = new Padding(3, 4, 3, 4);
            button8.Name = "button8";
            button8.Size = new Size(73, 65);
            button8.TabIndex = 24;
            button8.Text = "Customer";
            button8.TextAlign = ContentAlignment.BottomLeft;
            button8.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            button9.BackColor = Color.White;
            button9.BackgroundImageLayout = ImageLayout.Center;
            button9.Cursor = Cursors.Hand;
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button9.ForeColor = Color.Black;
            button9.Image = Properties.Resources._4373460521661014036_32;
            button9.Location = new Point(1057, 359);
            button9.Margin = new Padding(3, 4, 3, 4);
            button9.Name = "button9";
            button9.Size = new Size(73, 65);
            button9.TabIndex = 25;
            button9.Text = "Logout";
            button9.TextAlign = ContentAlignment.BottomLeft;
            button9.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label11);
            panel2.Controls.Add(lblVatExempt);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(lblVatAmount);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(lblVatSale);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(lblDiscount);
            panel2.Controls.Add(lblTotalAmount);
            panel2.Location = new Point(11, 440);
            panel2.Name = "panel2";
            panel2.Size = new Size(533, 156);
            panel2.TabIndex = 26;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(17, 92);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(87, 16);
            label11.TabIndex = 19;
            label11.Text = "VAT EXEMPT";
            // 
            // lblVatExempt
            // 
            lblVatExempt.AutoSize = true;
            lblVatExempt.Location = new Point(467, 92);
            lblVatExempt.Margin = new Padding(2, 0, 2, 0);
            lblVatExempt.Name = "lblVatExempt";
            lblVatExempt.Size = new Size(39, 16);
            lblVatExempt.TabIndex = 20;
            lblVatExempt.Text = "0.00";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(17, 66);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(87, 16);
            label9.TabIndex = 17;
            label9.Text = "VAT AMOUNT";
            // 
            // lblVatAmount
            // 
            lblVatAmount.AutoSize = true;
            lblVatAmount.Location = new Point(467, 66);
            lblVatAmount.Margin = new Padding(2, 0, 2, 0);
            lblVatAmount.Name = "lblVatAmount";
            lblVatAmount.Size = new Size(39, 16);
            lblVatAmount.TabIndex = 18;
            lblVatAmount.Text = "0.00";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 37);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(79, 16);
            label7.TabIndex = 15;
            label7.Text = "VAT SALES";
            // 
            // lblVatSale
            // 
            lblVatSale.AutoSize = true;
            lblVatSale.Location = new Point(467, 37);
            lblVatSale.Margin = new Padding(2, 0, 2, 0);
            lblVatSale.Name = "lblVatSale";
            lblVatSale.Size = new Size(39, 16);
            lblVatSale.TabIndex = 16;
            lblVatSale.Text = "0.00";
            // 
            // button10
            // 
            button10.BackColor = Color.White;
            button10.BackgroundImageLayout = ImageLayout.Center;
            button10.Cursor = Cursors.Hand;
            button10.FlatAppearance.BorderSize = 0;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button10.ForeColor = Color.Black;
            button10.Image = (Image)resources.GetObject("button10.Image");
            button10.Location = new Point(886, 343);
            button10.Margin = new Padding(3, 4, 3, 4);
            button10.Name = "button10";
            button10.Size = new Size(161, 121);
            button10.TabIndex = 27;
            button10.Text = "X-Reading";
            button10.TextAlign = ContentAlignment.BottomLeft;
            button10.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            button11.BackColor = Color.White;
            button11.BackgroundImageLayout = ImageLayout.Center;
            button11.Cursor = Cursors.Hand;
            button11.FlatAppearance.BorderSize = 0;
            button11.FlatStyle = FlatStyle.Flat;
            button11.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button11.ForeColor = Color.Black;
            button11.Image = (Image)resources.GetObject("button11.Image");
            button11.Location = new Point(886, 69);
            button11.Margin = new Padding(3, 4, 3, 4);
            button11.Name = "button11";
            button11.Size = new Size(161, 137);
            button11.TabIndex = 28;
            button11.Text = "Cash Drawer";
            button11.TextAlign = ContentAlignment.BottomLeft;
            button11.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            button12.BackColor = Color.White;
            button12.BackgroundImageLayout = ImageLayout.Center;
            button12.Cursor = Cursors.Hand;
            button12.FlatAppearance.BorderSize = 0;
            button12.FlatStyle = FlatStyle.Flat;
            button12.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            button12.ForeColor = Color.Black;
            button12.Image = (Image)resources.GetObject("button12.Image");
            button12.Location = new Point(886, 214);
            button12.Margin = new Padding(3, 4, 3, 4);
            button12.Name = "button12";
            button12.Size = new Size(161, 121);
            button12.TabIndex = 29;
            button12.Text = "Settle Payment";
            button12.TextAlign = ContentAlignment.BottomLeft;
            button12.UseVisualStyleBackColor = false;
            // 
            // btnEmployee
            // 
            btnEmployee.BackColor = Color.White;
            btnEmployee.BackgroundImageLayout = ImageLayout.Center;
            btnEmployee.Cursor = Cursors.Hand;
            btnEmployee.Enabled = false;
            btnEmployee.FlatAppearance.BorderSize = 0;
            btnEmployee.FlatStyle = FlatStyle.Flat;
            btnEmployee.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEmployee.ForeColor = Color.Black;
            btnEmployee.Image = (Image)resources.GetObject("btnEmployee.Image");
            btnEmployee.Location = new Point(1057, 70);
            btnEmployee.Margin = new Padding(3, 4, 3, 4);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Size = new Size(73, 65);
            btnEmployee.TabIndex = 30;
            btnEmployee.Text = "Employee";
            btnEmployee.TextAlign = ContentAlignment.BottomLeft;
            btnEmployee.UseVisualStyleBackColor = false;
            btnEmployee.Click += btnEmployee_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1138, 609);
            Controls.Add(btnEmployee);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(panel2);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(btnTender);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(txtBarcode);
            Controls.Add(cbTransType);
            Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            Load += Main_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbTransType;
        private TextBox txtBarcode;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label3;
        private Label lblTotalAmount;
        private Label lblDiscount;
        private Panel panel1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button btnTender;
        private Button button7;
        private Button button8;
        private Button button9;
        private Panel panel2;
        private Label label11;
        private Label lblVatExempt;
        private Label label9;
        private Label lblVatAmount;
        private Label label7;
        private Label lblVatSale;
        private Button button10;
        private Button button11;
        private Button button12;
        private Label lblTotalAmountHeader;
        private Button btnEmployee;
    }
}