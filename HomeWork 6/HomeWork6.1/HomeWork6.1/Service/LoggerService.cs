using Models;

namespace Service
{
    internal class LoggerService
    {
        public void log(LogType logType, string message)
        { 
            Console.WriteLine($"{DateTime.UtcNow}:{logType}: message: {message}");
        }
    }
}
