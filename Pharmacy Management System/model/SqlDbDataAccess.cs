using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Pharmacy_Management_System.model
{
    public class SqlDbDataAccess
    {
        private const string connectionString = @"Data Source= IZAZ\SQLEXPRESS;Initial Catalog=Pharmacy Management System;Trusted_Connection=true";

        public SqlCommand GetQuery(string query)
        {
            var connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = connection;
            return cmd;
        }
    }
}
