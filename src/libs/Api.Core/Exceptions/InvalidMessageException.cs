using System;

namespace Api.Core.Exceptions
{
    public class InvalidMessageException : Exception
    {
        public InvalidMessageException(string message) : base(message)
        {

        }

        public InvalidMessageException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
