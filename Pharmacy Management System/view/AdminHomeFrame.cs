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
        Login login;
        public AdminHomeFrame(Login login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void AdminHomeFrame_Load(object sender, EventArgs e)
        {

        }
    }
}
