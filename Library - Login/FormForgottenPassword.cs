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
    public partial class FormForgottenPassword : Form
    {
        Connect2DB connect;
        Encoding enc;
        byte[] data;
        string email;

        public FormForgottenPassword()
        {
            InitializeComponent();
            connect = new Connect2DB();
            enc = new UTF8Encoding(true, true);
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(email))
            {
                InfoMessage.Text = "Please, enter your email!";
                timer1.Interval = 2500;
                timer1.Tick += new EventHandler(Timer1_Tick);
                InfoMessage.Visible = true;
                timer1.Start();
            }
            else
            {
                if (connect.isEmailTaken(email) == 1)
                {
                    if (sendEmail(null, null))
                    {
                        InfoMessage.Text = "We sent you email with\nnew password!";
                        timer1.Interval = 2500;
                        timer1.Tick += new EventHandler(Timer1_Tick);
                        InfoMessage.Visible = true;
                        timer1.Start();
                    }
                    else
                    {
                        InfoMessage.Text = "We can't send you\nnew password now!";
                        timer1.Interval = 2500;
                        timer1.Tick += new EventHandler(Timer1_Tick);
                        InfoMessage.Visible = true;
                        timer1.Start();
                    }
                }
            }
        }

        private void Email_TextChanged(object sender, EventArgs e)
        {
            data = enc.GetBytes(Email.Text);
            email = enc.GetString(data);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            InfoMessage.Visible = false;
        }

        private bool sendEmail(object sender, EventArgs e)
        {
            try {
                SmtpClient client = new SmtpClient("rebooks.gmail.com");
                NetworkCredential credential = new NetworkCredential("ReBooksLibrary@gmail.com", "ReBooks1234");
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("ReBooksLibrary@gmail.com");
                msg.To.Add(email);
                msg.Subject = "New password";
                string newPass = connect.setPasswordCode(email);

                msg.Body = "Your new password is: " + newPass + "\nPlease, set new password, after login to your account.\nSupport Team.";
                client.Credentials = credential;
                client.EnableSsl = true;
                client.Send(msg);
                return true;
            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }
    }
}
