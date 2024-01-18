using Services.Abstraction;
using Models;

namespace Services
{
    internal class LoggerService : ILoggerService
    {
        public void Log(LogType logType, string message)
        {
            string logMessage = $"{DateTime.UtcNow}:{logType}:{message}";

            Console.WriteLine(logMessage);
        }
    }
}
