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
    public partial class Admin : Form
    {
        int waitingReg;
        Connect2DB con = new Connect2DB();
        public Admin()
        {
            InitializeComponent();
            DatabaseInfo.Visible = false;
            waitingReg = con.waitingRegistration();
            if(waitingReg > 0)
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

        private void addBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //settings visibility of confirming or refusing requests
            RRlabel1.Visible = RRlabel2.Visible = RRlabel3.Visible = RRlabel4.Visible = RRlabel5.Visible = RRlabel6.Visible = RRlabel7.Visible = RRlabel8.Visible = RRlabel9.Visible = RRlabel10.Visible = false;
            groupBox1.Visible = groupBox2.Visible = groupBox3.Visible = groupBox4.Visible = groupBox5.Visible = groupBox6.Visible = false;
            RRConfirm1.Visible = RRConfirm2.Visible = RRConfirm3.Visible = RRConfirm4.Visible = RRConfirm5.Visible = RRConfirmAll.Visible = false;
            RRRefuse1.Visible = RRRefuse2.Visible = RRRefuse3.Visible = RRRefuse4.Visible = RRRefuse5.Visible = RRRefuseAll.Visible = false;
            RRUserID1.Visible = RRUserID2.Visible = RRUserID3.Visible = RRUserID4.Visible = RRUserID5.Visible = false;
            RRFirstName1.Visible = RRFirstName2.Visible = RRFirstName3.Visible = RRFirstName4.Visible = RRFirstName5.Visible = false;
            RRLastName1.Visible = RRLastName2.Visible = RRLastName3.Visible = RRLastName4.Visible = RRLastName5.Visible = false;
            RRAge1.Visible = RRAge2.Visible = RRAge3.Visible = RRAge4.Visible = RRAge5.Visible = false;
            RRemail1.Visible = RRemail2.Visible = RRemail3.Visible = RRemail4.Visible = RRemail5.Visible = false;
            RRPermission1.Visible = RRPermission2.Visible = RRPermission3.Visible = RRPermission4.Visible = RRPermission5.Visible = false;

           FormAddBooks form = new FormAddBooks();
            form.Show(); // or form.ShowDialog(this);

        }

        private void registrationReguestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseInfo.Visible = false;
            registrationReguestToolStripMenuItem.Checked = true;
            addBooksToolStripMenuItem.Checked = false;

            //finding information from database to textboxes
            waitingReg = con.waitingRegistration();
            if (waitingReg > 0)
            {
                string users = con.waitingUsers();
                string[] items = users.Split(';');

                //settings visibility of confirming or refusing requests according to waiting requests
                switch (waitingReg)
                {
                    case 0:
                        RRConfirm.Visible = false;
                        RRConfirm.Enabled = false;
                        RRlabel1.Visible = RRlabel2.Visible = RRlabel3.Visible = RRlabel4.Visible = RRlabel5.Visible = RRlabel6.Visible = RRlabel7.Visible = RRlabel8.Visible = RRlabel9.Visible = RRlabel10.Visible = false;
                        groupBox1.Visible = groupBox2.Visible = groupBox3.Visible = groupBox4.Visible = groupBox5.Visible = groupBox6.Visible = false;
                        RRConfirm1.Visible = RRConfirm2.Visible = RRConfirm3.Visible = RRConfirm4.Visible = RRConfirm5.Visible = RRConfirmAll.Visible = false;
                        RRRefuse1.Visible = RRRefuse2.Visible = RRRefuse3.Visible = RRRefuse4.Visible = RRRefuse5.Visible = RRRefuseAll.Visible = false;
                        RRUserID1.Visible = RRUserID2.Visible = RRUserID3.Visible = RRUserID4.Visible = RRUserID5.Visible = false;
                        RRFirstName1.Visible = RRFirstName2.Visible = RRFirstName3.Visible = RRFirstName4.Visible = RRFirstName5.Visible = false;
                        RRLastName1.Visible = RRLastName2.Visible = RRLastName3.Visible = RRLastName4.Visible = RRLastName5.Visible = false;
                        RRAge1.Visible = RRAge2.Visible = RRAge3.Visible = RRAge4.Visible = RRAge5.Visible = false;
                        RRemail1.Visible = RRemail2.Visible = RRemail3.Visible = RRemail4.Visible = RRemail5.Visible = false;
                        RRPermission1.Visible = RRPermission2.Visible = RRPermission3.Visible = RRPermission4.Visible = RRPermission5.Visible = false;
                        break;
                    case 1:
                        RRConfirm.Visible = true;
                        RRConfirm.Enabled = true;
                        RRlabel1.Visible = RRlabel2.Visible = RRlabel3.Visible = RRlabel4.Visible = RRlabel5.Visible =
                            RRlabel6.Visible = RRlabel7.Visible = RRlabel8.Visible = true;
                        RRlabel9.Visible = false;
                        RRlabel1.Visible = RRlabel2.Visible = RRlabel3.Visible = RRlabel4.Visible = RRlabel5.Visible = RRlabel6.Visible = RRlabel7.Visible = RRlabel8.Visible = RRlabel9.Visible = RRlabel10.Visible = true;
                        groupBox1.Visible = RRConfirm1.Visible = RRRefuse1.Visible
                         = RRUserID1.Visible = RRFirstName1.Visible = RRLastName1.Visible = RRAge1.Visible
                         = RRemail1.Visible = RRPermission1.Visible = true;

                        // inserting info from database to textboxes
                        RRUserID1.Text = items[0];
                        RRFirstName1.Text = items[1];
                        RRLastName1.Text = items[2];
                        RRemail1.Text = items[3];
                        RRAge1.Text = items[4];
                        break;
                    case 2:
                        RRConfirm.Visible = true;
                        RRConfirm.Enabled = true;
                        RRlabel1.Visible = RRlabel2.Visible = RRlabel3.Visible = RRlabel4.Visible = RRlabel5.Visible =
                            RRlabel6.Visible = RRlabel7.Visible = RRlabel8.Visible = RRlabel9.Visible =
                            RRlabel10.Visible = true;
                        groupBox1.Visible = RRConfirm1.Visible = RRRefuse1.Visible
                         = RRUserID1.Visible = RRFirstName1.Visible = RRLastName1.Visible = RRAge1.Visible
                         = RRemail1.Visible = RRPermission1.Visible = true;
                        groupBox2.Visible = RRConfirm2.Visible = RRRefuse2.Visible
                         = RRUserID2.Visible = RRFirstName2.Visible = RRLastName2.Visible = RRAge2.Visible
                         = RRemail2.Visible = RRPermission2.Visible = true;

                        // inserting info from database to textboxes
                        RRUserID1.Text = items[0];
                        RRFirstName1.Text = items[1];
                        RRLastName1.Text = items[2];
                        RRemail1.Text = items[3];
                        RRAge1.Text = items[4];

                        RRUserID2.Text = items[5];
                        RRFirstName2.Text = items[6];
                        RRLastName2.Text = items[7];
                        RRemail2.Text = items[8];
                        RRAge2.Text = items[9];
                        break;
                    case 3:
                        RRConfirm.Visible = true;
                        RRConfirm.Enabled = true;
                        RRlabel1.Visible = RRlabel2.Visible = RRlabel3.Visible = RRlabel4.Visible = RRlabel5.Visible =
                            RRlabel6.Visible = RRlabel7.Visible = RRlabel8.Visible = RRlabel9.Visible =
                            RRlabel10.Visible = true;
                        groupBox1.Visible = RRConfirm1.Visible = RRRefuse1.Visible
                         = RRUserID1.Visible = RRFirstName1.Visible = RRLastName1.Visible = RRAge1.Visible
                         = RRemail1.Visible = RRPermission1.Visible = true;
                        groupBox2.Visible = RRConfirm2.Visible = RRRefuse2.Visible
                         = RRUserID2.Visible = RRFirstName2.Visible = RRLastName2.Visible = RRAge2.Visible
                         = RRemail2.Visible = RRPermission2.Visible = true;
                        groupBox3.Visible = RRConfirm3.Visible = RRRefuse3.Visible
                         = RRUserID3.Visible = RRFirstName3.Visible = RRLastName3.Visible = RRAge3.Visible
                         = RRemail3.Visible = RRPermission3.Visible = true;

                        // inserting info from database to textboxes
                        RRUserID1.Text = items[0];
                        RRFirstName1.Text = items[1];
                        RRLastName1.Text = items[2];
                        RRemail1.Text = items[3];
                        RRAge1.Text = items[4];

                        RRUserID2.Text = items[5];
                        RRFirstName2.Text = items[6];
                        RRLastName2.Text = items[7];
                        RRemail2.Text = items[8];
                        RRAge2.Text = items[9];

                        RRUserID3.Text = items[10];
                        RRFirstName3.Text = items[11];
                        RRLastName3.Text = items[12];
                        RRemail3.Text = items[13];
                        RRAge3.Text = items[14];
                        break;
                    case 4:
                        RRConfirm.Visible = true;
                        RRConfirm.Enabled = true;
                        RRlabel1.Visible = RRlabel2.Visible = RRlabel3.Visible = RRlabel4.Visible = RRlabel5.Visible =
                            RRlabel6.Visible = RRlabel7.Visible = RRlabel8.Visible = RRlabel9.Visible =
                            RRlabel10.Visible = true;
                        groupBox1.Visible = RRConfirm1.Visible = RRRefuse1.Visible
                         = RRUserID1.Visible = RRFirstName1.Visible = RRLastName1.Visible = RRAge1.Visible
                         = RRemail1.Visible = RRPermission1.Visible = true;
                        groupBox2.Visible = RRConfirm2.Visible = RRRefuse2.Visible
                         = RRUserID2.Visible = RRFirstName2.Visible = RRLastName2.Visible = RRAge2.Visible
                         = RRemail2.Visible = RRPermission2.Visible = true;
                        groupBox3.Visible = RRConfirm3.Visible = RRRefuse3.Visible
                         = RRUserID3.Visible = RRFirstName3.Visible = RRLastName3.Visible = RRAge3.Visible
                         = RRemail3.Visible = RRPermission3.Visible = true;
                        groupBox4.Visible = RRConfirm4.Visible = RRRefuse4.Visible
                         = RRUserID4.Visible = RRFirstName4.Visible = RRLastName4.Visible = RRAge4.Visible
                         = RRemail4.Visible = RRPermission4.Visible = true;

                        // inserting info from database to textboxes
                        RRUserID1.Text = items[0];
                        RRFirstName1.Text = items[1];
                        RRLastName1.Text = items[2];
                        RRemail1.Text = items[3];
                        RRAge1.Text = items[4];

                        RRUserID2.Text = items[5];
                        RRFirstName2.Text = items[6];
                        RRLastName2.Text = items[7];
                        RRemail2.Text = items[8];
                        RRAge2.Text = items[9];

                        RRUserID3.Text = items[10];
                        RRFirstName3.Text = items[11];
                        RRLastName3.Text = items[12];
                        RRemail3.Text = items[13];
                        RRAge3.Text = items[14];

                        RRUserID4.Text = items[15];
                        RRFirstName4.Text = items[16];
                        RRLastName4.Text = items[17];
                        RRemail4.Text = items[18];
                        RRAge4.Text = items[19];
                        break;
                    default:
                        RRConfirm.Visible = true;
                        RRConfirm.Enabled = true;
                        RRlabel1.Visible = RRlabel2.Visible = RRlabel3.Visible = RRlabel4.Visible = RRlabel5.Visible =
                            RRlabel6.Visible = RRlabel7.Visible = RRlabel8.Visible = RRlabel9.Visible =
                            RRlabel10.Visible = true;
                        groupBox1.Visible = RRConfirm1.Visible = RRRefuse1.Visible
                         = RRUserID1.Visible = RRFirstName1.Visible = RRLastName1.Visible = RRAge1.Visible
                         = RRemail1.Visible = RRPermission1.Visible = true;
                        groupBox2.Visible = RRConfirm2.Visible = RRRefuse2.Visible
                         = RRUserID2.Visible = RRFirstName2.Visible = RRLastName2.Visible = RRAge2.Visible
                         = RRemail2.Visible = RRPermission2.Visible = true;
                        groupBox3.Visible = RRConfirm3.Visible = RRRefuse3.Visible
                         = RRUserID3.Visible = RRFirstName3.Visible = RRLastName3.Visible = RRAge3.Visible
                         = RRemail3.Visible = RRPermission3.Visible = true;
                        groupBox4.Visible = RRConfirm4.Visible = RRRefuse4.Visible
                         = RRUserID4.Visible = RRFirstName4.Visible = RRLastName4.Visible = RRAge4.Visible
                         = RRemail4.Visible = RRPermission4.Visible = true;
                        groupBox5.Visible = RRConfirm5.Visible = RRRefuse5.Visible
                         = RRUserID5.Visible = RRFirstName5.Visible = RRLastName5.Visible = RRAge5.Visible
                         = RRemail5.Visible = RRPermission5.Visible = true;

                        // inserting info from database to textboxes
                        RRUserID1.Text = items[0];
                        RRFirstName1.Text = items[1];
                        RRLastName1.Text = items[2];
                        RRemail1.Text = items[3];
                        RRAge1.Text = items[4];

                        RRUserID2.Text = items[5];
                        RRFirstName2.Text = items[6];
                        RRLastName2.Text = items[7];
                        RRemail2.Text = items[8];
                        RRAge2.Text = items[9];

                        RRUserID3.Text = items[10];
                        RRFirstName3.Text = items[11];
                        RRLastName3.Text = items[12];
                        RRemail3.Text = items[13];
                        RRAge3.Text = items[14];

                        RRUserID4.Text = items[15];
                        RRFirstName4.Text = items[16];
                        RRLastName4.Text = items[17];
                        RRemail4.Text = items[18];
                        RRAge4.Text = items[19];

                        RRUserID5.Text = items[20];
                        RRFirstName5.Text = items[21];
                        RRLastName5.Text = items[22];
                        RRemail5.Text = items[23];
                        RRAge5.Text = items[24];
                        break;
                }
            }

            //settings disability of changed textboxs
            RRUserID1.Enabled = RRUserID2.Enabled = RRUserID3.Enabled = RRUserID4.Enabled = RRUserID5.Enabled = false;
            RRFirstName1.Enabled = RRFirstName2.Enabled = RRFirstName3.Enabled = RRFirstName4.Enabled = RRFirstName5.Enabled = false;
            RRLastName1.Enabled = RRLastName2.Enabled = RRLastName3.Enabled = RRLastName4.Enabled = RRLastName5.Enabled = false;
            RRAge1.Enabled = RRAge2.Enabled = RRAge3.Enabled = RRAge4.Enabled = RRAge5.Enabled = false;
            RRemail1.Enabled = RRemail2.Enabled = RRemail3.Enabled = RRemail4.Enabled = RRemail5.Enabled = false;
            
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RRConfirm_Click(object sender, EventArgs e)
        {
            string userID;
            string perm;
            char permis;
            if (RRPermission1.Text != "" && RRConfirm1.Checked == true)
            {
                userID = RRUserID1.Text;
                perm = RRPermission1.Text;
                permis = getPermission(perm);
                if(con.writeUserAsActive(userID, permis))
                {
                    DatabaseInfo.Text = "User was added to the database as " + perm;
                    DatabaseInfo.Visible = true;
                }
            }
            else if (RRRefuse1.Checked == true)
            {
                con.deleteUserFromDatabase(RRUserID1.Text);
                DatabaseInfo.Text = "User was removed from database";
                DatabaseInfo.Visible = true;
            }
            if (RRUserID2.Visible == true && RRPermission2.Text != "" && RRConfirm2.Checked == true)
            {
                userID = RRUserID2.Text;
                perm = RRPermission2.Text;
                permis = getPermission(perm);
                con.writeUserAsActive(userID, permis);
            }
            else if (RRUserID2.Visible == true && RRRefuse2.Checked == true)
            {
                con.deleteUserFromDatabase(RRUserID2.Text);
            }
            if (RRUserID3.Visible == true && RRPermission3.Text != "" && RRConfirm3.Checked == true)
            {
                userID = RRUserID3.Text;
                perm = RRPermission3.Text;
                permis = getPermission(perm);
                con.writeUserAsActive(userID, permis);
            }
            else if (RRUserID3.Visible == true && RRRefuse3.Checked == true)
            {
                con.deleteUserFromDatabase(RRUserID3.Text);
            }
            if (RRUserID4.Visible == true && RRPermission4.Text != "" && RRConfirm4.Checked == true)
            {
                userID = RRUserID4.Text;
                perm = RRPermission4.Text;
                permis = getPermission(perm);
                con.writeUserAsActive(userID, permis);
            }
            else if (RRUserID4.Visible == true && RRRefuse4.Checked == true)
            {
                con.deleteUserFromDatabase(RRUserID4.Text);
            }
            if (RRUserID5.Visible == true && RRPermission5.Text != "" && RRConfirm5.Checked == true)
            {
                userID = RRUserID5.Text;
                perm = RRPermission5.Text;
                permis = getPermission(perm);
                con.writeUserAsActive(userID, permis);
            }
            else if (RRUserID5.Visible == true && RRRefuse5.Checked == true)
            {
                con.deleteUserFromDatabase(RRUserID5.Text);
            }

            registrationReguestToolStripMenuItem_Click(RRConfirm, null);
        }

        private char getPermission(string permission)
        {
            char permis;
            if (permission.Equals("Admin"))
            {
                permis = 'a';
            }
            else
            {
                permis = 'u';
            }
            return permis;
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
    }
}
