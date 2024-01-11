namespace LoggerAplication
{
    internal class SaveLog
    {
        private static bool _checkOutRequest = true;
        public static void AskSaveLogToFile()
        {
            _checkOutRequest = true;

            while (_checkOutRequest)
            {
                Console.WriteLine("Does save the log to txt file? Y/N");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        {
                            Console.WriteLine();

                            Console.WriteLine("Log saves to log.txt");

                            Logger.GetInstance().SaveLog();

                            _checkOutRequest = false;

                            break;
                        }
                    case ConsoleKey.N:
                        {
                            Console.WriteLine();

                            Console.WriteLine("Log doesn`t save to file");

                            _checkOutRequest = false;

                            break;
                        }
                    default:
                        {
                            Console.WriteLine();

                            Console.WriteLine("You enter somthing else... repit");

                            _checkOutRequest = true;

                            break;
                        }
                }
            }
        }
    }
}
