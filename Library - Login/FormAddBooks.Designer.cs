namespace Library___Login
{
    partial class FormAddBooks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddBooks));
            this.lblBookName = new System.Windows.Forms.Label();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.lblAutho = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.comboBoxBookCategory = new System.Windows.Forms.ComboBox();
            this.lblBookCategory = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBookLanguage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.richTxtBookDescreption = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBookName
            // 
            this.lblBookName.AutoSize = true;
            this.lblBookName.Location = new System.Drawing.Point(44, 39);
            this.lblBookName.Name = "lblBookName";
            this.lblBookName.Size = new System.Drawing.Size(63, 13);
            this.lblBookName.TabIndex = 0;
            this.lblBookName.Text = "Book Name";
            // 
            // txtBookName
            // 
            this.txtBookName.Location = new System.Drawing.Point(113, 36);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.Size = new System.Drawing.Size(154, 20);
            this.txtBookName.TabIndex = 1;
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(312, 379);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(119, 23);
            this.btnAddBook.TabIndex = 2;
            this.btnAddBook.Text = "ADD BOOK";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // lblAutho
            // 
            this.lblAutho.AutoSize = true;
            this.lblAutho.Location = new System.Drawing.Point(69, 72);
            this.lblAutho.Name = "lblAutho";
            this.lblAutho.Size = new System.Drawing.Size(38, 13);
            this.lblAutho.TabIndex = 3;
            this.lblAutho.Text = "Author";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(113, 69);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(154, 20);
            this.txtAuthor.TabIndex = 4;
            // 
            // comboBoxBookCategory
            // 
            this.comboBoxBookCategory.FormattingEnabled = true;
            this.comboBoxBookCategory.Location = new System.Drawing.Point(113, 107);
            this.comboBoxBookCategory.Name = "comboBoxBookCategory";
            this.comboBoxBookCategory.Size = new System.Drawing.Size(154, 21);
            this.comboBoxBookCategory.TabIndex = 5;
            // 
            // lblBookCategory
            // 
            this.lblBookCategory.AutoSize = true;
            this.lblBookCategory.Location = new System.Drawing.Point(58, 110);
            this.lblBookCategory.Name = "lblBookCategory";
            this.lblBookCategory.Size = new System.Drawing.Size(49, 13);
            this.lblBookCategory.TabIndex = 6;
            this.lblBookCategory.Text = "Category";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Language";
            // 
            // comboBoxBookLanguage
            // 
            this.comboBoxBookLanguage.FormattingEnabled = true;
            this.comboBoxBookLanguage.Location = new System.Drawing.Point(113, 139);
            this.comboBoxBookLanguage.Name = "comboBoxBookLanguage";
            this.comboBoxBookLanguage.Size = new System.Drawing.Size(154, 21);
            this.comboBoxBookLanguage.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "ISBN";
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(113, 172);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(154, 20);
            this.txtISBN.TabIndex = 10;
            // 
            // richTxtBookDescreption
            // 
            this.richTxtBookDescreption.Location = new System.Drawing.Point(113, 204);
            this.richTxtBookDescreption.Name = "richTxtBookDescreption";
            this.richTxtBookDescreption.Size = new System.Drawing.Size(318, 169);
            this.richTxtBookDescreption.TabIndex = 11;
            this.richTxtBookDescreption.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Book Descreption";
            // 
            // FormAddBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 457);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTxtBookDescreption);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxBookLanguage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBookCategory);
            this.Controls.Add(this.comboBoxBookCategory);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblAutho);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.txtBookName);
            this.Controls.Add(this.lblBookName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAddBooks";
            this.Text = "FormAddBooks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBookName;
        private System.Windows.Forms.TextBox txtBookName;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Label lblAutho;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.ComboBox comboBoxBookCategory;
        private System.Windows.Forms.Label lblBookCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBookLanguage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.RichTextBox richTxtBookDescreption;
        private System.Windows.Forms.Label label3;
    }
}