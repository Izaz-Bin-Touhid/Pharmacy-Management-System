using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.model
{
    public class Employee
    {
        private int employeeId;
        private string name;
        private string password;
        private string email;
        private int adminId;

        public Employee()
        { 

        }

        public Employee(int employeeId, string name, string password, string email, int adminId)
        {
            this.EmployeeId = employeeId;
            this.Name = name;
            this.Password = password;
            this.Email = email;
            this.AdminId = adminId;
        }

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public int AdminId { get => adminId; set => adminId = value; }
    }
}
