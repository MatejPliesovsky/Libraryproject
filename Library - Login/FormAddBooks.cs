using MySql.Data.MySqlClient;
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
    public partial class FormAddBooks : Form
    {

        Connect2DB database = new Connect2DB();
        private string BookName, Author, IDcategory, IDLanguage, ISBN, Publisher, Description, image;

        public FormAddBooks()
        {
            InitializeComponent();
            fillComboBoxBookCategory();
            fillComboBoxBookLanguage();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            BookName = this.txtBookName.Text;
            Author = this.txtAuthor.Text;
            IDcategory = comboBoxBookCategory.SelectedValue.ToString();
            IDLanguage = comboBoxBookLanguage.SelectedValue.ToString();
            ISBN = this.txtISBN.Text;
            Publisher = this.txtPublisher.Text;
            Description = this.richTxtBookDescreption.Text;
            image = this.txtImagePath.Text;

            if (database.addBook(BookName, Author, IDcategory, IDLanguage, image, ISBN, Publisher, Description))
            {
                MessageBox.Show("Book successfully added");
                pictureBox1.Image = Properties.Resources.noimage;
                txtImagePath.Text = null;
                txtBookName.Text = null;
                txtAuthor.Text = null;
                txtISBN.Text = null;
                txtPublisher.Text = null;
                richTxtBookDescreption.Text = null;                
            }

            else
            {
                MessageBox.Show("Book Not added, please check Debug Log");
            }
        }

        private void fillComboBoxBookCategory()
        {
            List<string> cat = database.loadBookCategoryName();
            comboBoxBookCategory.DataSource = cat;

        }


        private void fillComboBoxBookLanguage()
        {
            List<string> lang = database.loadBookLanguageName();
            comboBoxBookLanguage.DataSource = lang;
        }



        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string pictPatch = dlg.FileName.ToString();
                txtImagePath.Text = pictPatch;
                pictureBox1.ImageLocation = pictPatch;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }
    }
}
