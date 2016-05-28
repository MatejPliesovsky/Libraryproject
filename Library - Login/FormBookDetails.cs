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
    public partial class FormBookDetails : Form
    {
        string userID;
        string bookID;
        Connect2DB connect = new Connect2DB();

        public FormBookDetails(string info, string userID)
        {
            InitializeComponent();
            this.userID = userID;
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
                    desc = desc + descrpition[i] + ".\n";
                }
                Description.Text = "Description: " + desc;

                PictureBox.Image = Image.FromStream(new System.IO.MemoryStream(connect.getImageByBookId(bookID)));
                PictureBox.Refresh();
                PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        public void checkBookStatus() { 
        if (connect.checkIfBookIsFree(bookID) == true)
            {
                Reserve.Show();
                DeleteRes.Hide();
            }
        else{
                if (connect.checkBookisReservedByUser(bookID, userID))
                {
                    DeleteRes.Show();
                    Exception.Text = "You have already reserved this book";
                }
                else
                {
                    DeleteRes.Hide();                    
                    Exception.Text = "Book is lent or reserved by another user";
                }
                Reserve.Hide();
                Exception.Visible = true;
            }
        }


    private void Reserve_Click(object sender, EventArgs e)
        { 
                connect.reserveBook(bookID, userID);
            messageLabel.Show();
            messageLabel.Text = "You have reservate this book";
        }

        private void DeleteRes_Click(object sender, EventArgs e)
        {
            connect.deleteReservation(bookID, userID);
            messageLabel.Show();
            messageLabel.Text = "You have decline reservation";

        }

        private void FormBookDetails_Shown(object sender, EventArgs e)
        {
            checkBookStatus();
            connect.checkBookisReservedByUser(bookID, userID);
        }

        private void FormBookDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
