using HomeWork10.Config;
using HomeWork10.Models.Enums;
using HomeWork10.Services.Abstractions;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace HomeWork10.Services
{
    internal class LoggerService : ILoggerService
    {
        private readonly LoggerOption _loggerOption;
        public LoggerService(IOptions<LoggerOption> loggerOptions)
        { 
            _loggerOption = loggerOptions.Value;
        }
        public void Log(LogType logType, string message)
        {
            string logMessage = $"{DateTime.Now}: {logType} : {message}";

            Console.WriteLine(logMessage);

            Debug.WriteLine($"write log to {_loggerOption.Path}");
        }
    }
}
