namespace Library___Login
{
    partial class ReservationDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReservationDetails));
            this.Language = new System.Windows.Forms.Label();
            this.Category = new System.Windows.Forms.Label();
            this.Author = new System.Windows.Forms.Label();
            this.BookName = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.Label();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.Refuse = new System.Windows.Forms.Button();
            this.UserAge = new System.Windows.Forms.Label();
            this.DatabaseInfo = new System.Windows.Forms.Label();
            this.Penalty = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Language
            // 
            this.Language.AutoSize = true;
            this.Language.Location = new System.Drawing.Point(12, 108);
            this.Language.Name = "Language";
            this.Language.Size = new System.Drawing.Size(55, 13);
            this.Language.TabIndex = 8;
            this.Language.Text = "Language";
            // 
            // Category
            // 
            this.Category.AutoSize = true;
            this.Category.Location = new System.Drawing.Point(12, 78);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(49, 13);
            this.Category.TabIndex = 7;
            this.Category.Text = "Category";
            // 
            // Author
            // 
            this.Author.AutoSize = true;
            this.Author.Location = new System.Drawing.Point(12, 48);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(38, 13);
            this.Author.TabIndex = 6;
            this.Author.Text = "Author";
            // 
            // BookName
            // 
            this.BookName.AutoSize = true;
            this.BookName.Location = new System.Drawing.Point(12, 18);
            this.BookName.Name = "BookName";
            this.BookName.Size = new System.Drawing.Size(60, 13);
            this.BookName.TabIndex = 5;
            this.BookName.Text = "BookName";
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(12, 138);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(57, 13);
            this.UserName.TabIndex = 10;
            this.UserName.Text = "UserName";
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(411, 12);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(361, 390);
            this.PictureBox.TabIndex = 9;
            this.PictureBox.TabStop = false;
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(15, 400);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(120, 45);
            this.Confirm.TabIndex = 12;
            this.Confirm.Text = "Borrow book";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // Refuse
            // 
            this.Refuse.Location = new System.Drawing.Point(179, 400);
            this.Refuse.Name = "Refuse";
            this.Refuse.Size = new System.Drawing.Size(120, 45);
            this.Refuse.TabIndex = 13;
            this.Refuse.Text = "Refuse borrowing";
            this.Refuse.UseVisualStyleBackColor = true;
            this.Refuse.Click += new System.EventHandler(this.Refuse_Click);
            // 
            // UserAge
            // 
            this.UserAge.AutoSize = true;
            this.UserAge.Location = new System.Drawing.Point(12, 167);
            this.UserAge.Name = "UserAge";
            this.UserAge.Size = new System.Drawing.Size(48, 13);
            this.UserAge.TabIndex = 11;
            this.UserAge.Text = "UserAge";
            // 
            // DatabaseInfo
            // 
            this.DatabaseInfo.AutoSize = true;
            this.DatabaseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DatabaseInfo.ForeColor = System.Drawing.Color.Red;
            this.DatabaseInfo.Location = new System.Drawing.Point(-1, 265);
            this.DatabaseInfo.Name = "DatabaseInfo";
            this.DatabaseInfo.Size = new System.Drawing.Size(389, 31);
            this.DatabaseInfo.TabIndex = 49;
            this.DatabaseInfo.Text = "Cannot connect to database!";
            this.DatabaseInfo.Visible = false;
            // 
            // Penalty
            // 
            this.Penalty.AutoSize = true;
            this.Penalty.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Penalty.ForeColor = System.Drawing.Color.Red;
            this.Penalty.Location = new System.Drawing.Point(1, 209);
            this.Penalty.Name = "Penalty";
            this.Penalty.Size = new System.Drawing.Size(49, 19);
            this.Penalty.TabIndex = 50;
            this.Penalty.Text = "label1";
            this.Penalty.Visible = false;
            // 
            // ReservationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.Penalty);
            this.Controls.Add(this.DatabaseInfo);
            this.Controls.Add(this.Refuse);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.UserAge);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.Language);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.Author);
            this.Controls.Add(this.BookName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReservationDetails";
            this.Text = "ReservationDetails";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Language;
        private System.Windows.Forms.Label Category;
        private System.Windows.Forms.Label Author;
        private System.Windows.Forms.Label BookName;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Refuse;
        private System.Windows.Forms.Label UserAge;
        private System.Windows.Forms.Label DatabaseInfo;
        private System.Windows.Forms.Label Penalty;
        private System.Windows.Forms.Timer timer1;
    }
}