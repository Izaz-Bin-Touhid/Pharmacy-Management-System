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
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime expiryDate = reader.GetDateTime(0);
                            DateTime today = DateTime.Today;
                            status = (expiryDate < today) ? "Expired" : "Valid";
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"Database error checking expiry date: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error checking expiry date: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cmd.Connection.State != ConnectionState.Closed)
                        cmd.Connection.Close();
                }

                return status;
            }

            public List<Product> GetData(SqlCommand cmd)
            {
                List<Product> productList = new List<Product>();
                SqlDataReader reader = null;

                try
                {
                    cmd.Connection.Open();
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var p = new Product
                        {
                            ProductName = reader.GetString(0),
                            Category = reader.GetString(1),
                            Price = (float)reader.GetDouble(2),
                            Discount = reader.GetInt32(3),
                            PriceAfterDiscount = (float)reader.GetDouble(4),
                            StockQuantity = reader.GetInt32(5),
                            ExpiryDate = reader.GetString(6),
                            AdminName = reader.GetString(7)
                        };
                        productList.Add(p);
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"Database error retrieving data: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    reader?.Close();
                    if (cmd.Connection.State != ConnectionState.Closed)
                        cmd.Connection.Close();
                }

                return productList;
            }

            public Product SearchProductByName(string productName)
            {
                SqlCommand cmd = sda.GetQuery("SELECT * FROM Product WHERE productName=@productName;");
                cmd.Parameters.AddWithValue("productName", productName);
                cmd.CommandType = CommandType.Text;

                // No need for try/catch here since GetData handles exceptions
                var productList = GetData(cmd);
                return (productList.Count > 0) ? productList[0] : null;
            }

            public static void DisplayAndSearch(string query, DataGridView dgv)
            {
                SqlDbDataAccess dba = new SqlDbDataAccess();
                SqlCommand cmd = dba.GetQuery(query);
                cmd.CommandType = CommandType.Text;

                try
                {
                    cmd.Connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        DataTable tbl = new DataTable();
                        tbl.Load(reader);
                        dgv.DataSource = tbl;
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"Database error displaying data: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error displaying data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cmd.Connection.State != ConnectionState.Closed)
                        cmd.Connection.Close();
                }
            }
        }

    }

