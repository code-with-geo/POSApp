﻿using Newtonsoft.Json.Linq;
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
    public partial class HoldCustomer : Form
    {
        public List<Cart> _cart { get; private set; }
        public HoldCustomer()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadHoldSale()
        {
            DataTable dt = DatabaseHelper.GetAllHoldSale();
            dgvHoldSale.DataSource = dt;
        }
        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            DatabaseHelper.DeleteAllHoldProduct();
            DatabaseHelper.DeleteAllHoldSale();
            LoadHoldSale();
        }

        private void HoldCustomer_Load(object sender, EventArgs e)
        {
            LoadHoldSale();
            if (!dgvHoldSale.Columns.Contains("Remove"))
            {
                DataGridViewButtonColumn removeButtonColumn = new DataGridViewButtonColumn();
                removeButtonColumn.Name = "Remove";
                removeButtonColumn.HeaderText = "Remove";
                removeButtonColumn.Text = "Remove";
                removeButtonColumn.UseColumnTextForButtonValue = true;
                dgvHoldSale.Columns.Add(removeButtonColumn);
            }

            if (!dgvHoldSale.Columns.Contains("Select"))
            {
                DataGridViewButtonColumn removeButtonColumn = new DataGridViewButtonColumn();
                removeButtonColumn.Name = "Select";
                removeButtonColumn.HeaderText = "Select";
                removeButtonColumn.Text = "Select";
                removeButtonColumn.UseColumnTextForButtonValue = true;
                dgvHoldSale.Columns.Add(removeButtonColumn);
            }
        }

        private void dgvHoldSale_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvHoldSale.Columns["Remove"].Index)
            {
                try
                {
                    // Validate and retrieve the ReferenceId from the first column
                    var value = dgvHoldSale.Rows[e.RowIndex].Cells[0].Value;

                    if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                    {
                        MessageBox.Show("The ReferenceId is invalid or missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Attempt to parse the ReferenceId
                    if (int.TryParse(value.ToString(), out int refId))
                    {
                        // Perform deletion
                        DatabaseHelper.DeleteHoldSaleByRefId(refId);
                        DatabaseHelper.DeleteHoldProductByRefId(refId);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("The ReferenceId is not a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    // Show detailed error information
                    MessageBox.Show($"An error occurred while removing the item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dgvHoldSale.Columns["Select"].Index)
            {
                try
                {
                    // Validate and retrieve the ReferenceId from the first column
                    var value = dgvHoldSale.Rows[e.RowIndex].Cells[0].Value;

                    if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                    {
                        MessageBox.Show("The ReferenceId is invalid or missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Attempt to parse the ReferenceId
                    if (int.TryParse(value.ToString(), out int refId))
                    {
                        _cart = DatabaseHelper.GetAllHoldOrdersByRefId(refId); // Store the token
                        DatabaseHelper.DeleteHoldSaleByRefId(refId);
                        DatabaseHelper.DeleteHoldProductByRefId(refId);
                        LoadHoldSale();
                        this.DialogResult = DialogResult.OK; // Close with success
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("The ReferenceId is not a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    // Show detailed error information
                    MessageBox.Show($"An error occurred while removing the item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
