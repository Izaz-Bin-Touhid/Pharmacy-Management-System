using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.model
{
    public class Admin
    {
        private int adminId;
        private string name;
        private string email;
        private string password;

        public Admin() { 
        }

        public Admin(int adminId, string name, string email, string password)
        {
            this.AdminId = adminId;
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }

        public int AdminId { get => adminId; set => adminId = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
    }
}
