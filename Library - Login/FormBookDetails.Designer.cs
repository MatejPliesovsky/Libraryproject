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
            this.BookName = new System.Windows.Forms.Label();
            this.Author = new System.Windows.Forms.Label();
            this.Publisher = new System.Windows.Forms.Label();
            this.Category = new System.Windows.Forms.Label();
            this.Language = new System.Windows.Forms.Label();
            this.Lent = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.DeleteRes = new System.Windows.Forms.Button();
            this.Reserve = new System.Windows.Forms.Button();
            this.Exception = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BookName
            // 
            this.BookName.AutoSize = true;
            this.BookName.Location = new System.Drawing.Point(30, 30);
            this.BookName.Name = "BookName";
            this.BookName.Size = new System.Drawing.Size(60, 13);
            this.BookName.TabIndex = 0;
            this.BookName.Text = "BookName";
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
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Location = new System.Drawing.Point(30, 210);
            this.Description.MaximumSize = new System.Drawing.Size(350, 0);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(60, 13);
            this.Description.TabIndex = 6;
            this.Description.Text = "Description";
            // 
            // PictureBox
            // 
            this.PictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PictureBox.Location = new System.Drawing.Point(411, 12);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(361, 390);
            this.PictureBox.TabIndex = 7;
            this.PictureBox.TabStop = false;
            // 
            // DeleteRes
            // 
            this.DeleteRes.Location = new System.Drawing.Point(562, 482);
            this.DeleteRes.Name = "DeleteRes";
            this.DeleteRes.Size = new System.Drawing.Size(113, 23);
            this.DeleteRes.TabIndex = 9;
            this.DeleteRes.Text = "Delete Reservation";
            this.DeleteRes.UseVisualStyleBackColor = true;
            this.DeleteRes.Click += new System.EventHandler(this.DeleteRes_Click);
            // 
            // Reserve
            // 
            this.Reserve.Location = new System.Drawing.Point(107, 482);
            this.Reserve.Name = "Reserve";
            this.Reserve.Size = new System.Drawing.Size(117, 23);
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
            this.Exception.Location = new System.Drawing.Point(107, 441);
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
            this.messageLabel.Location = new System.Drawing.Point(332, 303);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(66, 24);
            this.messageLabel.TabIndex = 12;
            this.messageLabel.Text = "label1";
            this.messageLabel.Visible = false;
            // 
            // FormBookDetails
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.Exception);
            this.Controls.Add(this.Reserve);
            this.Controls.Add(this.DeleteRes);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.Lent);
            this.Controls.Add(this.Language);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.Publisher);
            this.Controls.Add(this.Author);
            this.Controls.Add(this.BookName);
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
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Button DeleteRes;
        private System.Windows.Forms.Button reserve;
        private System.Windows.Forms.Button Reserve;
        private System.Windows.Forms.Label Exception;
        private System.Windows.Forms.Label messageLabel;
    }
}