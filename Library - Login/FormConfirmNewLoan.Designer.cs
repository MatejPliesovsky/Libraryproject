namespace Library___Login
{
    partial class FormConfirmNewLoan
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
            this.UserName = new System.Windows.Forms.Label();
            this.BookName = new System.Windows.Forms.Label();
            this.DateOfReturn = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Yes = new System.Windows.Forms.Button();
            this.No = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(13, 13);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(35, 13);
            this.UserName.TabIndex = 0;
            this.UserName.Text = "User: ";
            // 
            // BookName
            // 
            this.BookName.AutoSize = true;
            this.BookName.Location = new System.Drawing.Point(13, 43);
            this.BookName.Name = "BookName";
            this.BookName.Size = new System.Drawing.Size(38, 13);
            this.BookName.TabIndex = 1;
            this.BookName.Text = "Book: ";
            // 
            // DateOfReturn
            // 
            this.DateOfReturn.AutoSize = true;
            this.DateOfReturn.Location = new System.Drawing.Point(13, 73);
            this.DateOfReturn.Name = "DateOfReturn";
            this.DateOfReturn.Size = new System.Drawing.Size(78, 13);
            this.DateOfReturn.TabIndex = 2;
            this.DateOfReturn.Text = "Date of return: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Do you really want to add this loan?";
            // 
            // Yes
            // 
            this.Yes.Location = new System.Drawing.Point(13, 178);
            this.Yes.Name = "Yes";
            this.Yes.Size = new System.Drawing.Size(75, 23);
            this.Yes.TabIndex = 4;
            this.Yes.Text = "Yes";
            this.Yes.UseVisualStyleBackColor = true;
            // 
            // No
            // 
            this.No.Location = new System.Drawing.Point(184, 178);
            this.No.Name = "No";
            this.No.Size = new System.Drawing.Size(75, 23);
            this.No.TabIndex = 5;
            this.No.Text = "No";
            this.No.UseVisualStyleBackColor = true;
            // 
            // FormConfirmNewLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 213);
            this.Controls.Add(this.No);
            this.Controls.Add(this.Yes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DateOfReturn);
            this.Controls.Add(this.BookName);
            this.Controls.Add(this.UserName);
            this.Name = "FormConfirmNewLoan";
            this.Text = "FormConfirmNewLoan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Label BookName;
        private System.Windows.Forms.Label DateOfReturn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Yes;
        private System.Windows.Forms.Button No;
    }
}