using System;
using MySql.Data.MySqlClient;

namespace BicycleCMS
{
    public class DatabaseController
    {
        private static DatabaseController dbc = null;
        MySqlConnection DBconn = null;
        MySqlCommand query = null;
        MySqlDataReader rdr = null;
        string connError = "";
        public string DBprefix = "Cms_";

        private DatabaseController()
        {
            string connectionString = "Server = mysql78.unoeuro.com; " +
                                        "Port = 3306; " +
                                        "Database = seobetter_dk_db_seobtr; " +
                                        "Uid = seobetter_dk; " +
                                        "Pwd = " + DBpwd.pwd+"; ";
            DBconn = new MySqlConnection(connectionString);
            try
            {
                DBconn.Open();
            }
            catch (Exception ex)
            {
                connError = ex.Message;
            }
        }

        public static DatabaseController getInstance()
        {
            if (dbc == null)
            {
                dbc = new DatabaseController();
            }
            return dbc;
        }

        public int dbUpdate(string SQLsentence)
        {
            query = null;
            query = DBconn.CreateCommand();
            query.CommandText = SQLsentence;
            int result = query.ExecuteNonQuery();
            return result;
        }

        public int insertedId()
        {
            return Convert.ToInt32(query.LastInsertedId);
        }

        public MySqlDataReader dbRead(string SQLsentence)
        {
            query = null;
            query = DBconn.CreateCommand();
            query.CommandText = SQLsentence;
            rdr = query.ExecuteReader();
            return rdr;
        }

        public MySqlDataAdapter dbAdapt(string SQLsentence)
        {
            query = null;
            query = DBconn.CreateCommand();
            query.CommandText = SQLsentence;
            MySqlDataAdapter adapt = new MySqlDataAdapter(query);
            return adapt;
        }

        public void closeReader()
        {
            rdr.Close();
        }

        public int rowCount(MySqlDataReader rdr)
        {
            return rdr.FieldCount;
        }

        public MySqlDataReader DBquery(string SQLsentence)
        {
            query = DBconn.CreateCommand();
            query.CommandText = SQLsentence;
            rdr = query.ExecuteReader();
            return rdr;

            /*while (rdr.Read())
            {
                Response.Write(" test " + (string)rdr["Petshop_Name"]);
            }
            GridViewShops.DataSource = rdr;
            GridViewShops.DataBind();*/
        }

        public void CloseConnection()
        {
            DBconn.Close();
        }
    }
}