using HomeWork16.Enums;

namespace HomeWork16;

public delegate void MessageBoxDelegate (State state);

internal class MessageBox
{
    public event MessageBoxDelegate? closedWindods;
    public async Task Open()
    {
        Console.WriteLine("Window is open");

        await Task.Delay(3000);

        Console.WriteLine("Window was closed by the user");

        var randomState = (State)new Random().Next(0, 2);

        closedWindods?.Invoke(randomState);
    }
}
