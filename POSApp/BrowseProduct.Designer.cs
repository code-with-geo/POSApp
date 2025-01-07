namespace POSApp
{
    partial class BrowseProduct
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
            dataGridView1 = new DataGridView();
            txtLocationId = new TextBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Location = new Point(10, 43);
            dataGridView1.Margin = new Padding(2, 3, 2, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(818, 348);
            dataGridView1.TabIndex = 7;
            // 
            // txtLocationId
            // 
            txtLocationId.Location = new Point(185, 15);
            txtLocationId.Margin = new Padding(2, 3, 2, 3);
            txtLocationId.Name = "txtLocationId";
            txtLocationId.PlaceholderText = "Search Product";
            txtLocationId.Size = new Size(643, 22);
            txtLocationId.TabIndex = 6;
            txtLocationId.TextAlign = HorizontalAlignment.Center;
            txtLocationId.TextChanged += txtLocationId_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(10, 13);
            comboBox1.Margin = new Padding(2, 3, 2, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(171, 24);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "Choose Search Key";
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(10, 397);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(110, 39);
            button1.TabIndex = 8;
            button1.Text = "CLOSE";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // BrowseProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(839, 445);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(txtLocationId);
            Controls.Add(comboBox1);
            Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "BrowseProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customers";
            Load += BrowseProduct_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtLocationId;
        private ComboBox comboBox1;
        private Button button1;
    }
}