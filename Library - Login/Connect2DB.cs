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
        private string port;
        public MySqlConnection connection;

        public Connect2DB()
        {
            server = "mysql51.websupport.sk";
            database = "ReBooksDB";
            uid = "ReBooksDB";
            password = "auticko1238792";
            port = "3310";
            string connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        public int getUserAge(int userId)
        {
            int userAge = 0;
            string sqlQuery = "select age from users where id like " + userId;

            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    userAge = int.Parse(reader["age"] + "");
                }
                closeConnection();
                return userAge;
            }
            else
            {
                return userAge;
            }
        }

        public string getUserAllName(int userId)
        {
            string userName = null;
            string sqlQuery = "select username, usersurname from users where id like " + userId;

            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    userName = reader["username"] + "" + reader["usersurname"] + "";
                }
                closeConnection();
                return userName;
            }
            else
            {
                return userName;
            }
        }

        public int FindUser(string username, string password)
        {
            int userID = -1;
            string sqlQuery = "select id from users where username like '" + username + "' and userpass like '" + password + "'";
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    userID = int.Parse(reader["userid"] + "");
                }
                closeConnection();
                return userID;
            }
            else
            {
                return userID;
            }
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

        public bool writeUserAsInactive(string firstName, string lastName, string email, int telephone, int age, System.DateTime birthDate, string street, string streetNumber, string city, int postalCode)
        {
            if (openConnection())
            {
                string sqlQuery = "insert into users (username, usersurname, email, telephone, age, birthdate,"
                    + "active, street, streetnumber, psc, city) values ('" + firstName + "', '" + lastName + "', '"
                    + email + "', " + telephone + ", " + age + ", '" + birthDate.Year + "-" + birthDate.Month + "-"
                    + birthDate.Day + "', 0, '" + street + "', '" + streetNumber + "', " + postalCode + ", '"
                    + city + "')";

                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.Add(sqlQuery);
                closeConnection();
                return true;
            }
            else
            {
                return false;
            }
        }

        public int waitingRegistration()
        {
            int wait = 0;
            if (openConnection())
            {
                string sqlQuery = "select * from Users where active like 0";
                MySqlCommand check = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = check.ExecuteReader();
                while (reader.Read())
                {
                    wait++;
                }
                closeConnection();
                return wait;
            }
            else
            {
                return -1;
            }
        }
    }
}
