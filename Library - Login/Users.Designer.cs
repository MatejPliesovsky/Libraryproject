namespace Library___Login
{
    partial class Users
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UserAllName = new System.Windows.Forms.Label();
            this.UserAge = new System.Windows.Forms.Label();
            this.ErrorMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 129);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UserAllName
            // 
            this.UserAllName.AutoSize = true;
            this.UserAllName.Location = new System.Drawing.Point(13, 149);
            this.UserAllName.Name = "UserAllName";
            this.UserAllName.Size = new System.Drawing.Size(35, 13);
            this.UserAllName.TabIndex = 1;
            this.UserAllName.Text = "label1";
            this.UserAllName.Click += new System.EventHandler(this.UserAllName_Click);
            // 
            // UserAge
            // 
            this.UserAge.AutoSize = true;
            this.UserAge.Location = new System.Drawing.Point(13, 166);
            this.UserAge.Name = "UserAge";
            this.UserAge.Size = new System.Drawing.Size(35, 13);
            this.UserAge.TabIndex = 2;
            this.UserAge.Text = "label2";
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.AutoSize = true;
            this.ErrorMessage.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.ErrorMessage.Location = new System.Drawing.Point(113, 134);
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.Size = new System.Drawing.Size(378, 32);
            this.ErrorMessage.TabIndex = 3;
            this.ErrorMessage.Text = "Cannot conect to database!";
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 280);
            this.Controls.Add(this.ErrorMessage);
            this.Controls.Add(this.UserAge);
            this.Controls.Add(this.UserAllName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Users";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label UserAllName;
        private System.Windows.Forms.Label UserAge;
        private System.Windows.Forms.Label ErrorMessage;
    }
}