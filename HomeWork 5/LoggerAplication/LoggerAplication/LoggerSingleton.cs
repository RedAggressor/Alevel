using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerAplication
{
    public enum LogType
    {
        Info = 1,
        Warning,
        Error
    }

    internal class LoggerSingleton
    {
        private DateTime LogTime { get; set; }

        private string MessageText { get; set; } = string.Empty;

        private LogType _logType;

        private StringBuilder _logMessage = new StringBuilder();

        private LoggerSingleton() { }

        private static LoggerSingleton _loggerSingletonInstance = null;

        public static LoggerSingleton GetInstance()
        {
            if (_loggerSingletonInstance == null)
            {
                _loggerSingletonInstance = new LoggerSingleton();
            }

            return _loggerSingletonInstance;
        }

        public void Info(string message, LogType logType)
        {
            LogTime = DateTime.Now;

            _logType = logType;

            MessageText = message;

            DisplayLogToConsole();

            WritteToLoglist();
        }

        private void DisplayLogToConsole() => Console.WriteLine($"{LogTime} : {_logType} : {MessageText}");

        public string ShowLoglist() => _logMessage.ToString();

        private void WritteToLoglist() => _logMessage.Append($"{LogTime} : {_logType} : {MessageText}\n");
    }
}
