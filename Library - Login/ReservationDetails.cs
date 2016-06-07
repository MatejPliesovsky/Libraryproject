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
    /// show details of reservation
    /// </summary>
    public partial class ReservationDetails : Form
    {
        string AdminID, userID, bookStatus;
        string bookID, author, bookCategory, bookLanguage, categoryID, languageID;
        int counter;
        byte[] data;
        Connect2DB connect;
        DateTime borrowing;
        Encoding enc;

        public ReservationDetails(string AdminID, string bookName)
        {
            InitializeComponent();
            DatabaseInfo.Visible = false;
            this.AdminID = AdminID;
            connect = new Connect2DB();
            borrowing = new DateTime();
            enc = new UTF8Encoding(true, true);
            this.StartPosition = FormStartPosition.CenterScreen;

            List<string> BookData = new List<string>();
            BookData = connect.bookDetails(bookName);

            if (BookData.Count == 0)
            {
                DatabaseInfo.Visible = true;
                BookName.Text = "Book name: ";
                Author.Text = "Author: ";
                Category.Text = "Category: ";
                Language.Text = "Language: ";

                UserName.Text = "User: ";
                UserAge.Text = "Age: ";
            }
            else
            {
                bookID = BookData[0].ToString();
                bookName = "Book name: " + BookData[1].ToString();
                author = "Author: " + BookData[2].ToString();
                categoryID = BookData[4].ToString();
                languageID = BookData[5].ToString();

                bookLanguage = "Language: " + connect.bookLanguage(languageID);
                bookCategory = "Category: " + connect.bookCategory(categoryID);

                BookName.Text = bookName;
                Author.Text = author;
                Category.Text = bookCategory;
                Language.Text = bookLanguage;

                bookStatus = BookData[3].ToString();

                UserName.Text = "User: " + connect.findUserAllName(bookID, bookStatus);
                UserAge.Text = "Age: " + connect.findUserAge(bookID, bookStatus);
                userID = connect.findUserIDByBookID(bookID, bookStatus);

                PictureBox.Image = Image.FromStream(new System.IO.MemoryStream(connect.getImageByBookId(bookID)));
                PictureBox.Refresh();

                counter = connect.checkSumOfReservation(userID, true);
                if (counter == 5)
                {
                    Confirm.Hide();
                    DatabaseInfo.Text = "User has already 5 borrowed books.";
                    DatabaseInfo.Visible = true;
                }
                if (bookStatus == "borrowed")
                {
                    Confirm.Text = "Remove borrowing";
                    Refuse.Text = "Back";

                    borrowing = connect.checkBorrowingDate(bookID, userID);

                    if(borrowing < DateTime.Today)
                    {
                        string penalty;
                        if(DateTime.Today <= borrowing.AddDays(7))
                        {
                            penalty = connect.getPenalty(1);
                            Penalty.Text = UserName.Text + " has penalty " + penalty + " EURO for this book.\nHe must pay only biggest penalty.";
                            Penalty.Visible = true;
                        }
                        else if (DateTime.Today > borrowing.AddDays(7) && DateTime.Today <= borrowing.AddMonths(1))
                        {
                            penalty = connect.getPenalty(2);
                            Penalty.Text = UserName.Text + " has penalty " + penalty + " EURO for this book.\nHe must pay only biggest penalty.";
                            Penalty.Visible = true;
                        }
                        else if (DateTime.Today > borrowing.AddMonths(1) && DateTime.Today <= borrowing.AddMonths(2))
                        {
                            penalty = connect.getPenalty(3);
                            Penalty.Text = UserName.Text + " has penalty " + penalty + " EURO for this book.\nHe must pay only biggest penalty.";
                            Penalty.Visible = true;
                        }
                        else if (borrowing.AddMonths(2) < DateTime.Today)
                        {
                            penalty = connect.getPenalty(4);
                            Penalty.Text = UserName.Text + " has penalty " + penalty + " EURO for this book.\nHe must pay only biggest penalty.\nThis user is Blocked";
                            Penalty.Visible = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// confirm reservation to borrowing state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirm_Click(object sender, EventArgs e)
        {
            if (bookStatus == "borrowed")
            {
                if (connect.removeBorrowing(bookID))
                {
                    DatabaseInfo.Text = "Borrow was remove successuly";
                    timer1.Interval = 5000;
                    timer1.Tick += new EventHandler(Timer1_Tick);
                    DatabaseInfo.Visible = true;
                    timer1.Start();
                }
                else
                {
                    DatabaseInfo.Text = "Cannot connect to database!";
                    timer1.Interval = 5000;
                    timer1.Tick += new EventHandler(Timer1_Tick);
                    DatabaseInfo.Visible = true;
                    timer1.Start();
                }
            }
            else
            {
                DateTime today = DateTime.Today;
                DateTime returns = DateTime.Today.AddDays(30);

                string dateOfBorrowing = today.Year + "-" + today.Month + "-" + today.Day;
                string dateOfReturn = returns.Year + "-" + returns.Month + "-" + returns.Day;

                if (connect.dropBookFromReservations(bookID))
                {
                    if (connect.addBorrowing(dateOfBorrowing, dateOfReturn, bookID, userID))
                    {
                        DatabaseInfo.Text = "Book was borrowed successuly";
                        timer1.Interval = 5000;
                        timer1.Tick += new EventHandler(Timer1_Tick);
                        DatabaseInfo.Visible = true;
                        timer1.Start();
                    }
                }
                else
                {
                    DatabaseInfo.Text = "Cannot connect to database!";
                    timer1.Interval = 5000;
                    timer1.Tick += new EventHandler(Timer1_Tick);
                    DatabaseInfo.Visible = true;
                    timer1.Start();
                }
            }
        }

        private void Refuse_Click(object sender, EventArgs e)
        {
            if (bookStatus == "borrowed")
            {
                this.Close();
            }
            else
            {
                connect.deleteReservation(bookID, userID);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DatabaseInfo.Visible = false;
            timer1.Stop();
        }
    }
}
