using System;

namespace DakboardKiosk.Exceptions
{
    public class InvalidApiKeyException : Exception
    {
        public InvalidApiKeyException(string message)
            : base(message)
        {
        }

        public InvalidApiKeyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public InvalidApiKeyException()
        {
        }
    }
}
