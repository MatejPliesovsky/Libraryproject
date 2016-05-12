namespace Library___Login
{
    partial class FormAdminHome
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DatabaseInfo = new System.Windows.Forms.Label();
            this.adminMenuControl1 = new Library___Login.AdminMenuControl();
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
            this.listView1.Location = new System.Drawing.Point(52, 58);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(516, 202);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
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
            // DatabaseInfo
            // 
            this.DatabaseInfo.AutoSize = true;
            this.DatabaseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DatabaseInfo.ForeColor = System.Drawing.Color.Red;
            this.DatabaseInfo.Location = new System.Drawing.Point(114, 140);
            this.DatabaseInfo.Name = "DatabaseInfo";
            this.DatabaseInfo.Size = new System.Drawing.Size(389, 31);
            this.DatabaseInfo.TabIndex = 48;
            this.DatabaseInfo.Text = "Cannot connect to database!";
            this.DatabaseInfo.Visible = false;
            // 
            // adminMenuControl1
            // 
            this.adminMenuControl1.Location = new System.Drawing.Point(2, 1);
            this.adminMenuControl1.Name = "adminMenuControl1";
            this.adminMenuControl1.Size = new System.Drawing.Size(645, 24);
            this.adminMenuControl1.TabIndex = 49;
            // 
            // FormAdminHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 287);
            this.Controls.Add(this.adminMenuControl1);
            this.Controls.Add(this.DatabaseInfo);
            this.Controls.Add(this.listView1);
            this.Name = "FormAdminHome";
            this.Text = "FormAdminHome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label DatabaseInfo;
        private AdminMenuControl adminMenuControl1;
    }
}