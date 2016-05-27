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
    public partial class Users : Form
    {
        string userID;
        public Users(string userID)
        {
            InitializeComponent();
            ErrorMessage.Visible = false;
            Connect2DB con = new Connect2DB();
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

        private void UserAllName_Click(object sender, EventArgs e)
        {

        }
    }
}
