using Pharmacy_Management_System.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.model
{
    public class EmployeeController
    {
        public void AddEmployee(Employee c)
        {
            try
            {
                Employees cls = new Employees();
                cls.AddEmployee(c);
            }
            catch (SqlException sqlEx)
            {
              
                Console.WriteLine($"SQL error while adding employee: {sqlEx.Message}");
                
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Unexpected error: {ex.Message}");
                
            }
        }
    }

}
