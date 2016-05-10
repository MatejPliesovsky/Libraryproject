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
        string UserID;

        public FormUserInterface()
        {
            InitializeComponent();
            connection = new Connect2DB();
            SwitchToAdmin.Visible = false;
            SwitchToAdmin.Enabled = false;
        }

        public FormUserInterface(string UserID)
        {
            InitializeComponent();
            connection = new Connect2DB();
            this.UserID = UserID;
            string userRole = connection.getUserRole(UserID);
            if (userRole == "admin")
            {
                SwitchToAdmin.Visible = true;
                SwitchToAdmin.Enabled = true;
            }
            else
            {
                SwitchToAdmin.Visible = false;
                SwitchToAdmin.Enabled = false;
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SearchFree.Checked = false;
            SearchBar.Text = "";
            for (int i = 0;i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
            for (int j = 0; j < checkedListBox1.Items.Count; j++)
            {
                checkedListBox2.SetItemCheckState(j, CheckState.Unchecked);
            }
            Form2_Shown(Refresh, null);
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            string categories = null;
            listView1.Items.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    categories = categories + checkedListBox1.Items[i].ToString() + ";";
                }
            }

            List<string> books = new List<string>();
            List<string> authors = new List<string>();
            List<string> Lents = new List<string>();
            List<string> category = new List<string>();
            List<string> language = new List<string>();

            books = connection.searchBookNames(null, false, categories);
            authors = connection.searchAuthor(null, false, categories);
            Lents = connection.searchLents(null, false, categories);
            category = connection.searchCategory(null, false, categories);
            language = connection.searchLanguage(null, false, categories);

            for (int i = 0; i < books.Count; i++)
            {
                ListViewItem item = new ListViewItem(books[i]);
                item.SubItems.Add(authors[i]);
                item.SubItems.Add(Lents[i]);
                item.SubItems.Add(category[i]);
                item.SubItems.Add(language[i]);

                listView1.Items.Add(item);
            }
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            string search, categories = null;
            List<string> books = new List<string>();
            List<string> authors = new List<string>();
            List<string> Lents = new List<string>();
            List<string> category = new List<string>();
            List<string> language = new List<string>();

            listView1.Items.Clear();
            for (int i = 0;i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    categories = categories + checkedListBox1.Items[i].ToString() + ";";
                }
            }
            for (int j = 0; j < checkedListBox1.Items.Count; j++)
            {
                checkedListBox2.SetItemCheckState(j, CheckState.Unchecked);
            }

            if (SearchFree.Checked==true)
            {
                search = SearchBar.Text;
                books = connection.searchBookNames(search, true, categories);
                authors = connection.searchAuthor(search, true, categories);
                Lents = connection.searchLents(search, true, categories);
                category = connection.searchCategory(search, true, categories);
                language = connection.searchLanguage(search, true, categories);
            }
            else
            {
                search = SearchBar.Text;
                books = connection.searchBookNames(search, false, categories);
                authors = connection.searchAuthor(search, false, categories);
                Lents = connection.searchLents(search, false, categories);
                category = connection.searchCategory(search, false, categories);
                language = connection.searchLanguage(search, false, categories);
            }
            

            for (int i = 0; i < books.Count; i++)
            {
                ListViewItem item = new ListViewItem(books[i]);
                item.SubItems.Add(authors[i]);
                item.SubItems.Add(Lents[i]);
                item.SubItems.Add(category[i]);
                item.SubItems.Add(language[i]);

                listView1.Items.Add(item);
            }

        }

        private void SearchFree_CheckedChanged(object sender, EventArgs e)
        {
            bool lent;
            string search, categories = null;
            List<string> books = new List<string>();
            List<string> authors = new List<string>();
            List<string> Lents = new List<string>();
            List<string> category = new List<string>();
            List<string> language = new List<string>();

            listView1.Items.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    categories = categories + checkedListBox1.Items[i].ToString() + ";";
                }
            }

            search = SearchBar.Text;
            lent = true;
            books = connection.searchBookNames(search, lent, categories);
            authors = connection.searchAuthor(search, lent, categories);
            Lents = connection.searchLents(search, lent, categories);
            category = connection.searchCategory(search, lent, categories);


            for (int i = 0; i < books.Count; i++)
            {
                ListViewItem item = new ListViewItem(books[i]);
                item.SubItems.Add(authors[i]);
                item.SubItems.Add(Lents[i]);
                item.SubItems.Add(category[i]);

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
                FormBookDetails bookDetail = new FormBookDetails(info);
                bookDetail.ShowDialog();
                Search_btn.Select();
                this.Update();
            }
        }

        private void SwitchToAdmin_Click(object sender, EventArgs e)
        {
            FormAdminInterface admin = new FormAdminInterface(UserID);
            admin.Show();
            this.Close();
            admin.FormClosed += new FormClosedEventHandler(AdminForm_FormClosed);
        }

        private void AdminForm_FormClosed(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormUserInterface>().Any())
            {
                FormLogin.ActiveForm.Hide();
            }
            else
            {
                FormLogin.ActiveForm.Show();
            }
        }
    }
}
    