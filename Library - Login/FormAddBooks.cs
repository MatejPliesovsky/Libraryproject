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
    }
}
