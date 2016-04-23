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
        private string loginEntity = "`UsersLogin`";
        private string detailsEntity = "`UsersDetails`";
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

        // START OF LOGIN METHODS

        // verification, if user is registered
        public bool isUserRegistered(string email, string password)
        {
            if (openConnection())
            {
                string sqlQuery = "select email, password from " + loginEntity + " where email like '" + email + "'";

                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (reader["email"] + "" == email && reader["password"] + "" == password)
                    {
                        closeConnection();
                        return true;
                    }
                }
            }
            closeConnection();
            return false;
        }


        // verification, if user is admin, or not
        public string isUserAdmin(string email)
        {
            string userRole = null;
            if (openConnection())
            {
                string sqlQuery = "select UserRole from " + loginEntity + " where email like '" + email+"'";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                {
                    if (reader.Read())
                    {
                        userRole = reader["UserRole"] + "";
                    }
                }
            }
            closeConnection();
            return userRole;
        }

        // START OF USER METHOD
        
        // method, that found user age for his profile
        public string getUserAge(string userId)
        {
            string userAge = null;
            DateTime BirthDate = new DateTime();
            string sqlQuery = "select BirthDate from " + usersEntity + " where id like " + userId;

            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    userAge = reader["BirthDate"] + "";
                }
                closeConnection();
                string[] items = userAge.Split('-');
                BirthDate.AddYears(int.Parse(items[0]));
                BirthDate.AddMonths(int.Parse(items[1]));
                BirthDate.AddDays(int.Parse(items[2]));
                userAge = null;
                if (System.DateTime.Today.Month == BirthDate.Month && System.DateTime.Today.Day == BirthDate.Day)
                {
                    userAge = (System.DateTime.Today.Year - BirthDate.Year).ToString();
                }
                else
                {
                    userAge = (System.DateTime.Today.Year - BirthDate.Year - 1).ToString();
                }
                return userAge;
            }
            else
            {
                return null;
            }
        }

        // method, that found user first and last name for his profile
        public string getUserAllName(string userId)
        {
            string userName = null;
            string sqlQuery = "select FirstName, LastName from " + usersEntity + " where id like " + userId;

            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    userName = reader["FirstName"] + " " + reader["LastName"] + "";
                }
                closeConnection();
                return userName;
            }
            else
            {
                return userName;
            }
        }

        // method, that found user id for next works
        public string FindUser(string username, string password)
        {
            string userID = null;
            string sqlQuery = "select id from " + loginEntity + " where email like '" + username + "' and password like '" + password + "'";
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

        // START OF ADMIN - USER METHODS

        // for write all users
        public List<string> getUser()
        {
            List<string> users = new List<string>();
            string sqlQuery = "select ID, FirstName, LastName from " + usersEntity;
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(reader["ID"] + " " + reader["FirstName"] + " " + reader["LastName"]);
                }
                closeConnection();
            }
            return users;
        }

        // after users registration, his data will be saved to database, and admin must confirm, or refuse his request
        public bool writeUserAsInactive(string firstName, string lastName, string email, string password, string telephone, System.DateTime birthDate, string street, int streetNumber, string city, string postalCode, string country)
        {
            try
            {
                if (openConnection())
                {
                    string sqlQuery = "insert into " + usersEntity + " (FirstName, LastName, BirthDate) "
                        + "values (@firstName, @lastName, @birthDate)";

                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@birthDate", (birthDate.Year + "-" + birthDate.Month + "-" + birthDate.Day));
                    cmd.ExecuteNonQuery();

                    sqlQuery = "insert into " + loginEntity + " (email, password, Active) "
                        + "values (@email, @password, @active)";
                    cmd = new MySqlCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@active", "waiting");
                    cmd.ExecuteNonQuery();

                    sqlQuery = "insert into " + detailsEntity + " (Street, StreetNumber, PostalCode, City, Telephone, Country) "
                        + "values (@street, @streetnumber, @postalcode, @city, @telephone, @country)";
                    cmd = new MySqlCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("@street", street);
                    cmd.Parameters.AddWithValue("@streetnumber", streetNumber);
                    cmd.Parameters.AddWithValue("@postalcode", postalCode);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@telephone", telephone);
                    cmd.Parameters.AddWithValue("@country", country);

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

        // if there are some registration requests, this method find out how many there are
        public int waitingRegistration()
        {
            int wait = 0;
            if (openConnection())
            {
                string sqlQuery = "select * from " + loginEntity + " where active like 'waiting'";
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

        // if there are some registration requests, this method find out details
        public string waitingUsers()
        {
            string wait = null;
            string help;
            DateTime forAge = new DateTime();
            int i = 0;
            if (openConnection())
            {
                string sqlQuery = "select "+ usersEntity + ".ID, " + usersEntity + ".FirstName, " + usersEntity + ".LastName, "
                    + usersEntity + ".BirthDate, " + loginEntity + ".email from " + usersEntity + " inner join "
                    + loginEntity + "on " + usersEntity + ".ID = " + loginEntity + ".ID where "
                    + loginEntity + ".Active like 'waiting'";
                MySqlCommand check = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = check.ExecuteReader();
                while (reader.Read() && i < 5)
                {
                    wait = wait + reader["ID"] + ";" + reader["FirstName"] + ";" + reader["LastName"] + "";
                    help = reader["BirthDate"] + "";
                    Console.Write(help);
                    forAge = DateTime.Parse(help);

                    if (System.DateTime.Today.Year == forAge.Year && System.DateTime.Today.Month <= forAge.Month && System.DateTime.Today.Day <= forAge.Day)
                    {
                        help = (System.DateTime.Today.Year - forAge.Year).ToString();
                    }
                    else
                    {
                        help = (System.DateTime.Today.Year - forAge.Year - 1).ToString();
                    }

                    wait = wait + ";" + reader["email"] + ";" + help + ";";
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

        // if admin confirm user registration
        public bool writeUserAsActive(string id, string userRole, string active)
        {
            if (openConnection())
            {
                string sqlQuery = "update " + loginEntity + " set Active = @active, UserRole = @userrole where id like " + id;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@userrole", userRole);
                cmd.ExecuteNonQuery();
                closeConnection();
                return true;
            }
            return false;
        }

        // admin can block user
        public bool blockUser(string id, string active)
        {
            if (openConnection())
            {
                string sqlQuery = "update " + loginEntity + " set Active = @active where id like " + id;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.ExecuteNonQuery();
                closeConnection();
                return true;
            }
            return false;
        }

        // for deleting users from database, if users delete his account
        public bool deleteUserFromDatabase(string id)
        {
            if (openConnection())
            {
                string sqlQuery = "delete from " + usersEntity + " where id like @id";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                closeConnection();
                return true;
            }
            return false;
        }

        // searching bookname according search parameters
        public List<string> searchBookNames(string search, bool free)
        {
            List<string> books = new List<string>();
            if (openConnection())
            {
                String sqlQuery;
                if (free == true)
                {
                    sqlQuery = "SELECT BookName FROM Books where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Lent LIKE 0";
                }
                else
                {
                    sqlQuery = "SELECT BookName FROM Books where BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%'";
                }
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    books.Add((reader["BookName"].ToString()));
                }
                closeConnection();
                return books;
            }
            return books;
        }

        // searching Author according search parameters
        public List<string> searchAuthor(string search, bool free)
        {
            List<string> authors = new List<string>();
            if (openConnection())
            {
                String sqlQuery;
                if (free == true)
                {
                    sqlQuery = "select Author from Books where (BookName like '%" + search + "%' or Author like '%" + search + "%') and Lent LIKE 0 ";
                }
                else
                {
                    sqlQuery = "SELECT Author FROM Books where BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%'";
                }
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    authors.Add((reader["Author"].ToString()));
                }
                closeConnection();
                return authors;
            }
            return authors;
        }

        // searching Lents according search parameters
        public List<string> searchLents(string search, bool free)
        {
            string help;
            List<string> Lents = new List<string>();
            if (openConnection())
            {
                String sqlQuery;
                if (free == true)
                {
                    sqlQuery = "SELECT Lent FROM Books where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Lent LIKE 0";
                }
                else
                {
                    sqlQuery = "SELECT Lent FROM Books where BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%'";
                }
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Lents.Add((bool)(reader["Lent"]) ? "lent":"free");
                }
                closeConnection();
                return Lents;
            }
            return Lents;
        }
    }
}
