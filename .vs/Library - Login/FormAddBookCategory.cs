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
    public partial class FormAddBookCategory : Form
    {
        Connect2DB connection = new Connect2DB();

        public FormAddBookCategory()
        {
            InitializeComponent();
        }

        private void btnAddBookCategory_Click(object sender, EventArgs e)
        {
            if (connection.openConnection())
            {
                String sqlQuery = "INSERT INTO BookCategory (CategoryName) VALUES('" + this.txtBookCategory.Text + "');";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection.connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                }

                connection.closeConnection();

                if (cmd == null)
                {
                    MessageBox.Show("ERROR: Category not added!");
                }

                else
                {
                    MessageBox.Show("Category successfully added");
                }

            }
        }
    }
}
