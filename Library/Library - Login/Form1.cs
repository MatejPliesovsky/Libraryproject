﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ErrorMessage.Visible = false;
            Username.Text = "Enter e-mail";
            Password.Text = "Enter password";
            Username.ForeColor = Color.Gray;
            Password.ForeColor = Color.Gray;
        }

        // after clicking label, there will be opened new method with registration form
        private void Registration_Click(object sender, EventArgs e)
        {
            RegistrationForm reg = new RegistrationForm();
            reg.Show();
            this.Hide();
            reg.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
        }

        //primary amdin login, that will be changed later
        private void Login_Click(object sender, EventArgs e)
        {
            Connect2DB con = new Connect2DB();
            if (con.isUserRegistered(Username.Text, Password.Text))
            {
                if (con.isUserAdmin(Username.Text) == "a")
                {
                    Admin admin = new Admin();
                    admin.Show();
                    this.Hide();
                    admin.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
                }
                else if (con.isUserAdmin(Username.Text) == "u")
                {
                    Form2 userForm = new Form2();
                    userForm.Show();
                    this.Hide();
                    userForm.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
                }
                else
                {
                    ErrorMessage.Text = "Your registration request is treated!";
                    ErrorMessage.Visible = true;
                }
            }
            else
            {
                ErrorMessage.Text = "Invalid email or password!";
                ErrorMessage.Visible = true;
            }
        }

        //set the looks of char at password textbox as *
        private void Password_TextChanged(object sender, EventArgs e)
        {
            Password.ForeColor = Color.Black;
            Password.PasswordChar = '*';
        }

        //if some opened formular will be closed, login form closed as well
        private void Form1_FormClosed(object sender, EventArgs e)
        {
            Username.Text = "Enter e-mail";
            Password.Text = "Enter password";
            Username.ForeColor = Color.Gray;
            Password.ForeColor = Color.Gray;
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {
            RegistrationForm reg = new RegistrationForm();
            reg.Show();
            this.Hide();
            reg.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            Username.ForeColor = Color.Black;
        }
    }
}
