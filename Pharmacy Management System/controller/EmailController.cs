using Pharmacy_Management_System.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pharmacy_Management_System.controller
{
    namespace Pharmacy_Management_System.controller
    {
        public class EmailController
        {
            public void SendEmail(Email email)
            {
                try
                {
                    Emails ems = new Emails(); // Correct class name
                    ems.SendEmail(email);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while sending the email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public List<Email> GetAllEmails()
            {
                try
                {
                    Emails ems = new Emails(); // Correct class name
                    return ems.GetAllEmails();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while retrieving emails: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<Email>();
                }
            }
        }
    }
}