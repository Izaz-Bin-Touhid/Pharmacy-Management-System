using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.model
{
    public class Emails
    {
        SqlDbDataAccess sda = new SqlDbDataAccess();

        public void SendEmail(Email email)
        {
            SqlCommand cmd = sda.GetQuery("INSERT INTO Emails (customerName, recipient, subject, message, sentTime) VALUES (@customerName, @recipient, @subject, @message, @sentTime);");

            cmd.Parameters.AddWithValue("@customerName", email.CustomerName);
            cmd.Parameters.AddWithValue("@recipient", email.Recipient);
            cmd.Parameters.AddWithValue("@subject", email.Subject);
            cmd.Parameters.AddWithValue("@message", email.Message);
            cmd.Parameters.AddWithValue("@sentTime", email.SentTime);

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd.Connection.Close(); // ensures close even on failure
            }
        }


        public List<Email> GetAllEmails()
        {
            List<Email> emailList = new List<Email>();

            SqlCommand cmd = sda.GetQuery("SELECT customerName, recipient, subject, message, sentTime FROM Emails;");
            cmd.Connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Email email = new Email
                {
                    CustomerName = reader["customerName"].ToString(),
                    Recipient = reader["recipient"].ToString(),
                    Subject = reader["subject"].ToString(),
                    Message = reader["message"].ToString(),
                    SentTime = Convert.ToDateTime(reader["sentTime"])
                };
                emailList.Add(email);
            }

            reader.Close();
            cmd.Connection.Close();
            return emailList;
        }

    }

}
