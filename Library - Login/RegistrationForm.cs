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
    public partial class RegistrationForm : Form
    {
        private string firstName, lastName, password, email, street, streetNumber, city;
        private int telephone, postalCode;
        private System.DateTime dateOfBirth = new DateTime();

        public RegistrationForm()
        {
            InitializeComponent();
            Info.Visible = false;
        }

        //button after click save the information to array, then, this information will be send to admin for confirm
        private void Confirm_Click(object sender, EventArgs e)
        {
            Connect2DB register = new Connect2DB();
            firstName = FirstName.Text;
            lastName = LastName.Text;
            dateOfBirth = DateOfBirth.Value;
            password = PasswordReg.Text;
            email = EmailReg.Text;
            telephone = int.Parse(Telephone.Text);
            street = Street.Text;
            streetNumber = Number.Text;
            city = City.Text;
            postalCode = int.Parse(PostalCode.Text);
            int age;
            if(System.DateTime.Today.Month == dateOfBirth.Month && System.DateTime.Today.Day == dateOfBirth.Day)
            {
                age = System.DateTime.Today.Year - dateOfBirth.Year;
            }
            else
            {
                age = System.DateTime.Today.Year - dateOfBirth.Year - 1;
            }
            if (register.writeUserAsInactive(firstName, lastName, email, telephone, age, dateOfBirth, street, streetNumber, city, postalCode))
            {
                Info.Visible = true;
            }
            else
            {
                Info.Text = "Your request wasn't send successfully.\nPlease try again later.";
                Info.Visible = true;
            }
        }

        //button after click remove all information and set the dateTimePicker to 1.1.2012
        private void Delete_Click(object sender, EventArgs e)
        {
            FirstName.Text = LastName.Text = EmailReg.Text = PasswordReg.Text = Street.Text = Number.Text = City.Text = PostalCode.Text = "";
            DateOfBirth.Text = "1.1.2012"; 
        }

        //set the looks of char at password textbox as *
        private void PasswordReg_TextChanged(object sender, EventArgs e)
        {
            PasswordReg.PasswordChar = '*';
        }
    }
}
