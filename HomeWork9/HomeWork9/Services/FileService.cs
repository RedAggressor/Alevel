using Services.Abstracts;

namespace Services
{
    internal class FileService : IFileService
    {
        private readonly static string str;
        private const string _path = $"C:\\Users\\Сім'я\\source\\repos\\HomeWork9\\HomeWork9\\Log\\";

        static FileService()
        {
            DeleteOverFile();

            str = DateTime.Now.ToString("MM/dd/yyyy hh.mm.ss.ffftt");
        }
        
        public void SaveMessage(string message) 
        {
            string path = Path.GetFullPath($"{_path}{str}.txt");
            
            FileInfo file = new FileInfo(path);
            
            using (StreamWriter swe = file.AppendText())
            {
                swe.WriteLine(message);
            }
        }

        private static void DeleteOverFile()
        {
            if ((Directory.GetFiles(_path).Length >= 4))
            {
                File.Delete(Directory.GetFiles(_path).First());
            }
        }
    }
}
