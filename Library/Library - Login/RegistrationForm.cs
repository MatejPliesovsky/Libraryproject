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
        private int postalCode;
        private System.DateTime dateOfBirth = new DateTime();

        public RegistrationForm()
        {
            InitializeComponent();
        }

        //button after click save the information to array, then, this information will be send to admin for confirm
        private void Confirm_Click(object sender, EventArgs e)
        {
            firstName = FirstName.Text;
            lastName = LastName.Text;
            dateOfBirth = DateOfBirth.Value;
            password = PasswordReg.Text;
            email = EmailReg.Text;
            street = Street.Text;
            streetNumber = Number.Text;
            city = City.Text;
            postalCode = int.Parse(PostalCode.Text);
            label1.Text = dateOfBirth.ToString();
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
