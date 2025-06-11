using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.model
{
    public class Login
    {
        private string userName;
        private string password;
        private string role;

        public Login() { 
        
        }

        public Login(string userName, string password, string role)
        {
            this.UserName = userName;
            this.Password = password;
            this.Role = role;
        }

        public String UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }
    }
}
