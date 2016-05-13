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
    public partial class MenuAdminUserControl1 : UserControl
    {
        string AdminID;
        Connect2DB connection = new Connect2DB();

        public MenuAdminUserControl1(string username, string password)
        {
            InitializeComponent();
            AdminID = connection.FindUser(username, password);
        }

        public MenuAdminUserControl1(string userID)
        {
            InitializeComponent();
            AdminID = userID;
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

        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUpdateUser updateUser = new FormUpdateUser(AdminID);
            updateUser.Show();
        }

        private void registrationReguestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdminInterface admin = new FormAdminInterface(AdminID);
            admin.Show();
        }

        private void switchToUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserInterface userForm = new FormUserInterface(AdminID);
            userForm.Show();
            this.Hide();

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
