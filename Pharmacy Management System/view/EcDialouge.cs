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

namespace Pharmacy_Management_System.view
{
    public partial class EcDialouge : Form
    {
        //Tex=st
        private readonly EcCrude _ec;


        public EcDialouge(EcCrude ec)
        {
            InitializeComponent();
            _ec = ec;
        }

        public void Clear()
        {
            textBox1.Text = textBox3.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length < 3)
            {
                MessageBox.Show("Name must be grater than 3 character");
                return;
            }

            if (textBox3.Text.Trim().Length < 1)
            {
                MessageBox.Show("Password must be greater than 1 character");
                return;
            }

            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Please select a role.");
                return;
            }

            string role = radioButton1.Checked ? "Employee" : "Customer";

            if (btnSave.Text == "Save")
            {
                Login login = new Login(textBox1.Text.Trim(), textBox3.Text.Trim(), role);
                Logins logins = new Logins();
                logins.AddLogin(login);
                Clear();
            }
            _ec.Display();



        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void EcDialouge_Load(object sender, EventArgs e)
        {

        }
    }
}
