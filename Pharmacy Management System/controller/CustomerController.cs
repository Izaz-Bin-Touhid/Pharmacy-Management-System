using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Pharmacy_Management_System.model;

namespace Pharmacy_Management_System.controller
{
    public class CustomerController
    {
        public void AddCustomer(Customer cs)
        {
            Customers cls = new Customers();
            cls.AddCustomers(cs);
        }
    }
}
