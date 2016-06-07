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
    /// for bor adding new borrowing of book
    /// </summary>
    public partial class FormAddBorrowing : Form
    {
        Connect2DB con;
        Encoding enc;
        byte[] data, book1, book2, book3, book4, book5, user;
        string userName, userID;
        int counter;

        public FormAddBorrowing()
        {
            InitializeComponent();
            con = new Connect2DB();
            enc = new UTF8Encoding(true, true);
            InfoMessage.Visible = false;
            List<string> books = new List<string>();
            books = con.searchBooksToListView(null, false, null, null);
            counter = 0;
            for (int i = 0;i < books.Count; i++)
            {
                data = enc.GetBytes(books[i]);
                BookName1.Items.Add(enc.GetString(data));
                BookName2.Items.Add(enc.GetString(data));
                BookName3.Items.Add(enc.GetString(data));
                BookName4.Items.Add(enc.GetString(data));
                BookName5.Items.Add(enc.GetString(data));
            }
        }

        /// <summary>
        /// load username to list of borrowings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserName_TextChanged(object sender, EventArgs e)
        {
            List<string> users;
            user = enc.GetBytes(UserName.Text);
            userName = enc.GetString(user);
            UserID.Items.Clear();
            if (userName != "")
            {
                users = con.getAllUsers(userName);
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

        /// <summary>
        /// get user ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserID_SelectedIndexChanged(object sender, EventArgs e)
        {
            userID = UserID.Text;
            user = enc.GetBytes(con.getUserAllName(userID));
            userName = enc.GetString(user);
            UserName.Text = userName;
            UserID.Text = userID;

            counter = con.checkSumOfReservation(UserID.Text, true);
            if (counter == 5)
            {
                Confirm.Hide();
                InfoMessage.Text = "User has already 5 loaner books.";
                timer1.Interval = 5000;
                timer1.Tick += new EventHandler(Timer1_Tick);
                InfoMessage.Visible = true;
                timer1.Start();
            }
        }

        /// <summary>
        /// select bookname from list and show in borrowing list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BookName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] bookNames = new string[5];
            if (BookName1.Text != "")
            {
                book1 = enc.GetBytes(BookName1.Text);
                BookName2.Items.Remove(enc.GetString(book1));
                BookName3.Items.Remove(enc.GetString(book1));
                BookName4.Items.Remove(enc.GetString(book1));
                BookName5.Items.Remove(enc.GetString(book1));
                bookNames[0] = enc.GetString(book1);
            }
            if (BookName2.Text != "")
            {
                book2 = enc.GetBytes(BookName2.Text);
                BookName1.Items.Remove(enc.GetString(book2));
                BookName3.Items.Remove(enc.GetString(book2));
                BookName4.Items.Remove(enc.GetString(book2));
                BookName5.Items.Remove(enc.GetString(book2));
                bookNames[1] = enc.GetString(book2);
            }
            if (BookName3.Text != "")
            {
                book3 = enc.GetBytes(BookName3.Text);
                BookName1.Items.Remove(enc.GetString(book3));
                BookName2.Items.Remove(enc.GetString(book3));
                BookName4.Items.Remove(enc.GetString(book3));
                BookName5.Items.Remove(enc.GetString(book3));
                bookNames[2] = enc.GetString(book3);
            }
            if (BookName4.Text != "")
            {
                book4 = enc.GetBytes(BookName4.Text);
                BookName1.Items.Remove(enc.GetString(book4));
                BookName2.Items.Remove(enc.GetString(book4));
                BookName3.Items.Remove(enc.GetString(book4));
                BookName5.Items.Remove(enc.GetString(book4));
                bookNames[3] = enc.GetString(book4);
            }
            if (BookName5.Text != "")
            {
                book5 = enc.GetBytes(BookName5.Text);
                BookName1.Items.Remove(enc.GetString(book5));
                BookName2.Items.Remove(enc.GetString(book5));
                BookName3.Items.Remove(enc.GetString(book5));
                BookName4.Items.Remove(enc.GetString(book5));
                bookNames[4] = enc.GetString(book5);
            }
            if (bookNames[0] != null)
            {
                BookName1.Text = enc.GetString(book1);
            }
            if (bookNames[1] != null)
            {
                BookName2.Text = enc.GetString(book2);
            }
            if (bookNames[2] != null)
            {
                BookName3.Text = enc.GetString(book3);
            }
            if (bookNames[3] != null)
            {
                BookName4.Text = enc.GetString(book4);
            }
            if (bookNames[4] != null)
            {
                BookName5.Text = enc.GetString(book5);
            }
        }

        /// <summary>
        /// confirming button of borrowings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    bookID = con.findBookID(enc.GetString(book1));
                    if (con.addBorrowing(dateOfLoan, dateOfReturn, bookID, userID))
                    {
                        InfoMessage.Text = "Borrowing was add.";
                    
                        if (BookName2.Text != "")
                        {
                            bookID = con.findBookID(enc.GetString(book2));
                            if (con.addBorrowing(dateOfLoan, dateOfReturn, bookID, userID))
                            {
                                InfoMessage.Text = "Borrowings was add.";
                            }
                        }
                        if (BookName3.Text != "")
                        {
                            bookID = con.findBookID(enc.GetString(book3));
                            con.addBorrowing(dateOfLoan, dateOfReturn, bookID, userID);
                        }
                        if (BookName4.Text != "")
                        {
                            bookID = con.findBookID(enc.GetString(book4));
                            con.addBorrowing(dateOfLoan, dateOfReturn, bookID, userID);
                        }
                        if (BookName5.Text != "")
                        {
                            bookID = con.findBookID(enc.GetString(book5));
                            con.addBorrowing(dateOfLoan, dateOfReturn, bookID, userID);
                        }
                    }
                    else
                    {
                        InfoMessage.Text = "Error. Cannot connect to database.";
                    }
                    timer1.Interval = 5000;
                    timer1.Tick += new EventHandler(Timer1_Tick);
                    InfoMessage.Visible = true;
                    timer1.Start();
                }
                else
                {
                    InfoMessage.Text = "Add at least one book.";
                    timer1.Interval = 5000;
                    timer1.Tick += new EventHandler(Timer1_Tick);
                    InfoMessage.Visible = true;
                    timer1.Start();
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            InfoMessage.Visible = false;
            timer1.Stop();
        }
    }
}
