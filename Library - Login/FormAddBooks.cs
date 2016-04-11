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
        Connect2DB connection = new Connect2DB();

        public FormAddBooks()
        {
            InitializeComponent();
            fillComboBoxBookCategory();
            fillComboBoxBookLanguage();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {

            if (connection.openConnection())
            {
                String sqlQuery = "INSERT INTO Books (BookName) VALUES('"+this.txtBookName.Text+"');";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection.connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                }

                connection.closeConnection();

            }

        }


        private void fillComboBoxBookCategory()
        {
            if (connection.openConnection())
            {
                String sqlQuery = "SELECT * FROM ReBooksDB.BookCategory;";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection.connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string sCategoryName = reader.GetString("CategoryName");
                    comboBoxBookCategory.Items.Add(sCategoryName);

                }


                connection.closeConnection();
            }
        }


        private void fillComboBoxBookLanguage()
        {
            if (connection.openConnection())
            {
                String sqlQuery = "SELECT * FROM ReBooksDB.BookLanguage;";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection.connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string sLanguageName = reader.GetString("LanguageName");
                    comboBoxBookLanguage.Items.Add(sLanguageName);
                }


                connection.closeConnection();
            }
        }


    }
}
