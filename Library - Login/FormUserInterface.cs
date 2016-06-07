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
    /// form of user interface after his login to system with functions which he is alloved to do, for example borrow books, see his profile,edit profile, see list of books
    /// </summary>
    public partial class FormUserInterface : Form
    {
        Connect2DB connection;
        Encoding enc;
        string UserID;
        byte[] data, user, pass;

        public FormUserInterface()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            connection = new Connect2DB();
            enc = new UTF8Encoding(true, true);
            SwitchToAdmin.Visible = false;
            SwitchToAdmin.Enabled = false;
        }

        public FormUserInterface(string UserID)
        {
            InitializeComponent();
            connection = new Connect2DB();
            enc = new UTF8Encoding(true, true);
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
        
        public FormUserInterface(string username,string password)
        {
            InitializeComponent();
            connection = new Connect2DB();
            enc = new UTF8Encoding(true, true);
            user = enc.GetBytes(username);
            pass = enc.GetBytes(password);
            UserID = connection.FindUser(enc.GetString(user), enc.GetString(pass));
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
                checkedListBox2.SetItemCheckState(i, CheckState.Unchecked);
            }
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

            books = connection.searchBooksToListView(null, false, categories, languages);

            for (int i = 0; i < books.Count; i++)
            {
                ListViewItem item = new ListViewItem(books[i]);
                i++;
                item.SubItems.Add(books[i]);
                i++;
                item.SubItems.Add(books[i]);
                i++;
                item.SubItems.Add(books[i]);
                i++;
                item.SubItems.Add(books[i]);

                listView1.Items.Add(item);
            }
        }

        /// <summary>
        /// refresh list of books
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            string search, categories = null, languages = null;
            List<string> books = new List<string>();

            listView1.Items.Clear();
            for (int i = 0;i < checkedListBox1.Items.Count; i++)
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
            data = enc.GetBytes(SearchBar.Text);
            if (SearchFree.Checked==true)
            {
                search = enc.GetString(data);
                books = connection.searchBooksToListView(search, true, categories, languages);
            }
            else
            {
                search = enc.GetString(data);
                books = connection.searchBooksToListView(search, false, categories, languages);
            }
            

            for (int i = 0; i < books.Count; i++)
            {
                ListViewItem item = new ListViewItem(books[i]);
                i++;
                item.SubItems.Add(books[i]);
                i++;
                item.SubItems.Add(books[i]);
                i++;
                item.SubItems.Add(books[i]);
                i++;
                item.SubItems.Add(books[i]);

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
                data = enc.GetBytes(listView1.SelectedItems[index].Text);
                string info = enc.GetString(data);
                FormBookDetails bookDetail = new FormBookDetails(info, UserID);
                bookDetail.ShowDialog();
                Search_btn.Select();
                this.Update();
            }
        }

        /// <summary>
        /// show only in admin mode, only admin can switch between user and admin interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SwitchToAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAdminInterface admin = new FormAdminInterface(UserID);
            admin.Show();
            
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserInterface.ActiveForm.Refresh();
        }

        private void userProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserProfile form = new UserProfile(UserID);
            form.Show();
            this.Hide();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout about = new FormAbout();
            about.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUserInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormLogin forml = new FormLogin();
            forml.Show();
        }
    }
}
    