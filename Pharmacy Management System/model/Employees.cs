using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;




namespace Pharmacy_Management_System.model
{
    public class Employees
    {
        SqlDbDataAccess sda = new SqlDbDataAccess();

        public void AddEmployee(Employee c)
        {
            try
            {
                SqlCommand cmd = sda.GetQuery("INSERT INTO Employee VALUES (@employeeName,@password,@name,@email);");
                cmd.Parameters.AddWithValue("@employeeName", c.EmployeeName);
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
               
                MessageBox.Show($"Database error adding employee: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            catch (Exception ex)
            {
             
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

    }
}
