using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POSApp.Class;

namespace POSApp
{
    public partial class BrowseProduct : Form
    {
        public BrowseProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BrowseProduct_Load(object sender, EventArgs e)
        {
            var inventoryData = DatabaseHelper.GetInventory();
            dgvProducts.DataSource = inventoryData;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Get the text from the search box
            string searchText = txtSearch.Text.Trim();

            // Fetch data based on the search text
            DataTable filteredData;

            if (string.IsNullOrEmpty(searchText))
            {
                // If the search box is empty, display all inventory
                filteredData = DatabaseHelper.GetInventory();
            }
            else
            {
                if (cmbKey.SelectedIndex == 0)
                {
                    filteredData = DatabaseHelper.GetFilteredInventoryByName(searchText);
                    // Bind the filtered or full data to the DataGridView
                    dgvProducts.DataSource = null;
                    dgvProducts.DataSource = filteredData;
                }
                else
                {
                    filteredData = DatabaseHelper.GetFilteredInventoryByBarcode(searchText);
                    // Bind the filtered or full data to the DataGridView
                    dgvProducts.DataSource = null;
                    dgvProducts.DataSource = filteredData;
                }

            }

            
        }
    }
}
