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
    public partial class FormCheckLoans : Form
    {
        int waitingReg;
        string AdminID;
        Connect2DB con = new Connect2DB();
        List<string> books = new List<string>();
        List<string> readers = new List<string>();
        List<string> status = new List<string>();
        List<string> lendings = new List<string>();
        List<string> returns = new List<string>();

        public FormCheckLoans(string UserID)
        {
            InitializeComponent(); this.StartPosition = FormStartPosition.CenterScreen;
            DatabaseInfo.Visible = false;
            AdminID = UserID;
            waitingReg = con.waitingRegistration();
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
            Refresh_Click(null, null);
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdminInterface home = new FormAdminInterface(AdminID);
            home.Show();
            this.Close();
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

        private void addLoansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddLoan loans = new FormAddLoan();
            loans.ShowDialog();
        }

        private void reservedBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkLoansToolStripMenuItem_Click(reservedBooksToolStripMenuItem, null);
        }

        private void checkLoansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCheckLoans.ActiveForm.Refresh();
        }

        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUpdateUser updateUser = new FormUpdateUser(AdminID);
            updateUser.Show();
            this.Close();
        }

        public void registrationReguestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWaitingRegistrations admin = new FormWaitingRegistrations(AdminID);
            admin.Show();
            this.Close();
        }

        private void switchToUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserInterface userForm = new FormUserInterface(AdminID);
            userForm.ShowDialog();
            this.Close();
            userForm.FormClosed += new FormClosedEventHandler(UserForm_FormClosed);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin.ActiveForm.Show();
            this.Close();
        }

        private void UserForm_FormClosed(object sender, EventArgs e)
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

        private void Refresh_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            columnHeader1.TextAlign = HorizontalAlignment.Center;
            if (Reserved.Checked == false)
            {
                books = con.checkLentBookNames(SearchBar.Text, false);
                readers = con.checkOwnersOfLentBooks(SearchBar.Text, false);
                status = con.checkStatusOfBook(SearchBar.Text, false);
                lendings = con.checkDatesLendings(SearchBar.Text, false);
                returns = con.checkReturnsDates(SearchBar.Text, false);
            }
            else
            {
                books = con.checkLentBookNames(SearchBar.Text, true);
                readers = con.checkOwnersOfLentBooks(SearchBar.Text, true);
                status = con.checkStatusOfBook(SearchBar.Text, true);
                lendings = con.checkDatesLendings(SearchBar.Text, true);
                returns = con.checkReturnsDates(SearchBar.Text, true);
            }

            for (int i = 0; i < books.Count; i++)
            {
                ListViewItem item = new ListViewItem(books[i]);
                item.SubItems.Add(readers[i]);
                item.SubItems.Add(status[i]);
                item.SubItems.Add(lendings[i]);
                item.SubItems.Add(returns[i]);

                listView1.Items.Add(item);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
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
                FormBookDetails bookDetails = new FormBookDetails(info);
                bookDetails.ShowDialog();
                Refresh.Select();
                this.Update();
            }
        }
    }
}
