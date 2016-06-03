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
    public partial class UserProfile : Form
    {
        string userID, loan, bookName;
        double biggestPenalty;
        Connect2DB connect;
        List<string> details;
        DateTime lent;

        public UserProfile(string userID)
        {
            InitializeComponent();
            ErrorMessage.Visible = false;
            connect = new Connect2DB();
            lent = new DateTime();
            biggestPenalty = 0;

            details = new List<string>();
            this.userID = userID;
            if (userID == null)
            {
                ErrorMessage.Visible = true;
            }
            else
            {

                ProfilePictureBox.Image = Image.FromStream(new System.IO.MemoryStream(connect.getUserProfileImage(userID)));
                ProfilePictureBox.Refresh();
                ProfilePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                UserAllName.Text = connect.getUserAllName(userID);
                if (UserAllName.Text == null)
                {
                    ErrorMessage.Visible = true;
                }
                else
                {
                    UserAge.Text = "Age: " + connect.getUserAge(userID);
                }
            }
            listView1.Items.Clear();
            columnHeader1.TextAlign = HorizontalAlignment.Center;
            details = connect.checkUserLoansAndReservation(userID);

            for (int i = 0; i < details.Count; i++)
            {
                ListViewItem item = new ListViewItem(details[i]);
                bookName = details[i].ToString();
                i++;
                item.SubItems.Add(details[i]);
                i++;
                item.SubItems.Add(details[i]);
                i++;
                item.SubItems.Add(details[i]);
                i++;
                item.SubItems.Add(details[i]);
                loan = details[i].ToString();

                if (loan != "---")
                {
                    checkReturnDate(bookName, loan);
                    lent = DateTime.Parse(loan);
                    if (lent < DateTime.Today)
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

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserInterface form = new FormUserInterface(userID);
            form.Show();
            this.Hide();
        }

        private void editProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserProfile.ActiveForm.Refresh();
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

        private void UserProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            FormLogin forml = new FormLogin();
            forml.Show();
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
                string info = listView1.SelectedItems[index].Text;
                FormBookDetails bookDetail = new FormBookDetails(info, userID);
                bookDetail.ShowDialog();
                this.Update();
            }
        }

        private void ProfilePictureBox_Click(object sender, EventArgs e)
        {
            FormChangeProfilePhoto profilePhoto = new FormChangeProfilePhoto(userID);
            profilePhoto.ShowDialog();
        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {
            FormChangePassword changePassword = new FormChangePassword(userID);
            changePassword.ShowDialog();
        }

        private void EditProfile_Click(object sender, EventArgs e)
        {
            FormUserDetails form = new FormUserDetails(userID);
            form.ShowDialog();
        }

        private void checkReturnDate(string bookName, string loan)
        {
            string bookID = connect.findBookID(bookName);
            lent = connect.checkLoanDate(bookID, userID);

            if (lent < DateTime.Today)
            {
                string penalty;
                if (DateTime.Today <= lent.AddDays(7))
                {
                    if (0.7 >= biggestPenalty)
                    {
                        penalty = connect.getPenalty(1);
                        biggestPenalty = 0.7;
                        Penalty.Text = "You have has penalty " + penalty + " EURO";
                        Penalty.Visible = true;
                    }
                }
                else if (DateTime.Today > lent.AddDays(7) && DateTime.Today <= lent.AddMonths(1))
                {
                    if (2.00 >= biggestPenalty)
                    {

                        penalty = connect.getPenalty(2);
                        if (!(penalty.Contains(".") || penalty.Contains(",")))
                        {
                            penalty = penalty + ".00";
                        }
                        biggestPenalty = 2.00;
                        Penalty.Text = "You have penalty " + penalty + " EURO";
                        Penalty.Visible = true;
                    }
                }
                else if (DateTime.Today > lent.AddMonths(1) && DateTime.Today <= lent.AddMonths(2))
                {
                    if (5.00 >= biggestPenalty)
                    {
                        penalty = connect.getPenalty(3);
                        if (!(penalty.Contains(".") || penalty.Contains(",")))
                        {
                            penalty = penalty + ".00";
                        }
                        biggestPenalty = 5.00;
                        Penalty.Text = "You have penalty " + penalty + " EURO";
                        Penalty.Visible = true;
                    }
                }
                else if (lent.AddMonths(2) < DateTime.Today)
                {
                    if (5.00 >= biggestPenalty)
                    {
                        penalty = connect.getPenalty(4);
                        if (!(penalty.Contains(".") || penalty.Contains(",")))
                        {
                            penalty = penalty + ".00";
                        }
                        biggestPenalty = 5.00;
                        Penalty.Text = "You have penalty " + penalty + " EURO.\nYou are Blocked";
                        Penalty.Visible = true;
                    }
                }
            }
        }
    }
}
