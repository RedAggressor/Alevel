using System.Text;

namespace LoggerAplication
{
    internal class Logger
    {
        private DateTime LogTime { get; set; }

        private string MessageText { get; set; } = string.Empty;

        private LogType _logType;

        private StringBuilder _logs = new StringBuilder();

        private static Logger _loggerInstance = null;

        private Logger() { }

        public static Logger GetInstance()
        {
            if (_loggerInstance == null)
            {
                _loggerInstance = new Logger();
            }

            return _loggerInstance;
        }

        public void Log(string message, LogType logType)
        {
            LogTime = DateTime.Now;

            _logType = logType;

            MessageText = message;

            DisplayLogToConsole();

            WritteToLoglist();
        }

        private void DisplayLogToConsole() => Console.WriteLine($"{LogTime} : {_logType} : {MessageText}");

        public string ShowLoglist() => _logs.ToString();

        internal void SaveLog() => File.WriteAllText("log.txt", ShowLoglist());

        private void WritteToLoglist() => _logs.Append($"{LogTime} : {_logType} : {MessageText}\n");
    }
}
