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
    /// form for update user by admin
    /// </summary>
    public partial class FormUpdateUser : Form
    {
        Connect2DB con; 
        Encoding enc;
        byte[] data;
        string AdminID;
        int waitingReg;

        public FormUpdateUser(string adminID)
        {
            InitializeComponent();
            enc = new UTF8Encoding(true, true);
            con = new Connect2DB();
            DatabaseInfo.Visible = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AdminID = adminID;
            Search_btn_Click(null, null);
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
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            SearchBar.Text = "";
            Search_btn_Click(Refresh, null);
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            List<string> usersData = new List<string>();

            data = enc.GetBytes(SearchBar.Text);
            usersData = con.getAllUsersData(enc.GetString(data));

            for (int i = 0; i < usersData.Count; i++)
            {
                ListViewItem item = new ListViewItem(usersData[i]);
                i++;
                item.SubItems.Add(usersData[i]);
                i++;
                item.SubItems.Add(usersData[i]);
                i++;
                item.SubItems.Add(usersData[i]);
                i++;
                item.SubItems.Add(usersData[i]);

                this.listView1.Items.Add(item);
            }
            this.listView1.View = View.Details;
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
                data = enc.GetBytes(listView1.SelectedItems[index].Text);
                string info = enc.GetString(data);
                FormUserDetails userDetail = new FormUserDetails(AdminID, info);
                userDetail.ShowDialog();
                Search_btn.Select();
                this.Update();
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdminInterface home = new FormAdminInterface(AdminID);
            home.Show();
            this.Hide();
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
            borrowing.ShowDialog();
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
            FormUpdateUser.ActiveForm.Refresh();
        }

        public void registrationReguestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWaitingRegistrations admin = new FormWaitingRegistrations(AdminID);
            admin.Show();
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

        private void Countries_Click(object sender, EventArgs e)
        {
            FormAddCountries country = new FormAddCountries(AdminID);
            country.ShowDialog();
        }

        private void FormUpdateUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
        }

        private void SearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search_btn_Click(SearchBar, null);
            }
        }
    }
}
