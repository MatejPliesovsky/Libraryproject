using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library___Login
{
    public partial class FormRegistrationUser : Form
    {
        private string firstName, lastName, password, email, telephone, street, postalCode, city, country;
        private byte[] image;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formlogin = new FormLogin();
            formlogin.Show();
        }

        private void FormRegistrationUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1);
        }

        List<string> phonePrefix, countryName;
        Connect2DB register;

        private void FirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Confirm_Click(FirstName, null);
            }
        }

        private int streetNumber;
        private System.DateTime dateOfBirth = new DateTime();

        public FormRegistrationUser()
        {
            register = new Connect2DB();
            InitializeComponent();
            Info.Visible = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            phonePrefix = new List<string>();
            countryName = new List<string>();


            phonePrefix = register.getPhonePrefixes();
            countryName = register.getCountriesNames();

            Telephone1.Items.Clear();
            Country.Items.Clear();
            for (int i = 0; i < phonePrefix.Count; i++)
            {
                Telephone1.Items.Add(phonePrefix[i]);
            }

            for (int i = 0; i < countryName.Count; i++)
            {
                Country.Items.Add(countryName[i]);
            }
        }

        //button after click save the information to array, then, this information will be send to admin for confirm
        private void Confirm_Click(object sender, EventArgs e)
        {
            if (FirstName.Text.Trim() != "" && LastName.Text.Trim() != "" && PasswordReg.Text.Trim() != "" 
                && EmailReg.Text.Trim() != "" && (Telephone1.Text + Telephone2.Text.Trim()) != "" 
                && Street.Text.Trim() != "" && Number.Text.Trim() != "" && City.Text.Trim() != "" 
                && PostalCode.Text.Trim() != "" && Country.Text.Trim() != "")
            {
                firstName = FirstName.Text;
                lastName = LastName.Text;
                dateOfBirth = DateOfBirth.Value;
                password = PasswordReg.Text;
                email = EmailReg.Text;
                telephone = Telephone1.Text + Telephone2.Text;
                street = Street.Text;
                streetNumber = Int32.Parse(Number.Text);
                city = City.Text;
                postalCode = PostalCode.Text;
                country = Country.Text;
                image = register.getDefaultImage();

                if (register.isEmailTaken(email) == 0)
                {
                    if (!(Telephone1.Items.Contains(Telephone1.Text)) && !(Country.Items.Contains(Country.Text)))
                    {
                        register.addCountryToDB(Telephone1.Text, Country.Text);
                    }

                    if (register.writeUserAsInactive(firstName, lastName, email, password, telephone, dateOfBirth, street, streetNumber, city, postalCode, country, image))
                    {
                        Info.Text = "Your request was send successfully.";
                        Info.Visible = true;
                    }
                    else
                    {
                        Info.Text = "Your request wasn't send successfully.\nPlease try again later.";
                        Info.Visible = true;
                    }
                }
                else if (register.isEmailTaken(email) == 1)
                {
                    Info.Text = "Email is already taken.";
                    Info.Visible = true;
                }
                else
                {
                    Info.Text = "Error! Cannot connect to database.\nPlease try again later.";
                    Info.Visible = true;
                }
            }
            else
            {
                Info.Text = "Enter your data!";
                Info.Visible = true;
            }
        }

        //button after click remove all information and set the dateTimePicker to 1.1.2012
        private void Delete_Click(object sender, EventArgs e)
        {
            Info.Visible = false;
            FirstName.Text = LastName.Text = EmailReg.Text = Telephone1.Text = Telephone2.Text = PasswordReg.Text = Street.Text = Number.Text = City.Text = PostalCode.Text = "";
            DateOfBirth.Text = "8.4.2016"; 
        }

        //set the looks of char at password textbox as *
        private void PasswordReg_TextChanged(object sender, EventArgs e)
        {
            PasswordReg.PasswordChar = '*';
        }

        private static byte[] bitmapToByte(Bitmap image)
        {
            BitmapData bmpData = null;
            byte[] imageBT = null;
            try
            {
                bmpData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, image.PixelFormat);
                int numBytes = bmpData.Stride * image.Height;
                imageBT = new byte[numBytes];
                IntPtr ptr = bmpData.Scan0;

                Marshal.Copy(ptr, imageBT, 0, numBytes);
                return imageBT;
            }
            finally
            {
                if (bmpData != null)
                {
                    image.UnlockBits(bmpData);
                }
            }
        }
    }
}
