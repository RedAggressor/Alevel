namespace LoggerAplication
{
    internal class Starter
    {
        public static void Run()
        {
            for (int i = 0; i <= 100; i++)
            {
                int randomNumber = new Random().Next(1, 4);

                StartAction(randomNumber);

                Thread.Sleep(200);
            }

            TaskSaveLog();
        }

        private static Result StartAction(int number) =>
            number switch
            {
                1 => Action.StartMethod(),

                2 => Action.SkippedLogicInMethod(),

                3 => Action.BrokeALogic()
            };

        private static void TaskSaveLog()
        {
            Console.WriteLine("Save the log y/n?");

            ConsoleKey consoleKey = Console.ReadKey().Key;

            bool yesOrNo = SaveLog.ChoseAnswer(consoleKey);

            SaveLog.SaveLogToFile(yesOrNo);
        }
    }
}
