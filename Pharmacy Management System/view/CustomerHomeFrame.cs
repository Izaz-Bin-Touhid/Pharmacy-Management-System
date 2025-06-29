using Pharmacy_Management_System.controller;
using Pharmacy_Management_System.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pharmacy_Management_System.view
{
    public partial class CustomerHomeFrame : Form
    {
        public CustomerHomeFrame()
        {
            InitializeComponent();
        }

        // Method to display products
        public void Display()
        {
            Logins.DisplayAndSearch(
                "SELECT productName, category, price, discount, priceAfterDiscount, stockQuantity, expiryDate FROM Product",
                dataGridView
            );
        }

        // This method is triggered when the form loads
        private void CustomerHomeFrame_Load(object sender, EventArgs e)
        {
            // Optionally load data or perform actions on load.
        }

        // This method is triggered when the form is shown
        private void CustomerHomeFrame_Shown(object sender, EventArgs e)
        {
            Display();
        }

        // This method is triggered when text is changed in the product name textbox
        private void productnametextbox_TextChanged(object sender, EventArgs e)
        {

        }

        // This method is triggered when text is changed in the price textbox
        private void pricetextbox_TextChanged(object sender, EventArgs e)
        {

        }

        // This method is triggered when text is changed in the quantity textbox
        private void quantitytextbox_TextChanged(object sender, EventArgs e)
        {

        }

        // This method handles when a user clicks a cell in the DataGridView
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure it's a valid row selection
            {
                DataGridViewRow selectedRow = dataGridView.Rows[e.RowIndex];

                // Load product details into textboxes
                productnametextbox.Text = selectedRow.Cells["productName"].Value?.ToString() ?? "N/A";
                pricetextbox.Text = selectedRow.Cells["priceAfterDiscount"].Value?.ToString() ?? "0";

                // Set the initial quantity as 0
                quantitytextbox.Text = "0";
            }
        }

        // This method handles when the selection changes in the DataGridView
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                // Load product details into textboxes
                productnametextbox.Text = selectedRow.Cells["productName"].Value?.ToString() ?? "N/A";
                pricetextbox.Text = selectedRow.Cells["priceAfterDiscount"].Value?.ToString() ?? "0";

                // Set the initial quantity as 0
                quantitytextbox.Text = "0";
            }
        }

        // This method handles the 'Add to Cart' button click event
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected from the DataGridView
                if (dataGridView.CurrentRow == null)
                {
                    MessageBox.Show("Please select a product from the grid before adding to the cart.");
                    return;  // Prevent further processing if no row is selected
                }

                // Get the selected row data from the DataGridView
                DataGridViewRow selectedRow = dataGridView.CurrentRow;

                // Get the product details from the selected row
                string productName = selectedRow.Cells["productName"].Value?.ToString();
                float priceAfterDiscount = float.Parse(selectedRow.Cells["priceAfterDiscount"].Value?.ToString() ?? "0");

                // Get the stock quantity from the selected row
                int stockQuantity = int.Parse(selectedRow.Cells["stockQuantity"].Value?.ToString());

                // Check if the stock quantity is 0
                if (stockQuantity == 0)
                {
                    MessageBox.Show("This product is out of stock.");
                    quantitytextbox.Enabled = false;  // Disable quantity input if stock is 0
                    return; // Don't allow adding to the cart if stock is 0
                }
                else
                {
                    quantitytextbox.Enabled = true; // Enable quantity textbox if stock is available
                }

                // Get the quantity entered by the user
                int quantity = int.Parse(quantitytextbox.Text.Trim());

                // Ensure quantity doesn't exceed available stock
                if (quantity > stockQuantity)
                {
                    MessageBox.Show("Quantity cannot exceed available stock.");
                    return;  // Don't proceed if quantity exceeds stock
                }

                // Calculate the total price for the item
                float total = priceAfterDiscount * quantity;

                // Create a CartItem object
                CartItem item = new CartItem
                {
                    CartSerial = Guid.NewGuid().ToString(),  // Generate a unique serial for the cart item
                    ProductName = productName,
                    PriceAfterDiscount = priceAfterDiscount,
                    Quantity = quantity,
                    Total = total
                };

                // Add the item to the cart
                CartController cartController = new CartController();
                cartController.AddCartItem(item);

                // Show the CartSummaryForm to display the updated cart
                CartSummaryForm summaryForm = new CartSummaryForm();
                summaryForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding to cart: " + ex.Message);
            }
        }
    }
}

