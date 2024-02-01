using HomeWork10.Models.Enums;

namespace HomeWork10.Services.Abstractions
{
    internal interface ILoggerService
    {
        public void Log(LogType logType, string message);
    }
}
