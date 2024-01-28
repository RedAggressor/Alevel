using Models;

namespace Services.Abstraction
{
    internal interface ILoggerService
    {
        public void Log(LogType logType, string message);
    }
}
