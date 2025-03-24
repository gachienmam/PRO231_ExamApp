using System.Configuration;
using System.Globalization;

namespace ManagementApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.CurrentCulture = new(CultureInfo.CurrentCulture.TextInfo.CultureName);
            Application.Run(new DangNhapForm(ConfigurationManager.AppSettings["ServerAddress"] ?? "http://localhost:5001"));
        }
    }
}