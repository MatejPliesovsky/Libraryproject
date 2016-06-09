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
    /// form for changing password
    /// </summary>
    public partial class FormChangePassword : Form
    {
        private string userID;
        private Connect2DB connect;
        private byte[] data;
        private Encoding enc;

        public FormChangePassword(string userID)
        {
            InitializeComponent();
            enc = new UTF8Encoding(true, true);
            this.userID = userID;
            connect = new Connect2DB();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            OldPassword.PasswordChar = '●';
            NewPassword.PasswordChar = '●';
            RepeatPassword.PasswordChar = '●';
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (NewPassword.Text == RepeatPassword.Text)
            {
                data = enc.GetBytes(OldPassword.Text);
                if (enc.GetString(data) == connect.getOldPassword(userID))
                {
                    data = enc.GetBytes(NewPassword.Text);
                    if (connect.changeUserPassword(userID, enc.GetString(data)))
                    {
                        InfoMessage.Text = "Password was changed successfuly!";
                        timer1.Interval = 5000;
                        timer1.Tick += new EventHandler(Timer1_Tick);
                        InfoMessage.Visible = true;
                        timer1.Start();
                    }
                    else
                    {
                        InfoMessage.Text = "Password wasn't changed successfuly!";
                        timer1.Interval = 5000;
                        timer1.Tick += new EventHandler(Timer1_Tick);
                        InfoMessage.Visible = true;
                        timer1.Start();
                    }
                }
                else
                {
                    InfoMessage.Text = "Old password is incorrect!";
                    timer1.Interval = 5000;
                    timer1.Tick += new EventHandler(Timer1_Tick);
                    InfoMessage.Visible = true;
                    timer1.Start();
                }
            }
            else
            {
                InfoMessage.Text = "New passwords aren't same!";
                timer1.Interval = 5000;
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

        private void OldPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Confirm_Click(OldPassword, null);
            }
        }
    }
}
