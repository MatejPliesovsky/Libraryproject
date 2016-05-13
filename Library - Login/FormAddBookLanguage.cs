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
        private string LanguageName;

        public FormAddBookLanguage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnAddBookLanguage_Click(object sender, EventArgs e)
        {
            Connect2DB database = new Connect2DB();

            LanguageName = this.txtBookLanguage.Text;

            if (database.addBookLanguage(LanguageName))
            {
                MessageBox.Show("Language successfully added");
            }

            else
            {
                MessageBox.Show("ERROR: Language not added!");
            }

        }
    }

}
