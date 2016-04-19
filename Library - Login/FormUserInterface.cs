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
    public partial class FormUserInterface : Form
    {
        Connect2DB connection;
        string UserID;        

        public FormUserInterface()
        {
            InitializeComponent();
            connection = new Connect2DB();
            SwitchToAdmin.Visible = false;
            SwitchToAdmin.Enabled = false;
        }

        public FormUserInterface(string UserID)
        {
            InitializeComponent();
            connection = new Connect2DB();
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

        private void button1_Click(object sender, EventArgs e)
        {
                      
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            if (connection.openConnection())
            {
                String sqlQuery = "SELECT * FROM Books";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, connection.connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["BookName"].ToString());
                    item.SubItems.Add(reader["Author"].ToString());
                    item.SubItems.Add(((bool)reader["Lent"]) ? "lent" : "free");


                    listView1.Items.Add(item);
                }

                connection.closeConnection();

            }
        }

        private void SwitchToAdmin_Click(object sender, EventArgs e)
        {
            FormAdminInterface admin = new FormAdminInterface(UserID);
            admin.Show();
            this.Close();
        }
    }
    }