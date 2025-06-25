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
    public partial class ExpireEmplo : Form
    {
        public ExpireEmplo()
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

        private void ExpireEmplo_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Logins.DisplayAndSearch(
                "SELECT productName, category, price, discount, priceAfterDiscount, stockQuantity, expiryDate, adminName FROM Product WHERE productName Like '%"+ txtSearch.Text +"%'",
                dataGridView
            );

        }
    }
}
