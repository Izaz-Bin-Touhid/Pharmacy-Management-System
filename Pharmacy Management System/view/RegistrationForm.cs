using Pharmacy_Management_System.controller;
using Pharmacy_Management_System.model;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;

namespace Pharmacy_Management_System.view
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox2.Text;
            string name = textBox1.Text;
            string password = textBox3.Text;
            string email = textBox4.Text;
            string role = comboBox1.SelectedItem?.ToString();

            // Validate input fields
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter the Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Please enter the Username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter the Password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter the Email.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate email format
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
            {
                MessageBox.Show("Please enter a valid Gmail address (e.g., example@gmail.com).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Please select a role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create login object
            Login login = new Login(userName, password, role);
            LoginController lgc = new LoginController();
            lgc.AddLogin(login);

            // Add Employee or Customer based on role
            if (role == "Employee")
            {
                Employee c = new Employee(userName, name, password, email, role);
                EmployeeController cc = new EmployeeController();
                cc.AddEmployee(c);
            }
            else if (role == "Customer")
            {
                Customer cus = new Customer(userName, name, password, email);
                CustomerController cc = new CustomerController();
                cc.AddCustomer(cus);
            }

            // Show success message
            MessageBox.Show($"{role} Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(41, 128, 185);

            // Optional: Change text color
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = SystemColors.Control;

            // Optional: Restore original text color
            button1.ForeColor = Color.Black;
        }
    }
}

