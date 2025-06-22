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
using Pharmacy_Management_System.controller;
using System.Data.SqlClient;



namespace Pharmacy_Management_System.view
{
    public partial class productCrude : Form
    {
        public productCrude()
        {
            InitializeComponent();
        }

        public void Display()
        {
            Logins.DisplayAndSearch(
                "SELECT productName, category, price, discount, priceAfterDiscount, stockQuantity, expiryDate, adminName FROM Product",
                dataGridView
            );
        }



        private void btnNew_Click(object sender, EventArgs e)
        {
            ProductDia form = new ProductDia(this);
            form.ShowDialog();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Delete button (Column2)
            if (e.ColumnIndex == dataGridView.Columns["Column2"].Index)
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this product?",
                    "Confirmation",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // Assumes "productName" is one of the visible columns in SELECT query
                    string productName = dataGridView.Rows[e.RowIndex].Cells["productName"].Value.ToString();

                    Products ps = new Products();
                    ps.DeleteProduct(productName);

                    MessageBox.Show("Product deleted successfully!");
                    Display(); // Refresh table
                }
            }

            // Edit button (Column1) – Optional placeholder
            //if (e.ColumnIndex == dataGridView.Columns["Column1"].Index)
            //{
            //    // You can open the ProductDia edit form here later
            //    MessageBox.Show("Edit functionality here (optional)");
            //}
        }



        private void productCrude_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void productCrude_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Logins.DisplayAndSearch("SELECT productName, category, price, discount, priceAfterDiscount, stockQuantity, expiryDate, adminName FROM Product WHERE productName LIKE '%"+txtSearch.Text+"%'",dataGridView);
        }


    }
}
