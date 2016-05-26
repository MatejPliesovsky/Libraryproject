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
    public partial class UserProfile : Form
    {
        string userID;
        Connect2DB con;

        public UserProfile(string userID)
        {
            InitializeComponent();
            ErrorMessage.Visible = false;
            con = new Connect2DB();
            this.userID = userID;
            if (userID == null)
            {
                ErrorMessage.Visible = true;
            }
            else
            {
                UserAllName.Text = con.getUserAllName(userID);
                if (UserAllName.Text == null)
                {
                    ErrorMessage.Visible = true;
                }
                else
                {
                    UserAge.Text = "Age: " + con.getUserAge(userID);
                }
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserInterface form = new FormUserInterface(userID);
            form.Show();
            this.Close();
        }

        private void editProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserProfile.ActiveForm.Refresh();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditProfile_Click(object sender, EventArgs e)
        {
            FormUserDetails form = new FormUserDetails(userID);
            form.ShowDialog();
        }
    }
}
