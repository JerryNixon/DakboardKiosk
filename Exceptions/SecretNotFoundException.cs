using System;

namespace DakboardKiosk.Exceptions
{
    public class SecretNotFoundException : Exception
    {
        public SecretNotFoundException(string message)
            : base(message)
        {
        }

        public SecretNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public SecretNotFoundException()
        {
        }
    }
}
