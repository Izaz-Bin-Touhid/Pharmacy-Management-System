using Pharmacy_Management_System.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_Management_System.controller
{
    public class ProductController
    {
        SqlDbDataAccess sda = new SqlDbDataAccess();

        public void AddCustomer(Customer cs)
        {
            try
            {
                Customers cls = new Customers();
                cls.AddCustomers(cs);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the customer: {ex.Message}");
            }
        }

        public void UpdateLogin(Login login)
        {
            try
            {
                Logins lgs = new Logins();
                lgs.UpdateLogin(login);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the login: {ex.Message}");
            }
        }

        public void DeleteLogin(string userName)
        {
            try
            {
                Logins lgs = new Logins();
                lgs.DeleteLogin(userName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the login: {ex.Message}");
            }
        }

        public Login SearchLogin(string userName, string password)
        {
            try
            {
                Logins lgs = new Logins();
                return lgs.SearchLogin(userName, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching for the login: {ex.Message}");
                return null;
            }
        }
        public List<Product> GetAllProducts()
        {
            try
            {
                Products ps = new Products();
                return ps.GetProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving all products: {ex.Message}");
                return new List<Product>();
            }
        }

        public List<Login> GetAllLogins()
        {
            try
            {
                Logins lgs = new Logins();
                return lgs.GetAllLogin();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving all logins: {ex.Message}");
                return new List<Login>();
            }
        }


    }
}
