using Pharmacy_Management_System.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_Management_System.controller
{
    public class CustomerController
    {
        public void AddCustomer(Customer cs)
        {
            try
            {
                Customers cls = new Customers();
                cls.AddCustomers(cs);
            }
            catch (SqlException sqlEx)
            {
                
                MessageBox.Show($"Database error adding customer: {sqlEx.Message}",
                                "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Unexpected error adding customer: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }
        }
    }

}
