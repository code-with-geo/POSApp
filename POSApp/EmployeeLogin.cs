using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using POSApp.Class;

namespace POSApp
{
    public partial class EmployeeLogin : Form
    {
        private readonly HttpClient _httpClient;
        public string Token { get; private set; }
        public EmployeeLogin()
        {
            InitializeComponent();
            _httpClient = new HttpClient(); // Initialize HttpClient instance
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validate inputs
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // Call API for login
            var token = await AuthenticateUserAsync(username, password);

            if (!string.IsNullOrEmpty(token))
            {
                Token = token;  // Store the token
                this.DialogResult = DialogResult.OK; // Close with success
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid login credentials or API error.");
            }
        }

        private async Task<string> AuthenticateUserAsync(string username, string password)
        {
            try
            {
                // Your API endpoint for login
                string apiUrl = $"https://localhost:7148/api/auth/login?username={username}&password={password}";

                // Create the login request payload (usually a JSON object)
                var loginData = new
                {
                    Username = username,
                    Password = password
                };

                // Serialize the login data to JSON
                var json = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send the POST request to the API
                var response = await _httpClient.PostAsync(apiUrl, content);

                // Check if the request was successful (status code 200-299)
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content (usually contains the token in JSON format)
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Assuming the response is a JSON object with a "token" property
                    var responseObject = JsonConvert.DeserializeObject<ApiResponse>(responseContent);

                    if (responseObject != null && !string.IsNullOrEmpty(responseObject.Token))
                    {
                        return responseObject.Token; // Return the token
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., network errors)
                MessageBox.Show($"Error: {ex.Message}");
            }

            return null; // Return null if authentication failed or an error occurred
        }

        // A class to represent the API response (assuming it returns a token)
        public class ApiResponse
        {
            [JsonProperty("Token")]
            public string Token { get; set; }
        }
    }
}
