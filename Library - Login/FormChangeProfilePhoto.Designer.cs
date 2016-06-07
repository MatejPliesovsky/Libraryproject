namespace Library___Login
{
    partial class FormChangeProfilePhoto
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChangeProfilePhoto));
            this.ProfilePictureBox = new System.Windows.Forms.PictureBox();
            this.Upload = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.DatabaseInfo = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ProfilePictureBox
            // 
            this.ProfilePictureBox.Location = new System.Drawing.Point(79, 12);
            this.ProfilePictureBox.Name = "ProfilePictureBox";
            this.ProfilePictureBox.Size = new System.Drawing.Size(118, 129);
            this.ProfilePictureBox.TabIndex = 1;
            this.ProfilePictureBox.TabStop = false;
            // 
            // Upload
            // 
            this.Upload.Location = new System.Drawing.Point(79, 197);
            this.Upload.Name = "Upload";
            this.Upload.Size = new System.Drawing.Size(118, 23);
            this.Upload.TabIndex = 2;
            this.Upload.Text = "Upload image";
            this.Upload.UseVisualStyleBackColor = true;
            this.Upload.Click += new System.EventHandler(this.Upload_Click);
            this.Upload.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Upload_KeyDown);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(79, 226);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(118, 23);
            this.Save.TabIndex = 3;
            this.Save.Text = "Save changes";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(12, 161);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(260, 20);
            this.txtImagePath.TabIndex = 17;
            // 
            // DatabaseInfo
            // 
            this.DatabaseInfo.AutoSize = true;
            this.DatabaseInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DatabaseInfo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.DatabaseInfo.Location = new System.Drawing.Point(43, 100);
            this.DatabaseInfo.Name = "DatabaseInfo";
            this.DatabaseInfo.Size = new System.Drawing.Size(185, 19);
            this.DatabaseInfo.TabIndex = 18;
            this.DatabaseInfo.Text = "Profile image was changed";
            this.DatabaseInfo.Visible = false;
            // 
            // FormChangeProfilePhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.DatabaseInfo);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Upload);
            this.Controls.Add(this.ProfilePictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormChangeProfilePhoto";
            this.Text = "FormChangeProfilePhoto";
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ProfilePictureBox;
        private System.Windows.Forms.Button Upload;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Label DatabaseInfo;
        private System.Windows.Forms.Timer timer1;
    }
}