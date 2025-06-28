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
    public partial class productUp : Form
    {
        public productUp()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void productUp_Load(object sender, EventArgs e)
        {

        }

        
        

        //product update button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Step 1: All fields empty check
            if (string.IsNullOrWhiteSpace(prtxt.Text) &&
                string.IsNullOrWhiteSpace(ctxt.Text) &&
                string.IsNullOrWhiteSpace(textBox2.Text) &&
                string.IsNullOrWhiteSpace(dtxt.Text) &&
                string.IsNullOrWhiteSpace(sqtxt.Text) &&
                string.IsNullOrWhiteSpace(extxt.Text) &&
                string.IsNullOrWhiteSpace(atxt.Text))
            {
                MessageBox.Show("Please input all data", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Step 2: Individual field checks
            if (string.IsNullOrWhiteSpace(prtxt.Text))
            {
                MessageBox.Show("Please enter Product Name");
                return;
            }

            if (string.IsNullOrWhiteSpace(ctxt.Text))
            {
                MessageBox.Show("Please enter Category");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter Price");
                return;
            }

            if (string.IsNullOrWhiteSpace(dtxt.Text))
            {
                MessageBox.Show("Please enter Discount");
                return;
            }

            if (string.IsNullOrWhiteSpace(sqtxt.Text))
            {
                MessageBox.Show("Please enter Stock Quantity");
                return;
            }

            if (string.IsNullOrWhiteSpace(sqtxt.Text))
            {
                MessageBox.Show("Please enter Expiry Date");
                return;
            }

            if (string.IsNullOrWhiteSpace(atxt.Text))
            {
                MessageBox.Show("Please enter Admin Name");
                return;
            }

            // Step 3: Try to convert values
            if (!float.TryParse(prtxt.Text, out float price))
            {
                MessageBox.Show("Invalid price value");
                return;
            }

            if (!int.TryParse(dtxt.Text, out int discount))
            {
                MessageBox.Show("Invalid discount value");
                return;
            }

            if (!int.TryParse(sqtxt.Text, out int quantity))
            {
                MessageBox.Show("Invalid stock quantity");
                return;
            }

            if (!DateTime.TryParse(extxt.Text, out DateTime expiry))
            {
                MessageBox.Show("Invalid expiry date format");
                return;
            }

            // Step 4: Create Product and Update
            Product p = new Product
            {
                ProductName = prtxt.Text.Trim(),
                Category = ctxt.Text.Trim(),
                Price = price,
                Discount = discount,
                StockQuantity = quantity,
                ExpiryDate = expiry.ToString("yyyy-MM-dd"),
                AdminName = atxt.Text.Trim()
            };

            Products ps = new Products();
            ps.UpdateProduct(p);

            MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Optional: Close the update form
        }


    }
}

