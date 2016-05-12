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
        private string CategoryName;

        public FormAddBookCategory()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnAddBookCategory_Click(object sender, EventArgs e)
        {
            Connect2DB database = new Connect2DB();

            CategoryName = this.txtBookCategory.Text;

            if (database.addBookCategory(CategoryName))
            {
                MessageBox.Show("Category successfully added");
            }

            else
            {
                MessageBox.Show("ERROR: Category not added!");
            }

        
        }
    }
}
