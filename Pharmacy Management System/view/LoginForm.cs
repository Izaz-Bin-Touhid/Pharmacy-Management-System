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
using Pharmacy_Management_System.model;

namespace Pharmacy_Management_System.view
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }


        //exit button
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm rf = new RegistrationForm();
           
            rf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;

            if (string.IsNullOrWhiteSpace(userName) && string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please input User Name and Password", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Please enter your username", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your password", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoginController lgc = new LoginController();
            Login login= lgc.SearchLogin(userName, password);

            if(login != null)
            {
                if (login.UserName.Equals("admin", StringComparison.OrdinalIgnoreCase) &&
        login.UserName.Equals("admin") &&
        login.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    // Hide the current form
                    this.Hide();

                    // Redirect to AdminHomeFrame
                    AdminHomeFrame adh = new AdminHomeFrame(login);
                    adh.Show();
                }
                else if (login.UserName.Equals(userName) && login.Password.Equals(password) && login.Role.Equals("Employee"))
                {
                    this.Hide();
                    ExpireEmplo ex = new ExpireEmplo();
                    ex.Show();

                }

                else if (login.UserName.Equals(userName) && login.Password.Equals(password) && login.Role.Equals("Customer"))
                {
                    MessageBox.Show("Customer");

                }
                else
                {
                    MessageBox.Show("INvalid id pass");
                }


            }

            
            

            else
            {
                MessageBox.Show("Invalid");
            }

                    
       
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == false)
            {
                textBox2.UseSystemPasswordChar = true;

            }

            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
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

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(41, 128, 185);

            // Optional: Change text color
            button3.ForeColor = Color.White;

        }
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = SystemColors.Control;

            // Optional: Restore original text color
            button3.ForeColor = Color.Black;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
