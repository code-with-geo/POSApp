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

namespace POSApp
{
    public partial class Main : Form
    {
        private List<Cart> displayedProducts = new List<Cart>();
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
            browse.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customers customer = new Customers();
            customer.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Fetch data and bind to DataGridView
            //var inventoryData = DatabaseHelper.GetInventory();
            // dataGridView1.DataSource = inventoryData;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DatabaseHelper.CreateDatabase();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            string apiUrl = "https://localhost:7148/api/products";
            string apiUrl2 = "https://localhost:7148/api/locations";
            string apiUrl3 = "https://localhost:7148/api/category";
            string apiUrl4 = "https://localhost:7148/api/inventory";
            string authToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZG1pbiIsImp0aSI6ImRjOGVjOWIzLTg1MzMtNGI4MC1iNzQ0LWJjODgwZGUxY2Q5NyIsImV4cCI6MTczNjI1MjU2OSwiaXNzIjoiSnd0QXV0aEFwaSIsImF1ZCI6Ikp3dEF1dGhBcGlVc2VycyJ9.UYBAsidHf4Wm9tHkC3xDp5Rf-zGoKhZGGnNexpN6vKw"; // Replace with your token

            await DatabaseHelper.SyncProducts(apiUrl, authToken);
            await DatabaseHelper.SyncLocations(apiUrl2, authToken);
            await DatabaseHelper.SyncCategory(apiUrl3, authToken);
            await DatabaseHelper.SyncInventory(apiUrl4, authToken);
        }

        private void AddProductToCart()
        {
            if (int.TryParse(txtBarcode.Text, out int productId))
            {
                // Check if the product already exists in displayedProducts
                var existingProduct = displayedProducts.FirstOrDefault(p => p.Id == productId);

                if (existingProduct != null)
                {
                    // Increment quantity if product already exists
                    existingProduct.Quantity += 1;

                    // Update SubTotal
                    existingProduct.SubTotal = existingProduct.Quantity * existingProduct.RetailPrice;

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

                    MessageBox.Show($"Product {productId} already exists. Quantity increased to {existingProduct.Quantity}.");
                }
                else
                {
                    // Fetch product from the database
                    var product = DatabaseHelper.GetProductById(productId);

                    if (product != null)
                    {
                        // Calculate VAT if applicable
                        decimal vatAmount = 0;
                        if (product.IsVat == 1)
                        {
                            vatAmount = product.RetailPrice * 0.12m; // 12% VAT
                        }

                        // Add the product to the cart
                        displayedProducts.Add(new Cart
                        {
                            Id = product.Id,
                            Barcode = product.Barcode,
                            Name = product.Name,
                            Description = product.Description,
                            RetailPrice = product.RetailPrice,
                            Quantity = 1, // Initial quantity is 1
                            SubTotal = product.RetailPrice, // SubTotal = RetailPrice * Quantity
                            VatAmount = vatAmount, // Add VAT amount to the cart
                            IsVat = product.IsVat
                        });

                        // Refresh DataGridView to display the updated cart
                        RefreshDataGridView();
                        DisplayTotalAmount();
                        DisplayVatSale();
                        DisplayVatAmount();

                        MessageBox.Show($"Product {productId} added with quantity 1.");
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
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // Add columns and bind to properties
            dataGridView1.Columns.Add("Barcode", "Barcode");
            dataGridView1.Columns["Barcode"].DataPropertyName = "Barcode";

            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns["Name"].DataPropertyName = "Name";

            dataGridView1.Columns.Add("Description", "Description");
            dataGridView1.Columns["Description"].DataPropertyName = "Description";

            dataGridView1.Columns.Add("RetailPrice", "Retail Price");
            dataGridView1.Columns["RetailPrice"].DataPropertyName = "RetailPrice";

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

            // Bind the displayedProducts list to the DataGridView
            dataGridView1.DataSource = null;  // Clear previous binding
            dataGridView1.DataSource = displayedProducts;

            // Format columns for currency
            dataGridView1.Columns["RetailPrice"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["SubTotal"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["VatAmount"].DefaultCellStyle.Format = "C2";
            // Align numeric columns
            dataGridView1.Columns["RetailPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

        private void button6_Click(object sender, EventArgs e)
        {
            // Get the productId from the TextBox

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
                    productToRemove.SubTotal = productToRemove.Quantity * productToRemove.RetailPrice;

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
                }

                // Refresh DataGridView after updating
                RefreshDataGridView();
                DisplayTotalAmount();
                DisplayVatSale();
                DisplayVatAmount();
            }
        }
    }
}
