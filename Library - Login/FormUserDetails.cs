using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library___Login
{
    /// <summary>
    /// form with user details
    /// </summary>
    public partial class FormUserDetails : Form
    {
        string adminID; // id of user, who made changes. It can be admin, or user
        string userID, firstName, lastName, age, email, userRole, active, street, streetNumber, postalCode, city, country, telephone, details;

        private void Active_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Apply_Click(Active, null);
            }
        }

        string[] items;
        byte[] data;
        Connect2DB connect; 
        Encoding enc;

        public FormUserDetails(string adminID, string firstName)
        {
            InitializeComponent();
            enc = new UTF8Encoding(true, true);
            connect = new Connect2DB();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.adminID = adminID;
            details = connect.findUserByFirstName(firstName);
            items = details.Split(';');

            userID = items[0];
            this.firstName = items[1];
            lastName = items[2];
            age = items[3];
            email = items[4];
            userRole = items[5];
            active = items[6];
            street = items[7];
            streetNumber = items[8];
            postalCode = items[9];
            city = items[10];
            country = items[11];
            telephone = items[12];

            ID.Text = userID;
            FirstName.Text = this.firstName;
            LastName.Text = lastName;
            Age.Text = age;
            Email.Text = email;
            UserRole.Text = userRole;
            Active.Text = active;
            Street.Text = street;
            StreetNumber.Text = streetNumber;
            PostalCode.Text = postalCode;
            City.Text = city;
            Country.Text = country;
            Telephone.Text = telephone;

            ID.Enabled = false;
            FirstName.Enabled = false;
            LastName.Enabled = false;
            Age.Enabled = false;
        }

        public FormUserDetails(string userID)
        {
            InitializeComponent();
            this.adminID = null;
            details = connect.findUserByID(userID);
            items = details.Split(';');

            userID = items[0];
            firstName = items[1];
            lastName = items[2];
            age = items[3];
            email = items[4];
            userRole = items[5];
            active = items[6];
            street = items[7];
            streetNumber = items[8];
            postalCode = items[9];
            city = items[10];
            country = items[11];
            telephone = items[12];

            ID.Text = userID;
            data = enc.GetBytes(firstName);
            FirstName.Text = enc.GetString(data);

            data = enc.GetBytes(lastName);
            LastName.Text = enc.GetString(data);

            data = enc.GetBytes(email);
            Email.Text = enc.GetString(data);

            UserRole.Text = userRole;
            Active.Text = active;

            data = enc.GetBytes(street);
            Street.Text = enc.GetString(data);

            StreetNumber.Text = streetNumber;

            PostalCode.Text = postalCode;

            data = enc.GetBytes(city);
            City.Text = enc.GetString(data);

            data = enc.GetBytes(country);
            Country.Text = enc.GetString(data);

            Telephone.Text = telephone;

            ID.Enabled = false;
            FirstName.Enabled = false;
            LastName.Enabled = false;
            Age.Enabled = false;
            UserRole.Enabled = false;
            Active.Enabled = false;
            Delete.Enabled = false;
            Delete.Visible = false;
        }
              

        private void Apply_Click(object sender, EventArgs e)
        {
            userID = ID.Text;
            data = enc.GetBytes(FirstName.Text);
            firstName = enc.GetString(data);

            data = enc.GetBytes(LastName.Text);
            lastName = enc.GetString(data);

            data = enc.GetBytes(Email.Text);
            email = enc.GetString(data);

            userRole = UserRole.Text.ToLower();
            active = Active.Text.ToLower();

            data = enc.GetBytes(Street.Text);
            street = enc.GetString(data);

            streetNumber = StreetNumber.Text;

            postalCode = PostalCode.Text;

            data = enc.GetBytes(City.Text);
            city = enc.GetString(data);

            data = enc.GetBytes(Country.Text);
            country = enc.GetString(data);
            
            telephone = Telephone.Text;

            data = enc.GetBytes(userID + ";" + firstName + ";" + lastName + ";" + email + ";" + userRole + ";" + active + ";" + street + ";"
                + streetNumber + ";" + postalCode + ";" + city + ";" + country + ";" + telephone);
            details = enc.GetString(data);

            if (connect.updateUserData(details))
            {
                DatabaseInfo.Text = "User data was update";
                timer1.Interval = 5000;
                timer1.Tick += new EventHandler(Timer1_Tick);
                DatabaseInfo.Visible = true;
                timer1.Start();
                Console.Write("User was update");
            }
            else
            {
                DatabaseInfo.Text = "Cannot connect to the database!";
                timer1.Interval = 5000;
                timer1.Tick += new EventHandler(Timer1_Tick);
                DatabaseInfo.Visible = true;
                timer1.Start();
                Console.Write("Error with DB connection");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (connect.deleteUserFromDatabase(userID))
            {
                DatabaseInfo.Text = "User was deleted.";
                timer1.Interval = 5000;
                timer1.Tick += new EventHandler(Timer1_Tick);
                DatabaseInfo.Visible = true;
                timer1.Start();
                Console.Write("User was delete successfuly");
            }
        }

        private void ReturnChanges_Click(object sender, EventArgs e)
        {
            ID.Text = userID;
            data = enc.GetBytes(firstName);
            FirstName.Text = enc.GetString(data);

            data = enc.GetBytes(lastName);
            LastName.Text = enc.GetString(data);

            data = enc.GetBytes(email);
            Email.Text = enc.GetString(data);

            UserRole.Text = userRole;
            Active.Text = active;

            data = enc.GetBytes(street);
            Street.Text = enc.GetString(data);

            StreetNumber.Text = streetNumber;

            PostalCode.Text = postalCode;

            data = enc.GetBytes(city);
            City.Text = enc.GetString(data);

            data = enc.GetBytes(country);
            Country.Text = enc.GetString(data);

            Telephone.Text = telephone;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DatabaseInfo.Visible = false;
            timer1.Stop();
        }
    }
}
