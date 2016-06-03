﻿using System;
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
    public partial class FormAddCountries : Form
    {
        Connect2DB connect;
        string prefix, country, AdminID;

        public FormAddCountries(string AdminID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            connect = new Connect2DB();
            this.AdminID = AdminID;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            prefix = Prefix.Text;
            country = Country.Text;
            if (prefix == "" || prefix == null || country == "" || country == null)
            {
                MessageBox.Show("Enter all fields!");
            }
            else
            {
                if (connect.addCountryToDB(prefix, country))
                {
                    MessageBox.Show("Country was added to database.");
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