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
            rf.ShowDialog();
            rf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;

            LoginController lgc = new LoginController();
            Login login= lgc.SearchLogin(userName, password);

            if(login != null)
            {
                if (login.UserName.Equals(userName) && login.Password.Equals(password) && login.Role.Equals("Admin")) {
                    this.Hide();
                    AdminHomeFrame adh = new AdminHomeFrame(login);
                    adh.Show();
                
                }
                else if (login.UserName.Equals(userName) && login.Password.Equals(password) && login.Role.Equals("Employee"))
                {
                    MessageBox.Show("Employee");

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
    }
}
