using CefSharp;
using CefSharp.WinForms;
using System;
using System.Windows.Forms;

namespace HiTechBrowser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Initialize CefSharp if not already initialized
            if (!Cef.IsInitialized) // Добавил проверку
            {
                Cef.Initialize(new CefSettings()); // Добавил аргумент
            }

            // Parse the command line argument for the link
            string link = "https://hitech.pro100byte.ru"; // Default link
            if (args.Length > 0 && args[0].StartsWith("--link="))
            {
                link = args[0].Substring(7); // Remove the --link= part
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(link)); // Pass the link to the form constructor
        }
    }
}
