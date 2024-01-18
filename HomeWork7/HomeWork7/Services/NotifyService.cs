using Services.Abstraction;
using Models;

namespace Services
{
    internal class NotifyService : INotifyService
    {
        private ILoggerService _loggerService;

        public NotifyService(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public void Notify(Notify notify, string message, string toSend) // I don`t release notify in my app to many message on console! if need release
        {
            //_loggerService.Log(LogType.Info, $"this message send {notify}:");

            //Console.WriteLine($"{message} send to: {toSend}");
        }
    }
}
