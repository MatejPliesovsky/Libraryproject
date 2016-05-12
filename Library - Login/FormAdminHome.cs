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
    public partial class FormAdminHome : Form
    {
        Connect2DB connection = new Connect2DB();
        string adminID;

        public FormAdminHome(string username, string password)
        {
            InitializeComponent();
            this.adminID = connection.FindUser(username, password);
            addItemsToList();
        }

        public FormAdminHome(string adminID)
        {
            InitializeComponent();
            this.adminID = adminID;
            addItemsToList();
        }

        private void addItemsToList()
        {
            List<string> books = new List<string>();
            List<string> authors = new List<string>();
            List<string> lents = new List<string>();
            List<string> category = new List<string>();

            listView1.Items.Clear();

            books = connection.lastBookNames();
            authors = connection.lastAuthors();
            lents = connection.lastLents();
            category = connection.lastCategories();

            if (books != null)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    ListViewItem item = new ListViewItem(books[i]);
                    item.SubItems.Add(authors[i]);
                    item.SubItems.Add(lents[i]);
                    item.SubItems.Add(category[i]);

                    listView1.Items.Add(item);
                }
            }
            else
            {
                DatabaseInfo.Visible = true;
            }
        }
    }
}
