using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CourseWork
{
    public partial class userAccount : Form
    {
        public userAccount()
        {
            InitializeComponent();
        }

        

        public void openAccount()
        {
            userAccountErrorLabel.Visible = false;
            User currentUser = new User(AutentificationClass.UserID);
            try
            {
                userNameLabel.Text = currentUser.UserName;
                userName.Text = currentUser.UserName;
                userEmail.Text = currentUser.UserEmail;
                userPassword.Text = currentUser.UserPassword;
                userPN.Text = currentUser.UserPN;
                userBirth.Text = currentUser.UserBirth;
                userName.ReadOnly= true;
                userEmail.ReadOnly= true;
                userPassword.ReadOnly= true;
                userPN.ReadOnly= true;
                userBirth.ReadOnly= true;
                saveUserAccount.Visible= false;
                calcelChangesInUserAccount.Visible= false;
                changeUserAccount.Visible = true;
                cancelUser.Visible = true;
                
            }
            catch {
                MessageBox.Show("что-то пошло не так при заполнении лк");
            }
        }

        private void cancelUser_Click(object sender, EventArgs e)
        {
            userAccountErrorLabel.Visible = false;
            this.Close();
        }

        private void calcelChangesInUserAccount_Click(object sender, EventArgs e)
        {
            userAccountErrorLabel.Visible = false;
            openAccount();
        }

        //добавить проверку на пустые поля
        //если некоторые поля пустые, то вводить в бд значение нул
        public void changeUser(string name, string email, string password, string PN, string userBirth)
        {
            DateTime birth=DateTime.MinValue;
            if (!(userBirth==null))
            {
                try
                {
                    birth = Convert.ToDateTime(userBirth);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ошибка при конвертации даты");
                }
            }
            
            
            NpgsqlConnection nc = connectToDB.connect();
            try
            {
                string sql = "update fulluser set user_name=@userName, user_email=@userEmail, user_password=@userPassword, " +
                    "user_PN=@userPN, user_birth=@userBirth " +
                    "where user_id=@userId;";
                NpgsqlCommand changeUser = new NpgsqlCommand(sql, nc);
                if (name==null)
                {
                    changeUser.Parameters.AddWithValue("@userName", DBNull.Value);
                }
                else
                {
                    changeUser.Parameters.AddWithValue("@userName", name);
                }
                changeUser.Parameters.AddWithValue("@userEmail", email);
                changeUser.Parameters.AddWithValue("@userPassword", password);
                if (PN==null)
                {
                    changeUser.Parameters.AddWithValue("@userPN", DBNull.Value);
                }
                else
                {
                    changeUser.Parameters.AddWithValue("@userPN", PN);
                }
                if (birth==DateTime.MinValue)
                {
                    changeUser.Parameters.AddWithValue("@userBirth", DBNull.Value);
                }
                else
                {
                    changeUser.Parameters.AddWithValue("@userBirth", birth);
                }
                changeUser.Parameters.AddWithValue("@userId", AutentificationClass.UserID);
                changeUser.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при изменении пользовательских данных" + ex.Message);
            }
            nc.Close();

        }

        private void changeUserAccount_Click(object sender, EventArgs e)
        {
            userAccountErrorLabel.Visible = false;
            cancelUser.Visible= false;
            changeUserAccount.Visible= false;
            userName.ReadOnly = false;
            userEmail.ReadOnly = false;
            userPassword.ReadOnly = false;
            userPN.ReadOnly = false;
            userBirth.ReadOnly = false;
            saveUserAccount.Visible = true;
            calcelChangesInUserAccount.Visible = true;
        }

        public bool checkUserEmail()
        {
            
            Regex checkEmail = new Regex(@"^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+[.][A-Za-z]+$");
            
            Match email = checkEmail.Match(userEmail.Text);
            if (!email.Success)
            {
                userAccountErrorLabel.Visible = true;
                userAccountErrorLabel.Text = "Неверный формат ввода электронной почты";
                return false;
            }
            
            return true;
        }

        public bool checkUserName()
        {
            Regex checkName = new Regex(@"[а-яА-Я_ ]");
            
            Match name = checkName.Match(userName.Text);
            if (!name.Success)
            {
                userAccountErrorLabel.Visible = true;
                userAccountErrorLabel.Text = "Неверный формат ввода имени";
                return false;
            }
            return true;
        }

        public bool checkUserPN()
        {
            Regex checkPhone = new Regex(@"^((\+7|7|8)+([0-9]){10})$");
            Match phone = checkPhone.Match(userPN.Text);
            if (!phone.Success)
            {
                userAccountErrorLabel.Visible = true;
                userAccountErrorLabel.Text = "Неверный формат ввода номера телефона";
                return false;
            }
            return true;
        }

        private void saveUserAccount_Click(object sender, EventArgs e)
        {
            userAccountErrorLabel.Visible = false;
            string name = userName.Text.ToString();
            string email = userEmail.Text.ToString();
            string password = userPassword.Text.ToString();
            string pn = userPN.Text.ToString();
            string birth = userBirth.Text.ToString();
            bool flagToStartChanges = true;
            if (!String.IsNullOrEmpty(userEmail.Text))
            {
                bool f = checkUserEmail();
                if (f)
                {
                    email = userEmail.Text.ToString();
                }
                else
                {
                    userAccountErrorLabel.Visible = true;
                    userAccountErrorLabel.Text = "Неверный формат ввода почты";
                    flagToStartChanges = false;
                }
            }
            else
            {
                userAccountErrorLabel.Visible = true;
                userAccountErrorLabel.Text = "Адрес электронной почты - обязательное поле";
                flagToStartChanges = false;
            }
            if (!String.IsNullOrEmpty(userName.Text))
            {
                bool f = checkUserName();
                if (f)
                {
                    name = userName.Text.ToString();
                }
                else
                {
                    userAccountErrorLabel.Visible = true;
                    userAccountErrorLabel.Text = "Неверный формат ввода имени";
                    flagToStartChanges = false;
                }
            }
            else
            {
                name = null;
            }
            if (!String.IsNullOrEmpty(userPassword.Text))
            {
                    password = userPassword.Text.ToString();
            }
            else
            {
                userAccountErrorLabel.Visible = true;
                userAccountErrorLabel.Text = "Пароль - обязательное поле";
                flagToStartChanges = false;
            }
            if (!String.IsNullOrEmpty(userPN.Text))
            {
                bool f = checkUserPN();
                if (f)
                {
                    pn = userPN.Text.ToString();
                }
                else
                {
                    userAccountErrorLabel.Visible = true;
                    userAccountErrorLabel.Text = "Неверный формат ввода номера телефона";
                    flagToStartChanges = false;
                }
            }
            else
            {
                pn = null;
            }
            if (!String.IsNullOrEmpty(userBirth.Text))
            {
                DateTime checkBirth;
                DateTime minDate = new DateTime(1950, 1, 1);
                DateTime maxDate = new DateTime(2023, 1, 1);
                try
                {
                    checkBirth = Convert.ToDateTime(userBirth.Text);
                    if ((checkBirth>minDate)&&(checkBirth<maxDate))
                    {
                        birth = userBirth.Text.ToString();
                    }
                    else
                    {
                        userAccountErrorLabel.Visible = true;
                        userAccountErrorLabel.Text = "Дата рождения долдна быть больше 01.01.1950";
                        flagToStartChanges = false;
                    }
                }
                catch(Exception ex)
                {
                    //birth = null;
                    flagToStartChanges = false;
                    userAccountErrorLabel.Visible = true;
                    userAccountErrorLabel.Text = "Неверный формат даты рождения";
                }
            }
            else
            {
                birth = null;
            }

            if (flagToStartChanges)
            {
                changeUser(name, email, password, pn, birth);
                User thisUser = new User(AutentificationClass.UserID);
                openAccount();
            }
            else
            {
                MessageBox.Show("Где то произошла ошибка с изменением данных");
            }
        }

        public void restartProgram()
        {
            AutentificationClass.UserID = 0;
            Tags.allTags = null;
            mainForm.noteIndexes = null;
            this.Close();
            Application.Restart();
        }

        private void outOfUserAccount_Click(object sender, EventArgs e)
        {
            userAccountErrorLabel.Visible = false;
            restartProgram();
        }

        public void deleteCurrentAccount(int index)
        {
            
            NpgsqlConnection nc = connectToDB.connect();
            try
            {
                string sql = "delete from fulluser where user_id=@index;";
                NpgsqlCommand deleteUser = new NpgsqlCommand(sql, nc);
                deleteUser.Parameters.AddWithValue("@index", index);
                deleteUser.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении пользователя" + ex.Message);
            }
            nc.Close();
        }

        private void deleteUserAccount_Click(object sender, EventArgs e)
        {
            userAccountErrorLabel.Visible = false;
            var confirmResult = MessageBox.Show("Подтвердите удаление аккаунта",
                                     "Удаление аккаунта",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                deleteCurrentAccount(AutentificationClass.UserID);
                restartProgram();
            }
        }
    }
}
