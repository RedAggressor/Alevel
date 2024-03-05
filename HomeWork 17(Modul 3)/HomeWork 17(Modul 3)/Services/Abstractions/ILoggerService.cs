using HomeWork_17_Modul_3_.Enums;

namespace HomeWork_17_Modul_3_.Services.Abstractions;

internal interface ILoggerService
{
    public event LoggerHandle LoggerHandle;
    public Task LogAsync(LogType logType, string messageLog);
}
