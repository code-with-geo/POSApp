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
        public Customers(List<Cart> cart, string token)
        {
            InitializeComponent();
            _cart = cart;
            Token = token;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*Tenders tenders = new Tenders(_cart,Token,CustomerId);
            tenders.ShowDialog();
            this.Hide();*/
            var tender = new Tenders(_cart, Token, CustomerId);
            var result = tender.ShowDialog();

            // If the user successfully logged in, set the token
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Transaction completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Close with success
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            var customer = new AddCustomer(Token);
            var result = customer.ShowDialog();

            // If the user successfully logged in, set the token
            if (result == DialogResult.OK)
            {
                CustomerId = customer.CustomerId;
                Tenders tenders = new Tenders(_cart, Token, CustomerId);
                tenders.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Add Failed.");
            }
        }
    }
}
