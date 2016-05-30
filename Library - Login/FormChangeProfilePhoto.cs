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
    public partial class FormChangeProfilePhoto : Form
    {
        string userID, image;
        Connect2DB connect;

        public FormChangeProfilePhoto(string userID)
        {
            InitializeComponent();
            this.userID = userID;
            connect = new Connect2DB();
            image = this.txtImagePath.Text;

            ProfilePictureBox.Image = Image.FromStream(new System.IO.MemoryStream(connect.getUserProfileImage(userID)));
            ProfilePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ProfilePictureBox.Refresh();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            image = txtImagePath.Text;
            if (connect.uploadUserImage(image, userID))
            {
                DatabaseInfo.Text = "Profile image was changed.";
                DatabaseInfo.Visible = true;
            }
            else
            {
                DatabaseInfo.Text = "Cannot upload profile image.\nTry again later.";
                DatabaseInfo.Visible = true;
            }
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog imgSrc = new OpenFileDialog();
            imgSrc.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";

            if (imgSrc.ShowDialog() == DialogResult.OK)
            {
                string src = imgSrc.FileName.ToString();
                txtImagePath.Text = src;
                ProfilePictureBox.ImageLocation = src;
            }
        }
    }
}
