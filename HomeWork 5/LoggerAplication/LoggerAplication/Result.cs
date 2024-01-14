namespace LoggerAplication
{
    internal class Result
    {
        private bool _status;

        private string _message = string.Empty;

        public Result(bool status) 
        {
            _status = status;
        }

        public Result(bool status, string message): this (status)
        {
            _message = message;

            if (_status == false)
            {
                Logger.GetInstance().Log(_message, LogType.Error);
            }
        }
    }
}
