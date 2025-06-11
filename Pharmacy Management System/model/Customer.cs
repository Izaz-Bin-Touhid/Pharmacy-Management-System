using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.model
{
    public class Customer
    {
        private int customerId;
        private string name;
        private string password;
        private string email;

        public Customer() { }

        public Customer(int customerId, string name, string password, string email)
        {
            this.CustomerId = customerId;
            this.Name = name;
            this.Password = password;
            this.Email = email;
        }

        public int CustomerId { get => customerId; set => customerId = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
    }
}
