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
        int counter;

        public FormAddLoan()
        {
            InitializeComponent();
            InfoMessage.Visible = false;
            List<string> books = new List<string>();
            books = con.searchBooksToListView(null, false, null, null);
            counter = 0;
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

            counter = con.checkSumOfReservation(UserID.Text, true);
            if (counter == 5)
            {
                Confirm.Hide();
                InfoMessage.Text = "User has already 5 loaner books.";
                InfoMessage.Visible = true;
            }
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

        private void Confirm_Click(object sender, EventArgs e)
        {
            DateTime dateOfRet = new DateTime();
            string dateOfLoan, dateOfReturn, bookID;
            if (UserName.Text != "" && UserID.Text != "")
            {
                dateOfLoan = DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day;
                dateOfRet = DateTime.Today.AddDays(30);
                dateOfReturn = dateOfRet.Year + "-" + dateOfRet.Month + "-" + dateOfRet.Day;
                if (BookName1.Text != "")
                {
                    bookID = con.findBookID(BookName1.Text);
                    if (con.addLoans(dateOfLoan, dateOfReturn, bookID, UserID.Text))
                    {
                        InfoMessage.Text = "Loan was added.";
                    
                        if (BookName2.Text != "")
                        {
                            bookID = con.findBookID(BookName2.Text);
                            if (con.addLoans(dateOfLoan, dateOfReturn, bookID, UserID.Text))
                            {
                                InfoMessage.Text = "Loans was added.";
                            }
                        }
                        if (BookName3.Text != "")
                        {
                            bookID = con.findBookID(BookName3.Text);
                            con.addLoans(dateOfLoan, dateOfReturn, bookID, UserID.Text);
                        }
                        if (BookName4.Text != "")
                        {
                            bookID = con.findBookID(BookName4.Text);
                            con.addLoans(dateOfLoan, dateOfReturn, bookID, UserID.Text);
                        }
                        if (BookName5.Text != "")
                        {
                            bookID = con.findBookID(BookName5.Text);
                            con.addLoans(dateOfLoan, dateOfReturn, bookID, UserID.Text);
                        }
                    }
                    else
                    {
                        InfoMessage.Text = "Error. Cannot connect to database.";
                    }
                    InfoMessage.Visible = true;
                }
                else
                {
                    InfoMessage.Text = "Add at least one book.";
                    InfoMessage.Visible = true;
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
