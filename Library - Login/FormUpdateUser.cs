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
        string adminID;

        public FormUpdateUser(string adminID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.adminID = adminID;
            Search_btn_Click(null, null);
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
                FormUserDetails userDetail = new FormUserDetails(adminID, info);
                userDetail.ShowDialog();
                Search_btn.Select();
                this.Update();
            }
        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
