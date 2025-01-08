namespace POSApp
{
    partial class AddCustomer
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
            txtEmail = new TextBox();
            txtContactNo = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            label1 = new Label();
            btnSearch = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(11, 129);
            txtEmail.Margin = new Padding(2, 3, 2, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(287, 22);
            txtEmail.TabIndex = 25;
            txtEmail.TextAlign = HorizontalAlignment.Center;
            // 
            // txtContactNo
            // 
            txtContactNo.Location = new Point(11, 101);
            txtContactNo.Margin = new Padding(2, 3, 2, 3);
            txtContactNo.Name = "txtContactNo";
            txtContactNo.PlaceholderText = "Contact No.";
            txtContactNo.Size = new Size(287, 22);
            txtContactNo.TabIndex = 24;
            txtContactNo.TextAlign = HorizontalAlignment.Center;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(11, 73);
            txtLastName.Margin = new Padding(2, 3, 2, 3);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Last Name";
            txtLastName.Size = new Size(287, 22);
            txtLastName.TabIndex = 23;
            txtLastName.TextAlign = HorizontalAlignment.Center;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(11, 45);
            txtFirstName.Margin = new Padding(2, 3, 2, 3);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "First Name";
            txtFirstName.Size = new Size(287, 22);
            txtFirstName.TabIndex = 22;
            txtFirstName.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(60, 9);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(180, 27);
            label1.TabIndex = 26;
            label1.Text = "ADD CUSTOMER";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Black;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(173, 164);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(125, 35);
            btnSearch.TabIndex = 28;
            btnSearch.Text = "SAVE";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Black;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(11, 164);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(125, 35);
            btnExit.TabIndex = 27;
            btnExit.Text = "CANCEL";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // AddCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(312, 206);
            Controls.Add(btnSearch);
            Controls.Add(btnExit);
            Controls.Add(label1);
            Controls.Add(txtEmail);
            Controls.Add(txtContactNo);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddCustomer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddCustomer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private TextBox txtContactNo;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Label label1;
        private Button btnSearch;
        private Button btnExit;
    }
}