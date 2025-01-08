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

namespace POSApp
{
    public partial class Tenders : Form
    {
        private List<Cart> _cart;
        private string Token;
        private int customerId;
        public Tenders(List<Cart> cart, string token, int customerId)
        {
            InitializeComponent();
            _cart = cart;
            Token = token;
            this.customerId = customerId;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayTotalAmount()
        {
            // Calculate the total sum of SubTotal from displayedProducts list
            decimal totalSubTotal = _cart.Sum(p => p.SubTotal);

            // Update the label (assuming you have a label named lblTotalSubTotal)
            lblAmountDue.Text = totalSubTotal.ToString("C2"); // "C2" formats as currency with 2 decimals
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            // Example: Call AddOrderAsync with dummy data or actual inputs from your form
            int locationId = 1; // Replace with the actual locationId
            int userId = 1;     // Replace with the actual userId
            int discountId = 1;
            // Call the AddOrderAsync method
            bool isSuccess = await AddOrderAsync(locationId, userId, discountId, customerId);

            if (isSuccess)
            {
                // Redirect to the main form if the call is successful
                MessageBox.Show("Redirecting to the main form...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Bring the main form to the front if it already exists
                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is Main mainForm)
                    {
                        mainForm.Show();      // Ensure it's visible
                        mainForm.BringToFront(); // Bring it to the front
                        this.Refresh();
                        this.DialogResult = DialogResult.OK; // Close with success
                        this.Close();         // Close the current form
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK; // Close with success

                // If the main form is not open, create a new instance
                Main newMainForm = new Main(); // Replace with the actual name of your main form class
                newMainForm.ShowDialog(); // Use ShowDialog if that's how you opened it initially
                this.Close();             // Close the current form
            }
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
            txtLocationId.Text = "0.00";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AddToTextboxValue(100m);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        // Method to add the specified amount to the TextBox value
        private void AddToTextboxValue(decimal amount)
        {
            decimal currentValue = 0.00m;

            // Check if the value in the TextBox is a valid decimal
            if (!string.IsNullOrWhiteSpace(txtLocationId.Text) && decimal.TryParse(txtLocationId.Text, out currentValue))
            {
                // Add the specified amount to the current value
                currentValue += amount;

                // Update the TextBox with the new value formatted as currency (C2)
                txtLocationId.Text = currentValue.ToString();  // "C2" formats it as currency with two decimals
            }
            else
            {
                // Provide a more specific error message
                MessageBox.Show("Please enter a valid number in the TextBox.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            AddToTextboxValue(50m);  // Use decimal type (m suffix)
        }
    }
}
