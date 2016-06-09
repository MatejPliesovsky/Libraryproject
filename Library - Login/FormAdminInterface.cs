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
    /// admin interface for editing of library system, editing books, users, borrowings
    /// </summary>
    public partial class FormAdminInterface : Form
    {
        private Connect2DB connection;
        private Encoding enc;
        private byte[] data;
        private string AdminID;
        private int waitingReg;
        private List<string> borrowings, categories, languages;
        private DateTime returns;

        public FormAdminInterface(string adminID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            enc = new UTF8Encoding(true, true);
            connection = new Connect2DB();
            returns = new DateTime();
            AdminID = adminID;
            waitingReg = connection.waitingRegistration();
            if (waitingReg > 0)
            {
                registrationReguestToolStripMenuItem.Text = "Registration Request (" + waitingReg + ")";
            }
            else if (waitingReg == 0)
            {
                registrationReguestToolStripMenuItem.Text = "Registration Request";
            }
            else if (waitingReg == -1)
            {
                registrationReguestToolStripMenuItem.Text = "Registration Request";
                DatabaseInfo.Text = "Cannot connect to database!";
                DatabaseInfo.Visible = true;
            }

            checkedListBox1.Items.Clear();
            categories = connection.categoriesForFilter();
            for (int i = 0;i < categories.Count; i++)
            {
                checkedListBox1.Items.Add(categories[i]);
            }

            checkedListBox2.Items.Clear();
            languages = connection.languagesForFilter();
            for (int i = 0;i < languages.Count; i++)
            {
                checkedListBox2.Items.Add(languages[i]);
            }

            borrowings = connection.checkBorrowings();
            for (int i = 0; i < borrowings.Count; i++)
            {
                returns = DateTime.Parse(borrowings[i].ToString());
                i++;
                if (returns.AddMonths(2) < DateTime.Today)
                {
                    connection.blockUser(borrowings[i].ToString(), "blocked");
                }
            }
        }

        public FormAdminInterface(string username, string password)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            enc = new UTF8Encoding(true, true);
            connection = new Connect2DB();
            AdminID = connection.FindUser(username, password);
            waitingReg = connection.waitingRegistration();
            if (waitingReg > 0)
            {
                registrationReguestToolStripMenuItem.Text = "Registration Request (" + waitingReg + ")";
            }
            else if (waitingReg == 0)
            {
                registrationReguestToolStripMenuItem.Text = "Registration Request";
            }
            else if (waitingReg == -1)
            {
                registrationReguestToolStripMenuItem.Text = "Registration Request";
                DatabaseInfo.Text = "Cannot connect to database!";
                DatabaseInfo.Visible = true;
            }

            checkedListBox1.Items.Clear();
            categories = connection.categoriesForFilter();
            for (int i = 0; i < categories.Count; i++)
            {
                checkedListBox1.Items.Add(categories[i]);
            }

            checkedListBox2.Items.Clear();
            languages = connection.languagesForFilter();
            for (int i = 0; i < languages.Count; i++)
            {
                checkedListBox2.Items.Add(languages[i]);
            }

            borrowings = connection.checkBorrowings();
            for (int i = 0; i < borrowings.Count; i++)
            {
                returns = DateTime.Parse(borrowings[i].ToString());
                i++;
                if (returns.AddMonths(2) < DateTime.Today)
                {
                    connection.blockUser(borrowings[i].ToString(), "blocked");
                }
            }
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
            }
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
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
        /// listview for list of books
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                FormEditBookDetails editSingleBookDetails = new FormEditBookDetails(info);
                editSingleBookDetails.ShowDialog();
                Search_btn.Select();
                btnSearch_2.Select();
                this.Update();
            }
        }

        /// <summary>
        /// refreshing of list of books
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refresh_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SearchFree.Checked = false;
            SearchBar.Text = "";
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemCheckState(i, CheckState.Unchecked);
            }
            Form2_Shown(Refresh, null);
        }

        /// <summary>
        /// searching button for search books by some specifications
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click_1(object sender, EventArgs e)
        {
            string search, categories = null, languages = null;
            List<string> books = new List<string>();

            listView1.Items.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    categories = categories + checkedListBox1.Items[i].ToString() + ";";
                }
            }
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                if (checkedListBox2.GetItemCheckState(i) == CheckState.Checked)
                {
                    languages = languages + checkedListBox2.Items[i].ToString() + ";";
                }
            }

            if (SearchFree.Checked == true)
            {
                data = enc.GetBytes(SearchBar.Text);
                search = enc.GetString(data);
                books = connection.searchBooksToListView(search, true, categories, languages);
            }
            else
            {
                data = enc.GetBytes(SearchBar.Text);
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

        /// <summary>
        /// menu items for moves between admin forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdminInterface.ActiveForm.Refresh();
        }

        private void addBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddBooks form = new FormAddBooks();
            form.Show(); // or form.ShowDialog(this);
        }

        private void addCategoryBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddBookCategory form = new FormAddBookCategory();
            form.Show(); // or form.ShowDialog(this);
        }

        private void addBookLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddBookLanguage form = new FormAddBookLanguage();
            form.Show();
        }

        private void addBorrowingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddBorrowing borrowing = new FormAddBorrowing();
            borrowing.Show();
        }

        private void reservedBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCheckBorrowings reserved = new FormCheckBorrowings(AdminID, true);
            reserved.Show();
            this.Hide();
        }

        private void checkBorrowingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCheckBorrowings borrowings = new FormCheckBorrowings(AdminID, false);
            borrowings.Show();
            this.Hide();
        }

        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUpdateUser updateUser = new FormUpdateUser(AdminID);
            updateUser.Show();
            this.Hide();
        }

        private void registrationReguestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWaitingRegistrations registrations = new FormWaitingRegistrations(AdminID);
            registrations.Show();
            this.Hide();
        }

        private void switchToUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserInterface userForm = new FormUserInterface(AdminID);
            userForm.Show();
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

        /// <summary>
        /// button for creating of XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateXML_Click(object sender, EventArgs e)
        {
            if (connection.CreateXML())
            {
                XMLInfo.Text = "XML was created";
                XMLInfo.Visible = true;
            }
            else
            {
                XMLInfo.Text = "XML wasn't created";
                XMLInfo.Visible = true;
            }
        }

        private void btnSearch_2_Click(object sender, EventArgs e)
        {
            string search, categories = null, languages = null;
            List<string> books = new List<string>();

            listView1.Items.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    categories = categories + checkedListBox1.Items[i].ToString() + ";";
                }
            }
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                if (checkedListBox2.GetItemCheckState(i) == CheckState.Checked)
                {
                    languages = languages + checkedListBox2.Items[i].ToString() + ";";
                }
            }

            if (SearchFree.Checked == true)
            {
                data = enc.GetBytes(SearchBar.Text);
                search = enc.GetString(data);
                books = connection.searchBooksToListView(search, true, categories, languages);
            }
            else
            {
                data = enc.GetBytes(SearchBar.Text);
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

        private void FormAdminInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
        }

        private void FormAdminInterface_Load(object sender, EventArgs e)
        {

        }
    }
}
