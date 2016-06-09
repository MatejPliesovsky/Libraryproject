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
    /// form for adding book category
    /// </summary>
    public partial class FormAddBookCategory : Form
    {
        private string CategoryName;
        byte[] data;
        Encoding enc;

        public FormAddBookCategory()
        {
            InitializeComponent();
            enc = new UTF8Encoding(true, true);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// button for confirm of adding new book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddBookCategory_Click(object sender, EventArgs e)
        {
            Connect2DB database = new Connect2DB();

            data = enc.GetBytes(txtBookCategory.Text);
            CategoryName = enc.GetString(data);

            if (database.addBookCategory(CategoryName))
            {
                MessageBox.Show("Category successfully added");
            }

            else
            {
                MessageBox.Show("ERROR: Category not added!");
            }

        
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
