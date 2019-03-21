using DiaryApp.Data;
using DiaryApp.Data.Models;
using DiaryApp.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiaryApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var StartingForm = new LoginForm();
            StartingForm.Show();
            Application.Run();
        }
    }
}
