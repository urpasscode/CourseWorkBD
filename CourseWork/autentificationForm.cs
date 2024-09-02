using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;


namespace CourseWork
{
    public partial class autentificationForm : Form
    {
        public autentificationForm()
        {
            InitializeComponent();
        }


        private bool checkSignIn(string email, string password)
        {
            AutentificationClass oldUser = new AutentificationClass();
            int f = oldUser.findUser(email, password);
            if (f == 2)
            {
                setCurrentUser();
                return true;
            }
            else if (f == 1)
            {
                autentificationErrorLabel.Text = "Неверный пароль";
                autentificationErrorLabel.Visible = true;
                

            }
            else if (f == 0)
            {
                autentificationErrorLabel.Text = "Нет такого пользователя";
                autentificationErrorLabel.Visible = true;
            }
            return false;
        }

        private void signIn_Click(object sender, EventArgs e)
        {
            string email = emailField.Text;
            string password = passwordField.Text;
            bool f = checkSignIn(email, password);
            if (f)
            {
                this.Close();
            }
            
        }

        public void setCurrentUser()
        {
            User currentUser = new User(AutentificationClass.UserID);
        }

        
        private void signUp_Click(object sender, EventArgs e)
        {
            autentificationErrorLabel.Visible=false;
            backTiSingIn.Visible = true;
            signIn.Visible = false;
            label1.Text = "Введите электронную почту";
            label3.Text = "Придумайте пароль";
            signIn.Visible = false;
            signUp.Visible = false;
            createAccount.Visible = true;
            emailField.Text = "";
            passwordField.Text = "";

        }

        public bool checkSignUp(string email, string password)
        {
            AutentificationClass newUser= new AutentificationClass();
            bool f=newUser.addNewUser(email, password);
            if (f)
            {
                return true;
            }
            return false;
        }

        public bool checkFields()
        {
            //@"^[^@\s]+@[^@\s]+\.[^@\s]+$
            Regex checkEmail = new Regex(@"^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+[.][A-Za-z]+$");
            if (String.IsNullOrWhiteSpace(emailField.Text))
            {
                autentificationErrorLabel.Visible = true;
                autentificationErrorLabel.Text = "Введите адрес электронной почты";
                return false;
            }
            else if (!String.IsNullOrWhiteSpace(emailField.Text))
            {
                string mail=emailField.Text;
                Match check = checkEmail.Match(mail);
                if (!check.Success)
                {
                    autentificationErrorLabel.Visible = true;
                    autentificationErrorLabel.Text = "Неверный формат почты";
                    return false;
                } else
                {
                    if (String.IsNullOrWhiteSpace(passwordField.Text))
                    {
                        autentificationErrorLabel.Visible = true;
                        autentificationErrorLabel.Text = "Введите пароль";
                        return false;
                    }
                }
            }
            return true;
        }


        private void createAccount_Click(object sender, EventArgs e)
        {
            autentificationErrorLabel.Visible = false;
            bool f=checkFields();
            if (f)
            {
                string email = emailField.Text;
                string password = passwordField.Text;
                bool f1 = checkSignUp(email, password);
                if (f1)
                {
                    this.Close();
                }
                else if (!f1)
                {
                    autentificationErrorLabel.Visible = true;
                    autentificationErrorLabel.Text = "Пользователь с такой почтой уже существует";
                }
            }
        }

        private void backTiSingIn_Click(object sender, EventArgs e)
        {
            createAccount.Visible=false;
            backTiSingIn.Visible=false;
            signIn.Visible = true;
            signUp.Visible = true;
            emailField.Text = "";
            passwordField.Text = "";
            label1.Text = "Электронная почта";
            label3.Text = "Пароль";
            autentificationErrorLabel.Visible=false;
        }
    }   
}
