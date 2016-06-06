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
    /// login form for log in to the system
    /// </summary>
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            ErrorMessage.Visible = false;
            Username.Text = "Please enter your email";
            Password.Text = "Password";
            Username.ForeColor = Color.Gray;
            Password.ForeColor = Color.Gray;
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
            Connect2DB con = new Connect2DB();
            if (con.isUserRegistered(Username.Text, Password.Text))
            {
                if (con.isUserAdmin(Username.Text) == "admin")
                {
                    FormAdminInterface admin = new FormAdminInterface(Username.Text, Password.Text);
                    admin.Show();
                    this.Hide();
                }
                else if (con.isUserAdmin(Username.Text) == "user")
                {
                    FormUserInterface userForm = new FormUserInterface(Username.Text,Password.Text);
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void Username_TextChanged(object sender, EventArgs e)
        {
            Username.ForeColor = Color.Black;
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
            Password.PasswordChar = '*';
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

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
