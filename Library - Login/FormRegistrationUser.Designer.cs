namespace Library___Login
{
    partial class FormRegistrationUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistrationUser));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.LastName = new System.Windows.Forms.TextBox();
            this.Street = new System.Windows.Forms.TextBox();
            this.DateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.Number = new System.Windows.Forms.TextBox();
            this.City = new System.Windows.Forms.TextBox();
            this.PostalCode = new System.Windows.Forms.TextBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.PasswordReg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.EmailReg = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Telephone2 = new System.Windows.Forms.TextBox();
            this.Info = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Country = new System.Windows.Forms.ComboBox();
            this.Telephone1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date of birth:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(331, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Street:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(322, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Number:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(342, 281);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "City:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(303, 307);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Postal code:";
            // 
            // FirstName
            // 
            this.FirstName.Location = new System.Drawing.Point(375, 60);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(133, 20);
            this.FirstName.TabIndex = 11;
            this.FirstName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FirstName_KeyDown);
            // 
            // LastName
            // 
            this.LastName.Location = new System.Drawing.Point(375, 86);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(133, 20);
            this.LastName.TabIndex = 12;
            this.LastName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FirstName_KeyDown);
            // 
            // Street
            // 
            this.Street.Location = new System.Drawing.Point(375, 226);
            this.Street.Name = "Street";
            this.Street.Size = new System.Drawing.Size(100, 20);
            this.Street.TabIndex = 18;
            this.Street.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FirstName_KeyDown);
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.Location = new System.Drawing.Point(375, 113);
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.Size = new System.Drawing.Size(133, 20);
            this.DateOfBirth.TabIndex = 13;
            this.DateOfBirth.Value = new System.DateTime(2016, 4, 8, 0, 0, 0, 0);
            this.DateOfBirth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FirstName_KeyDown);
            // 
            // Number
            // 
            this.Number.Location = new System.Drawing.Point(375, 252);
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(100, 20);
            this.Number.TabIndex = 19;
            this.Number.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FirstName_KeyDown);
            // 
            // City
            // 
            this.City.Location = new System.Drawing.Point(375, 278);
            this.City.Name = "City";
            this.City.Size = new System.Drawing.Size(100, 20);
            this.City.TabIndex = 20;
            this.City.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FirstName_KeyDown);
            // 
            // PostalCode
            // 
            this.PostalCode.Location = new System.Drawing.Point(375, 304);
            this.PostalCode.Name = "PostalCode";
            this.PostalCode.Size = new System.Drawing.Size(100, 20);
            this.PostalCode.TabIndex = 21;
            this.PostalCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FirstName_KeyDown);
            // 
            // Confirm
            // 
            this.Confirm.BackColor = System.Drawing.Color.LightPink;
            this.Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Confirm.Location = new System.Drawing.Point(408, 362);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 23);
            this.Confirm.TabIndex = 24;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = false;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(327, 362);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 23;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // PasswordReg
            // 
            this.PasswordReg.Location = new System.Drawing.Point(375, 139);
            this.PasswordReg.Name = "PasswordReg";
            this.PasswordReg.Size = new System.Drawing.Size(133, 20);
            this.PasswordReg.TabIndex = 14;
            this.PasswordReg.TextChanged += new System.EventHandler(this.PasswordReg_TextChanged);
            this.PasswordReg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FirstName_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(313, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "email:";
            // 
            // EmailReg
            // 
            this.EmailReg.Location = new System.Drawing.Point(375, 165);
            this.EmailReg.Name = "EmailReg";
            this.EmailReg.Size = new System.Drawing.Size(133, 20);
            this.EmailReg.TabIndex = 15;
            this.EmailReg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FirstName_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Telephone:";
            // 
            // Telephone2
            // 
            this.Telephone2.Location = new System.Drawing.Point(431, 190);
            this.Telephone2.Name = "Telephone2";
            this.Telephone2.Size = new System.Drawing.Size(77, 20);
            this.Telephone2.TabIndex = 17;
            this.Telephone2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FirstName_KeyDown);
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Info.ForeColor = System.Drawing.Color.Purple;
            this.Info.Location = new System.Drawing.Point(283, 404);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(262, 16);
            this.Info.TabIndex = 25;
            this.Info.Text = "Your request was send successfully. ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(322, 333);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Country:";
            // 
            // Country
            // 
            this.Country.FormattingEnabled = true;
            this.Country.Items.AddRange(new object[] {
            "Slovakia",
            "Czech Republic",
            "Austria",
            "Hungary",
            "Ukraine",
            "Poland"});
            this.Country.Location = new System.Drawing.Point(375, 330);
            this.Country.Name = "Country";
            this.Country.Size = new System.Drawing.Size(102, 21);
            this.Country.TabIndex = 22;
            this.Country.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FirstName_KeyDown);
            // 
            // Telephone1
            // 
            this.Telephone1.FormattingEnabled = true;
            this.Telephone1.Items.AddRange(new object[] {
            "+421",
            "+420",
            "+43",
            "+36",
            "+380",
            "+48"});
            this.Telephone1.Location = new System.Drawing.Point(375, 190);
            this.Telephone1.Name = "Telephone1";
            this.Telephone1.Size = new System.Drawing.Size(50, 21);
            this.Telephone1.TabIndex = 16;
            this.Telephone1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FirstName_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(489, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Back to login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormRegistrationUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Telephone1);
            this.Controls.Add(this.Country);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.Telephone2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.EmailReg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PasswordReg);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.PostalCode);
            this.Controls.Add(this.City);
            this.Controls.Add(this.Number);
            this.Controls.Add(this.DateOfBirth);
            this.Controls.Add(this.Street);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.FirstName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRegistrationUser";
            this.Text = "Registration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRegistrationUser_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.TextBox Street;
        private System.Windows.Forms.DateTimePicker DateOfBirth;
        private System.Windows.Forms.TextBox Number;
        private System.Windows.Forms.TextBox City;
        private System.Windows.Forms.TextBox PostalCode;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.TextBox PasswordReg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox EmailReg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Telephone2;
        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox Country;
        private System.Windows.Forms.ComboBox Telephone1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
    }
}