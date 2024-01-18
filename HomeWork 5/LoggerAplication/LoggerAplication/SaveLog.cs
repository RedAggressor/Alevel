namespace LoggerAplication
{
    internal class SaveLog
    {
        public static bool ChoseAnswer(ConsoleKey consoleKey) =>
            consoleKey switch
            {
                ConsoleKey.Y => false,
                _ => true
            };
        
        public static void SaveLogToFile(bool yesOrNo)
        {
            if (!yesOrNo)
            {
                Logger.GetInstance().SaveLog();

                Console.WriteLine("\nLog saves to log.txt");

                return;
            }

            Console.WriteLine("\nLog doesn`t save to file");
        }
    }
}
