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
    public partial class FormAddLoan : Form
    {
        Connect2DB con = new Connect2DB();
        public FormAddLoan()
        {
            InitializeComponent();
            List<string> books = new List<string>();
            books = con.searchBookNames(null, false, null, null);
            for (int i = 0;i < books.Count; i++)
            {
                BookName1.Items.Add(books[i]);
                BookName2.Items.Add(books[i]);
                BookName3.Items.Add(books[i]);
                BookName4.Items.Add(books[i]);
                BookName5.Items.Add(books[i]);
            }
        }

        private void UserName_TextChanged(object sender, EventArgs e)
        {
            List<string> users;
            string name = UserName.Text;
            UserID.Items.Clear();
            if (name != "")
            {
                users = con.getAllUsers(name);
                for (int i = 0; i < users.Count; i++)
                {
                    UserID.Items.Add(users[i]);
                }
                if (users.Count > 0 && UserID.Text == "")
                {
                    UserID.DroppedDown = true;
                }
            }
            else
            {
                UserID.Items.Clear();
                UserID.Text = "";
                UserID.DroppedDown = false;
            }
        }

        private void UserID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string userID = UserID.Text;
            string userName = con.getUserAllName(userID);
            UserName.Text = userName;
            UserID.Text = userID;
        }

        private void BookName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] bookNames = new string[5];
            if (BookName1.Text != "")
            {
                BookName2.Items.Remove(BookName1.Text);
                BookName3.Items.Remove(BookName1.Text);
                BookName4.Items.Remove(BookName1.Text);
                BookName5.Items.Remove(BookName1.Text);
                bookNames[0] = BookName1.Text;
            }
            if (BookName2.Text != "")
            {
                BookName1.Items.Remove(BookName2.Text);
                BookName3.Items.Remove(BookName2.Text);
                BookName4.Items.Remove(BookName2.Text);
                BookName5.Items.Remove(BookName2.Text);
                bookNames[1] = BookName2.Text;
            }
            if (BookName3.Text != "")
            {
                BookName1.Items.Remove(BookName3.Text);
                BookName2.Items.Remove(BookName3.Text);
                BookName4.Items.Remove(BookName3.Text);
                BookName5.Items.Remove(BookName3.Text);
                bookNames[2] = BookName3.Text;
            }
            if (BookName4.Text != "")
            {
                BookName1.Items.Remove(BookName4.Text);
                BookName2.Items.Remove(BookName4.Text);
                BookName3.Items.Remove(BookName4.Text);
                BookName5.Items.Remove(BookName4.Text);
                bookNames[3] = BookName4.Text;
            }
            if (BookName5.Text != "")
            {
                BookName1.Items.Remove(BookName5.Text);
                BookName2.Items.Remove(BookName5.Text);
                BookName3.Items.Remove(BookName5.Text);
                BookName4.Items.Remove(BookName5.Text);
                bookNames[4] = BookName5.Text;
            }
            if (bookNames[0] != null)
            {
                BookName1.Text = bookNames[0];
            }
            if (bookNames[1] != null)
            {
                BookName2.Text = bookNames[1];
            }
            if (bookNames[2] != null)
            {
                BookName3.Text = bookNames[2];
            }
            if (bookNames[3] != null)
            {
                BookName4.Text = bookNames[3];
            }
            if (bookNames[4] != null)
            {
                BookName5.Text = bookNames[4];
            }
        }
    }
}
