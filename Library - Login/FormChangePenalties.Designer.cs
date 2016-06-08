namespace Library___Login
{
    partial class FormChangePenalties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChangePenalties));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TwoWeeks = new System.Windows.Forms.TextBox();
            this.OneMonth = new System.Windows.Forms.TextBox();
            this.TwoMonths = new System.Windows.Forms.TextBox();
            this.Longer = new System.Windows.Forms.TextBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.Message = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Penalty till 2 weeks:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Penalty till 1 month:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Penalty till 2 months:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Penalty more than 2 months:";
            // 
            // TwoWeeks
            // 
            this.TwoWeeks.Location = new System.Drawing.Point(172, 32);
            this.TwoWeeks.Name = "TwoWeeks";
            this.TwoWeeks.Size = new System.Drawing.Size(100, 20);
            this.TwoWeeks.TabIndex = 4;
            this.TwoWeeks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Longer_KeyDown);
            // 
            // OneMonth
            // 
            this.OneMonth.Location = new System.Drawing.Point(172, 57);
            this.OneMonth.Name = "OneMonth";
            this.OneMonth.Size = new System.Drawing.Size(100, 20);
            this.OneMonth.TabIndex = 5;
            this.OneMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Longer_KeyDown);
            // 
            // TwoMonths
            // 
            this.TwoMonths.Location = new System.Drawing.Point(172, 82);
            this.TwoMonths.Name = "TwoMonths";
            this.TwoMonths.Size = new System.Drawing.Size(100, 20);
            this.TwoMonths.TabIndex = 6;
            this.TwoMonths.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Longer_KeyDown);
            // 
            // Longer
            // 
            this.Longer.Location = new System.Drawing.Point(172, 107);
            this.Longer.Name = "Longer";
            this.Longer.Size = new System.Drawing.Size(100, 20);
            this.Longer.TabIndex = 7;
            this.Longer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Longer_KeyDown);
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(12, 178);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(125, 23);
            this.Confirm.TabIndex = 8;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(146, 178);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(125, 23);
            this.Back.TabIndex = 9;
            this.Back.Text = "Close without changes";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Message.ForeColor = System.Drawing.Color.Red;
            this.Message.Location = new System.Drawing.Point(49, 144);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(175, 16);
            this.Message.TabIndex = 10;
            this.Message.Text = "Penalty wasn\'t changed!";
            this.Message.Visible = false;
            // 
            // FormChangePenalties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 213);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.Longer);
            this.Controls.Add(this.TwoMonths);
            this.Controls.Add(this.OneMonth);
            this.Controls.Add(this.TwoWeeks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormChangePenalties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TwoWeeks;
        private System.Windows.Forms.TextBox OneMonth;
        private System.Windows.Forms.TextBox TwoMonths;
        private System.Windows.Forms.TextBox Longer;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.Timer timer1;
    }
}