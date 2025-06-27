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
    public class Products
    {
        SqlDbDataAccess sda = new SqlDbDataAccess();

        public void AddProduct(Product p)
        {
            SqlCommand cmd = sda.GetQuery("INSERT INTO Product (productName, category, price, discount, priceAfterDiscount, stockQuantity, expiryDate, adminName) VALUES (@productName,@category,@price,@discount, @price - (@price * @discount / 100.0),@stockQuantity,@expiryDate,@adminName);");
            cmd.Parameters.AddWithValue("productName", p.ProductName);
            cmd.Parameters.AddWithValue("category", p.Category);
            cmd.Parameters.AddWithValue("price", p.Price);
            cmd.Parameters.AddWithValue("discount", p.Discount);
            cmd.Parameters.AddWithValue("stockQuantity", p.StockQuantity);
            cmd.Parameters.AddWithValue("expiryDate", p.ExpiryDate);
            cmd.Parameters.AddWithValue("adminName", p.AdminName);
            cmd.CommandType = CommandType.Text;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error adding product: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error adding product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }

        public void UpdateProduct(Product p)
        {
            SqlCommand cmd = sda.GetQuery("UPDATE Product SET category=@category, price=@price, discount=@discount, priceAfterDiscount=@price - (@price * @discount / 100.0), stockQuantity=@stockQuantity, expiryDate=@expiryDate, adminName=@adminName WHERE productName=@productName;");
            cmd.Parameters.AddWithValue("productName", p.ProductName);
            cmd.Parameters.AddWithValue("category", p.Category);
            cmd.Parameters.AddWithValue("price", p.Price);
            cmd.Parameters.AddWithValue("discount", p.Discount);
            cmd.Parameters.AddWithValue("stockQuantity", p.StockQuantity);
            cmd.Parameters.AddWithValue("expiryDate", p.ExpiryDate);
            cmd.Parameters.AddWithValue("adminName", p.AdminName);
            cmd.CommandType = CommandType.Text;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error updating product: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error updating product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }

        public void DeleteProduct(string productName)
        {
            SqlCommand cmd = sda.GetQuery("DELETE FROM Product WHERE productName=@productName;");
            cmd.Parameters.AddWithValue("productName", productName);
            cmd.CommandType = CommandType.Text;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error deleting product: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
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
                MessageBox.Show($"Database error fetching products: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error fetching products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            var productList = GetData(cmd);
            return productList.Count > 0 ? productList[0] : null;
        }

        public List<Product> GetProducts()
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Product;");
            cmd.CommandType = CommandType.Text;
            return GetData(cmd);
        }

        public string CheckExpireDate(string productName)
        {
            SqlCommand cmd = sda.GetQuery("SELECT expiryDate FROM Product WHERE productName = @productName;");
            cmd.Parameters.AddWithValue("productName", productName);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = null;
            string status = "Not Found";

            try
            {
                cmd.Connection.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DateTime expiryDate = Convert.ToDateTime(reader["expiryDate"]);
                    status = expiryDate < DateTime.Today ? "Expired" : "Valid";
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error checking expiry: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error checking expiry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                reader?.Close();
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }

            return status;
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
                    var tbl = new DataTable();
                    tbl.Load(reader);
                    dgv.DataSource = tbl;
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error displaying products: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error displaying products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }
    }
}