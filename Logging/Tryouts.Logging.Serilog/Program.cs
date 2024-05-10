using Serilog;
using Serilog.Core;

namespace Tryouts.Logging.Serilog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Way 1
            Logger logger1 = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            logger1.Information("{Message} has been logged as a sample log.", $"An information message");

            // Way 2
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Information("{Message} has been logged as a sample log.", $"An information message");

            Log.CloseAndFlush();
            Console.ReadKey();
        }
    }
}
