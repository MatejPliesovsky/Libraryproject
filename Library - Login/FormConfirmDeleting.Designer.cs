namespace Library___Login
{
    partial class FormConfirmDeleting
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
            this.Message = new System.Windows.Forms.Label();
            this.Confirm = new System.Windows.Forms.Button();
            this.Refuse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Location = new System.Drawing.Point(36, 40);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(35, 13);
            this.Message.TabIndex = 0;
            this.Message.Text = "label1";
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(50, 118);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 23);
            this.Confirm.TabIndex = 1;
            this.Confirm.Text = "Yes";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // Refuse
            // 
            this.Refuse.Location = new System.Drawing.Point(151, 118);
            this.Refuse.Name = "Refuse";
            this.Refuse.Size = new System.Drawing.Size(75, 23);
            this.Refuse.TabIndex = 2;
            this.Refuse.Text = "No";
            this.Refuse.UseVisualStyleBackColor = true;
            this.Refuse.Click += new System.EventHandler(this.Refuse_Click);
            // 
            // FormConfirmEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 153);
            this.Controls.Add(this.Refuse);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.Message);
            this.Name = "FormConfirmEvent";
            this.Text = "FormConfirmEvent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Refuse;
    }
}