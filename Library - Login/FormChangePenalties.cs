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
    public partial class FormChangePenalties : Form
    {
        string adminID;
        Connect2DB connect;
        List<string> penalties;

        public FormChangePenalties(string adminID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.adminID = adminID;
            connect = new Connect2DB();
            penalties = new List<string>();
            penalties = connect.getPenalties();

            for (int i = 0;i < penalties.Count; i++)
            {
                if (!(penalties[i].Contains('.') || penalties[i].Contains(',')))
                {
                    penalties[i] = penalties[i] + ".00";
                }
            }

            TwoWeeks.Text = penalties[0];
            OneMonth.Text = penalties[1];
            TwoMonths.Text = penalties[2];
            Longer.Text = penalties[3];
            penalties.Clear();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if ((TwoWeeks.Text == "" && OneMonth.Text == "" && TwoMonths.Text == "" && Longer.Text =="") ||
                (TwoWeeks.Text == null && OneMonth.Text == null && TwoMonths.Text == null && Longer.Text == null))
            {
                timer1.Interval = 2500;
                timer1.Tick += new EventHandler(Timer1_Tick);
                Message.Text = "Fill all fields";
                Message.Visible = true;
                timer1.Start();
            }
            else
            {
                penalties.Add(TwoWeeks.Text);
                penalties.Add(OneMonth.Text);
                penalties.Add(TwoMonths.Text);
                penalties.Add(Longer.Text);
                if (connect.updatePenalties(penalties))
                {
                    timer1.Interval = 2500;
                    timer1.Tick += new EventHandler(Timer1_Tick);
                    Message.Text = "Penalties were update!";
                    Message.Visible = true;
                    timer1.Start();
                }
                else
                {
                    timer1.Interval = 2500;
                    timer1.Tick += new EventHandler(Timer1_Tick);
                    Message.Text = "Penalties weren't update!";
                    Message.Visible = true;
                    timer1.Start();
                }
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Message.Visible = false;
        }
    }
}
