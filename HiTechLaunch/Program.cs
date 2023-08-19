using System.Diagnostics;
using System.Threading;

namespace HiTechLaunch
{
    class Program
    {
        // Путь к исполняемому файлу Hi-TechHub.exe
        private const string HTR_PATH = @"Hi-TechHub.exe";

        static void Main(string[] args)
        {
            // Запускаем процесс Hi-TechHub.exe
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
