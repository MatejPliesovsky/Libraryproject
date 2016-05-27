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
    public partial class ReservationDetails : Form
    {
        string AdminID, userID, bookStatus;
        string bookID, author, bookCategory, bookLanguage, categoryID, languageID;
        Connect2DB connect;

        public ReservationDetails(string AdminID, string bookName)
        {
            InitializeComponent();
            DatabaseInfo.Visible = false;
            this.AdminID = AdminID;
            connect = new Connect2DB();
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

                bookStatus = connect.findBookStatus(bookID);

                UserName.Text = "User: " + connect.findUserAllName(bookID, bookStatus);
                UserAge.Text = "Age: " + connect.findUserAge(bookID, bookStatus);
                userID = connect.findUserIDByBookID(bookID);

                PictureBox.Image = Image.FromStream(new System.IO.MemoryStream(connect.getImageByBookId(bookID)));
                PictureBox.Refresh();
                if (bookStatus == "lent")
                {
                    Confirm.Text = "Remove loan";
                    Refuse.Text = "Back";
                }
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (bookStatus == "lent")
            {
                if (connect.removeLoan(bookID))
                {
                    if (connect.dropBookFromReservations(bookID))
                    {
                        DatabaseInfo.Text = "Lent was remove successuly";
                        DatabaseInfo.Visible = true;
                    }
                }
                else
                {
                    DatabaseInfo.Text = "Cannot connect to database!";
                    DatabaseInfo.Visible = true;
                }
            }
            else
            {
                DateTime today = DateTime.Today;
                DateTime returns = DateTime.Today.AddDays(30);

                string dateOfLoan = today.Year + "-" + today.Month + "-" + today.Day;
                string dateOfReturn = returns.Year + "-" + returns.Month + "-" + returns.Day;

                if (connect.addLoans(dateOfLoan, dateOfReturn, bookID, userID))
                {
                    if (connect.dropBookFromReservations(bookID))
                    {
                        DatabaseInfo.Text = "Book was lent successuly";
                        DatabaseInfo.Visible = true;
                    }
                }
                else
                {
                    DatabaseInfo.Text = "Cannot connect to database!";
                    DatabaseInfo.Visible = true;
                }
            }
        }

        private void Refuse_Click(object sender, EventArgs e)
        {
            if (bookStatus == "lent")
            {
                this.Close();
            }
            else
            {
                connect.deleteReservation(bookID, userID);
            }
        }
    }
}
