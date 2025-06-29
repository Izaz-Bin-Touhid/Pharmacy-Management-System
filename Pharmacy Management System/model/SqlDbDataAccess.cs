//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data;
//using System.Data.SqlClient;


//namespace Pharmacy_Management_System.model
//{
//    public class SqlDbDataAccess
//    {
//        private const string connectionString = @"Data Source= IZAZ\SQLEXPRESS;Initial Catalog=Pharmacy Management System;Trusted_Connection=true";

//        public SqlCommand GetQuery(string query)
//        {
//            var connection = new SqlConnection(connectionString);
//            SqlCommand cmd = new SqlCommand(query);
//            cmd.Connection = connection;
//            return cmd;
//        }
//    }
//}




using System;
using System.Data;
using System.Data.SqlClient;

namespace Pharmacy_Management_System.model
{
    public class SqlDbDataAccess
    {
        private const string connectionString = @"Data Source=IZAZ\SQLEXPRESS;Initial Catalog=Pharmacy Management System;Trusted_Connection=true";

        // 1. Support for queries with optional parameters
        public SqlCommand GetQuery(string query, SqlParameter[] parameters = null)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            return cmd;
        }

        // 2. Execute INSERT, UPDATE, DELETE queries
        public void ExecuteNonQuery(SqlCommand cmd)
        {
            using (cmd.Connection)
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // 3. Execute SELECT queries and return SqlDataReader
        public SqlDataReader ExecuteReader(SqlCommand cmd)
        {
            cmd.Connection.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        // 4. For DataGridView display
        public DataTable ExecuteDataTable(SqlCommand cmd)
        {
            DataTable table = new DataTable();
            using (cmd.Connection)
            {
                cmd.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            return table;
        }
    }
}
