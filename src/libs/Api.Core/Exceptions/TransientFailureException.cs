using System;

namespace Api.Core.Exceptions
{
    public class TransientFailureException : Exception
    {
        public TransientFailureException(string message, Exception ex) : base(message, ex)
        {
            
        }
    }
}