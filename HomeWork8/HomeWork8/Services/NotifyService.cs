using Models;
using Services.Abstract;

namespace Services
{
    internal class NotifyService : INotifyService
    {
        private ILoggerService _logger;

        public NotifyService(ILoggerService loggerService)
        { 
            _logger = loggerService;
        }
       
        public void Notify(TypeNoti typeNotify, string message, string ToSend)
        {
            _logger.Log(TypeLog.Info, $"Send message to {typeNotify}");
        }
    }
}
