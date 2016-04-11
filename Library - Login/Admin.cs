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
        public Admin()
        {
            InitializeComponent();
            Connect2DB con = new Connect2DB();
            int waitingReg = con.waitingRegistration();
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
            registrationReguestToolStripMenuItem.Checked = true;
            addBooksToolStripMenuItem.Checked = false;

            //settings visibility of confirming or refusing requests
            RRlabel1.Visible = RRlabel2.Visible = RRlabel3.Visible = RRlabel4.Visible = RRlabel5.Visible = RRlabel6.Visible = RRlabel7.Visible = RRlabel8.Visible = RRlabel9.Visible = RRlabel10.Visible = true;
            groupBox1.Visible = groupBox2.Visible = groupBox3.Visible = groupBox4.Visible = groupBox5.Visible = groupBox6.Visible = true;
            RRConfirm1.Visible = RRConfirm2.Visible = RRConfirm3.Visible = RRConfirm4.Visible = RRConfirm5.Visible = RRConfirmAll.Visible = true;
            RRRefuse1.Visible = RRRefuse2.Visible = RRRefuse3.Visible = RRRefuse4.Visible = RRRefuse5.Visible = RRRefuseAll.Visible = true;
            RRUserID1.Visible = RRUserID2.Visible = RRUserID3.Visible = RRUserID4.Visible = RRUserID5.Visible = true;
            RRFirstName1.Visible = RRFirstName2.Visible = RRFirstName3.Visible = RRFirstName4.Visible = RRFirstName5.Visible = true;
            RRLastName1.Visible = RRLastName2.Visible = RRLastName3.Visible = RRLastName4.Visible = RRLastName5.Visible = true;
            RRAge1.Visible = RRAge2.Visible = RRAge3.Visible = RRAge4.Visible = RRAge5.Visible = true;
            RRemail1.Visible = RRemail2.Visible = RRemail3.Visible = RRemail4.Visible = RRemail5.Visible = true;
            RRPermission1.Visible = RRPermission2.Visible = RRPermission3.Visible = RRPermission4.Visible = RRPermission5.Visible = true;

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

        private void Confirm_Click(object sender, EventArgs e)
        {

        }
    }
}
