using LauncherApp;
using System;
using System.Diagnostics;
using System.Windows.Forms; // Добавил эту директиву

namespace Hi_Tech_Hub
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Теперь компилятор знает, что такое Form1
        }
    }
}
