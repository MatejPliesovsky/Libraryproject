using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace Library___Login
{

    /// <summary>
    /// prototype of database connection
    /// </summary>
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
            string text = System.IO.File.ReadAllText("DatabaseInfo.txt");
            string[] items = text.Split('\n');
            
            server = (items[0].Split(' '))[1];
            database = (items[1].Split(' '))[1];
            uid = (items[2].Split(' '))[1];
            password = (items[3].Split(' '))[1];
            port = (items[4].Split(' '))[1];
            string connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// return open connection to DB
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// close DB connection
        /// </summary>
        /// <returns></returns>
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

        /***START OF LOGIN METHODS***/

        /// <summary>
        ///  verification if user is already registered
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public int isEmailTaken(string email)
        {
            if (openConnection())
            {
                int same = 0;
                string sqlQuery = "select email from UsersLogin";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["email"].ToString() == email)
                    {
                        same = 1;
                        break;
                    }
                }
                closeConnection();
                return same;
            }
            return -1;
        }

        /// <summary>
        /// verification, if user is registered
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool isUserRegistered(string email, string password)
        {
            if (openConnection())
            {
                string sqlQuery = "select email, password from UsersLogin where email like '" + email + "'";

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

        /// <summary>
        /// read user´s profile image from db and load to profile page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public byte[] getUserProfileImage(string id)
        {
            byte[] imageBytes = null;
            String sqlQuery = "select Avatar from Users where ID = " + id;
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    imageBytes = (byte[])reader["Avatar"];
                    closeConnection();
                    return imageBytes;
                }
                closeConnection();
            }
            return null;
        }

        /// <summary>
        /// verification, if user is admin, or not
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string isUserAdmin(string email)
        {
            string userRole = null;
            if (openConnection())
            {
                string sqlQuery = "select UserRole from UsersLogin where email like '" + email + "'";
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

        /// <summary>
        /// verification if is user blocked
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool isUserBlocked(string userID)
        {
            string status = null;
            if (openConnection())
            {
                string sqlQuery = "select Active from UsersLogin where ID like " + userID;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    status = reader["Active"] + "";
                }
                closeConnection();
                if (status.Equals("blocked"))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// verification if user is admin or not according his id
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public string getUserRole(string userID)
        {
            string userRole = null;
            if (openConnection())
            {
                string sqlQuery = "select UserRole from UsersLogin where ID like " + userID + "";
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

        /***START OF REGISTRATION METHODS***/

        /// <summary>
        /// adding phone prefixes to combobox
        /// </summary>
        /// <returns></returns>
        public List<string> getPhonePrefixes()
        {
            List<string> prefixes = new List<string>();
            if (openConnection())
            {
                string sqlQuery = "select PhonePrefix from Countries";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    prefixes.Add(reader["PhonePrefix"].ToString());
                }
                closeConnection();
            }
            return prefixes;
        }

        /// <summary>
        /// adding countries to combobox
        /// </summary>
        /// <returns></returns>
        public List<string> getCountriesNames()
        {
            List<string> countries = new List<string>();
            if (openConnection())
            {
                string sqlQuery = "select CountryName from Countries";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    countries.Add(reader["CountryName"].ToString());
                }
                closeConnection();
            }
            return countries;
        }

        /// <summary>
        /// adding prefix to DB
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public bool addCountryToDB(string prefix, string country)
        {
            if (openConnection())
            {
                string sqlQuery = "insert into Countries (CountryName, PhonePrefix) values (@country, @prefix)";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@country", country);
                cmd.Parameters.AddWithValue("@prefix", prefix);
                cmd.ExecuteNonQuery();
                closeConnection();
                return true;
            }
            return false;
        }

        /// <summary>
        /// get field of image
        /// </summary>
        /// <returns></returns>
        public byte[] getDefaultImage()
        {
            byte[] image = null;
            if (openConnection())
            {
                string sqlQuery = "select Image from DefaultUserImage";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    image = (byte[])reader["Image"];
                }
                closeConnection();
                return image;
            }
            return image;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool isCodeTaken(int code)
        {
            if (openConnection())
            {
                string sqlQuery = "select ResetPasswordCode from Users";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (code == Int32.Parse(reader["ResetPasswordCode"].ToString()))
                    {
                        closeConnection();
                        return true;
                    }
                }
                closeConnection();
            }
            return false;
        }

        public string setPasswordCode(string email)
        {
            string passwordCode = null;
            if (openConnection())
            {
                string sqlQuery = "select ResetPasswordCode from Users inner join UsersLogin on Users.ID = UsersLogin.ID where"
                    + " UsersLogin.email like '" + email + "'";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    passwordCode = reader["ResetPasswordCode"].ToString();
                }
                reader.Close();

                sqlQuery = "update UsersLogin set PASSWORD = @pass where email like @email";
                cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@pass", passwordCode);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.ExecuteNonQuery();

                closeConnection();
                return passwordCode;
            }
            return passwordCode;
        }

        /// <summary>
        /// after users registration, his data will be saved to database, and admin must confirm, or refuse his request
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="telephone"></param>
        /// <param name="birthDate"></param>
        /// <param name="street"></param>
        /// <param name="streetNumber"></param>
        /// <param name="city"></param>
        /// <param name="postalCode"></param>
        /// <param name="country"></param>
        /// <param name="image"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool writeUserAsInactive(string firstName, string lastName, string email, string password, string telephone, System.DateTime birthDate, string street, int streetNumber, string city, string postalCode, string country, byte[] image, int code)
        {
            try
            {
                if (openConnection())
                {

                    string sqlQuery = "insert into Users (FirstName, LastName, BirthDate, Avatar, ResetPasswordCode) "
                        + "values (@firstName, @lastName, @birthDate, @Avatar, @code)";

                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@birthDate", (birthDate.Year + "-" + birthDate.Month + "-" + birthDate.Day));
                    cmd.Parameters.AddWithValue("@Avatar", image);
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.ExecuteNonQuery();

                    sqlQuery = "insert into UsersLogin (email, password, Active) "
                        + "values (@email, @password, @active)";
                    cmd = new MySqlCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@active", "waiting");
                    cmd.ExecuteNonQuery();

                    sqlQuery = "insert into UsersDetails (Street, StreetNumber, PostalCode, City, Telephone, Country) "
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

        /***START OF USER METHOD***/

        /// <summary>
        /// method, that found user age for his profile
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string getUserAge(string userId)
        {
            string userAge = null;
            DateTime BirthDate = new DateTime();
            string sqlQuery = "select BirthDate from Users where id like " + userId;

            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    userAge = reader["BirthDate"] + "";
                }
                closeConnection();
                BirthDate = DateTime.Parse(userAge);
                userAge = null;
                if (System.DateTime.Today.Year >= BirthDate.Year && System.DateTime.Today.Month >= BirthDate.Month && System.DateTime.Today.Day >= BirthDate.Day)
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

        /// <summary>
        /// method, that found user first and last name for his profile
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string getUserAllName(string userId)
        {
            string userName = null;
            string sqlQuery = "select FirstName, LastName from Users where id like " + userId;

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

        /// <summary>
        /// method, that found user id for next works
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string FindUser(string username, string password)
        {
            string userID = null;
            string sqlQuery = "select id from UsersLogin where email like '" + username + "' and password like '" + password + "'";
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

        /// <summary>
        /// this find user all name thanks entity ReservedBooks
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public string findUserAllName(string bookID, string status)
        {
            string userName = null;
            if (openConnection())
            {
                string sqlQuery = null;
                if (status == "reserved")
                {
                    sqlQuery = "select FirstName, LastName from Users inner join ReservedBooks on Users.ID = ReservedBooks.IDUser where ReservedBooks.IDBook = " + bookID;
                }
                else
                {
                    sqlQuery = "select FirstName, LastName from Users inner join Borrowings on Users.ID = Borrowings.IDUser where Borrowings.IDBook = " + bookID;
                }

                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    userName = reader["FirstName"] + " " + reader["LastName"];
                }
                closeConnection();
                return userName;
            }
            return userName;
        }

        /// <summary>
        /// this find user age thanks entity ReservedBooks
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public string findUserAge(string bookID, string status)
        {
            string userAge = null;
            DateTime birthDate = new DateTime();
            if (openConnection())
            {
                string sqlQuery = null;
                if (status == "reserved")
                {
                    sqlQuery = "select BirthDate from Users inner join ReservedBooks on Users.ID = ReservedBooks.IDUser where ReservedBooks.IDBook like " + bookID;
                }
                else
                {
                    sqlQuery = "select BirthDate from Users inner join Borrowings on Users.ID = Borrowings.IDUser where Borrowings.IDBook like " + bookID;
                }

                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    userAge = reader["BirthDate"].ToString();
                }
                closeConnection();
                
                birthDate = DateTime.Parse(userAge);

                if (System.DateTime.Today.Year >= birthDate.Year && System.DateTime.Today.Month >= birthDate.Month && System.DateTime.Today.Day >= birthDate.Day)
                {
                    userAge = (System.DateTime.Today.Year - birthDate.Year).ToString();
                }
                else
                {
                    userAge = (System.DateTime.Today.Year - birthDate.Year - 1).ToString();
                }
                return userAge;
            }
            return userAge;
        }

        /// <summary>
        /// find user id by book id in entity ReservedBooks
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public string findUserIDByBookID(string bookID, string status)
        {
            string userID = null;
            if (openConnection())
            {
                string sqlQuery = null;
                if (status == "reserved")
                {
                    sqlQuery = "select IDUser from ReservedBooks where IDBook = " + bookID;
                }
                else
                {
                    sqlQuery = "select IDUser from Borrowings where IDBook = " + bookID;
                }
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    userID = reader["IDUser"].ToString();
                }
                closeConnection();
                return userID;
            }
            return userID;
        }

        /// <summary>
        /// automatically count how many reservations has user and if he has some number, he can't borrow more books
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="loan"></param>
        /// <returns></returns>
        public int checkSumOfReservation(string userID, bool loan)
        {
            int counter = 0;
            if (openConnection())
            {
                string sqlQuery = null;
                if (loan == false)
                {
                    sqlQuery = "select * from ReservedBooks where IDUser like " + userID;
                }
                else
                {
                    sqlQuery = "select * from Borrowings where IDUser like " + userID;
                }
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    counter++;
                }
                closeConnection();
                return counter;
            }
            return counter;
        }

        /// <summary>
        /// find all user ID according their name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<string> getAllUsers(string name)
        {
            List<string> users = new List<string>();
            if (openConnection())
            {
                string[] items;
                items = name.Split(' ');
                string sqlQuery;
                if (items.Length > 1)
                {
                    sqlQuery = "select ID from Users where FirstName like '" + items[0] + "' and LastName like '" + items[1] + "%'";
                }
                else
                {
                    sqlQuery = "select ID from Users where FirstName like '" + name + "%' or LastName like '" + name + "%'";
                }
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(reader["ID"].ToString());
                }
                closeConnection();
                return users;
            }
            return users;
        }
        ///<summary> START OF ADMIN - USER METHODS</summary>

        /// <summary>
        /// find all users IDs
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<string> getAllUsersData(string search)
        {
            string help, age;
            DateTime forAge;
            List<string> usersData = new List<string>();
            string sqlQuery = "select FirstName, LastName, BirthDate, email, UserRole, Active from Users inner join UsersLogin on Users.ID = UsersLogin.ID where Users.FirstName like '%" + search + "%' or Users.LastName like '%" + search + "%'";
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usersData.Add(reader["FirstName"].ToString());
                    usersData.Add(reader["LastName"].ToString());

                    help = reader["BirthDate"].ToString();
                    forAge = DateTime.Parse(help);
                    if (System.DateTime.Today.Year >= forAge.Year && System.DateTime.Today.Month >= forAge.Month && System.DateTime.Today.Day >= forAge.Day)
                    {
                        age = (System.DateTime.Today.Year - forAge.Year).ToString();
                    }
                    else
                    {
                        age = (System.DateTime.Today.Year - forAge.Year - 1).ToString();
                    }

                    usersData.Add(age);
                    usersData.Add(reader["UserRole"].ToString());
                    usersData.Add(reader["Active"].ToString());
                }
                closeConnection();
            }
            return usersData;
        }

        /// <summary>
        /// if there are some registration requests, this method find out how many there are
        /// </summary>
        /// <returns></returns>
        public int waitingRegistration()
        {
            int wait = 0;
            if (openConnection())
            {
                string sqlQuery = "select * from UsersLogin where active like 'waiting'";
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

        /// <summary>
        /// if there are some registration requests, this method find out details
        /// </summary>
        /// <returns></returns>
        public string waitingUsers()
        {
            string wait = null;
            string help;
            DateTime forAge = new DateTime();
            int i = 0;
            if (openConnection())
            {
                string sqlQuery = "select Users.ID, Users.FirstName, Users.LastName, Users.BirthDate, UsersLogin.email "
                    + "from Users inner join UsersLogin on Users.ID = UsersLogin.ID where UsersLogin.Active like 'waiting'";
                MySqlCommand check = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = check.ExecuteReader();
                while (reader.Read() && i < 5)
                {
                    wait = wait + reader["ID"] + ";" + reader["FirstName"] + ";" + reader["LastName"] + "";
                    help = reader["BirthDate"] + "";
                    forAge = DateTime.Parse(help);

                    if (System.DateTime.Today.Year >= forAge.Year && System.DateTime.Today.Month >= forAge.Month && System.DateTime.Today.Day >= forAge.Day)
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

        /// <summary>
        /// if admin confirm user registration
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userRole"></param>
        /// <param name="active"></param>
        /// <returns></returns>
        public bool writeUserAsActive(string id, string userRole, string active)
        {
            if (openConnection())
            {
                string sqlQuery = "update UsersLogin set Active = @active, UserRole = @userrole where id like " + id;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.Parameters.AddWithValue("@userrole", userRole);
                cmd.ExecuteNonQuery();
                closeConnection();
                return true;
            }
            return false;
        }

        /// <summary>
        /// admin can block user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="active"></param>
        /// <returns></returns>
        public bool blockUser(string id, string active)
        {
            if (openConnection())
            {
                string sqlQuery = "update UsersLogin set Active = @active where id like " + id;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.ExecuteNonQuery();
                closeConnection();
                return true;
            }
            return false;
        }

        /// <summary>
        /// find details of one user by id
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public string findUserByID(string userID)
        {
            string details = null, help;
            DateTime forAge = new DateTime();
            if (openConnection())
            {
                string sqlQuery = "select * from Users inner join UsersDetails on Users.ID = UsersDetails.ID inner join "
                    + "UsersLogin on Users.ID = UsersLogin.ID where Users.ID like " + userID;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

               
                while (reader.Read())
                {
                    details = reader["ID"] + ";" + reader["FirstName"] + ";" + reader["LastName"] + ";";
                    help = reader["BirthDate"] + "";
                    forAge = DateTime.Parse(help);

                    if (System.DateTime.Today.Month <= forAge.Month && System.DateTime.Today.Day <= forAge.Day)
                    {
                        help = (System.DateTime.Today.Year - forAge.Year).ToString();
                    }
                    else
                    {
                        help = (System.DateTime.Today.Year - forAge.Year - 1).ToString();
                    }
                    details = details + help + ";" + reader["email"] + ";" + reader["UserRole"] + ";" + reader["Active"] + ";"
                        + reader["Street"] + ";" + reader["StreetNumber"] + ";" + reader["PostalCode"] + ";" + reader["City"] + ";" + reader["Country"]
                        + ";" + reader["Telephone"];
                }
                closeConnection();
                return details;
            }
            return details;
        }

        /// <summary>
        /// find details of one user by his first name
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public string findUserByFirstName(string firstName)
        {
            string details = null, help;
            DateTime forAge = new DateTime();
            if (openConnection())
            {
                string sqlQuery = "select * from Users inner join UsersDetails on Users.ID = UsersDetails.ID inner join "
                    + "UsersLogin on Users.ID = UsersLogin.ID where Users.FirstName like '" + firstName + "'";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    details = reader["ID"] + ";" + reader["FirstName"] + ";" + reader["LastName"] + ";";
                    help = reader["BirthDate"] + "";
                    forAge = DateTime.Parse(help);

                    if (System.DateTime.Today.Year >= forAge.Year && System.DateTime.Today.Month >= forAge.Month && System.DateTime.Today.Day >= forAge.Day)
                    {
                        help = (System.DateTime.Today.Year - forAge.Year).ToString();
                    }
                    else
                    {
                        help = (System.DateTime.Today.Year - forAge.Year - 1).ToString();
                    }
                    details = details + help + ";" + reader["email"] + ";" + reader["UserRole"] + ";" + reader["Active"] + ";"
                        + reader["Street"] + ";" + reader["StreetNumber"] + ";" + reader["PostalCode"] + ";"
                        + reader["City"] + ";" + reader["Country"] + ";" + reader["Telephone"];
                }
                closeConnection();
                return details;
            }
            return details;
        }

        /// <summary>
        ///  update user info
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool updateUserData(string data)
        {
            string userID, firstName, lastName, email, userRole, active, street, streetNumber, postalCode, city, country, telephone;
            string[] items;
            items = data.Split(';');

            userID = items[0];
            firstName = items[1];
            lastName = items[2];
            email = items[3];
            userRole = items[4];
            active = items[5];
            street = items[6];
            streetNumber = items[7];
            postalCode = items[8];
            city = items[9];
            country = items[10];
            telephone = items[11];

            if (openConnection())
            {
                string sqlQuery = "update Users set FirstName = @firstName, LastName = @lastName where ID like " + userID;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.ExecuteNonQuery();

                sqlQuery = "update UsersLogin set email = @email, UserRole = @userRole, Active = @active where ID like " + userID;
                cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@userRole", userRole);
                cmd.Parameters.AddWithValue("@active", active);
                cmd.ExecuteNonQuery();

                sqlQuery = "update UsersDetails set Street = @street, StreetNumber = @streetnumber, PostalCode = @postalcode, "
                    + "City = @city, Telephone = @telephone, Country = @country where ID like " + userID;
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
            return false;
        }

        /// <summary>
        /// get old password of user
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public string getOldPassword(string userID)
        {
            string password = null;
            if (openConnection())
            {
                string sqlQuery = "select PASSWORD from UsersLogin where ID like " + userID;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    password = reader["PASSWORD"].ToString();
                }
                closeConnection();
                return password;
            }
            return password;
        }

        /// <summary>
        /// set new password
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool changeUserPassword(string userID, string password)
        {
            if (openConnection())
            {
                string sqlQuery = "update UsersLogin set PASSWORD = @password where ID like @id";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@id", userID);
                cmd.ExecuteNonQuery();

                closeConnection();
                return true;
            }
            return false;
        }

        /// <summary>
        /// enable upload user's profile image from his pc
        /// </summary>
        /// <param name="image"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool uploadUserImage(string image, string userID)
        {
            byte[] imageBT = null;
            FileStream fStream = new FileStream(image, FileMode.Open, FileAccess.Read);
            BinaryReader bRead = new BinaryReader(fStream);
            imageBT = bRead.ReadBytes((int)fStream.Length);

            if (openConnection())
            {
                string sqlQuery = "update Users set Avatar = @avatar where ID like @userID";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@avatar", imageBT);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.ExecuteNonQuery();

                closeConnection();
                return true;
            }
            return false;
        }

        /// <summary>
        ///  for deleting users from database, if users delete his account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deleteUserFromDatabase(string id)
        {
            if (openConnection())
            {
                string sqlQuery = "delete from Users where id like @id";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                closeConnection();
                return true;
            }
            return false;
        }

        /// <summary>
        ///  searching bookname, author, status, category and language of books according search parameters
        /// </summary>
        /// <param name="search"></param>
        /// <param name="free"></param>
        /// <param name="categories"></param>
        /// <param name="languages"></param>
        /// <returns></returns>
        public List<string> searchBooksToListView(string search, bool free, string categories, string languages)
        {
            if (categories != null && languages == null)
            {
                string[] category;
                category = categories.Split(';');

                List<string> books = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    for (int i = 0; i < (category.Length) - 1; i++)
                    {
                        if (free == true)
                        {
                            sqlQuery = "SELECT BookName, Author, Borrowings, CategoryName, LanguageName FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Borrowings LIKE 'free' and CategoryName like '" + category[i] + "'";
                        }
                        else
                        {
                            sqlQuery = "SELECT BookName, Author, Borrowings, CategoryName, LanguageName FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and CategoryName like '" + category[i] + "'";
                        }
                        MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            books.Add(reader["BookName"].ToString());
                            books.Add(reader["Author"].ToString());
                            books.Add(reader["Borrowings"].ToString());
                            books.Add(reader["CategoryName"].ToString());
                            books.Add(reader["LanguageName"].ToString());
                        }
                        reader.Close();
                    }
                    closeConnection();
                    return books;
                }
                return books;
            }
            else if (categories == null && languages != null)
            {
                string[] language;
                language = languages.Split(';');

                List<string> books = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    for (int i = 0; i < (language.Length) - 1; i++)
                    {
                        if (free == true)
                        {
                            sqlQuery = "SELECT BookName, Author, Borrowings, CategoryName, LanguageName FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Borrowings LIKE 'free' and LanguageName like '" + language[i] + "'";
                        }
                        else
                        {
                            sqlQuery = "SELECT BookName, Author, Borrowings, CategoryName, LanguageName FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and LanguageName like '" + language[i] + "'";
                        }
                        MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            books.Add(reader["BookName"].ToString());
                            books.Add(reader["Author"].ToString());
                            books.Add(reader["Borrowings"].ToString());
                            books.Add(reader["CategoryName"].ToString());
                            books.Add(reader["LanguageName"].ToString());
                        }
                        reader.Close();
                    }
                    closeConnection();
                    return books;
                }
                return books;
            }
            else if (categories != null && languages != null)
            {
                string[] language, category;
                language = languages.Split(';');
                category = categories.Split(';');

                List<string> books = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    for (int i = 0; i < (language.Length) - 1; i++)
                    {
                        for (int j = 0; j < (category.Length) - 1; j++)
                        {
                            if (free == true)
                            {
                                sqlQuery = "SELECT BookName, Author, Borrowings, CategoryName, LanguageName FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Borrowings LIKE 'free' and LanguageName like '" + language[i] + "' and CategoryName like '" + category[j] + "'";
                            }
                            else
                            {
                                sqlQuery = "SELECT BookName, Author, Borrowings, CategoryName, LanguageName FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and LanguageName like '" + language[i] + "' and CategoryName like '" + category[j] + "'";
                            }
                            MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                            MySqlDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                books.Add(reader["BookName"].ToString());
                                books.Add(reader["Author"].ToString());
                                books.Add(reader["Borrowings"].ToString());
                                books.Add(reader["CategoryName"].ToString());
                                books.Add(reader["LanguageName"].ToString());
                            }
                            reader.Close();
                        }
                    }
                    closeConnection();
                    return books;
                }
                return books;
            }
            else /*if (categories == null && languages == null)*/
            {
                List<string> books = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    if (free == true)
                    {
                        sqlQuery = "SELECT BookName, Author, Borrowings, CategoryName, LanguageName FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Borrowings LIKE 'free'";
                    }
                    else
                    {
                        sqlQuery = "SELECT BookName, Author, Borrowings, CategoryName, LanguageName FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%')";
                    }
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        books.Add(reader["BookName"].ToString());
                        books.Add(reader["Author"].ToString());
                        books.Add(reader["Borrowings"].ToString());
                        books.Add(reader["CategoryName"].ToString());
                        books.Add(reader["LanguageName"].ToString());
                    }
                    closeConnection();
                    return books;
                }
                return books;
            }
        }

        /// <summary>
        ///  find details about book according its name
        /// </summary>
        /// <param name="bookName"></param>
        /// <returns></returns>
        public List<string> bookDetails(string bookName)
        {
            List<string> bookDetail = new List<string>();
            if (openConnection())
            {
                string sqlQuery = "select * from Books inner join BooksDetails on Books.ID = BooksDetails.ID where Books.BookName like '" + bookName + "'";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    bookDetail.Add(reader["ID"] + "");
                    bookDetail.Add(reader["BookName"] + "");
                    bookDetail.Add(reader["Author"] + "");
                    bookDetail.Add(reader["Borrowings"].ToString());
                    bookDetail.Add(reader["IDCategory"] + "");
                    bookDetail.Add(reader["IDLanguage"] + "");
                    bookDetail.Add(reader["Description"] + "");
                    bookDetail.Add(reader["ISBN"] + "");
                    bookDetail.Add(reader["Publisher"] + "");
                }
                closeConnection();
                return bookDetail;
            }
            return bookDetail;
        }

        /// <summary>
        ///  find book language according its id
        /// </summary>
        /// <param name="languageID"></param>
        /// <returns></returns>
        public string bookLanguage(string languageID)
        {
            string bookLanguage = null;
            if (openConnection())
            {
                string sqlQuery = "select LanguageName from BookLanguage where ID like " + languageID;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    bookLanguage = reader["LanguageName"] + "";
                }
                closeConnection();
            }
            return bookLanguage;
        }

        /// <summary>
        /// find book category according its id
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public string bookCategory(string categoryID)
        {
            string bookCategory = null;
            if (openConnection())
            {
                string sqlQuery = "select CategoryName from BookCategory where ID like " + categoryID;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    bookCategory = reader["CategoryName"] + "";
                }
                closeConnection();
            }
            return bookCategory;
        }


        /*** START BOOKS INSERT TO DATABASE ***/
        /// <summary>
        ///  add Book Category To database
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <returns></returns>
        public bool addBookCategory(string CategoryName)
        {
            try
            {
                if (openConnection())
                {
                    string sqlQuery = "Insert into BookCategory (CategoryName) VALUES (@CategoryName)";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
                    cmd.ExecuteNonQuery();
                    closeConnection();
                    return true;
                }


                return false;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }

        }

        /// <summary>
        ///  add Book Language To database
        /// </summary>
        /// <param name="LanguageName"></param>
        /// <returns></returns>
        public bool addBookLanguage(string LanguageName)
        {
            try
            {
                if (openConnection())
                {
                    string sqlQuery = "Insert into BookLanguage (LanguageName) VALUES (@LanguageName)";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("@LanguageName", LanguageName);
                    cmd.ExecuteNonQuery();
                    closeConnection();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }

        }

        /// <summary>
        /// load CategoryName from database
        /// </summary>
        /// <returns></returns>
        public List<string> loadBookCategoryName()
        {
            List<string> sCategoryName = new List<string>();
            String sqlQuery = "select id, categoryname from BookCategory";

            if (openConnection())
            {

                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    sCategoryName.Add(reader["ID"] + " " + reader["categoryname"]);
                }

                closeConnection();
                return sCategoryName;
            }
            return null;
        }

        /// <summary>
        /// find book ID according it's name
        /// </summary>
        /// <param name="bookName"></param>
        /// <returns></returns>
        public string findBookID(string bookName)
        {
            if (openConnection())
            {
                string bookID = null;
                string sqlQuery = "select ID from Books where BookName like '" + bookName + "'";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    bookID = reader["ID"].ToString();
                }
                closeConnection();
                return bookID;
            }
            return null;
        }

        /// <summary>
        /// get bookimage from database and show it in bookdetailsform
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public byte[] getImageByBookId(String id)
        {
            byte[] imageBytes = null;
            String sqlQuery = "select Image from BooksDetails where ID = " + id;
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    imageBytes = (byte[])reader["Image"];
                }
            }
            closeConnection();
            return imageBytes;
        }



        /// <summary>
        /// load LanguageName from database
        /// </summary>
        /// <returns></returns>
        public List<string> loadBookLanguageName()
        {
            List<string> sLanguageName = new List<string>();
            String sqlQuery = "select id, languagename from BookLanguage";

            if (openConnection())
            {

                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    sLanguageName.Add(reader["ID"] +" "+ reader["languagename"]);
                }

                closeConnection();
                return sLanguageName;
            }

            return null;

        }

        /// <summary>
        ///  add book to database
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="bookAuthor"></param>
        /// <param name="IDCategory"></param>
        /// <param name="IDLanguage"></param>
        /// <param name="image"></param>
        /// <param name="ISBN"></param>
        /// <param name="publisher"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public bool addBook(string bookName, string bookAuthor, string IDCategory, string IDLanguage, string image, string ISBN, string publisher, string description)
        {        
                if (openConnection())
                {
                    //insert books
                    string sqlQuery = "Insert into Books (BookName,Author, IDCategory, IDLanguage) Values (@bookName, @bookAuthor, @IDCategory, @IDLanguage )";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("@bookName", bookName);
                    cmd.Parameters.AddWithValue("@bookAuthor", bookAuthor);
                    cmd.Parameters.AddWithValue("@IDCategory", IDCategory);
                    cmd.Parameters.AddWithValue("@IDLanguage", IDLanguage);
                    cmd.ExecuteNonQuery();


                    ///<summary> insert book details</summary>
                    byte[] imageBT = null;
                    FileStream fstream = new FileStream(image, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fstream);
                    imageBT = br.ReadBytes((int)fstream.Length);

                    sqlQuery = "Insert into BooksDetails (Image,Description,ISBN,Publisher) Values (@image,@description, @ISBN, @publisher)";
                    cmd = new MySqlCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("@image", imageBT);
                    cmd.Parameters.AddWithValue("@ISBN", ISBN);
                    cmd.Parameters.AddWithValue("@publisher", publisher);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.ExecuteNonQuery();

                    closeConnection();
                    return true;
                }

                return false;

        }
        /*** END BOOK Insert to database ***/

        /*** START Update Book ***/
        /// <summary>
        /// update book details without by admin
        /// </summary>
        /// <param name="data"></param>
        /// <param name="IDCategory"></param>
        /// <param name="IDLanguage"></param>
        /// <returns></returns>
        public bool updateBookdetailsDataWithOutImage(string data, string IDCategory, string IDLanguage)
        {
            string bookID, bookName, author, desc, publisher, ISBN;
            string[] descrpition;
            string[] items;
            items = data.Split(';');

            bookID = items[0];
            bookName = items[1];
            author = items[2];
            ISBN = items[3];
            publisher = items[4];
            desc = items[5];       

            descrpition = desc.Split('.');      

                if (openConnection())
                {
                string sqlQuery = "update Books set BookName = @bookName, Author = @author, IDCategory = @IDcategory, IDLanguage = @IDLanguage where ID like " + bookID;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@BookName", bookName);
                cmd.Parameters.AddWithValue("@author", author);
                cmd.Parameters.AddWithValue("@IDCategory", IDCategory);
                cmd.Parameters.AddWithValue("@IDLanguage", IDLanguage);
                cmd.ExecuteNonQuery();

                sqlQuery = "update BooksDetails set ISBN = @ISBN, Publisher = @publisher, description = @desc where ID like " + bookID;
                cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@ISBN", ISBN);
                cmd.Parameters.AddWithValue("@publisher", publisher);
                cmd.Parameters.AddWithValue("@desc", desc);
                cmd.ExecuteNonQuery();

                closeConnection();
                return true;
            }
            return false;

        }

        /// <summary>
        /// update bookdetails with image
        /// </summary>
        /// <param name="data"></param>
        /// <param name="image"></param>
        /// <param name="IDCategory"></param>
        /// <param name="IDLanguage"></param>
        /// <returns></returns>
        public bool updateBookdetailsDataWithImage(string data, string image, string IDCategory, string IDLanguage)
        {
            string bookID, bookName, author, desc, publisher, ISBN;
            string[] descrpition;
            string[] items;
            items = data.Split(';');

            bookID = items[0];
            bookName = items[1];
            author = items[2];
            ISBN = items[3];
            publisher = items[4];
            desc = items[5];

            descrpition = desc.Split('.');

            if (openConnection())
            {
                string sqlQuery = "update Books set BookName = @bookName, Author = @author, IDCategory = @IDcategory, IDLanguage = @IDLanguage where ID like " + bookID;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@BookName", bookName);
                cmd.Parameters.AddWithValue("@author", author);
                cmd.Parameters.AddWithValue("@IDCategory", IDCategory);
                cmd.Parameters.AddWithValue("@IDLanguage", IDLanguage);
                cmd.ExecuteNonQuery();

                byte[] imageBT = null;
                FileStream fstream = new FileStream(image, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBT = br.ReadBytes((int)fstream.Length);

                sqlQuery = "update BooksDetails set ISBN = @ISBN, Publisher = @publisher, description = @desc, image = @image where ID like " + bookID;
                cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@image", imageBT);
                cmd.Parameters.AddWithValue("@ISBN", ISBN);
                cmd.Parameters.AddWithValue("@publisher", publisher);
                cmd.Parameters.AddWithValue("@desc", desc);
                cmd.ExecuteNonQuery();

                closeConnection();
                return true;
            }
            return false;

        }

        /*** END UPDATE BOOK ***/

        /*** Delete book from database ***/
        /// <summary>
        /// delete book from DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deleteBookFromDatabase(string id)
        {
            if (openConnection())
            {
                string sqlQuery = "delete from Books where id like @id";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                closeConnection();
                return true;
            }
            return false;
        }



        /*** START OF BORROWINGS QUERIES ***/

        /// <summary>
        ///  Add borrowings into database
        /// </summary>
        /// <param name="dateOfBorrow"></param>
        /// <param name="dateOfReturn"></param>
        /// <param name="bookID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool addBorrowing(string dateOfBorrow, string dateOfReturn, string bookID, string userID)
        {
            if (openConnection())
            {
                string sqlQuery = "insert into Borrowings (DateOfBorrow, DateOfReturn, IDBook, IDUser) values (@dateOfBorrow, @dateOfReturn, @bookID, @userID)";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@dateOfBorrow", dateOfBorrow);
                cmd.Parameters.AddWithValue("@dateOfReturn", dateOfReturn);
                cmd.Parameters.AddWithValue("@bookID", bookID);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.ExecuteNonQuery();

                sqlQuery = "update Books set Borrowings = @borrowings where ID = " + bookID;
                cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@borrowings", "borrowed");
                cmd.ExecuteNonQuery();

                closeConnection();
                return true;
            }
            return false;
        }

        /// <summary>
        /// deleting borrowings
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        public bool removeBorrowing(string bookID)
        {
            if (openConnection())
            {
                string sqlQuery = "delete from Borrowings where IDBook like @BookID";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@BookID", bookID);
                cmd.ExecuteNonQuery();

                sqlQuery = "update Books set Borrowings = @borrowings where ID = " + bookID;
                cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@borrowings", "free");
                cmd.ExecuteNonQuery();

                closeConnection();
                return true;
            }
            return false;
        }

        /// <summary>
        /// deleting book from entity ReservedBooks after succesful lent
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        public bool dropBookFromReservations(string bookID)
        {
            if (openConnection())
            {
                string sqlQuery = "delete from ReservedBooks where IDBook like @BookID";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@BookID", bookID);
                cmd.ExecuteNonQuery();

                sqlQuery = "update Books set Borrowings = @borrowings where ID = " + bookID;
                cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@borrowings", "free");
                cmd.ExecuteNonQuery();

                closeConnection();
                return true;
            }
            return false;
        }

        /// <summary>
        ///  return list of lent and reservationd details 
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="onlyReserved"></param>
        /// <returns></returns>
        public List<string> checkBorrowingsAndReservations(string bookName, bool onlyReserved)
        {
            DateTime date = new DateTime();
            string stringDate = null;
            List<string> list = new List<string>();
            if (openConnection())
            {
                if (onlyReserved == false)
                {
                    string sqlQuery = "select BookName, FirstName, LastName, Borrowings, DateofBorrow, DateOfReturn from Books inner join"
                        + " Borrowings on Books.ID = Borrowings.IDBook inner join Users on Users.ID = Borrowings.IDUser where Books.BookName"
                        + " like '%" + bookName + "%'";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader["BookName"].ToString());
                        list.Add(reader["FirstName"] + " " + reader["LastName"]);
                        list.Add(reader["Borrowings"].ToString());

                        date = DateTime.Parse(reader["DateOfBorrow"].ToString());
                        stringDate = date.Day + "." + date.Month + "." + date.Year;
                        list.Add(stringDate);

                        date = DateTime.Parse(reader["DateOfReturn"].ToString());
                        stringDate = date.Day + "." + date.Month + "." + date.Year;
                        list.Add(stringDate);
                    }
                    reader.Close();

                    sqlQuery = "select BookName, FirstName, LastName, Borrowings from Books inner join"
                        + " ReservedBooks on Books.ID = ReservedBooks.IDBook inner join Users on Users.ID = ReservedBooks.IDUser"
                        + " where Books.BookName like '%" + bookName + "%'";
                    cmd = new MySqlCommand(sqlQuery, connection);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader["BookName"].ToString());
                        list.Add(reader["FirstName"] + " " + reader["LastName"]);
                        list.Add(reader["Borrowings"].ToString());
                        list.Add("---");
                        list.Add("---");
                    }
                    closeConnection();
                    return list;
                }
                else
                {
                    string sqlQuery = "select BookName, FirstName, LastName, Borrowings from Books inner join"
                        + " ReservedBooks on Books.ID = ReservedBooks.IDBook inner join Users on Users.ID = ReservedBooks.IDUser"
                        + " where Books.BookName like '%" + bookName + "%'";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader["BookName"].ToString());
                        list.Add(reader["FirstName"] + " " + reader["LastName"]);
                        list.Add(reader["Borrowings"].ToString());
                        list.Add("---");
                        list.Add("---");
                    }
                    closeConnection();
                    return list;
                }
            }
            return list;
        }

        /// <summary>
        /// show all borrowings in admin part for checking borrowings
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<string> checkUserBorrowingsAndReservation(string UserID)
        {
            DateTime date = new DateTime();
            string stringDate = null;
            List<string> list = new List<string>();
            if (openConnection())
            {
                string sqlQuery = "select BookName, Author, Borrowings, DateOfBorrow, DateOfReturn from Books inner join"
                        + " Borrowings on Books.ID = Borrowings.IDBook inner join Users on Users.ID = Borrowings.IDUser where"
                        + " Borrowings.IDUser like " + UserID;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader["BookName"].ToString());
                    list.Add(reader["Author"].ToString());
                    list.Add(reader["Borrowings"].ToString());

                    date = DateTime.Parse(reader["DateOfBorrow"].ToString());
                    stringDate = date.Day + "." + date.Month + "." + date.Year;
                    list.Add(stringDate);

                    date = DateTime.Parse(reader["DateOfReturn"].ToString());
                    stringDate = date.Day + "." + date.Month + "." + date.Year;
                    list.Add(stringDate);
                }
                reader.Close();

                sqlQuery = "select BookName, Author, Borrowings from Books inner join"
                    + " ReservedBooks on Books.ID = ReservedBooks.IDBook inner join Users on Users.ID = ReservedBooks.IDUser"
                    + " where ReservedBooks.IDUser like " + UserID;
                cmd = new MySqlCommand(sqlQuery, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader["BookName"].ToString());
                    list.Add(reader["Author"].ToString());
                    list.Add(reader["Borrowings"].ToString());
                    list.Add("---");
                    list.Add("---");
                }
                closeConnection();
                return list;
            }
            return list;
        }

        /// <summary>
        /// reserve book by User
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool reserveBook(string bookID, string userID)
        {
            if (openConnection())
            {
                string sqlQuery = "insert into ReservedBooks (IDBook, IDUser) values (@IDBook, @IDUser)";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IDBook", bookID);
                cmd.Parameters.AddWithValue("@IDUser", userID);
                cmd.ExecuteNonQuery();

                sqlQuery = "update Books set Borrowings = @borrowings where ID = " + bookID;
                cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@borrowings", "reserved");
                cmd.ExecuteNonQuery();

                closeConnection();
                return true;
            }
            return false;
        }

        /// <summary>
        ///  delete reservation of book
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool deleteReservation(string bookID, string userID)
        {
            if (openConnection())
            {
                string sqlQuery = "delete from ReservedBooks where IDBook = @IDBook and IDUser = @IDUser";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IDBook", bookID);
                cmd.Parameters.AddWithValue("@IDUser", userID);
                cmd.ExecuteNonQuery();

                sqlQuery = "update Books set Borrowings = @borrowings where ID = " + bookID;
                cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@borrowings", "free");
                cmd.ExecuteNonQuery();


                closeConnection();
                return true;
            }
            return false;
        }

        /// <summary>
        /// check state of book, if it is free
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        public bool checkIfBookIsFree(string bookID)
        {
            if (openConnection())
            {
                string sqlQuery = "select Borrowings from Books where ID like @bookID";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@bookId", bookID);

                MySqlDataReader reader = cmd.ExecuteReader();
                bool result = false;
                if (reader.Read())
                {
                    result = reader["Borrowings"].ToString().Equals("free");
                }

                closeConnection();
                return result;
            }
            return true;
       }

        /// <summary>
        /// check if is book reserve
        /// </summary>
        /// <param name="IDBook"></param>
        /// <param name="IDUser"></param>
        /// <param name="loan"></param>
        /// <returns></returns>
        public bool checkBookisReservedByUser(string IDBook, string IDUser, string loan)
        {
            bool result = false;
            if (openConnection())
            {
                string sqlQuery = null;
                if (loan == "reserved")
                {
                    sqlQuery = "select Borrowings, IDUser from Books INNER JOIN ReservedBooks ON Books.ID=ReservedBooks.IDBook"
                        + " where Books.ID like " + IDBook;
                }
                else if (loan == "borrowed")
                {
                    sqlQuery = "select Borrowings, IDUser from Books INNER JOIN Borrowings ON Books.ID=Borrowings.IDBook"
                        + " where Books.ID like " + IDBook;
                }
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Borrowings"].ToString().Equals("reserved") || reader["Borrowings"].ToString().Equals("borrowed"))
                    {
                        result = reader["IDUser"].ToString().Equals(IDUser);
                    }
                }

                closeConnection();
                return result;
            }
            return result;
        }

        /// <summary>
        /// finds date of return one loan, for setting penalty
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DateTime checkBorrowingDate(string bookID, string userID)
        {
            DateTime borrowings = new DateTime();
            if (openConnection())
            {
                string sqlQuery = "select DateOfReturn from Borrowings where IDBook like " + bookID + " and IDUser like " + userID;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    borrowings = DateTime.Parse(reader["DateOfReturn"].ToString());
                }
                closeConnection();
                return borrowings;
            }
            return borrowings;
        }

        /// <summary>
        /// finds and returns all loans to check, if there are any loans longer than 2 months to block these users
        /// </summary>
        /// <returns></returns>
        public List<string> checkBorrowings()
        {
            List<string> borrowings = new List<string>();

            if (openConnection())
            {
                DateTime date = new DateTime();
                string stringDate;
                string sqlQuery = "select DateOfReturn, IDUser from Borrowings";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    date = DateTime.Parse(reader["DateOfReturn"].ToString());
                    stringDate = date.Day + "." + date.Month + "." + date.Year;
                    
                    borrowings.Add(stringDate);
                    borrowings.Add(reader["IDUser"].ToString());
                }
                closeConnection();
                return borrowings;
            }
            return borrowings;
        }

        /// <summary>
        /// generate XML file
        /// </summary>
        /// <returns></returns>
        public bool CreateXML()
        {
            if (openConnection())
            {
                DataSet ds = new DataSet();
                string sqlQuery = "select * from Borrowings";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, connection);

                adapter.Fill(ds);
                closeConnection();
                ds.WriteXml("Borrowings.xml");
                return true;
            }
            return false;
        }

        /// <summary>
        /// get penalties to user if is some
        /// </summary>
        /// <param name="caseOfPenalty"></param>
        /// <returns></returns>
        public string getPenalty(int caseOfPenalty)
        {
            string penalty = null;
            if (openConnection())
            {
                string sqlQuery = "select Price from Penalties where ID like " + caseOfPenalty;
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    penalty = reader["Price"].ToString();
                }
                closeConnection();
                return penalty;
            }
            return penalty;
        }

        /// <summary>
        /// displej penalties from DB
        /// </summary>
        /// <returns></returns>
        public List<string> getPenalties()
        {
            List<string> penalties = new List<string>();
            if (openConnection())
            {
                string sqlQuery = "select Price from Penalties";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    penalties.Add(reader["Price"].ToString());
                }
                closeConnection();
                return penalties;
            }
            return penalties;
        }

        /// <summary>
        /// update penalties
        /// </summary>
        /// <param name="penalties"></param>
        /// <returns></returns>
        public bool updatePenalties(List<string> penalties)
        {
            if (openConnection())
            {
                string sqlQuery;
                MySqlCommand cmd;
                for (int i = 0;i < penalties.Count; i++)
                {
                    sqlQuery = "update Penalties set Price = @price where ID like @ID";
                    cmd = new MySqlCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("@price", penalties[i]);
                    cmd.Parameters.AddWithValue("@ID", i + 1);
                    cmd.ExecuteNonQuery();
                }
                closeConnection();
                return true;
            }
            return false;
        }
    }
}
