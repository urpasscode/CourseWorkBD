namespace CourseWork
{
    partial class autentificationForm
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
            this.emailField = new System.Windows.Forms.TextBox();
            this.passwordField = new System.Windows.Forms.TextBox();
            this.signIn = new System.Windows.Forms.Button();
            this.signUp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.autentificationErrorLabel = new System.Windows.Forms.Label();
            this.createAccount = new System.Windows.Forms.Button();
            this.backTiSingIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Электронная почта";
            // 
            // emailField
            // 
            this.emailField.Location = new System.Drawing.Point(169, 86);
            this.emailField.Name = "emailField";
            this.emailField.Size = new System.Drawing.Size(283, 22);
            this.emailField.TabIndex = 2;
            // 
            // passwordField
            // 
            this.passwordField.Location = new System.Drawing.Point(169, 141);
            this.passwordField.Name = "passwordField";
            this.passwordField.Size = new System.Drawing.Size(283, 22);
            this.passwordField.TabIndex = 3;
            // 
            // signIn
            // 
            this.signIn.Location = new System.Drawing.Point(169, 235);
            this.signIn.Name = "signIn";
            this.signIn.Size = new System.Drawing.Size(283, 23);
            this.signIn.TabIndex = 4;
            this.signIn.Text = "Войти";
            this.signIn.UseVisualStyleBackColor = true;
            this.signIn.Click += new System.EventHandler(this.signIn_Click);
            // 
            // signUp
            // 
            this.signUp.Location = new System.Drawing.Point(169, 264);
            this.signUp.Name = "signUp";
            this.signUp.Size = new System.Drawing.Size(283, 23);
            this.signUp.TabIndex = 5;
            this.signUp.Text = "Зарегистрироваться";
            this.signUp.UseVisualStyleBackColor = true;
            this.signUp.Click += new System.EventHandler(this.signUp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Пароль";
            // 
            // autentificationErrorLabel
            // 
            this.autentificationErrorLabel.AutoSize = true;
            this.autentificationErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.autentificationErrorLabel.Location = new System.Drawing.Point(166, 182);
            this.autentificationErrorLabel.Name = "autentificationErrorLabel";
            this.autentificationErrorLabel.Size = new System.Drawing.Size(44, 16);
            this.autentificationErrorLabel.TabIndex = 7;
            this.autentificationErrorLabel.Text = "label4";
            this.autentificationErrorLabel.Visible = false;
            // 
            // createAccount
            // 
            this.createAccount.Location = new System.Drawing.Point(169, 223);
            this.createAccount.Name = "createAccount";
            this.createAccount.Size = new System.Drawing.Size(283, 24);
            this.createAccount.TabIndex = 8;
            this.createAccount.Text = "Создать аккаунт";
            this.createAccount.UseVisualStyleBackColor = true;
            this.createAccount.Visible = false;
            this.createAccount.Click += new System.EventHandler(this.createAccount_Click);
            // 
            // backTiSingIn
            // 
            this.backTiSingIn.Location = new System.Drawing.Point(169, 253);
            this.backTiSingIn.Name = "backTiSingIn";
            this.backTiSingIn.Size = new System.Drawing.Size(283, 23);
            this.backTiSingIn.TabIndex = 9;
            this.backTiSingIn.Text = "Назад";
            this.backTiSingIn.UseVisualStyleBackColor = true;
            this.backTiSingIn.Visible = false;
            this.backTiSingIn.Click += new System.EventHandler(this.backTiSingIn_Click);
            // 
            // autentificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 365);
            this.Controls.Add(this.backTiSingIn);
            this.Controls.Add(this.createAccount);
            this.Controls.Add(this.autentificationErrorLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.signUp);
            this.Controls.Add(this.signIn);
            this.Controls.Add(this.passwordField);
            this.Controls.Add(this.emailField);
            this.Controls.Add(this.label1);
            this.Name = "autentificationForm";
            this.Text = "autentificationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox emailField;
        private System.Windows.Forms.TextBox passwordField;
        private System.Windows.Forms.Button signIn;
        private System.Windows.Forms.Button signUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label autentificationErrorLabel;
        private System.Windows.Forms.Button createAccount;
        private System.Windows.Forms.Button backTiSingIn;
    }
}