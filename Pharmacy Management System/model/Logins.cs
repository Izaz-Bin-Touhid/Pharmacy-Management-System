using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace Pharmacy_Management_System.model
{
    public class Logins
    {
        SqlDbDataAccess dba = new SqlDbDataAccess();

        public void AddLogin(Login login)
        {
            SqlCommand cmd = dba.GetQuery("INSERT INTO Login (userName, password,role) VALUES(@userName,@password,@role);");
            cmd.Parameters.AddWithValue("@userName", login.UserName);
            cmd.Parameters.AddWithValue("@password", login.Password);
            cmd.Parameters.AddWithValue("@role", login.Role);
            cmd.CommandType = CommandType.Text;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error adding login: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error adding login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }

        public void UpdateLogin(Login login)
        {
            using (SqlCommand cmd = dba.GetQuery("UPDATE Login SET password = @password, role = @role WHERE userName = @userName;"))
            {
                cmd.Parameters.AddWithValue("@userName", login.UserName);
                cmd.Parameters.AddWithValue("@password", login.Password);
                cmd.Parameters.AddWithValue("@role", login.Role);
                cmd.CommandType = CommandType.Text;

                try
                {
                    cmd.Connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("No user found with the specified username.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"Database error updating login: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unexpected error updating login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public void DeleteLogin(string userName)
        {
            SqlCommand cmd = dba.GetQuery("DELETE FROM Login WHERE userName=@userName;");
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.CommandType = CommandType.Text;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error deleting login: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error deleting login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }

        public List<Login> GetData(SqlCommand cmd)
        {
            List<Login> logins = new List<Login>();
            SqlDataReader reader = null;

            try
            {
                cmd.Connection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    logins.Add(new Login
                    {
                        UserName = reader.GetString(0),
                        Password = reader.GetString(1),
                        Role = reader.GetString(2)
                    });
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error retrieving logins: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error retrieving logins: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                reader?.Close();
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }

            return logins;
        }

        public Login SearchLogin(string userName, string password)
        {
            SqlCommand cmd = dba.GetQuery("SELECT * FROM Login WHERE userName=@userName AND password=@password;");
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.CommandType = CommandType.Text;

            var logins = GetData(cmd);
            return logins.Count > 0 ? logins[0] : null;
        }

        public List<Login> GetAllLogin()
        {
            SqlCommand cmd = dba.GetQuery("SELECT * FROM Login;");
            cmd.CommandType = CommandType.Text;
            return GetData(cmd);
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
                MessageBox.Show($"Database error displaying logins: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error displaying logins: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }
    }

}
