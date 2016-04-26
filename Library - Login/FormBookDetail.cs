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
    public partial class FormBookDetail : Form
    {
        public FormBookDetail(string info)
        {
            InitializeComponent();
            Connect2DB connect = new Connect2DB();
            List<string> bookDetail = new List<string>();
            bookDetail = connect.bookDetails(info);
            string bookID, bookName, author, lent, categoryID, languageID, description, publisher, category, language;
            if (bookDetail.Capacity > 0)
            {
                bookID = bookDetail.ElementAt(0);
                bookName = "Book name: " + bookDetail.ElementAt(1);
                author = "Author: " + bookDetail.ElementAt(2);
                lent = "Lent status: " + bookDetail.ElementAt(3);
                categoryID = bookDetail.ElementAt(4);
                languageID = bookDetail.ElementAt(5);
                description = "Description: " + bookDetail.ElementAt(6);
                publisher = "Publisher :" + bookDetail.ElementAt(7);

                language = "Language: " + connect.bookLanguage(languageID);
                category = "Category: " + connect.bookCategory(categoryID);

                BookName.Text = bookName;
                Author.Text = author;
                Publisher.Text = publisher;
                Category.Text = category;
                Language.Text = language;
                Lent.Text = lent;
                Description.Text = description;
            }
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
