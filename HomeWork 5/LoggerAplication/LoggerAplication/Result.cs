using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                LoggerSingleton.GetInstance().Info(Message, LogType.Error);
            }
        }
    }
}
