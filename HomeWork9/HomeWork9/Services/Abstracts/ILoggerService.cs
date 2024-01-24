using Models.Enum;

namespace Services.Abstracts
{
    internal interface ILoggerService
    {
        public void Log(LogType logType, string message);
    }
}
