using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library___Login
{
    public partial class AdminMenuControl : UserControl
    {
        private string AdminID;
        int waitingReg;
        Connect2DB con = new Connect2DB();
        RememberUserForMenu data;

        public AdminMenuControl(string username, string password)
        {
            InitializeComponent();
            data = new RememberUserForMenu();
            this.AdminID = con.FindUser(username, password);
            data.setUserID(AdminID);
            waitingReg = con.waitingRegistration();
            setRegistrationRequestText(waitingReg);
        }

        public AdminMenuControl()
        {
            InitializeComponent();
            data = new RememberUserForMenu();
            waitingReg = con.waitingRegistration();
            setRegistrationRequestText(waitingReg);
        }

        private void setRegistrationRequestText(int waitingReg)
        {
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

        private void addBooksToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormAddBooks form = new FormAddBooks();
            form.Show(); // or form.ShowDialog(this);
        }

        private void addCategoryBookToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormAddBookCategory form = new FormAddBookCategory();
            form.Show(); // or form.ShowDialog(this);
        }

        private void addBookLanguageToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormAddBookLanguage form = new FormAddBookLanguage();
            form.Show();
        }

        private void updateUserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormUpdateUser updateUser = new FormUpdateUser(data.getUserID());
            updateUser.Show();
        }

        private void registrationReguestToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormAdminRegistrationRequest admin = new FormAdminRegistrationRequest(data.getUserID());
            admin.Show();
        }
        // potrebne dorobit na sposob, ktorym by sa dalo ziskat user id
        private void switchToUserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormUserInterface userForm = new FormUserInterface("1");
            userForm.Show();
        }

        private void logOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdminHome home = new FormAdminHome(data.getUserID());
            home.Show();
        }
    }
}
