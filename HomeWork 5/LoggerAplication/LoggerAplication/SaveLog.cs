using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                            AnswerYes();

                            break;
                        }
                    case ConsoleKey.N:
                        {
                            AnswerNO();

                            break;
                        }
                    default:
                        {
                            AnswerSomeElse();

                            break;
                        }
                }
            }
        }

        private static void AnswerYes()
        {
            Console.WriteLine();

            Console.WriteLine("Log saves to log.txt");

            File.WriteAllText("log.txt", LoggerSingleton.GetInstance().ShowLoglist());

            checkOutRequest = false;
        }

        private static void AnswerNO()
        {
            Console.WriteLine();

            Console.WriteLine("Log doesn`t save to file");

            checkOutRequest = false;
        }

        private static void AnswerSomeElse()
        {
            Console.WriteLine();

            Console.WriteLine("You enter somthing else... repit");

            checkOutRequest = true;
        }
    }
}
