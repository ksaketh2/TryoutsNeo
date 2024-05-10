using Microsoft.Extensions.Logging;

namespace Tryouts.Logging.BuiltIn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ILoggerFactory loggerFactory =
                LoggerFactory.Create(builder =>
                {
                    builder.AddConsole();
                    if (OperatingSystem.IsWindows())
                    {
                        builder.AddEventLog();
                    }
                });
            
            ILogger logger = loggerFactory.CreateLogger(nameof(Program));

            logger.LogInformation("{Message} has been logged as a sample log.", $"An information message");

            Console.ReadKey();
        }
    }
}
