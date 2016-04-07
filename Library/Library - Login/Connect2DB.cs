using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Library___Login
{

    //prototype of database connect
    class Connect2DB
    {
        private string password;
        private string server;
        private string uid; // user id
        private string database;
        private MySqlConnection connection;

        public Connect2DB()
        {
            server = "mariadb55.websupport.sk:3310";
            database = "ReBooksDB";
            uid = "ReBooksDB";
            password = "rebooksdb@";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        public bool openConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }

        public bool closeConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }

        public List<string> getUser()
        {
            List<string> users = new List<string>();
            string sqlQuery = "select name from users";
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(reader["name"] + "");
                }
                closeConnection();
            }
            return users;
        }
    }
}
