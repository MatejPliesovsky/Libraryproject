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
    public partial class FormConfirmDeleting : Form
    {
        Connect2DB connection;
        string UserID;

        public FormConfirmDeleting(string message, string UserID) //more info is e.g. user id, for deleting user
        {
            InitializeComponent();
            Message.Text = message;
            this.UserID = UserID;
            connection = new Connect2DB();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            connection.deleteUserFromDatabase(UserID);
            FormUserDetails.ActiveForm.Dispose();
            this.Close();
        }

        private void Refuse_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
