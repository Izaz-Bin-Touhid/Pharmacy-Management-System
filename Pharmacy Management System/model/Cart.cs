using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Pharmacy_Management_System.controller;
using Pharmacy_Management_System.view;

namespace Pharmacy_Management_System.model
{
    public class Cart
    {
        // Using the existing SqlDbDataAccess instance to handle the database connection
        SqlDbDataAccess dba = new SqlDbDataAccess();

        // Add a new cart item to the database
        public void AddToCart(CartItem item)
        {
            string query = "INSERT INTO cartTable (cartSerial, productName, priceAfterDiscount, quantity, total) " +
                           "VALUES (@cartSerial, @productName, @priceAfterDiscount, @quantity, @total);";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@cartSerial", item.CartSerial),
                new SqlParameter("@productName", item.ProductName),
                new SqlParameter("@priceAfterDiscount", item.PriceAfterDiscount),
                new SqlParameter("@quantity", item.Quantity),
                new SqlParameter("@total", item.Total)
            };

            SqlCommand cmd = dba.GetQuery(query, parameters);
            dba.ExecuteNonQuery(cmd); // Executes the query
        }

        // Delete a cart item based on cartSerial
        public void DeleteCartItem(string cartSerial)
        {
            string query = "DELETE FROM cartTable WHERE cartSerial = @cartSerial;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@cartSerial", cartSerial)
            };

            SqlCommand cmd = dba.GetQuery(query, parameters);
            dba.ExecuteNonQuery(cmd); // Executes the DELETE query
        }

        // Fetch data from SQL and return a list of CartItem
        public List<CartItem> GetData(SqlCommand cmd)
        {
            List<CartItem> items = new List<CartItem>();
            SqlDataReader reader = null;

            try
            {
                reader = dba.ExecuteReader(cmd);
                while (reader.Read())
                {
                    CartItem item = new CartItem(
                        reader["cartSerial"].ToString(),
                        reader["productName"].ToString(),
                        reader["priceAfterDiscount"] != DBNull.Value ? Convert.ToSingle(reader["priceAfterDiscount"]) : 0.0f,
                        reader["quantity"] != DBNull.Value ? Convert.ToInt32(reader["quantity"]) : 0
                    );
                    item.Total = reader["total"] != DBNull.Value ? Convert.ToSingle(reader["total"]) : 0.0f;
                    items.Add(item);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error retrieving cart items: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error retrieving cart items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                reader?.Close();
            }

            return items;
        }

        // Get all cart items
        public List<CartItem> GetAllCartItems()
        {
            string query = "SELECT * FROM cartTable;";
            SqlCommand cmd = dba.GetQuery(query);
            return GetData(cmd);
        }

        // Search for a cart item based on cartSerial
        public CartItem SearchCartItem(string cartSerial)
        {
            string query = "SELECT * FROM cartTable WHERE cartSerial = @cartSerial;";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@cartSerial", cartSerial)
            };

            SqlCommand cmd = dba.GetQuery(query, parameters);
            List<CartItem> items = GetData(cmd);
            return items.Count > 0 ? items[0] : null;
        }

        // Static method to display and search data in DataGridView
        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            SqlDbDataAccess dba = new SqlDbDataAccess();
            SqlCommand cmd = dba.GetQuery(query);
            try
            {
                DataTable tbl = dba.ExecuteDataTable(cmd); // Using ExecuteDataTable method to get DataTable
                dgv.DataSource = tbl;
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error displaying cart: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error displaying cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

