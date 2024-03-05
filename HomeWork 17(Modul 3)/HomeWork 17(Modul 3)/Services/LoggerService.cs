using HomeWork_17_Modul_3_.Config;
using HomeWork_17_Modul_3_.Enums;
using HomeWork_17_Modul_3_.Services.Abstractions;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace HomeWork_17_Modul_3_.Services;

public delegate void LoggerHandle(string message);
internal class LoggerService : ILoggerService
{
    private readonly LoggerOption _loggerOption;
    private readonly IFileService _textService;

    public event LoggerHandle LoggerHandle;

    public LoggerService(IOptions<LoggerOption> loggerOptions, IFileService textService)
    { 
        _loggerOption = loggerOptions.Value;
        _textService = textService;
    }

    public async Task LogAsync(LogType logType, string messageLog)
    {
        string messageTextLog = $"{DateTime.UtcNow}: {logType} : {messageLog}";

        int countMessageLimit = _loggerOption.LimitMessageToFile;

        var counter = await Task.Run(async() => await _textService.WriteToFileAsync(messageTextLog, countMessageLimit));

        Debug.WriteLine($"write log to {_loggerOption.Path}");

        if (counter >= countMessageLimit)
        {
            LoggerHandle?.Invoke("need create new back up to the log file");
        }
    }
}
