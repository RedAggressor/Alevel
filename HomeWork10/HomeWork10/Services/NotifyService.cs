using HomeWork10.Models.Enums;
using HomeWork10.Services.Abstractions;

namespace HomeWork10.Services
{
    internal class NotifyService : INotifyService
    {
        private readonly ILoggerService _logger;

        public NotifyService(ILoggerService loggerService)
        { 
            _logger = loggerService;
        }

        public void Notify(NotifyType notifyType, string message) 
        {
            _logger.Log(LogType.Info,$"Notify send message {message} to {notifyType}");
        }
    }
}
