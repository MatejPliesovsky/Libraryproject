namespace Library___Login
{
    partial class FormAddLoan
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UserID = new System.Windows.Forms.ComboBox();
            this.BookName1 = new System.Windows.Forms.ComboBox();
            this.BookName2 = new System.Windows.Forms.ComboBox();
            this.BookName3 = new System.Windows.Forms.ComboBox();
            this.BookName4 = new System.Windows.Forms.ComboBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.BookName5 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(116, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User name:";
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(81, 40);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(122, 20);
            this.UserName.TabIndex = 2;
            this.UserName.TextChanged += new System.EventHandler(this.UserName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Book name:";
            // 
            // UserID
            // 
            this.UserID.AllowDrop = true;
            this.UserID.FormattingEnabled = true;
            this.UserID.Location = new System.Drawing.Point(81, 66);
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(121, 21);
            this.UserID.TabIndex = 7;
            this.UserID.SelectedIndexChanged += new System.EventHandler(this.UserID_SelectedIndexChanged);
            // 
            // BookName1
            // 
            this.BookName1.FormattingEnabled = true;
            this.BookName1.Location = new System.Drawing.Point(82, 102);
            this.BookName1.Name = "BookName1";
            this.BookName1.Size = new System.Drawing.Size(121, 21);
            this.BookName1.TabIndex = 8;
            this.BookName1.SelectedIndexChanged += new System.EventHandler(this.BookName1_SelectedIndexChanged);
            // 
            // BookName2
            // 
            this.BookName2.FormattingEnabled = true;
            this.BookName2.Location = new System.Drawing.Point(82, 129);
            this.BookName2.Name = "BookName2";
            this.BookName2.Size = new System.Drawing.Size(121, 21);
            this.BookName2.TabIndex = 9;
            this.BookName2.SelectedIndexChanged += new System.EventHandler(this.BookName1_SelectedIndexChanged);
            // 
            // BookName3
            // 
            this.BookName3.FormattingEnabled = true;
            this.BookName3.Location = new System.Drawing.Point(81, 156);
            this.BookName3.Name = "BookName3";
            this.BookName3.Size = new System.Drawing.Size(121, 21);
            this.BookName3.TabIndex = 10;
            this.BookName3.SelectedIndexChanged += new System.EventHandler(this.BookName1_SelectedIndexChanged);
            // 
            // BookName4
            // 
            this.BookName4.FormattingEnabled = true;
            this.BookName4.Location = new System.Drawing.Point(81, 183);
            this.BookName4.Name = "BookName4";
            this.BookName4.Size = new System.Drawing.Size(121, 21);
            this.BookName4.TabIndex = 11;
            this.BookName4.SelectedIndexChanged += new System.EventHandler(this.BookName1_SelectedIndexChanged);
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(15, 262);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 23);
            this.Confirm.TabIndex = 13;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(197, 262);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 14;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // BookName5
            // 
            this.BookName5.FormattingEnabled = true;
            this.BookName5.Location = new System.Drawing.Point(81, 210);
            this.BookName5.Name = "BookName5";
            this.BookName5.Size = new System.Drawing.Size(121, 21);
            this.BookName5.TabIndex = 12;
            this.BookName5.SelectedIndexChanged += new System.EventHandler(this.BookName1_SelectedIndexChanged);
            // 
            // FormAddLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 297);
            this.Controls.Add(this.BookName5);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.BookName4);
            this.Controls.Add(this.BookName3);
            this.Controls.Add(this.BookName2);
            this.Controls.Add(this.BookName1);
            this.Controls.Add(this.UserID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormAddLoan";
            this.Text = "FormAddLoan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox UserID;
        private System.Windows.Forms.ComboBox BookName1;
        private System.Windows.Forms.ComboBox BookName2;
        private System.Windows.Forms.ComboBox BookName3;
        private System.Windows.Forms.ComboBox BookName4;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ComboBox BookName5;
    }
}