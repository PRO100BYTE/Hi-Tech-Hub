using Sentry;
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
            SentrySdk.Init(options =>
            {
                // A Sentry Data Source Name (DSN) is required.
                // See https://docs.sentry.io/product/sentry-basics/dsn-explainer/
                // You can set it in the SENTRY_DSN environment variable, or you can set it in code here.
                options.Dsn = "https://303afc0cfe1e4b379ea50a67ad789e4c@sentry.cowr.org/8";

                // When debug is enabled, the Sentry client will emit detailed debugging information to the console.
                // This might be helpful, or might interfere with the normal operation of your application.
                // We enable it here for demonstration purposes when first trying Sentry.
                // You shouldn't do this in your applications unless you're troubleshooting issues with Sentry.
                options.Debug = true;

                // This option is recommended. It enables Sentry's "Release Health" feature.
                options.AutoSessionTracking = true;

                // This option is recommended for client applications only. It ensures all threads use the same global scope.
                // If you're writing a background service of any kind, you should remove this.
                options.IsGlobalModeEnabled = true;

                // This option will enable Sentry's tracing features. You still need to start transactions and spans.
                options.EnableTracing = true;
            });

            // Transaction can be started by providing, at minimum, the name and the operation
            var transaction = SentrySdk.StartTransaction(
              "test-transaction-name",
              "test-transaction-operation"
            );

            // Transactions can have child spans (and those spans can have child spans as well)
            var span = transaction.StartChild("test-child-operation");

            // ...
            // (Perform the operation represented by the span/transaction)
            // ...

            span.Finish(); // Mark the span as finished
            transaction.Finish(); // Mark the transaction as finished and send it to Sentry

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
