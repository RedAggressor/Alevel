using Services.Abstracts;

namespace Services
{
    internal class FileService : IFileService
    {
        private readonly static string str;
        private const string _path = "C:\\projects\\Alevel\\HomeWork9\\HomeWork9\\Log\\";

        static FileService()
        {
            DeleteOverFile();

            str = DateTime.UtcNow.ToString("MM/dd/yyyy hh.mm.ss.ffftt");
        }
        
        public void SaveMessage(string message) 
        {
            string path = Path.GetFullPath($"{_path}{str}.txt");
            
            FileInfo file = new FileInfo(path);
            
            using (StreamWriter streamWriter = file.AppendText())
            {
                streamWriter.WriteLine(message);
            }
        }

        private static void DeleteOverFile()
        {
            int countFile = Directory.GetFiles(_path).OrderBy(p=>p).Count();

            if (countFile >= 3)
            {
                File.Delete(Directory.GetFiles(_path).First());
            }
        }
    }
}
