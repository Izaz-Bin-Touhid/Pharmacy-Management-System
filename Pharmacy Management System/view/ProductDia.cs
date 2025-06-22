using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using Pharmacy_Management_System.model;
using Pharmacy_Management_System.controller;

namespace Pharmacy_Management_System.view
{
    public partial class ProductDia : Form
    {
        private readonly productCrude _product;


        public ProductDia(productCrude product)
        {
            InitializeComponent();
            _product = product;
        }

        public void Clear()
        {
            prtxt.Text = "";
            ctxt.Text = "";
            textBox2.Text = "";
            dtxt.Text = "";
            sqtxt.Text = "";
            extxt.Text = "";
            atxt.Text = "";

             
        }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ProductDia_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (prtxt.Text.Trim().Length < 3)
            {
                MessageBox.Show("Product name must be at least 3 characters long");
                return;
            }

            if (ctxt.Text.Trim().Length < 1)
            {
                MessageBox.Show("Category must be at least 1 character long");
                return;
            }

            if (!float.TryParse(textBox2.Text.Trim(), out float price))
            {
                MessageBox.Show("Price must be a valid number");
                return;
            }

            if (!int.TryParse(dtxt.Text.Trim(), out int discount))
            {
                MessageBox.Show("Discount must be a valid integer");
                return;
            }

            if (!int.TryParse(sqtxt.Text.Trim(), out int stockQuantity))
            {
                MessageBox.Show("Stock quantity must be a valid integer");
                return;
            }

            string expiryDate = extxt.Text.Trim();
            string adminName = atxt.Text.Trim();

            if (expiryDate.Length < 3)
            {
                MessageBox.Show("Expiry date must be at least 3 characters long");
                return;
            }

            if (adminName.Length < 3)
            {
                MessageBox.Show("Admin name must be at least 3 characters long");
                return;
            }

            // If Save mode
            if (btnSave.Text == "Save")
            {
                Product pp = new Product
                {
                    ProductName = prtxt.Text.Trim(),
                    Category = ctxt.Text.Trim(),
                    Price = price,
                    Discount = discount,
                    StockQuantity = stockQuantity,
                    ExpiryDate = expiryDate,
                    AdminName = adminName
                };

                // Insert into database
                Products products = new Products();
                products.AddProduct(pp);

                MessageBox.Show("Product saved successfully!");

                Clear();
            }

            _product.Display();
        }

    }
}
