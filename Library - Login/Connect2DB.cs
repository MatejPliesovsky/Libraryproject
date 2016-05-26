using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

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
        private string booksDetailsEntity = "`BooksDetails`";
        private string bookCategoryEnity = "`BookCategory`";
        private string bookLanguageEnity = "`BookLanguage`";
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

        // verification if user is already registered
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
                string sqlQuery = "select UserRole from " + loginEntity + " where email like '" + email + "'";
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

        // verification if is user blocked
        public bool isUserBlocked(string email)
        {
            string status = null;
            if (openConnection())
            {
                string sqlQuery = "select Active from UsersLogin where email like '" + email + "'";
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

        // verification if user is admin or not according his id
        public string getUserRole(string userID)
        {
            string userRole = null;
            if (openConnection())
            {
                string sqlQuery = "select UserRole from " + loginEntity + " where ID like " + userID + "";
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

        // find all user ID according their name
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

        // START OF ADMIN - USER METHODS

        // find all users IDs
        public List<string> getUsersID(string search)
        {
            List<string> usersID = new List<string>();
            string sqlQuery = "select ID from Users where FirstName like '%" + search + "%' or LastName like '%" + search + "%'";
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usersID.Add(reader["ID"] + "");
                }
                closeConnection();
            }
            return usersID;
        }

        // find all users first names
        public List<string> getUsersFirstName(string search)
        {
            List<string> usersFirstNames = new List<string>();
            string sqlQuery = "select FirstName from Users where FirstName like '%" + search + "%' or LastName like '%" + search + "%'";
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usersFirstNames.Add(reader["FirstName"] + "");
                }
                closeConnection();
            }
            return usersFirstNames;
        }

        // find all users last names
        public List<string> getUsersLastName(string search)
        {
            List<string> usersLastNames = new List<string>();
            string sqlQuery = "select LastName from Users where FirstName like '%" + search + "%' or LastName like '%" + search + "%'";
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usersLastNames.Add(reader["LastName"] + "");
                }
                closeConnection();
            }
            return usersLastNames;
        }

        // find all users ages
        public List<string> getUsersAge(string search)
        {
            List<string> usersAges = new List<string>();
            string help;
            DateTime forAge = new DateTime();
            string age;
            string sqlQuery = "select BirthDate from Users where FirstName like '%" + search + "%' or LastName like '%" + search + "%'";
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    help = reader["BirthDate"] + "";
                    forAge = DateTime.Parse(help);
                    if (System.DateTime.Today.Year == forAge.Year && System.DateTime.Today.Month <= forAge.Month && System.DateTime.Today.Day <= forAge.Day)
                    {
                        age = (System.DateTime.Today.Year - forAge.Year).ToString();
                    }
                    else
                    {
                        age = (System.DateTime.Today.Year - forAge.Year - 1).ToString();
                    }

                    usersAges.Add(age);
                }
                closeConnection();
            }
            return usersAges;
        }

        // find all users emails
        public List<string> getUsersEmails(string search)
        {
            List<string> usersEmails = new List<string>();
            string sqlQuery = "select email from UsersLogin inner join Users where FirstName like '%" + search + "%' or LastName like '%" + search + "%'";
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usersEmails.Add(reader["email"] + "");
                }
                closeConnection();
            }
            return usersEmails;
        }

        // find all users roles
        public List<string> getUsersRoles(string search)
        {
            List<string> usersRoles = new List<string>();
            string sqlQuery = "select UserRole from UsersLogin inner join Users where FirstName like '%" + search + "%' or LastName like '%" + search + "%'";
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usersRoles.Add(reader["UserRole"] + "");
                }
                closeConnection();
            }
            return usersRoles;
        }

        // find all users status (active, inactive or blocked)
        public List<string> getUsersStatus(string search)
        {
            List<string> usersStatus = new List<string>();
            string sqlQuery = "select Active from UsersLogin inner join Users where FirstName like '%" + search + "%' or LastName like '%" + search + "%'";
            if (openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usersStatus.Add(reader["Active"] + "");
                }
                closeConnection();
            }
            return usersStatus;
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
                string sqlQuery = "select " + usersEntity + ".ID, " + usersEntity + ".FirstName, " + usersEntity + ".LastName, "
                    + usersEntity + ".BirthDate, " + loginEntity + ".email from " + usersEntity + " inner join "
                    + loginEntity + "on " + usersEntity + ".ID = " + loginEntity + ".ID where "
                    + loginEntity + ".Active like 'waiting'";
                MySqlCommand check = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = check.ExecuteReader();
                while (reader.Read() && i < 5)
                {
                    wait = wait + reader["ID"] + ";" + reader["FirstName"] + ";" + reader["LastName"] + "";
                    help = reader["BirthDate"] + "";
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

        // find details of one user by id
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

                    if (System.DateTime.Today.Year == forAge.Year && System.DateTime.Today.Month <= forAge.Month && System.DateTime.Today.Day <= forAge.Day)
                    {
                        help = (System.DateTime.Today.Year - forAge.Year).ToString();
                    }
                    else
                    {
                        help = (System.DateTime.Today.Year - forAge.Year - 1).ToString();
                    }
                    details = details + help + ";" + reader["email"] + ";" + reader["UserRole"] + ";" + reader["Active"] + ";"
                        + reader["Street"] + ";" + reader["StreetNumber"] + ";" + reader["City"] + ";" + reader["Country"]
                        + ";" + reader["Telephone"];
                }
                closeConnection();
                return details;
            }
            return details;
        }

        // find details of one user by his first name
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

                    if (System.DateTime.Today.Year == forAge.Year && System.DateTime.Today.Month <= forAge.Month && System.DateTime.Today.Day <= forAge.Day)
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

        // update user info
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
        public List<string> searchBookNames(string search, bool free, string categories, string languages)
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
                            sqlQuery = "SELECT BookName FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Lent LIKE 'free' and CategoryName like '" + category[i] + "'";
                        }
                        else
                        {
                            sqlQuery = "SELECT BookName FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and CategoryName like '" + category[i] + "'";
                        }
                        MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            books.Add((reader["BookName"].ToString()));
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
                            sqlQuery = "SELECT BookName FROM Books inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Lent LIKE 'free' and LanguageName like '" + language[i] + "'";
                        }
                        else
                        {
                            sqlQuery = "SELECT BookName FROM Books inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and LanguageName like '" + language[i] + "'";
                        }
                        MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            books.Add((reader["BookName"].ToString()));
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
                                sqlQuery = "SELECT BookName FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Lent LIKE 'free' and LanguageName like '" + language[i] + "' and CategoryName like '" + category[j] + "'";
                            }
                            else
                            {
                                sqlQuery = "SELECT BookName FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and LanguageName like '" + language[i] + "' and CategoryName like '" + category[j] + "'";
                            }
                            MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                            MySqlDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                books.Add((reader["BookName"].ToString()));
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
                        sqlQuery = "SELECT BookName FROM Books where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Lent LIKE 'free'";
                    }
                    else
                    {
                        sqlQuery = "SELECT BookName FROM Books where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%')";
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
        }

        // searching Author according search parameters
        public List<string> searchAuthor(string search, bool free, string categories, string languages)
        {
            if (categories != null && languages == null)
            {
                string[] category;
                category = categories.Split(';');

                List<string> authors = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    for (int i = 0; i < (category.Length) - 1; i++)
                    {
                        if (free == true)
                        {
                            sqlQuery = "select Author from Books inner join BookCategory on Books.IDCategory = BookCategory.ID where (BookName like '%" + search + "%' or Author like '%" + search + "%') and Lent LIKE 'free' and CategoryName like '" + category[i] + "'";
                        }
                        else
                        {
                            sqlQuery = "SELECT Author FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and CategoryName like '" + category[i] + "'";
                        }
                        MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            authors.Add((reader["Author"].ToString()));
                        }
                        reader.Close();
                    }
                    closeConnection();
                    return authors;
                }
                return authors;
            }
            else if (categories == null && languages != null)
            {
                string[] language;
                language = languages.Split(';');

                List<string> authors = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    for (int i = 0; i < (language.Length) - 1; i++)
                    {
                        if (free == true)
                        {
                            sqlQuery = "SELECT Author FROM Books inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Lent LIKE 'free' and LanguageName like '" + language[i] + "'";
                        }
                        else
                        {
                            sqlQuery = "SELECT Author FROM Books inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and LanguageName like '" + language[i] + "'";
                        }
                        MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            authors.Add((reader["Author"].ToString()));
                        }
                        reader.Close();
                    }
                    closeConnection();
                    return authors;
                }
                return authors;
            }
            else if (categories != null && languages != null)
            {
                string[] language, category;
                language = languages.Split(';');
                category = categories.Split(';');

                List<string> authors = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    for (int i = 0; i < (language.Length) - 1; i++)
                    {
                        for (int j = 0; j < (category.Length) - 1; j++)
                        {
                            if (free == true)
                            {
                                sqlQuery = "SELECT Author FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Lent LIKE 'free' and LanguageName like '" + language[i] + "' and CategoryName like '" + category[j] + "'";
                            }
                            else
                            {
                                sqlQuery = "SELECT Author FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and LanguageName like '" + language[i] + "' and CategoryName like '" + category[j] + "'";
                            }
                            MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                            MySqlDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                authors.Add((reader["Author"].ToString()));
                            }
                            reader.Close();
                        }
                    }
                    closeConnection();
                    return authors;
                }
                return authors;
            }
            else /*if (categories == null && languages == null)*/
            {
                List<string> authors = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    if (free == true)
                    {
                        sqlQuery = "select Author from Books where (BookName like '%" + search + "%' or Author like '%" + search + "%') and Lent LIKE 'free'";
                    }
                    else
                    {
                        sqlQuery = "SELECT Author FROM Books where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%')";
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
        }

        // searching Lents according search parameters
        public List<string> searchLents(string search, bool free, string categories, string languages)
        {
            if (categories != null && languages == null)
            {
                string[] category;
                category = categories.Split(';');

                List<string> Lents = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    for (int i = 0; i < (category.Length) - 1; i++)
                    {
                        if (free == true)
                        {
                            sqlQuery = "SELECT Lent FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Lent LIKE 'free' and CategoryName like '" + category[i] + "'";
                        }
                        else
                        {
                            sqlQuery = "SELECT Lent FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and CategoryName like '" + category[i] + "'";
                        }
                        MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Lents.Add(reader["Lent"].ToString());
                        }
                        reader.Close();
                    }
                    closeConnection();
                    return Lents;
                }
                return Lents;
            }
            else if (categories == null && languages != null)
            {
                string[] language;
                language = languages.Split(';');

                List<string> Lents = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    for (int i = 0; i < (language.Length) - 1; i++)
                    {
                        if (free == true)
                        {
                            sqlQuery = "SELECT Lent FROM Books inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Lent LIKE 'free' and LanguageName like '" + language[i] + "'";
                        }
                        else
                        {
                            sqlQuery = "SELECT Lent FROM Books inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and LanguageName like '" + language[i] + "'";
                        }
                        MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Lents.Add(reader["Lent"].ToString());
                        }
                        reader.Close();
                    }
                    closeConnection();
                    return Lents;
                }
                return Lents;
            }
            else if (categories != null && languages != null)
            {
                string[] language, category;
                language = languages.Split(';');
                category = categories.Split(';');

                List<string> Lents = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    for (int i = 0; i < (language.Length) - 1; i++)
                    {
                        for (int j = 0; j < (category.Length) - 1; j++)
                        {
                            if (free == true)
                            {
                                sqlQuery = "SELECT Lent FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Lent LIKE 'free' and LanguageName like '" + language[i] + "' and CategoryName like '" + category[j] + "'";
                            }
                            else
                            {
                                sqlQuery = "SELECT Lent FROM Books inner join BookCategory on Books.IDCategory = BookCategory.ID inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and LanguageName like '" + language[i] + "' and CategoryName like '" + category[j] + "'";
                            }
                            MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                            MySqlDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                Lents.Add(reader["Lent"].ToString());
                            }
                            reader.Close();
                        }
                    }
                    closeConnection();
                    return Lents;
                }
                return Lents;
            }
            else /*if (categories == null && languages == null)*/
            {
                List<string> Lents = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    if (free == true)
                    {
                        sqlQuery = "SELECT Lent FROM Books where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Lent LIKE 'free'";
                    }
                    else
                    {
                        sqlQuery = "SELECT Lent FROM Books where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%')";
                    }
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Lents.Add(reader["Lent"].ToString());
                    }
                    closeConnection();
                    return Lents;
                }
                return Lents;
            }
        }

        // searching Category according search parameters
        public List<string> searchCategory(string search, bool free, string categories, string languages)
        {
            if (categories != null && languages == null)
            {
                string[] category;
                category = categories.Split(';');

                List<string> Category = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    for (int i = 0; i < (category.Length) - 1; i++)
                    {
                        if (free == true)
                        {
                            sqlQuery = "SELECT CategoryName from BookCategory inner join Books on Books.IDCategory = BookCategory.ID where (BookName like '%" + search + "%' or Author like '%" + search + "%') and Lent LIKE 'free' and CategoryName like '" + category[i] + "'";
                        }
                        else
                        {
                            sqlQuery = "SELECT CategoryName FROM BookCategory inner join Books on Books.IDCategory = BookCategory.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and CategoryName like '" + category[i] + "'";
                        }
                        MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Category.Add((reader["CategoryName"].ToString()));
                        }
                        reader.Close();
                    }
                    closeConnection();
                    return Category;
                }
                return Category;
            }
            else if (categories == null && languages != null)
            {
                string[] language;
                language = languages.Split(';');

                List<string> Category = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    for (int i = 0; i < (language.Length) - 1; i++)
                    {
                        if (free == true)
                        {
                            sqlQuery = "SELECT CategoryName from BookCategory inner join Books on Books.IDCategory = BookCategory.ID inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Lent like 'free' and LanguageName like '" + language[i] + "'";
                        }
                        else
                        {
                            sqlQuery = "SELECT CategoryName from BookCategory inner join Books on Books.IDCategory = BookCategory.ID inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and LanguageName like '" + language[i] + "'";
                        }
                        MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Category.Add((reader["CategoryName"].ToString()));
                        }
                        reader.Close();
                    }
                    closeConnection();
                    return Category;
                }
                return Category;
            }
            else if (categories != null && languages != null)
            {
                string[] language, category;
                language = languages.Split(';');
                category = categories.Split(';');

                List<string> Category = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    for (int i = 0; i < (language.Length) - 1; i++)
                    {
                        for (int j = 0; j < (category.Length) - 1; j++)
                        {
                            if (free == true)
                            {
                                sqlQuery = "SELECT CategoryName from BookCategory inner join Books on Books.IDCategory = BookCategory.ID inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Lent like 'free' and LanguageName like '" + language[i] + "' and CategoryName like '" + category[j] + "'";
                            }
                            else
                            {
                                sqlQuery = "SELECT CategoryName from BookCategory inner join Books on Books.IDCategory = BookCategory.ID inner join BookLanguage on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and LanguageName like '" + language[i] + "' and CategoryName like '" + category[j] + "'";
                            }
                            MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                            MySqlDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                Category.Add((reader["CategoryName"].ToString()));
                            }
                            reader.Close();
                        }
                    }
                    closeConnection();
                    return Category;
                }
                return Category;
            }
            else /*if (categories == null && languages == null)*/
            {
                List<string> Category = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    if (free == true)
                    {
                        sqlQuery = "SELECT CategoryName from BookCategory inner join Books on Books.IDCategory = BookCategory.ID where (BookName like '%" + search + "%' or Author like '%" + search + "%') and Lent LIKE 'free'";
                    }
                    else
                    {
                        sqlQuery = "SELECT CategoryName FROM BookCategory inner join Books on Books.IDCategory = BookCategory.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%')";
                    }
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Category.Add((reader["CategoryName"].ToString()));
                    }
                    closeConnection();
                    return Category;
                }
                return Category;
            }
        }

        // searching Language according search parameters
        public List<string> searchLanguage(string search, bool free, string categories, string languages)
        {
            if (languages != null && categories == null)
            {
                string[] language;
                language = languages.Split(';');

                List<string> Language = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    for (int i = 0; i < (language.Length) - 1; i++)
                    {
                        if (free == true)
                        {
                            sqlQuery = "SELECT LanguageName from BookLanguage inner join Books on Books.IDLanguage = BookLanguage.ID where (BookName like '%" + search + "%' or Author like '%" + search + "%') and Lent LIKE 'free' and LanguageName like '" + language[i] + "'";
                        }
                        else
                        {
                            sqlQuery = "SELECT LanguageName FROM BookLanguage inner join Books on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and LanguageName like '" + language[i] + "'";
                        }
                        MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Language.Add((reader["LanguageName"].ToString()));
                        }
                        reader.Close();
                    }
                    closeConnection();
                    return Language;
                }
                return Language;
            }
            else if (categories != null && languages == null)
            {
                string[] category;
                category = categories.Split(';');

                List<string> Language = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    for (int i = 0; i < (category.Length) - 1; i++)
                    {
                        if (free == true)
                        {
                            sqlQuery = "SELECT LanguageName from BookLanguage inner join Books on Books.IDLanguage = BookLanguage.ID inner join BookCategory on Books.IDCategory = BookCategory.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Lent like 'free' and CategoryName like '" + category[i] + "'";
                        }
                        else
                        {
                            sqlQuery = "SELECT LanguageName from BookLanguage inner join Books on Books.IDLanguage = BookLanguage.ID inner join BookCategory on Books.IDCategory = BookCategory.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and CategoryName like '" + category[i] + "'";
                        }
                        MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Language.Add((reader["LanguageName"].ToString()));
                        }
                        reader.Close();
                    }
                    closeConnection();
                    return Language;
                }
                return Language;
            }
            else if (categories != null && languages != null)
            {
                string[] language, category;
                language = languages.Split(';');
                category = categories.Split(';');

                List<string> authors = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    for (int i = 0; i < (language.Length) - 1; i++)
                    {
                        for (int j = 0; j < (category.Length) - 1; j++)
                        {
                            if (free == true)
                            {
                                sqlQuery = "SELECT LanguageName from BookLanguage inner join Books on Books.IDLanguage = BookLanguage.ID inner join BookCategory on Books.IDCategory = BookCategory.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and Lent like 'free' and LanguageName like '" + language[i] + "' and CategoryName like '" + category[j] + "'";
                            }
                            else
                            {
                                sqlQuery = "SELECT LanguageName from BookLanguage inner join Books on Books.IDLanguage = BookLanguage.ID inner join BookCategory on Books.IDCategory = BookCategory.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%') and LanguageName like '" + language[i] + "' and CategoryName like '" + category[j] + "'";
                            }
                            MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                            MySqlDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                authors.Add((reader["LanguageName"].ToString()));
                            }
                            reader.Close();
                        }
                    }
                    closeConnection();
                    return authors;
                }
                return authors;
            }
            else /*if (categories == null && languages == null)*/
            {
                List<string> Language = new List<string>();
                if (openConnection())
                {
                    string sqlQuery;
                    if (free == true)
                    {
                        sqlQuery = "SELECT LanguageName from BookLanguage inner join Books on Books.IDLanguage = BookLanguage.ID where (BookName like '%" + search + "%' or Author like '%" + search + "%') and Lent LIKE 'free'";
                    }
                    else
                    {
                        sqlQuery = "SELECT LanguageName FROM BookLanguage inner join Books on Books.IDLanguage = BookLanguage.ID where (BookName LIKE '%" + search + "%' or Author LIKE '%" + search + "%')";
                    }
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Language.Add((reader["LanguageName"].ToString()));
                    }
                    closeConnection();
                    return Language;
                }
                return Language;
            }
        }

        // find details about book according its name
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
                    bookDetail.Add(reader["Lent"].ToString());
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
        // add Book Category To database
        public bool addBookCategory(string CategoryName)
        {
            try
            {
                if (openConnection())
                {
                    string sqlQuery = "Insert into " + bookCategoryEnity + " (CategoryName) VALUES (@CategoryName)";
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

        // add Book Language To database
        public bool addBookLanguage(string LanguageName)
        {
            try
            {
                if (openConnection())
                {
                    string sqlQuery = "Insert into " + bookLanguageEnity + " (LanguageName) VALUES (@LanguageName)";
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

        //load CategoryName from database
        public List<string> loadBookCategoryName()
        {
            List<string> sCategoryName = new List<string>();
            String sqlQuery = "select id,CategoryName from " + bookCategoryEnity;

            if (openConnection())
            {

                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    sCategoryName.Add(reader["ID"] + " " + reader["CategoryName"]);
                }

                closeConnection();
                return sCategoryName;
            }
            return null;
        }

        // find book ID according it's name
        public string findBookID (string bookName)
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

        //get bookimage from database and show it in bookdetailsform
        public byte[] getImageByBookId(String id)
        {
            byte[] imageBytes = null;
            String sqlQuery = "select Image from " + booksDetailsEntity + "where ID = " + id;
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


        //load LanguageName from database
        public List<string> loadBookLanguageName()
        {
            List<string> sLanguageName = new List<string>();
            String sqlQuery = "select id,LanguageName from " + bookLanguageEnity;

            if (openConnection())
            {

                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    sLanguageName.Add(reader["ID"] + " " + reader["LanguageName"]);
                }

                closeConnection();
                return sLanguageName;
            }

            return null;

        }

        // add book to database
        public bool addBook(string bookName, string bookAuthor, string IDCategory, string IDLanguage, string image, string ISBN, string publisher, string description)
        {
            try
            {
                if (openConnection())
                {
                    //insert books
                    string sqlQuery = "Insert into " + booksEntity + " (BookName,Author, IDCategory, IDLanguage) Values (@bookName, @bookAuthor, @IDCategory, @IDLanguage )";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("@bookName", bookName);
                    cmd.Parameters.AddWithValue("@bookAuthor", bookAuthor);
                    cmd.Parameters.AddWithValue("@IDCategory", IDCategory);
                    cmd.Parameters.AddWithValue("@IDLanguage", IDLanguage);
                    cmd.ExecuteNonQuery();


                    // insert book details
                    byte[] imageBT = null;
                    FileStream fstream = new FileStream(image, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fstream);
                    imageBT = br.ReadBytes((int)fstream.Length);

                    sqlQuery = "Insert into " + booksDetailsEntity + " (Image,Description,ISBN,Publisher) Values (@image,@description, @ISBN, @publisher)";
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
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }
        /*** END BOOK Insert to database ***/

        /** START Update Book ***/
        public bool updateBookdetailsData(string data)
        {
            string bookID, bookName, author, lent, categoryID, languageID, desc, publisher, category, language, ISBN;
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
            string sqlQuery = "update Books set BookName = @bookName, Author = @author where ID like " + bookID;
            MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
            cmd.Parameters.AddWithValue("@BookName", bookName);
            cmd.Parameters.AddWithValue("@author", author);
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

        /*** END UPDATE BOOK ***/

        /*** START OF LOANS QUERIES ***/

        // Add Loans into database
        public bool addLoans(string dateOfLoan, string dateOfReturn, string bookID, string userID)
        {
            if (openConnection())
            {
                string sqlQuery = "insert into Loans (DateLoan, DateReturn, IDBook, IDUser) values (@dateOfLoan, @dateOfReturn, @bookID, @userID)";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@dateOfLoan", dateOfLoan);
                cmd.Parameters.AddWithValue("@dateOfReturn", dateOfReturn);
                cmd.Parameters.AddWithValue("@bookID", bookID);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.ExecuteNonQuery();

                sqlQuery = "update Books set Lent = @lent where ID = " + bookID;
                cmd = new MySqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@lent", "lent");
                cmd.ExecuteNonQuery();

                closeConnection();
                return true;
            }
            return false;
        }

        // return list of names of books, that are borrowed
        public List<string> checkLentBookNames(string bookName, bool onlyReserved)
        {
            List<string> books = new List<string>();
            if (openConnection())
            {
                if (onlyReserved == false)
                {
                    string sqlQuery = "select BookName from Books inner join Loans on Books.ID = Loans.IDBook where Books.BookName like '%" + bookName + "%'";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        books.Add(reader["BookName"].ToString());
                    }
                    reader.Close();

                    sqlQuery = "select BookName from Books inner join ReservedBooks on ReservedBooks.IDBook = Books.ID where Books.BookName like '%" + bookName + "%'";
                    cmd = new MySqlCommand(sqlQuery, connection);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        books.Add(reader["BookName"].ToString());
                    }

                    closeConnection();
                    return books;
                }
                else
                {
                    string sqlQuery = "select BookName from Books inner join ReservedBooks on ReservedBooks.IDBook = Books.ID where Books.BookName like '%" + bookName + "%'";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        books.Add(reader["BookName"].ToString());
                    }

                    closeConnection();
                    return books;
                }
                
            }
            return books;
        }

        // return list of names of readers, that have borrowed books
        public List<string> checkOwnersOfLentBooks(string bookName, bool onlyReserved)
        {
            List<string> readers = new List<string>();
            if (openConnection())
            {
                if (onlyReserved == false)
                {
                    string sqlQuery = "select FirstName, LastName from Users inner join Loans on Users.ID = Loans.IDUser inner join Books on Loans.IDBook = Books.ID where Books.BookName like '%" + bookName + "%'";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        readers.Add(reader["FirstName"] + " " + reader["LastName"]);
                    }
                    reader.Close();

                    sqlQuery = "select FirstName, LastName from Users inner join ReservedBooks on ReservedBooks.IDUser = Users.ID inner join Books on ReservedBooks.IDBook = Books.ID where Books.BookName like '%" + bookName + "%'";
                    cmd = new MySqlCommand(sqlQuery, connection);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        readers.Add(reader["FirstName"] + " " + reader["LastName"]);
                    }
                    closeConnection();
                    return readers;
                }
                else
                {
                    string sqlQuery = "select FirstName, LastName from Users inner join ReservedBooks on ReservedBooks.IDUser = Users.ID inner join Books on ReservedBooks.IDBook = Books.ID where Books.BookName like '%" + bookName + "%'";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        readers.Add(reader["FirstName"] + " " + reader["LastName"]);
                    }
                    closeConnection();
                    return readers;
                }
            }
            return readers;
        }

        public List<string> checkStatusOfBook(string bookName, bool onlyReserved)
        {
            List<string> status = new List<string>();
            if (openConnection())
            {
                if (onlyReserved == false)
                {
                    string sqlQuery = "select Lent from Books inner join Loans on Books.ID = Loans.IDBook where Books.BookName like '%" + bookName + "%'";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        status.Add(reader["Lent"].ToString());
                    }
                    reader.Close();

                    sqlQuery = "select Lent from Books inner join ReservedBooks on Books.ID = ReservedBooks.IDBook where Books.BookName like '%" + bookName + "%'";
                    cmd = new MySqlCommand(sqlQuery, connection);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        status.Add(reader["Lent"].ToString());
                    }
                    closeConnection();
                    return status;
                }
                else
                {
                    string sqlQuery = "select Lent from Books inner join ReservedBooks on Books.ID = ReservedBooks.IDBook where Books.BookName like '%" + bookName + "%'";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["Lent"].ToString() == "reserved")
                        {
                            status.Add(reader["Lent"].ToString());
                        }
                    }
                    closeConnection();
                    return status;
                }
            }
            return status;
        }

        // return list of dates when were books lended
        public List<string> checkDatesLendings(string bookName, bool onlyReserved)
        {
            List<string> lendings = new List<string>();
            if (openConnection())
            {
                if (onlyReserved == false)
                {
                    string sqlQuery = "select DateLoan from Loans inner join Books on Loans.IDBook = Books.ID where Books.BookName like '%" + bookName + "%'";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lendings.Add(reader["DateLoan"].ToString());
                    }
                    reader.Close();

                    sqlQuery = "select IDBook from ReservedBooks inner join Books on ReservedBooks.IDBook = Books.ID where Books.BookName like '%" + bookName + "%'";
                    cmd = new MySqlCommand(sqlQuery, connection);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lendings.Add("---");
                    }
                    closeConnection();
                    return lendings;
                }
                else
                {
                    string sqlQuery = "select IDBook from ReservedBooks inner join Books on ReservedBooks.IDBook = Books.ID where Books.BookName like '%" + bookName + "%'";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lendings.Add("---");
                    }
                }
            }
            closeConnection();
            return lendings;
        }

        // return list of dates when should be books returned
        public List<string> checkReturnsDates(string bookName, bool onlyReserved)
        {
            List<string> returns = new List<string>();
            if (openConnection())
            {
                if (onlyReserved == false)
                {
                    string sqlQuery = "select DateReturn from Loans inner join Books on Loans.IDBook = Books.ID where Books.BookName like '%" + bookName + "%'";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        returns.Add(reader["DateReturn"].ToString());
                    }
                    reader.Close();

                    sqlQuery = "select IDBook from ReservedBooks inner join Books on ReservedBooks.IDBook = Books.ID where Books.BookName like '%" + bookName + "%'";
                    cmd = new MySqlCommand(sqlQuery, connection);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        returns.Add("---");
                    }
                    closeConnection();
                    return returns;
                }
                else
                {
                    string sqlQuery = "select IDBook from ReservedBooks inner join Books on ReservedBooks.IDBook = Books.ID where Books.BookName like '%" + bookName + "%'";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       returns.Add("---");
                    }
                }
            }
            closeConnection();
            return returns;
        }
    }

}