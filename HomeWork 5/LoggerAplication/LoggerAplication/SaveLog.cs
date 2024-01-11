namespace LoggerAplication
{
    internal class SaveLog
    {
        private static bool checkOutRequest = true;
        public static void AskSaveLogToFile()
        {
            checkOutRequest = true;

            while (checkOutRequest)
            {
                Console.WriteLine("Does save the log to txt file? Y/N");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        {
                            Console.WriteLine();

                            Console.WriteLine("Log saves to log.txt");

                            Logger.GetInstance().SaveLog();

                            checkOutRequest = false;

                            break;
                        }
                    case ConsoleKey.N:
                        {
                            Console.WriteLine();

                            Console.WriteLine("Log doesn`t save to file");

                            checkOutRequest = false;

                            break;
                        }
                    default:
                        {
                            Console.WriteLine();

                            Console.WriteLine("You enter somthing else... repit");

                            checkOutRequest = true;

                            break;
                        }
                }
            }
        }
    }
}
