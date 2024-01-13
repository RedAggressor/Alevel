using Models;

namespace Service
{
    internal class NotificationService
    {
        private LoggerService _loggerService;

        public NotificationService(LoggerService loggerService) 
        { 
            _loggerService = loggerService;
        }

        public void Notify(string message)
        {
            string massageToNotify = $"This message send you to email: {message}";

            _loggerService.log(LogType.Info, massageToNotify);
        }
    }
}
