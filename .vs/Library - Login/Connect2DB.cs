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
        private string usersEntity = "`Users`";
        private string booksEntity = "`Books`";
        private string loansEntity = "`Loans`";
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

        public string getUserAge(string userId)
        {
            string userAge = null;
            string sqlQuery = "select Age from " +usersEntity + " where id like " + userId;

            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    userAge = reader["age"] + "";
                }
                closeConnection();
                return userAge;
            }
            else
            {
                return null;
            }
        }

        public string getUserAllName(string userId)
        {
            string userName = null;
            string sqlQuery = "select username, usersurname from " + usersEntity + " where id like " + userId;

            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    userName = reader["username"] + " " + reader["usersurname"] + "";
                }
                closeConnection();
                return userName;
            }
            else
            {
                return userName;
            }
        }

        public string FindUser(string username, string password)
        {
            string userID = null;
            string sqlQuery = "select id from " + usersEntity + " where email like '" + username + "' and userpass like '" + password + "'";
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    userID = reader["id"] + "";
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

        public bool isUserRegistered(string email, string password)
        {
            if (openConnection())
            {
                string sqlQuery = "select email, userpass from " + usersEntity + " where email like '" + email + "'";

                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (reader["email"] + "" == email && reader["userpass"] + "" == password)
                    {
                        closeConnection();
                        return true;
                    }
                }
            }
            closeConnection();
            return false;
        }

        public string isUserAdmin(string email)
        {
            string userRole = null;
            if (openConnection())
            {
                string sqlQuery = "select userrole from " + usersEntity + " where email like '" + email+"'";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                {
                    if (reader.Read())
                    {
                        userRole = reader["userrole"] + "";
                    }
                }
            }
            closeConnection();
            return userRole;
        }

        public List<string> getUser()
        {
            List<string> users = new List<string>();
            string sqlQuery = "select name from " + usersEntity;
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

        public bool writeUserAsInactive(string firstName, string lastName, string email, string password, int telephone, int age, System.DateTime birthDate, string street, string streetNumber, string city, int postalCode)
        {
            try
            {
                if (openConnection())
                {
                    string sqlQuery = "insert into " + usersEntity + " (username, userpass, usersurname, email, telephone, age, birthdate,"
                        + "active, street, streetnumber, psc, city) values (@firstName, @password, @lastName, @email, @telephone, "
                        + "@age, @birthDay, 0, @street, @streetnumber, @postalcode, @city)";

                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@telephone", telephone);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@birthDay", birthDate.Year + "-" + birthDate.Month + "-" + birthDate.Day);
                    cmd.Parameters.AddWithValue("@street", street);
                    cmd.Parameters.AddWithValue("@streetnumber", streetNumber);
                    cmd.Parameters.AddWithValue("@postalcode", postalCode);
                    cmd.Parameters.AddWithValue("@city", city);

                    cmd.ExecuteNonQuery();
                    closeConnection();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }

        public int waitingRegistration()
        {
            int wait = 0;
            if (openConnection())
            {
                string sqlQuery = "select * from " + usersEntity + " where active like 0";
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

        public string waitingUsers()
        {
            string wait = null;
            int i = 0;
            if (openConnection())
            {
                string sqlQuery = "select id, username, usersurname, email, age from " + usersEntity + " where active like 0";
                MySqlCommand check = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = check.ExecuteReader();
                while (reader.Read() && i < 5)
                {
                    wait = wait + reader["id"] + ";" + reader["username"] + ";" + reader["usersurname"] + ";" + reader["email"] + ";" + reader["age"] + ";";
                    i++;
                }
                closeConnection();
                return wait;
            }
            else
            {
                return wait;
            }
        }

        public bool writeUserAsActive(int id, char userRole)
        {

            return false;
        }

        public bool deleteUserFromDatabase(int id)
        {
            if (openConnection())
            {
                string sqlQuery = "delete from " + usersEntity + " where id like " + id;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.ExecuteNonQuery();
                closeConnection();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
