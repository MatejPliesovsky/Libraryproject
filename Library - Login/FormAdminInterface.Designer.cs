namespace Library___Login
{
    partial class FormAdminInterface
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
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SearchFree = new System.Windows.Forms.CheckBox();
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.Search_btn = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.booksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCategoryBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBookLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLoansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLoansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkLoansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrationReguestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchToUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DatabaseInfo = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(8, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Choose language";
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "English",
            "Slovak",
            "Germany",
            "Spain",
            "Polish"});
            this.checkedListBox2.Location = new System.Drawing.Point(12, 202);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(125, 79);
            this.checkedListBox2.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Choose category";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Programming",
            "Roman",
            "Drama",
            "Story",
            "Thriler"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 75);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(125, 94);
            this.checkedListBox1.TabIndex = 15;
            // 
            // SearchFree
            // 
            this.SearchFree.AutoSize = true;
            this.SearchFree.Location = new System.Drawing.Point(12, 287);
            this.SearchFree.Name = "SearchFree";
            this.SearchFree.Size = new System.Drawing.Size(66, 17);
            this.SearchFree.TabIndex = 14;
            this.SearchFree.Text = "Just free";
            this.SearchFree.UseVisualStyleBackColor = true;
            // 
            // SearchBar
            // 
            this.SearchBar.Location = new System.Drawing.Point(148, 50);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(477, 20);
            this.SearchBar.TabIndex = 13;
            // 
            // Search_btn
            // 
            this.Search_btn.Location = new System.Drawing.Point(630, 50);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(142, 20);
            this.Search_btn.TabIndex = 12;
            this.Search_btn.Text = "SEARCH";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click_1);
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(148, 526);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(624, 23);
            this.Refresh.TabIndex = 11;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click_1);
            // 
            // listView1
            // 
            this.listView1.BackgroundImageTiled = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader2,
            this.columnHeader5});
            this.listView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(148, 79);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(624, 441);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged_1);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "BookName";
            this.columnHeader1.Width = 124;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Author";
            this.columnHeader3.Width = 105;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Lent";
            this.columnHeader4.Width = 66;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Category";
            this.columnHeader2.Width = 114;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Language";
            this.columnHeader5.Width = 123;
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
            this.menuStrip1.TabIndex = 19;
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
            this.removeLoansToolStripMenuItem,
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
            // removeLoansToolStripMenuItem
            // 
            this.removeLoansToolStripMenuItem.Name = "removeLoansToolStripMenuItem";
            this.removeLoansToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.removeLoansToolStripMenuItem.Text = "Reserved books";
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
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
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
            this.DatabaseInfo.Visible = false;
            // 
            // FormAdminInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.DatabaseInfo);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkedListBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.SearchFree);
            this.Controls.Add(this.SearchBar);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.listView1);
            this.Name = "FormAdminInterface";
            this.Text = "FormEditBook";
            this.Shown += new System.EventHandler(this.Form2_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckBox SearchFree;
        private System.Windows.Forms.TextBox SearchBar;
        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem booksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCategoryBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBookLanguageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loansToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLoansToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeLoansToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkLoansToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrationReguestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchToUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.Label DatabaseInfo;
    }
}