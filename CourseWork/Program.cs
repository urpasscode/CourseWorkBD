using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //autentificationForm form1 = new autentificationForm();
            //mainForm form2 = new mainForm();
            //form1.FormClosed += (sender, args) => form2.Show(); // При закрытии Form1 показывается Form2
            Application.Run(new mainForm());
        }
    }
}
