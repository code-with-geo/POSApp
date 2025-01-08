using System;
using System.Data.SQLite;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using POSApp.Class;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace POSApp
{
    public partial class Login : Form
    {
        private static readonly string FolderPath = @"C:\POS";
        private static readonly string DbPath = Path.Combine(FolderPath, "POS.sqlite");
        public bool IsValid { get; private set; }
        public Login()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string locationid = txtLocationId.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(locationid) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Call API and get the token
                IsValid = await AuthenticateUser(locationid, password);

                if (IsValid)
                {
                    Main mainForm = new Main();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenMainForm()
        {
            Main mainForm = new Main();
            mainForm.Show();
            this.Hide(); // Hide the login form
        }

        private async Task<bool> AuthenticateUser(string locationid, string password)
        {
            string apiUrl = $"https://localhost:7148/api/locations/login?locationid={locationid}&password={password}";

            try
            {
                // Step 1: Check if the local database exists
                if (File.Exists(DbPath))
                {
                    MessageBox.Show("Local database found. Validating user locally.", "Offline Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Step 2: Validate user locally
                    if (ValidateLocal(locationid, password, DbPath))
                    {
                        MessageBox.Show("Login successful (local database).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OpenMainForm(); // Pass username to the main form
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("User not found in local database. Please check your username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else if (!IsInternetAvailable())
                {
                    MessageBox.Show("No internet connection. Falling back to local database.", "Offline Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Step 2: Attempt Local Database Lookup
                    if (ValidateLocal(locationid, password, DbPath))
                    {
                        MessageBox.Show("Login successful (local database).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OpenMainForm(); // Pass username to the main form
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("User not found in local database. Please connect to the internet to log in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; // Force user to connect to the internet
                    }
                } else
                {
                    var httpClient = new HttpClient();

                    // Prepare request payload
                    var payload = new
                    {
                        LocationId = locationid,
                        Password = password
                    };
                    var jsonPayload = JsonConvert.SerializeObject(payload);
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    // API Call
                    var response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Parse API response
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<dynamic>(jsonResponse);

                        // Check if login was successful
                        if (result?.Message == "Login successfully") // Update this to match your API response structure
                        {
                            MessageBox.Show("Login successful (via API).", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            OpenMainForm(); // Pass username to the main form
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool IsInternetAvailable()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool ValidateLocal(string loctionid, string password, string dbPath)
        {
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    connection.Open();

                    string query = "SELECT COUNT(1) FROM Locations WHERE LocationId = @LocationId AND Password = @Password";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LocationId", loctionid);
                        command.Parameters.AddWithValue("@Password", password); // Store passwords securely (hashed/salted)

                        var result = Convert.ToInt32(command.ExecuteScalar());
                        return result > 0; // Return true if user exists, otherwise false
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading from local database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
