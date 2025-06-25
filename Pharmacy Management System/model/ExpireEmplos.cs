using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Pharmacy_Management_System.model
{
    public class ExpireEmplos
    {
        SqlDbDataAccess sda = new SqlDbDataAccess();

        public string CheckExpireDate(string productName)
        {
            SqlCommand cmd = sda.GetQuery("SELECT expiryDate FROM Product WHERE productName = @productName;");
            cmd.Parameters.AddWithValue("productName", productName);

            string status = "Not Found";

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    DateTime expiryDate = reader.GetDateTime(0); // Make sure DB column is of DATE or DATETIME type
                    DateTime today = DateTime.Today;

                    if (expiryDate < today)
                        status = "Expired";
                    else
                        status = "Valid";
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking expiry date: " + ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }

            return status;
        }


        public List<Product> GetData(SqlCommand cmd)
        {
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> productList = new List<Product>();

            using (reader)
            {
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ProductName = reader.GetString(0);
                    p.Category = reader.GetString(1);
                    p.Price = (float)reader.GetDouble(2);
                    p.Discount = reader.GetInt32(3);
                    p.PriceAfterDiscount = (float)reader.GetDouble(4);
                    p.StockQuantity = reader.GetInt32(5);
                    p.ExpiryDate = reader.GetString(6);
                    p.AdminName = reader.GetString(7);

                    productList.Add(p);
                }

                reader.Close();
            }
            cmd.Connection.Close();
            return productList;
        }

        public Product SearchProductByName(string productName)
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Product WHERE productName=@productName;");

            cmd.Parameters.AddWithValue("productName", productName);
            cmd.CommandType = CommandType.Text;

            List<Product> productList = GetData(cmd);
            if (productList.Count > 0)
            {
                return productList[0];
            }
            else
            {
                return null;
            }
        }


        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            SqlDbDataAccess dba = new SqlDbDataAccess();
            SqlCommand cmd = dba.GetQuery(query);
            cmd.CommandType = CommandType.Text;

            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable tbl = new DataTable();
            tbl.Load(reader);
            dgv.DataSource = tbl;

            cmd.Connection.Close();
        }
    }
}
