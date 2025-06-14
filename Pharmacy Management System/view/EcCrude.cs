using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_Management_System.view
{
    public partial class EcCrude : Form
    {
        public EcCrude()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EcDialouge ec = new EcDialouge();
            ec.ShowDialog();
        }
    }
}
