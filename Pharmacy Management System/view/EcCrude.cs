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
    public partial class EcCrude : Form
    {
        public EcCrude()
        {
            InitializeComponent();
        }

        public void Display()
        {
            Logins.DisplayAndSearch("SELECT userName, password, role FROM Login", dataGridView);
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
    }
}
