using LauncherApp;
using Sentry;
using System;
using System.Windows.Forms;

namespace Hi_Tech_Hub
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Init the Sentry SDK
            SentrySdk.Init(o =>
            {
                // Tells which project in Sentry to send events to:
                o.Dsn = "https://12982fff733d441c9c400fbd603a990c@sentry.cowr.org/9";
                // When configuring for the first time, to see what the SDK is doing:
                o.Debug = true;
                // Set TracesSampleRate to 1.0 to capture 100% of transactions for performance monitoring.
                // We recommend adjusting this value in production.
                o.TracesSampleRate = 1.0;
            });
            // Configure WinForms to throw exceptions so Sentry can capture them.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);

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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
