using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.model
{
    public class Customer
    {
        private string customerName;
        private string name;
        private string password;
        private string email;
        

        public Customer() { }

        public Customer(string customerName, string name, string password, string email)
        {
            this.CustomerName = customerName;
            this.Name = name;
            this.Password = password;
            this.Email = email;
           
        }

        public string CustomerName { get => customerName; set => customerName = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        
    }
}
