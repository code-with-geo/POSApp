using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using POSApp.Class;

namespace POSApp
{
    public partial class AddCustomer : Form
    {
        private readonly HttpClient _httpClient;
        private string Token;
        public int CustomerId { get; private set; }
        public string AccountId { get; private set; }
        public AddCustomer(string token)
        {
            InitializeComponent();
            Token = token;
        }
        private async Task<int?> InsertCustomerAsync(string token, object customer)
        {
            try
            {
                // API endpoint for inserting a customer
                string apiUrl = "https://localhost:7148/api/customers"; // Replace with your actual API URL

                var httpClient = new HttpClient();
                var json = JsonConvert.SerializeObject(customer);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Set up the HttpRequestMessage with the Authorization header
                using (var request = new HttpRequestMessage(HttpMethod.Post, apiUrl))
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    request.Content = content;

                    // Send the request
                    var response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        // Parse the response body to get the CustomerId
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var responseJson = JsonConvert.DeserializeObject<dynamic>(responseBody);
                        int customerId = responseJson.CustomerId;

                        MessageBox.Show($"Customer added successfully! Customer ID: {customerId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return customerId; // Return the new CustomerId
                    }
                    else
                    {
                        MessageBox.Show($"Failed to add customer. Error: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var request = new
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                ContactNo = txtContactNo.Text,
                Email = txtEmail.Text
            };

            int? newCustomerId = await InsertCustomerAsync(Token, request);
            Random random = new Random();
            int randomId = random.Next(1000, int.MaxValue);
            string accountId = "CUS" + randomId + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
            var customer = new POSApp.Class.Customers
            {
                AccountId = accountId,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                ContactNo = txtContactNo.Text,
                Email = txtEmail.Text,
                TransactionCount = 0,
                Points = 0
            };

            DatabaseHelper.SaveCustomer(customer);

            if (newCustomerId.HasValue)
            {
                AccountId = accountId;
                CustomerId = newCustomerId.Value;
                this.DialogResult = DialogResult.OK; // Close with success
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
