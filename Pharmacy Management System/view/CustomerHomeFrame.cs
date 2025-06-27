using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Pharmacy_Management_System.model;
using Pharmacy_Management_System.controller;

namespace Pharmacy_Management_System.view
{
    public partial class CustomerHomeFrame : Form
    {
        Login login;


        private List<Product> allProducts = new List<Product>(); // To store all products

        public CustomerHomeFrame(Login login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void CustomerHomeFrame_Load(object sender, EventArgs e)
        {
            ProductController productController = new ProductController();
            allProducts = productController.GetAllProducts();
            dataGridView1.DataSource = ConvertToDataTable(allProducts);

            // Set the selection mode to FullRowSelect
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private DataTable ConvertToDataTable(List<Product> products)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Product Name");
            dt.Columns.Add("Category");
            dt.Columns.Add("Price");
            dt.Columns.Add("Discount");
            dt.Columns.Add("Price After Discount");
            dt.Columns.Add("Stock Quantity");
            dt.Columns.Add("Expiry Date");

            foreach (var product in products)
            {
                DataRow row = dt.NewRow();
                row["Product Name"] = product.ProductName;
                row["Category"] = product.Category;
                row["Price"] = product.Price;
                row["Discount"] = product.Discount;
                row["Price After Discount"] = product.PriceAfterDiscount;
                row["Stock Quantity"] = product.StockQuantity;
                row["Expiry Date"] = product.ExpiryDate;
                dt.Rows.Add(row);
            }

            return dt;
        }

        // This will trigger when the selection changes in the DataGridView
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Ensure there's a valid row selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Populate the text boxes with the selected row's data
                textBoxProductName.Text = selectedRow.Cells["Product Name"].Value?.ToString() ?? "N/A"; // Default "N/A" if null
                textBoxPrice.Text = selectedRow.Cells["Price"].Value?.ToString() ?? "0"; // Default "0" if null
                textBoxQuantity.Text = "0"; // Default quantity set to 0

                // Store the maximum quantity (stock quantity) for validation
                int stockQuantity = Convert.ToInt32(selectedRow.Cells["Stock Quantity"].Value);
                textBoxQuantity.Tag = stockQuantity; // Store stock quantity in Tag for later use
            }
        }

        // This method will handle the Quantity validation
        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxQuantity.Text, out int quantity))
            {
                // Retrieve the maximum available quantity (from the database)
                int maxQuantity = (int)textBoxQuantity.Tag;

                // Validate the quantity
                if (quantity < 0 || quantity > maxQuantity)
                {
                    MessageBox.Show($"Invalid quantity! Enter a value between 0 and {maxQuantity}.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxQuantity.Text = "0"; // Reset to 0 if invalid
                }
            }
            else
            {
                // Reset the quantity if the input is not a valid number
                textBoxQuantity.Text = "0";
            }
        }

        private void buttonAddToCart_Click(object sender, EventArgs e)
        {
            // Validate that necessary fields are filled
            if (string.IsNullOrEmpty(textBoxProductName.Text) || string.IsNullOrEmpty(textBoxQuantity.Text) || string.IsNullOrEmpty(textBoxPrice.Text) || textBoxQuantity.Text == "0")
            {
                MessageBox.Show("Please fill in the product name, valid quantity, and price.");
                return;
            }

            string productName = textBoxProductName.Text;
            double price = Convert.ToDouble(textBoxPrice.Text);
            int quantity = Convert.ToInt32(textBoxQuantity.Text);

            // Calculate total price
            double total = price * quantity;




            // Show success message
            MessageBox.Show($"{productName}Order Confirmd. Total: {total}");

            // Clear text fields after successful addition
            textBoxProductName.Clear();
            textBoxPrice.Clear();
            textBoxQuantity.Clear();
        }

        // Search functionality for Product Name
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = textBoxSearch.Text.ToLower(); // Convert to lowercase for case-insensitive search

            // Filter the products list based on the search query
            var filteredProducts = allProducts.Where(p => p.ProductName.ToLower().Contains(searchQuery)).ToList();

            // Update the DataGridView to show the filtered products
            dataGridView1.DataSource = ConvertToDataTable(filteredProducts);
        }

        private void button5_Click(object sender, EventArgs e)
        {





        }
    }


}
