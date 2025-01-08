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
            btnSkip = new Button();
            btnExit = new Button();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtContactNo = new TextBox();
            txtEmail = new TextBox();
            label1 = new Label();
            btnSearch = new Button();
            btnAddNew = new Button();
            SuspendLayout();
            // 
            // btnSkip
            // 
            btnSkip.BackColor = Color.Black;
            btnSkip.Cursor = Cursors.Hand;
            btnSkip.FlatStyle = FlatStyle.Flat;
            btnSkip.ForeColor = Color.White;
            btnSkip.Location = new Point(404, 178);
            btnSkip.Margin = new Padding(3, 4, 3, 4);
            btnSkip.Name = "btnSkip";
            btnSkip.Size = new Size(125, 46);
            btnSkip.TabIndex = 17;
            btnSkip.Text = "SKIP";
            btnSkip.UseVisualStyleBackColor = false;
            btnSkip.Click += button5_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Black;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(11, 178);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(125, 46);
            btnExit.TabIndex = 16;
            btnExit.Text = "Cancel";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(11, 70);
            txtFirstName.Margin = new Padding(2, 3, 2, 3);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "First Name";
            txtFirstName.Size = new Size(253, 22);
            txtFirstName.TabIndex = 18;
            txtFirstName.TextAlign = HorizontalAlignment.Center;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(276, 70);
            txtLastName.Margin = new Padding(2, 3, 2, 3);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Last Name";
            txtLastName.Size = new Size(253, 22);
            txtLastName.TabIndex = 19;
            txtLastName.TextAlign = HorizontalAlignment.Center;
            // 
            // txtContactNo
            // 
            txtContactNo.Location = new Point(11, 107);
            txtContactNo.Margin = new Padding(2, 3, 2, 3);
            txtContactNo.Name = "txtContactNo";
            txtContactNo.PlaceholderText = "Contact No.";
            txtContactNo.Size = new Size(518, 22);
            txtContactNo.TabIndex = 20;
            txtContactNo.TextAlign = HorizontalAlignment.Center;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(11, 144);
            txtEmail.Margin = new Padding(2, 3, 2, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(518, 22);
            txtEmail.TabIndex = 21;
            txtEmail.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(102, 22);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(334, 27);
            label1.TabIndex = 22;
            label1.Text = "ATTACH CUSTOMER ON SALE";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Black;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(273, 178);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(125, 46);
            btnSearch.TabIndex = 24;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnAddNew
            // 
            btnAddNew.BackColor = Color.Black;
            btnAddNew.Cursor = Cursors.Hand;
            btnAddNew.FlatStyle = FlatStyle.Flat;
            btnAddNew.ForeColor = Color.White;
            btnAddNew.Location = new Point(142, 178);
            btnAddNew.Margin = new Padding(3, 4, 3, 4);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(125, 46);
            btnAddNew.TabIndex = 25;
            btnAddNew.Text = "NEW CUSTOMER";
            btnAddNew.UseVisualStyleBackColor = false;
            btnAddNew.Click += btnAddNew_Click;
            // 
            // Customers
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(537, 234);
            Controls.Add(btnAddNew);
            Controls.Add(btnSearch);
            Controls.Add(label1);
            Controls.Add(txtEmail);
            Controls.Add(txtContactNo);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(btnSkip);
            Controls.Add(btnExit);
            Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Customers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customers";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSkip;
        private Button btnExit;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtContactNo;
        private TextBox txtEmail;
        private Label label1;
        private Button btnSearch;
        private Button btnAddNew;
    }
}