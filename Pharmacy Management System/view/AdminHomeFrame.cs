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
    
    public partial class AdminHomeFrame : Form
    {
        
        public AdminHomeFrame(Login login)
        {
            InitializeComponent();
            
        }

        private void AdminHomeFrame_Load(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            EcCrude ec = new EcCrude();
            ec.Show();
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            productCrude pc = new productCrude();
            pc.Show();
            this.Close();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm lg = new LoginForm();
            lg.Show();
            this.Close();
        }

        private void mainpanel_Paint_1(object sender, PaintEventArgs e)
        {
            EcCrude ec = new EcCrude(); 
            ec.Show();
            this.Hide();
        }
    }
}
