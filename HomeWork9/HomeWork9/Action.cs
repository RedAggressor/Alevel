using Abstracts;
using Models.Enum;
using Services.Abstracts;

namespace HomeWork9
{
    internal class Action : IAction
    {
        private readonly ILoggerService _logger;

        public Action(ILoggerService loggerService)
        { 
            _logger = loggerService;
        }

        public void StartMethod() => _logger.Log(LogType.Info, "Start method");

        public void BusinessException()
        {
            _logger.Log(LogType.Warning, "Skipped logic in method");

            throw new BusinessException();
        }

        public void ThrowExeption()
        {
            _logger.Log(LogType.Error, "I broke a logic");

            throw new Exception();
        }
    }
}
