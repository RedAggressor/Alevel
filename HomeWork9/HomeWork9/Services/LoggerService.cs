using Config;
using Microsoft.Extensions.Options;
using Models.Enum;
using Services.Abstracts;
using System.Diagnostics;

namespace Services
{
    internal class LoggerService : ILoggerService
    {
        private readonly LoggerOption _loggerOptions;
        private readonly IFileService _file;
        public LoggerService(IFileService fileService, IOptions<LoggerOption> loggerOption)
        { 
            _file = fileService;
            _loggerOptions = loggerOption.Value;
        }
        public void Log(LogType logType, string message)
        {
            DateTime dateTime = DateTime.Now;

            string messageLog = $"{dateTime}:{logType}:{message}";

            Console.WriteLine(messageLog);

            _file.SaveMessage(messageLog);

            Debug.WriteLine($"write log to {_loggerOptions.Path}");

        }
    }
}
