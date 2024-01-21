using Models;

namespace Services.Abstract
{
    internal interface INotifyService
    {
        public void Notify(TypeNoti typeNotify, string message, string ToSend);
    }
}
