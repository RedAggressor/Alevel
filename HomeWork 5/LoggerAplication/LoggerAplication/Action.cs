namespace LoggerAplication
{
    internal class Action
    {
        public static Result StartMethod()
        {
            Logger.GetInstance().Log("Satrt Method", LogType.Info);

            return new Result(true);
        }

        public static Result SkippedLogicInMethod()
        {
            Logger.GetInstance().Log("Skipped Logic In Method", LogType.Warning);

            return new Result(true);
        }

        public static Result IBrokeALogic()
        {
            Logger.GetInstance().Log("I Broke A Logic", LogType.Error);

            return new Result(false, "Action failed by a reason:");
        }
    }
}
