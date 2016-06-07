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
    /// <summary>
    /// form for adding new book Language
    /// </summary>
    public partial class FormAddBookLanguage : Form
    {
        private string LanguageName;
        byte[] data;
        Encoding enc;

        public FormAddBookLanguage()
        {
            InitializeComponent();
            enc = new UTF8Encoding(true, true);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// confirmbutton for adding new language of book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddBookLanguage_Click(object sender, EventArgs e)
        {
            Connect2DB database = new Connect2DB();

            data = enc.GetBytes(txtBookLanguage.Text);
            LanguageName = enc.GetString(data);

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
