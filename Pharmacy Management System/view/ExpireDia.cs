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
    public partial class ExpireDia : Form
    {
        public ExpireDia()
        {
            InitializeComponent();
        }

        private void ExpireDia_Load(object sender, EventArgs e)
        {

        }

        public ExpireDia(string productName, bool isExpired)
        {
            InitializeComponent();

            label1.Text = isExpired
                ? $"❌ The product \"{productName}\" is EXPIRED."
                : $"✅ The product \"{productName}\" is still VALID.";

            button1.Visible = isExpired;
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("📧 Email has been sent to the administrator.", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

