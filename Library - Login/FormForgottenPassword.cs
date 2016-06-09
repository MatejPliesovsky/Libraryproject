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
        private Connect2DB connect;
        private Encoding enc;
        private byte[] data;
        private string email;

        public FormForgottenPassword()
        {
            InitializeComponent();
            connect = new Connect2DB();
            enc = new UTF8Encoding(true, true);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(email))
            {
                InfoMessage.Text = "Please, enter your email!";
                timer1.Interval = 5000;
                timer1.Tick += new EventHandler(Timer1_Tick);
                InfoMessage.Visible = true;
                timer1.Start();
            }
            else
            {
                if (connect.isEmailTaken(email) == 1)
                {
                    string newPass = sendEmail(null, null);
                    if (newPass != null)
                    {
                        connect.setPasswordCode(email, newPass);
                        InfoMessage.Text = "We sent you email with new password!";
                        timer1.Interval = 5000;
                        timer1.Tick += new EventHandler(Timer1_Tick);
                        InfoMessage.Visible = true;
                        timer1.Start();
                    }
                    else
                    {
                        InfoMessage.Text = "We can't send you new password now!";
                        timer1.Interval = 5000;
                        timer1.Tick += new EventHandler(Timer1_Tick);
                        InfoMessage.Visible = true;
                        timer1.Start();
                    }
                }
                else
                {
                    InfoMessage.Text = "Error! Cannot connect into database!";
                    timer1.Interval = 5000;
                    timer1.Tick += new EventHandler(Timer1_Tick);
                    InfoMessage.Visible = true;
                    timer1.Start();
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

        private string sendEmail(object sender, EventArgs e)
        {
            MailAddress from = new MailAddress("lostpassword@naprogramujem.sk");
            MailAddress to = new MailAddress(email);
            try {
                SmtpClient client = new SmtpClient("smtp.websupport.sk");
                NetworkCredential credential = new NetworkCredential("lostpassword@naprogramujem.sk", "salama29");
                MailMessage msg;
                client.Port = 25;
                client.Credentials = credential;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;

                string newPass = connect.getPasswordCode(email);

                msg = new MailMessage(from, to);
                msg.Subject = "New password";
                msg.Body = "Your new password is: " + newPass + "\nPlease, set new password, after login to your account.\nSupport Team.";
                msg.IsBodyHtml = true;
                msg.Sender = from;
                
                client.Send(msg);
                return newPass;
            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
        }

        private void Email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Confirm_Click(Email, null);
                Email.Text = email;
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
