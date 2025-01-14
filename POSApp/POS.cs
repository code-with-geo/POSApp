using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
using POSApp.Class;
namespace POSApp
{
    public partial class POS : Form
    {
        private List<Cart> cart = new List<Cart>();
        private List<Inventory> inventoryList = new List<Inventory>();
        private static readonly string FolderPath = @"C:\POS";
        private static readonly string DbPath = Path.Combine(FolderPath, "POS.sqlite");
        private static bool isRetail = true;
        public string Token { get; private set; }
        public int UserId { get; private set; }
        public POS()
        {
            InitializeComponent();
        }

        private void RefreshDataGridView()
        {
            //DataGridView Properties
            dgvCart.ColumnHeadersVisible = true;
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();
            // Add columns and bind to properties
            // Add Barcode column to DataGridView
            dgvCart.Columns.Add("Barcode", "Barcode");
            dgvCart.Columns["Barcode"].DataPropertyName = "Barcode";
            // Add Name column to DataGridView
            dgvCart.Columns.Add("Name", "Name");
            dgvCart.Columns["Name"].DataPropertyName = "Name";
            // Add Description column to DataGridView
            dgvCart.Columns.Add("Description", "Description");
            dgvCart.Columns["Description"].DataPropertyName = "Description";
            // Add Price column to DataGridView
            dgvCart.Columns.Add("Price", "Price");
            dgvCart.Columns["Price"].DataPropertyName = "Price";
            // Add Quantity column to DataGridView
            dgvCart.Columns.Add("Quantity", "Quantity");
            dgvCart.Columns["Quantity"].DataPropertyName = "Quantity";
            // Add SubTotal column to DataGridView
            dgvCart.Columns.Add("SubTotal", "Sub Total");
            dgvCart.Columns["SubTotal"].DataPropertyName = "SubTotal";
            // Add VatAmount column to DataGridView
            dgvCart.Columns.Add("VatAmount", "VAT Amount");
            dgvCart.Columns["VatAmount"].DataPropertyName = "VatAmount";
            // Add AppliedDiscount column to DataGridView
            dgvCart.Columns.Add("AppliedDiscount", "Applied Discount");
            dgvCart.Columns["AppliedDiscount"].DataPropertyName = "AppliedDiscount";
            // Add TotalDiscount column to DataGridView
            dgvCart.Columns.Add("TotalDiscount", "Total Discount");
            dgvCart.Columns["TotalDiscount"].DataPropertyName = "TotalDiscount";

            // Add Remove button column
            DataGridViewButtonColumn removeButtonColumn = new DataGridViewButtonColumn();
            removeButtonColumn.Name = "Remove";
            removeButtonColumn.HeaderText = "Remove";
            removeButtonColumn.Text = "Remove";
            removeButtonColumn.UseColumnTextForButtonValue = true;
            dgvCart.Columns.Add(removeButtonColumn);

            // Add Discount column to DataGridView
            DataGridViewButtonColumn discountColumn = new DataGridViewButtonColumn();
            discountColumn.Name = "Discount";
            discountColumn.HeaderText = "Apply Discount";
            discountColumn.Text = "Apply";
            discountColumn.UseColumnTextForButtonValue = true;
            dgvCart.Columns.Add(discountColumn);

            // Bind the displayedProducts list to the DataGridView
            dgvCart.DataSource = null;  // Clear previous binding
            dgvCart.DataSource = cart;

            // Format columns for currency
            dgvCart.Columns["Price"].DefaultCellStyle.Format = "C2";
            dgvCart.Columns["SubTotal"].DefaultCellStyle.Format = "C2";
            dgvCart.Columns["VatAmount"].DefaultCellStyle.Format = "C2";
            dgvCart.Columns["AppliedDiscount"].DefaultCellStyle.Format = "C2";
            dgvCart.Columns["TotalDiscount"].DefaultCellStyle.Format = "C2";
            // Set readonly for certain columns
            dgvCart.Columns["Price"].ReadOnly = true;
            dgvCart.Columns["SubTotal"].ReadOnly = true;
            dgvCart.Columns["VatAmount"].ReadOnly = true;
            dgvCart.Columns["AppliedDiscount"].ReadOnly = true;
            dgvCart.Columns["TotalDiscount"].ReadOnly = true;
        }

        private void DisplayTotalAmount()
        {
            decimal totalSubTotal = cart.Sum(p => p.SubTotal);
            lblTotalAmount.Text = totalSubTotal.ToString("C2");
            lblTopTotalAmount.Text = totalSubTotal.ToString("C2");
        }

        private void DisplayVatSale()
        {
            decimal vatInclusiveTotal = cart.Where(p => p.IsVat == 1).Sum(p => p.SubTotal);
            lblVatSale.Text = vatInclusiveTotal.ToString("C2");
        }

        private void DisplayVatAmount()
        {
            decimal VatAmount = cart.Sum(p => p.VatAmount);
            lblVatAmount.Text = VatAmount.ToString("C2");
        }

        private void DisplayVatExempt()
        {
            decimal VatExempt = cart.Where(p => p.IsVat == 0).Sum(p => p.SubTotal);
            lblVatExempt.Text = VatExempt.ToString("C2");
        }

        private void DisplayTotalDiscount()
        {
            decimal TotalDiscount = cart.Where(d => d.HasDiscountApplied == true).Sum(d => d.TotalDiscount);
            lblDiscount.Text = TotalDiscount.ToString("C2");
        }

        private void AddProductToCart()
        {
            if (int.TryParse(txtSearch.Text, out int productId))
            {
                // Fetch the product inventory details
                var inventory = inventoryList.FirstOrDefault(i => i.ProductId == productId && i.LocationId == 1);

                if (inventory == null)
                {
                    MessageBox.Show($"No inventory found for Product ID {productId} at this location.", "Inventory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if the product already exists in displayedProducts
                var existingProduct = cart.FirstOrDefault(p => p.Id == productId);

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

                    // Recompute the discount if applied
                    if (existingProduct.HasDiscountApplied)
                    {
                        decimal discountPercentage = existingProduct.DiscountPercentage; // Get the previously applied discount percentage
                        existingProduct.TotalDiscount = existingProduct.AppliedDiscount * existingProduct.Quantity;  // Compute discount for the new SubTotal
                    }

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
                    DisplayVatExempt();
                    DisplayTotalDiscount();
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

                        decimal discountAmount = 0;

                        // Add the product to the cart
                        cart.Add(new Cart
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

                        if (cart.Count == 0)
                        {
                            dgvCart.Visible = false;
                        }
                        else
                        {
                            dgvCart.Visible = true;
                        }
                        // Refresh DataGridView to display the updated cart
                        RefreshDataGridView();
                        DisplayTotalAmount();
                        DisplayVatSale();
                        DisplayVatAmount();
                        DisplayVatExempt();
                        DisplayTotalDiscount();

                    }
                    else
                    {
                        // If no product is found in the database
                        MessageBox.Show($"Product with ID {productId} not found in the database.");
                    }
                }

                txtSearch.Clear(); // Clear input for the next product
            }
            else
            {
                MessageBox.Show("Please enter a valid product ID.");
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddProductToCart();
                if (cart.Count == 0)
                {
                    dgvCart.Visible = false;
                }
                else
                {
                    dgvCart.Visible = true;
                }
                e.SuppressKeyPress = true;
            }
        }

        private async void POS_Load(object sender, EventArgs e)
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
                            UserId = employee.UserId;
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
                            inventoryList = DatabaseHelper.LoadInventoryList();
                            this.Refresh();
                        }
                    }
                }
            }
            else
            {
                inventoryList = DatabaseHelper.LoadInventoryList();
            }
        }

        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click is on the "Remove" button column
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvCart.Columns["Remove"].Index)
            {
                var productToRemove = cart[e.RowIndex];

                // If quantity is greater than 1, decrease the quantity
                if (productToRemove.Quantity > 1)
                {
                    productToRemove.Quantity -= 1;
                    productToRemove.SubTotal = productToRemove.Quantity * productToRemove.Price;

                    // Recompute the discount if applied
                    if (productToRemove.HasDiscountApplied)
                    {
                        productToRemove.TotalDiscount = productToRemove.TotalDiscount - productToRemove.AppliedDiscount; // Remove the discount for the previous quantity
                    }

                    // Recalculate VAT if applicable
                    if (productToRemove.IsVat == 1)
                    {
                        productToRemove.VatAmount = Math.Round(productToRemove.SubTotal * 0.12m, 2, MidpointRounding.AwayFromZero);  // 12% VAT
                    }
                }
                else
                {
                    // If quantity is 1, remove the product from the cart
                    cart.RemoveAt(e.RowIndex);
                    if (cart.Count == 0)
                    {
                        dgvCart.ColumnHeadersVisible = false;

                    }
                    else
                    {
                        dgvCart.ColumnHeadersVisible = true;
                    }
                }

                if (cart.Count == 0)
                {
                    dgvCart.Visible = false;
                }
                else
                {
                    dgvCart.Visible = true;
                }
                // Refresh DataGridView after updating
                RefreshDataGridView();
                DisplayTotalAmount();
                DisplayVatSale();
                DisplayVatAmount();
                DisplayVatExempt();
                DisplayTotalDiscount();
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dgvCart.Columns["Discount"].Index)
            {
                var productToDiscount = cart[e.RowIndex];

                // Check if the product already has a discount applied
                if (productToDiscount.HasDiscountApplied) // Assuming you have a property for this
                {
                    MessageBox.Show("This product already has a discount applied.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit early if a discount is already applied
                }

                // Fetch discount from the DiscountSelectionForm
                var selectedDiscount = GetSelectedDiscount();

                if (selectedDiscount != null)
                {
                    // Calculate discount amount
                    decimal discountAmount = (selectedDiscount.Percentage / 100m) * productToDiscount.Price;
                    decimal discountedPrice = productToDiscount.Price - discountAmount;
                    decimal totalDiscount = discountedPrice * (selectedDiscount.Percentage / 100m);
                    // Apply the discounted price
                    productToDiscount.DiscountId = selectedDiscount.DiscountId;
                    productToDiscount.Price = discountedPrice;
                    productToDiscount.SubTotal = productToDiscount.Quantity * discountedPrice;
                    productToDiscount.HasDiscountApplied = true; // Mark that a discount has been applied
                    productToDiscount.DiscountPercentage = selectedDiscount.Percentage;
                    productToDiscount.AppliedDiscount = discountAmount;
                    productToDiscount.TotalDiscount = discountAmount * productToDiscount.Quantity;
                    // Recalculate VAT if applicable
                    if (productToDiscount.IsVat == 1)
                    {
                        productToDiscount.VatAmount = Math.Round(productToDiscount.SubTotal * 0.12m, 2, MidpointRounding.AwayFromZero);  // 12% VAT
                    }

                }
                else
                {
                    MessageBox.Show("No discount selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (cart.Count == 0)
                {
                    dgvCart.Visible = false;
                }
                else
                {
                    dgvCart.Visible = true;
                }

                // Refresh DataGridView after updating
                RefreshDataGridView();
                DisplayTotalAmount();
                DisplayVatSale();
                DisplayVatAmount();
                DisplayVatExempt();
                DisplayTotalDiscount();
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

        private void RefreshForm()
        {
            cart.Clear();
            if (cart.Count == 0)
            {
                dgvCart.Visible = false;
            }
            else
            {
                dgvCart.Visible = true;
            }
            DisplayTotalAmount();
            DisplayVatSale();
            DisplayVatAmount();
            DisplayVatExempt();
            DisplayTotalDiscount();
            inventoryList = DatabaseHelper.LoadInventoryList();
        }

        private void btnEmptyCart_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void cmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTransactionType.SelectedIndex == 0)
            {
                isRetail = true;
                RefreshForm();
            }
            else
            {
                isRetail = false;
                RefreshForm();
            }
        }

        private void btnBrowseProduct_Click(object sender, EventArgs e)
        {
            BrowseProduct browse = new BrowseProduct();
            browse.ShowDialog();
        }

        private void btnHoldCustomer_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                var hold = new HoldCustomer();
                var result = hold.ShowDialog();

                // If the user successfully logged in, set the token
                if (result == DialogResult.OK)
                {

                    cart = hold._cart;
                    RefreshDataGridView();
                    DisplayTotalAmount();
                    DisplayVatSale();
                    DisplayVatAmount();
                    DisplayVatExempt();
                    DisplayTotalDiscount();
                    dgvCart.Visible = true;
                    this.Refresh();
                }
            }
            else
            {
                Random random = new Random();
                int refId = random.Next(1000000000, int.MaxValue);
                DatabaseHelper.SaveHoldProducts(cart, refId);
                DatabaseHelper.SaveHoldSale(refId, 1);
                RefreshForm();
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

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            var employee = new EmployeeLogin();
            var result = employee.ShowDialog();

            // If the user successfully logged in, set the token
            if (result == DialogResult.OK)
            {
                UserId = employee.UserId;
                Token = employee.Token;
                btnEmployee.Enabled = false;
                this.Refresh();
            }
        }

        private async void btnSettlePayment_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("No items in the cart.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var customer = new Customers(cart, Token, UserId);
            var result = customer.ShowDialog();

            // If the user successfully logged in, set the token
            if (result == DialogResult.OK)
            {
                cart.Clear();
                dgvCart.DataSource = null;
                dgvCart.ColumnHeadersVisible = false;
                RefreshDataGridView();
                DisplayTotalAmount();
                DisplayVatSale();
                DisplayVatAmount();
                DisplayTotalDiscount();
                lblDiscount.Text = 0.ToString("C2");
                string apiUrl = "https://localhost:7148/api/inventory";
                await DatabaseHelper.SyncInventory(apiUrl, Token);
                inventoryList = DatabaseHelper.LoadInventoryList();
            }
        }

        private void btnCashDrawer_Click(object sender, EventArgs e)
        {
            CashDrawer drawer = new CashDrawer();
            drawer.ShowDialog();
        }

        private void btnXReading_Click(object sender, EventArgs e)
        {
            MessageBox.Show(UserId.ToString());
        }
    }
}
