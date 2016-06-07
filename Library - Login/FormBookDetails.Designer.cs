namespace Library___Login
{
    partial class FormBookDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBookDetails));
            this.BookName = new System.Windows.Forms.Label();
            this.Author = new System.Windows.Forms.Label();
            this.Publisher = new System.Windows.Forms.Label();
            this.Category = new System.Windows.Forms.Label();
            this.Language = new System.Windows.Forms.Label();
            this.Lent = new System.Windows.Forms.Label();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.DeleteRes = new System.Windows.Forms.Button();
            this.Reserve = new System.Windows.Forms.Button();
            this.Exception = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.RichTextBox();
            this.Back = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BookName
            // 
            this.BookName.AutoSize = true;
            this.BookName.Location = new System.Drawing.Point(30, 30);
            this.BookName.Name = "BookName";
            this.BookName.Size = new System.Drawing.Size(63, 13);
            this.BookName.TabIndex = 0;
            this.BookName.Text = "Book Name";
            // 
            // Author
            // 
            this.Author.AutoSize = true;
            this.Author.Location = new System.Drawing.Point(30, 60);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(38, 13);
            this.Author.TabIndex = 1;
            this.Author.Text = "Author";
            // 
            // Publisher
            // 
            this.Publisher.AutoSize = true;
            this.Publisher.Location = new System.Drawing.Point(30, 90);
            this.Publisher.Name = "Publisher";
            this.Publisher.Size = new System.Drawing.Size(50, 13);
            this.Publisher.TabIndex = 2;
            this.Publisher.Text = "Publisher";
            // 
            // Category
            // 
            this.Category.AutoSize = true;
            this.Category.Location = new System.Drawing.Point(30, 120);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(49, 13);
            this.Category.TabIndex = 3;
            this.Category.Text = "Category";
            // 
            // Language
            // 
            this.Language.AutoSize = true;
            this.Language.Location = new System.Drawing.Point(30, 150);
            this.Language.Name = "Language";
            this.Language.Size = new System.Drawing.Size(55, 13);
            this.Language.TabIndex = 4;
            this.Language.Text = "Language";
            // 
            // Lent
            // 
            this.Lent.AutoSize = true;
            this.Lent.Location = new System.Drawing.Point(30, 180);
            this.Lent.Name = "Lent";
            this.Lent.Size = new System.Drawing.Size(28, 13);
            this.Lent.TabIndex = 5;
            this.Lent.Text = "Lent";
            // 
            // PictureBox
            // 
            this.PictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PictureBox.Location = new System.Drawing.Point(411, 12);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(361, 449);
            this.PictureBox.TabIndex = 7;
            this.PictureBox.TabStop = false;
            // 
            // DeleteRes
            // 
            this.DeleteRes.Location = new System.Drawing.Point(524, 511);
            this.DeleteRes.Name = "DeleteRes";
            this.DeleteRes.Size = new System.Drawing.Size(124, 38);
            this.DeleteRes.TabIndex = 9;
            this.DeleteRes.Text = "Delete Reservation";
            this.DeleteRes.UseVisualStyleBackColor = true;
            this.DeleteRes.Click += new System.EventHandler(this.DeleteRes_Click);
            // 
            // Reserve
            // 
            this.Reserve.Location = new System.Drawing.Point(73, 511);
            this.Reserve.Name = "Reserve";
            this.Reserve.Size = new System.Drawing.Size(128, 38);
            this.Reserve.TabIndex = 10;
            this.Reserve.Text = "Reserve Book";
            this.Reserve.UseVisualStyleBackColor = true;
            this.Reserve.Click += new System.EventHandler(this.Reserve_Click);
            // 
            // Exception
            // 
            this.Exception.AutoSize = true;
            this.Exception.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Exception.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Exception.Location = new System.Drawing.Point(69, 488);
            this.Exception.Name = "Exception";
            this.Exception.Size = new System.Drawing.Size(57, 20);
            this.Exception.TabIndex = 11;
            this.Exception.Text = "label1";
            this.Exception.Visible = false;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.messageLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.messageLabel.Location = new System.Drawing.Point(32, 454);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(66, 24);
            this.messageLabel.TabIndex = 12;
            this.messageLabel.Text = "label1";
            this.messageLabel.Visible = false;
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(36, 207);
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Size = new System.Drawing.Size(347, 231);
            this.Description.TabIndex = 15;
            this.Description.Text = "";
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(654, 511);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(118, 38);
            this.Back.TabIndex = 16;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // FormBookDetails
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.Exception);
            this.Controls.Add(this.Reserve);
            this.Controls.Add(this.DeleteRes);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.Lent);
            this.Controls.Add(this.Language);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.Publisher);
            this.Controls.Add(this.Author);
            this.Controls.Add(this.BookName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBookDetails";
            this.Shown += new System.EventHandler(this.FormBookDetails_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BookName;
        private System.Windows.Forms.Label Author;
        private System.Windows.Forms.Label Publisher;
        private System.Windows.Forms.Label Category;
        private System.Windows.Forms.Label Language;
        private System.Windows.Forms.Label Lent;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Button DeleteRes;
        private System.Windows.Forms.Button reserve;
        private System.Windows.Forms.Button Reserve;
        private System.Windows.Forms.Label Exception;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.RichTextBox Description;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Timer timer1;
    }
}