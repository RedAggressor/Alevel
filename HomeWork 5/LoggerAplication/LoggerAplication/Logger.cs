using System.Text;

namespace LoggerAplication
{
    internal class Logger
    {
        private DateTime _logTime = DateTime.UtcNow;

        private string _messageText = string.Empty;

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
            _logTime = DateTime.Now;

            _logType = logType;

            _messageText = message;

            Console.WriteLine(DisplayLogToConsole());

            WritteToLoglist();
        }

        private string DisplayLogToConsole() => $"{_logTime} : {_logType} : {_messageText}";

        public string ShowLoglist() => _logs.ToString();

        internal void SaveLog() => File.WriteAllText("log.txt", ShowLoglist());

        private void WritteToLoglist() => _logs.Append(DisplayLogToConsole()+"\n");
    }
}
