namespace CourseWork
{
    partial class userAccount
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
            this.userNameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.userBirth = new System.Windows.Forms.TextBox();
            this.userPN = new System.Windows.Forms.TextBox();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.userEmail = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.changeUserAccount = new System.Windows.Forms.Button();
            this.saveUserAccount = new System.Windows.Forms.Button();
            this.cancelUser = new System.Windows.Forms.Button();
            this.outOfUserAccount = new System.Windows.Forms.Button();
            this.calcelChangesInUserAccount = new System.Windows.Forms.Button();
            this.deleteUserAccount = new System.Windows.Forms.Button();
            this.userAccountErrorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Личный кабинет пользователя";
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(266, 39);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(137, 16);
            this.userNameLabel.TabIndex = 1;
            this.userNameLabel.Text = "*имя пользователя*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Имя";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Почта";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Пароль";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Номер телефона";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 311);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Дата рождения";
            // 
            // userBirth
            // 
            this.userBirth.Location = new System.Drawing.Point(34, 330);
            this.userBirth.Name = "userBirth";
            this.userBirth.Size = new System.Drawing.Size(379, 22);
            this.userBirth.TabIndex = 7;
            // 
            // userPN
            // 
            this.userPN.Location = new System.Drawing.Point(34, 263);
            this.userPN.Name = "userPN";
            this.userPN.Size = new System.Drawing.Size(379, 22);
            this.userPN.TabIndex = 8;
            // 
            // userPassword
            // 
            this.userPassword.Location = new System.Drawing.Point(34, 200);
            this.userPassword.Name = "userPassword";
            this.userPassword.Size = new System.Drawing.Size(379, 22);
            this.userPassword.TabIndex = 9;
            // 
            // userEmail
            // 
            this.userEmail.Location = new System.Drawing.Point(34, 141);
            this.userEmail.Name = "userEmail";
            this.userEmail.Size = new System.Drawing.Size(379, 22);
            this.userEmail.TabIndex = 10;
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(34, 88);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(379, 22);
            this.userName.TabIndex = 11;
            // 
            // changeUserAccount
            // 
            this.changeUserAccount.Location = new System.Drawing.Point(34, 398);
            this.changeUserAccount.Name = "changeUserAccount";
            this.changeUserAccount.Size = new System.Drawing.Size(150, 23);
            this.changeUserAccount.TabIndex = 12;
            this.changeUserAccount.Text = "Редактировать данные";
            this.changeUserAccount.UseVisualStyleBackColor = true;
            this.changeUserAccount.Click += new System.EventHandler(this.changeUserAccount_Click);
            // 
            // saveUserAccount
            // 
            this.saveUserAccount.Location = new System.Drawing.Point(34, 398);
            this.saveUserAccount.Name = "saveUserAccount";
            this.saveUserAccount.Size = new System.Drawing.Size(150, 23);
            this.saveUserAccount.TabIndex = 13;
            this.saveUserAccount.Text = "Сохранить";
            this.saveUserAccount.UseVisualStyleBackColor = true;
            this.saveUserAccount.Click += new System.EventHandler(this.saveUserAccount_Click);
            // 
            // cancelUser
            // 
            this.cancelUser.Location = new System.Drawing.Point(263, 398);
            this.cancelUser.Name = "cancelUser";
            this.cancelUser.Size = new System.Drawing.Size(150, 23);
            this.cancelUser.TabIndex = 14;
            this.cancelUser.Text = "Отменить";
            this.cancelUser.UseVisualStyleBackColor = true;
            this.cancelUser.Click += new System.EventHandler(this.cancelUser_Click);
            // 
            // outOfUserAccount
            // 
            this.outOfUserAccount.Location = new System.Drawing.Point(34, 437);
            this.outOfUserAccount.Name = "outOfUserAccount";
            this.outOfUserAccount.Size = new System.Drawing.Size(150, 25);
            this.outOfUserAccount.TabIndex = 15;
            this.outOfUserAccount.Text = "Выйти из аккаунта";
            this.outOfUserAccount.UseVisualStyleBackColor = true;
            this.outOfUserAccount.Click += new System.EventHandler(this.outOfUserAccount_Click);
            // 
            // calcelChangesInUserAccount
            // 
            this.calcelChangesInUserAccount.Location = new System.Drawing.Point(263, 398);
            this.calcelChangesInUserAccount.Name = "calcelChangesInUserAccount";
            this.calcelChangesInUserAccount.Size = new System.Drawing.Size(150, 23);
            this.calcelChangesInUserAccount.TabIndex = 16;
            this.calcelChangesInUserAccount.Text = "Отменить";
            this.calcelChangesInUserAccount.UseVisualStyleBackColor = true;
            this.calcelChangesInUserAccount.Click += new System.EventHandler(this.calcelChangesInUserAccount_Click);
            // 
            // deleteUserAccount
            // 
            this.deleteUserAccount.Location = new System.Drawing.Point(263, 437);
            this.deleteUserAccount.Name = "deleteUserAccount";
            this.deleteUserAccount.Size = new System.Drawing.Size(150, 25);
            this.deleteUserAccount.TabIndex = 17;
            this.deleteUserAccount.Text = "Удалить аккаунт";
            this.deleteUserAccount.UseVisualStyleBackColor = true;
            this.deleteUserAccount.Click += new System.EventHandler(this.deleteUserAccount_Click);
            // 
            // userAccountErrorLabel
            // 
            this.userAccountErrorLabel.AutoSize = true;
            this.userAccountErrorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.userAccountErrorLabel.Location = new System.Drawing.Point(31, 366);
            this.userAccountErrorLabel.Name = "userAccountErrorLabel";
            this.userAccountErrorLabel.Size = new System.Drawing.Size(44, 16);
            this.userAccountErrorLabel.TabIndex = 18;
            this.userAccountErrorLabel.Text = "label2";
            // 
            // userAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 504);
            this.Controls.Add(this.userAccountErrorLabel);
            this.Controls.Add(this.deleteUserAccount);
            this.Controls.Add(this.calcelChangesInUserAccount);
            this.Controls.Add(this.outOfUserAccount);
            this.Controls.Add(this.cancelUser);
            this.Controls.Add(this.saveUserAccount);
            this.Controls.Add(this.changeUserAccount);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.userEmail);
            this.Controls.Add(this.userPassword);
            this.Controls.Add(this.userPN);
            this.Controls.Add(this.userBirth);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.label1);
            this.Name = "userAccount";
            this.Text = "userAccount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox userBirth;
        private System.Windows.Forms.TextBox userPN;
        private System.Windows.Forms.TextBox userPassword;
        private System.Windows.Forms.TextBox userEmail;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Button changeUserAccount;
        private System.Windows.Forms.Button saveUserAccount;
        private System.Windows.Forms.Button cancelUser;
        private System.Windows.Forms.Button outOfUserAccount;
        private System.Windows.Forms.Button calcelChangesInUserAccount;
        private System.Windows.Forms.Button deleteUserAccount;
        private System.Windows.Forms.Label userAccountErrorLabel;
    }
}