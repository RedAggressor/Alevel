using HomeWork_17_Modul_3_.Models;
using HomeWork_17_Modul_3_.Services.Abstractions;

namespace HomeWork_17_Modul_3_.Services;

internal class FileService : IFileService
{
    private Files? _file;
    public FileService()
    {
        _file = new Files();
        _file.FullPuth = $"{_file.Path}{_file.NameFile}.txt";
        _file.StreamWriter = new StreamWriter(_file.FullPuth);
    }

    public async Task<int> WriteToFileAsync(string messageText, int countMessageLimit)
    {
        await _file.SemaphoreSlim.WaitAsync();

        try
        {
            if (_file.Counter >= countMessageLimit)
            {
                _file.NameFile = DateTime.UtcNow.ToString("MM/dd/yyyy hh.mm.ss.ffftt");
                _file.FullPuth = $"{_file.Path}{_file.NameFile}.txt";
                _file.StreamWriter = new StreamWriter(_file.FullPuth);
                _file.Counter = 0;
            }

            await _file.StreamWriter.WriteLineAsync(messageText);
            await _file.StreamWriter.FlushAsync();

            _file.Counter++;
        }
        finally
        {
            _file.SemaphoreSlim.Release();
        }
        return _file.Counter;
    }
}
