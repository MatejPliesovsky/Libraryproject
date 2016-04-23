namespace Library___Login
{
    partial class FormBookDetail
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
            this.BookName = new System.Windows.Forms.Label();
            this.Author = new System.Windows.Forms.Label();
            this.Publisher = new System.Windows.Forms.Label();
            this.Category = new System.Windows.Forms.Label();
            this.Language = new System.Windows.Forms.Label();
            this.Lent = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BookName
            // 
            this.BookName.AutoSize = true;
            this.BookName.Location = new System.Drawing.Point(26, 28);
            this.BookName.Name = "BookName";
            this.BookName.Size = new System.Drawing.Size(60, 13);
            this.BookName.TabIndex = 0;
            this.BookName.Text = "BookName";
            // 
            // Author
            // 
            this.Author.AutoSize = true;
            this.Author.Location = new System.Drawing.Point(29, 56);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(38, 13);
            this.Author.TabIndex = 1;
            this.Author.Text = "Author";
            // 
            // Publisher
            // 
            this.Publisher.AutoSize = true;
            this.Publisher.Location = new System.Drawing.Point(29, 85);
            this.Publisher.Name = "Publisher";
            this.Publisher.Size = new System.Drawing.Size(50, 13);
            this.Publisher.TabIndex = 2;
            this.Publisher.Text = "Publisher";
            // 
            // Category
            // 
            this.Category.AutoSize = true;
            this.Category.Location = new System.Drawing.Point(29, 116);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(49, 13);
            this.Category.TabIndex = 3;
            this.Category.Text = "Category";
            // 
            // Language
            // 
            this.Language.AutoSize = true;
            this.Language.Location = new System.Drawing.Point(32, 155);
            this.Language.Name = "Language";
            this.Language.Size = new System.Drawing.Size(55, 13);
            this.Language.TabIndex = 4;
            this.Language.Text = "Language";
            // 
            // Lent
            // 
            this.Lent.AutoSize = true;
            this.Lent.Location = new System.Drawing.Point(32, 188);
            this.Lent.Name = "Lent";
            this.Lent.Size = new System.Drawing.Size(28, 13);
            this.Lent.TabIndex = 5;
            this.Lent.Text = "Lent";
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Location = new System.Drawing.Point(29, 223);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(60, 13);
            this.Description.TabIndex = 6;
            this.Description.Text = "Description";
            // 
            // FormBookDetail
            // 
            this.ClientSize = new System.Drawing.Size(566, 314);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.Lent);
            this.Controls.Add(this.Language);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.Publisher);
            this.Controls.Add(this.Author);
            this.Controls.Add(this.BookName);
            this.Name = "FormBookDetail";
            this.Load += new System.EventHandler(this.FormBookDetail_Load);
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
        private System.Windows.Forms.Label Description;
    }
}