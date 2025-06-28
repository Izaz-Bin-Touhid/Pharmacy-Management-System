using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pharmacy_Management_System.model
{
    public class Cart
    {
        SqlDbDataAccess dba = new SqlDbDataAccess();

        public void AddToCart(CartItem item)
        {
            SqlCommand cmd = dba.GetQuery("INSERT INTO cartTable (cartSerial, productName, priceAfterDiscount, quantity, total) VALUES (@cartSerial, @productName, @priceAfterDiscount, @quantity, @total);");
            cmd.Parameters.AddWithValue("@cartSerial", item.CartSerial);
            cmd.Parameters.AddWithValue("@productName", item.ProductName);
            cmd.Parameters.AddWithValue("@priceAfterDiscount", item.PriceAfterDiscount);
            cmd.Parameters.AddWithValue("@quantity", item.Quantity);
            cmd.Parameters.AddWithValue("@total", item.Total);
            cmd.CommandType = CommandType.Text;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error adding cart item: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error adding cart item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }

        public void DeleteCartItem(string cartSerial)
        {
            SqlCommand cmd = dba.GetQuery("DELETE FROM cartTable WHERE cartSerial = @cartSerial;");
            cmd.Parameters.AddWithValue("@cartSerial", cartSerial);
            cmd.CommandType = CommandType.Text;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error deleting cart item: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error deleting cart item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }

        public List<CartItem> GetData(SqlCommand cmd)
        {
            List<CartItem> items = new List<CartItem>();
            SqlDataReader reader = null;

            try
            {
                cmd.Connection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CartItem item = new CartItem(
                        reader["cartSerial"].ToString(),
                        reader["productName"].ToString(),
                        Convert.ToSingle(reader["priceAfterDiscount"]),
                        Convert.ToInt32(reader["quantity"])
                    );
                    item.Total = Convert.ToSingle(reader["total"]);
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
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }

            return items;
        }

        public List<CartItem> GetAllCartItems()
        {
            SqlCommand cmd = dba.GetQuery("SELECT * FROM cartTable;");
            cmd.CommandType = CommandType.Text;
            return GetData(cmd);
        }

        public CartItem SearchCartItem(string cartSerial)
        {
            SqlCommand cmd = dba.GetQuery("SELECT * FROM cartTable WHERE cartSerial = @cartSerial;");
            cmd.Parameters.AddWithValue("@cartSerial", cartSerial);
            cmd.CommandType = CommandType.Text;

            var items = GetData(cmd);
            return items.Count > 0 ? items[0] : null;
        }

        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            SqlDbDataAccess dba = new SqlDbDataAccess();
            SqlCommand cmd = dba.GetQuery(query);
            cmd.CommandType = CommandType.Text;

            try
            {
                cmd.Connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable tbl = new DataTable();
                    tbl.Load(reader);
                    dgv.DataSource = tbl;
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error displaying cart: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error displaying cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }
    }
}
