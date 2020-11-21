using System.Collections.Generic;

namespace AspNetCore.Common.Messages
{
    public class ExceptionMessage
    {
        public string Message { set; get; }
        public List<ExceptionMessage> Details { set; get; }
        public ExceptionMessage()
        {

        }
        public ExceptionMessage(string message)
        {
            Message = message;
        }
    }
}
