using Newtonsoft.Json;
using POSApp.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace POSApp
{
    public partial class Tenders : Form
    {
        private List<Cart> _cart;
        private string Token;
        private int CustomerId;
        private int UserId;
        private string AccountId;
        private decimal TotalAmount;
        public Tenders(List<Cart> cart, string token, int customerId, int userId, string accountId)
        {
            InitializeComponent();
            _cart = cart;
            Token = token;
            CustomerId = customerId;
            UserId = userId;
            AccountId = accountId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayTotalAmount()
        {
            decimal totalSubTotal = _cart.Sum(p => p.SubTotal);
            lblAmountDue.Text = totalSubTotal.ToString("C2");
            TotalAmount = totalSubTotal;
        }

        private async Task<bool> AddOrderAsync(int locationId, int userId, int discountId, int customerId)
        {
            try
            {
                // API endpoint
                string apiUrl = "https://localhost:7148/api/orders"; // Replace with your actual API URL
                var _httpClient = new HttpClient();
                // Prepare the products array from the _cart list
                var products = _cart.Select(cartItem => new
                {
                    productId = cartItem.Id, // Use the Id property from the Cart class
                    quantity = cartItem.Quantity,
                    discountId = cartItem.DiscountId
                }).ToList();

                // Create the request body
                var requestBody = new
                {
                    products = products,
                    locationId = locationId,
                    userId = userId,
                    discountId = discountId,
                    customerId = customerId
                };

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Set up the HttpRequestMessage with the Authorization header
                using (var request = new HttpRequestMessage(HttpMethod.Post, apiUrl))
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
                    request.Content = content;

                    // Send the request
                    var response = await _httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        // Success message
                        MessageBox.Show("Order added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true; // Indicate success
                    }
                    else
                    {
                        // Handle errors
                        MessageBox.Show($"Failed to add order. Error: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; // Indicate failure
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Indicate failure
            }
        }

        private void Tenders_Load(object sender, EventArgs e)
        {
            DisplayTotalAmount();
        }

        private async void btnRemoveAll_Click(object sender, EventArgs e)
        {
            int locationId = 1;
            int userId = UserId;
            int discountId = 1;
            bool isSuccess = await AddOrderAsync(locationId, userId, discountId, CustomerId);
            int points = Convert.ToInt32(TotalAmount / 200);
            Random random = new Random();
            int invoiceNo = random.Next(1000000000, int.MaxValue);
            string accountId = AccountId == null ? "N/A" : AccountId;
            decimal totalAmount = TotalAmount;
            decimal receivedAmount = Convert.ToDecimal(txtReceiveAmount.Text);
            int paymentMethod = 0;
            if (isSuccess)
            {
                SaveToLocal(invoiceNo,_cart, accountId,points,userId,locationId, totalAmount, receivedAmount, paymentMethod);
                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is POS pos)
                    {
                        pos.Show();
                        pos.BringToFront();
                        this.Refresh();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK;
                POS newPOSForm = new POS();
                newPOSForm.ShowDialog();
                this.Close();
            }
        }

        private void SaveToLocal(int invoiceNo, List<Cart> cart, string accountId, int points, int userId, int locationId, decimal totalAmount,decimal receivedAmount, int paymentMethod)
        {
            if (accountId != "N/A")
            {
                DatabaseHelper.UpdateCustomerTransaction(accountId, points);
            }
            DatabaseHelper.SaveOrderProducts(cart, invoiceNo);
            DatabaseHelper.SaveOrder(invoiceNo, userId, locationId, accountId, totalAmount, receivedAmount, paymentMethod);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AccountId.ToString());
        }
    }
}
