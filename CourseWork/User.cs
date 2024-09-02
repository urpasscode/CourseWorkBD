using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    internal class User
    {
        int userID;
        string userName;
        string userEmail;
        string userPassword;
        string userPN;
        string userBirth;

        public int UserID { get { return userID; } set { userID = value; } }
        public string UserName { get { return userName;} set { userName = value; } }
        public string UserEmail { get { return userEmail; } set { userEmail = value; } }
        public string UserPassword { get { return userPassword; } set { userPassword = value; } }
        public string UserPN { get { return userPN; } set { userPN = value; } }
        public string UserBirth { get { return userBirth; } set { userBirth = value; } }

        public User(int userID, string userName, string userEmail, string userPassword, string userPN, string userBirth)
        {
            UserID = userID;
            UserName = userName;
            UserEmail = userEmail;
            UserPassword = userPassword;
            UserPN = userPN;
            UserBirth = userBirth;
        }

        public User (int userId)
        {
            NpgsqlConnection nc = connectToDB.connect();
            int f = 0;
            try
            {
                string command = "select user_id, user_name, user_email, user_password, user_pn, user_birth from fulluser where user_id= @_userId";
                NpgsqlCommand user = new NpgsqlCommand(command, nc);
                user.Parameters.AddWithValue("@_userId", userId);
                NpgsqlDataReader reader = user.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        try
                        {
                            UserID = reader.GetInt32(0);
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка в юзер id");
                        }
                        try
                        {
                            UserName = reader.GetString(1);
                        }
                        catch { UserName = null; }
                        try
                        {
                            UserEmail = reader.GetString(2);
                        }
                        catch { UserEmail=null; }

                        try
                        {
                            UserPassword = reader.GetString(3);
                        }
                        catch { userPassword=null; }
                        try
                        {
                            UserPN = reader.GetString(4);
                        }
                        catch { UserPN=null; }
                        try
                        {

                            UserBirth = reader.GetDateTime(5).ToShortDateString();

                        }
                        catch { UserBirth=null; }

                    }
                }
                else
                {
                    MessageBox.Show("нет ни одной строки");
                }
            }
            catch
            {
                MessageBox.Show("ошибка при заполнении данных пользователя");
            }
        }
    }

}
