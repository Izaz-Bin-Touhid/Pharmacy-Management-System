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
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void UpdateProduct(Product p)
        {
            SqlCommand cmd = sda.GetQuery("UPDATE Product SET category=@category, price=@price, discount=@discount, " +"priceAfterDiscount=@price - (@price * @discount / 100.0), " +"stockQuantity=@stockQuantity, expiryDate=@expiryDate, adminName=@adminName " +"WHERE productName=@productName;");

            cmd.Parameters.AddWithValue("productName", p.ProductName);
            cmd.Parameters.AddWithValue("category", p.Category);
            cmd.Parameters.AddWithValue("price", p.Price);
            cmd.Parameters.AddWithValue("discount", p.Discount);
            cmd.Parameters.AddWithValue("stockQuantity", p.StockQuantity);
            cmd.Parameters.AddWithValue("expiryDate", p.ExpiryDate);
            cmd.Parameters.AddWithValue("adminName", p.AdminName);

            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }



        public void DeleteProduct(string productName)
        {

            SqlCommand cmd = sda.GetQuery("DELETE FROM Product WHERE productName=@productName;");

            cmd.Parameters.AddWithValue("productName", productName);
           

            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
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
            if(productList.Count > 0)
            {
                return productList[0];
            }
            else
            {
                return null;
            }
        }

        public List<Product> GetProducts()
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Product;");
            
            cmd.CommandType = CommandType.Text;

            List<Product> productList = GetData(cmd);
            return productList;

        }

        //Test
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
