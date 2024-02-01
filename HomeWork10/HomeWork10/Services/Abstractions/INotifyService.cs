using HomeWork10.Models.Enums;

namespace HomeWork10.Services.Abstractions
{
    internal interface INotifyService
    {
        public void Notify(NotifyType notifyType, string message);
    }
}
