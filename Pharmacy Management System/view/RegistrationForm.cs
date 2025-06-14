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
            if (string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Please select a role.");
                return;
            }

            Login login = new Login(userName, password, role);
            LoginController lgc = new LoginController();
            lgc.AddLogin(login);


            //Test
            if(role == "Employee")
            {
                Employee c = new Employee(userName, name, password, email,role);
                EmployeeController cc = new EmployeeController();
                cc.AddEmployee(c);
            }
            else if(role == "Customer")
            {
                Customer cus = new Customer(userName, name, password, email);
                CustomerController cc = new CustomerController();
                cc.AddCustomer(cus);

            }

            MessageBox.Show($"{role} Added Successfully");


            
        }
    }
}
