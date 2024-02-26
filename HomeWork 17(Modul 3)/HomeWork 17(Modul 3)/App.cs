using HomeWork_17_Modul_3_.Enums;
using HomeWork_17_Modul_3_.Services.Abstractions;

namespace HomeWork_17_Modul_3_;

internal class App
{
    private ILoggerService _loggerService;

    public App(ILoggerService loggerService)
    {
        _loggerService = loggerService;
    }

    public void Start()
    {
        _loggerService.LoggerHandle += message => Console.WriteLine(message);

        var task = Task.Run(async () => await RunFirst());
        var task2 = Task.Run(async () => await RunSecond());

        Task.WaitAll(task, task2);
    }

    private async Task RunFirst()
    {
        for (int i = 1; i <= 50; i++)
        {
           await Task.Run(async() => await _loggerService.LogAsync(LogType.Info, $"Task1 {i}"));
        }
    }

    private async Task RunSecond()
    {
        for (int i = 1; i <= 50; i++)
        {
           await Task.Run(async() => await _loggerService.LogAsync(LogType.Info, $"Task2 {i}"));
        }
    }
}
