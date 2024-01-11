﻿using System.Threading.Tasks;

namespace LoggerAplication
{
    internal class Starter
    {
        public static void Run()
        {
            for (int i = 0; i <= 100; i++)
            {

                switch (new Random().Next(1, 4))
                {
                    case 1:
                        {
                            Action.StartMethod();

                            break;
                        }

                    case 2:
                        {
                            Action.SkippedLogicInMethod();

                            break;
                        }

                    case 3:
                        {
                            Action.IBrokeALogic();

                            break;
                        }
                }
                Thread.Sleep(200);
            }
            SaveLog.SaveLogToFile();
        }
    }
}