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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;

namespace POSApp
{
    public partial class Main : Form
    {
        private List<Cart> displayedProducts = new List<Cart>();
        private List<Inventory> inventoryList = new List<Inventory>();
        private static readonly string FolderPath = @"C:\POS";
        private static readonly string DbPath = Path.Combine(FolderPath, "POS.sqlite");
        private static bool isRetail = true;
        public string Token { get; private set; }

        public Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BrowseProduct browse = new BrowseProduct();
            browse.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customers customer = new Customers(displayedProducts, Token);
            customer.Show();
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            if (!File.Exists(DbPath))
            {
                DatabaseHelper.CreateDatabase();
                if (IsInternetAvailable())
                {
                    if (string.IsNullOrEmpty(Token))
                    {
                        var employee = new EmployeeLogin();
                        var result = employee.ShowDialog();

                        // If the user successfully logged in, set the token
                        if (result == DialogResult.OK)
                        {

                            Token = employee.Token;
                            btnEmployee.Enabled = false;
                            string apiUrl = "https://localhost:7148/api/products";
                            string apiUrl2 = "https://localhost:7148/api/locations";
                            string apiUrl3 = "https://localhost:7148/api/category";
                            string apiUrl4 = "https://localhost:7148/api/inventory";
                            string apiUrl5 = "https://localhost:7148/api/discounts";
                            await DatabaseHelper.SyncProducts(apiUrl, Token);
                            await DatabaseHelper.SyncLocations(apiUrl2, Token);
                            await DatabaseHelper.SyncCategory(apiUrl3, Token);
                            await DatabaseHelper.SyncInventory(apiUrl4, Token);
                            await DatabaseHelper.SyncDiscount(apiUrl5, Token);
                            this.Refresh();
                        }
                    }
                }
            }
            else
            {
                if (IsInternetAvailable())
                {
                    if (string.IsNullOrEmpty(Token))
                    {
                        btnEmployee.Enabled = true;
                    }
                    else
                    {
                        string apiUrl = "https://localhost:7148/api/products";
                        string apiUrl2 = "https://localhost:7148/api/locations";
                        string apiUrl3 = "https://localhost:7148/api/category";
                        string apiUrl4 = "https://localhost:7148/api/inventory";
                        await DatabaseHelper.SyncProducts(apiUrl, Token);
                        await DatabaseHelper.SyncLocations(apiUrl2, Token);
                        await DatabaseHelper.SyncCategory(apiUrl3, Token);
                        await DatabaseHelper.SyncInventory(apiUrl4, Token);
                    }
                }
                else
                {

                }

                inventoryList = DatabaseHelper.LoadInventoryList();
                lblVatSale.Text = 0.ToString("C2");
                lblVatAmount.Text = 0.ToString("C2");
                lblTotalAmount.Text = 0.ToString("C2");
                lblVatExempt.Text = 0.ToString("C2");
                lblDiscount.Text = 0.ToString("C2");
                lblTotalAmountHeader.Text = 0.ToString("C2");

            }

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            string apiUrl = "https://localhost:7148/api/products";
            string apiUrl2 = "https://localhost:7148/api/locations";
            string apiUrl3 = "https://localhost:7148/api/category";
            string apiUrl4 = "https://localhost:7148/api/inventory";
            await DatabaseHelper.SyncProducts(apiUrl, Token);
            await DatabaseHelper.SyncLocations(apiUrl2, Token);
            await DatabaseHelper.SyncCategory(apiUrl3, Token);
            await DatabaseHelper.SyncInventory(apiUrl4, Token);
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            displayedProducts.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.ColumnHeadersVisible = false;
            RefreshDataGridView();
            DisplayTotalAmount();
            DisplayVatSale();
            DisplayVatAmount();
            lblDiscount.Text = 0.ToString("C2");
            inventoryList = DatabaseHelper.LoadInventoryList();
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

        private void AddProductToCart()
        {
            if (int.TryParse(txtBarcode.Text, out int productId))
            {
                // Fetch the product inventory details
                var inventory = inventoryList.FirstOrDefault(i => i.ProductId == productId && i.LocationId == 1);

                if (inventory == null)
                {
                    MessageBox.Show($"No inventory found for Product ID {productId} at this location.", "Inventory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if the product already exists in displayedProducts
                var existingProduct = displayedProducts.FirstOrDefault(p => p.Id == productId);

                if (existingProduct != null)
                {
                    // Check if adding another unit exceeds the inventory
                    if (existingProduct.Quantity + 1 > inventory.Units)
                    {
                        MessageBox.Show($"Cannot add more units. Available stock: {inventory.Units}.", "Stock Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Increment quantity if product already exists
                    existingProduct.Quantity += 1;

                    // Update SubTotal
                    existingProduct.SubTotal = existingProduct.Quantity * existingProduct.Price;

                    // If product has VAT, update the VAT amount
                    if (existingProduct.IsVat == 1)
                    {
                        existingProduct.VatAmount = existingProduct.SubTotal * 0.12m;  // 12% VAT
                    }

                    // Refresh DataGridView after updating
                    RefreshDataGridView();
                    DisplayTotalAmount();
                    DisplayVatSale();
                    DisplayVatAmount();

                    //  MessageBox.Show($"Product {productId} already exists. Quantity increased to {existingProduct.Quantity}.");
                }
                else
                {
                    // Check if inventory has at least one unit
                    if (inventory.Units < 1)
                    {
                        MessageBox.Show($"Product ID {productId} is out of stock.", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Fetch product from the database
                    var product = isRetail ? DatabaseHelper.GetRetailedProductById(productId) : DatabaseHelper.GetWholesaleProductById(productId);

                    if (product != null)
                    {
                        // Calculate VAT if applicable
                        decimal vatAmount = 0;
                        if (product.IsVat == 1)
                        {
                            vatAmount = isRetail ? product.RetailPrice * 0.12m : product.WholesalePrice * 0.12m; // 12% VAT
                        }

                        // Add the product to the cart
                        displayedProducts.Add(new Cart
                        {
                            Id = product.Id,
                            Barcode = product.Barcode,
                            Name = product.Name,
                            Description = product.Description,
                            Price = isRetail ? product.RetailPrice : product.WholesalePrice,
                            Quantity = 1, // Initial quantity is 1
                            SubTotal = isRetail ? product.RetailPrice : product.WholesalePrice, // SubTotal = RetailPrice * Quantity
                            VatAmount = vatAmount, // Add VAT amount to the cart
                            IsVat = product.IsVat
                        });

                        // Refresh DataGridView to display the updated cart
                        RefreshDataGridView();
                        DisplayTotalAmount();
                        DisplayVatSale();
                        DisplayVatAmount();

                        //      MessageBox.Show($"Product {productId} added with quantity 1.");
                    }
                    else
                    {
                        // If no product is found in the database
                        MessageBox.Show($"Product with ID {productId} not found in the database.");
                    }
                }

                txtBarcode.Clear(); // Clear input for the next product
            }
            else
            {
                MessageBox.Show("Please enter a valid product ID.");
            }
        }

        private void RefreshDataGridView()
        {
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // Add columns and bind to properties
            dataGridView1.Columns.Add("Barcode", "Barcode");
            dataGridView1.Columns["Barcode"].DataPropertyName = "Barcode";

            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns["Name"].DataPropertyName = "Name";

            dataGridView1.Columns.Add("Description", "Description");
            dataGridView1.Columns["Description"].DataPropertyName = "Description";

            dataGridView1.Columns.Add("Price", "Price");
            dataGridView1.Columns["Price"].DataPropertyName = "Price";

            dataGridView1.Columns.Add("Quantity", "Quantity");
            dataGridView1.Columns["Quantity"].DataPropertyName = "Quantity";

            dataGridView1.Columns.Add("SubTotal", "Sub Total");
            dataGridView1.Columns["SubTotal"].DataPropertyName = "SubTotal";

            dataGridView1.Columns.Add("VatAmount", "VAT Amount");
            dataGridView1.Columns["VatAmount"].DataPropertyName = "VatAmount";

            // Add Remove button column
            DataGridViewButtonColumn removeButtonColumn = new DataGridViewButtonColumn();
            removeButtonColumn.Name = "Remove";
            removeButtonColumn.HeaderText = "Remove";
            removeButtonColumn.Text = "Remove";
            removeButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(removeButtonColumn);

            // Add Discount column to DataGridView
            DataGridViewButtonColumn discountColumn = new DataGridViewButtonColumn();
            discountColumn.Name = "Discount";
            discountColumn.HeaderText = "Apply Discount";
            discountColumn.Text = "Apply";
            discountColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(discountColumn);

            // Bind the displayedProducts list to the DataGridView
            dataGridView1.DataSource = null;  // Clear previous binding
            dataGridView1.DataSource = displayedProducts;

            // Format columns for currency
            dataGridView1.Columns["Price"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["SubTotal"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["VatAmount"].DefaultCellStyle.Format = "C2";
            // Align numeric columns
            dataGridView1.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["VatAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // Set readonly for certain columns
            dataGridView1.Columns["VatAmount"].ReadOnly = true;
            dataGridView1.Columns["SubTotal"].ReadOnly = true;
        }

        private void DisplayTotalAmount()
        {
            // Calculate the total sum of SubTotal from displayedProducts list
            decimal totalSubTotal = displayedProducts.Sum(p => p.SubTotal);

            // Update the label (assuming you have a label named lblTotalSubTotal)
            lblTotalAmount.Text = totalSubTotal.ToString("C2"); // "C2" formats as currency with 2 decimals
            lblTotalAmountHeader.Text = totalSubTotal.ToString("C2"); // "C2" formats as currency with 2 decimals
        }

        private void DisplayVatSale()
        {
            decimal vatInclusiveTotal = displayedProducts.Where(p => p.IsVat == 1).Sum(p => p.SubTotal);
            lblVatSale.Text = vatInclusiveTotal.ToString("C2"); // Format as currency
        }

        private void DisplayVatAmount()
        {
            decimal VatAmount = displayedProducts.Sum(p => p.VatAmount);
            lblVatAmount.Text = VatAmount.ToString("C2"); // Format as currency
        }

        private void DisplayVatExempt()
        {
            decimal VatExempt = displayedProducts.Where(p => p.IsVat == 0).Sum(p => p.SubTotal);
            lblVatExempt.Text = VatExempt.ToString("C2"); // Format as currency
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            //Customers customer = new Customers(displayedProducts, Token);
            //customer.ShowDialog();
            var customer = new Customers(displayedProducts, Token);
            var result = customer.ShowDialog();

            // If the user successfully logged in, set the token
            if (result == DialogResult.OK)
            {
                displayedProducts.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.ColumnHeadersVisible = false;
                RefreshDataGridView();
                DisplayTotalAmount();
                DisplayVatSale();
                DisplayVatAmount();
                lblDiscount.Text = 0.ToString("C2");
                string apiUrl4 = "https://localhost:7148/api/inventory";
                await DatabaseHelper.SyncInventory(apiUrl4, Token);
                inventoryList = DatabaseHelper.LoadInventoryList();
            }

        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddProductToCart(); // Call the method to add product
                e.SuppressKeyPress = true; // Suppress the "ding" sound from Enter key
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click is on the "Remove" button column
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Remove"].Index)
            {
                var productToRemove = displayedProducts[e.RowIndex];

                // If quantity is greater than 1, decrease the quantity
                if (productToRemove.Quantity > 1)
                {
                    productToRemove.Quantity -= 1;
                    productToRemove.SubTotal = productToRemove.Quantity * productToRemove.Price;

                    // Recalculate VAT if applicable
                    if (productToRemove.IsVat == 1)
                    {
                        productToRemove.VatAmount = Math.Round(productToRemove.SubTotal * 0.12m, 2, MidpointRounding.AwayFromZero);  // 12% VAT
                    }
                }
                else
                {
                    // If quantity is 1, remove the product from the cart
                    displayedProducts.RemoveAt(e.RowIndex);
                    if (displayedProducts.Count == 0)
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                        lblDiscount.Text = 0.ToString("C2");
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                    }
                }

                // Refresh DataGridView after updating
                RefreshDataGridView();
                DisplayTotalAmount();
                DisplayVatSale();
                DisplayVatAmount();
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Discount"].Index)
            {
                var productToDiscount = displayedProducts[e.RowIndex];

                // Fetch discount from the DiscountSelectionForm
                var selectedDiscount = GetSelectedDiscount();

                if (selectedDiscount != null)
                {
                    // Calculate discount amount
                    decimal discountAmount = (selectedDiscount.Percentage / 100m) * productToDiscount.Price;
                    decimal discountedPrice = productToDiscount.Price - discountAmount;

                    // Apply the discounted price
                    productToDiscount.Price = discountedPrice;
                    productToDiscount.SubTotal = productToDiscount.Quantity * discountedPrice;

                    // Recalculate VAT if applicable
                    if (productToDiscount.IsVat == 1)
                    {
                        productToDiscount.VatAmount = Math.Round(productToDiscount.SubTotal * 0.12m, 2, MidpointRounding.AwayFromZero);  // 12% VAT
                    }

                    lblDiscount.Text = discountAmount.ToString("C2"); // Display the discount amount
                }
                else
                {
                    MessageBox.Show("No discount selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Refresh DataGridView after updating
                RefreshDataGridView();
                DisplayTotalAmount();
                DisplayVatSale();
                DisplayVatAmount();
            }
        }

        private Discounts GetSelectedDiscount()
        {
            // Fetch the list of discounts from the database using the existing method
            DataTable discountDataTable = DatabaseHelper.GetAllDiscounts();

            // Check if any discounts were retrieved
            if (discountDataTable == null || discountDataTable.Rows.Count == 0)
            {
                MessageBox.Show("No discounts available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            // Convert DataTable to a list of Discounts
            List<Discounts> discounts = new List<Discounts>();
            foreach (DataRow row in discountDataTable.Rows)
            {
                discounts.Add(new Discounts
                {
                    DiscountId = Convert.ToInt32(row["DiscountId"]),
                    Name = row["Name"].ToString(),
                    Percentage = Convert.ToInt32(row["Percentage"]),
                    Status = Convert.ToInt32(row["Status"]),
                    DateCreated = row["DateCreated"] as DateTime? // Handle possible nulls
                });
            }

            // Create the DiscountSelectionForm and pass the discounts list
            using (var discountForm = new DiscountList(discounts))
            {
                var result = discountForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    return discountForm.SelectedDiscount;
                }
            }

            // If the user cancels or no discount selected, return null
            return null;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            BrowseProduct browse = new BrowseProduct();
            browse.ShowDialog();
        }

        private void cbTransType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTransType.SelectedIndex == 0)
            {
                isRetail = true;
            }
            else
            {
                isRetail = false;
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            var employee = new EmployeeLogin();
            var result = employee.ShowDialog();

            // If the user successfully logged in, set the token
            if (result == DialogResult.OK)
            {

                Token = employee.Token;
                btnEmployee.Enabled = false;
                this.Refresh();
            }
        }
    }
}
