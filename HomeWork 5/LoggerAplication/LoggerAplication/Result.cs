namespace LoggerAplication
{
    internal class Result
    {
        private bool Status { get; set; }

        private string Message { get; set; } = string.Empty;

        public Result(bool status)
        {
            Status = status;
        }

        public Result(bool status, string message)
        {
            Message = message;

            Status = status;

            if (Status == false)
            {
                Logger.GetInstance().Log(Message, LogType.Error);
            }
        }
    }
}
