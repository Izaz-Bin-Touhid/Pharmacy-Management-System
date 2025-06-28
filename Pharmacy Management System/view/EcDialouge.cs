using System;
using System.Drawing;
using System.Windows.Forms;
using Pharmacy_Management_System.model;
using Pharmacy_Management_System.controller;

namespace Pharmacy_Management_System.view
{
    public partial class EcDialouge : Form
    {
        private readonly EcCrude _ec;

        public EcDialouge(EcCrude ec)
        {
            InitializeComponent();
            _ec = ec;
        }

        public void Clear()
        {
            textBox1.Enabled = true;
            textBox1.Text = textBox3.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            btnSave.Text = "Save";
        }

        // Set data for Edit
        public void SetData(string userName, string password, string role)
        {
            textBox1.Text = userName;
            textBox1.Enabled = false; // username is primary key, prevent changing
            textBox3.Text = password;

            if (role == "Employee")
                radioButton1.Checked = true;
            else if (role == "Customer")
                radioButton2.Checked = true;

            btnSave.Text = "Update";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length < 3)
            {
                MessageBox.Show("Name must be greater than 3 characters");
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
            string userName = textBox1.Text.Trim();
            string password = textBox3.Text.Trim();

            Login login = new Login(userName, password, role); // Create the object

            Logins logins = new Logins();

            if (btnSave.Text == "Save")
            {
                logins.AddLogin(login);
                MessageBox.Show("Added successfully!");
            }
            else if (btnSave.Text == "Update")
            {
                logins.UpdateLogin(login);
                MessageBox.Show("Updated successfully!");
            }

            _ec.Display();
            this.Close(); // Close after save/update
        }


        private void EcDialouge_Load(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.White;
            btnSave.ForeColor = Color.FromArgb(2, 0, 121);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.FromArgb(2, 0, 121);
            btnSave.ForeColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close(); // Exit button
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Optional UI Paint
        }
    }
}
