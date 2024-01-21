using Models;
using Services.Abstract;

namespace Services
{
    internal class LoggerService : ILoggerService
    {
        private List<string> _logList { get; set; } = new List<string>();

        public void Log(TypeLog typeLog, string message)
        {
            DateTime dateTime = DateTime.UtcNow;

            string messageLog = $"{dateTime}:{typeLog}: {message}";

            _logList.Add(messageLog);

            Console.WriteLine(messageLog);
        }
    }
}
