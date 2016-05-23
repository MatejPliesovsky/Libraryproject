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
    public partial class FormEditBook : Form
    {
        Connect2DB connection;

        public FormEditBook()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            connection = new Connect2DB();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SearchBar.Text = "";
    
            Form2_Shown(Refresh, null);
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            string categories = null, languages = null;
            listView1.Items.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    categories = categories + checkedListBox1.Items[i].ToString() + ";";
                }
                if (checkedListBox2.GetItemCheckState(i) == CheckState.Checked)
                {
                    languages = languages + checkedListBox2.Items[i].ToString() + ";";
                }
            }

            List<string> books = new List<string>();
            List<string> authors = new List<string>();
            List<string> Lents = new List<string>();
            List<string> category = new List<string>();
            List<string> language = new List<string>();

            books = connection.searchBookNames(null, false, categories, languages);
            authors = connection.searchAuthor(null, false, categories, languages);
            Lents = connection.searchLents(null, false, categories, languages);
            category = connection.searchCategory(null, false, categories, languages);
            language = connection.searchLanguage(null, false, categories, languages);

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
                FormEditSingleBookDetails editSingleBookDetails = new FormEditSingleBookDetails(info);
                editSingleBookDetails.ShowDialog();
                Search_btn.Select();
                this.Update();
            }
        }

        private void Refresh_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SearchFree.Checked = false;
            SearchBar.Text = "";
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                checkedListBox2.SetItemCheckState(i, CheckState.Unchecked);
            }
            Form2_Shown(Refresh, null);
        }

        private void Search_btn_Click_1(object sender, EventArgs e)
        {
            string search, categories = null, languages = null;
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
                if (checkedListBox2.GetItemCheckState(i) == CheckState.Checked)
                {
                    languages = languages + checkedListBox2.Items[i].ToString() + ";";
                }
            }

            if (SearchFree.Checked == true)
            {
                search = SearchBar.Text;
                books = connection.searchBookNames(search, true, categories, languages);
                authors = connection.searchAuthor(search, true, categories, languages);
                Lents = connection.searchLents(search, true, categories, languages);
                category = connection.searchCategory(search, true, categories, languages);
                language = connection.searchLanguage(search, true, categories, languages);
            }
            else
            {
                search = SearchBar.Text;
                books = connection.searchBookNames(search, false, categories, languages);
                authors = connection.searchAuthor(search, false, categories, languages);
                Lents = connection.searchLents(search, false, categories, languages);
                category = connection.searchCategory(search, false, categories, languages);
                language = connection.searchLanguage(search, false, categories, languages);
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
    }
}
