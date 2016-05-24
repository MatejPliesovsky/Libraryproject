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
    public partial class FormEditBookDetails : Form
    {
        string bookID, bookName, author, lent, categoryID, languageID, desc, publisher, category, language, ISBN;
        string[] descrpition;
        Connect2DB db = new Connect2DB();

        public FormEditBookDetails(string info)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            List<string> bookDetail = new List<string>();
            bookDetail = db.bookDetails(info);

            if (bookDetail.Capacity > 0)
            {
                bookID = bookDetail.ElementAt(0);
                bookName = bookDetail.ElementAt(1);
                author = bookDetail.ElementAt(2);
                lent = bookDetail.ElementAt(3);
                categoryID = bookDetail.ElementAt(4);
                languageID = bookDetail.ElementAt(5);
                desc = bookDetail.ElementAt(6);
                ISBN = bookDetail.ElementAt(7);
                publisher = bookDetail.ElementAt(8);

                language = db.bookLanguage(languageID);
                category = db.bookCategory(categoryID);

                descrpition = desc.Split('.');
                desc = "";

                txtIDBook.Text = bookID;
                txtBookName.Text = bookName;
                txtBookAuthor.Text = author;
                txtBookPublisher.Text = publisher;
                txtBookCategory.Text = category;
                txtBookLanguage.Text = language;
                txtBookISBN.Text = ISBN;
                for (int i = 0; i < descrpition.Length; i++)
                {
                    desc = desc + descrpition[i] + ".\n";
                }
                txtBookDescription.Text = desc;

                pictureBox1.Image = Image.FromStream(new System.IO.MemoryStream(db.getImageByBookId(bookID)));
                pictureBox1.Refresh();
            }

        }

        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            string details = bookID + ";" + bookName + ";" + author + ";" + publisher + ";" + ISBN;

            txtIDBook.Text = bookID;
            txtBookName.Text = bookName;
            txtBookAuthor.Text = author;
            txtBookPublisher.Text = publisher;
            txtBookCategory.Text = category;
            txtBookLanguage.Text = language;
            txtBookISBN.Text = ISBN;
           /* for (int i = 0; i < descrpition.Length; i++)
            {
                desc = desc + descrpition[i] + ".\n";
            }
            txtBookDescription.Text = desc;*/

            if (db.updateBookdetailsData(details))            
                MessageBox.Show("Book successfully Update");
            
            else            
                MessageBox.Show("Book NOT successfully Update");
            

        }
    }
}
