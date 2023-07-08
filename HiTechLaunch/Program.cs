using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace HiTechLaunch
{
    class Program
    {
        // Путь к исполняемому файлу Hi-Tech Room.exe
        private const string HTR_PATH = @"C:\Hub\Hi-TechHub.exe";

        static void Main(string[] args)
        {
            // Завершаем все процессы с именем "explorer"
            KillProcessesByName("explorer");
            // Запускаем процесс Hi-Tech Room.exe
            Process htrProcess = StartProcess(HTR_PATH);
            // Проверяем, не завершился ли процесс
            while (true)
            {
                // Если процесс завершился, запускаем его снова
                if (htrProcess.HasExited)
                {
                    htrProcess = StartProcess(HTR_PATH);
                }
                // Ждем 1 секунду перед следующей проверкой
                Thread.Sleep(1000);
            }
        }


        // Метод для завершения всех процессов с заданным именем
        private static void KillProcessesByName(string name)
        {
            // Получаем список всех процессов с заданным именем
            Process[] processes = Process.GetProcessesByName(name);
            // Завершаем каждый из них
            foreach (Process p in processes)
            {
                p.Kill();
            }
        }

        // Метод для запуска процесса по заданному пути
        private static Process StartProcess(string path)
        {
            // Создаем объект ProcessStartInfo с нужными параметрами
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = path;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            // Запускаем процесс и возвращаем его
            return Process.Start(psi);
        }
    }
}
