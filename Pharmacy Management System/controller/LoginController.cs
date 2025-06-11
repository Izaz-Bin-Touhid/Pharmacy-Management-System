using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy_Management_System.model;

namespace Pharmacy_Management_System.controller
{
    public class LoginController
    {
        public void AddLogin(Login login)
        {
            Logins lgs = new Logins();
            lgs.AddLogin(login);

        } 

        public void UpdateLogin(Login login)
        {
            Logins lgs = new Logins();
            lgs.UpdateLogin(login);
        }

        public void DeleteLogin(string userName)
        {
            Logins lgs = new Logins();
            lgs.DeleteLogin(userName);
        }

        public Login SearchLogin(string userName, string password)
        {
            Logins lgs = new Logins();
            Login login = lgs.SearchLogin(userName, password);
            return login;
        }

        public List<Login> GetAllLogins()
        {
            Logins lgs = new Logins();
            List<Login> loginList = lgs.GetAllLogin();
            return loginList;
        }
    }
}
