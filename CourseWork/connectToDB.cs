using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public static class connectToDB
    {
        public static NpgsqlConnection connect()
        {
            string connString = "Server=localhost;Port=5432;Username=postgres;Password=nastya123;Database=bihd_labs";
            NpgsqlConnection nc = new NpgsqlConnection(connString);
            try
            {
                //Открываем соединение.
                nc.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подключении к БД");
            }
            return nc;
        }
    }
}
