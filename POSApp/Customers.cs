using POSApp.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSApp
{
    public partial class Customers : Form
    {
        private List<Cart> _cart;
        private string Token;
        public int CustomerId { get; private set; }
        public int UserId { get; private set; }
        public string AccountId { get; private set; }
        public Customers(List<Cart> cart, string token, int userId)
        {
            InitializeComponent();
            _cart = cart;
            Token = token;
            UserId = userId;
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            var tender = new Tenders(_cart, Token, CustomerId, UserId, AccountId);
            var result = tender.ShowDialog();


            if (result == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            var customer = new AddCustomer(Token);
            var result = customer.ShowDialog();

            // If the user successfully logged in, set the token
            if (result == DialogResult.OK)
            {
                CustomerId = customer.CustomerId;
                AccountId = customer.AccountId;
                var tender = new Tenders(_cart, Token, CustomerId, UserId, AccountId);
                var open = tender.ShowDialog();
                this.Hide();
                if (result == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(UserId.ToString());
        }
    }
}
