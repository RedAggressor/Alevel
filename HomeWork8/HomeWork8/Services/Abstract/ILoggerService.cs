using Models;

namespace Services.Abstract
{
    internal interface ILoggerService
    {
        public void Log(TypeLog typeLog, string message);
    }
}
