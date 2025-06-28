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

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Column name match kore check korchi
            if (dataGridView.Columns[e.ColumnIndex].HeaderText == "CheckDate")
            {
                string productName = dataGridView.Rows[e.RowIndex].Cells["productName"].Value.ToString();

                ExpireEmplos checker = new ExpireEmplos();
                string status = checker.CheckExpireDate(productName);
                bool isExpired = (status == "Expired");

                ExpireDia dialog = new ExpireDia(productName, isExpired);
                dialog.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExpireEmplo_Load(object sender, EventArgs e)
        {

        }
    }
}
