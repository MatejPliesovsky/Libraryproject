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
    /// countries form
    /// </summary>
    public partial class FormAddCountries : Form
    {
        private Connect2DB connect;
        private Encoding enc;
        private string prefix, country, AdminID;
        private byte[] data;

        public FormAddCountries(string AdminID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            connect = new Connect2DB();
            enc = new UTF8Encoding(true, true);
            this.AdminID = AdminID;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// confirm of adding new country
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirm_Click(object sender, EventArgs e)
        {
            prefix = Prefix.Text;
            data = enc.GetBytes(Country.Text);
            country = enc.GetString(data);
            if (prefix == "" || prefix == null || country == "" || country == null)
            {
                MessageBox.Show("Enter all fields!");
            }
            else
            {
                if (connect.addCountryToDB(prefix, country))
                {
                    MessageBox.Show("Country was add to database.");
                    prefix = null;
                    country = null;
                }
                else
                {
                    MessageBox.Show("Error! Cannot connect to database!");
                }

            }
        }
    }
}
