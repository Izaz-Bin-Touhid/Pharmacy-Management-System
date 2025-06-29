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
using System.Data.SqlClient;

namespace Pharmacy_Management_System.view
{
    public partial class CartSummaryForm : Form
    {
        public CartSummaryForm()
        {
            InitializeComponent();
        }



        public void Display()
        {
            // Using the DisplayAndSearch method to show the cart data in DataGridView
            Cart.DisplayAndSearch(
                "SELECT cartSerial, productName, priceAfterDiscount, quantity, total FROM cartTable ",
                dataGridView // Make sure dataGridView is the actual DataGridView control in your form
            );
        }

        


        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CartSummaryForm_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void CartSummaryForm_Load(object sender, EventArgs e)
        {

        }

        private void CartSummaryForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
