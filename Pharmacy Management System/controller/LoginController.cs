using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Pharmacy_Management_System.model;

namespace Pharmacy_Management_System.controller
{
    public class LoginController
    {
        public void AddLogin(Login login)
        {
            try
            {
                Logins lgs = new Logins();
                lgs.AddLogin(login);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error adding login: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error adding login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateLogin(Login login)
        {
            try
            {
                Logins lgs = new Logins();
                lgs.UpdateLogin(login);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error updating login: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error updating login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteLogin(string userName)
        {
            try
            {
                Logins lgs = new Logins();
                lgs.DeleteLogin(userName);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error deleting login: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error deleting login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Login SearchLogin(string userName, string password)
        {
            try
            {
                Logins lgs = new Logins();
                return lgs.SearchLogin(userName, password);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error searching login: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error searching login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Login> GetAllLogins()
        {
            try
            {
                Logins lgs = new Logins();
                return lgs.GetAllLogin();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error retrieving logins: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Login>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error retrieving logins: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Login>();
            }
        }
    }
}

