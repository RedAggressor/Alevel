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
    }

    public async Task<int> WriteToFileAsync(string messageText, int countMessageLimit)
    {
        await _file.SemaphoreSlim.WaitAsync();

        try
        {
            if (_file.Counter >= countMessageLimit)
            {
                using (_file.StreamWriter = new StreamWriter(_file.FullPuth, true))
                {
                    await _file.StreamWriter.WriteAsync($"{messageText}");
                }

                _file.NameFile = DateTime.UtcNow.ToString("MM/dd/yyyy hh.mm.ss.ffftt");
                _file.FullPuth = $"{_file.Path}{_file.NameFile}.txt";
                _file.Counter = 1;
            }
            else
            {
                using (_file.StreamWriter = new StreamWriter(_file.FullPuth, true))
                {
                    await _file.StreamWriter.WriteLineAsync($"{messageText}");
                }

                _file.Counter++;
            }            
        }
        finally
        {
            _file.SemaphoreSlim.Release();
        }

        return _file.Counter;
    }
}
