using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.model
{
    public class Employee
    {
        private string employeeName;
        private string name;
        private string password;
        private string email;
        private string role;
      

        public Employee()
        { 

        }

        public Employee(string employeeName, string name, string password, string email,string role)
        {
            this.EmployeeName = employeeName;
            this.Name = name;
            this.Password = password;
            this.Email = email;
            this.role = role;
        }

        public string EmployeeName { get => employeeName; set => employeeName = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Role { get => role; set => role = value; }

    }
}
