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
            Name = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            RetailPrice = new DataGridViewTextBoxColumn();
            WholesalePrice = new DataGridViewTextBoxColumn();
            AvailableUnits = new DataGridViewTextBoxColumn();
            Specification = new DataGridViewTextBoxColumn();
            txtLocationId = new TextBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Name, Description, RetailPrice, WholesalePrice, AvailableUnits, Specification });
            dataGridView1.Location = new Point(12, 48);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(995, 392);
            dataGridView1.TabIndex = 7;
            // 
            // Name
            // 
            Name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Name.HeaderText = "Name";
            Name.Name = "Name";
            // 
            // Description
            // 
            Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Description.HeaderText = "Description";
            Description.Name = "Description";
            // 
            // RetailPrice
            // 
            RetailPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RetailPrice.HeaderText = "Retail Price";
            RetailPrice.Name = "RetailPrice";
            // 
            // WholesalePrice
            // 
            WholesalePrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            WholesalePrice.HeaderText = "Wholesale Price";
            WholesalePrice.Name = "WholesalePrice";
            WholesalePrice.Resizable = DataGridViewTriState.False;
            // 
            // AvailableUnits
            // 
            AvailableUnits.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            AvailableUnits.HeaderText = "Available Units";
            AvailableUnits.Name = "AvailableUnits";
            // 
            // Specification
            // 
            Specification.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Specification.HeaderText = "Specification";
            Specification.Name = "Specification";
            // 
            // txtLocationId
            // 
            txtLocationId.Location = new Point(276, 15);
            txtLocationId.Name = "txtLocationId";
            txtLocationId.PlaceholderText = "Search Product";
            txtLocationId.Size = new Size(731, 26);
            txtLocationId.TabIndex = 6;
            txtLocationId.TextAlign = HorizontalAlignment.Center;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 15);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(258, 26);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "Choose Search Key";
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(12, 447);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(171, 80);
            button1.TabIndex = 8;
            button1.Text = "CLOSE";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // BrowseProduct
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1019, 536);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(txtLocationId);
            Controls.Add(comboBox1);
            Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customers";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtLocationId;
        private ComboBox comboBox1;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn RetailPrice;
        private DataGridViewTextBoxColumn WholesalePrice;
        private DataGridViewTextBoxColumn AvailableUnits;
        private DataGridViewTextBoxColumn Specification;
        private Button button1;
    }
}