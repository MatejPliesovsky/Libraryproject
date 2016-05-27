namespace Library___Login
{
    partial class FormCheckLoans
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.booksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCategoryBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBookLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLoansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservedBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkLoansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrationReguestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchToUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DatabaseInfo = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.Refresh = new System.Windows.Forms.Button();
            this.Reserved = new System.Windows.Forms.CheckBox();
            this.ErrorMessage = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.booksToolStripMenuItem,
            this.loansToolStripMenuItem,
            this.updateUserToolStripMenuItem,
            this.registrationReguestToolStripMenuItem,
            this.switchToUserToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // booksToolStripMenuItem
            // 
            this.booksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBooksToolStripMenuItem,
            this.addCategoryBookToolStripMenuItem,
            this.addBookLanguageToolStripMenuItem,
            this.removeBooksToolStripMenuItem,
            this.checkBooksToolStripMenuItem});
            this.booksToolStripMenuItem.Name = "booksToolStripMenuItem";
            this.booksToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.booksToolStripMenuItem.Text = "Books";
            // 
            // addBooksToolStripMenuItem
            // 
            this.addBooksToolStripMenuItem.Name = "addBooksToolStripMenuItem";
            this.addBooksToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.addBooksToolStripMenuItem.Text = "Add Books";
            this.addBooksToolStripMenuItem.Click += new System.EventHandler(this.addBooksToolStripMenuItem_Click);
            // 
            // addCategoryBookToolStripMenuItem
            // 
            this.addCategoryBookToolStripMenuItem.Name = "addCategoryBookToolStripMenuItem";
            this.addCategoryBookToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.addCategoryBookToolStripMenuItem.Text = "Add Book Category";
            this.addCategoryBookToolStripMenuItem.Click += new System.EventHandler(this.addCategoryBookToolStripMenuItem_Click);
            // 
            // addBookLanguageToolStripMenuItem
            // 
            this.addBookLanguageToolStripMenuItem.Name = "addBookLanguageToolStripMenuItem";
            this.addBookLanguageToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.addBookLanguageToolStripMenuItem.Text = "Add Book Language";
            this.addBookLanguageToolStripMenuItem.Click += new System.EventHandler(this.addBookLanguageToolStripMenuItem_Click);
            // 
            // removeBooksToolStripMenuItem
            // 
            this.removeBooksToolStripMenuItem.Name = "removeBooksToolStripMenuItem";
            this.removeBooksToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.removeBooksToolStripMenuItem.Text = "Remove books";
            // 
            // checkBooksToolStripMenuItem
            // 
            this.checkBooksToolStripMenuItem.Name = "checkBooksToolStripMenuItem";
            this.checkBooksToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.checkBooksToolStripMenuItem.Text = "Check Books";
            // 
            // loansToolStripMenuItem
            // 
            this.loansToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addLoansToolStripMenuItem,
            this.reservedBooksToolStripMenuItem,
            this.checkLoansToolStripMenuItem});
            this.loansToolStripMenuItem.Name = "loansToolStripMenuItem";
            this.loansToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.loansToolStripMenuItem.Text = "Loans";
            // 
            // addLoansToolStripMenuItem
            // 
            this.addLoansToolStripMenuItem.Name = "addLoansToolStripMenuItem";
            this.addLoansToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.addLoansToolStripMenuItem.Text = "Add loans";
            this.addLoansToolStripMenuItem.Click += new System.EventHandler(this.addLoansToolStripMenuItem_Click);
            // 
            // reservedBooksToolStripMenuItem
            // 
            this.reservedBooksToolStripMenuItem.Name = "reservedBooksToolStripMenuItem";
            this.reservedBooksToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.reservedBooksToolStripMenuItem.Text = "Reserved books";
            this.reservedBooksToolStripMenuItem.Click += new System.EventHandler(this.reservedBooksToolStripMenuItem_Click);
            // 
            // checkLoansToolStripMenuItem
            // 
            this.checkLoansToolStripMenuItem.Name = "checkLoansToolStripMenuItem";
            this.checkLoansToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.checkLoansToolStripMenuItem.Text = "Check loans";
            this.checkLoansToolStripMenuItem.Click += new System.EventHandler(this.checkLoansToolStripMenuItem_Click);
            // 
            // updateUserToolStripMenuItem
            // 
            this.updateUserToolStripMenuItem.Name = "updateUserToolStripMenuItem";
            this.updateUserToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.updateUserToolStripMenuItem.Text = "Update user";
            this.updateUserToolStripMenuItem.Click += new System.EventHandler(this.updateUserToolStripMenuItem_Click);
            // 
            // registrationReguestToolStripMenuItem
            // 
            this.registrationReguestToolStripMenuItem.Name = "registrationReguestToolStripMenuItem";
            this.registrationReguestToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.registrationReguestToolStripMenuItem.Text = " Registration Request (0)";
            this.registrationReguestToolStripMenuItem.Click += new System.EventHandler(this.registrationReguestToolStripMenuItem_Click);
            // 
            // switchToUserToolStripMenuItem
            // 
            this.switchToUserToolStripMenuItem.Name = "switchToUserToolStripMenuItem";
            this.switchToUserToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.switchToUserToolStripMenuItem.Text = "Switch to user";
            this.switchToUserToolStripMenuItem.Click += new System.EventHandler(this.switchToUserToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // DatabaseInfo
            // 
            this.DatabaseInfo.AutoSize = true;
            this.DatabaseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DatabaseInfo.ForeColor = System.Drawing.Color.Red;
            this.DatabaseInfo.Location = new System.Drawing.Point(198, 265);
            this.DatabaseInfo.Name = "DatabaseInfo";
            this.DatabaseInfo.Size = new System.Drawing.Size(389, 31);
            this.DatabaseInfo.TabIndex = 48;
            this.DatabaseInfo.Text = "Cannot connect to database!";
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
            this.listView1.Location = new System.Drawing.Point(148, 60);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(624, 441);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 58;
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
            this.columnHeader2.Text = "User name";
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
            // SearchBar
            // 
            this.SearchBar.Location = new System.Drawing.Point(12, 60);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(121, 20);
            this.SearchBar.TabIndex = 57;
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(12, 131);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(121, 23);
            this.Refresh.TabIndex = 56;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // Reserved
            // 
            this.Reserved.AutoSize = true;
            this.Reserved.Location = new System.Drawing.Point(12, 97);
            this.Reserved.Name = "Reserved";
            this.Reserved.Size = new System.Drawing.Size(89, 17);
            this.Reserved.TabIndex = 55;
            this.Reserved.Text = "Just reserved";
            this.Reserved.UseVisualStyleBackColor = true;
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.AutoSize = true;
            this.ErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.ErrorMessage.Location = new System.Drawing.Point(145, 504);
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.Size = new System.Drawing.Size(286, 24);
            this.ErrorMessage.TabIndex = 59;
            this.ErrorMessage.Text = "Please, select reserved book!";
            this.ErrorMessage.Visible = false;
            // 
            // FormCheckLoans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ErrorMessage);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.SearchBar);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.Reserved);
            this.Controls.Add(this.DatabaseInfo);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormCheckLoans";
            this.Text = "FormCheckLoans";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem booksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCategoryBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBookLanguageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loansToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLoansToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservedBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkLoansToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrationReguestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchToUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.Label DatabaseInfo;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox SearchBar;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.CheckBox Reserved;
        private System.Windows.Forms.Label ErrorMessage;
    }
}