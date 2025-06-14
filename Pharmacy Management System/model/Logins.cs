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
            SqlCommand cmd = dba.GetQuery("INSERT INTO Login (userName, password,role) Values(@userName,@password,@role);");
            cmd.Parameters.AddWithValue("@userName", login.UserName);
            cmd.Parameters.AddWithValue("@password", login.Password);
            cmd.Parameters.AddWithValue("@role", login.Role);

            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();



        }
        public void UpdateLogin(Login login)
        {
            SqlCommand cmd = dba.GetQuery("UPDATE Login SET password=@password,role=@role WHERE userName=@userName;");
            cmd.Parameters.AddWithValue("@userName", login.UserName);
            cmd.Parameters.AddWithValue("@password", login.Password);
            cmd.Parameters.AddWithValue("@role", login.Role);

            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();



        }

        public void DeleteLogin(string userName)
        {
            SqlCommand cmd = dba.GetQuery("DELETE FROM Login WHERE userName=@userName;");
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();



        }

        public List<Login> GetData(SqlCommand cmd)
        {
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Login> logins = new List<Login>();

            using (reader)
            {
                while (reader.Read())
                {
                    Login login = new Login();
                    login.UserName = reader.GetString(0);
                    login.Password = reader.GetString(1);
                    login.Role = reader.GetString(2);

                    logins.Add(login);
                }

                reader.Close();
            }

            cmd.Connection.Close();
            return logins;

        }

        public Login SearchLogin(string userName, string password)
        {
            SqlCommand cmd = dba.GetQuery("SELECT * FROM Login WHERE userName=@userName AND password=@password;");
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.CommandType = CommandType.Text;

            List<Login> logins = GetData(cmd);

            if (logins.Count > 0)
            {
                return logins[0];
            }
            else
            {
                return null;
            }

            


        }

        public List<Login> GetAllLogin()
        {
            SqlCommand cmd = dba.GetQuery("SELECT * FROM Login;");
            
            cmd.CommandType = CommandType.Text;

            List<Login> logins = GetData(cmd);

            return logins;

        }


        ///Test////
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
