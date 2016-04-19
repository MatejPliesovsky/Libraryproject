namespace Library___Login
{
    partial class FormAddBookCategory
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
            this.txtBookCategory = new System.Windows.Forms.TextBox();
            this.btnAddBookCategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category Name";
            // 
            // txtBookCategory
            // 
            this.txtBookCategory.Location = new System.Drawing.Point(180, 81);
            this.txtBookCategory.Name = "txtBookCategory";
            this.txtBookCategory.Size = new System.Drawing.Size(100, 20);
            this.txtBookCategory.TabIndex = 1;
            // 
            // btnAddBookCategory
            // 
            this.btnAddBookCategory.Location = new System.Drawing.Point(97, 107);
            this.btnAddBookCategory.Name = "btnAddBookCategory";
            this.btnAddBookCategory.Size = new System.Drawing.Size(183, 78);
            this.btnAddBookCategory.TabIndex = 2;
            this.btnAddBookCategory.Text = "ADD BOOK CATEGORY";
            this.btnAddBookCategory.UseVisualStyleBackColor = true;
            this.btnAddBookCategory.Click += new System.EventHandler(this.btnAddBookCategory_Click);
            // 
            // FormAddBookCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 280);
            this.Controls.Add(this.btnAddBookCategory);
            this.Controls.Add(this.txtBookCategory);
            this.Controls.Add(this.label1);
            this.Name = "FormAddBookCategory";
            this.Text = "FoormAddBookCategory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBookCategory;
        private System.Windows.Forms.Button btnAddBookCategory;
    }
}