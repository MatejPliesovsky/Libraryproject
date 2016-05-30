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
        List<string> details = new List<string>();

        public FormCheckLoans(string UserID, bool justReserved)
        {
            InitializeComponent(); this.StartPosition = FormStartPosition.CenterScreen;
            DatabaseInfo.Visible = false;
            AdminID = UserID;
            Reserved.Checked = justReserved;
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
            FormCheckLoans reserved = new FormCheckLoans(AdminID, true);
            reserved.Show();
            this.Close();
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
            userForm.Show();
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout about = new FormAbout();
            about.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin.ActiveForm.Show();
            this.Close();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            DateTime loan = new DateTime();
            columnHeader1.TextAlign = HorizontalAlignment.Center;
            if (Reserved.Checked == false)
            {
                details = con.checkLentsAndReservations(SearchBar.Text, false);
            }
            else
            {
                details = con.checkLentsAndReservations(SearchBar.Text, true);
            }

            for (int i = 0; i < details.Count; i++)
            {
                ListViewItem item = new ListViewItem(details[i]);
                i++;
                item.SubItems.Add(details[i]);
                i++;
                item.SubItems.Add(details[i]);
                i++;
                item.SubItems.Add(details[i]);
                i++;
                item.SubItems.Add(details[i]);

                if (details[i] != "---")
                {
                    loan = DateTime.Parse(details[i]);
                    if (loan < DateTime.Today)
                    {
                        item.ForeColor = Color.Red;
                    }
                }
                else
                {
                    item.ForeColor = Color.Blue;
                }

                listView1.Items.Add(item);
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            int index = 0;
            index = (listView1.SelectedIndices.Count) - 1;
            if (index < 0)
            {
                index = index + listView1.SelectedIndices.Count;
            }
            else
            {
                string status = listView1.SelectedItems[listView1.SelectedIndices.Count - 1].SubItems[2].Text;
                ErrorMessage.Visible = false;
                string bookName = listView1.SelectedItems[index].Text;
                ReservationDetails showDetails = new ReservationDetails(AdminID, bookName);
                showDetails.ShowDialog();
                Refresh.Select();
                this.Update();
            }
        }
    }
}
