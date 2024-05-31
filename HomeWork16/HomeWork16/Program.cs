using HomeWork16.Enums;

namespace HomeWork16;

internal class Program
{
    static void Main(string[] args)
    {
        var messageBox = new MessageBox();

        messageBox.NotifyState += (State state) =>
        {
            if (state == State.OK)
            {
                Console.WriteLine($"{state} - the operation has been confirmed");
            }
            else
            {
                Console.WriteLine($"{state} - the operation was rejected");
            }
        };

        var task = Task.Run(() => messageBox.OpenAsync());

        task.Wait();
    }
}
