using Service;
using Repository;

namespace HomeWork6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoggerService logger = new LoggerService();

            Store store = new Store(new ItemService(new ItemRepository(), logger, new NotificationService(logger)));

            store.Start();
        }
    }
}
