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
    public partial class FormAddBookLanguage : Form
    {
        Connect2DB connection = new Connect2DB();

        public FormAddBookLanguage()
        {
            InitializeComponent();
        }

        private void btnAddBookLanguage_Click(object sender, EventArgs e)
        {
            if (connection.openConnection())
            {
                String sqlQuery = "INSERT INTO BookLanguage (LanguageName) VALUES('" + this.txtBookLanguage.Text + "');";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection.connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                connection.closeConnection();

                if(cmd == null)
                {
                    MessageBox.Show("ERROR: Language not added!");
                }

                else
                {
                    MessageBox.Show("Language successfully added");
                }

            }

        }
    }

}
