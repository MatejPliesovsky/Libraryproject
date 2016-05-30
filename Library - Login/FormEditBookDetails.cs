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
        string bookID, bookName, author, lent, IDCategory, IDLanguage, desc, publisher, category, language, ISBN, image;

        string[] descrpition;
        Connect2DB db = new Connect2DB();

        public FormEditBookDetails(string info)
        {
            InitializeComponent();
            fillComboBoxBookCategory();
            fillComboBoxBookLanguage();
            this.StartPosition = FormStartPosition.CenterScreen;
            List<string> bookDetail = new List<string>();
            bookDetail = db.bookDetails(info);

            if (bookDetail.Capacity > 0)
            {
                bookID = bookDetail.ElementAt(0);
                bookName = bookDetail.ElementAt(1);
                author = bookDetail.ElementAt(2);
                lent = bookDetail.ElementAt(3);
                IDCategory = bookDetail.ElementAt(4);
                IDLanguage = bookDetail.ElementAt(5);
                desc = bookDetail.ElementAt(6);
                ISBN = bookDetail.ElementAt(7);
                publisher = bookDetail.ElementAt(8);

                language = db.bookLanguage(IDLanguage);
                category = db.bookCategory(IDCategory);

                descrpition = desc.Split('.');
                desc = "";

                txtIDBook.Text = bookID;
                txtBookName.Text = bookName;
                txtBookAuthor.Text = author;
                txtBookPublisher.Text = publisher;
                txtBookCategory.Text = category;
                txtBookLanguage.Text = language;
                txtBookISBN.Text = ISBN;
                txtImagePath.Enabled = false;
                for (int i = 0; i < descrpition.Length; i++)
                {
                    desc = desc + descrpition[i];
                }
                txtBookDescription.Text = desc;

                pictureBox1.Image = Image.FromStream(new System.IO.MemoryStream(db.getImageByBookId(bookID)));
                pictureBox1.Refresh();
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Sure delete this book?", "Delete this book?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (db.deleteBookFromDatabase(bookID))
                {
                    MessageBox.Show("Book successfully DELETED");
                    this.Close();
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Book NOT Successfully DELETED");
            }

        }

        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            if(txtImagePath.Enabled == false)
            {
                bookName = txtBookName.Text;
                author = txtBookAuthor.Text;
                publisher = txtBookPublisher.Text;
                ISBN = txtBookISBN.Text;
                IDCategory = comboNewCategory.SelectedValue.ToString();
                IDLanguage = comboNewLanguage.SelectedValue.ToString();
                for (int i = 0; i < descrpition.Length; i++)
                {
                    desc = desc + descrpition[i];
                }
                desc = txtBookDescription.Text;

                string details = bookID + ";" + bookName + ";" + author + ";" + publisher + ";" + ISBN + ";" + desc;

                if (db.updateBookdetailsDataWithOutImage(details, IDCategory, IDLanguage))
                    MessageBox.Show("Book successfully Update");

                else
                    MessageBox.Show("Book NOT successfully Update");
            }

            else if(txtImagePath.Enabled == true)
            {
                bookName = txtBookName.Text;
                author = txtBookAuthor.Text;
                publisher = txtBookPublisher.Text;
                ISBN = txtBookISBN.Text;
                image = txtImagePath.Text;
                IDCategory = comboNewCategory.SelectedValue.ToString();
                IDLanguage = comboNewLanguage.SelectedValue.ToString();
                for (int i = 0; i < descrpition.Length; i++)
                {
                    desc = desc + descrpition[i];
                }
                desc = txtBookDescription.Text;

                string details = bookID + ";" + bookName + ";" + author + ";" + publisher + ";" + ISBN + ";" + desc;

                if (db.updateBookdetailsDataWithImage(details, image, IDCategory, IDLanguage))
                    MessageBox.Show("Book successfully Update");

                else
                    MessageBox.Show("Book NOT successfully Update");
            }         

        }


        private void btnLoadImage_Click(object sender, EventArgs e)
        {   
            txtImagePath.Enabled = true;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string pictPatch = dlg.FileName.ToString();
                txtImagePath.Text = pictPatch;
                pictureBox1.ImageLocation = pictPatch;
            }
        }


        private void fillComboBoxBookCategory()
        {
            List<string> cat = db.loadBookCategoryName();
            comboNewCategory.DataSource = cat;

        }


        private void fillComboBoxBookLanguage()
        {
            List<string> lang = db.loadBookLanguageName();
            comboNewLanguage.DataSource = lang;
        }


    }
}
