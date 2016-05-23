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
    public partial class FormUpdateUser : Form
    {
        Connect2DB con = new Connect2DB();
        string AdminID;
        int waitingReg;

        public FormUpdateUser(string adminID)
        {
            InitializeComponent();
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

            List<string> userID = new List<string>();
            List<string> userFirstName = new List<string>();
            List<string> userLastName = new List<string>();
            List<string> userAges = new List<string>();
            List<string> useremails = new List<string>();
            List<string> userRole = new List<string>();
            List<string> userStatus = new List<string>();

            userID = con.getUsersID(SearchBar.Text);
            userFirstName = con.getUsersFirstName(SearchBar.Text);
            userLastName = con.getUsersLastName(SearchBar.Text);
            userAges = con.getUsersAge(SearchBar.Text);
            useremails = con.getUsersEmails(SearchBar.Text);
            userRole = con.getUsersRoles(SearchBar.Text);
            userStatus = con.getUsersStatus(SearchBar.Text);

            for (int i = 0; i < userFirstName.Count; i++)
            {
                ListViewItem item = new ListViewItem(userFirstName[i]);
                item.SubItems.Add(userLastName[i]);
                item.SubItems.Add(userAges[i]);
                item.SubItems.Add(userRole[i]);
                item.SubItems.Add(userStatus[i]);

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
                string info = listView1.SelectedItems[index].Text;
                FormUserDetails userDetail = new FormUserDetails(AdminID, info);
                userDetail.ShowDialog();
                Search_btn.Select();
                this.Update();
            }
        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {

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
            FormAddLoan loan = new FormAddLoan();
            loan.Show();
        }

        private void reservedBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkLoansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCheckLoans loans = new FormCheckLoans(AdminID);
            loans.Show();
            this.Close();
        }

        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUpdateUser.ActiveForm.Refresh();
        }

        private void registrationReguestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWaitingRegistrations registrations = new FormWaitingRegistrations(AdminID);
            registrations.Show();
            this.Close();
        }

        private void switchToUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserInterface userForm = new FormUserInterface(AdminID);
            userForm.ShowDialog();
            this.Close();
            userForm.FormClosed += new FormClosedEventHandler(UserForm_FormClosed);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
    }
}
