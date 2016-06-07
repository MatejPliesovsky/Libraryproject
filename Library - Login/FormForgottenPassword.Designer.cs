namespace Library___Login
{
    partial class FormForgottenPassword
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForgottenPassword));
            this.label1 = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.TextBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.InfoMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter your email:";
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(15, 131);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(257, 20);
            this.Email.TabIndex = 1;
            this.Email.TextChanged += new System.EventHandler(this.Email_TextChanged);
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(13, 215);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(114, 34);
            this.Confirm.TabIndex = 2;
            this.Confirm.Text = "Send password";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(158, 215);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(114, 34);
            this.Back.TabIndex = 3;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            // 
            // InfoMessage
            // 
            this.InfoMessage.AutoSize = true;
            this.InfoMessage.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InfoMessage.ForeColor = System.Drawing.Color.Red;
            this.InfoMessage.Location = new System.Drawing.Point(15, 170);
            this.InfoMessage.Name = "InfoMessage";
            this.InfoMessage.Size = new System.Drawing.Size(40, 15);
            this.InfoMessage.TabIndex = 4;
            this.InfoMessage.Text = "label2";
            this.InfoMessage.Visible = false;
            // 
            // FormForgottenPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.InfoMessage);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormForgottenPassword";
            this.Text = "FormForgottenPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label InfoMessage;
    }
}