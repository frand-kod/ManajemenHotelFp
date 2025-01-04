using Sistem_Manajemen_Hotel.View;
using Sistem_Manajemen_Hotel.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Manajemen_Hotel
{

    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginController loginController = new LoginController();

            using (var loginForm = new Form_Login())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Jika login berhasil, jalankan form dashboard
                    Application.Run(new Form_Dashboard());
                }
            }
        }
    }

}
