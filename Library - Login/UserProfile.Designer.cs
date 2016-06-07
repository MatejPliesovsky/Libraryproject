namespace Library___Login
{
    partial class UserProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserProfile));
            this.ProfilePictureBox = new System.Windows.Forms.PictureBox();
            this.UserAllName = new System.Windows.Forms.Label();
            this.UserAge = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditProfile = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ErrorMessage = new System.Windows.Forms.Label();
            this.Penalty = new System.Windows.Forms.Label();
            this.ChangePassword = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProfilePictureBox
            // 
            this.ProfilePictureBox.Image = global::Library___Login.Properties.Resources.default_user2;
            this.ProfilePictureBox.Location = new System.Drawing.Point(12, 27);
            this.ProfilePictureBox.Name = "ProfilePictureBox";
            this.ProfilePictureBox.Size = new System.Drawing.Size(118, 129);
            this.ProfilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProfilePictureBox.TabIndex = 0;
            this.ProfilePictureBox.TabStop = false;
            this.ProfilePictureBox.Click += new System.EventHandler(this.ProfilePictureBox_Click);
            // 
            // UserAllName
            // 
            this.UserAllName.AutoSize = true;
            this.UserAllName.Location = new System.Drawing.Point(12, 163);
            this.UserAllName.Name = "UserAllName";
            this.UserAllName.Size = new System.Drawing.Size(35, 13);
            this.UserAllName.TabIndex = 1;
            this.UserAllName.Text = "label1";
            // 
            // UserAge
            // 
            this.UserAge.AutoSize = true;
            this.UserAge.Location = new System.Drawing.Point(12, 180);
            this.UserAge.Name = "UserAge";
            this.UserAge.Size = new System.Drawing.Size(35, 13);
            this.UserAge.TabIndex = 2;
            this.UserAge.Text = "label2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.editProfileToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // editProfileToolStripMenuItem
            // 
            this.editProfileToolStripMenuItem.Name = "editProfileToolStripMenuItem";
            this.editProfileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.editProfileToolStripMenuItem.Text = "Profile";
            this.editProfileToolStripMenuItem.Click += new System.EventHandler(this.editProfileToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // EditProfile
            // 
            this.EditProfile.Location = new System.Drawing.Point(15, 214);
            this.EditProfile.Name = "EditProfile";
            this.EditProfile.Size = new System.Drawing.Size(115, 35);
            this.EditProfile.TabIndex = 5;
            this.EditProfile.Text = "Edit profile";
            this.EditProfile.UseVisualStyleBackColor = true;
            this.EditProfile.Click += new System.EventHandler(this.EditProfile_Click);
            // 
            // listView1
            // 
            this.listView1.BackgroundImageTiled = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(148, 27);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(624, 200);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 59;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Book name";
            this.columnHeader1.Width = 124;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Author";
            this.columnHeader2.Width = 118;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 105;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Date of lending";
            this.columnHeader4.Width = 136;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Date of return";
            this.columnHeader5.Width = 135;
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.AutoSize = true;
            this.ErrorMessage.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.ErrorMessage.Location = new System.Drawing.Point(205, 250);
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.Size = new System.Drawing.Size(378, 32);
            this.ErrorMessage.TabIndex = 60;
            this.ErrorMessage.Text = "Cannot conect to database!";
            this.ErrorMessage.Visible = false;
            // 
            // Penalty
            // 
            this.Penalty.AutoSize = true;
            this.Penalty.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Penalty.ForeColor = System.Drawing.Color.Red;
            this.Penalty.Location = new System.Drawing.Point(15, 308);
            this.Penalty.Name = "Penalty";
            this.Penalty.Size = new System.Drawing.Size(49, 19);
            this.Penalty.TabIndex = 61;
            this.Penalty.Text = "label1";
            this.Penalty.Visible = false;
            // 
            // ChangePassword
            // 
            this.ChangePassword.Location = new System.Drawing.Point(15, 254);
            this.ChangePassword.Name = "ChangePassword";
            this.ChangePassword.Size = new System.Drawing.Size(115, 35);
            this.ChangePassword.TabIndex = 62;
            this.ChangePassword.Text = "Change password";
            this.ChangePassword.UseVisualStyleBackColor = true;
            this.ChangePassword.Click += new System.EventHandler(this.ChangePassword_Click);
            // 
            // UserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ChangePassword);
            this.Controls.Add(this.Penalty);
            this.Controls.Add(this.ErrorMessage);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.EditProfile);
            this.Controls.Add(this.UserAge);
            this.Controls.Add(this.UserAllName);
            this.Controls.Add(this.ProfilePictureBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserProfile_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ProfilePictureBox;
        private System.Windows.Forms.Label UserAllName;
        private System.Windows.Forms.Label UserAge;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.Button EditProfile;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label ErrorMessage;
        private System.Windows.Forms.Label Penalty;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button ChangePassword;
    }
}