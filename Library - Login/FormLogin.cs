using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library___Login
{
    /// <summary>
    /// login form for log in to the system
    /// </summary>
    public partial class FormLogin : Form
    {
        string username, password;
        Encoding enc;
        Connect2DB con;

        public FormLogin()
        {
            InitializeComponent();
            enc = new UTF8Encoding(true, true);
            ErrorMessage.Visible = false;
            Username.Text = "Please enter your email";
            Password.Text = "Password";
            Username.ForeColor = Color.Gray;
            Password.ForeColor = Color.Gray;
            Username.SelectionStart = 0;
            Username.SelectionLength = Username.Text.Length;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        /// <summary>
        /// after clicking button "Sign up", there will be opened new method with registration form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Register_Click(object sender, EventArgs e)
        {
            FormRegistrationUser reg = new FormRegistrationUser();
            reg.Show();
            this.Hide();
            reg.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
        }

        /// <summary>
        /// primary amdin login, that will be changed later
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Click(object sender, EventArgs e)
        {
            con = new Connect2DB();
            if (con.isUserRegistered(username, password))
            {
                if (con.isUserAdmin(username) == "admin")
                {
                    FormAdminInterface admin = new FormAdminInterface(username, password);
                    Console.Write("Opening admin interface");
                    admin.Show();
                    this.Hide();
                }
                else if (con.isUserAdmin(username) == "user")
                {
                    FormUserInterface userForm = new FormUserInterface(username, password);
                    Console.Write("Openning user interface");
                    userForm.Show();
                    this.Hide();
                }
                else
                {
                    ErrorMessage.Text = "Your registration request is treated!";
                    timer1.Interval = 2500;
                    timer1.Tick += new EventHandler(Timer1_Tick);
                    ErrorMessage.Visible = true;
                    timer1.Start();
                }
            }
            else
            {
                ErrorMessage.Text = "Invalid email or password!";
                timer1.Interval = 2500;
                timer1.Tick += new EventHandler(Timer1_Tick);
                ErrorMessage.Visible = true;
                timer1.Start();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            ErrorMessage.Visible = false;
        }

        /// <summary>
        /// set the looks of char at password textbox as *
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Password_TextChanged(object sender, EventArgs e)
        {
            Password.ForeColor = Color.Black;
            // Password.PasswordChar = '*';
            byte[] bytes = enc.GetBytes(Password.Text);
            password = enc.GetString(bytes);
        }

        /// <summary>
        /// if some opened formular will be closed, login form closed as well
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, EventArgs e)
        {
                this.Hide();

                Username.Text = "Please enter your email";
                Password.Text = "Password";
                Username.ForeColor = Color.Gray;
                Password.ForeColor = Color.Gray;
                ErrorMessage.Visible = false;
        
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            Username.ForeColor = Color.Black;
            byte[] user = enc.GetBytes(Username.Text);
            username = enc.GetString(user);
            Username.Anchor = AnchorStyles.Bottom & AnchorStyles.Top & AnchorStyles.Left & AnchorStyles.Right;
            try
            {
                Username.TextAlign = HorizontalAlignment.Left;
            }
            catch (InvalidEnumArgumentException ex)
            {
                MessageBox.Show("Error! " + ex.ToString());
            }
        }

        private void Username_MouseClick(object sender, MouseEventArgs e)
        {
            Username.Text = "";
            if (Password.Text == "")
            {
                Password.Text = "Password";
                Password.ForeColor = Color.Gray;
            }
        }

        private void Username_Click(object sender, EventArgs e)
        {
            Username.Text = "";
            if (Password.Text == "")
            {
                Password.Text = "Password";
                Password.ForeColor = Color.Gray;
            }
        }

        private void Password_MouseClick(object sender, MouseEventArgs e)
        {
            Password.Text = "";
            if (Username.Text == "")
            {
                Username.Text = "Please enter your email";
                Username.ForeColor = Color.Gray;
            }
        }

        private void Password_Click(object sender, EventArgs e)
        {
            Password.Text = "";
            if (Username.Text == "")
            {
                Username.Text = "Please enter your email";
                Username.ForeColor = Color.Gray;
            }
        }

        private void Password_Enter(object sender, EventArgs e)
        {
            Password.PasswordChar = '●';
            byte[] pass = enc.GetBytes(Password.Text);
            password = enc.GetString(pass);
        }

        private void Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login_Click(Username, null);
                Username.Text.Substring(0, (Username.TextLength - 1));
            }
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login_Click(Username, null);
                Password.Text = "";
            }
        }

        private void ForgottenPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormForgottenPassword forgotten = new FormForgottenPassword();
            forgotten.ShowDialog();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
