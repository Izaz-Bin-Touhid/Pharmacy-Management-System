using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacy_Management_System.model;
using Pharmacy_Management_System.controller;
using System.Data.SqlClient;
using System.Data;

namespace Pharmacy_Management_System.view
{
    public partial class EcCrude : Form
    {
        
        public EcCrude()
        {
            InitializeComponent();
        }

        public void Display()
        {
            Logins.DisplayAndSearch("SELECT userName, password, role FROM Login WHERE userName LIKE '%" + txtSearch.Text + "%'", dataGridView);
        }

        


        private void button1_Click(object sender, EventArgs e)
        {
            EcDialouge dialogue = new EcDialouge(this);
            dialogue.Show();
        }

        private void EcCrude_Load(object sender, EventArgs e)
        {

        }

        private void EcCrude_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Logins.DisplayAndSearch("SELECT userName, password, role FROM Login WHERE userName LIKE '%" + txtSearch.Text + "%'", dataGridView);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Edit
            if (e.ColumnIndex == 0)
            {
                // Edit
                return;
            }


            if (e.ColumnIndex == 1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    string userName = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();

                    Logins lgs = new Logins();
                    lgs.DeleteLogin(userName);

                    MessageBox.Show("Deleted successfully!");

                    Display();
                }
                return;
            }
        }


        private void btnNew_MouseEnter(object sender, EventArgs e)
        {
            btnNew.BackColor = Color.White;
            btnNew.ForeColor = Color.FromArgb(2, 0, 121);

        }

        private void btnNew_MouseLeave(object sender, EventArgs e)
        {
            btnNew.BackColor = Color.FromArgb(2, 0, 121);
            btnNew.ForeColor = Color.White;

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
