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
    /// form for showing details of book
    /// </summary>
    public partial class FormBookDetails : Form
    {
        string userID, bookID, loan;
        Connect2DB connect;
        int counter;

        public FormBookDetails(string info, string userID)
        {
            InitializeComponent();
            this.userID = userID;
            connect = new Connect2DB();
            counter = 0;
            this.StartPosition = FormStartPosition.CenterScreen;
            List<string> bookDetail = new List<string>();
            bookDetail = connect.bookDetails(info);
            string bookName, author, lent, categoryID, languageID, desc, publisher, category, language;
            string[] descrpition;
            if (bookDetail.Capacity > 0)
            {
                bookID = bookDetail.ElementAt(0);
                bookName = "Book name: " + bookDetail.ElementAt(1);
                author = "Author: " + bookDetail.ElementAt(2);
                lent = "Lent status: " + bookDetail.ElementAt(3);
                loan = bookDetail.ElementAt(3);
                categoryID = bookDetail.ElementAt(4);
                languageID = bookDetail.ElementAt(5);
                desc = bookDetail.ElementAt(6);
                publisher = "Publisher :" + bookDetail.ElementAt(7);

                language = "Language: " + connect.bookLanguage(languageID);
                category = "Category: " + connect.bookCategory(categoryID);

                descrpition = desc.Split('.');
                desc = "";

                BookName.Text = bookName;
                Author.Text = author;
                Publisher.Text = publisher;
                Category.Text = category;
                Language.Text = language;
                Lent.Text = lent;
                for (int i = 0; i < descrpition.Length; i++)
                {
                    desc = desc + descrpition[i];
                }
                Console.WriteLine(desc);
                Description.Text = "Description: " + desc;

                PictureBox.Image = Image.FromStream(new System.IO.MemoryStream(connect.getImageByBookId(bookID)));
                PictureBox.Refresh();
                PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                if (connect.isUserBlocked(userID))
                {
                    Reserve.Enabled = false;
                    Reserve.Visible = false;
                    DeleteRes.Enabled = false;
                    DeleteRes.Visible = false;
                    Exception.Text = "You are blocked. Please, contact your nearest library.";
                    Exception.Visible = true;
                }
            }
        }

        /// <summary>
        /// show status of book
        /// </summary>
        public void checkBookStatus() { 
        if (connect.checkIfBookIsFree(bookID) == true)
            {
                Reserve.Show();
                DeleteRes.Hide();
            }
        else{
                if (connect.checkBookisReservedByUser(bookID, userID, loan))
                {
                    if (loan == "reserved")
                    {
                        DeleteRes.Show();
                    }
                    else
                    {
                        DeleteRes.Hide();
                    }
                    Exception.Text = "You have already " + loan + " this book";
                }
                else
                {
                    DeleteRes.Hide();                    
                    Exception.Text = "Book is " + loan + " by another user";
                }
                Reserve.Hide();
                Exception.Visible = true;
            }
        }

        /// <summary>
        /// if is alloved(show), user can reserve book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
    private void Reserve_Click(object sender, EventArgs e)
        {
            counter = connect.checkSumOfReservation(userID, false);
            if (counter < 5)
            {
                connect.reserveBook(bookID, userID);
                messageLabel.Show();
                messageLabel.Text = "You have reservate this book";
            }
            else
            {
                Reserve.Hide();
                messageLabel.Show();
                messageLabel.Text = "You have already reserved 5 books!";
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteRes_Click(object sender, EventArgs e)
        {
            connect.deleteReservation(bookID, userID);
            messageLabel.Show();
            messageLabel.Text = "You have decline reservation";

        }

        private void FormBookDetails_Shown(object sender, EventArgs e)
        {
            if (connect.isUserBlocked(userID))
            {
                Reserve.Enabled = false;
                Reserve.Visible = false;
                DeleteRes.Enabled = false;
                DeleteRes.Visible = false;
                Exception.Text = "You are blocked. Please, contact your nearest library.";
                Exception.Visible = true;
            }
            else
            {
                checkBookStatus();
            }
        }
    }
}
