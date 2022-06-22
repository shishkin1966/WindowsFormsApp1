using System;
using System.Windows.Forms;
using WindowsFormsApp1.App;

namespace WindowsFormsApp1
{
    static class Program
    {
        public const string NAME = "Application";

        private readonly static ServiceLocator _sl = new ServiceLocator(ServiceLocator.NAME);

        public static ServiceLocator SL
        {
            get
            {
                return _sl;
            }
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SL.Start();

            Application.Run(new MainForm());
        }
    }
}
