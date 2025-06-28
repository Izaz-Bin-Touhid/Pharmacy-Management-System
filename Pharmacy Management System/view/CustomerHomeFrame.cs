using Pharmacy_Management_System.controller;
using Pharmacy_Management_System.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_Management_System.view
{
    public partial class CustomerHomeFrame : Form
    {
        public CustomerHomeFrame()
        {
            InitializeComponent();
        }

        public void Display()
        {
            Logins.DisplayAndSearch(
                "SELECT productName, category, price, discount, priceAfterDiscount, stockQuantity, expiryDate FROM Product",
                dataGridView
            );
        }
        private void CustomerHomeFrame_Load(object sender, EventArgs e)
        {

        }

        private void CustomerHomeFrame_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void productnametextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pricetextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void quantitytextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Make sure the click is on a row, not on the header
            {
                DataGridViewRow selectedRow = dataGridView.Rows[e.RowIndex];

                // Load product name
                productnametextbox.Text = selectedRow.Cells["productName"].Value?.ToString() ?? "N/A";

                // 👉 Load price after discount instead of original price
                pricetextbox.Text = selectedRow.Cells["priceAfterDiscount"].Value?.ToString() ?? "0";

                // Quantity should always be 0 initially
                quantitytextbox.Text = "0";
            }
        }




        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                productnametextbox.Text = selectedRow.Cells["productName"].Value?.ToString() ?? "N/A";

                // 👉 Load price after discount instead of original price
                pricetextbox.Text = selectedRow.Cells["priceAfterDiscount"].Value?.ToString() ?? "0";

                quantitytextbox.Text = "0";
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                CartItem item = new CartItem
                {
                    CartSerial = Guid.NewGuid().ToString(), // Or any logic
                    ProductName = productnametextbox.Text.Trim(),
                    PriceAfterDiscount = float.Parse(pricetextbox.Text.Trim()),
                    Quantity = int.Parse(quantitytextbox.Text.Trim())
                };
                item.Total = item.PriceAfterDiscount * item.Quantity;

                // Add to database
                CartController cartController = new CartController();
                cartController.AddCartItem(item);

                // Show new form
                CartSummaryForm summaryForm = new CartSummaryForm();
                summaryForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding to cart: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CartSummaryForm cs = new CartSummaryForm();
            cs.Show();
        }
    }
}


