namespace POSApp
{
    partial class HoldCustomer
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnRemoveAll = new Guna.UI2.WinForms.Guna2Button();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            dgvHoldSale = new Guna.UI2.WinForms.Guna2DataGridView();
            guna2Panel2.SuspendLayout();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoldSale).BeginInit();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2Panel2
            // 
            guna2Panel2.BackColor = Color.MidnightBlue;
            guna2Panel2.Controls.Add(lblTitle);
            guna2Panel2.CustomizableEdges = customizableEdges7;
            guna2Panel2.Location = new Point(-8, -5);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel2.Size = new Size(820, 74);
            guna2Panel2.TabIndex = 11;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(19, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(205, 34);
            lblTitle.TabIndex = 12;
            lblTitle.Text = "HOLD CUSTOMER";
            lblTitle.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.MidnightBlue;
            guna2Panel1.Controls.Add(btnRemoveAll);
            guna2Panel1.Controls.Add(btnClose);
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.Location = new Point(-7, 405);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.Size = new Size(820, 91);
            guna2Panel1.TabIndex = 12;
            // 
            // btnRemoveAll
            // 
            btnRemoveAll.CustomizableEdges = customizableEdges1;
            btnRemoveAll.DisabledState.BorderColor = Color.DarkGray;
            btnRemoveAll.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRemoveAll.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRemoveAll.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRemoveAll.FillColor = Color.Teal;
            btnRemoveAll.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnRemoveAll.ForeColor = Color.White;
            btnRemoveAll.Location = new Point(143, 13);
            btnRemoveAll.Name = "btnRemoveAll";
            btnRemoveAll.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnRemoveAll.Size = new Size(120, 66);
            btnRemoveAll.TabIndex = 17;
            btnRemoveAll.Text = "REMOVE ALL";
            btnRemoveAll.Click += btnRemoveAll_Click;
            // 
            // btnClose
            // 
            btnClose.CustomizableEdges = customizableEdges3;
            btnClose.DisabledState.BorderColor = Color.DarkGray;
            btnClose.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClose.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClose.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClose.FillColor = Color.Teal;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(17, 13);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnClose.Size = new Size(120, 66);
            btnClose.TabIndex = 16;
            btnClose.Text = "CLOSE";
            btnClose.Click += btnClose_Click;
            // 
            // dgvHoldSale
            // 
            dgvHoldSale.AllowUserToAddRows = false;
            dgvHoldSale.AllowUserToDeleteRows = false;
            dgvHoldSale.AllowUserToResizeColumns = false;
            dgvHoldSale.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvHoldSale.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvHoldSale.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvHoldSale.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvHoldSale.ColumnHeadersHeight = 17;
            dgvHoldSale.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvHoldSale.DefaultCellStyle = dataGridViewCellStyle3;
            dgvHoldSale.GridColor = Color.White;
            dgvHoldSale.Location = new Point(10, 75);
            dgvHoldSale.Name = "dgvHoldSale";
            dgvHoldSale.RowHeadersVisible = false;
            dgvHoldSale.RowTemplate.Height = 25;
            dgvHoldSale.Size = new Size(778, 324);
            dgvHoldSale.TabIndex = 15;
            dgvHoldSale.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvHoldSale.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvHoldSale.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvHoldSale.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvHoldSale.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvHoldSale.ThemeStyle.BackColor = Color.White;
            dgvHoldSale.ThemeStyle.GridColor = Color.White;
            dgvHoldSale.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvHoldSale.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHoldSale.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgvHoldSale.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvHoldSale.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvHoldSale.ThemeStyle.HeaderStyle.Height = 17;
            dgvHoldSale.ThemeStyle.ReadOnly = false;
            dgvHoldSale.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvHoldSale.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHoldSale.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgvHoldSale.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvHoldSale.ThemeStyle.RowsStyle.Height = 25;
            dgvHoldSale.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvHoldSale.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvHoldSale.CellClick += dgvHoldSale_CellClick;
            // 
            // HoldCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 496);
            Controls.Add(dgvHoldSale);
            Controls.Add(guna2Panel1);
            Controls.Add(guna2Panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HoldCustomer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HoldCustomer";
            Load += HoldCustomer_Load;
            guna2Panel2.ResumeLayout(false);
            guna2Panel2.PerformLayout();
            guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoldSale).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnRemoveAll;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2DataGridView dgvHoldSale;
    }
}