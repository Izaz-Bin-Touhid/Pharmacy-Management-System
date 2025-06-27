using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Pharmacy_Management_System.model
{
    public class Customers
    {
        SqlDbDataAccess sda = new SqlDbDataAccess();
        public void AddCustomers(Customer c)
        {
            try
            {
                SqlCommand cmd = sda.GetQuery(
                    "INSERT INTO Customer VALUES(@customerName,@name,@password,@email);");
                cmd.Parameters.AddWithValue("@customerName", c.CustomerName);
                cmd.Parameters.AddWithValue("@name", c.Name);
                cmd.Parameters.AddWithValue("@password", c.Password);
                cmd.Parameters.AddWithValue("@email", c.Email);

                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (SqlException sqlEx)
            {
               
                Console.WriteLine($"SQL error inserting customer: {sqlEx.Message}");
               
               
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Unexpected error: {ex.Message}");
                
            }
        }

    }
}
