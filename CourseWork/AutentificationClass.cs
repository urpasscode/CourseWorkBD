using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CourseWork
{
    internal class AutentificationClass
    {
        protected static int userID=0;
        protected string email;
        protected string password;

        public static int UserID { get { return userID; } set { userID=value; } }
        public string Email { get { return email; } set { } }
        public string Password { get { return password; } set { } }

        

        //описать про заполнение лк данными
        public int findUser(string username, string password)
        {
            NpgsqlConnection nc= connectToDB.connect(); 
            int f = 0;
            try
            {
                string sql = "select user_id, user_email, user_password from fulluser";
                
                NpgsqlCommand showUser = new NpgsqlCommand(sql, nc);
                NpgsqlDataReader reader = showUser.ExecuteReader();
                while (reader.Read())
                {
                    if ((username.Equals(reader[1].ToString()))&&(password.Equals(reader[2].ToString()))) {
                        f = 2;
                        UserID = Convert.ToInt32(reader[0]);
                        break;
                    } else if ((username.Equals(reader[1].ToString()))&&(!password.Equals(reader[2].ToString())))
                    {
                        f = 1;
                        break;
                    }
                    else if (!username.Equals(reader[1].ToString()))
                    {
                        f = 0;
                    }
                }

            }
            catch
            {
                MessageBox.Show("Ошибка при поиске пользователя");
            }
            return f;
            nc.Close();
        }


        public bool checkUserEmail(string username)
        {
            NpgsqlConnection nc = connectToDB.connect();
            try
            {
                string sql = "select user_email from fulluser";
                NpgsqlCommand showUser = new NpgsqlCommand(sql, nc);
                NpgsqlDataReader reader = showUser.ExecuteReader();
                while (reader.Read())
                {
                    if (username.Equals(reader[0].ToString()))
                    {
                        return false;
                    }
                }
                nc.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка на поиск уникальная ли почта");
            }
            return true;
            nc.Close();
        }

        public void insertNewUser(string username, string pw)
        {
            MessageBox.Show(username);
            MessageBox.Show(pw);
            NpgsqlConnection nc = connectToDB.connect();
            try
            {
                using (nc)
                {
                    using (var command = new NpgsqlCommand("INSERT INTO fulluser (user_email, user_password) VALUES (@em, @pw) returning user_id", nc))
                    {
                        command.Parameters.AddWithValue("@em", username);
                        command.Parameters.AddWithValue("@pw", pw);
                        UserID= Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                nc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении и поиске пользователя" + ex.Message);
            }
            nc.Close();
            
        }

        public bool addNewUser(string username, string password)
        {
            bool f=checkUserEmail(username);
            if (f)
            {
                insertNewUser(username, password);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
