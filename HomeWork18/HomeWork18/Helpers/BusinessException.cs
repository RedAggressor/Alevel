namespace HomeWork18.Helpers
{
    internal class BusinessException : Exception
    {
        public string? ErrorCode { get; }

        public BusinessException(string message)
            : base (message) { }

        public BusinessException(string message, Exception exception)
            : base (message, exception) { }

        public BusinessException(string message, string errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
