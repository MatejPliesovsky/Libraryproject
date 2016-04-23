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
    public partial class FormUserInterface : Form
    {
        Connect2DB connection;



        public FormUserInterface()
        {
            InitializeComponent();
            connection = new Connect2DB();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SearchFree.Checked = false;
            SearchBar.Text = "";
            Form2_Shown(Refresh, null);
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            List<string> books = new List<string>();
            List<string> authors = new List<string>();
            List<string> Lents = new List<string>();

            books = connection.searchBookNames(null, false);
            authors = connection.searchAuthor(null, false);
            Lents = connection.searchLents(null, false);

            for (int i = 0; i < books.Count; i++)
            {
                ListViewItem item = new ListViewItem(books[i]);
                item.SubItems.Add(authors[i]);
                item.SubItems.Add(Lents[i]);

                listView1.Items.Add(item);
            }
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            string search;
            List<string> books = new List<string>();
            List<string> authors = new List<string>();
            List<string> Lents = new List<string>();

            listView1.Items.Clear();
            if (SearchFree.Checked==true)
            {
                search = SearchBar.Text;
                books = connection.searchBookNames(search, true);
                authors = connection.searchAuthor(search, true);
                Lents = connection.searchLents(search, true);
            }
            else
            {
                search = SearchBar.Text;
                books = connection.searchBookNames(search, false);
                authors = connection.searchAuthor(search, false);
                Lents = connection.searchLents(search, false);
            }
            
            for (int i = 0; i < books.Count; i++)
            {
                ListViewItem item = new ListViewItem(books[i]);
                item.SubItems.Add(authors[i]);
                item.SubItems.Add(Lents[i]);

                listView1.Items.Add(item);
            }

        }

        private void SearchFree_CheckedChanged(object sender, EventArgs e)
        {
            bool lent;
            string search;
            List<string> books = new List<string>();
            List<string> authors = new List<string>();
            List<string> Lents = new List<string>();

            listView1.Items.Clear();
          
            search = SearchBar.Text;
            lent = true;
            books = connection.searchBookNames(search, lent);
            authors = connection.searchAuthor(search, lent);
            Lents = connection.searchLents(search, lent);


            for (int i = 0; i < books.Count; i++)
            {
                ListViewItem item = new ListViewItem(books[i]);
                item.SubItems.Add(authors[i]);
                item.SubItems.Add(Lents[i]);

                listView1.Items.Add(item);
            }

        }

        private void bookDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Update();
            }
        }

        private void listView1_ItemSelectionChanged_1(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            int index = 0;
            index = (listView1.SelectedIndices.Count) - 1;
            if (index < 0)
            {
                index = index + listView1.SelectedIndices.Count;
            }
            else
            {
                string info = listView1.SelectedItems[index].Text;
                FormBookDetail bookDetail = new FormBookDetail(info);
                bookDetail.ShowDialog();
                Search_btn.Select();
                this.Update();
            }
        }
    }
}
    