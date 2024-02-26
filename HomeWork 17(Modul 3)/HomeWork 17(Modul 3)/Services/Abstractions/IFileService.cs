namespace HomeWork_17_Modul_3_.Services.Abstractions;

internal interface IFileService
{
    public Task<int> WriteToFileAsync(string messageTextToLog, int countMessageLimit);
}
