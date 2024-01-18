using Models;

namespace Services.Abstraction
{
    internal interface INotifyService
    {
        public void Notify(Notify notify, string message, string toSend);
    }
}
