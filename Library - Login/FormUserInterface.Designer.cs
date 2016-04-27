namespace Library___Login
{
    partial class FormUserInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserInterface));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Refresh = new System.Windows.Forms.Button();
            this.Search_btn = new System.Windows.Forms.Button();
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.SearchFree = new System.Windows.Forms.CheckBox();
            this.SwitchToAdmin = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackgroundImageTiled = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader2});
            this.listView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(180, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(516, 270);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged_1);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "BookName";
            this.columnHeader1.Width = 137;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Author";
            this.columnHeader3.Width = 153;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Lent";
            this.columnHeader4.Width = 92;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Category";
            this.columnHeader2.Width = 125;
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(333, 288);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(133, 23);
            this.Refresh.TabIndex = 1;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // Search_btn
            // 
            this.Search_btn.Location = new System.Drawing.Point(12, 288);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(120, 23);
            this.Search_btn.TabIndex = 2;
            this.Search_btn.Text = "SEARCH";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // SearchBar
            // 
            this.SearchBar.Location = new System.Drawing.Point(12, 12);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(162, 20);
            this.SearchBar.TabIndex = 3;
            // 
            // SearchFree
            // 
            this.SearchFree.AutoSize = true;
            this.SearchFree.Location = new System.Drawing.Point(12, 182);
            this.SearchFree.Name = "SearchFree";
            this.SearchFree.Size = new System.Drawing.Size(66, 17);
            this.SearchFree.TabIndex = 4;
            this.SearchFree.Text = "Just free";
            this.SearchFree.UseVisualStyleBackColor = true;
            this.SearchFree.CheckedChanged += new System.EventHandler(this.SearchFree_CheckedChanged);
            // 
            // SwitchToAdmin
            // 
            this.SwitchToAdmin.Location = new System.Drawing.Point(603, 288);
            this.SwitchToAdmin.Name = "SwitchToAdmin";
            this.SwitchToAdmin.Size = new System.Drawing.Size(93, 23);
            this.SwitchToAdmin.TabIndex = 5;
            this.SwitchToAdmin.Text = "Back to Admin";
            this.SwitchToAdmin.UseVisualStyleBackColor = true;
            this.SwitchToAdmin.Click += new System.EventHandler(this.SwitchToAdmin_Click);
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
            this.checkedListBox1.Location = new System.Drawing.Point(12, 82);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 94);
            this.checkedListBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose category";
            // 
            // FormUserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 328);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.SwitchToAdmin);
            this.Controls.Add(this.SearchFree);
            this.Controls.Add(this.SearchBar);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUserInterface";
            this.Text = "ReBooks";
            this.Shown += new System.EventHandler(this.Form2_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.TextBox SearchBar;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.CheckBox SearchFree;
        private System.Windows.Forms.Button SwitchToAdmin;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label1;
    }
}