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
    public partial class FormChangePassword : Form
    {
        string userID;
        Connect2DB connect;

        public FormChangePassword(string userID)
        {
            InitializeComponent();
            this.userID = userID;
            connect = new Connect2DB();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            OldPassword.PasswordChar = '*';
            NewPassword.PasswordChar = '*';
            RepeatPassword.PasswordChar = '*';
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (NewPassword.Text == RepeatPassword.Text)
            {
                if (OldPassword.Text == connect.getOldPassword(userID))
                {
                    if (connect.changeUserPassword(userID, NewPassword.Text))
                    {
                        InfoMessage.Text = "Password was changed successfuly!";
                        timer1.Interval = 2500;
                        timer1.Tick += new EventHandler(Timer1_Tick);
                        InfoMessage.Visible = true;
                        timer1.Start();
                    }
                    else
                    {
                        InfoMessage.Text = "Password wasn't changed successfuly!";
                        timer1.Interval = 2500;
                        timer1.Tick += new EventHandler(Timer1_Tick);
                        InfoMessage.Visible = true;
                        timer1.Start();
                    }
                }
                else
                {
                    InfoMessage.Text = "Old password is incorrect!";
                    timer1.Interval = 2500;
                    timer1.Tick += new EventHandler(Timer1_Tick);
                    InfoMessage.Visible = true;
                    timer1.Start();
                }
            }
            else
            {
                InfoMessage.Text = "New passwords aren't same!";
                timer1.Interval = 2500;
                timer1.Tick += new EventHandler(Timer1_Tick);
                InfoMessage.Visible = true;
                timer1.Start();
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            InfoMessage.Visible = false;
        }
    }
}
